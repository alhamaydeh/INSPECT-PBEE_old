namespace SampleWizard
{
    partial class WaveFileChangerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaveFileChangerList));
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_deltaT = new System.Windows.Forms.TextBox();
            this.rdb_values = new System.Windows.Forms.RadioButton();
            this.rdb_time_value = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_txt_deltaT = new System.Windows.Forms.Button();
            this.btn_rdb_values = new System.Windows.Forms.Button();
            this.nud_points_per_line = new System.Windows.Forms.NumericUpDown();
            this.nud_prefix = new System.Windows.Forms.NumericUpDown();
            this.nud_lines_to_skip = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_nud_points_per_line = new System.Windows.Forms.Button();
            this.btn_nud_prefix = new System.Windows.Forms.Button();
            this.btn_nud_lines_to_skip = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_file_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button_23 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lb_count = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_points_per_line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_prefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_lines_to_skip)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 19);
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
            this.chart1.Location = new System.Drawing.Point(27, 18);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(384, 160);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.chart1);
            this.groupBox5.Location = new System.Drawing.Point(12, 294);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(504, 185);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Graph";
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(9, 14);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_text.Size = new System.Drawing.Size(254, 202);
            this.txt_text.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_text);
            this.groupBox4.Location = new System.Drawing.Point(292, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 222);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File Content";
            // 
            // txt_deltaT
            // 
            this.txt_deltaT.Location = new System.Drawing.Point(171, 42);
            this.txt_deltaT.Name = "txt_deltaT";
            this.txt_deltaT.Size = new System.Drawing.Size(52, 20);
            this.txt_deltaT.TabIndex = 6;
            // 
            // rdb_values
            // 
            this.rdb_values.AutoSize = true;
            this.rdb_values.Location = new System.Drawing.Point(10, 43);
            this.rdb_values.Name = "rdb_values";
            this.rdb_values.Size = new System.Drawing.Size(155, 17);
            this.rdb_values.TabIndex = 1;
            this.rdb_values.TabStop = true;
            this.rdb_values.Text = "Values at equal intervals of ";
            this.rdb_values.UseVisualStyleBackColor = true;
            // 
            // rdb_time_value
            // 
            this.rdb_time_value.AutoSize = true;
            this.rdb_time_value.Location = new System.Drawing.Point(10, 19);
            this.rdb_time_value.Name = "rdb_time_value";
            this.rdb_time_value.Size = new System.Drawing.Size(222, 17);
            this.rdb_time_value.TabIndex = 0;
            this.rdb_time_value.TabStop = true;
            this.rdb_time_value.Text = "Time and Values ( Equal spaced samples)";
            this.rdb_time_value.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_txt_deltaT);
            this.groupBox3.Controls.Add(this.btn_rdb_values);
            this.groupBox3.Controls.Add(this.txt_deltaT);
            this.groupBox3.Controls.Add(this.rdb_values);
            this.groupBox3.Controls.Add(this.rdb_time_value);
            this.groupBox3.Location = new System.Drawing.Point(13, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 77);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Values are";
            // 
            // btn_txt_deltaT
            // 
            this.btn_txt_deltaT.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_txt_deltaT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_txt_deltaT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_txt_deltaT.Location = new System.Drawing.Point(232, 45);
            this.btn_txt_deltaT.Name = "btn_txt_deltaT";
            this.btn_txt_deltaT.Size = new System.Drawing.Size(23, 20);
            this.btn_txt_deltaT.TabIndex = 49;
            this.btn_txt_deltaT.UseVisualStyleBackColor = true;
            this.btn_txt_deltaT.Click += new System.EventHandler(this.btn_txt_deltaT_Click);
            // 
            // btn_rdb_values
            // 
            this.btn_rdb_values.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_rdb_values.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_rdb_values.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_rdb_values.Location = new System.Drawing.Point(232, 19);
            this.btn_rdb_values.Name = "btn_rdb_values";
            this.btn_rdb_values.Size = new System.Drawing.Size(23, 20);
            this.btn_rdb_values.TabIndex = 48;
            this.btn_rdb_values.UseVisualStyleBackColor = true;
            this.btn_rdb_values.Click += new System.EventHandler(this.btn_rdb_values_Click);
            // 
            // nud_points_per_line
            // 
            this.nud_points_per_line.Location = new System.Drawing.Point(179, 96);
            this.nud_points_per_line.Name = "nud_points_per_line";
            this.nud_points_per_line.Size = new System.Drawing.Size(47, 20);
            this.nud_points_per_line.TabIndex = 8;
            // 
            // nud_prefix
            // 
            this.nud_prefix.Location = new System.Drawing.Point(179, 62);
            this.nud_prefix.Name = "nud_prefix";
            this.nud_prefix.Size = new System.Drawing.Size(47, 20);
            this.nud_prefix.TabIndex = 7;
            // 
            // nud_lines_to_skip
            // 
            this.nud_lines_to_skip.Location = new System.Drawing.Point(179, 28);
            this.nud_lines_to_skip.Name = "nud_lines_to_skip";
            this.nud_lines_to_skip.Size = new System.Drawing.Size(47, 20);
            this.nud_lines_to_skip.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Number of points per line :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prefix Characters per line to skip:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_nud_points_per_line);
            this.groupBox2.Controls.Add(this.btn_nud_prefix);
            this.groupBox2.Controls.Add(this.btn_nud_lines_to_skip);
            this.groupBox2.Controls.Add(this.nud_points_per_line);
            this.groupBox2.Controls.Add(this.nud_prefix);
            this.groupBox2.Controls.Add(this.nud_lines_to_skip);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 138);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Format";
            // 
            // btn_nud_points_per_line
            // 
            this.btn_nud_points_per_line.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_nud_points_per_line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_nud_points_per_line.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_nud_points_per_line.Location = new System.Drawing.Point(232, 96);
            this.btn_nud_points_per_line.Name = "btn_nud_points_per_line";
            this.btn_nud_points_per_line.Size = new System.Drawing.Size(23, 20);
            this.btn_nud_points_per_line.TabIndex = 47;
            this.btn_nud_points_per_line.UseVisualStyleBackColor = true;
            this.btn_nud_points_per_line.Click += new System.EventHandler(this.btn_nud_points_per_line_Click);
            // 
            // btn_nud_prefix
            // 
            this.btn_nud_prefix.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_nud_prefix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_nud_prefix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_nud_prefix.Location = new System.Drawing.Point(232, 62);
            this.btn_nud_prefix.Name = "btn_nud_prefix";
            this.btn_nud_prefix.Size = new System.Drawing.Size(23, 20);
            this.btn_nud_prefix.TabIndex = 46;
            this.btn_nud_prefix.UseVisualStyleBackColor = true;
            this.btn_nud_prefix.Click += new System.EventHandler(this.btn_nud_prefix_Click);
            // 
            // btn_nud_lines_to_skip
            // 
            this.btn_nud_lines_to_skip.BackgroundImage = global::SampleWizard.Properties.Resources.stock_vector_file_icons_granite_series_simple_glyph_stile_icons_in_versions_the_icons_are_designed_at_x_216342223;
            this.btn_nud_lines_to_skip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_nud_lines_to_skip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_nud_lines_to_skip.Location = new System.Drawing.Point(232, 28);
            this.btn_nud_lines_to_skip.Name = "btn_nud_lines_to_skip";
            this.btn_nud_lines_to_skip.Size = new System.Drawing.Size(23, 20);
            this.btn_nud_lines_to_skip.TabIndex = 45;
            this.btn_nud_lines_to_skip.UseVisualStyleBackColor = true;
            this.btn_nud_lines_to_skip.Click += new System.EventHandler(this.btn_nud_lines_to_skip_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Header Lines to Skip :";
            // 
            // txt_file_name
            // 
            this.txt_file_name.Location = new System.Drawing.Point(77, 16);
            this.txt_file_name.Name = "txt_file_name";
            this.txt_file_name.ReadOnly = true;
            this.txt_file_name.Size = new System.Drawing.Size(472, 20);
            this.txt_file_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_file_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 50);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Image = global::SampleWizard.Properties.Resources.Exit;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(292, 492);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 28);
            this.button2.TabIndex = 38;
            this.button2.Text = "         Close ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_23
            // 
            this.button_23.Image = global::SampleWizard.Properties.Resources.Next;
            this.button_23.Location = new System.Drawing.Point(395, 492);
            this.button_23.Name = "button_23";
            this.button_23.Size = new System.Drawing.Size(111, 28);
            this.button_23.TabIndex = 36;
            this.button_23.Text = "Next";
            this.button_23.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_23.UseVisualStyleBackColor = true;
            this.button_23.Click += new System.EventHandler(this.button_23_Click);
            // 
            // button4
            // 
            this.button4.Image = global::SampleWizard.Properties.Resources.Previous;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(14, 492);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 28);
            this.button4.TabIndex = 37;
            this.button4.Text = "         Previous";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(159, 500);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(35, 13);
            this.lb_count.TabIndex = 39;
            this.lb_count.Text = "label5";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // WaveFileChangerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 531);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_23);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WaveFileChangerList";
            this.Text = "WaveFileChangerList";
            this.Load += new System.EventHandler(this.WaveFileChangerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_points_per_line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_prefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_lines_to_skip)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_23;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_deltaT;
        private System.Windows.Forms.RadioButton rdb_values;
        private System.Windows.Forms.RadioButton rdb_time_value;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nud_points_per_line;
        private System.Windows.Forms.NumericUpDown nud_prefix;
        private System.Windows.Forms.NumericUpDown nud_lines_to_skip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_file_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.Button btn_txt_deltaT;
        private System.Windows.Forms.Button btn_rdb_values;
        private System.Windows.Forms.Button btn_nud_points_per_line;
        private System.Windows.Forms.Button btn_nud_prefix;
        private System.Windows.Forms.Button btn_nud_lines_to_skip;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}