/*
   Garrys Mod IDE
   -----------------------------
   
   Copyright (C) 2012 Alan Doherty
   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
   to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
   and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
   
   - "YOU" as in, the "DOWNLOADER" of this software package, these conditions exclude the copyright holder
   - You may only sell this software when FULL profits go towards a registered charity of your choice
   - You may not redistribute this software on any website owned by Garry, Valve or Facepunch Studios
    
   The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
   IN THE SOFTWARE.
*/

using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;
using GModIDE.PluginConnector;
using AwesomePixel;
using GModIDE.Classes.Plugins;

namespace GModIDE.Classes
{
    public static class PluginManager
    {
        #region Properties
        /// <summary>
        /// Get's all loaded plugins
        /// </summary>
        public static List<PluginData> Plugins { get; set; }

        /// <summary>
        /// Get's all load tasks
        /// </summary>
        public static List<LoadTask> LoadTasks { get; set; }

        /// <summary>
        /// Get's the plugin host
        /// </summary>
        public static PluginHost PluginServer { get; set; }

        /// <summary>
        /// Get's the plugin menu items
        /// </summary>
        public static Dictionary<MenuSection, List<ToolStripMenuItem>> MenuItems
        {
            get
            {
                return PluginServer.MenuItems;
            }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Search and return plugins
        /// </summary>
        /// <returns>List of plugin assemblies</returns>
        public static Assembly[] SearchPlugins()
        {
            string path = Application.StartupPath;
            string[] pluginFiles = Directory.GetFiles(path + "\\plugins", "*.dll");
            Assembly[] plugins = new Assembly[pluginFiles.Length];

            for (int i = 0; i < pluginFiles.Length; i++)
            {
                string args = pluginFiles[i].Substring(
                    pluginFiles[i].LastIndexOf("\\") + 1,
                    pluginFiles[i].IndexOf(".dll") -
                    pluginFiles[i].LastIndexOf("\\") - 1);
                try
                {
                    Assembly ass = null;
                    ass = Assembly.LoadFile(path + "\\plugins\\" + args + ".dll");

                    if (ass != null)
                    {
                        plugins[i] = ass;
                        Utils.Log("Processed plugin: " + args, LogType.INFO);
                    }
                    else { throw new Exception("Assembly returned as null, bad plugin?"); }
                }
                catch (Exception ex)
                {
                    Utils.Log("Failed to proccess plugin: " + args + " (" + ex.Message + ")", LogType.ERROR);
                }
            }

            return plugins;
        }

        /// <summary>
        /// Perform load operations for plugins
        /// </summary>
        public static void LoadPlugins()
        {
            /* Plugin List */
            Plugins = new List<PluginData>();
            LoadTasks = new List<LoadTask>();

            /* Plugin Host */
            PluginManager.PluginServer = new PluginHost();

            /* Plugins */
            Assembly[] ass = SearchPlugins();
            int i = 0;
            foreach (Assembly a in ass)
            {
                if (a == null) { continue; }
                bool b = LoadPlugin(a);
                if (b == true) { i++; }
            }

            Utils.Log("Plugin Manager loaded " + i.ToString() + " plugins", LogType.INFO);
        }

        /// <summary>
        /// Get plugin data by IPluginClient
        /// </summary>
        /// <param name="plugin">Plugin</param>
        /// <returns>Plugin Data</returns>
        public static PluginData GetPluginData(IPluginClient plugin)
        {
            foreach (PluginData pd in Plugins)
            {
                if (pd.Plugin == plugin) { return pd; }
            }
            return null;
        }

        /// <summary>
        /// Compile a readable description for a plugin
        /// </summary>
        /// <param name="plugin">Plugin</param>
        /// <returns>Description</returns>
        public static String CompilePluginDesc(IPluginClient plugin)
        {
            return plugin.Name + " by " + plugin.Author + " (v" + plugin.Version + ")";
        }

        /// <summary>
        /// Compile all plugin load tasks
        /// </summary>
        public static void CompileLoadTasks()
        {
            if (Plugins.Count == 0) { return; }

            foreach (PluginData pd in Plugins)
            {
                IPluginClient plugin = pd.Plugin;
                if (plugin.LoadTasks == null) { continue; }

                foreach (KeyValuePair<string, Action> l in plugin.LoadTasks)
                {
                    LoadTaskWrapper lt = new LoadTaskWrapper();
                    lt.LoadTask = l;
                    LoadManager.AddTask(lt);
                }
            }
        }

        /// <summary>
        /// Compile all plugin language packs
        /// </summary>
        public static void CompileLanguagePacks()
        {
            if (Plugins.Count == 0) { return; }

            foreach (PluginData pd in Plugins)
            {
                IPluginClient plugin = pd.Plugin;
                if (plugin.LanguagePacks == null) { continue; }

                foreach (ILanguagePack lp in plugin.LanguagePacks)
                {
                    LanguagePack l = new LanguagePack();
                    l.Valid = true;
                    l.Author = lp.Author;
                    l.Language = lp.Language;
                    l.Name = lp.Name;
                    l.Picture = lp.Flag;
                    l.Table = lp.Table;
                    LanguageManager.AddPack(l);
                }
            }
        }

        /// <summary>
        /// Load a plugin by assembly
        /// </summary>
        /// <param name="a">Plugin Assembly</param>
        /// <returns>Success</returns>
        public static bool LoadPlugin(Assembly a)
        {
            String ass = "Unknown";
            try
            {
                ass = a.GetName().Name;
                Type pluginType = a.GetType(ass + ".Plugin");
                if (pluginType != null)
                {
                    IPluginClient ipc = (IPluginClient)Activator.CreateInstance(pluginType);
                    ipc.Host = PluginServer;

                    Settings s = null;
                    if (!File.Exists("data\\" + ass + ".aps"))
                    {
                        try
                        {
                            SettingDefaults sd = SettingsHost.DefaultsFromInterface(ipc.DefaultSettings);
                            s = new Settings(sd);
                            s.Data = sd.Defaults;
                            s.Save("data\\" + ass + ".aps");
                        }
                        catch (Exception ex)
                        {
                            ErrorHandler.CreateError(ex, "The plugin " + ipc.Name + " was unable to create it's settings file");
                        }
                    }
                    else
                    {
                        try
                        {
                            SettingDefaults sd = SettingsHost.DefaultsFromInterface(ipc.DefaultSettings);
                            s = new Settings(sd);
                            s.Load("data\\" + ass + ".aps");

                            if (sd.Defaults.Count != ipc.DefaultSettings.Defaults.Count)
                            {
                                try
                                {
                                    if (File.Exists("data\\" + ass + ".aps.old")) { File.Delete("data\\" + ass + ".aps.old"); }

                                    File.Copy("data\\" + ass + ".aps", "data\\" + ass + ".aps.old");
                                    File.Delete("data\\" + ass + ".aps");
                                    ErrorHandler.CreateError(new Exception(""), "The plugin " + ipc.Name + " has outdated or corrupted setting defaults - the settings file has been deleted and backed up");
                                }
                                catch (Exception ex)
                                {
                                    ErrorHandler.CreateError(ex, "The plugin " + ipc.Name + " has outdated or corrupted setting defaults - the settings file could not be deleted automatically and must manually be deleted");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorHandler.CreateError(ex, "The plugin " + ipc.Name + " was unable to load it's settings file");
                        }

                    }

                    PluginData pd = null;
                    pd = new PluginData(ipc, new SettingsHost(pd, s));
                    Plugins.Add(pd);
                    Utils.Log("Loaded plugin: " + CompilePluginDesc(ipc), LogType.INFO);
                }
                else
                {
                    Utils.Log("Invalid plugin type: " + ass + ".Plugin", LogType.INFO);
                }
                return true;
            }
            catch (Exception ex)
            {
                Utils.Log("Failed to load plugin: " + ass + " (" + ex.Message + ")", LogType.ERROR);
            }
            return false;
        }

        public static void InitPlugins()
        {
            foreach (PluginData p in Plugins)
            {
                p.Plugin.Init();
            }
        }
        #endregion
    }
}
