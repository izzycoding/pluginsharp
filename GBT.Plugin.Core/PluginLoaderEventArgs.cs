using System;
using System.IO;

namespace GBT.Plugin.Core
{
    public class PluginLoaderEventArgs : EventArgs
    {
        public FileInfo AssemblyInfo { get; set; }

        public PluginLoaderEventArgs(string assemblyPath)
            : this(new FileInfo(assemblyPath))
        {
        }

        public PluginLoaderEventArgs(FileInfo assembly)
        {
            AssemblyInfo = assembly;
        }
    }
}
