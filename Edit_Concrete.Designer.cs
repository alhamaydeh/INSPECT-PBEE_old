namespace SampleWizard
{
    partial class Edit_Concrete
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
            this.components = new System.ComponentModel.Container();
            this.button_23 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.ZF = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.EPSU = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.FC = new System.Windows.Forms.TextBox();
            this.EC = new System.Windows.Forms.TextBox();
            this.EPS0 = new System.Windows.Forms.TextBox();
            this.FT = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.databaseDataSet = new SampleWizard.DatabaseDataSet();
            this.databaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_FT = new System.Windows.Forms.Button();
            this.btn_EPS0 = new System.Windows.Forms.Button();
            this.btn_EC = new System.Windows.Forms.Button();
            this.btn_ZF = new System.Windows.Forms.Button();
            this.btn_EPSU = new System.Windows.Forms.Button();
            this.btn_FC = new System.Windows.Forms.Button();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_23
            // 
            this.button_23.Location = new System.Drawing.Point(461, 372);
            this.button_23.Name = "button_23";
            this.button_23.Size = new System.Drawing.Size(111, 28);
            this.button_23.TabIndex = 10;
            this.button_23.Text = "Next";
            this.button_23.UseVisualStyleBackColor = true;
            this.button_23.Click += new System.EventHandler(this.button_23_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(32, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Concrete property type Number:";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btn_FT);
            this.groupBox16.Controls.Add(this.btn_EPS0);
            this.groupBox16.Controls.Add(this.btn_EC);
            this.groupBox16.Controls.Add(this.btn_ZF);
            this.groupBox16.Controls.Add(this.btn_EPSU);
            this.groupBox16.Controls.Add(this.btn_FC);
            this.groupBox16.Controls.Add(this.checkBox6);
            this.groupBox16.Controls.Add(this.checkBox5);
            this.groupBox16.Controls.Add(this.checkBox4);
            this.groupBox16.Controls.Add(this.ZF);
            this.groupBox16.Controls.Add(this.label32);
            this.groupBox16.Controls.Add(this.EPSU);
            this.groupBox16.Controls.Add(this.label31);
            this.groupBox16.Controls.Add(this.FC);
            this.groupBox16.Controls.Add(this.EC);
            this.groupBox16.Controls.Add(this.EPS0);
            this.groupBox16.Controls.Add(this.FT);
            this.groupBox16.Controls.Add(this.label30);
            this.groupBox16.Controls.Add(this.label29);
            this.groupBox16.Controls.Add(this.label28);
            this.groupBox16.Controls.Add(this.label27);
            this.groupBox16.Location = new System.Drawing.Point(36, 57);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(489, 265);
            this.groupBox16.TabIndex = 21;
            this.groupBox16.TabStop = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(390, 126);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(89, 17);
            this.checkBox6.TabIndex = 19;
            this.checkBox6.Text = "Default value";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(390, 98);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(89, 17);
            this.checkBox5.TabIndex = 18;
            this.checkBox5.Text = "Default value";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(390, 70);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(89, 17);
            this.checkBox4.TabIndex = 17;
            this.checkBox4.Text = "Default value";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // ZF
            // 
            this.ZF.Location = new System.Drawing.Point(248, 175);
            this.ZF.Name = "ZF";
            this.ZF.Size = new System.Drawing.Size(100, 20);
            this.ZF.TabIndex = 13;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(21, 178);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(204, 13);
            this.label32.TabIndex = 12;
            this.label32.Text = "Parameter defining slope of falling branch.";
            // 
            // EPSU
            // 
            this.EPSU.Location = new System.Drawing.Point(248, 149);
            this.EPSU.Name = "EPSU";
            this.EPSU.Size = new System.Drawing.Size(100, 20);
            this.EPSU.TabIndex = 11;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(21, 152);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(166, 13);
            this.label31.TabIndex = 10;
            this.label31.Text = "Ultimate strain in compression (%).";
            // 
            // FC
            // 
            this.FC.Location = new System.Drawing.Point(248, 39);
            this.FC.Name = "FC";
            this.FC.Size = new System.Drawing.Size(100, 20);
            this.FC.TabIndex = 9;
            this.FC.TextChanged += new System.EventHandler(this.FC_TextChanged);
            // 
            // EC
            // 
            this.EC.Location = new System.Drawing.Point(248, 67);
            this.EC.Name = "EC";
            this.EC.Size = new System.Drawing.Size(100, 20);
            this.EC.TabIndex = 8;
            // 
            // EPS0
            // 
            this.EPS0.Location = new System.Drawing.Point(248, 93);
            this.EPS0.Name = "EPS0";
            this.EPS0.Size = new System.Drawing.Size(100, 20);
            this.EPS0.TabIndex = 7;
            // 
            // FT
            // 
            this.FT.Location = new System.Drawing.Point(248, 123);
            this.FT.Name = "FT";
            this.FT.Size = new System.Drawing.Size(100, 20);
            this.FT.TabIndex = 6;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(21, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(168, 13);
            this.label30.TabIndex = 4;
            this.label30.Text = "Unconfined compressive strength.";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(21, 70);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(175, 13);
            this.label29.TabIndex = 3;
            this.label29.Text = "Initial Young\'s Modulus of concrete.";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(21, 99);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(189, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Strain at max. strength of concrete (%).";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(21, 126);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(132, 13);
            this.label27.TabIndex = 1;
            this.label27.Text = "Stress at tension cracking.";
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "DatabaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // databaseDataSetBindingSource
            // 
            this.databaseDataSetBindingSource.DataSource = this.databaseDataSet;
            this.databaseDataSetBindingSource.Position = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "Previous";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(232, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_FT
            // 
            this.btn_FT.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FT.Location = new System.Drawing.Point(354, 122);
            this.btn_FT.Name = "btn_FT";
            this.btn_FT.Size = new System.Drawing.Size(23, 20);
            this.btn_FT.TabIndex = 57;
            this.btn_FT.UseVisualStyleBackColor = true;
            this.btn_FT.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_EPS0
            // 
            this.btn_EPS0.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_EPS0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_EPS0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EPS0.Location = new System.Drawing.Point(354, 92);
            this.btn_EPS0.Name = "btn_EPS0";
            this.btn_EPS0.Size = new System.Drawing.Size(23, 20);
            this.btn_EPS0.TabIndex = 56;
            this.btn_EPS0.UseVisualStyleBackColor = true;
            this.btn_EPS0.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_EC
            // 
            this.btn_EC.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_EC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_EC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EC.Location = new System.Drawing.Point(354, 67);
            this.btn_EC.Name = "btn_EC";
            this.btn_EC.Size = new System.Drawing.Size(23, 20);
            this.btn_EC.TabIndex = 55;
            this.btn_EC.UseVisualStyleBackColor = true;
            this.btn_EC.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_ZF
            // 
            this.btn_ZF.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_ZF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ZF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ZF.Location = new System.Drawing.Point(354, 175);
            this.btn_ZF.Name = "btn_ZF";
            this.btn_ZF.Size = new System.Drawing.Size(23, 20);
            this.btn_ZF.TabIndex = 54;
            this.btn_ZF.UseVisualStyleBackColor = true;
            this.btn_ZF.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_EPSU
            // 
            this.btn_EPSU.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_EPSU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_EPSU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EPSU.Location = new System.Drawing.Point(354, 148);
            this.btn_EPSU.Name = "btn_EPSU";
            this.btn_EPSU.Size = new System.Drawing.Size(23, 20);
            this.btn_EPSU.TabIndex = 53;
            this.btn_EPSU.UseVisualStyleBackColor = true;
            this.btn_EPSU.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_FC
            // 
            this.btn_FC.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_FC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FC.Location = new System.Drawing.Point(354, 38);
            this.btn_FC.Name = "btn_FC";
            this.btn_FC.Size = new System.Drawing.Size(23, 20);
            this.btn_FC.TabIndex = 52;
            this.btn_FC.UseVisualStyleBackColor = true;
            this.btn_FC.Click += new System.EventHandler(this.btn_setRange);
            // 
            // Edit_Concrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_23);
            this.Name = "Edit_Concrete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Concrete properties";
            this.Load += new System.EventHandler(this.Add_Concrete_Load);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox ZF;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox EPSU;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox FC;
        private System.Windows.Forms.TextBox EC;
        private System.Windows.Forms.TextBox EPS0;
        private System.Windows.Forms.TextBox FT;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.BindingSource databaseDataSetBindingSource;
        private DatabaseDataSet databaseDataSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_FT;
        private System.Windows.Forms.Button btn_EPS0;
        private System.Windows.Forms.Button btn_EC;
        private System.Windows.Forms.Button btn_ZF;
        private System.Windows.Forms.Button btn_EPSU;
        private System.Windows.Forms.Button btn_FC;
    }
}