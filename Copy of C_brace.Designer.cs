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
            this.KDH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.FYDH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.POWER = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RPSTDH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ETA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.groupBox1.Text = "groupBox1";
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
            this.label7.Size = new System.Drawing.Size(74, 13);
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
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Yield force of this type of hysteretic dampers";
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
            this.label2.Size = new System.Drawing.Size(142, 13);
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
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Post yield stiffness ratio";
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
            this.label5.Size = new System.Drawing.Size(230, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Ratio of forces in upper to lower bound curves";
            // 
            // C_brace_sp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.label6);
            this.Name = "C_brace_sp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add_Columns";
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
    }
}                                                                                                                                                                                                                                                                                                                                                                                                      on1.Location = new System.Drawing.Point(12, 372);
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
            // C_brace_sp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.label6);
            this.Name = "C_brace_sp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add_Columns";
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
        private System.Windows.Forms.TextBox KDH;
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
    }
}                         