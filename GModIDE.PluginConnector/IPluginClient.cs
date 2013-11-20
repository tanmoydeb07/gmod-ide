using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GModIDE.PluginConnector
{
    public interface IPluginClient
    {
        String Name { get; }
        String Version { get;}
        String Author { get; }
        String ID { get; }
        IPluginServer Host { get; set; }
        ILanguagePack[] LanguagePacks { get; }
        Dictionary<String,Action> LoadTasks { get; }
        IPluginSettingDefaults DefaultSettings { get; }
        void Init();
    }
}
