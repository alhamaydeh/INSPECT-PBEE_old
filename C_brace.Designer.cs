namespace SampleWizard
{
    partial class C_brace
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
            this.AMLBR = new System.Windows.Forms.TextBox();
            this.ITBR = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.JB = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.JT = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.LB = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.LT = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ITD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IF = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_IF = new System.Windows.Forms.Button();
            this.btn_ITD = new System.Windows.Forms.Button();
            this.btn_LT = new System.Windows.Forms.Button();
            this.btn_LB = new System.Windows.Forms.Button();
            this.btn_JT = new System.Windows.Forms.Button();
            this.btn_JB = new System.Windows.Forms.Button();
            this.btn_AMLBR = new System.Windows.Forms.Button();
            this.btn_ITBR = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ITD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IF)).BeginInit();
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
            this.groupBox1.Controls.Add(this.btn_ITBR);
            this.groupBox1.Controls.Add(this.btn_AMLBR);
            this.groupBox1.Controls.Add(this.btn_JB);
            this.groupBox1.Controls.Add(this.btn_JT);
            this.groupBox1.Controls.Add(this.btn_LB);
            this.groupBox1.Controls.Add(this.btn_LT);
            this.groupBox1.Controls.Add(this.btn_ITD);
            this.groupBox1.Controls.Add(this.btn_IF);
            this.groupBox1.Controls.Add(this.AMLBR);
            this.groupBox1.Controls.Add(this.ITBR);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.JB);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.JT);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ITD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 255);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // AMLBR
            // 
            this.AMLBR.Location = new System.Drawing.Point(326, 207);
            this.AMLBR.Name = "AMLBR";
            this.AMLBR.Size = new System.Drawing.Size(66, 20);
            this.AMLBR.TabIndex = 16;
            // 
            // ITBR
            // 
            this.ITBR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ITBR.FormattingEnabled = true;
            this.ITBR.Items.AddRange(new object[] {
            "Visco-elastic brace",
            "Friction damper brace",
            "Hysteretic damper brace"});
            this.ITBR.Location = new System.Drawing.Point(326, 50);
            this.ITBR.Name = "ITBR";
            this.ITBR.Size = new System.Drawing.Size(196, 21);
            this.ITBR.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Brace length (joint to joint).";
            // 
            // JB
            // 
            this.JB.Location = new System.Drawing.Point(326, 181);
            this.JB.Name = "JB";
            this.JB.Size = new System.Drawing.Size(45, 20);
            this.JB.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(231, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Column line number at bottom side of the brace.";
            // 
            // JT
            // 
            this.JT.Location = new System.Drawing.Point(326, 155);
            this.JT.Name = "JT";
            this.JT.Size = new System.Drawing.Size(45, 20);
            this.JT.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Column line number at top side of the brace.";
            // 
            // LB
            // 
            this.LB.Location = new System.Drawing.Point(326, 129);
            this.LB.Name = "LB";
            this.LB.Size = new System.Drawing.Size(45, 20);
            this.LB.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Story level at bottom side of the brace.";
            // 
            // LT
            // 
            this.LT.Location = new System.Drawing.Point(326, 103);
            this.LT.Name = "LT";
            this.LT.Size = new System.Drawing.Size(45, 20);
            this.LT.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Story level at top side of the brace.";
            // 
            // ITD
            // 
            this.ITD.Location = new System.Drawing.Point(326, 77);
            this.ITD.Name = "ITD";
            this.ITD.Size = new System.Drawing.Size(45, 20);
            this.ITD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Property type number of specified brace.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brace type:";
            // 
            // IF
            // 
            this.IF.Location = new System.Drawing.Point(326, 24);
            this.IF.Name = "IF";
            this.IF.Size = new System.Drawing.Size(45, 20);
            this.IF.TabIndex = 1;
            this.IF.ValueChanged += new System.EventHandler(this.ITW_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Frame number.";
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
            this.button2.Location = new System.Drawing.Point(233, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_IF
            // 
            this.btn_IF.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IF.Location = new System.Drawing.Point(377, 24);
            this.btn_IF.Name = "btn_IF";
            this.btn_IF.Size = new System.Drawing.Size(23, 20);
            this.btn_IF.TabIndex = 43;
            this.btn_IF.UseVisualStyleBackColor = true;
            this.btn_IF.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ITD
            // 
            this.btn_ITD.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ITD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ITD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ITD.Location = new System.Drawing.Point(377, 77);
            this.btn_ITD.Name = "btn_ITD";
            this.btn_ITD.Size = new System.Drawing.Size(23, 20);
            this.btn_ITD.TabIndex = 44;
            this.btn_ITD.UseVisualStyleBackColor = true;
            this.btn_ITD.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_LT
            // 
            this.btn_LT.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_LT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LT.Location = new System.Drawing.Point(377, 103);
            this.btn_LT.Name = "btn_LT";
            this.btn_LT.Size = new System.Drawing.Size(23, 20);
            this.btn_LT.TabIndex = 45;
            this.btn_LT.UseVisualStyleBackColor = true;
            this.btn_LT.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_LB
            // 
            this.btn_LB.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_LB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LB.Location = new System.Drawing.Point(377, 129);
            this.btn_LB.Name = "btn_LB";
            this.btn_LB.Size = new System.Drawing.Size(23, 20);
            this.btn_LB.TabIndex = 46;
            this.btn_LB.UseVisualStyleBackColor = true;
            this.btn_LB.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_JT
            // 
            this.btn_JT.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_JT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_JT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_JT.Location = new System.Drawing.Point(377, 155);
            this.btn_JT.Name = "btn_JT";
            this.btn_JT.Size = new System.Drawing.Size(23, 20);
            this.btn_JT.TabIndex = 47;
            this.btn_JT.UseVisualStyleBackColor = true;
            this.btn_JT.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_JB
            // 
            this.btn_JB.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_JB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_JB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_JB.Location = new System.Drawing.Point(377, 181);
            this.btn_JB.Name = "btn_JB";
            this.btn_JB.Size = new System.Drawing.Size(23, 20);
            this.btn_JB.TabIndex = 48;
            this.btn_JB.UseVisualStyleBackColor = true;
            this.btn_JB.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_AMLBR
            // 
            this.btn_AMLBR.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_AMLBR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AMLBR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AMLBR.Location = new System.Drawing.Point(398, 206);
            this.btn_AMLBR.Name = "btn_AMLBR";
            this.btn_AMLBR.Size = new System.Drawing.Size(23, 20);
            this.btn_AMLBR.TabIndex = 49;
            this.btn_AMLBR.UseVisualStyleBackColor = true;
            this.btn_AMLBR.Click += new System.EventHandler(this.btn_AMLBR_Click);
            // 
            // btn_ITBR
            // 
            this.btn_ITBR.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ITBR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ITBR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ITBR.Location = new System.Drawing.Point(528, 50);
            this.btn_ITBR.Name = "btn_ITBR";
            this.btn_ITBR.Size = new System.Drawing.Size(23, 20);
            this.btn_ITBR.TabIndex = 50;
            this.btn_ITBR.UseVisualStyleBackColor = true;
            this.btn_ITBR.Click += new System.EventHandler(this.btn_ITBR_Click);
            // 
            // C_brace
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
            this.Name = "C_brace";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Brace Connectivities";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ITD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.NumericUpDown IF;
        private System.Windows.Forms.TextBox AMLBR;
        private System.Windows.Forms.ComboBox ITBR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown JB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown JT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown LB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown LT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ITD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ITBR;
        private System.Windows.Forms.Button btn_AMLBR;
        private System.Windows.Forms.Button btn_JB;
        private System.Windows.Forms.Button btn_JT;
        private System.Windows.Forms.Button btn_LB;
        private System.Windows.Forms.Button btn_LT;
        private System.Windows.Forms.Button btn_ITD;
        private System.Windows.Forms.Button btn_IF;
    }
}