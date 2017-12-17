namespace SampleWizard
{
    partial class Edit_Friction
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
            this.ANGDF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.KDFCH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FYDF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KDF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_FYDF = new System.Windows.Forms.Button();
            this.btn_KDF = new System.Windows.Forms.Button();
            this.btn_ANGDF = new System.Windows.Forms.Button();
            this.btn_KDFCH = new System.Windows.Forms.Button();
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
            this.label6.Size = new System.Drawing.Size(317, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Friction (damper) brace type Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_FYDF);
            this.groupBox1.Controls.Add(this.btn_KDF);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.FYDF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.KDF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 225);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ANGDF);
            this.groupBox2.Controls.Add(this.btn_KDFCH);
            this.groupBox2.Controls.Add(this.ANGDF);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.KDFCH);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(15, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 100);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // ANGDF
            // 
            this.ANGDF.Location = new System.Drawing.Point(382, 53);
            this.ANGDF.Name = "ANGDF";
            this.ANGDF.Size = new System.Drawing.Size(62, 20);
            this.ANGDF.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Angle of inclination of the brace with respect to a horizontal line.";
            // 
            // KDFCH
            // 
            this.KDFCH.Location = new System.Drawing.Point(382, 27);
            this.KDFCH.Name = "KDFCH";
            this.KDFCH.Size = new System.Drawing.Size(62, 20);
            this.KDFCH.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Axial stiffness of one leg of the Chevron brace (EA/L).";
            // 
            // FYDF
            // 
            this.FYDF.Location = new System.Drawing.Point(394, 49);
            this.FYDF.Name = "FYDF";
            this.FYDF.Size = new System.Drawing.Size(62, 20);
            this.FYDF.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Friction force of this type of friction dampers.";
            // 
            // KDF
            // 
            this.KDF.Location = new System.Drawing.Point(394, 23);
            this.KDF.Name = "KDF";
            this.KDF.Size = new System.Drawing.Size(62, 20);
            this.KDF.TabIndex = 1;
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
            // button_23
            // 
            this.button_23.Location = new System.Drawing.Point(461, 372);
            this.button_23.Name = "button_23";
            this.button_23.Size = new System.Drawing.Size(111, 28);
            this.button_23.TabIndex = 26;
            this.button_23.Text = "Next";
            this.button_23.UseVisualStyleBackColor = true;
            this.button_23.Click += new System.EventHandler(this.button_23_Click_1);
            // 
            // button2
            // 
            this.button2.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(218, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 28;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_FYDF
            // 
            this.btn_FYDF.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FYDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FYDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FYDF.Location = new System.Drawing.Point(462, 49);
            this.btn_FYDF.Name = "btn_FYDF";
            this.btn_FYDF.Size = new System.Drawing.Size(23, 20);
            this.btn_FYDF.TabIndex = 50;
            this.btn_FYDF.UseVisualStyleBackColor = true;
            this.btn_FYDF.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KDF
            // 
            this.btn_KDF.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KDF.Location = new System.Drawing.Point(462, 23);
            this.btn_KDF.Name = "btn_KDF";
            this.btn_KDF.Size = new System.Drawing.Size(23, 20);
            this.btn_KDF.TabIndex = 49;
            this.btn_KDF.UseVisualStyleBackColor = true;
            this.btn_KDF.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ANGDF
            // 
            this.btn_ANGDF.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ANGDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ANGDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ANGDF.Location = new System.Drawing.Point(447, 55);
            this.btn_ANGDF.Name = "btn_ANGDF";
            this.btn_ANGDF.Size = new System.Drawing.Size(23, 20);
            this.btn_ANGDF.TabIndex = 52;
            this.btn_ANGDF.UseVisualStyleBackColor = true;
            this.btn_ANGDF.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_KDFCH
            // 
            this.btn_KDFCH.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KDFCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KDFCH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KDFCH.Location = new System.Drawing.Point(447, 26);
            this.btn_KDFCH.Name = "btn_KDFCH";
            this.btn_KDFCH.Size = new System.Drawing.Size(23, 20);
            this.btn_KDFCH.TabIndex = 51;
            this.btn_KDFCH.UseVisualStyleBackColor = true;
            this.btn_KDFCH.Click += new System.EventHandler(this.btn_setRange);
            // 
            // Edit_Friction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "Edit_Friction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visco-elastic brace properties";
            this.Load += new System.EventHandler(this.Add_Friction_Load);
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
        private System.Windows.Forms.TextBox KDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FYDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ANGDF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KDFCH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_FYDF;
        private System.Windows.Forms.Button btn_KDF;
        private System.Windows.Forms.Button btn_ANGDF;
        private System.Windows.Forms.Button btn_KDFCH;
    }
}