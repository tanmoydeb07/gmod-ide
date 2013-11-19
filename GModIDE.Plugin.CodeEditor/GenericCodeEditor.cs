using Fireball.Docking;
using GModIDE.PluginConnector;
using System;

namespace GModIDE.Plugin.CodeEditor
{
    public class GenericCodeEditor : IEditor
    {
        public string Name
        {
            get { return "klua_ceditor"; }
        }

        public string DisplayName
        {
            get { return "Generic Editor"; }
        }

        public EditorType EditorType
        {
            get { return EditorType.CODER; }
        }

        public bool Visible()
        {
            return false;
        }

        public DockableWindow CreateEditor()
        {
            throw new NotImplementedException();
        }
    }
}
