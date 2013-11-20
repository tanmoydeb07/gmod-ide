using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GModIDE.PluginConnector
{
    public interface ILanguagePack
    {
        String Name { get; set; }
        String Author { get; set; }
        String Language { get; set; }
        Image Flag { get; set; }
        Dictionary<String, String> Table { get; set; }
    }
}
