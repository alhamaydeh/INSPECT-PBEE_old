namespace SampleWizard
{
    partial class Edit_Transverse
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
            this.ARV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ALV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AKV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ALV = new System.Windows.Forms.Button();
            this.btn_ARV = new System.Windows.Forms.Button();
            this.btn_AKV = new System.Windows.Forms.Button();
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
            this.label6.Size = new System.Drawing.Size(270, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Transverse beam type Number: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ALV);
            this.groupBox1.Controls.Add(this.btn_ARV);
            this.groupBox1.Controls.Add(this.btn_AKV);
            this.groupBox1.Controls.Add(this.ARV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ALV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AKV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 132);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // ARV
            // 
            this.ARV.Location = new System.Drawing.Point(366, 49);
            this.ARV.Name = "ARV";
            this.ARV.Size = new System.Drawing.Size(62, 20);
            this.ARV.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Torsional Stiffness";
            // 
            // ALV
            // 
            this.ALV.Location = new System.Drawing.Point(366, 75);
            this.ALV.Name = "ALV";
            this.ALV.Size = new System.Drawing.Size(62, 20);
            this.ALV.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Element length";
            // 
            // AKV
            // 
            this.AKV.Location = new System.Drawing.Point(366, 23);
            this.AKV.Name = "AKV";
            this.AKV.Size = new System.Drawing.Size(62, 20);
            this.AKV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vertical Stiffness";
            // 
            // button1
            // 
            this.button1.Image = global::SampleWizard.Properties.Resources.Previous;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(10, 222);
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
            this.button_23.Location = new System.Drawing.Point(411, 222);
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
            this.button2.Location = new System.Drawing.Point(200, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 28;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ALV
            // 
            this.btn_ALV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ALV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ALV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ALV.Location = new System.Drawing.Point(434, 74);
            this.btn_ALV.Name = "btn_ALV";
            this.btn_ALV.Size = new System.Drawing.Size(23, 20);
            this.btn_ALV.TabIndex = 105;
            this.btn_ALV.UseVisualStyleBackColor = true;
            this.btn_ALV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ARV
            // 
            this.btn_ARV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ARV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ARV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ARV.Location = new System.Drawing.Point(434, 48);
            this.btn_ARV.Name = "btn_ARV";
            this.btn_ARV.Size = new System.Drawing.Size(23, 20);
            this.btn_ARV.TabIndex = 104;
            this.btn_ARV.UseVisualStyleBackColor = true;
            this.btn_ARV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_AKV
            // 
            this.btn_AKV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_AKV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AKV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AKV.Location = new System.Drawing.Point(434, 22);
            this.btn_AKV.Name = "btn_AKV";
            this.btn_AKV.Size = new System.Drawing.Size(23, 20);
            this.btn_AKV.TabIndex = 103;
            this.btn_AKV.UseVisualStyleBackColor = true;
            this.btn_AKV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // Edit_Transverse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 262);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "Edit_Transverse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transverse beam properties";
            this.Load += new System.EventHandler(this.Add_Transverse_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AKV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ARV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ALV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ALV;
        private System.Windows.Forms.Button btn_ARV;
        private System.Windows.Forms.Button btn_AKV;
    }
}