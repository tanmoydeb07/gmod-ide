namespace GModIDE.Windows
{
    partial class FirstTimeWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstTimeWizard));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.wizardPageCollection1 = new GModIDE.Windows.WizardPageCollection();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.s1_Text = new System.Windows.Forms.Label();
            this.s1_Title = new System.Windows.Forms.Label();
            this.s1_SideImage = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.s2_flag = new System.Windows.Forms.PictureBox();
            this.s2_lblFlag = new System.Windows.Forms.Label();
            this.s2_txtAuthor = new System.Windows.Forms.Label();
            this.s2_txtName = new System.Windows.Forms.Label();
            this.s2_lblAuthor = new System.Windows.Forms.Label();
            this.s2_lblName = new System.Windows.Forms.Label();
            this.s2_lnkImport = new System.Windows.Forms.LinkLabel();
            this.s2_lSelect = new System.Windows.Forms.TreeView();
            this.s2_lSelectImages = new System.Windows.Forms.ImageList(this.components);
            this.s2_Title = new System.Windows.Forms.Label();
            this.s2_SideImage = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.s3_Title = new System.Windows.Forms.Label();
            this.s3_SideImage = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.s4_Text = new System.Windows.Forms.Label();
            this.s4_Title = new System.Windows.Forms.Label();
            this.s4_SideImage = new System.Windows.Forms.PictureBox();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.wizardPageCollection1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s1_SideImage)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s2_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s2_SideImage)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s3_SideImage)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s4_SideImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.wizardPageCollection1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn2);
            this.splitContainer1.Panel2.Controls.Add(this.btn1);
            this.splitContainer1.Panel2.Controls.Add(this.btn3);
            this.splitContainer1.Size = new System.Drawing.Size(534, 414);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // wizardPageCollection1
            // 
            this.wizardPageCollection1.bckButton = null;
            this.wizardPageCollection1.cclButton = null;
            this.wizardPageCollection1.Controls.Add(this.tabPage1);
            this.wizardPageCollection1.Controls.Add(this.tabPage2);
            this.wizardPageCollection1.Controls.Add(this.tabPage3);
            this.wizardPageCollection1.Controls.Add(this.tabPage4);
            this.wizardPageCollection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageCollection1.Location = new System.Drawing.Point(0, 0);
            this.wizardPageCollection1.Name = "wizardPageCollection1";
            this.wizardPageCollection1.nxtButton = this.btn3;
            this.wizardPageCollection1.SelectedIndex = 0;
            this.wizardPageCollection1.Size = new System.Drawing.Size(532, 378);
            this.wizardPageCollection1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.s1_Text);
            this.tabPage1.Controls.Add(this.s1_Title);
            this.tabPage1.Controls.Add(this.s1_SideImage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(524, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // s1_Text
            // 
            this.s1_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s1_Text.Location = new System.Drawing.Point(168, 60);
            this.s1_Text.Name = "s1_Text";
            this.s1_Text.Size = new System.Drawing.Size(295, 222);
            this.s1_Text.TabIndex = 2;
            this.s1_Text.Text = resources.GetString("s1_Text.Text");
            // 
            // s1_Title
            // 
            this.s1_Title.AutoSize = true;
            this.s1_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s1_Title.Location = new System.Drawing.Point(168, 19);
            this.s1_Title.Name = "s1_Title";
            this.s1_Title.Size = new System.Drawing.Size(190, 15);
            this.s1_Title.TabIndex = 1;
            this.s1_Title.Text = "Welcome to Garry\'s Mod IDE";
            // 
            // s1_SideImage
            // 
            this.s1_SideImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.s1_SideImage.Image = global::GModIDE.Properties.Resources.wizard1;
            this.s1_SideImage.Location = new System.Drawing.Point(0, 0);
            this.s1_SideImage.Name = "s1_SideImage";
            this.s1_SideImage.Size = new System.Drawing.Size(150, 352);
            this.s1_SideImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.s1_SideImage.TabIndex = 0;
            this.s1_SideImage.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.s2_flag);
            this.tabPage2.Controls.Add(this.s2_lblFlag);
            this.tabPage2.Controls.Add(this.s2_txtAuthor);
            this.tabPage2.Controls.Add(this.s2_txtName);
            this.tabPage2.Controls.Add(this.s2_lblAuthor);
            this.tabPage2.Controls.Add(this.s2_lblName);
            this.tabPage2.Controls.Add(this.s2_lnkImport);
            this.tabPage2.Controls.Add(this.s2_lSelect);
            this.tabPage2.Controls.Add(this.s2_Title);
            this.tabPage2.Controls.Add(this.s2_SideImage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(524, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // s2_flag
            // 
            this.s2_flag.Location = new System.Drawing.Point(404, 162);
            this.s2_flag.Name = "s2_flag";
            this.s2_flag.Size = new System.Drawing.Size(16, 11);
            this.s2_flag.TabIndex = 10;
            this.s2_flag.TabStop = false;
            // 
            // s2_lblFlag
            // 
            this.s2_lblFlag.AutoSize = true;
            this.s2_lblFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s2_lblFlag.Location = new System.Drawing.Point(342, 158);
            this.s2_lblFlag.Name = "s2_lblFlag";
            this.s2_lblFlag.Size = new System.Drawing.Size(43, 15);
            this.s2_lblFlag.TabIndex = 9;
            this.s2_lblFlag.Text = "Flag: ";
            // 
            // s2_txtAuthor
            // 
            this.s2_txtAuthor.AutoSize = true;
            this.s2_txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s2_txtAuthor.Location = new System.Drawing.Point(401, 115);
            this.s2_txtAuthor.Name = "s2_txtAuthor";
            this.s2_txtAuthor.Size = new System.Drawing.Size(0, 15);
            this.s2_txtAuthor.TabIndex = 8;
            // 
            // s2_txtName
            // 
            this.s2_txtName.AutoSize = true;
            this.s2_txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s2_txtName.Location = new System.Drawing.Point(401, 72);
            this.s2_txtName.Name = "s2_txtName";
            this.s2_txtName.Size = new System.Drawing.Size(0, 15);
            this.s2_txtName.TabIndex = 7;
            // 
            // s2_lblAuthor
            // 
            this.s2_lblAuthor.AutoSize = true;
            this.s2_lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s2_lblAuthor.Location = new System.Drawing.Point(342, 115);
            this.s2_lblAuthor.Name = "s2_lblAuthor";
            this.s2_lblAuthor.Size = new System.Drawing.Size(56, 15);
            this.s2_lblAuthor.TabIndex = 6;
            this.s2_lblAuthor.Text = "Author: ";
            // 
            // s2_lblName
            // 
            this.s2_lblName.AutoSize = true;
            this.s2_lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s2_lblName.Location = new System.Drawing.Point(342, 72);
            this.s2_lblName.Name = "s2_lblName";
            this.s2_lblName.Size = new System.Drawing.Size(53, 15);
            this.s2_lblName.TabIndex = 5;
            this.s2_lblName.Text = "Name: ";
            // 
            // s2_lnkImport
            // 
            this.s2_lnkImport.AutoSize = true;
            this.s2_lnkImport.Location = new System.Drawing.Point(168, 303);
            this.s2_lnkImport.Name = "s2_lnkImport";
            this.s2_lnkImport.Size = new System.Drawing.Size(158, 13);
            this.s2_lnkImport.TabIndex = 4;
            this.s2_lnkImport.TabStop = true;
            this.s2_lnkImport.Text = "Import a language pack from file\r\n";
            this.s2_lnkImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.s2_lnkImport_LinkClicked);
            // 
            // s2_lSelect
            // 
            this.s2_lSelect.ImageIndex = 0;
            this.s2_lSelect.ImageList = this.s2_lSelectImages;
            this.s2_lSelect.Location = new System.Drawing.Point(171, 72);
            this.s2_lSelect.Name = "s2_lSelect";
            this.s2_lSelect.SelectedImageIndex = 0;
            this.s2_lSelect.Size = new System.Drawing.Size(154, 214);
            this.s2_lSelect.TabIndex = 3;
            this.s2_lSelect.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.s2_lSelect_NodeMouseClick);
            // 
            // s2_lSelectImages
            // 
            this.s2_lSelectImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.s2_lSelectImages.ImageSize = new System.Drawing.Size(16, 11);
            this.s2_lSelectImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // s2_Title
            // 
            this.s2_Title.AutoSize = true;
            this.s2_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s2_Title.Location = new System.Drawing.Point(168, 19);
            this.s2_Title.Name = "s2_Title";
            this.s2_Title.Size = new System.Drawing.Size(135, 15);
            this.s2_Title.TabIndex = 2;
            this.s2_Title.Text = "Language Selection";
            // 
            // s2_SideImage
            // 
            this.s2_SideImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.s2_SideImage.Image = global::GModIDE.Properties.Resources.wizard1;
            this.s2_SideImage.Location = new System.Drawing.Point(0, 0);
            this.s2_SideImage.Name = "s2_SideImage";
            this.s2_SideImage.Size = new System.Drawing.Size(150, 352);
            this.s2_SideImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.s2_SideImage.TabIndex = 0;
            this.s2_SideImage.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.s3_Title);
            this.tabPage3.Controls.Add(this.s3_SideImage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(524, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // s3_Title
            // 
            this.s3_Title.AutoSize = true;
            this.s3_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s3_Title.Location = new System.Drawing.Point(168, 19);
            this.s3_Title.Name = "s3_Title";
            this.s3_Title.Size = new System.Drawing.Size(93, 15);
            this.s3_Title.TabIndex = 2;
            this.s3_Title.Text = "Configuration";
            // 
            // s3_SideImage
            // 
            this.s3_SideImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.s3_SideImage.Image = global::GModIDE.Properties.Resources.wizard1;
            this.s3_SideImage.Location = new System.Drawing.Point(0, 0);
            this.s3_SideImage.Name = "s3_SideImage";
            this.s3_SideImage.Size = new System.Drawing.Size(150, 352);
            this.s3_SideImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.s3_SideImage.TabIndex = 1;
            this.s3_SideImage.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.s4_Text);
            this.tabPage4.Controls.Add(this.s4_Title);
            this.tabPage4.Controls.Add(this.s4_SideImage);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(524, 352);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // s4_Text
            // 
            this.s4_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s4_Text.Location = new System.Drawing.Point(168, 60);
            this.s4_Text.Name = "s4_Text";
            this.s4_Text.Size = new System.Drawing.Size(295, 222);
            this.s4_Text.TabIndex = 3;
            this.s4_Text.Text = "The interactive developer environment is now ready for use!";
            // 
            // s4_Title
            // 
            this.s4_Title.AutoSize = true;
            this.s4_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s4_Title.Location = new System.Drawing.Point(168, 19);
            this.s4_Title.Name = "s4_Title";
            this.s4_Title.Size = new System.Drawing.Size(221, 15);
            this.s4_Title.TabIndex = 2;
            this.s4_Title.Text = "Thanks for using Garry\'s Mod IDE";
            // 
            // s4_SideImage
            // 
            this.s4_SideImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.s4_SideImage.Image = global::GModIDE.Properties.Resources.wizard1;
            this.s4_SideImage.Location = new System.Drawing.Point(0, 0);
            this.s4_SideImage.Name = "s4_SideImage";
            this.s4_SideImage.Size = new System.Drawing.Size(150, 352);
            this.s4_SideImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.s4_SideImage.TabIndex = 1;
            this.s4_SideImage.TabStop = false;
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(431, 3);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(90, 23);
            this.btn3.TabIndex = 0;
            this.btn3.Text = "Next >";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Enabled = false;
            this.btn2.Location = new System.Drawing.Point(335, 3);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(90, 23);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "< Back";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(239, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(90, 23);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "Cancel";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // FirstTimeWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 414);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstTimeWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Time Setup";
            this.Load += new System.EventHandler(this.FirstTimeWizard_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.wizardPageCollection1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s1_SideImage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s2_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s2_SideImage)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s3_SideImage)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s4_SideImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private WizardPageCollection wizardPageCollection1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox s1_SideImage;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.PictureBox s2_SideImage;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label s1_Title;
        private System.Windows.Forms.Label s1_Text;
        private System.Windows.Forms.Label s2_Title;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label s3_Title;
        private System.Windows.Forms.PictureBox s3_SideImage;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label s4_Text;
        private System.Windows.Forms.Label s4_Title;
        private System.Windows.Forms.PictureBox s4_SideImage;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Label s2_lblAuthor;
        private System.Windows.Forms.Label s2_lblName;
        private System.Windows.Forms.LinkLabel s2_lnkImport;
        private System.Windows.Forms.TreeView s2_lSelect;
        private System.Windows.Forms.ImageList s2_lSelectImages;
        private System.Windows.Forms.Label s2_txtAuthor;
        private System.Windows.Forms.Label s2_txtName;
        private System.Windows.Forms.PictureBox s2_flag;
        private System.Windows.Forms.Label s2_lblFlag;
    }
}