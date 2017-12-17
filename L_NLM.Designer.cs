namespace SampleWizard
{
    partial class L_NLM
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
            this.FM2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FM1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IBM = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_FM2 = new System.Windows.Forms.Button();
            this.btn_FM1 = new System.Windows.Forms.Button();
            this.btn_IBM = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IBM)).BeginInit();
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
            this.groupBox1.Controls.Add(this.btn_FM2);
            this.groupBox1.Controls.Add(this.btn_FM1);
            this.groupBox1.Controls.Add(this.btn_IBM);
            this.groupBox1.Controls.Add(this.FM2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.FM1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IBM);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 142);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // FM2
            // 
            this.FM2.Location = new System.Drawing.Point(213, 85);
            this.FM2.Name = "FM2";
            this.FM2.Size = new System.Drawing.Size(100, 20);
            this.FM2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nodal moment (right).";
            // 
            // FM1
            // 
            this.FM1.Location = new System.Drawing.Point(213, 59);
            this.FM1.Name = "FM1";
            this.FM1.Size = new System.Drawing.Size(100, 20);
            this.FM1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nodal moment (left).";
            // 
            // IBM
            // 
            this.IBM.Location = new System.Drawing.Point(213, 33);
            this.IBM.Name = "IBM";
            this.IBM.Size = new System.Drawing.Size(45, 20);
            this.IBM.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Beam number.";
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
            // btn_FM2
            // 
            this.btn_FM2.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FM2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FM2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FM2.Location = new System.Drawing.Point(319, 85);
            this.btn_FM2.Name = "btn_FM2";
            this.btn_FM2.Size = new System.Drawing.Size(23, 20);
            this.btn_FM2.TabIndex = 54;
            this.btn_FM2.UseVisualStyleBackColor = true;
            this.btn_FM2.Click += new System.EventHandler(this.btn_FM2_Click);
            // 
            // btn_FM1
            // 
            this.btn_FM1.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FM1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FM1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FM1.Location = new System.Drawing.Point(319, 59);
            this.btn_FM1.Name = "btn_FM1";
            this.btn_FM1.Size = new System.Drawing.Size(23, 20);
            this.btn_FM1.TabIndex = 53;
            this.btn_FM1.UseVisualStyleBackColor = true;
            this.btn_FM1.Click += new System.EventHandler(this.btn_FM1_Click);
            // 
            // btn_IBM
            // 
            this.btn_IBM.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IBM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IBM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IBM.Location = new System.Drawing.Point(264, 33);
            this.btn_IBM.Name = "btn_IBM";
            this.btn_IBM.Size = new System.Drawing.Size(23, 20);
            this.btn_IBM.TabIndex = 52;
            this.btn_IBM.UseVisualStyleBackColor = true;
            this.btn_IBM.Click += new System.EventHandler(this.btn_setRange);
            // 
            // L_NLM
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
            this.Name = "L_NLM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nodal Moment Data";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IBM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.TextBox FM1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IBM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FM2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_FM2;
        private System.Windows.Forms.Button btn_FM1;
        private System.Windows.Forms.Button btn_IBM;
    }
}