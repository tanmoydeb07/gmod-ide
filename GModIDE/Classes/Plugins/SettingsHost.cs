using System;
using GModIDE.PluginConnector;
using AwesomePixel;

namespace GModIDE.Classes
{
    public class SettingsHost : IPluginSettings
    {
        #region Fields
        private Settings _settings = null;
        private PluginData _plugin = null;
        #endregion

        #region Methods
        public void SetDefaults(IPluginSettingDefaults def)
        {
            _settings.Defaults.Defaults = def.Defaults;
        }

        public IPluginSettingDefaults GetDefaults()
        {
            return new IPluginSettingDefaults() { Defaults = _settings.Defaults.Defaults };
        }

        public object Get(string key)
        {
            try
            {
                if (!_settings.Data.ContainsKey(key)) { throw new NullReferenceException("Missing key in hashtable"); }
                return _settings.Data[key];
            }
            catch (Exception ex)
            {
                ErrorHandler.CreateError(ex, "The plugin " + _plugin.Plugin.Name + " tried to access a missing setting '" + key + "', go ask " + _plugin.Plugin.Author + " to fix it");
            }
            return null;
        }

        public void Set(string key, object val)
        {
            try
            {
                _settings.Data[key] = val;
            }
            catch (Exception ex)
            {
                ErrorHandler.CreateError(ex, "The plugin " + _plugin.Plugin.Name + " tried to access a missing setting '" + key + "', go ask " + _plugin.Plugin.Author + " to fix it");
            }
        }
        #endregion

        #region Properties
        public System.Collections.Hashtable Data
        {
            get { return _settings.Data; }
        }
        #endregion

        #region Constructors
        public SettingsHost(PluginData p, Settings s)
        {
            _settings = s;
            _plugin = p;
        }
        #endregion

        #region Static Methods
        public static SettingDefaults DefaultsFromInterface(IPluginSettingDefaults def)
        {
            SettingDefaults sd = new SettingDefaults();
            sd.Defaults = def.Defaults;
            return sd;
        }

        public static Settings SettingsFromInterface(IPluginSettings set)
        {
            Settings s = new Settings(DefaultsFromInterface(set.GetDefaults()));
            s.Data = set.Data;
            s.Loaded = true;
            return s;
        }
        #endregion
    }
}
