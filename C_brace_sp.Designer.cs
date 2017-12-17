namespace SampleWizard
{
    partial class C_brace_sp
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
            this.ETA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.POWER = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RPSTDH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FYDH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KDH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_KDH = new System.Windows.Forms.Button();
            this.btn_FYDH = new System.Windows.Forms.Button();
            this.btn_RPSTDH = new System.Windows.Forms.Button();
            this.btn_POWER = new System.Windows.Forms.Button();
            this.btn_ETA = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.btn_ETA);
            this.groupBox1.Controls.Add(this.btn_POWER);
            this.groupBox1.Controls.Add(this.btn_RPSTDH);
            this.groupBox1.Controls.Add(this.btn_FYDH);
            this.groupBox1.Controls.Add(this.btn_KDH);
            this.groupBox1.Controls.Add(this.ETA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.POWER);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RPSTDH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FYDH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.KDH);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 255);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // ETA
            // 
            this.ETA.Location = new System.Drawing.Point(329, 123);
            this.ETA.Name = "ETA";
            this.ETA.Size = new System.Drawing.Size(66, 20);
            this.ETA.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Ratio of forces in upper to lower bound curves";
            // 
            // POWER
            // 
            this.POWER.Location = new System.Drawing.Point(329, 97);
            this.POWER.Name = "POWER";
            this.POWER.Size = new System.Drawing.Size(66, 20);
            this.POWER.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Power of stiffness transition";
            // 
            // RPSTDH
            // 
            this.RPSTDH.Location = new System.Drawing.Point(329, 71);
            this.RPSTDH.Name = "RPSTDH";
            this.RPSTDH.Size = new System.Drawing.Size(66, 20);
            this.RPSTDH.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Post yield stiffness ratio";
            // 
            // FYDH
            // 
            this.FYDH.Location = new System.Drawing.Point(329, 45);
            this.FYDH.Name = "FYDH";
            this.FYDH.Size = new System.Drawing.Size(66, 20);
            this.FYDH.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Yield force of this type of hysteretic dampers";
            // 
            // KDH
            // 
            this.KDH.Location = new System.Drawing.Point(329, 19);
            this.KDH.Name = "KDH";
            this.KDH.Size = new System.Drawing.Size(66, 20);
            this.KDH.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Axial stiffness";
            // 
            // button1
            // 
            this.button1.Image = global::SampleWizard.Properties.Resources.Previous;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 372);
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
            this.button_23.Location = new System.Drawing.Point(461, 372);
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
            this.button2.Location = new System.Drawing.Point(222, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_KDH
            // 
            this.btn_KDH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KDH.Location = new System.Drawing.Point(401, 19);
            this.btn_KDH.Name = "btn_KDH";
            this.btn_KDH.Size = new System.Drawing.Size(23, 20);
            this.btn_KDH.TabIndex = 44;
            this.btn_KDH.UseVisualStyleBackColor = true;
            this.btn_KDH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_FYDH
            // 
            this.btn_FYDH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FYDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FYDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FYDH.Location = new System.Drawing.Point(401, 45);
            this.btn_FYDH.Name = "btn_FYDH";
            this.btn_FYDH.Size = new System.Drawing.Size(23, 20);
            this.btn_FYDH.TabIndex = 45;
            this.btn_FYDH.UseVisualStyleBackColor = true;
            this.btn_FYDH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_RPSTDH
            // 
            this.btn_RPSTDH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_RPSTDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RPSTDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RPSTDH.Location = new System.Drawing.Point(401, 71);
            this.btn_RPSTDH.Name = "btn_RPSTDH";
            this.btn_RPSTDH.Size = new System.Drawing.Size(23, 20);
            this.btn_RPSTDH.TabIndex = 46;
            this.btn_RPSTDH.UseVisualStyleBackColor = true;
            this.btn_RPSTDH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_POWER
            // 
            this.btn_POWER.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_POWER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_POWER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_POWER.Location = new System.Drawing.Point(401, 97);
            this.btn_POWER.Name = "btn_POWER";
            this.btn_POWER.Size = new System.Drawing.Size(23, 20);
            this.btn_POWER.TabIndex = 47;
            this.btn_POWER.UseVisualStyleBackColor = true;
            this.btn_POWER.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ETA
            // 
            this.btn_ETA.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ETA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ETA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ETA.Location = new System.Drawing.Point(401, 122);
            this.btn_ETA.Name = "btn_ETA";
            this.btn_ETA.Size = new System.Drawing.Size(23, 20);
            this.btn_ETA.TabIndex = 48;
            this.btn_ETA.UseVisualStyleBackColor = true;
            this.btn_ETA.Click += new System.EventHandler(this.btn_setRange);
            // 
            // C_brace_sp
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
            this.Name = "C_brace_sp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hysteretic damper brace properties sets";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.TextBox KDH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ETA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox POWER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RPSTDH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FYDH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ETA;
        private System.Windows.Forms.Button btn_POWER;
        private System.Windows.Forms.Button btn_RPSTDH;
        private System.Windows.Forms.Button btn_FYDH;
        private System.Windows.Forms.Button btn_KDH;
    }
}