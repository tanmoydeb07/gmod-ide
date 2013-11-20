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
    public partial class ErrorDialog : Form
    {
        private Exception p_Ex = null;
        private String p_Desc = "";
        private int p_ID = 0;

        public ErrorDialog()
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

            /* Language */
            LanguageManager.HandleForm(this);

            /* Error Report */
            errInfo.Text = "Error ID: " + p_ID.ToString() + Environment.NewLine;
            errInfo.Text += "Error: " + p_Desc + Environment.NewLine + Environment.NewLine;
            System.OperatingSystem os = Environment.OSVersion;
            errInfo.Text += "OS: " + os.VersionString + Environment.NewLine;
            errInfo.Text += "x64 System: " + Environment.Is64BitOperatingSystem.ToString() + Environment.NewLine;
            errInfo.Text += "x64 Procces: " + Environment.Is64BitProcess.ToString() + Environment.NewLine + Environment.NewLine;
            errInfo.Text += "Exception: " + Environment.NewLine;
            errInfo.Text += p_Ex.Message + Environment.NewLine;
            if (p_Ex.InnerException != null)
            {
                errInfo.Text += "Inner Exception: " + Environment.NewLine;
                errInfo.Text += p_Ex.InnerException.Message + Environment.NewLine + Environment.NewLine;
            }
            errInfo.Text += "Stack Trace: " + Environment.NewLine;
            errInfo.Text += p_Ex.StackTrace;
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

        public void ShowError(Exception ex, String desc, int id=0)
        {
            p_Ex = ex;
            p_Desc = desc;
            p_ID = id;

            ShowDialog();
        }

        private void btnPrivacyFreak_Click(object sender, EventArgs e)
        {
            Program.ForceQuit();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try{
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.QueryString.Add("data", errInfo.Text);
                    client.UploadString("http://www.gmservers.co.uk/system/gide/bugreport.php", "POST");
                }

                MessageBox.Show("Thanks, You've forwarded science by 3 years!", "Bug Report Sent!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(WebException ex) {
                HttpStatusCode stat = ((HttpWebResponse)ex.Response).StatusCode;
                if (stat == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Error: Server not available to proccess bug report!\n(thanks anyway though)", "Darn...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (stat == HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Error: Server denied bug report!\n(thanks anyway though)", "Darn...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: Unable to send bug report!\n(thanks anyway though)", "Darn...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Program.ForceQuit();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            Program.ForceQuit();
        }
    }
}
