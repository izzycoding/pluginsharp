using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GBT.Plugin.Core
{
    public delegate void AssemblyLoaded(object sender, PluginLoaderEventArgs e);

    public static class PluginLoader
    {
        private const string DefaultSearchPattern = "*.dll";

        private static bool _isInitialized;
        private static readonly ConcurrentDictionary<string, FileSystemWatcher> FolderWatchers = new ConcurrentDictionary<string, FileSystemWatcher>();
        private static readonly ConcurrentBag<string> LoadedAssemblies = new ConcurrentBag<string>();

        public static event AssemblyLoaded PluginLoaded;

        public static void RegisterPlugins(AppDomain domain, params string[] directoryPaths)
        {
            RegisterPlugins(domain, directoryPaths.Where(x => !string.IsNullOrEmpty(x)));
        }

        public static void RegisterPlugins(AppDomain domain, string searchPattern, params string[] directoryPaths)
        {
            RegisterPlugins(domain, searchPattern, directoryPaths.Where(x => !string.IsNullOrEmpty(x)));
        }

        public static void RegisterPlugins(AppDomain domain, IEnumerable<string> directoryPaths)
        {
            RegisterPlugins(domain, DefaultSearchPattern, directoryPaths);
        }

        public static void RegisterPlugins(AppDomain domain, string searchPattern, IEnumerable<string> directoryPaths)
        {
            domain.AssemblyLoad += AssemblyInitializer;

            Parallel.ForEach(directoryPaths, path => LoadFromDirectory(Path.Combine(path, "Plugins"), searchPattern));

            _isInitialized = true;
        }

        private static void AssemblyInitializer(object sender, AssemblyLoadEventArgs e)
        {
            // force load of all types that are decorated with PluginAttribute
            // ReSharper disable once UnusedVariable
            var loadedPlugins = e.LoadedAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsPublic)
                .Select(t => t.GetCustomAttribute<PluginAttribute>())
                .ToList();
            var pluginPath = e.LoadedAssembly.Location;
            LoadedAssemblies.Add(pluginPath);

            // Notify user of dynamically loaded plugins
            if (_isInitialized) { PluginLoaded?.Invoke(sender, new PluginLoaderEventArgs(pluginPath)); }
        }

        private static void LoadFromDirectory(string directory, string searchPattern = DefaultSearchPattern)
        {
            LoadFromDirectory(new DirectoryInfo(directory), searchPattern);
        }

        private static void LoadFromDirectory(DirectoryInfo directory, string searchPattern = DefaultSearchPattern)
        {
            if (!directory.Exists) return;

            Parallel.ForEach(directory.GetFiles(searchPattern), plugin => LoadPlugin(plugin.FullName));

            RegisterPluginDirectory(directory, searchPattern);
        }

        private static void RegisterPluginDirectory(FileSystemInfo directory, string searchPattern = DefaultSearchPattern)
        {
            if (FolderWatchers.ContainsKey(directory.FullName)) return;

            var watcher = new FileSystemWatcher
            {
                Path = directory.FullName,
                Filter = searchPattern,
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };
            while (!FolderWatchers.TryAdd(directory.FullName, watcher)) { }
            watcher.Changed += DynamicPluginLoader;
        }

        private static void DynamicPluginLoader(object sender, FileSystemEventArgs e)
        {
            LoadPlugin(e.FullPath);
        }

        private static void LoadPlugin(string filePath)
        {
            if (LoadedAssemblies.Any(x => x == filePath)) return;
            Assembly.LoadFrom(filePath);
        }
    }
}
