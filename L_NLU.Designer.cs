namespace SampleWizard
{
    partial class L_NLU
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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IBN = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_FU = new System.Windows.Forms.Button();
            this.btn_IBN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IBN)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(23, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Column number: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_FU);
            this.groupBox1.Controls.Add(this.btn_IBN);
            this.groupBox1.Controls.Add(this.FU);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IBN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 129);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // FU
            // 
            this.FU.Location = new System.Drawing.Point(213, 68);
            this.FU.Name = "FU";
            this.FU.Size = new System.Drawing.Size(92, 20);
            this.FU.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Magnitude of load (Force/length).";
            // 
            // IBN
            // 
            this.IBN.Location = new System.Drawing.Point(213, 24);
            this.IBN.Name = "IBN";
            this.IBN.Size = new System.Drawing.Size(45, 20);
            this.IBN.TabIndex = 1;
            this.IBN.ValueChanged += new System.EventHandler(this.ITW_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Beam number.";
            // 
            // button1
            // 
            this.button1.Image = global::SampleWizard.Properties.Resources.Previous;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 25;
            this.button1.Text = "         Previous";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_23
            // 
            this.button_23.Image = global::SampleWizard.Properties.Resources.Next;
            this.button_23.Location = new System.Drawing.Point(289, 208);
            this.button_23.Name = "button_23";
            this.button_23.Size = new System.Drawing.Size(111, 28);
            this.button_23.TabIndex = 24;
            this.button_23.Text = "Next";
            this.button_23.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_23.UseVisualStyleBackColor = true;
            this.button_23.Click += new System.EventHandler(this.button_23_Click_1);
            // 
            // button2
            // 
            this.button2.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(142, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 29;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_FU
            // 
            this.btn_FU.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FU.Location = new System.Drawing.Point(311, 69);
            this.btn_FU.Name = "btn_FU";
            this.btn_FU.Size = new System.Drawing.Size(23, 20);
            this.btn_FU.TabIndex = 55;
            this.btn_FU.UseVisualStyleBackColor = true;
            this.btn_FU.Click += new System.EventHandler(this.btn_FU_Click);
            // 
            // btn_IBN
            // 
            this.btn_IBN.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IBN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IBN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IBN.Location = new System.Drawing.Point(264, 24);
            this.btn_IBN.Name = "btn_IBN";
            this.btn_IBN.Size = new System.Drawing.Size(23, 20);
            this.btn_IBN.TabIndex = 54;
            this.btn_IBN.UseVisualStyleBackColor = true;
            this.btn_IBN.Click += new System.EventHandler(this.btn_IBN_Click);
            // 
            // L_NLU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 262);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.label6);
            this.Name = "L_NLU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Uniformly Loaded Beam Data";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IBN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.NumericUpDown IBN;
        private System.Windows.Forms.TextBox FU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_FU;
        private System.Windows.Forms.Button btn_IBN;
    }
}