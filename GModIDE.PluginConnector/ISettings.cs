using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GModIDE.PluginConnector
{
    public interface IPluginSettings
    {
        void SetDefaults(IPluginSettingDefaults def);
        IPluginSettingDefaults GetDefaults();
        object Get(String key);
        void Set(String key, object val);
        Hashtable Data { get; }
    }

    public class IPluginSettingDefaults
    {
        #region Properties
        /// <summary>
        /// Defaults for this plugin
        /// </summary>
        public Hashtable Defaults { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add a setting default
        /// </summary>
        /// <param name="a">Key</param>
        /// <param name="b">Value</param>
        public void Add(String a, Object b)
        {
            /* type restriction */
            List<Type> c = new List<Type>();
            c.AddRange(new Type[] { typeof(bool), typeof(Boolean), typeof(Int16), typeof(Int32), typeof(int), typeof(String) });

            if (!c.Contains(b.GetType())) { return; }

            /* actually add it */
            Defaults.Add(a, b);
        }
        #endregion

        #region Constructors
        public IPluginSettingDefaults() { Defaults = new Hashtable(); }
        #endregion
    }
}
