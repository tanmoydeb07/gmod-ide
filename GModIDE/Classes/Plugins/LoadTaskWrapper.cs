using System;
using System.Text;
using System.Collections.Generic;
using GModIDE.PluginConnector;

namespace GModIDE.Classes
{
    public class LoadTaskWrapper : LoadTask
    {
        public String Name { get { return LoadTask.Key; } set { } }
        public void Run()
        {
            LoadTask.Value.Invoke();
        }

        public KeyValuePair<String,Action> LoadTask { get; set; }
    }
}
