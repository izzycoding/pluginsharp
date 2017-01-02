﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GBT.Plugin.Core
{
    public class PluginLoader
    {
        private const string DefaultSearchPattern = "*.dll";

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

            foreach (var path in directoryPaths)
            {
                LoadFromDirectory(Path.Combine(path, "Plugins"), searchPattern);
            }
        }

        private static void AssemblyInitializer(object sender, AssemblyLoadEventArgs args)
        {
            // force load of all types that are decorated with PluginAttribute
            // ReSharper disable once UnusedVariable
            var loadedPlugins = args.LoadedAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsPublic)
                .Select(t => t.GetCustomAttribute<PluginAttribute>())
                .ToList();
        }

        private static void LoadFromDirectory(string directory, string searchPattern = DefaultSearchPattern)
        {
            LoadFromDirectory(new DirectoryInfo(directory), searchPattern);
        }

        private static void LoadFromDirectory(DirectoryInfo directory, string searchPattern = DefaultSearchPattern)
        {
            if (!directory.Exists) return;

            foreach (var plugin in directory.GetFiles(searchPattern))
            {
                Assembly.LoadFrom(plugin.FullName);
            }
        }
    }
}