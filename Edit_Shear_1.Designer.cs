namespace SampleWizard
{
    partial class Edit_Shear_1
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
            this.richTextBox11 = new System.Windows.Forms.RichTextBox();
            this.NSECT = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.AMLW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KHYSW_3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.KHYSW_2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.KHYSW_1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox33 = new System.Windows.Forms.RichTextBox();
            this.btn_NSECT = new System.Windows.Forms.Button();
            this.btn_AMLW = new System.Windows.Forms.Button();
            this.btn_AN = new System.Windows.Forms.Button();
            this.btn_KHYSW_3 = new System.Windows.Forms.Button();
            this.btn_KHYSW_2 = new System.Windows.Forms.Button();
            this.btn_KHYSW_1 = new System.Windows.Forms.Button();
            this.btn_IMC = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSECT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(23, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Shear wall type Number: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_NSECT);
            this.groupBox1.Controls.Add(this.btn_AMLW);
            this.groupBox1.Controls.Add(this.btn_AN);
            this.groupBox1.Controls.Add(this.btn_KHYSW_3);
            this.groupBox1.Controls.Add(this.btn_KHYSW_2);
            this.groupBox1.Controls.Add(this.btn_KHYSW_1);
            this.groupBox1.Controls.Add(this.btn_IMC);
            this.groupBox1.Controls.Add(this.richTextBox11);
            this.groupBox1.Controls.Add(this.NSECT);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.AMLW);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.AN);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.KHYSW_3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.KHYSW_2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.KHYSW_1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IMC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 320);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // richTextBox11
            // 
            this.richTextBox11.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox11.ForeColor = System.Drawing.Color.Red;
            this.richTextBox11.Location = new System.Drawing.Point(266, 280);
            this.richTextBox11.Name = "richTextBox11";
            this.richTextBox11.Size = new System.Drawing.Size(213, 24);
            this.richTextBox11.TabIndex = 97;
            this.richTextBox11.Text = "*Any change will delete all related data";
            // 
            // NSECT
            // 
            this.NSECT.Location = new System.Drawing.Point(407, 180);
            this.NSECT.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.NSECT.Name = "NSECT";
            this.NSECT.Size = new System.Drawing.Size(62, 20);
            this.NSECT.TabIndex = 15;
            this.NSECT.ValueChanged += new System.EventHandler(this.NSECT_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 41);
            this.button1.TabIndex = 14;
            this.button1.Text = "Add/Edit Sections";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Number of Sections.";
            // 
            // AMLW
            // 
            this.AMLW.Location = new System.Drawing.Point(407, 153);
            this.AMLW.Name = "AMLW";
            this.AMLW.Size = new System.Drawing.Size(62, 20);
            this.AMLW.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Height of shear wall.";
            // 
            // AN
            // 
            this.AN.Location = new System.Drawing.Point(406, 127);
            this.AN.Name = "AN";
            this.AN.Size = new System.Drawing.Size(62, 20);
            this.AN.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Axial load.";
            // 
            // KHYSW_3
            // 
            this.KHYSW_3.Location = new System.Drawing.Point(406, 101);
            this.KHYSW_3.Name = "KHYSW_3";
            this.KHYSW_3.Size = new System.Drawing.Size(62, 20);
            this.KHYSW_3.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Hysteretic Rule Number (shear).";
            // 
            // KHYSW_2
            // 
            this.KHYSW_2.Location = new System.Drawing.Point(407, 75);
            this.KHYSW_2.Name = "KHYSW_2";
            this.KHYSW_2.Size = new System.Drawing.Size(62, 20);
            this.KHYSW_2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hysteretic Rule Number (top).";
            // 
            // KHYSW_1
            // 
            this.KHYSW_1.Location = new System.Drawing.Point(406, 49);
            this.KHYSW_1.Name = "KHYSW_1";
            this.KHYSW_1.Size = new System.Drawing.Size(62, 20);
            this.KHYSW_1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hysteretic Rule Number (bottom).";
            // 
            // IMC
            // 
            this.IMC.Location = new System.Drawing.Point(406, 23);
            this.IMC.Name = "IMC";
            this.IMC.Size = new System.Drawing.Size(62, 20);
            this.IMC.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Concrete type number.";
            // 
            // button2
            // 
            this.button2.Image = global::SampleWizard.Properties.Resources.Previous;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(12, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "         Previous";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_23
            // 
            this.button_23.Image = global::SampleWizard.Properties.Resources.Next;
            this.button_23.Location = new System.Drawing.Point(461, 372);
            this.button_23.Name = "button_23";
            this.button_23.Size = new System.Drawing.Size(111, 28);
            this.button_23.TabIndex = 26;
            this.button_23.Text = "Next";
            this.button_23.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_23.UseVisualStyleBackColor = true;
            this.button_23.Click += new System.EventHandler(this.button_23_Click_1);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SampleWizard.Properties.Resources.Help_symbol;
            this.pictureBox4.Location = new System.Drawing.Point(467, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 119;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(221, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 28);
            this.button3.TabIndex = 120;
            this.button3.Text = "         Close && Save";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox33
            // 
            this.richTextBox33.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox33.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox33.ForeColor = System.Drawing.Color.Red;
            this.richTextBox33.Location = new System.Drawing.Point(482, 227);
            this.richTextBox33.Name = "richTextBox33";
            this.richTextBox33.Size = new System.Drawing.Size(10, 18);
            this.richTextBox33.TabIndex = 122;
            this.richTextBox33.Text = "*";
            // 
            // btn_NSECT
            // 
            this.btn_NSECT.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_NSECT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_NSECT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_NSECT.Location = new System.Drawing.Point(481, 180);
            this.btn_NSECT.Name = "btn_NSECT";
            this.btn_NSECT.Size = new System.Drawing.Size(23, 20);
            this.btn_NSECT.TabIndex = 112;
            this.btn_NSECT.UseVisualStyleBackColor = true;
            this.btn_NSECT.Click += new System.EventHandler(this.btn_NSECT_Click);
            // 
            // btn_AMLW
            // 
            this.btn_AMLW.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_AMLW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AMLW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AMLW.Location = new System.Drawing.Point(481, 154);
            this.btn_AMLW.Name = "btn_AMLW";
            this.btn_AMLW.Size = new System.Drawing.Size(23, 20);
            this.btn_AMLW.TabIndex = 111;
            this.btn_AMLW.UseVisualStyleBackColor = true;
            this.btn_AMLW.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_AN
            // 
            this.btn_AN.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_AN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AN.Location = new System.Drawing.Point(482, 127);
            this.btn_AN.Name = "btn_AN";
            this.btn_AN.Size = new System.Drawing.Size(23, 20);
            this.btn_AN.TabIndex = 110;
            this.btn_AN.UseVisualStyleBackColor = true;
            this.btn_AN.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KHYSW_3
            // 
            this.btn_KHYSW_3.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KHYSW_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KHYSW_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KHYSW_3.Location = new System.Drawing.Point(481, 101);
            this.btn_KHYSW_3.Name = "btn_KHYSW_3";
            this.btn_KHYSW_3.Size = new System.Drawing.Size(23, 20);
            this.btn_KHYSW_3.TabIndex = 109;
            this.btn_KHYSW_3.UseVisualStyleBackColor = true;
            this.btn_KHYSW_3.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KHYSW_2
            // 
            this.btn_KHYSW_2.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KHYSW_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KHYSW_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KHYSW_2.Location = new System.Drawing.Point(482, 75);
            this.btn_KHYSW_2.Name = "btn_KHYSW_2";
            this.btn_KHYSW_2.Size = new System.Drawing.Size(23, 20);
            this.btn_KHYSW_2.TabIndex = 108;
            this.btn_KHYSW_2.UseVisualStyleBackColor = true;
            this.btn_KHYSW_2.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KHYSW_1
            // 
            this.btn_KHYSW_1.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KHYSW_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KHYSW_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KHYSW_1.Location = new System.Drawing.Point(481, 49);
            this.btn_KHYSW_1.Name = "btn_KHYSW_1";
            this.btn_KHYSW_1.Size = new System.Drawing.Size(23, 20);
            this.btn_KHYSW_1.TabIndex = 107;
            this.btn_KHYSW_1.UseVisualStyleBackColor = true;
            this.btn_KHYSW_1.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_IMC
            // 
            this.btn_IMC.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IMC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IMC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IMC.Location = new System.Drawing.Point(481, 23);
            this.btn_IMC.Name = "btn_IMC";
            this.btn_IMC.Size = new System.Drawing.Size(23, 20);
            this.btn_IMC.TabIndex = 106;
            this.btn_IMC.UseVisualStyleBackColor = true;
            this.btn_IMC.Click += new System.EventHandler(this.btn_setRange);
            // 
            // Edit_Shear_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox33);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "Edit_Shear_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shear wall properties";
            this.Load += new System.EventHandler(this.Add_Columns_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NSECT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AMLW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox KHYSW_3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox KHYSW_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KHYSW_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.NumericUpDown NSECT;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox11;
        private System.Windows.Forms.RichTextBox richTextBox33;
        private System.Windows.Forms.Button btn_NSECT;
        private System.Windows.Forms.Button btn_AMLW;
        private System.Windows.Forms.Button btn_AN;
        private System.Windows.Forms.Button btn_KHYSW_3;
        private System.Windows.Forms.Button btn_KHYSW_2;
        private System.Windows.Forms.Button btn_KHYSW_1;
        private System.Windows.Forms.Button btn_IMC;
    }
}