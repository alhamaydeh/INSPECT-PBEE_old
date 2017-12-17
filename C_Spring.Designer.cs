namespace SampleWizard
{
    partial class C_Spring
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
            this.KSPL = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LSP = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.JSP = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ISP = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ITRSP = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_KSPL = new System.Windows.Forms.Button();
            this.btn_LSP = new System.Windows.Forms.Button();
            this.btn_JSP = new System.Windows.Forms.Button();
            this.btn_ISP = new System.Windows.Forms.Button();
            this.btn_ITRSP = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ITRSP)).BeginInit();
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
            this.groupBox1.Controls.Add(this.btn_KSPL);
            this.groupBox1.Controls.Add(this.btn_LSP);
            this.groupBox1.Controls.Add(this.btn_JSP);
            this.groupBox1.Controls.Add(this.btn_ISP);
            this.groupBox1.Controls.Add(this.btn_ITRSP);
            this.groupBox1.Controls.Add(this.KSPL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LSP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.JSP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ISP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ITRSP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 255);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // KSPL
            // 
            this.KSPL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KSPL.FormattingEnabled = true;
            this.KSPL.Items.AddRange(new object[] {
            "spring on beam, left of joint",
            "spring on column, top of joint",
            "spring on beam, right of joint",
            "spring on column, bottom of joint"});
            this.KSPL.Location = new System.Drawing.Point(248, 130);
            this.KSPL.Name = "KSPL";
            this.KSPL.Size = new System.Drawing.Size(244, 21);
            this.KSPL.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Relative spring location as follows:";
            // 
            // LSP
            // 
            this.LSP.Location = new System.Drawing.Point(248, 104);
            this.LSP.Name = "LSP";
            this.LSP.Size = new System.Drawing.Size(45, 20);
            this.LSP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Story level.";
            // 
            // JSP
            // 
            this.JSP.Location = new System.Drawing.Point(248, 78);
            this.JSP.Name = "JSP";
            this.JSP.Size = new System.Drawing.Size(45, 20);
            this.JSP.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Column line number.";
            // 
            // ISP
            // 
            this.ISP.Location = new System.Drawing.Point(248, 52);
            this.ISP.Name = "ISP";
            this.ISP.Size = new System.Drawing.Size(45, 20);
            this.ISP.TabIndex = 3;
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
            // ITRSP
            // 
            this.ITRSP.Location = new System.Drawing.Point(248, 26);
            this.ITRSP.Name = "ITRSP";
            this.ITRSP.Size = new System.Drawing.Size(45, 20);
            this.ITRSP.TabIndex = 1;
            this.ITRSP.ValueChanged += new System.EventHandler(this.ITW_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rotational Spring Type Number.";
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
            this.button2.Location = new System.Drawing.Point(219, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_KSPL
            // 
            this.btn_KSPL.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_KSPL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_KSPL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_KSPL.Location = new System.Drawing.Point(498, 131);
            this.btn_KSPL.Name = "btn_KSPL";
            this.btn_KSPL.Size = new System.Drawing.Size(23, 20);
            this.btn_KSPL.TabIndex = 53;
            this.btn_KSPL.UseVisualStyleBackColor = true;
            this.btn_KSPL.Click += new System.EventHandler(this.btn_KSPL_Click);
            // 
            // btn_LSP
            // 
            this.btn_LSP.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_LSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LSP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LSP.Location = new System.Drawing.Point(299, 104);
            this.btn_LSP.Name = "btn_LSP";
            this.btn_LSP.Size = new System.Drawing.Size(23, 20);
            this.btn_LSP.TabIndex = 52;
            this.btn_LSP.UseVisualStyleBackColor = true;
            this.btn_LSP.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_JSP
            // 
            this.btn_JSP.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_JSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_JSP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_JSP.Location = new System.Drawing.Point(299, 78);
            this.btn_JSP.Name = "btn_JSP";
            this.btn_JSP.Size = new System.Drawing.Size(23, 20);
            this.btn_JSP.TabIndex = 51;
            this.btn_JSP.UseVisualStyleBackColor = true;
            this.btn_JSP.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ISP
            // 
            this.btn_ISP.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ISP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ISP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ISP.Location = new System.Drawing.Point(299, 52);
            this.btn_ISP.Name = "btn_ISP";
            this.btn_ISP.Size = new System.Drawing.Size(23, 20);
            this.btn_ISP.TabIndex = 50;
            this.btn_ISP.UseVisualStyleBackColor = true;
            this.btn_ISP.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ITRSP
            // 
            this.btn_ITRSP.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ITRSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ITRSP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ITRSP.Location = new System.Drawing.Point(299, 26);
            this.btn_ITRSP.Name = "btn_ITRSP";
            this.btn_ITRSP.Size = new System.Drawing.Size(23, 20);
            this.btn_ITRSP.TabIndex = 49;
            this.btn_ITRSP.UseVisualStyleBackColor = true;
            this.btn_ITRSP.Click += new System.EventHandler(this.btn_setRange);
            // 
            // C_Spring
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
            this.Name = "C_Spring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Springs locations";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ITRSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.NumericUpDown ITRSP;
        private System.Windows.Forms.ComboBox KSPL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown LSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown JSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ISP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_KSPL;
        private System.Windows.Forms.Button btn_LSP;
        private System.Windows.Forms.Button btn_JSP;
        private System.Windows.Forms.Button btn_ISP;
        private System.Windows.Forms.Button btn_ITRSP;
    }
}