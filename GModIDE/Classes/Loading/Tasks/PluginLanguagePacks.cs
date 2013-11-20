using System;

namespace GModIDE.Classes.LoadingTasks
{
    public class PluginLanguagePacks : LoadTask
    {

        /// <summary>
        /// Load languages, run AFTER any kind of first time setup
        /// </summary>
        public void Run()
        {
            PluginManager.CompileLanguagePacks();
        }

        public string Name
        {
            get { return "Plugin Language Packs"; }
            set { }
        }
    }
}
