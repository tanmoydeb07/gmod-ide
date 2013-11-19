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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GModIDE.Classes;

namespace GModIDE.Windows
{
    class WizardPageCollection : TabControl
    {
        public Button nxtButton { get; set; }
        public Button bckButton { get; set; }
        public Button cclButton { get; set; }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }

        public void ShowPage(int id)
        {
            this.SelectedIndex = id - 1;
            UpdateButtons();
        }

        public void UpdateButtons()
        {
            if (this.SelectedIndex == 0) { bckButton.Enabled = false; }
            else { bckButton.Enabled = true; }

            if (this.SelectedIndex == TabPages.Count - 1)
            {
                nxtButton.Tag = WizardButton.Finish; nxtButton.Text = LanguageManager.Get("dialog_finish");
                bckButton.Enabled = false; cclButton.Enabled = false;
            }

            if ((bool)TabPages[SelectedIndex].Tag == true)
            {
                nxtButton.Enabled = true;
            }
            else
            {
                nxtButton.Enabled = false;
            }
        }
    }
}
