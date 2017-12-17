namespace SampleWizard
{
    partial class Edit_Visco
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ANGDV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KDVCH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ALPHADV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.KDV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CDV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ALPHADV = new System.Windows.Forms.Button();
            this.btn_KDV = new System.Windows.Forms.Button();
            this.btn_CDV = new System.Windows.Forms.Button();
            this.btn_ANGDV = new System.Windows.Forms.Button();
            this.btn_KDVCH = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(23, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Visco-elastic brace type Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ALPHADV);
            this.groupBox1.Controls.Add(this.btn_KDV);
            this.groupBox1.Controls.Add(this.btn_CDV);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ALPHADV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.KDV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CDV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 320);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ANGDV);
            this.groupBox2.Controls.Add(this.btn_KDVCH);
            this.groupBox2.Controls.Add(this.ANGDV);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.KDVCH);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(9, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 119);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chevron Braces Data";
            // 
            // ANGDV
            // 
            this.ANGDV.Location = new System.Drawing.Point(391, 59);
            this.ANGDV.Name = "ANGDV";
            this.ANGDV.Size = new System.Drawing.Size(62, 20);
            this.ANGDV.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Angle of inclination of the brace with respect to a horizontal line";
            // 
            // KDVCH
            // 
            this.KDVCH.Location = new System.Drawing.Point(390, 33);
            this.KDVCH.Name = "KDVCH";
            this.KDVCH.Size = new System.Drawing.Size(62, 20);
            this.KDVCH.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Axial stiffness of one leg of the Chevron bracing (EA/L).";
            // 
            // ALPHADV
            // 
            this.ALPHADV.Location = new System.Drawing.Point(395, 75);
            this.ALPHADV.Name = "ALPHADV";
            this.ALPHADV.Size = new System.Drawing.Size(62, 20);
            this.ALPHADV.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Polynomial power α of velocity for non-linear dampers";
            // 
            // KDV
            // 
            this.KDV.Location = new System.Drawing.Point(395, 49);
            this.KDV.Name = "KDV";
            this.KDV.Size = new System.Drawing.Size(62, 20);
            this.KDV.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Axial stiffness of this type of visco-elastic brace (EA/L).";
            // 
            // CDV
            // 
            this.CDV.Location = new System.Drawing.Point(395, 23);
            this.CDV.Name = "CDV";
            this.CDV.Size = new System.Drawing.Size(62, 20);
            this.CDV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Damping constant C of this type of viscoelastic brace.";
            // 
            // button1
            // 
            this.button1.Image = global::SampleWizard.Properties.Resources.Previous;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "         Previous";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // button2
            // 
            this.button2.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(217, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 28;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ALPHADV
            // 
            this.btn_ALPHADV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ALPHADV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ALPHADV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ALPHADV.Location = new System.Drawing.Point(463, 75);
            this.btn_ALPHADV.Name = "btn_ALPHADV";
            this.btn_ALPHADV.Size = new System.Drawing.Size(23, 20);
            this.btn_ALPHADV.TabIndex = 106;
            this.btn_ALPHADV.UseVisualStyleBackColor = true;
            this.btn_ALPHADV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KDV
            // 
            this.btn_KDV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KDV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KDV.Location = new System.Drawing.Point(463, 49);
            this.btn_KDV.Name = "btn_KDV";
            this.btn_KDV.Size = new System.Drawing.Size(23, 20);
            this.btn_KDV.TabIndex = 105;
            this.btn_KDV.UseVisualStyleBackColor = true;
            this.btn_KDV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_CDV
            // 
            this.btn_CDV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_CDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CDV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CDV.Location = new System.Drawing.Point(463, 23);
            this.btn_CDV.Name = "btn_CDV";
            this.btn_CDV.Size = new System.Drawing.Size(23, 20);
            this.btn_CDV.TabIndex = 104;
            this.btn_CDV.UseVisualStyleBackColor = true;
            this.btn_CDV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ANGDV
            // 
            this.btn_ANGDV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ANGDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ANGDV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ANGDV.Location = new System.Drawing.Point(458, 58);
            this.btn_ANGDV.Name = "btn_ANGDV";
            this.btn_ANGDV.Size = new System.Drawing.Size(23, 20);
            this.btn_ANGDV.TabIndex = 107;
            this.btn_ANGDV.UseVisualStyleBackColor = true;
            this.btn_ANGDV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KDVCH
            // 
            this.btn_KDVCH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KDVCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KDVCH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KDVCH.Location = new System.Drawing.Point(458, 32);
            this.btn_KDVCH.Name = "btn_KDVCH";
            this.btn_KDVCH.Size = new System.Drawing.Size(23, 20);
            this.btn_KDVCH.TabIndex = 106;
            this.btn_KDVCH.UseVisualStyleBackColor = true;
            this.btn_KDVCH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // Edit_Visco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.label6);
            this.Name = "Edit_Visco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visco-elastic brace properties";
            this.Load += new System.EventHandler(this.Add_Visco_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ALPHADV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KDV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ANGDV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox KDVCH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ALPHADV;
        private System.Windows.Forms.Button btn_KDV;
        private System.Windows.Forms.Button btn_CDV;
        private System.Windows.Forms.Button btn_ANGDV;
        private System.Windows.Forms.Button btn_KDVCH;
    }
}