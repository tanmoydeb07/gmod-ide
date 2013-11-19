using System;
using GModIDE.PluginConnector;

namespace GModIDE.Classes
{
    public class PluginData
    {
        #region Properties
        /// <summary>
        /// The plugin in question
        /// </summary>
        public IPluginClient Plugin { get; set; }

        /// <summary>
        /// The settings wrapper for this plugin
        /// </summary>
        public IPluginSettings Settings { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new plugin data class
        /// </summary>
        /// <param name="a">Plugin</param>
        /// <param name="b">Settings Wrapper</param>
        public PluginData(IPluginClient a, IPluginSettings b)
        {
            Plugin = a;
            Settings = b;
        }
        #endregion
    }
}
