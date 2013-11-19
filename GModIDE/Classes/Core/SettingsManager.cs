using System;
using System.IO;
using System.Collections.Generic;
using AwesomePixel;

namespace GModIDE.Classes
{
    public static class SettingsManager
    {
        #region Fields
        private static Settings _settings1;
        #endregion

        #region Properties
        /// <summary>
        /// Primary Settings
        /// </summary>
        public static Settings PrimarySettings { get { return _settings1; } }

        /// <summary>
        /// Primary Setting Defaults
        /// </summary>
        private static SettingDefaults PrimarySettingsDefaults
        {
            get
            {
                SettingDefaults sd = new SettingDefaults();
                sd.Add("window_w", 800);
                sd.Add("window_h", 600);
                sd.Add("languagepack", "");
                sd.Add("first_time", true);
                sd.Add("current_designer", "");
                sd.Add("current_coder", "");
                return sd;
            }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Load primary settings
        /// </summary>
        public static void Load()
        {
            _settings1 = null;
            if (!File.Exists("data/settings.aps"))
            {
                try
                {
                    _settings1 = new Settings();
                    _settings1.SetDefaults(PrimarySettingsDefaults);
                    _settings1.Data = PrimarySettingsDefaults.Defaults;
                    _settings1.Save("data/settings.aps");
                }
                catch (Exception ex) { ErrorHandler.CreateError(ex, "Unable to create primary settings file, reinstall program"); }
            }
            else
            {
                try
                {
                    _settings1 = new Settings();
                    _settings1.Load("data/settings.aps");

                    if (_settings1.Defaults.Defaults.Count != PrimarySettingsDefaults.Defaults.Count)
                    {
                        Utils.Log("New settings defaults detected", LogType.INFO);
                        Settings s = new Settings(PrimarySettingsDefaults);
                        s.Data = PrimarySettingsDefaults.Defaults;
                        foreach (KeyValuePair<object, object> kv in s.Data)
                        {
                            if (_settings1.Data.ContainsKey(kv.Key))
                            {
                                Utils.Log("Copied setting '" + kv.Key + "' to new settings file", LogType.INFO);
                                s[(string)kv.Key] = _settings1.Data[(string)kv.Key];
                            }
                        }
                        _settings1 = s;
                        if (File.Exists("data/settings.aps")) { File.Delete("data/settings.aps"); }
                        _settings1.Save("data/settings.aps");
                    }
                }
                catch (Exception ex) { ErrorHandler.CreateError(ex, "Unable to load primary settings file, reinstall program"); }
            }
        }

        /// <summary>
        /// Save primary settings
        /// </summary>
        public static void Save()
        {
            try
            {
                _settings1.Save("data/settings.aps");
            }
            catch (Exception ex) { ErrorHandler.CreateError(ex, "Unable to save primary settings file, reinstall program"); }
        }
        #endregion
    }
}
