﻿namespace GModIDE.Windows.Dialogs
{
    partial class StubDialog
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
            this.btnOkay = new System.Windows.Forms.Button();
            this.stubInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // errHelp
            // 
            this.errHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errHelp.Location = new System.Drawing.Point(12, 9);
            this.errHelp.Name = "errHelp";
            this.errHelp.Size = new System.Drawing.Size(360, 105);
            this.errHelp.TabIndex = 0;
            this.errHelp.Text = "text_stubnotice";
            this.errHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOkay
            // 
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkay.Location = new System.Drawing.Point(160, 279);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 2;
            this.btnOkay.Text = "dialog_okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            // 
            // stubInfo
            // 
            this.stubInfo.Location = new System.Drawing.Point(28, 130);
            this.stubInfo.Multiline = true;
            this.stubInfo.Name = "stubInfo";
            this.stubInfo.ReadOnly = true;
            this.stubInfo.Size = new System.Drawing.Size(332, 133);
            this.stubInfo.TabIndex = 3;
            // 
            // StubDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 314);
            this.Controls.Add(this.stubInfo);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.errHelp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StubDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dialogt_stub";
            this.Load += new System.EventHandler(this.ErrorDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errHelp;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.TextBox stubInfo;
    }
}