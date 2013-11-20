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
    public partial class Main : Form
    {
        public bool packOpen = false;
        public String packPath = "";
        public bool packChanges = false;

        LanguagePack cPack = null;

        public Main()
        {
            InitializeComponent();
        }

        private void UpdateUI()
        {
            if (!packOpen)
            {
                btnAddField.Visible = false;
                btnEditField.Visible = false;
                btnRemoveField.Visible = false;
                sepExtra.Visible = false;

                stringTable.Items.Clear();

                Icon = SilkHandler.ToIcon(LanguagePacker.Properties.Resources.user);
            }
            else
            {
                btnAddField.Visible = true;
                btnEditField.Visible = true;
                btnRemoveField.Visible = true;
                sepExtra.Visible = true;

                Icon = SilkHandler.ToIcon((Bitmap)cPack.Picture); 

                /* update list */
                stringTable.Items.Clear();
                foreach (KeyValuePair<string, string> kv in cPack.Table)
                {
                    stringTable.Items.Add(new ListViewItem(new string[] { kv.Key.ToLower(), kv.Value }));
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Icon
            Icon = SilkHandler.ToIcon(LanguagePacker.Properties.Resources.user);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLanguage();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewLanguage();
        }

        /// <summary>
        /// Create a new language and check for saving, etc
        /// </summary>
        public void NewLanguage()
        {
            if (packOpen && packChanges)
            {
                DialogResult res = MessageBox.Show("Would you like to save your current pack first?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveLanguage();
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                    case System.Windows.Forms.DialogResult.No:
                        return;
                }
            }

            LanguagePack lp = NewDialog.NewPack();

            if (lp == null)
            {
                return;
            }

            cPack = lp;
            packOpen = true;
            packChanges = false;
            packPath = "";

            UpdateUI();
        }

        private void SaveLanguage()
        {
            if (packPath == "")
            {
                SaveFileDialog ofd = new SaveFileDialog();
                ofd.Title = "Save Language Pack";
                ofd.Filter = "Language Pack (*.lang)|*.lang";
                ofd.RestoreDirectory = true;
                ofd.OverwritePrompt = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        cPack.Save(ofd.FileName);
                    }
                    catch (Exception) { MessageBox.Show("Unable to save language pack, check path still exists and you have write permissions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                packPath = ofd.FileName;
            }
            else
            {
                try
                {
                    cPack.Save(packPath);
                }
                catch (Exception) { MessageBox.Show("Unable to save language pack, check path still exists and you have write permissions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            packChanges = false;
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            KeyValuePair<string,string> res = AddEditDialog.AddPair();

            if (res.Key == "" && res.Value == "")
            {
                return;
            }

            if (cPack.Table.ContainsKey(res.Key.ToLower()))
            {
                MessageBox.Show("A translation already exists with that name!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cPack.Table.Add(res.Key.ToLower(), res.Value);

            stringTable.Items.Add(new ListViewItem(new string[] { res.Key.ToLower(), res.Value }));
            packChanges = true;
        }

        private void RemoveFields()
        {
            if (stringTable.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select one or more fields to delete!", "Nope", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stringTable.SelectedItems.Count == 1)
            {
                ListViewItem lvi = stringTable.SelectedItems[0];
                cPack.Table.Remove(lvi.SubItems[0].Text);
                stringTable.Items.Remove(stringTable.SelectedItems[0]);
                packChanges = true;
                return;
            }

            if (stringTable.SelectedItems.Count > 1)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete " + stringTable.SelectedItems.Count.ToString() + " fields?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in stringTable.SelectedItems)
                    {
                        cPack.Table.Remove(lvi.SubItems[0].Text);
                        stringTable.Items.Remove(lvi);
                    }
                }
            }
            packChanges = true;
        }

        private void btnRemoveField_Click(object sender, EventArgs e)
        {
            RemoveFields();
        }

        private void btnEditField_Click(object sender, EventArgs e)
        {
            if (stringTable.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a field to edit", "Nope", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem lvi = stringTable.SelectedItems[0];

            KeyValuePair<string,string> res = AddEditDialog.EditExistingPair(new KeyValuePair<string, string>(lvi.SubItems[0].Text, lvi.SubItems[1].Text));

            if (cPack.Table.ContainsKey(res.Key) && lvi.SubItems[0].Text != res.Key) 
            {
                MessageBox.Show("You cannot rename to an existing field", "Nope", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvi.SubItems[0].Text != res.Key)
            {
                stringTable.Items[lvi.Index].SubItems[0].Text = res.Key;
                stringTable.Items[lvi.Index].SubItems[1].Text = res.Value;
                cPack.Table.Remove(lvi.SubItems[0].Text);
                cPack.Table.Add(res.Key, res.Value);
            }
            else
            {
                stringTable.Items[lvi.Index].SubItems[0].Text = res.Key;
                stringTable.Items[lvi.Index].SubItems[1].Text = res.Value;
                cPack.Table[res.Key] = res.Value;
            }
            packChanges = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (packOpen && packChanges)
            {
                DialogResult res = MessageBox.Show("Would you like to save your current pack first?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveLanguage();
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                    case System.Windows.Forms.DialogResult.No:
                        return;
                }
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Language Pack";
            ofd.Filter = "Language Pack (*.lang)|*.lang";
            ofd.CheckFileExists = true;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    cPack = LanguagePack.LoadFromFile(ofd.FileName);
                }
                catch (Exception) { MessageBox.Show("Unable to load language pack, check the file is not corrupted and you have read rights", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            packPath = ofd.FileName;
            packOpen = true;
            packChanges = false;
            UpdateUI();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (packChanges == true)
            {
                DialogResult res = MessageBox.Show("Would you like to save your current pack first?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveLanguage();
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                    case System.Windows.Forms.DialogResult.No:
                        return;
                }
            }
        }
    }
}
