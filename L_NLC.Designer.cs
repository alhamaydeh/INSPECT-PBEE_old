namespace SampleWizard
{
    partial class L_NLC
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
            this.JV = new System.Windows.Forms.NumericUpDown();
            this.LV = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.FV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IFV = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_FV = new System.Windows.Forms.Button();
            this.btn_JV = new System.Windows.Forms.Button();
            this.btn_LV = new System.Windows.Forms.Button();
            this.btn_IFV = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFV)).BeginInit();
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
            this.groupBox1.Controls.Add(this.btn_FV);
            this.groupBox1.Controls.Add(this.btn_JV);
            this.groupBox1.Controls.Add(this.btn_LV);
            this.groupBox1.Controls.Add(this.btn_IFV);
            this.groupBox1.Controls.Add(this.JV);
            this.groupBox1.Controls.Add(this.LV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IFV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 142);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // JV
            // 
            this.JV.Location = new System.Drawing.Point(213, 89);
            this.JV.Name = "JV";
            this.JV.Size = new System.Drawing.Size(45, 20);
            this.JV.TabIndex = 10;
            // 
            // LV
            // 
            this.LV.Location = new System.Drawing.Point(213, 61);
            this.LV.Name = "LV";
            this.LV.Size = new System.Drawing.Size(45, 20);
            this.LV.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Column line number.";
            // 
            // FV
            // 
            this.FV.Location = new System.Drawing.Point(213, 116);
            this.FV.Name = "FV";
            this.FV.Size = new System.Drawing.Size(100, 20);
            this.FV.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Magnitude of external nodal force.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Story level number.";
            // 
            // IFV
            // 
            this.IFV.Location = new System.Drawing.Point(213, 33);
            this.IFV.Name = "IFV";
            this.IFV.Size = new System.Drawing.Size(45, 20);
            this.IFV.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Frame number.";
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
            this.button2.Location = new System.Drawing.Point(149, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 28);
            this.button2.TabIndex = 29;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_FV
            // 
            this.btn_FV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FV.Location = new System.Drawing.Point(319, 116);
            this.btn_FV.Name = "btn_FV";
            this.btn_FV.Size = new System.Drawing.Size(23, 20);
            this.btn_FV.TabIndex = 52;
            this.btn_FV.UseVisualStyleBackColor = true;
            this.btn_FV.Click += new System.EventHandler(this.btn_FV_Click);
            // 
            // btn_JV
            // 
            this.btn_JV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_JV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_JV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_JV.Location = new System.Drawing.Point(264, 89);
            this.btn_JV.Name = "btn_JV";
            this.btn_JV.Size = new System.Drawing.Size(23, 20);
            this.btn_JV.TabIndex = 51;
            this.btn_JV.UseVisualStyleBackColor = true;
            this.btn_JV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_LV
            // 
            this.btn_LV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_LV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LV.Location = new System.Drawing.Point(264, 61);
            this.btn_LV.Name = "btn_LV";
            this.btn_LV.Size = new System.Drawing.Size(23, 20);
            this.btn_LV.TabIndex = 50;
            this.btn_LV.UseVisualStyleBackColor = true;
            this.btn_LV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_IFV
            // 
            this.btn_IFV.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IFV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IFV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IFV.Location = new System.Drawing.Point(264, 33);
            this.btn_IFV.Name = "btn_IFV";
            this.btn_IFV.Size = new System.Drawing.Size(23, 20);
            this.btn_IFV.TabIndex = 49;
            this.btn_IFV.UseVisualStyleBackColor = true;
            this.btn_IFV.Click += new System.EventHandler(this.btn_setRange);
            // 
            // L_NLC
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
            this.Name = "L_NLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data on Concentrated Vertical Loads";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IFV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IFV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown JV;
        private System.Windows.Forms.NumericUpDown LV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_FV;
        private System.Windows.Forms.Button btn_JV;
        private System.Windows.Forms.Button btn_LV;
        private System.Windows.Forms.Button btn_IFV;
    }
}