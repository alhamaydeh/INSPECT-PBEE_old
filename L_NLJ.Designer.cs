namespace SampleWizard
{
    partial class L_NLJ
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
            this.FL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IF_1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.LF = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_FL = new System.Windows.Forms.Button();
            this.btn_IF_1 = new System.Windows.Forms.Button();
            this.btn_LF = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IF_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LF)).BeginInit();
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
            this.groupBox1.Controls.Add(this.btn_FL);
            this.groupBox1.Controls.Add(this.btn_IF_1);
            this.groupBox1.Controls.Add(this.btn_LF);
            this.groupBox1.Controls.Add(this.FL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IF_1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 129);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // FL
            // 
            this.FL.Location = new System.Drawing.Point(213, 76);
            this.FL.Name = "FL";
            this.FL.Size = new System.Drawing.Size(100, 20);
            this.FL.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Magnitude of load.";
            // 
            // IF_1
            // 
            this.IF_1.Location = new System.Drawing.Point(213, 50);
            this.IF_1.Name = "IF_1";
            this.IF_1.Size = new System.Drawing.Size(45, 20);
            this.IF_1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Frame number.";
            // 
            // LF
            // 
            this.LF.Location = new System.Drawing.Point(213, 24);
            this.LF.Name = "LF";
            this.LF.Size = new System.Drawing.Size(45, 20);
            this.LF.TabIndex = 1;
            this.LF.ValueChanged += new System.EventHandler(this.ITW_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Story level number.";
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
            // btn_FL
            // 
            this.btn_FL.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FL.Location = new System.Drawing.Point(319, 75);
            this.btn_FL.Name = "btn_FL";
            this.btn_FL.Size = new System.Drawing.Size(23, 20);
            this.btn_FL.TabIndex = 51;
            this.btn_FL.UseVisualStyleBackColor = true;
            this.btn_FL.Click += new System.EventHandler(this.btn_FL_Click);
            // 
            // btn_IF_1
            // 
            this.btn_IF_1.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IF_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IF_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IF_1.Location = new System.Drawing.Point(264, 50);
            this.btn_IF_1.Name = "btn_IF_1";
            this.btn_IF_1.Size = new System.Drawing.Size(23, 20);
            this.btn_IF_1.TabIndex = 50;
            this.btn_IF_1.UseVisualStyleBackColor = true;
            this.btn_IF_1.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_LF
            // 
            this.btn_LF.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_LF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LF.Location = new System.Drawing.Point(264, 24);
            this.btn_LF.Name = "btn_LF";
            this.btn_LF.Size = new System.Drawing.Size(23, 20);
            this.btn_LF.TabIndex = 49;
            this.btn_LF.UseVisualStyleBackColor = true;
            this.btn_LF.Click += new System.EventHandler(this.btn_setRange);
            // 
            // L_NLJ
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
            this.Name = "L_NLJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Laterally Loaded Joints";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IF_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.NumericUpDown LF;
        private System.Windows.Forms.TextBox FL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IF_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_FL;
        private System.Windows.Forms.Button btn_IF_1;
        private System.Windows.Forms.Button btn_LF;
    }
}