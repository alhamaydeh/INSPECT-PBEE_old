using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWizard
{
    public partial class ExecutionMonitors : Form
    {
        List<List<RunState>> states;
        results_class[, ,] results;
        int NSO;
        int waiting, running, success, fail,forceFailed;
        decimal[] factors_m;
        Thread updater_thread=null;
        int forceFail_scales;
        bool EXEC_TIMER = true;// to measure execution time, used as flag to measure the time once only; 
        DateTime startingTime;
        //bool OK = true;     
        //PerformanceCounter cpuCounter;
       // PerformanceCounter ramCounter;
       // LinkedList<float> cpuValues = new LinkedList<float>();
        double checkbox6;
        double checkbox7;
        double c6_drift;
        double c6_damage;

        public ExecutionMonitors(results_class[, ,] results,decimal[] factors_m ,int NSO, double checkbox6_, double checkbox7_, double c6_drift_, double c6_damage_)
        {
            InitializeComponent();
            this.results = results;
            this.NSO = NSO;
            this.factors_m = factors_m;

             checkbox6 = checkbox6_;
             checkbox7 = checkbox7_;
            c6_drift = c6_drift_;
            c6_damage = c6_damage_;


            waiting = running = success = fail = 0;
            ForceFailForm fm = new ForceFailForm(ExecutionState.ScalesCount);
            fm.ShowDialog();
            forceFail_scales = fm.Scales;

          //  cpuCounter = new PerformanceCounter();

            //cpuCounter.CategoryName = "Processor";
            //cpuCounter.CounterName = "% Processor Time";
            //cpuCounter.InstanceName = "_Total";

            //ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }





//public float getCurrentCpuUsage(){
//            return cpuCounter.NextValue();
//}

//public float getAvailableRAM(){
 //           return ramCounter.NextValue();
//} 
        private String[] RemoveIndices(String[] IndicesArray, int RemoveAt)
        {
            String[] newIndicesArray = new String[IndicesArray.Length - 1];

            int i = 0;
            int j = 0;
            while (i < IndicesArray.Length)
            {
                if (i != RemoveAt)
                {
                    newIndicesArray[j] = IndicesArray[i];
                    j++;
                }

                i++;
            }

            return newIndicesArray;
        }

        private void updater()
        {
            while(true)
            {
                if(!ExecutionState.OK)
                {
                 //   Thread.Sleep(1000);
                    continue;
                }
                #region  update the state of all  running processes
                for (int i=0;i<ExecutionState.ScalesCount;i++)
                {
                    for(int j=0;j<ExecutionState.FilesCount;j++)
                    {
                       // Console.WriteLine("" + i + "," + j);
                        
                        if(states[i][j].getState()== RunningState.Running)
                        {
                            // check the status of the output file and decide the action 
                            if(ExecutionState.EndingTimes[i,j]!=DateTime.MaxValue)// processes finished
                            {

                                String output = System.IO.File.ReadAllText(ExecutionState.Paths[i, j] + @"\test.out");

                                if (output.Contains("CHOLESKY DECOMPOSITION FAILED"))
                                {
                                    Action DoChangeState = () =>
                                    {
                                        states[i][j].changeState(RunningState.Fail);
                                    };
                                    this.Invoke(DoChangeState);
                                    
                                    for (int k = 0; k < NSO; k++)
                                    {
                                        results[j, i, k].not_failure = false;
                                    }
                                    //If failure, Column 12 = 1
                                    //  results[i, factor_c, 12] = 1;

                                    //if ((scale_f + batch_inc) < batch_end)
                                    //    break;//record the last SF
                                    //else
                                    //{
                                    //    results[i, factor_c, 0, 11] = scale_f;
                                    //    break;
                                    //}
                                }
                                else if (output.Contains("********** MAXIMUM RESPONSE **********"))
                                {

                                    factors_m[i]--;
                                    //List<string> out_list = new List<string>(Regex.Split(output, "\n"));
                                    int index1 = output.IndexOf("********** MAXIMUM RESPONSE **********");
                                    int index2 = output.IndexOf("********** MAXIMUM FORCES **********");
                                    if (index1 == -1 || index2 == -1)
                                        MessageBox.Show("error"); //Need edit

                                    ///////////READ Damage Index
                                    int index3 = output.IndexOf("    OVERALL STRUCTURAL DAMAGE : ");
                                    int index4 = output.IndexOf("\r\n", index3+2);
                                    int range = index4 - index3-32;
                                    //string t = "    OVERALL STRUCTURAL DAMAGE : ";
                                    string di_str = output.Substring(index3+31,range+3);
                                    //char[] damage_list = new char[index4 - index3 - 37];
                                    //output.CopyTo(index3 + 37, damage_list, 0, index4 - index3 - 38);
                                    //string temp_damage = new string(damage_list);
                                    bool status = true;
                                    bool added = false;

                                    double damage_index = 0;
                                    if (di_str.Contains("**"))
                                    {
                                        status = false;
                                        if (!added)
                                        {
                                            factors_m[i]++;
                                            added = true;

                                        }
                                        for (int k = 0; k < NSO; k++)
                                        {
                                            results[j, i, k].not_failure = false;
                                        }

                                    }
                                    else
                                    {
                                        damage_index = Convert.ToDouble(di_str);
                                        status = true;
                                        //double damge_inex= 
                                        // string[] f_list= new string[index2-index1+1];
                                        char[] f_list = new char[index2 - index1 + 1 - 6];
                                        output.CopyTo(index1, f_list, 0, index2 - index1 - 6);
                                        string temp = new string(f_list);
                                        while (temp.Contains("  "))
                                        {
                                            temp = temp.Replace("  ", " ");
                                        }
                                        while (temp.Contains("\r"))
                                        {
                                            temp = temp.Replace("\r", "");
                                        }

                                        List<string> edit_out = new List<string>(Regex.Split(temp, "\n"));
                                        //  int max_d_i = 0;
                                        for (int jj = 10; jj < 10 + NSO; jj++)
                                        {
                                            String[] temp_string = edit_out[jj].Split(' ');
                                            if (temp_string[0] == "")
                                            {
                                                temp_string = RemoveIndices(temp_string, 0);
                                            }

                                            ////
                                            bool check_error_instability = false;
                                            for (int kkk = 1; kkk <= 7; kkk++)
                                            {
                                                if (temp_string[kkk].Contains("**"))
                                                {
                                                    check_error_instability = true;
                                                    break;
                                                }
                                            }

                                            if (check_error_instability)
                                            {
                                                status = false;
                                                if (!added)
                                                {
                                                    factors_m[i]++;
                                                    added = true;

                                                }
                                                for (int k = 0; k < NSO; k++)
                                                {
                                                    results[j, i, k].not_failure = false;
                                                }

                                            }
                                            if (!check_error_instability)
                                            {


                                                status = true;
                                                /////

                                                results[j, i, jj - 10].not_failure = true;
                                                results[j, i, jj - 10].story_shear = Convert.ToDecimal(temp_string[1]);
                                                results[j, i, jj - 10].drift_ratio = Convert.ToDecimal(temp_string[2]);
                                                results[j, i, jj - 10].story_drift = Convert.ToDecimal(temp_string[3]);
                                                results[j, i, jj - 10].displacment = Convert.ToDecimal(temp_string[4]);
                                                results[j, i, jj - 10].velocity = Convert.ToDecimal(temp_string[5]);
                                                results[j, i, jj - 10].acceleration = Convert.ToDecimal(temp_string[6]);
                                                results[j, i, jj - 10].story_velocity_drift = Convert.ToDecimal(temp_string[7]);
                                                results[j, i, jj - 10].damage_index = Convert.ToDecimal(damage_index);
                                                //ssss

                                                if (checkbox6 != 0)
                                                {
                                                    if (results[j, i, jj - 10].drift_ratio > Convert.ToDecimal(c6_drift) )
                                                    {
                                                        if (!added)
                                                        {
                                                            factors_m[i]++;
                                                            added = true;

                                                        }
                                                        for (int k = 0; k < NSO; k++)
                                                        {
                                                            results[j, i, k].not_failure = false;
                                                        }
                                                        status = false;
                                                        // continue;
                                                    }
                                                }
                                                else
                                                {
                                                    if (results[j, i, jj - 10].drift_ratio > Limits.TOTAL_COLLAPSE_DRIFT_THRESHOLD)
                                                    {
                                                        if (!added)
                                                        {
                                                            factors_m[i]++;
                                                            added = true;

                                                        }
                                                        for (int k = 0; k < NSO; k++)
                                                        {
                                                            results[j, i, k].not_failure = false;
                                                        }
                                                        status = false;
                                                        // continue;
                                                    }
                                                }
                                                if (checkbox7 != 0)
                                                {
                                                    if (results[j, i, jj - 10].damage_index > Convert.ToDecimal(c6_damage))
                                                    {
                                                        if (!added)
                                                        {
                                                            factors_m[i]++;
                                                            added = true;
                                                        }
                                                        for (int k = 0; k < NSO; k++)
                                                        {
                                                            results[j, i, k].not_failure = false;
                                                        }
                                                        status = false;
                                                        // continue;
                                                    }
                                                }
                                                else
                                                {
                                                    if (results[j, i, jj - 10].damage_index > Limits.TOTAL_COLLAPSE_DAMAGE_INDEX_THRESHOLD)
                                                    {
                                                        if (!added)
                                                        {
                                                            factors_m[i]++;
                                                            added = true;
                                                        }
                                                        for (int k = 0; k < NSO; k++)
                                                        {
                                                            results[j, i, k].not_failure = false;
                                                        }
                                                        status = false;
                                                        // continue;
                                                    }
                                                }


                                            }
                                        }
                                    }

                                    Action DoChangeState = () =>
                                    {
                                        if(status)
                                            states[i][j].changeState(RunningState.Success);
                                        else
                                            states[i][j].changeState(RunningState.Fail);
                                    };
                                    try
                                    {
                                        this.Invoke(DoChangeState);
                                    }
                                    catch { }
                                    


                                }
                                else if(ExecutionState.Scales[i,j]==0)
                                {
                                    factors_m[i]--;
                                    Action DoChangeState = () =>
                                    {
                                        states[i][j].changeState(RunningState.Success);
                                    };
                                    try
                                    {
                                        this.Invoke(DoChangeState);
                                    }
                                    catch { }
                                    for (int jj = 10; jj < 10 + NSO; jj++)
                                    {
                                       

                                        results[j, i, jj - 10].not_failure = true;
                                        results[j, i, jj - 10].story_shear = 0;// Convert.ToDecimal(temp_string[1]);
                                        results[j, i, jj - 10].drift_ratio = 0;// Convert.ToDecimal(temp_string[2]);
                                        results[j, i, jj - 10].story_drift = 0;// Convert.ToDecimal(temp_string[3]);
                                        results[j, i, jj - 10].displacment = 0;// Convert.ToDecimal(temp_string[4]);
                                        results[j, i, jj - 10].velocity = 0;// Convert.ToDecimal(temp_string[5]);
                                        results[j, i, jj - 10].acceleration = 0;// Convert.ToDecimal(temp_string[6]);
                                        results[j, i, jj - 10].story_velocity_drift = 0;// Convert.ToDecimal(temp_string[7]);
                                        results[j, i, jj - 10].damage_index = 0;// Convert.ToDecimal(damage_index);

                                    }

                                }
                                else
                                {
                                    Action DoChangeState = () =>
                                    {
                                        states[i][j].changeState(RunningState.Fail);
                                    };
                                    try
                                    {
                                        this.Invoke(DoChangeState);
                                    }
                                    catch { }
                                }

                            }
                            // Show running time 
                            Action DoUpdateTime = () =>
                            {
                                states[i][j].setTime(DateTime.Now.Subtract(ExecutionState.StartingTimes[i, j]));
                            };
                            try
                            {
                                this.Invoke(DoUpdateTime);
                            }
                            catch { }
                        }
                    }
                }
                #endregion
                #region Count Running,Success, Fail ... 
                waiting = running = success = fail = forceFailed=0; 
                for (int i = 0; i < ExecutionState.ScalesCount;i++ )
                {
                    for(int j=0;j<ExecutionState.FilesCount;j++)
                    {
                        RunningState state = states[i][j].getState();
                        if (state == RunningState.Fail)
                            fail++;
                        else if (state == RunningState.ForceFailed)
                            forceFailed++;
                        else if (state == RunningState.Running)
                            running++;
                        else if (state == RunningState.Success)
                            success++;
                        else
                            waiting++;
                    }
                }
                Action DoCrossThreadUIWork = () =>
                {
                    lb_status.Text = String.Format(status_template, running, waiting, success, fail,forceFailed);
                    pb_total.Value = (int)((((float)(success + fail+forceFailed)) / (running + waiting + success + fail+forceFailed)) * 100);
                };
                try
                {
                    this.Invoke(DoCrossThreadUIWork);
                }
                catch { }
                
                #endregion
                #region if there is any empty core, run a new process 
                if(waiting>0 && running<Limits.CORES)
                {

                    for(int i=0;i<ExecutionState.ScalesCount;i++)
                    {
                        if (running >= Limits.CORES)
                                break;
                        for(int j=0;j<ExecutionState.FilesCount;j++)
                        {
                            
                            if(states[i][j].getState()== RunningState.Waiting)
                            {
                                running++; 
                               // Thread thread = new Thread(() => runProcess(ExecutionState.Paths[i,j]));
                                Thread thread = new Thread(runProcess);
                                thread.IsBackground = true;
                                thread.Start(new RunningThreadInput(i,j));
                                Action DoChangeState = () =>
                                    {
                                        states[i][j].changeState(RunningState.Running);
                                    };
                                try
                                {
                                    this.Invoke(DoChangeState);
                                }
                                catch { }
                                if (running >= Limits.CORES)
                                    break;
                                
                            }
                        }
                    }
                }
                #endregion

                #region check for force failed condition
                int failedScales = 0;
                for (int i = 0; i < ExecutionState.FilesCount;i++ )
                {
                    failedScales = 0;
                    for(int j=0;j<ExecutionState.ScalesCount;j++)
                    {
                       if (states[j][i].getState() == RunningState.Fail)
                       {
                          failedScales++;
                          if(failedScales>=forceFail_scales)
                          {
                              break;
                          }
                       }
                       else
                       {
                           failedScales = 0;
                       }
                        
                    }
                    if(failedScales>=forceFail_scales)
                    {
                       for(int j=0;j<ExecutionState.ScalesCount;j++)
                       {
                           if (states[j][i].getState() == RunningState.Waiting)
                           {
                               Action DoChangeState = () =>
                               {
                                   states[j][i].changeState(RunningState.ForceFailed);
                               };
                               try
                               {
                                   this.Invoke(DoChangeState);
                               }
                               catch { }

                           }

                       }
                    }
                }
               

                #endregion
                //if(EXEC_TIMER)
                //{
                //    //Console.WriteLine("CPU " + getCurrentCpuUsage() + "%");
                //    cpuValues.AddLast(getCurrentCpuUsage());
                //}
                //if(pb_total.Value == 100 && EXEC_TIMER)
                //{
                //    TimeSpan duration = DateTime.Now.Subtract(startingTime);
                //    Console.WriteLine("Execution Time is : "+ duration+"  [" + duration.TotalMilliseconds+"] Average CPU = "+cpuValues.Average());
                    
                //    EXEC_TIMER = false;
                //}
               //     Thread.Sleep(100);

            }
        }
        void runProcess(object input)
        {
            RunningThreadInput t = (RunningThreadInput)input;
            int i = t.i;
            int j = t.j;
            ProcessStartInfo startInfo = new ProcessStartInfo(ExecutionState.Paths[i,j] + @"\idarc2d_7.0.exe");
            startInfo.WorkingDirectory = ExecutionState.Paths[i, j];
           // startInfo.WindowStyle = ProcessWindowStyle.Minimized;
           // startInfo.UseShellExecute = false;

          //  startInfo.FileName = fullPath;
           // startInfo.Arguments = args;
            //startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;


           // startInfo.Verb = "runas";
            Process p = new Process();
            p.StartInfo = startInfo;
            ExecutionState.Process[i, j] = p;
            ExecutionState.StartingTimes[i, j] = DateTime.Now;
            ExecutionState.EndingTimes[i, j] = DateTime.MaxValue;
            p.Start();
            p.WaitForExit();
            ExecutionState.EndingTimes[i, j] = DateTime.Now;
        }
        string status_template;
        private void ExecutionMonitors_Load(object sender, EventArgs e)
        {
           
            states = new List<List<RunState>>();
            
            for(int i=0;i<ExecutionState.ScalesCount;i++)
            {
                states.Add(new List<RunState>());
                for(int j=0;j<ExecutionState.FilesCount;j++)
                {
                    RunState state = new RunState(i,j, RunningState.Waiting);
                    
                    states[i].Add(state);
                    states_panel.Controls.Add(state);


                }
            }
            status_template = "Total proccess [" + (ExecutionState.FilesCount * ExecutionState.ScalesCount);
            status_template += "] Running  [{0}]  Waiting [{1}]  Success  [{2}] Fail  [{3}] Force Failed [{4}]";
            lb_status.Text = String.Format(status_template, 0, 0, 0, 0,0);
             updater_thread = new Thread(new ThreadStart(updater));
            updater_thread.IsBackground = true;
            updater_thread.Start();
            ExecutionState.OK = true;
            startingTime = DateTime.Now;
        }

        private void ExecutionMonitors_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running > 0 || waiting > 0)
            {
                DialogResult res = MessageBox.Show("There are some processes still runing/waiting\r\nAre you sure you want to close the form ?", "Closing", MessageBoxButtons.YesNo);
                if (res != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }

           ExecutionState.OK = false;
            for (int i = 0; i < ExecutionState.ScalesCount; i++)
            {
                for (int j = 0; j < ExecutionState.FilesCount; j++)
                {
                    if (ExecutionState.Process[i, j] != null)
                    {
                        if (!ExecutionState.Process[i, j].HasExited)
                        {
                            try
                            {
                                ExecutionState.Process[i, j].Kill();
                            }
                            catch { }
                        }
                    }
                }
            }
            if(updater_thread !=null)
            {
                try
                {
                    updater_thread.Suspend();
                }
                catch { }
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            ExecutionState.OK = false;
            for(int i=0;i<ExecutionState.ScalesCount;i++)
            {
                for(int j=0;j<ExecutionState.FilesCount;j++)
                {
                    try
                    {
                        if(states[i][j].getState() == RunningState.Running)
                        {
                            states[i][j].changeState(RunningState.Waiting);
                            ExecutionState.Process[i,j].Kill();
                        }
                        
                    }
                    catch (Exception ee) { MessageBox.Show("Error while stoping some processes"); }
                }
            }
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            ExecutionState.OK = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //if (running > 0 || waiting > 0)
            //{
            //    DialogResult res = MessageBox.Show("There are some processes still runing/waiting\r\nAre you sure you want to close the form ?", "Closing", MessageBoxButtons.YesNo);
            //    if (res != System.Windows.Forms.DialogResult.Yes)
            //        return;
            //}
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //if(running>0||waiting>0)
            //{
            //    DialogResult res = MessageBox.Show("There are some processes still runing/waiting\r\nAre you sure you want to close the form ?", "Closing", MessageBoxButtons.YesNo);
            //    if (res != System.Windows.Forms.DialogResult.Yes)
            //        return;
            //}
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
     class RunningThreadInput
    {
        public RunningThreadInput()
        {
            i = j = 0;
        }
        public RunningThreadInput(int i,int j)
        {
            this.i = i;
            this.j = j;
        }
        public int i { get; set; }
        public int j { get; set; }
    }
}
