using Fireball.Docking;
using System;

namespace GModIDE.PluginConnector
{
    public interface IEditor
    {
        String Name { get; }
        String DisplayName { get; }
        EditorType EditorType { get; }
        bool Visible();
        DockableWindow CreateEditor();
    }

    public enum EditorType
    {
        DESIGNER=0,
        CODER=1,
        OTHER=2
    }
}
