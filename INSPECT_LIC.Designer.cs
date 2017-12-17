namespace SampleWizard
{
    partial class INSPECT_LIC
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_agree = new System.Windows.Forms.Button();
            this.btn_decline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(3, 31);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(678, 402);
            this.webBrowser1.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Please read the agreement carefully before accepting it ";
            // 
            // btn_agree
            // 
            this.btn_agree.Location = new System.Drawing.Point(3, 439);
            this.btn_agree.Name = "btn_agree";
            this.btn_agree.Size = new System.Drawing.Size(75, 23);
            this.btn_agree.TabIndex = 29;
            this.btn_agree.Text = "Agree";
            this.btn_agree.UseVisualStyleBackColor = true;
            this.btn_agree.Click += new System.EventHandler(this.btn_agree_Click);
            // 
            // btn_decline
            // 
            this.btn_decline.Location = new System.Drawing.Point(84, 439);
            this.btn_decline.Name = "btn_decline";
            this.btn_decline.Size = new System.Drawing.Size(75, 23);
            this.btn_decline.TabIndex = 30;
            this.btn_decline.Text = "Decline";
            this.btn_decline.UseVisualStyleBackColor = true;
            this.btn_decline.Click += new System.EventHandler(this.btn_decline_Click);
            // 
            // INSPECT_LIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 471);
            this.Controls.Add(this.btn_decline);
            this.Controls.Add(this.btn_agree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "INSPECT_LIC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSPECT-PBEE License Agreement";
            this.Load += new System.EventHandler(this.INSPECT_LIC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_agree;
        private System.Windows.Forms.Button btn_decline;
    }
}