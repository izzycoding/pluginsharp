using System;
using System.Collections.Generic;
using System.IO;

namespace GBT.Plugin.Core
{
    public class PluginLoaderEventArgs : EventArgs
    {
        public FileInfo AssemblyInfo { get; }

        public List<Type> LoadedPluginTypes { get; }

        public PluginLoaderEventArgs(string assemblyPath, List<Type> loadedPluginTypes)
            : this(new FileInfo(assemblyPath), loadedPluginTypes)
        {
        }

        public PluginLoaderEventArgs(FileInfo assembly, List<Type> loadedPluginTypes)
        {
            AssemblyInfo = assembly;
            LoadedPluginTypes = loadedPluginTypes;
        }
    }
}
