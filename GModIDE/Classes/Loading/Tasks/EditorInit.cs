using System;

namespace GModIDE.Classes.LoadingTasks
{
    public class EditorInit : LoadTask
    {

        /// <summary>
        /// Load languages, run AFTER any kind of first time setup
        /// </summary>
        public void Run()
        {
            //Import languages
            EditorManager.ProcessEditors();
        }

        public string Name
        {
            get { return "Editor Initalization"; }
            set { }
        }
    }
}
