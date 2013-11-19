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
using GModIDE.Properties;
using System.Net;

namespace GModIDE.Windows.Dialogs
{
    public partial class StubDialog : Form
    {
        private String p_FeatureName = null;
        private String p_Desc = "";

        public StubDialog()
        {
            InitializeComponent();
        }

        private void ErrorDialog_Load(object sender, EventArgs e)
        {
            /* Icon */
            try
            {
                Icon = SilkHandler.ToIcon(Resources.bug_error, true);
            }
            catch (Exception) { }

            /* Stub Report */
            stubInfo.Text = "Feature: " + p_FeatureName + Environment.NewLine + Environment.NewLine;
            stubInfo.Text = "Explanation: " + p_Desc;

            /* Language */
            LanguageManager.HandleForm(this);
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public void ShowStub(String name, String explan)
        {
            p_FeatureName = name;
            p_Desc = explan;

            ShowDialog();
        }
    }
}
