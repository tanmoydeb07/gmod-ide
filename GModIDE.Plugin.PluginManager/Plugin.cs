﻿using System;
using GModIDE.PluginConnector;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GModIDE.Plugin.PluginManager
{
    public class Plugin : IPluginClient
    {
        public string Name
        {
            get { return "Plugin Manager"; }
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
            ToolStripMenuItem tsm = new ToolStripMenuItem("Plugins");
            tsm.Click+= MenuOpenManager;
            Host.RegisterMenuItem(MenuSection.TOOLS, tsm);
        }

        public void MenuOpenManager(object sender, EventArgs e)
        {
            new PluginManager(Host).ShowDialog();
        }
    }
}
