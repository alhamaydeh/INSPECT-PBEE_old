namespace SampleWizard
{
    partial class RunState
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_status = new System.Windows.Forms.Panel();
            this.lb_time = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.txt_scale_factor = new System.Windows.Forms.TextBox();
            this.txt_hfile = new System.Windows.Forms.TextBox();
            this.txt_vfile = new System.Windows.Forms.TextBox();
            this.contextMenuWaiting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRunning = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPassFail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_status.SuspendLayout();
            this.contextMenuWaiting.SuspendLayout();
            this.contextMenuRunning.SuspendLayout();
            this.contextMenuPassFail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale Factor : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "H File : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "V File : ";
            // 
            // pnl_status
            // 
            this.pnl_status.BackColor = System.Drawing.Color.SlateGray;
            this.pnl_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_status.Controls.Add(this.lb_time);
            this.pnl_status.Controls.Add(this.lb_status);
            this.pnl_status.Location = new System.Drawing.Point(5, 68);
            this.pnl_status.Name = "pnl_status";
            this.pnl_status.Size = new System.Drawing.Size(141, 49);
            this.pnl_status.TabIndex = 3;
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Location = new System.Drawing.Point(3, 30);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(0, 13);
            this.lb_time.TabIndex = 1;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(21, 15);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(55, 13);
            this.lb_status.TabIndex = 0;
            this.lb_status.Text = "Waiting ...";
            // 
            // txt_scale_factor
            // 
            this.txt_scale_factor.Enabled = false;
            this.txt_scale_factor.Location = new System.Drawing.Point(78, 4);
            this.txt_scale_factor.Name = "txt_scale_factor";
            this.txt_scale_factor.Size = new System.Drawing.Size(68, 20);
            this.txt_scale_factor.TabIndex = 4;
            // 
            // txt_hfile
            // 
            this.txt_hfile.Enabled = false;
            this.txt_hfile.Location = new System.Drawing.Point(43, 25);
            this.txt_hfile.Name = "txt_hfile";
            this.txt_hfile.Size = new System.Drawing.Size(103, 20);
            this.txt_hfile.TabIndex = 5;
            // 
            // txt_vfile
            // 
            this.txt_vfile.Enabled = false;
            this.txt_vfile.Location = new System.Drawing.Point(43, 46);
            this.txt_vfile.Name = "txt_vfile";
            this.txt_vfile.Size = new System.Drawing.Size(103, 20);
            this.txt_vfile.TabIndex = 6;
            // 
            // contextMenuWaiting
            // 
            this.contextMenuWaiting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.startToolStripMenuItem});
            this.contextMenuWaiting.Name = "contextMenuWaiting";
            this.contextMenuWaiting.Size = new System.Drawing.Size(140, 48);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // contextMenuRunning
            // 
            this.contextMenuRunning.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopToolStripMenuItem});
            this.contextMenuRunning.Name = "contextMenuRunning";
            this.contextMenuRunning.Size = new System.Drawing.Size(99, 26);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // contextMenuPassFail
            // 
            this.contextMenuPassFail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem1,
            this.restartToolStripMenuItem});
            this.contextMenuPassFail.Name = "contextMenuPassFail";
            this.contextMenuPassFail.Size = new System.Drawing.Size(153, 70);
            // 
            // openFolderToolStripMenuItem1
            // 
            this.openFolderToolStripMenuItem1.Name = "openFolderToolStripMenuItem1";
            this.openFolderToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.openFolderToolStripMenuItem1.Text = "Open Folder";
            this.openFolderToolStripMenuItem1.Click += new System.EventHandler(this.openFolderToolStripMenuItem1_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // RunState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuWaiting;
            this.Controls.Add(this.txt_vfile);
            this.Controls.Add(this.txt_hfile);
            this.Controls.Add(this.txt_scale_factor);
            this.Controls.Add(this.pnl_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RunState";
            this.Size = new System.Drawing.Size(151, 121);
            this.Load += new System.EventHandler(this.RunState_Load);
            this.pnl_status.ResumeLayout(false);
            this.pnl_status.PerformLayout();
            this.contextMenuWaiting.ResumeLayout(false);
            this.contextMenuRunning.ResumeLayout(false);
            this.contextMenuPassFail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_status;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.TextBox txt_scale_factor;
        private System.Windows.Forms.TextBox txt_hfile;
        private System.Windows.Forms.TextBox txt_vfile;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.ContextMenuStrip contextMenuWaiting;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuRunning;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuPassFail;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}
