using System;
using System.Windows.Forms;
using GBT.Plugin.Core;

namespace GBT.Plugin.DemoApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Note: Change this as required to load and auto register PluginAttribute decorated types
            PluginLoader.RegisterPlugins(
                AppDomain.CurrentDomain,
                "GBT.Plugin.Demo.*.dll",
                Application.CommonAppDataPath,
                Application.LocalUserAppDataPath,
                Application.StartupPath
                );
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InfoScreen());
        }
    }
}
