using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GModIDE.PluginConnector;

namespace GModIDE.Classes.Plugins
{
    public class PluginHost : IPluginServer
    {
        #region Fields
        private static IUtils _utilsHost;
        private static Dictionary<MenuSection, List<ToolStripMenuItem>> _menus;
        #endregion

        #region Properties
        /// <summary>
        /// Utils Host
        /// </summary>
        public IUtils Utils
        {
            get
            {
                if (_utilsHost == null) { _utilsHost = new UtilsHost(); }
                return _utilsHost;
            }
        }

        /// <summary>
        /// Menu Items
        /// </summary>
        public Dictionary<MenuSection, List<ToolStripMenuItem>> MenuItems { get { return _menus; } }
        #endregion

        #region Constructors
        public PluginHost()
        {
            /* menus */
            _menus = new Dictionary<MenuSection, List<ToolStripMenuItem>>();
            _menus.Add(MenuSection.EDIT, new List<ToolStripMenuItem>());
            _menus.Add(MenuSection.FILE, new List<ToolStripMenuItem>());
            _menus.Add(MenuSection.HELP, new List<ToolStripMenuItem>());
            _menus.Add(MenuSection.TOOLS, new List<ToolStripMenuItem>());
            _menus.Add(MenuSection.VIEW, new List<ToolStripMenuItem>());
        }
        #endregion

        #region Methods
        public IPluginSettings GetSettings(IPluginClient plugin)
        {
            return PluginManager.GetPluginData(plugin).Settings;
        }

        public void RegisterEditor(IEditor editor)
        {
            EditorManager.RegisterEditor(editor);
        }

        public void RegisterMenuItem(MenuSection sec, ToolStripMenuItem item)
        {
            _menus[sec].Add(item);
        }
        #endregion
    }
}
