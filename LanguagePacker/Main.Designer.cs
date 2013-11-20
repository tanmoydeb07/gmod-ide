namespace LanguagePacker
{
    partial class Main
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
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.sepMain = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddField = new System.Windows.Forms.ToolStripButton();
            this.btnEditField = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveField = new System.Windows.Forms.ToolStripButton();
            this.sepExtra = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.stringTable = new System.Windows.Forms.ListView();
            this.clmKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.sepMain,
            this.btnAddField,
            this.btnEditField,
            this.btnRemoveField,
            this.sepExtra,
            this.btnHelp});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(384, 25);
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::LanguagePacker.Properties.Resources.page;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::LanguagePacker.Properties.Resources.folder_page;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::LanguagePacker.Properties.Resources.disk;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sepMain
            // 
            this.sepMain.Name = "sepMain";
            this.sepMain.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddField
            // 
            this.btnAddField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddField.Image = global::LanguagePacker.Properties.Resources.textfield_add;
            this.btnAddField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(23, 22);
            this.btnAddField.Text = "Add Field";
            this.btnAddField.Visible = false;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // btnEditField
            // 
            this.btnEditField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditField.Image = global::LanguagePacker.Properties.Resources.textfield_rename;
            this.btnEditField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditField.Name = "btnEditField";
            this.btnEditField.Size = new System.Drawing.Size(23, 22);
            this.btnEditField.Text = "Edit Field";
            this.btnEditField.Visible = false;
            this.btnEditField.Click += new System.EventHandler(this.btnEditField_Click);
            // 
            // btnRemoveField
            // 
            this.btnRemoveField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveField.Image = global::LanguagePacker.Properties.Resources.textfield_delete;
            this.btnRemoveField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveField.Text = "Remove Field";
            this.btnRemoveField.Visible = false;
            this.btnRemoveField.Click += new System.EventHandler(this.btnRemoveField_Click);
            // 
            // sepExtra
            // 
            this.sepExtra.Name = "sepExtra";
            this.sepExtra.Size = new System.Drawing.Size(6, 25);
            this.sepExtra.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = global::LanguagePacker.Properties.Resources.help;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.Text = "Help";
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "lang";
            this.openDialog.Filter = "Language Packs (.lang)|*.lang";
            this.openDialog.Title = "Open Language Pack";
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "lang";
            this.saveDialog.Filter = "Language Packs (.lang)|*.lang";
            this.saveDialog.Title = "Save Language Pack";
            // 
            // stringTable
            // 
            this.stringTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmKey,
            this.clmValue});
            this.stringTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stringTable.FullRowSelect = true;
            this.stringTable.GridLines = true;
            this.stringTable.Location = new System.Drawing.Point(0, 25);
            this.stringTable.Name = "stringTable";
            this.stringTable.Size = new System.Drawing.Size(384, 289);
            this.stringTable.TabIndex = 1;
            this.stringTable.UseCompatibleStateImageBehavior = false;
            this.stringTable.View = System.Windows.Forms.View.Details;
            // 
            // clmKey
            // 
            this.clmKey.Text = "Key";
            this.clmKey.Width = 190;
            // 
            // clmValue
            // 
            this.clmValue.Text = "Value";
            this.clmValue.Width = 190;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 314);
            this.Controls.Add(this.stringTable);
            this.Controls.Add(this.toolBar);
            this.Name = "Main";
            this.Text = "Language Packer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator sepMain;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ListView stringTable;
        private System.Windows.Forms.ToolStripButton btnAddField;
        private System.Windows.Forms.ToolStripButton btnEditField;
        private System.Windows.Forms.ToolStripButton btnRemoveField;
        private System.Windows.Forms.ToolStripSeparator sepExtra;
        private System.Windows.Forms.ColumnHeader clmKey;
        private System.Windows.Forms.ColumnHeader clmValue;
    }
}

