namespace SampleWizard
{
    partial class PostProcessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostProcessor));
            this.NSO_post = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.radioButtonYN1 = new SampleWizard.RadioButtonYN();
            this.units_post = new SampleWizard.RadioButtonYN();
            this.label29 = new System.Windows.Forms.Label();
            this.h_post = new System.Windows.Forms.TextBox();
            this.btn_batch_example = new System.Windows.Forms.Button();
            this.txt_batch_template = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.button35 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.load_input = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDARC2DManualToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iDARCLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNSPECTLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acknowledgementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_plots = new System.Windows.Forms.Button();
            this.chb_isFEMA = new SampleWizard.RadioButtonYN();
            this.radioButtonYN2 = new SampleWizard.RadioButtonYN();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox18.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NSO_post
            // 
            this.NSO_post.Location = new System.Drawing.Point(166, 172);
            this.NSO_post.Name = "NSO_post";
            this.NSO_post.Size = new System.Drawing.Size(100, 20);
            this.NSO_post.TabIndex = 106;
            this.NSO_post.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(24, 175);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 13);
            this.label28.TabIndex = 105;
            this.label28.Text = "Number of Stories : ";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.radioButtonYN1);
            this.groupBox18.Controls.Add(this.units_post);
            this.groupBox18.Location = new System.Drawing.Point(33, 210);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(165, 61);
            this.groupBox18.TabIndex = 109;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "System of units:";
            // 
            // radioButtonYN1
            // 
            this.radioButtonYN1.AutoSize = true;
            this.radioButtonYN1.Location = new System.Drawing.Point(88, 31);
            this.radioButtonYN1.Name = "radioButtonYN1";
            this.radioButtonYN1.Size = new System.Drawing.Size(61, 17);
            this.radioButtonYN1.TabIndex = 22;
            this.radioButtonYN1.Text = "mm, kN";
            this.radioButtonYN1.UseVisualStyleBackColor = true;
            this.radioButtonYN1.YesNo = "0";
            // 
            // units_post
            // 
            this.units_post.AutoSize = true;
            this.units_post.Checked = true;
            this.units_post.Location = new System.Drawing.Point(6, 31);
            this.units_post.Name = "units_post";
            this.units_post.Size = new System.Drawing.Size(70, 17);
            this.units_post.TabIndex = 20;
            this.units_post.TabStop = true;
            this.units_post.Text = "inch, kips";
            this.units_post.UseVisualStyleBackColor = true;
            this.units_post.YesNo = "1";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(30, 294);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 13);
            this.label29.TabIndex = 108;
            this.label29.Text = "Total Elevation";
            // 
            // h_post
            // 
            this.h_post.Location = new System.Drawing.Point(166, 287);
            this.h_post.Name = "h_post";
            this.h_post.Size = new System.Drawing.Size(100, 20);
            this.h_post.TabIndex = 107;
            this.h_post.Text = "0";
            // 
            // btn_batch_example
            // 
            this.btn_batch_example.Location = new System.Drawing.Point(27, 121);
            this.btn_batch_example.Name = "btn_batch_example";
            this.btn_batch_example.Size = new System.Drawing.Size(257, 23);
            this.btn_batch_example.TabIndex = 104;
            this.btn_batch_example.Text = "It\'s Complicated :( show me an example :)";
            this.btn_batch_example.UseVisualStyleBackColor = true;
            this.btn_batch_example.Click += new System.EventHandler(this.btn_batch_example_Click);
            // 
            // txt_batch_template
            // 
            this.txt_batch_template.Location = new System.Drawing.Point(27, 94);
            this.txt_batch_template.Name = "txt_batch_template";
            this.txt_batch_template.ReadOnly = true;
            this.txt_batch_template.Size = new System.Drawing.Size(193, 20);
            this.txt_batch_template.TabIndex = 103;
            this.txt_batch_template.Text = "[BATCH_TEMPLATE]";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(24, 38);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(260, 39);
            this.label27.TabIndex = 102;
            this.label27.Text = "Please replace Dynamic Analysis Control Parameters ,\r\nInput Wave information,  an" +
    "d Wave files list  with the \r\nFollowing Template Line : ";
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(330, 25);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(110, 38);
            this.button35.TabIndex = 101;
            this.button35.Text = "Load input file";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(27, 441);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(216, 40);
            this.button34.TabIndex = 99;
            this.button34.Text = "Run";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button33
            // 
            this.button33.Enabled = false;
            this.button33.Location = new System.Drawing.Point(27, 390);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(216, 40);
            this.button33.TabIndex = 98;
            this.button33.Text = "FEMA Options";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(27, 339);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(216, 40);
            this.button29.TabIndex = 97;
            this.button29.Text = "Batch Mode Options";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // load_input
            // 
            this.load_input.Location = new System.Drawing.Point(330, 69);
            this.load_input.Name = "load_input";
            this.load_input.Size = new System.Drawing.Size(366, 398);
            this.load_input.TabIndex = 96;
            this.load_input.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 110;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.savePlotToolStripMenuItem,
            this.openPlotToolStripMenuItem,
            this.exportOutputFolderToolStripMenuItem,
            this.cleanWorkspaceToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // savePlotToolStripMenuItem
            // 
            this.savePlotToolStripMenuItem.Name = "savePlotToolStripMenuItem";
            this.savePlotToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.savePlotToolStripMenuItem.Text = "Save Plot";
            this.savePlotToolStripMenuItem.Click += new System.EventHandler(this.savePlotToolStripMenuItem_Click);
            // 
            // openPlotToolStripMenuItem
            // 
            this.openPlotToolStripMenuItem.Name = "openPlotToolStripMenuItem";
            this.openPlotToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openPlotToolStripMenuItem.Text = "Open Plot";
            this.openPlotToolStripMenuItem.Click += new System.EventHandler(this.openPlotToolStripMenuItem_Click);
            // 
            // exportOutputFolderToolStripMenuItem
            // 
            this.exportOutputFolderToolStripMenuItem.Name = "exportOutputFolderToolStripMenuItem";
            this.exportOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportOutputFolderToolStripMenuItem.Text = "Export Output folder";
            this.exportOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.exportOutputFolderToolStripMenuItem_Click);
            // 
            // cleanWorkspaceToolStripMenuItem
            // 
            this.cleanWorkspaceToolStripMenuItem.Name = "cleanWorkspaceToolStripMenuItem";
            this.cleanWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cleanWorkspaceToolStripMenuItem.Text = "Clean Workspace";
            this.cleanWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.cleanWorkspaceToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDARC2DManualToolStripMenuItem1,
            this.iDARCLicenseToolStripMenuItem,
            this.iNSPECTLicenseToolStripMenuItem,
            this.acknowledgementsToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // iDARC2DManualToolStripMenuItem1
            // 
            this.iDARC2DManualToolStripMenuItem1.Name = "iDARC2DManualToolStripMenuItem1";
            this.iDARC2DManualToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.iDARC2DManualToolStripMenuItem1.Text = "IDARC2D Manual";
            this.iDARC2DManualToolStripMenuItem1.Click += new System.EventHandler(this.iDARC2DManualToolStripMenuItem1_Click);
            // 
            // iDARCLicenseToolStripMenuItem
            // 
            this.iDARCLicenseToolStripMenuItem.Name = "iDARCLicenseToolStripMenuItem";
            this.iDARCLicenseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.iDARCLicenseToolStripMenuItem.Text = "IDARC License ";
            this.iDARCLicenseToolStripMenuItem.Click += new System.EventHandler(this.iDARCLicenseToolStripMenuItem_Click);
            // 
            // iNSPECTLicenseToolStripMenuItem
            // 
            this.iNSPECTLicenseToolStripMenuItem.Name = "iNSPECTLicenseToolStripMenuItem";
            this.iNSPECTLicenseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.iNSPECTLicenseToolStripMenuItem.Text = "INSPECT License";
            this.iNSPECTLicenseToolStripMenuItem.Click += new System.EventHandler(this.iNSPECTLicenseToolStripMenuItem_Click);
            // 
            // acknowledgementsToolStripMenuItem
            // 
            this.acknowledgementsToolStripMenuItem.Name = "acknowledgementsToolStripMenuItem";
            this.acknowledgementsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.acknowledgementsToolStripMenuItem.Text = "Acknowledgements";
            this.acknowledgementsToolStripMenuItem.Click += new System.EventHandler(this.acknowledgementsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // btn_plots
            // 
            this.btn_plots.Location = new System.Drawing.Point(27, 487);
            this.btn_plots.Name = "btn_plots";
            this.btn_plots.Size = new System.Drawing.Size(216, 40);
            this.btn_plots.TabIndex = 111;
            this.btn_plots.Text = "Show Plots";
            this.btn_plots.UseVisualStyleBackColor = true;
            this.btn_plots.Click += new System.EventHandler(this.btn_plots_Click);
            // 
            // chb_isFEMA
            // 
            this.chb_isFEMA.AutoSize = true;
            this.chb_isFEMA.Location = new System.Drawing.Point(12, 402);
            this.chb_isFEMA.Name = "chb_isFEMA";
            this.chb_isFEMA.Size = new System.Drawing.Size(14, 13);
            this.chb_isFEMA.TabIndex = 112;
            this.chb_isFEMA.TabStop = true;
            this.chb_isFEMA.UseVisualStyleBackColor = true;
            this.chb_isFEMA.YesNo = "0";
            this.chb_isFEMA.CheckedChanged += new System.EventHandler(this.chb_isFEMA_CheckedChanged);
            // 
            // radioButtonYN2
            // 
            this.radioButtonYN2.AutoSize = true;
            this.radioButtonYN2.Checked = true;
            this.radioButtonYN2.Location = new System.Drawing.Point(12, 351);
            this.radioButtonYN2.Name = "radioButtonYN2";
            this.radioButtonYN2.Size = new System.Drawing.Size(14, 13);
            this.radioButtonYN2.TabIndex = 113;
            this.radioButtonYN2.TabStop = true;
            this.radioButtonYN2.UseVisualStyleBackColor = true;
            this.radioButtonYN2.YesNo = "1";
            this.radioButtonYN2.CheckedChanged += new System.EventHandler(this.radioButtonYN2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 533);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 40);
            this.button1.TabIndex = 114;
            this.button1.Text = "Save Plots";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PostProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 574);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButtonYN2);
            this.Controls.Add(this.chb_isFEMA);
            this.Controls.Add(this.btn_plots);
            this.Controls.Add(this.NSO_post);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.h_post);
            this.Controls.Add(this.btn_batch_example);
            this.Controls.Add(this.txt_batch_template);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.load_input);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PostProcessor";
            this.Text = "INSPECT-PBEE    PostProcessor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostProcessor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PostProcessor_FormClosed);
            this.Load += new System.EventHandler(this.PostProcessor_Load_1);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox NSO_post;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox18;
        private RadioButtonYN radioButtonYN1;
        public RadioButtonYN units_post;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox h_post;
        private System.Windows.Forms.Button btn_batch_example;
        private System.Windows.Forms.TextBox txt_batch_template;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.RichTextBox load_input;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOutputFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btn_plots;
        private RadioButtonYN chb_isFEMA;
        private RadioButtonYN radioButtonYN2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDARC2DManualToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iDARCLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNSPECTLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acknowledgementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem savePlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlotToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}