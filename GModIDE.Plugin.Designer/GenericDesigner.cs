using Fireball.Docking;
using GModIDE.PluginConnector;
using System;

namespace GModIDE.Plugin.Designer
{
    public class GenericDesigner : IEditor
    {
        public string Name
        {
            get { return "klua_deditor"; }
        }

        public string DisplayName
        {
            get { return "Generic Designer"; }
        }

        public EditorType EditorType
        {
            get { return EditorType.DESIGNER; }
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
