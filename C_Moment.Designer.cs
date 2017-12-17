namespace SampleWizard
{
    partial class C_Moment
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
            this.IHTY = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IREG = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.INUM = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_IREG = new System.Windows.Forms.Button();
            this.btn_INUM = new System.Windows.Forms.Button();
            this.btn_IHTY = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.INUM)).BeginInit();
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
            this.groupBox1.Controls.Add(this.btn_IREG);
            this.groupBox1.Controls.Add(this.IHTY);
            this.groupBox1.Controls.Add(this.btn_INUM);
            this.groupBox1.Controls.Add(this.btn_IHTY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IREG);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.INUM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 255);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // IHTY
            // 
            this.IHTY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IHTY.FormattingEnabled = true;
            this.IHTY.Items.AddRange(new object[] {
            "COLUMN",
            "BEAM",
            "WALL"});
            this.IHTY.Location = new System.Drawing.Point(299, 49);
            this.IHTY.Name = "IHTY";
            this.IHTY.Size = new System.Drawing.Size(145, 21);
            this.IHTY.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Element type:";
            // 
            // IREG
            // 
            this.IREG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IREG.FormattingEnabled = true;
            this.IREG.Items.AddRange(new object[] {
            "BOTTOM or LEFT",
            "TOP or RIGHT"});
            this.IREG.Location = new System.Drawing.Point(299, 130);
            this.IREG.Name = "IREG";
            this.IREG.Size = new System.Drawing.Size(145, 21);
            this.IREG.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Location of hinge or moment release:";
            // 
            // INUM
            // 
            this.INUM.Location = new System.Drawing.Point(299, 87);
            this.INUM.Name = "INUM";
            this.INUM.Size = new System.Drawing.Size(45, 20);
            this.INUM.TabIndex = 1;
            this.INUM.ValueChanged += new System.EventHandler(this.ITW_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Column, Beam or Wall number.";
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
            this.button2.Location = new System.Drawing.Point(228, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_IREG
            // 
            this.btn_IREG.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IREG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IREG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IREG.Location = new System.Drawing.Point(450, 131);
            this.btn_IREG.Name = "btn_IREG";
            this.btn_IREG.Size = new System.Drawing.Size(23, 20);
            this.btn_IREG.TabIndex = 47;
            this.btn_IREG.UseVisualStyleBackColor = true;
            this.btn_IREG.Click += new System.EventHandler(this.btn_IREG_Click);
            // 
            // btn_INUM
            // 
            this.btn_INUM.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_INUM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_INUM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_INUM.Location = new System.Drawing.Point(350, 87);
            this.btn_INUM.Name = "btn_INUM";
            this.btn_INUM.Size = new System.Drawing.Size(23, 20);
            this.btn_INUM.TabIndex = 46;
            this.btn_INUM.UseVisualStyleBackColor = true;
            this.btn_INUM.Click += new System.EventHandler(this.btn_INUM_Click);
            // 
            // btn_IHTY
            // 
            this.btn_IHTY.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_IHTY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_IHTY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_IHTY.Location = new System.Drawing.Point(450, 50);
            this.btn_IHTY.Name = "btn_IHTY";
            this.btn_IHTY.Size = new System.Drawing.Size(23, 20);
            this.btn_IHTY.TabIndex = 45;
            this.btn_IHTY.UseVisualStyleBackColor = true;
            this.btn_IHTY.Click += new System.EventHandler(this.btn_IHTY_Click);
            // 
            // C_Moment
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
            this.Name = "C_Moment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Moment releases";
            this.Load += new System.EventHandler(this.Add_Edge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.INUM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.NumericUpDown INUM;
        private System.Windows.Forms.ComboBox IREG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox IHTY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_IREG;
        private System.Windows.Forms.Button btn_INUM;
        private System.Windows.Forms.Button btn_IHTY;
    }
}