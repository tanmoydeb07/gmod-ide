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
using System.IO;

namespace GModIDE.Windows
{
    public partial class FirstTimeWizard : Form
    {
        private String o_Text;
        private int o_Pages = 4;
        private String lPack = "";

        public FirstTimeWizard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show a page
        /// </summary>
        /// <param name="id"></param>
        private void ShowPage(int id)
        {
            wizardPageCollection1.ShowPage(id);
            Text = o_Text + " - " + String.Format(LanguageManager.Get("dialogt_step"), new string[] { id.ToString(), o_Pages.ToString() });

            wizardPageCollection1.UpdateButtons();
        }

        private int GetPage()
        {
            return wizardPageCollection1.SelectedIndex + 1;
        }

        private void req_LanguagePack()
        {
            DialogResult r = MessageBox.Show("It seems as though there are no language packs to import automatically, you will have to import a language pack. Continue?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (r == System.Windows.Forms.DialogResult.No)
            {
                Program.ForceQuit();
            }
        }


        private void updateSelectInfo()
        {
            updateSelectInfo(LanguageManager.Packs[s2_lSelect.SelectedImageKey]);
        }

        private void updateSelectInfo(LanguagePack lp)
        {
            s2_txtAuthor.Text = lp.Author;
            s2_txtName.Text = lp.Name;
            s2_flag.Image = lp.Picture;
        }

        public void initlanguage()
        {
            btn1.Text = LanguageManager.Get("dialog_cancel");
            btn2.Text = "< " + LanguageManager.Get("dialog_back");
            if (wizardPageCollection1.SelectedIndex == wizardPageCollection1.TabPages.Count - 1) { btn3.Text = LanguageManager.Get("dialog_finish"); }
            else { btn3.Text = LanguageManager.Get("dialog_next") + " >"; }
            o_Text = LanguageManager.Get("dialogt_firsttime");
            Text = o_Text + " - " + String.Format(LanguageManager.Get("dialogt_step"), new string[] { "2", o_Pages.ToString() });

            s2_Title.Text = LanguageManager.Get("text_langselect");
            s2_lblAuthor.Text = LanguageManager.Get("field_author");
            s2_lblName.Text = LanguageManager.Get("field_name");
            s2_lblFlag.Text = LanguageManager.Get("field_flag");
            s2_lnkImport.Text = LanguageManager.Get("text_importlp");

            s3_Title.Text = LanguageManager.Get("text_configuration");
            s4_Title.Text = LanguageManager.Get("text_thanks");
            s4_Text.Text = LanguageManager.Get("text_readytouse");
        }

        private void FirstTimeWizard_Load(object sender, EventArgs e)
        {
            //Use default pack for now
            LanguagePack lp = new LanguagePack("First Time Pack", "KillerLUA", "en-gb", null);
            lp.Put("dialog_next", "Next");
            lp.Put("dialog_back", "Back");
            lp.Put("dialog_finish", "Finish");
            lp.Put("dialog_cancel", "Cancel");
            lp.Put("field_author", "Author");
            lp.Put("field_name", "Name");
            lp.Put("field_flag", "Flag");
            lp.Put("dialogt_firsttime", "First Time Setup");
            lp.Put("dialogt_step", "Step {0} of {1}");
            lp.Put("text_langselect", "Language Selection");
            lp.Put("text_importlp", "Import Language Pack");
            LanguageManager.Current = lp;

            initlanguage();

            int imported = LanguageManager.Packs.Count;

            if (imported == 0)
            {
                req_LanguagePack();
            }

            //Init buttons
            btn1.Tag = WizardButton.Cancel;
            btn2.Tag = WizardButton.Back;
            btn3.Tag = WizardButton.Next;

            wizardPageCollection1.cclButton = btn1;
            wizardPageCollection1.nxtButton = btn3;
            wizardPageCollection1.bckButton = btn2;

            //Init pages
            foreach (TabPage p in wizardPageCollection1.TabPages)
            {
                p.Tag = false;
            }

            wizardPageCollection1.TabPages[0].Tag = true;
            ShowPage(1);

            if (imported > 0)
            {
                foreach (KeyValuePair<String, LanguagePack> p in LanguageManager.Packs)
                {
                    s2_lSelectImages.Images.Add(p.Key, p.Value.Picture);
                    s2_lSelect.Nodes.Add(p.Key, p.Value.Name, p.Key);
                }

                s2_lSelect.SelectedImageIndex = 0;
                updateSelectInfo(LanguageManager.Packs.First().Value);

                /* we can forward */
                wizardPageCollection1.TabPages[1].Tag = true;
                wizardPageCollection1.UpdateButtons();
                lPack = LanguageManager.Packs.First().Key;
            }

            //Icon
            Icon = SilkHandler.ToIcon(Resources.wrench);
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

        public void PerformButtonFunc(WizardButton typ)
        {
            switch (typ)
            {
                case WizardButton.Back:
                    ShowPage(GetPage() - 1);
                    break;
                case WizardButton.Cancel:
                    DialogResult re = MessageBox.Show("Are you sure you want to exit the wizard?\n\nYou must run this wizard to fully configure\nthe program!", "Abort?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (re == System.Windows.Forms.DialogResult.Yes)
                    {
                        Program.ForceQuit();
                    }
                    break;
                case WizardButton.Finish:
                    SettingsManager.PrimarySettings["first_time"] = false;
                    SettingsManager.PrimarySettings["languagepack"] = lPack;
                    SettingsManager.Save();
                    Application.Restart();
                    return;
                case WizardButton.Next:
                    if (GetPage() == 2)
                    {
                        LanguageManager.Current = LanguageManager.Packs[lPack];
                        initlanguage();
                        wizardPageCollection1.TabPages[2].Tag = true;
                    }

                    ShowPage(GetPage() + 1);

                    if (GetPage() == wizardPageCollection1.TabPages.Count)
                    {
                        wizardPageCollection1.TabPages[wizardPageCollection1.TabPages.Count - 1].Tag = true;
                    }
                    break;
            }

            wizardPageCollection1.UpdateButtons();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            PerformButtonFunc((WizardButton)btn1.Tag);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            PerformButtonFunc((WizardButton)btn2.Tag);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            PerformButtonFunc((WizardButton)btn3.Tag);
        }

        private void s2_lnkImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Import Language Pack";
            ofd.Filter = "Language Pack (*.lang)|*.lang";
            ofd.CheckFileExists = true;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    String shortName = Path.GetFileName(ofd.FileName);
                    File.Copy(ofd.FileName, "loc\\" + shortName);
                    Application.Restart();
                }
                catch (Exception) { MessageBox.Show("Unable to import selected language, do you have correct read rights?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void s2_lSelect_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LanguagePack lp = LanguageManager.Packs[e.Node.ImageKey];
            updateSelectInfo(lp);
            initlanguage();

            /* we can forward */
            wizardPageCollection1.TabPages[1].Tag = true;
            wizardPageCollection1.UpdateButtons();
            lPack = e.Node.ImageKey;
        }
    }
}
