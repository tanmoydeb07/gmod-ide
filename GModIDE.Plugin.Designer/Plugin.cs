using System;
using GModIDE.PluginConnector;
using System.Collections.Generic;

namespace GModIDE.Plugin.Designer
{
    public class Plugin : IPluginClient
    {
        public string Name
        {
            get { return "Derma Designer"; }
        }

        public string Version
        {
            get { return "1.0.0"; }
        }

        public string Author
        {
            get { return "KillerLUA"; }
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
            Host.RegisterEditor(new GenericDesigner());
        }
    }
}
