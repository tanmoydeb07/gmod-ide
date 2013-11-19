namespace LanguagePacker
{
    partial class NewDialog
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtLang = new System.Windows.Forms.MaskedTextBox();
            this.lnkLanguageHelp = new System.Windows.Forms.LinkLabel();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblFlag = new System.Windows.Forms.Label();
            this.txtFlag = new System.Windows.Forms.TextBox();
            this.btnFindFlag = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.findFlagFile = new System.Windows.Forms.OpenFileDialog();
            this.chkFlag = new System.Windows.Forms.CheckBox();
            this.imgMissingFlag = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgMissingFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(59, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 24);
            this.txtName.MaxLength = 32;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(130, 50);
            this.txtAuthor.MaxLength = 48;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(160, 20);
            this.txtAuthor.TabIndex = 3;
            this.txtAuthor.TextChanged += new System.EventHandler(this.txtAuthor_TextChanged);
            this.txtAuthor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAuthor_KeyUp);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(59, 53);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(44, 13);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author: ";
            // 
            // txtLang
            // 
            this.txtLang.Location = new System.Drawing.Point(130, 76);
            this.txtLang.Mask = "aa-aa";
            this.txtLang.Name = "txtLang";
            this.txtLang.Size = new System.Drawing.Size(33, 20);
            this.txtLang.TabIndex = 4;
            this.txtLang.TextChanged += new System.EventHandler(this.txtLang_TextChanged);
            this.txtLang.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLang_KeyUp);
            // 
            // lnkLanguageHelp
            // 
            this.lnkLanguageHelp.AutoSize = true;
            this.lnkLanguageHelp.Location = new System.Drawing.Point(169, 79);
            this.lnkLanguageHelp.Name = "lnkLanguageHelp";
            this.lnkLanguageHelp.Size = new System.Drawing.Size(13, 13);
            this.lnkLanguageHelp.TabIndex = 5;
            this.lnkLanguageHelp.TabStop = true;
            this.lnkLanguageHelp.Text = "?";
            this.lnkLanguageHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLanguageHelp_LinkClicked);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(59, 79);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(61, 13);
            this.lblLanguage.TabIndex = 6;
            this.lblLanguage.Text = "Language: ";
            // 
            // lblFlag
            // 
            this.lblFlag.AutoSize = true;
            this.lblFlag.Location = new System.Drawing.Point(59, 105);
            this.lblFlag.Name = "lblFlag";
            this.lblFlag.Size = new System.Drawing.Size(33, 13);
            this.lblFlag.TabIndex = 7;
            this.lblFlag.Text = "Flag: ";
            // 
            // txtFlag
            // 
            this.txtFlag.Location = new System.Drawing.Point(130, 102);
            this.txtFlag.Name = "txtFlag";
            this.txtFlag.ReadOnly = true;
            this.txtFlag.Size = new System.Drawing.Size(160, 20);
            this.txtFlag.TabIndex = 8;
            this.txtFlag.Visible = false;
            this.txtFlag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFlag_KeyUp);
            // 
            // btnFindFlag
            // 
            this.btnFindFlag.Location = new System.Drawing.Point(296, 102);
            this.btnFindFlag.Name = "btnFindFlag";
            this.btnFindFlag.Size = new System.Drawing.Size(21, 20);
            this.btnFindFlag.TabIndex = 9;
            this.btnFindFlag.Text = "..";
            this.btnFindFlag.UseVisualStyleBackColor = true;
            this.btnFindFlag.Visible = false;
            this.btnFindFlag.Click += new System.EventHandler(this.btnFindFlag_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(101, 135);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(182, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // findFlagFile
            // 
            this.findFlagFile.DefaultExt = "png";
            this.findFlagFile.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Fi" +
                "les (*.gif)|*.gif";
            this.findFlagFile.Title = "Open Flag Image";
            // 
            // chkFlag
            // 
            this.chkFlag.AutoSize = true;
            this.chkFlag.Location = new System.Drawing.Point(38, 106);
            this.chkFlag.Name = "chkFlag";
            this.chkFlag.Size = new System.Drawing.Size(15, 14);
            this.chkFlag.TabIndex = 12;
            this.chkFlag.UseVisualStyleBackColor = true;
            this.chkFlag.CheckedChanged += new System.EventHandler(this.chkFlag_CheckedChanged);
            this.chkFlag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chkFlag_KeyUp);
            // 
            // imgMissingFlag
            // 
            this.imgMissingFlag.Image = global::LanguagePacker.Properties.Resources.flag_missing;
            this.imgMissingFlag.Location = new System.Drawing.Point(130, 107);
            this.imgMissingFlag.Name = "imgMissingFlag";
            this.imgMissingFlag.Size = new System.Drawing.Size(16, 11);
            this.imgMissingFlag.TabIndex = 13;
            this.imgMissingFlag.TabStop = false;
            // 
            // NewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 170);
            this.Controls.Add(this.imgMissingFlag);
            this.Controls.Add(this.chkFlag);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnFindFlag);
            this.Controls.Add(this.txtFlag);
            this.Controls.Add(this.lblFlag);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lnkLanguageHelp);
            this.Controls.Add(this.txtLang);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Language Pack";
            this.Load += new System.EventHandler(this.NewDialog_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewDialog_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.imgMissingFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.MaskedTextBox txtLang;
        private System.Windows.Forms.LinkLabel lnkLanguageHelp;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblFlag;
        private System.Windows.Forms.TextBox txtFlag;
        private System.Windows.Forms.Button btnFindFlag;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog findFlagFile;
        private System.Windows.Forms.CheckBox chkFlag;
        private System.Windows.Forms.PictureBox imgMissingFlag;
    }
}