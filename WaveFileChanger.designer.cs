namespace SampleWizard
{
    partial class WaveFileChanger
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaveFileChanger));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_file_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_txt_points_per_line = new System.Windows.Forms.Button();
            this.btn_txt_prefix = new System.Windows.Forms.Button();
            this.btn_txt_lines_to_skip = new System.Windows.Forms.Button();
            this.txt_points_per_line = new System.Windows.Forms.NumericUpDown();
            this.txt_prefix = new System.Windows.Forms.NumericUpDown();
            this.txt_lines_to_skip = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_txt_deltaT = new System.Windows.Forms.Button();
            this.btn_rdb_values = new System.Windows.Forms.Button();
            this.txt_deltaT = new System.Windows.Forms.TextBox();
            this.rdb_values = new System.Windows.Forms.RadioButton();
            this.rdb_time_value = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_points_per_line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_prefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lines_to_skip)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_file_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txt_file_name
            // 
            this.txt_file_name.Location = new System.Drawing.Point(67, 17);
            this.txt_file_name.Name = "txt_file_name";
            this.txt_file_name.ReadOnly = true;
            this.txt_file_name.Size = new System.Drawing.Size(445, 20);
            this.txt_file_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_txt_points_per_line);
            this.groupBox2.Controls.Add(this.btn_txt_prefix);
            this.groupBox2.Controls.Add(this.btn_txt_lines_to_skip);
            this.groupBox2.Controls.Add(this.txt_points_per_line);
            this.groupBox2.Controls.Add(this.txt_prefix);
            this.groupBox2.Controls.Add(this.txt_lines_to_skip);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Format";
            // 
            // btn_txt_points_per_line
            // 
            this.btn_txt_points_per_line.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_txt_points_per_line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_txt_points_per_line.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_txt_points_per_line.Location = new System.Drawing.Point(226, 99);
            this.btn_txt_points_per_line.Name = "btn_txt_points_per_line";
            this.btn_txt_points_per_line.Size = new System.Drawing.Size(23, 20);
            this.btn_txt_points_per_line.TabIndex = 47;
            this.btn_txt_points_per_line.UseVisualStyleBackColor = true;
            this.btn_txt_points_per_line.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_txt_prefix
            // 
            this.btn_txt_prefix.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_txt_prefix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_txt_prefix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_txt_prefix.Location = new System.Drawing.Point(226, 65);
            this.btn_txt_prefix.Name = "btn_txt_prefix";
            this.btn_txt_prefix.Size = new System.Drawing.Size(23, 20);
            this.btn_txt_prefix.TabIndex = 46;
            this.btn_txt_prefix.UseVisualStyleBackColor = true;
            this.btn_txt_prefix.Click += new System.EventHandler(this.btn_setRange);
            // 
            // btn_txt_lines_to_skip
            // 
            this.btn_txt_lines_to_skip.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_txt_lines_to_skip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_txt_lines_to_skip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_txt_lines_to_skip.Location = new System.Drawing.Point(226, 29);
            this.btn_txt_lines_to_skip.Name = "btn_txt_lines_to_skip";
            this.btn_txt_lines_to_skip.Size = new System.Drawing.Size(23, 20);
            this.btn_txt_lines_to_skip.TabIndex = 44;
            this.btn_txt_lines_to_skip.UseVisualStyleBackColor = true;
            this.btn_txt_lines_to_skip.Click += new System.EventHandler(this.btn_setRange);
            // 
            // txt_points_per_line
            // 
            this.txt_points_per_line.Location = new System.Drawing.Point(173, 97);
            this.txt_points_per_line.Name = "txt_points_per_line";
            this.txt_points_per_line.Size = new System.Drawing.Size(47, 20);
            this.txt_points_per_line.TabIndex = 8;
            // 
            // txt_prefix
            // 
            this.txt_prefix.Location = new System.Drawing.Point(173, 63);
            this.txt_prefix.Name = "txt_prefix";
            this.txt_prefix.Size = new System.Drawing.Size(47, 20);
            this.txt_prefix.TabIndex = 7;
            // 
            // txt_lines_to_skip
            // 
            this.txt_lines_to_skip.Location = new System.Drawing.Point(173, 29);
            this.txt_lines_to_skip.Name = "txt_lines_to_skip";
            this.txt_lines_to_skip.Size = new System.Drawing.Size(47, 20);
            this.txt_lines_to_skip.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Number of points per line :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prefix Characters per line to skip:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Header Lines to Skip :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_txt_deltaT);
            this.groupBox3.Controls.Add(this.btn_rdb_values);
            this.groupBox3.Controls.Add(this.txt_deltaT);
            this.groupBox3.Controls.Add(this.rdb_values);
            this.groupBox3.Controls.Add(this.rdb_time_value);
            this.groupBox3.Location = new System.Drawing.Point(13, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 77);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Values are";
            // 
            // btn_txt_deltaT
            // 
            this.btn_txt_deltaT.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_txt_deltaT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_txt_deltaT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_txt_deltaT.Location = new System.Drawing.Point(239, 44);
            this.btn_txt_deltaT.Name = "btn_txt_deltaT";
            this.btn_txt_deltaT.Size = new System.Drawing.Size(23, 20);
            this.btn_txt_deltaT.TabIndex = 46;
            this.btn_txt_deltaT.UseVisualStyleBackColor = true;
            this.btn_txt_deltaT.Click += new System.EventHandler(this.btn_txt_deltaT_Click);
            // 
            // btn_rdb_values
            // 
            this.btn_rdb_values.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_rdb_values.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_rdb_values.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_rdb_values.Location = new System.Drawing.Point(239, 17);
            this.btn_rdb_values.Name = "btn_rdb_values";
            this.btn_rdb_values.Size = new System.Drawing.Size(23, 20);
            this.btn_rdb_values.TabIndex = 45;
            this.btn_rdb_values.UseVisualStyleBackColor = true;
            this.btn_rdb_values.Click += new System.EventHandler(this.btn_rdb_values_Click);
            // 
            // txt_deltaT
            // 
            this.txt_deltaT.Location = new System.Drawing.Point(173, 43);
            this.txt_deltaT.Name = "txt_deltaT";
            this.txt_deltaT.Size = new System.Drawing.Size(52, 20);
            this.txt_deltaT.TabIndex = 6;
            this.txt_deltaT.TextChanged += new System.EventHandler(this.txt_deltaT_TextChanged);
            // 
            // rdb_values
            // 
            this.rdb_values.AutoSize = true;
            this.rdb_values.Checked = true;
            this.rdb_values.Location = new System.Drawing.Point(12, 44);
            this.rdb_values.Name = "rdb_values";
            this.rdb_values.Size = new System.Drawing.Size(155, 17);
            this.rdb_values.TabIndex = 1;
            this.rdb_values.TabStop = true;
            this.rdb_values.Text = "Values at equal intervals of ";
            this.rdb_values.UseVisualStyleBackColor = true;
            this.rdb_values.CheckedChanged += new System.EventHandler(this.rdb_values_CheckedChanged);
            // 
            // rdb_time_value
            // 
            this.rdb_time_value.AutoSize = true;
            this.rdb_time_value.Location = new System.Drawing.Point(12, 20);
            this.rdb_time_value.Name = "rdb_time_value";
            this.rdb_time_value.Size = new System.Drawing.Size(222, 17);
            this.rdb_time_value.TabIndex = 0;
            this.rdb_time_value.Text = "Time and Values ( Equal spaced samples)";
            this.rdb_time_value.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_text);
            this.groupBox4.Location = new System.Drawing.Point(287, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 222);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File Content";
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(7, 14);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_text.Size = new System.Drawing.Size(230, 202);
            this.txt_text.TabIndex = 0;
            this.txt_text.TextChanged += new System.EventHandler(this.txt_text_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.chart1);
            this.groupBox5.Location = new System.Drawing.Point(12, 299);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(527, 185);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Graph";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Plot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(13, 19);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(418, 160);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button2
            // 
            this.button2.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(219, 497);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 28);
            this.button2.TabIndex = 30;
            this.button2.Text = "         Close && Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Image = global::SampleWizard.Properties.Resources.Previous;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(14, 497);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 28);
            this.button4.TabIndex = 29;
            this.button4.Text = "         Previous";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_23
            // 
            this.button_23.Image = global::SampleWizard.Properties.Resources.Next;
            this.button_23.Location = new System.Drawing.Point(428, 497);
            this.button_23.Name = "button_23";
            this.button_23.Size = new System.Drawing.Size(111, 28);
            this.button_23.TabIndex = 28;
            this.button_23.Text = "Next";
            this.button_23.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_23.UseVisualStyleBackColor = true;
            this.button_23.Click += new System.EventHandler(this.button_23_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // WaveFileChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 546);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WaveFileChanger";
            this.Text = "WaveFileChanger";
            this.Load += new System.EventHandler(this.WaveFileChanger_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_points_per_line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_prefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lines_to_skip)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_file_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_deltaT;
        private System.Windows.Forms.RadioButton rdb_values;
        private System.Windows.Forms.RadioButton rdb_time_value;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.NumericUpDown txt_points_per_line;
        private System.Windows.Forms.NumericUpDown txt_prefix;
        private System.Windows.Forms.NumericUpDown txt_lines_to_skip;
        private System.Windows.Forms.Button btn_txt_points_per_line;
        private System.Windows.Forms.Button btn_txt_prefix;
        private System.Windows.Forms.Button btn_txt_lines_to_skip;
        private System.Windows.Forms.Button btn_rdb_values;
        private System.Windows.Forms.Button btn_txt_deltaT;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}