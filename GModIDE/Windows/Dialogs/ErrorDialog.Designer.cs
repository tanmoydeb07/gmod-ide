namespace GModIDE.Windows.Dialogs
{
    partial class ErrorDialog
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
            this.errHelp = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.errInfo = new System.Windows.Forms.TextBox();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errHelp
            // 
            this.errHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errHelp.Location = new System.Drawing.Point(12, 9);
            this.errHelp.Name = "errHelp";
            this.errHelp.Size = new System.Drawing.Size(360, 105);
            this.errHelp.TabIndex = 0;
            this.errHelp.Text = "text_errornotice";
            this.errHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(106, 279);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "dialog_sendbug";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // errInfo
            // 
            this.errInfo.Location = new System.Drawing.Point(28, 130);
            this.errInfo.Multiline = true;
            this.errInfo.Name = "errInfo";
            this.errInfo.ReadOnly = true;
            this.errInfo.Size = new System.Drawing.Size(332, 133);
            this.errInfo.TabIndex = 3;
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(210, 279);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(75, 23);
            this.btnIgnore.TabIndex = 4;
            this.btnIgnore.Text = "dialog_ignorebug";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // ErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 314);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.errInfo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.errHelp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dialogt_exception";
            this.Load += new System.EventHandler(this.ErrorDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errHelp;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox errInfo;
        private System.Windows.Forms.Button btnIgnore;
    }
}