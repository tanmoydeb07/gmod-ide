using System;
using System.Collections.Generic;
using GModIDE.PluginConnector;

namespace GModIDE.Plugin.CodeEditor
{
    public class Plugin : IPluginClient
    {
        public string Name
        {
            get { return "Code Editor"; }
        }

        public string Version
        {
            get { return "1.0.0"; }
        }

        public string Author
        {
            get { return "Drake"; }
        }

        public string ID
        {
            get { return "0"; }
        }

        public IPluginServer Host { get; set; }

        public ILanguagePack[] LanguagePacks
        {
            get { return null; }
        }

        Dictionary<string, Action> IPluginClient.LoadTasks
        {
            get
            {
                return null;
            }
        }
        public IPluginSettingDefaults DefaultSettings
        {
            get
            {
                IPluginSettingDefaults id = new IPluginSettingDefaults();
                return id;
            }
        }

        public void Init()
        {
            Host.RegisterEditor(new GenericCodeEditor());
        }
    }
}
