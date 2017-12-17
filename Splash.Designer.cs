namespace SampleWizard
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pb_loading = new ColorProgressBar.ColorProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pb_loading
            // 
            this.pb_loading.BackColor = System.Drawing.SystemColors.Control;
            this.pb_loading.BarColor = System.Drawing.Color.LightSkyBlue;
            this.pb_loading.BorderColor = System.Drawing.Color.Black;
            this.pb_loading.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Dashed;
            this.pb_loading.Location = new System.Drawing.Point(-4, 318);
            this.pb_loading.Maximum = 100;
            this.pb_loading.Minimum = 0;
            this.pb_loading.Name = "pb_loading";
            this.pb_loading.Size = new System.Drawing.Size(526, 12);
            this.pb_loading.Step = 10;
            this.pb_loading.TabIndex = 1;
            this.pb_loading.Value = 0;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(520, 476);
            this.Controls.Add(this.pb_loading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private ColorProgressBar.ColorProgressBar pb_loading;
    }
}