using System;
using System.Windows.Forms;

namespace GModIDE.PluginConnector
{
    public interface IPluginServer
    {
        IUtils Utils { get; }
        IPluginSettings GetSettings(IPluginClient plugin);
        void RegisterEditor(IEditor editor);
        void RegisterMenuItem(MenuSection sec, ToolStripMenuItem item);
    }
}
