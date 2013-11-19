using GModIDE.PluginConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GModIDE.Plugin.PluginManager
{
    public partial class PluginManager : Form
    {
        #region Constructors
        public PluginManager(IPluginServer host)
        {
            InitializeComponent();

            /* icon */
            Icon = host.Utils.ToIcon(Icons.package);
        }
        #endregion
    }
}
