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

namespace LanguagePacker
{
    public partial class NewDialog : Form
    {
        public LanguagePack pack = null;
        public Image cflag = null;

        public NewDialog()
        {
            InitializeComponent();

            cflag = LanguagePacker.Properties.Resources.flag_missing;
        }

        private void NewDialog_Load(object sender, EventArgs e)
        {
            //Icon
            Icon = SilkHandler.ToIcon(LanguagePacker.Properties.Resources.user);
        }

        private void lnkLanguageHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("The language code you are making, for example, English (British) would be en-gb", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static LanguagePack NewPack()
        {
            NewDialog nd = new NewDialog();
            DialogResult res = nd.ShowDialog();

            return nd.pack;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            pack = new LanguagePack(txtName.Text, txtAuthor.Text, txtLang.Text, cflag);
            Close();
        }

        private void updateCreate()
        {
            bool enabled = true;

            if (txtName.Text.Length == 0)
            {
                enabled = false; 
            }

            if (txtAuthor.Text.Length == 0)
            {
                enabled = false; 
            }

            if (txtLang.Text.Length != 5)
            {
                enabled = false;
            }

            if (chkFlag.Checked == true && !System.IO.File.Exists(txtFlag.Text))
            {
                enabled = false;
            }

            if (btnCreate.Enabled != enabled) { btnCreate.Enabled = enabled; }
        }

        private void btnFindFlag_Click(object sender, EventArgs e)
        {
            findFlagFile.ShowDialog();

            if (!Util.IsValidImage(findFlagFile.FileName))
            {
                MessageBox.Show("The image you have provided is not valid!", "Corrupted Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (Image bmp = Image.FromFile(findFlagFile.FileName)) {
                if (bmp.Width != 16) { MessageBox.Show("The dimensions are incorrect, the image must be 16x11!", "Bad Size", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (bmp.Height != 11) { MessageBox.Show("The dimensions are incorrect, the image must be 16x11!", "Bad Size", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }

            txtFlag.Text = findFlagFile.FileName;

            cflag = Image.FromFile(txtFlag.Text);

            updateCreate();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            updateCreate();
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            updateCreate();
        }

        private void txtLang_TextChanged(object sender, EventArgs e)
        {
            updateCreate();
        }

        private void chkFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFlag.Checked == false)
            {
                cflag = LanguagePacker.Properties.Resources.flag_missing;
                txtFlag.Visible = false;
                btnFindFlag.Visible = false;
                imgMissingFlag.Visible = true;
            }
            else
            {
                imgMissingFlag.Visible = false;
                txtFlag.Visible = true;
                btnFindFlag.Visible = true;
            }

            updateCreate();
        }

        private void enter()
        {
            btnCreate_Click(this, new EventArgs());
        }

        private void NewDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCreate.Enabled == true && e.KeyCode == Keys.Enter) { enter(); }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCreate.Enabled == true && e.KeyCode == Keys.Enter) { enter(); }
        }

        private void txtAuthor_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCreate.Enabled == true && e.KeyCode == Keys.Enter) { enter(); }
        }

        private void txtLang_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCreate.Enabled == true && e.KeyCode == Keys.Enter) { enter(); }
        }

        private void chkFlag_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCreate.Enabled == true && e.KeyCode == Keys.Enter) { enter(); }
        }

        private void txtFlag_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCreate.Enabled == true && e.KeyCode == Keys.Enter) { enter(); }
        }
    }
}
