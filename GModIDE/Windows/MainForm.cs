/*
   Garrys Mod IDE
   -----------------------------
   
   Copyright (C) 2012 Alan Doherty
   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
   to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
   and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
   
   - "YOU" as in, the "DOWNLOADER" of this software package, these conditions exclude the copyright holder
   - You may only sell this software when FULL profits go towards a registered charity of your choice
   - You may not redistribute this software on any website owned by Garry, Valve or Facepunch Studios
    
   The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
   IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GModIDE.Classes;
using GModIDE.PluginConnector;

namespace GModIDE.Windows
{
    public partial class MainForm : Form
    {
        #region Fields
        private bool _shown = false;
        private Workspace _workspace;
        #endregion

        #region Properties
        /// <summary>
        /// If the form is visible
        /// </summary>
        public bool IsShown { get { return _shown; } }
        #endregion

        #region Constructors
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Methods
        private void MainForm_Load(object sender, EventArgs e)
        {
            /* Load */
            PreLoad.Load();

            /* Workspace */
            _workspace = new Workspace(this, dckMain, null, null, null, null, null);

            /* Add Plugin Menu Items */
            foreach (KeyValuePair<MenuSection, List<ToolStripMenuItem>> kv in PluginManager.MenuItems)
            {
                if (kv.Value.Count > 0)
                {
                    _workspace.AddMenuItem(kv.Key, new ToolStripSeparator());

                    foreach (ToolStripMenuItem tmi in kv.Value)
                    {
                        _workspace.AddMenuItem(kv.Key, tmi);
                    }
                }
            }

            /* Language */
            LanguageManager.HandleForm(this);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _shown = true;
        }
        #endregion
    }
}
