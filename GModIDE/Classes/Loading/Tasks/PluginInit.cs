using GModIDE.Classes.Plugins;
using System;

namespace GModIDE.Classes.LoadingTasks
{
    public class PluginInit : LoadTask
    {

        /// <summary>
        /// Load languages, run AFTER any kind of first time setup
        /// </summary>
        public void Run()
        {
            PluginManager.InitPlugins();
        }

        public string Name
        {
            get { return "Plugin Initalization"; }
            set { }
        }
    }
}
