using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace SampleWizard
{
    public partial class RunState : UserControl
    {
        private RunningState state = RunningState.Waiting;
        int i, j;
        public RunState(int i,int j,RunningState state)
        {
            this.i = i;
            this.j = j;
            InitializeComponent();
            txt_scale_factor.Text = "" + ExecutionState.Scales[i, j] ;
            txt_hfile.Text = ExecutionState.HFiles[i, j];
            txt_vfile.Text = ExecutionState.VFiles[i,j] != null ? ExecutionState.VFiles[i,j] : "None";
            changeState(state);
        }
        public RunningState getState()
        {
            return state;
        }
        public void setTime(TimeSpan dt)
        {
            lb_time.Text = dt.ToString(@"hh\:mm\:ss");
        }
        public void changeState(RunningState newState)
        {
            if (newState.Equals(state))
                return;
            switch(newState)
            {
                case RunningState.Waiting:
                    lb_status.Text = "Waiting";
                    pnl_status.BackColor = Color.SlateGray;
                    this.ContextMenuStrip = contextMenuWaiting;
                    break;
                case RunningState.Running:
                    lb_status.Text = "Running";
                    pnl_status.BackColor = Color.Salmon;
                    this.ContextMenuStrip = contextMenuRunning;
                    break;
                case RunningState.Success:
                    lb_status.Text = "Success";
                    pnl_status.BackColor = Color.Green;
                    this.ContextMenuStrip = contextMenuPassFail;
                    break;
                case RunningState.Fail:
                    lb_status.Text = "Fail";
                    pnl_status.BackColor = Color.Red;
                    this.ContextMenuStrip = contextMenuPassFail;
                    break;
                case RunningState.ForceFailed:
                    lb_status.Text = "Force Failed";
                    pnl_status.BackColor = Color.Firebrick;
                    this.ContextMenuStrip = contextMenuPassFail;
                    break;
            }
            state = newState;
        }

        private void RunState_Load(object sender, EventArgs e)
        {

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutionState.Process[i, j].Kill();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error while stoppig process");
            }
        }
        void runProcess(object input)
        {
            RunningThreadInput t = (RunningThreadInput)input;
            int i = t.i;
            int j = t.j;
            ProcessStartInfo startInfo = new ProcessStartInfo(ExecutionState.Paths[i, j] + @"\idarc2d_7.0.exe");
            startInfo.WorkingDirectory = ExecutionState.Paths[i, j];
            // startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            // startInfo.UseShellExecute = false;

            //  startInfo.FileName = fullPath;
            // startInfo.Arguments = args;
            //startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            Process p = new Process();
            p.StartInfo = startInfo;
            ExecutionState.Process[i, j] = p;
            ExecutionState.StartingTimes[i, j] = DateTime.Now;
            ExecutionState.EndingTimes[i, j] = DateTime.MaxValue;
            p.Start();
            p.WaitForExit();
            ExecutionState.EndingTimes[i, j] = DateTime.Now;
        }
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ExecutionState.Paths[i, j]);
        }

        private void openFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(ExecutionState.Paths[i, j]);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!ExecutionState.OK)
            {
                MessageBox.Show("You should resume execution first !");
                return;
            }
            Thread thread = new Thread(runProcess);
            thread.IsBackground = true;
            thread.Start(new RunningThreadInput(i, j));
            Action DoChangeState = () =>
            {
                this.changeState(RunningState.Running);
            };
            try
            {
                this.Invoke(DoChangeState);
            }
            catch { }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ExecutionState.OK)
            {
                MessageBox.Show("You should resume execution first !");
                return;
            }
            Action DoChangeState = () =>
            {
                this.changeState(RunningState.Waiting);
            };
            try
            {
                this.Invoke(DoChangeState);
            }
            catch { }
            startToolStripMenuItem_Click(sender, e);
        }

    }
    public enum RunningState{
        Waiting, 
        Running,
        Success,
        Fail,
        ForceFailed
    }

}
