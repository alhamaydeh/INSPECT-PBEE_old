namespace SampleWizard
{
    partial class plot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(plot));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.zedGraphControl4 = new ZedGraph.ZedGraphControl();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btn_cklt1_selectAll = new System.Windows.Forms.Button();
            this.btn_cklt1_clearAll = new System.Windows.Forms.Button();
            this.btn_cklt2_clearAll = new System.Windows.Forms.Button();
            this.btn_cklt2_selectAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(115, 159);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(349, 224);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            this.zedGraphControl1.DoubleClick += new System.EventHandler(this.zedGraphControl1_DoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(360, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(378, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(457, 150);
            this.dataGridView2.TabIndex = 3;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(486, 427);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(349, 224);
            this.zedGraphControl2.TabIndex = 4;
            this.zedGraphControl2.DoubleClick += new System.EventHandler(this.zedGraphControl2_DoubleClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Maximum Story Shear",
            "Maximum Drift Ratio",
            "Maximum Story Drift",
            "Damage Index"});
            this.comboBox1.Location = new System.Drawing.Point(115, 389);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 160);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(97, 64);
            this.checkedListBox1.TabIndex = 7;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Location = new System.Drawing.Point(486, 160);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(349, 224);
            this.zedGraphControl3.TabIndex = 19;
            this.zedGraphControl3.Load += new System.EventHandler(this.zedGraphControl3_Load);
            this.zedGraphControl3.DoubleClick += new System.EventHandler(this.zedGraphControl3_DoubleClick);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(12, 428);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(97, 64);
            this.checkedListBox2.TabIndex = 22;
            this.checkedListBox2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox2_ItemCheck);
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(115, 659);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 21;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // zedGraphControl4
            // 
            this.zedGraphControl4.Location = new System.Drawing.Point(115, 427);
            this.zedGraphControl4.Name = "zedGraphControl4";
            this.zedGraphControl4.ScrollGrace = 0D;
            this.zedGraphControl4.ScrollMaxX = 0D;
            this.zedGraphControl4.ScrollMaxY = 0D;
            this.zedGraphControl4.ScrollMaxY2 = 0D;
            this.zedGraphControl4.ScrollMinX = 0D;
            this.zedGraphControl4.ScrollMinY = 0D;
            this.zedGraphControl4.ScrollMinY2 = 0D;
            this.zedGraphControl4.Size = new System.Drawing.Size(349, 224);
            this.zedGraphControl4.TabIndex = 20;
            this.zedGraphControl4.Load += new System.EventHandler(this.zedGraphControl4_Load);
            this.zedGraphControl4.DoubleClick += new System.EventHandler(this.zedGraphControl4_DoubleClick);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(251, 659);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 23;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // btn_cklt1_selectAll
            // 
            this.btn_cklt1_selectAll.Location = new System.Drawing.Point(12, 230);
            this.btn_cklt1_selectAll.Name = "btn_cklt1_selectAll";
            this.btn_cklt1_selectAll.Size = new System.Drawing.Size(97, 23);
            this.btn_cklt1_selectAll.TabIndex = 24;
            this.btn_cklt1_selectAll.Text = "Select All";
            this.btn_cklt1_selectAll.UseVisualStyleBackColor = true;
            this.btn_cklt1_selectAll.Click += new System.EventHandler(this.btn_cklt1_selectAll_Click);
            // 
            // btn_cklt1_clearAll
            // 
            this.btn_cklt1_clearAll.Location = new System.Drawing.Point(12, 260);
            this.btn_cklt1_clearAll.Name = "btn_cklt1_clearAll";
            this.btn_cklt1_clearAll.Size = new System.Drawing.Size(97, 23);
            this.btn_cklt1_clearAll.TabIndex = 25;
            this.btn_cklt1_clearAll.Text = "Clear All";
            this.btn_cklt1_clearAll.UseVisualStyleBackColor = true;
            this.btn_cklt1_clearAll.Click += new System.EventHandler(this.btn_cklt1_clearAll_Click);
            // 
            // btn_cklt2_clearAll
            // 
            this.btn_cklt2_clearAll.Location = new System.Drawing.Point(12, 528);
            this.btn_cklt2_clearAll.Name = "btn_cklt2_clearAll";
            this.btn_cklt2_clearAll.Size = new System.Drawing.Size(97, 23);
            this.btn_cklt2_clearAll.TabIndex = 27;
            this.btn_cklt2_clearAll.Text = "Clear All";
            this.btn_cklt2_clearAll.UseVisualStyleBackColor = true;
            this.btn_cklt2_clearAll.Click += new System.EventHandler(this.btn_cklt2_clearAll_Click);
            // 
            // btn_cklt2_selectAll
            // 
            this.btn_cklt2_selectAll.Location = new System.Drawing.Point(12, 498);
            this.btn_cklt2_selectAll.Name = "btn_cklt2_selectAll";
            this.btn_cklt2_selectAll.Size = new System.Drawing.Size(97, 23);
            this.btn_cklt2_selectAll.TabIndex = 26;
            this.btn_cklt2_selectAll.Text = "Select All";
            this.btn_cklt2_selectAll.UseVisualStyleBackColor = true;
            this.btn_cklt2_selectAll.Click += new System.EventHandler(this.btn_cklt2_selectAll_Click);
            // 
            // plot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 685);
            this.Controls.Add(this.btn_cklt2_clearAll);
            this.Controls.Add(this.btn_cklt2_selectAll);
            this.Controls.Add(this.btn_cklt1_clearAll);
            this.Controls.Add(this.btn_cklt1_selectAll);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.zedGraphControl4);
            this.Controls.Add(this.zedGraphControl3);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.zedGraphControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "plot";
            this.Text = "Response Summary";
            this.Load += new System.EventHandler(this.plot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private ZedGraph.ZedGraphControl zedGraphControl4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btn_cklt1_selectAll;
        private System.Windows.Forms.Button btn_cklt1_clearAll;
        private System.Windows.Forms.Button btn_cklt2_clearAll;
        private System.Windows.Forms.Button btn_cklt2_selectAll;
    }
}