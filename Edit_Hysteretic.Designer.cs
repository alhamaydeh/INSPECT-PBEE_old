namespace SampleWizard
{
    partial class Edit_Hysteretic
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
            this.ANGDH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.KDHCH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RPSTDH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FYDH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KDH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_RPSTDH = new System.Windows.Forms.Button();
            this.btn_FYDH = new System.Windows.Forms.Button();
            this.btn_KDH = new System.Windows.Forms.Button();
            this.btn_ANGDH = new System.Windows.Forms.Button();
            this.btn_KDHCH = new System.Windows.Forms.Button();
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
            this.label6.Size = new System.Drawing.Size(325, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Hysteretic damper brace type Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_RPSTDH);
            this.groupBox1.Controls.Add(this.btn_FYDH);
            this.groupBox1.Controls.Add(this.btn_KDH);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.RPSTDH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FYDH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.KDH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 320);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ANGDH);
            this.groupBox2.Controls.Add(this.btn_KDHCH);
            this.groupBox2.Controls.Add(this.ANGDH);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.KDHCH);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // ANGDH
            // 
            this.ANGDH.Location = new System.Drawing.Point(389, 53);
            this.ANGDH.Name = "ANGDH";
            this.ANGDH.Size = new System.Drawing.Size(62, 20);
            this.ANGDH.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Angle of inclination of the brace with respect to a horizontal line.";
            // 
            // KDHCH
            // 
            this.KDHCH.Location = new System.Drawing.Point(388, 27);
            this.KDHCH.Name = "KDHCH";
            this.KDHCH.Size = new System.Drawing.Size(62, 20);
            this.KDHCH.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Axial stiffness of one leg of the Chevron bracing (EA/L).";
            // 
            // RPSTDH
            // 
            this.RPSTDH.Location = new System.Drawing.Point(394, 75);
            this.RPSTDH.Name = "RPSTDH";
            this.RPSTDH.Size = new System.Drawing.Size(62, 20);
            this.RPSTDH.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Post yield stiffness ratio.";
            // 
            // FYDH
            // 
            this.FYDH.Location = new System.Drawing.Point(394, 49);
            this.FYDH.Name = "FYDH";
            this.FYDH.Size = new System.Drawing.Size(62, 20);
            this.FYDH.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Yield force of this type of hysteretic dampers.";
            // 
            // KDH
            // 
            this.KDH.Location = new System.Drawing.Point(394, 23);
            this.KDH.Name = "KDH";
            this.KDH.Size = new System.Drawing.Size(62, 20);
            this.KDH.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Axial stiffness (EA/L).";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "Previous";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(461, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 28);
            this.button2.TabIndex = 26;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(220, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 28);
            this.button3.TabIndex = 28;
            this.button3.Text = "         Close && Save";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_RPSTDH
            // 
            this.btn_RPSTDH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_RPSTDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RPSTDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RPSTDH.Location = new System.Drawing.Point(462, 75);
            this.btn_RPSTDH.Name = "btn_RPSTDH";
            this.btn_RPSTDH.Size = new System.Drawing.Size(23, 20);
            this.btn_RPSTDH.TabIndex = 45;
            this.btn_RPSTDH.UseVisualStyleBackColor = true;
            this.btn_RPSTDH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_FYDH
            // 
            this.btn_FYDH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FYDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FYDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FYDH.Location = new System.Drawing.Point(462, 49);
            this.btn_FYDH.Name = "btn_FYDH";
            this.btn_FYDH.Size = new System.Drawing.Size(23, 20);
            this.btn_FYDH.TabIndex = 44;
            this.btn_FYDH.UseVisualStyleBackColor = true;
            this.btn_FYDH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KDH
            // 
            this.btn_KDH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KDH.Location = new System.Drawing.Point(462, 23);
            this.btn_KDH.Name = "btn_KDH";
            this.btn_KDH.Size = new System.Drawing.Size(23, 20);
            this.btn_KDH.TabIndex = 43;
            this.btn_KDH.UseVisualStyleBackColor = true;
            this.btn_KDH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ANGDH
            // 
            this.btn_ANGDH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ANGDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ANGDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ANGDH.Location = new System.Drawing.Point(456, 53);
            this.btn_ANGDH.Name = "btn_ANGDH";
            this.btn_ANGDH.Size = new System.Drawing.Size(23, 20);
            this.btn_ANGDH.TabIndex = 46;
            this.btn_ANGDH.UseVisualStyleBackColor = true;
            this.btn_ANGDH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KDHCH
            // 
            this.btn_KDHCH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KDHCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KDHCH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KDHCH.Location = new System.Drawing.Point(456, 27);
            this.btn_KDHCH.Name = "btn_KDHCH";
            this.btn_KDHCH.Size = new System.Drawing.Size(23, 20);
            this.btn_KDHCH.TabIndex = 45;
            this.btn_KDHCH.UseVisualStyleBackColor = true;
            this.btn_KDHCH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // Edit_Hysteretic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "Edit_Hysteretic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hysteretic damper brace properties";
            this.Load += new System.EventHandler(this.Add_Hysteretic_Load);
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
        private System.Windows.Forms.TextBox KDH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RPSTDH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FYDH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ANGDH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KDHCH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_RPSTDH;
        private System.Windows.Forms.Button btn_FYDH;
        private System.Windows.Forms.Button btn_KDH;
        private System.Windows.Forms.Button btn_ANGDH;
        private System.Windows.Forms.Button btn_KDHCH;
    }
}