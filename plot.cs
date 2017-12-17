


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using com.demo;
using System.Diagnostics;
using System.IO;
using System.Collections;



namespace SampleWizard
{
    public partial class plot : Form
    {
        results_class [, ,] results;
        object[,] batch;
        List<decimal> factors = new List<decimal>();

        List<int> Frag1 = new List<int>();
        List<int> Frag2 = new List<int>();
        List<int> Frag3 = new List<int>();
        List<int> Frag4 = new List<int>();
        List<int> Frag5 = new List<int>();


        List<int> num_c = new List<int>();
        List<int> num_g = new List<int>();
        List<double> x_value = new List<double>();
        List<double> IMM = new List<double>();


        public plot()
        {
            InitializeComponent();
        }
        double BTOT, c1, c2, c3, c4, c5, duct, Smt, SSF;
        double c1_check, c2_check, c3_check, c4_check, c5_check;
        int FEMA_check;
        double ACMR20;
        bool units;
        String units_length;
        String units_acc;
        String units_speed;
        String units_force;

        public plot(ref results_class [, ,] results_, ref object[,] batch_, ref decimal[] factors_, double BTOT_, double cc1, double cc2, double cc3, double cc4, double cc5, double ductt, double SSFf, double Smtt, int FEMA_check_, double cc1_, double cc2_, double cc3_, double cc4_, double cc5_, double ACMR20_, bool units_)
        {
            InitializeComponent();
            //CreateGraph(zedGraphControl1, x,y);
            results = results_;
            batch = batch_;
            duct = ductt;
            Smt = Smtt;
            SSF = SSFf;
            factors = new List<decimal>( factors_);
            BTOT = BTOT_;
            c1 = cc1;
            c2 = cc2;
            c3 = cc3;
            c4 = cc4;
            c5 = cc5;
            c1_check = cc1_;
            c2_check = cc2_;
            c3_check = cc3_;
            c4_check = cc4_;
            c5_check = cc5_;
            ACMR20 = ACMR20_;
            FEMA_check = FEMA_check_;
            units = units_;
            if(units)
            {
                units_length = " (inch)";
                units_acc = " (inch/sec^2)";
                units_speed =  " (inch/sec)";
                units_force = " (kips)";
            }
            else
            {
                units_length = " (mm)";
                units_acc = " (mm/sec^2)";
                units_speed =  " (mm/sec)";
                units_force = " (kN)";
            }
            String [] combo2_items = {
                "Story Shear" + units_force,
                "Drift Ratio(%)" ,
                "Story Drift",
                "Displacement" + units_length,
                "Velocity" + units_speed,
                "Acceleration" + units_acc,
                "Story Velocity Drift"
            };
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(combo2_items);

            
        }
        //1st plot (SF vs Maxs') (Y vs X)
        PointPairList[] list_Max_ss; 
        PointPairList[] list_Max_sd; 
        PointPairList[] list_Max_dr;
        PointPairList[] list_damage;

        //2nd plot (Story# vs Response_columns') (Y vs X)
        //STORY SHEAR    DRIFT RATIO(%)    STORY DRIFT    DISPLACEMENT      VELOCITY    ACCELERATION    STORY VELOCITY DRIFT
        PointPairList[,] list_ss;
        PointPairList[,] list_dr;
        PointPairList[,] list_sd;
        PointPairList[,] list_disp;
        PointPairList[,] list_vel;
        PointPairList[,] list_acc;
        PointPairList[,] list_svd;

        double ACMR_collapse;
        GraphViewer graph2 = new GraphViewer();
        GraphViewer graph3 = new GraphViewer();
        private void plot_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            if (FEMA_check != 1)
                zedGraphControl2.Hide();
            else
                zedGraphControl2.Show();

            int i_size = Convert.ToInt16(results.GetLength(0));
            int j_size = Convert.ToInt16(results.GetLength(1));
            list_ss = new PointPairList[i_size, j_size];
            list_dr = new PointPairList[i_size, j_size];
            list_sd = new PointPairList[i_size, j_size];
            list_disp = new PointPairList[i_size, j_size];
            list_vel = new PointPairList[i_size, j_size];
            list_acc = new PointPairList[i_size, j_size];
            list_svd = new PointPairList[i_size, j_size];

            int c = 0;
            //Frag1 = new int[(int)results.GetLength(1)];
            //Frag2 = new int[(int)results.GetLength(1)];
            //Frag3 = new int[(int)results.GetLength(1)];
            //Frag4 = new int[(int)results.GetLength(1)];
            //Frag5 = new int[(int)results.GetLength(1)];
            for (int i = 0; i < (int)results.GetLength(1); i++)
            {
                Frag1.Add(0);
                Frag2.Add(0);
                Frag3.Add(0);
                Frag4.Add(0);
                Frag5.Add(0);

            }

            comboBox1.SelectedIndex = 0;

            dataGridView1.RowCount = results.GetLength(0) * results.GetLength(1) + results.GetLength(0);
            dataGridView1.ColumnCount = 5;
            int ttt = results.GetLength(0);
            list_Max_ss = new PointPairList[ttt];
            list_Max_sd = new PointPairList[ttt];
            list_Max_dr = new PointPairList[ttt];
            list_damage = new PointPairList[ttt];

            double[] Last_SF = new double[results.GetLength(0)];
            double[] Last_ss = new double[results.GetLength(0)];
            double[] Last_dr = new double[results.GetLength(0)];
            double[] Last_sd = new double[results.GetLength(0)];


            //IMM = new double[(int)results.GetLength(1)];
            for (int i = 0; i < (int)results.GetLength(1); i++)
            {
                IMM.Add(0);

            }
            for (int i = 0; i < results.GetLength(0); i++) //each file
            {

                dataGridView1[0, c].Value = batch[i, 4];
                checkedListBox1.Items.Add(batch[i, 4].ToString());
                checkedListBox2.Items.Add(batch[i, 4].ToString());

                //Add the name of the vertical

                list_Max_ss[i] = new PointPairList();
                list_Max_sd[i] = new PointPairList();
                list_Max_dr[i] = new PointPairList();
                list_damage[i] = new PointPairList();

                list_Max_ss[i].Add(0, 0);
                list_Max_sd[i].Add(0, 0);
                list_Max_dr[i].Add(0, 0);
                c++;
                for (int j = 0; j < results.GetLength(1); j++) //each factor
                {   //What to Show
                   if(i==0)
                       comboBox3.Items.Add(results[0, j, 0].scale_factor);

                    

                    list_ss[i, j] = new PointPairList();
                    list_dr[i, j] = new PointPairList();
                    list_sd[i, j] = new PointPairList();
                    list_disp[i, j] = new PointPairList();
                    list_vel[i, j] = new PointPairList();
                    list_acc[i, j] = new PointPairList();
                    list_svd[i, j] = new PointPairList();

                    //Get Max
                    decimal max_ss=0;
                    decimal max_dr = 0;
                    decimal max_sd = 0;
                    dataGridView1.Columns[0].HeaderText = "Intensity Measure (IM)";
                    dataGridView1.Columns[1].HeaderText = "Maximum Story Shear" + units_force;
                    dataGridView1.Columns[2].HeaderText = "Maximum Drift Ratio (%)";
                    dataGridView1.Columns[3].HeaderText = "Maximum Story Drift";
                    dataGridView1.Columns[4].HeaderText = "Damage Index (DI)";
                    int floor_num = results.GetLength(2);
                    for (int k = 0; k < results.GetLength(2); k++)
                    {
                        if (results[i, j, k].story_drift > max_sd)
                            max_sd = results[i, j, k].story_drift;
                        if (results[i, j, k].story_shear > max_ss)
                            max_ss = results[i, j, k].story_shear;
                        if (results[i, j, k].drift_ratio > max_dr)
                            max_dr = results[i, j, k].drift_ratio;


                        if (results[i, j, k].not_failure)
                        {
                            list_ss[i,j].Add(Convert.ToDouble(results[i, j, k].story_shear), (floor_num - k));
                            list_dr[i, j].Add(Convert.ToDouble(results[i, j, k].drift_ratio), (floor_num - k));
                            list_sd[i, j].Add(Convert.ToDouble(results[i, j, k].story_drift), (floor_num - k));
                            list_disp[i, j].Add(Convert.ToDouble(results[i, j, k].displacment), (floor_num - k));
                            list_vel[i, j].Add(Convert.ToDouble(results[i, j, k].velocity), (floor_num - k));
                            list_acc[i, j].Add(Convert.ToDouble(results[i, j, k].acceleration), (floor_num - k));
                            list_svd[i, j].Add(Convert.ToDouble(results[i, j, k].story_velocity_drift), (floor_num - k));
                            
                        }

                    }

                    dataGridView1[0, c].Value = results[i, j, 0].scale_factor;

                    if (results[i, j, 0].not_failure)
                    {
                        dataGridView1[1, c].Value = max_ss;
                        dataGridView1[2, c].Value = max_dr;
                        dataGridView1[3, c].Value = max_sd;
                        dataGridView1[4, c].Value = results[i, j, 0].damage_index;
                    }
                    else
                    {
                        dataGridView1[1, c].Value = "F";
                        dataGridView1[2, c].Value = "F";
                        dataGridView1[3, c].Value = "F";
                        dataGridView1[4, c].Value = "F";
                    }
                    if (results[i, j, 0].not_failure == true)
                    {
                        list_Max_ss[i].Add(Convert.ToDouble(max_ss), Convert.ToDouble(results[i, j, 0].scale_factor));
                        list_Max_dr[i].Add(Convert.ToDouble(max_dr), Convert.ToDouble(results[i, j, 0].scale_factor));
                        list_Max_sd[i].Add(Convert.ToDouble(max_sd), Convert.ToDouble(results[i, j, 0].scale_factor));
                        list_damage[i].Add(Convert.ToDouble(results[i, j, 0].damage_index), (Convert.ToDouble(results[i, j, 0].scale_factor)));

                        Last_SF[i] = Convert.ToDouble(results[i, j, 0].scale_factor);
                        Last_ss[i] = Convert.ToDouble(max_ss);
                        Last_sd[i] = Convert.ToDouble(max_sd);
                        Last_dr[i]  = Convert.ToDouble(max_dr);
                    }
                    else
                    {
                        if (i != 0)
                        {
                          //  list_Max_ss[i].Add(Last_ss[i]*10, Last_SF[i]);
                            list_Max_dr[i].Add(10, Last_SF[i]);
                          //  list_Max_sd[i].Add(Last_sd[i] * 10, Last_SF[i]);
                        }
                        else
                        {
                          //  list_Max_ss[i].Add(0, 0);
                          //  list_Max_dr[i].Add(0, 0);
                          //  list_Max_sd[i].Add(0, 0);

                        }

                    }
                    //list_Max[i, 3].Add(0, 0);

                    c++;


                }


            }
            comboBox3.SelectedIndex = 0;


          //  double []SF = new double[

            for (int i = 0; i < (int)results.GetLength(0); i++) //each file
            {
                for (int j = 0; j < (int)results.GetLength(1); j++) //each factor
                {
                    double Max_Drift=0;
                    for (int k = 0; k < results.GetLength(2); k++)
                    {
                        if (results[i, j, k].drift_ratio > Convert.ToDecimal( Max_Drift))
                            Max_Drift = Convert.ToDouble( results[i, j, k].drift_ratio);

                        //Get Out Other X,Y

                    }
                    //Define Check1,2,3 .. Define Frag[results.GetLength(1), 3]
                    if (((Max_Drift >= c1  ) || results[i,j,0].not_failure == false)  && c1_check == 1)
                    {
                        Frag1[j]++;
                    }
                    if (((Max_Drift >= c2) || results[i, j, 0].not_failure == false)&& c2_check == 1)
                    {
                        Frag2[j]++;

                    }
                    if (((Max_Drift >= c3) || results[i, j, 0].not_failure == false)&& c3_check == 1)
                    {
                        Frag3[j]++;

                    }
                    if (((Max_Drift >= c4 ) || results[i, j, 0].not_failure == false)&& c4_check == 1)
                    {
                        Frag4[j]++;

                    }
                    if (((Max_Drift >= c5 ) || results[i, j, 0].not_failure == false)&& c5_check == 1)
                    {
                        Frag5[j]++;

                    }
                }

            }

//            IM
//  DCR
//LS
//LSR
//CP
            dataGridView2.RowHeadersWidth = 180;
            dataGridView2.RowCount = results.GetLength(1)+4;
            dataGridView2.ColumnCount = 6;
            //dataGridView2.Columns[0].HeaderText = "Intensity Measure (IM)";
            dataGridView2.Columns[0].HeaderText = "Probability of Immediate Occupancy [P(IO)]";//"Probability of IM";
            dataGridView2.Columns[1].HeaderText = "Probability of Damage Control Range [P(DCR)]";//"Probability of DCR";
            dataGridView2.Columns[2].HeaderText = "Probability of Life Safety [P(LS)]";//"Probability of LS";
            dataGridView2.Columns[3].HeaderText = "Probability of Limited Safety Range [P(LSR)]";//"Probability of LSR";
            dataGridView2.Columns[4].HeaderText = "Probability of Collapse Prevention [P(CP)]";//"Probability of CP";
            dataGridView2.Columns[5].HeaderText = "Probability of Total Collapse [P(TC)]";//"Probability of Failure";
            
            dataGridView2.Rows[results.GetLength(1)].HeaderCell.Value = "Fitted Farg. Mean (Theta)";
            dataGridView2.Rows[results.GetLength(1)+1].HeaderCell.Value = "Fitted Farg. Std. Dev. (Beta)";
            dataGridView2.Rows[results.GetLength(1)+2].HeaderCell.Value = "Adj. Farg. Mean (Theta)";
            dataGridView2.Rows[results.GetLength(1) + 3].HeaderCell.Value = "Adj. Farg. Std. Dev. (Beta)";

            double[] scales = new double[(int)results.GetLength(1)];
            //num_c = new int[(int)results.GetLength(1)];
            //num_g = new int[(int)results.GetLength(1)];
            for (int i = 0; i < (int)results.GetLength(1); i++)
            {
                num_c.Add(0);
                num_g.Add(0);


            }
           
            for ( int j = 0; j < (int)results.GetLength(1); j++) //each factor
            {

                //dataGridView2[0, j].Value = results[0, j, 0].scale_factor;
                dataGridView2.Rows[j].HeaderCell.Value = "Intensity Measure (IM) = " + results[0, j, 0].scale_factor;
                scales[j] = Convert.ToDouble( results[0, j, 0].scale_factor);
                IMM[j] = Convert.ToDouble(results[0, j, 0].scale_factor);
                
              
                dataGridView2[0, j].Value = (Frag1[j] / (decimal)results.GetLength(0));
                dataGridView2[1, j].Value = (Frag2[j] / (decimal)results.GetLength(0));
                dataGridView2[2, j].Value = (Frag3[j] / (decimal)results.GetLength(0));
                dataGridView2[3, j].Value = (Frag4[j] / (decimal)results.GetLength(0));
                dataGridView2[4, j].Value = (Frag5[j] / (decimal)results.GetLength(0));
                dataGridView2[5, j].Value = (factors[j] / (decimal)results.GetLength(0));

                num_c[j] = (int)(factors[j]);
                num_g[j] = (int)results.GetLength(0);
            }

            







            
            int cc = 0;
            int size = (int)results.GetLength(1);

            decimal inc = 0.01M;

            for (decimal i = 0; i <= results[0, size - 1, 0].scale_factor; i += (inc / 10))
            {
                cc++;
            }
            //x_value = new double[cc];
            for (int i = 0; i < cc; i++)
            {
                x_value.Add(0);



            }
            cc = 0;



            for (decimal i = 0; i <= results[0, size - 1, 0].scale_factor; i += (inc / 10))
            {
                x_value[cc] = Convert.ToDouble(i);
                cc++;
            }


///////////////////////////////////////////Fitting (Collapsed)
            double theta = 0.8;
            double beta = 0.4;

            //Inputs
            //IMM.Insert(0, 0);
            //num_g.Add(results.GetLength(0));


            List<double> IM = new List<double>(IMM);
            List<int> num_collapse = new List<int>(num_c);
            List<int> num_gms = new List<int>(num_g);
            List<double> x = new List<double>(x_value);
            List<double> y0_obs = new List<double>();
            List<double> y1_obs = new List<double>();
            List<double> y2_obs = new List<double>();
            List<double> y3_obs = new List<double>();
            List<double> y4_obs = new List<double>();
            List<double> y5_obs = new List<double>();

            y0_obs.Add(0);

            y1_obs.Add(0);
            y2_obs.Add(0);
            y3_obs.Add(0);
            y4_obs.Add(0);
            y5_obs.Add(0);

                //Frag1.Insert(0, 0);
                //Frag2.Insert(0, 0);
                //Frag3.Insert(0, 0);
                //Frag4.Insert(0, 0);
                //Frag5.Insert(0, 0);
                //num_collapse.Insert(0, 0);


            List<double> y0_adj= new List<double>();
            List<double> y1_adj = new List<double>();
            List<double> y2_adj = new List<double>();
            List<double> y3_adj = new List<double>();
            List<double> y4_adj = new List<double>();
            List<double> y5_adj = new List<double>();

            com.sameer.Analysis.fn_mle_pc(IM, num_gms, num_collapse, ref theta, ref beta);
            if (theta < 0)
                theta = theta * -1;
            if (beta < 0)
                beta = beta * -1;

     FragilityParameters.Theta0_Fitted = theta;
            FragilityParameters.Beta0_Fitted = beta;

            

            List<double> y0_fit = com.sameer.Analysis.Evaluate(theta, beta, x);

       
            List<double> y1_fit = new List<double>();
            List<double> y2_fit = new List<double>();
            List<double> y3_fit = new List<double>();
            List<double> y4_fit = new List<double>();
            List<double> y5_fit = new List<double>();

            double CMR, ACMR;

            for (int i = 0; i<num_collapse.Count; i++)
            {
                y0_obs.Add ((double) num_collapse[i] / num_gms[0]);
 
            }
            //Adjust
            if (FEMA_check==1)
            {
               CMR = theta / Smt;
             //   CMR = theta;
                ACMR = SSF * CMR;
                //ACMR =  CMR;
                theta = ACMR*Smt;
                beta = BTOT;
                FragilityParameters.Theta0_Adj = theta;
                FragilityParameters.Beta0_Adj = beta;
                 y0_adj = com.sameer.Analysis.Evaluate(theta, beta, x);
                 ACMR_collapse = ACMR;
            }
                    

                //c1
            if (c1_check ==1)
            {
                theta = 0.8;
                beta = 0.4;
                num_collapse = new List<int>(Frag1);
                com.sameer.Analysis.fn_mle_pc(IM, num_gms, num_collapse, ref theta, ref beta);
                if (theta < 0)
                    theta = theta * -1;
                if (beta < 0)
                    beta = beta * -1;

                FragilityParameters.Theta1_Fitted = theta;
                FragilityParameters.Beta1_Fitted = beta;


                y1_fit = com.sameer.Analysis.Evaluate(theta, beta, x);
                for (int i = 0; i < num_collapse.Count; i++)
                {
                    y1_obs.Add((double)num_collapse[i] / num_gms[0]);

                }
                //Adjust
                if (FEMA_check == 1)
                {
                   // CMR = theta / Smt;
                    CMR = theta;
                    ACMR = SSF * CMR;
                    theta = ACMR;
                    beta = BTOT;
                    FragilityParameters.Theta1_Adj = theta;
                    FragilityParameters.Beta1_Adj = beta;
                    y1_adj = com.sameer.Analysis.Evaluate(theta, beta, x);
                }
            }
            if (c2_check == 1)
            {
                //c2
                theta = 0.8;
                beta = 0.4;
                num_collapse = new List<int>(Frag2);
                com.sameer.Analysis.fn_mle_pc(IM, num_gms, num_collapse, ref theta, ref beta);
                if (theta < 0)
                    theta = theta * -1;
                if (beta < 0)
                    beta = beta * -1;
                FragilityParameters.Theta2_Fitted = theta;
                FragilityParameters.Beta2_Fitted = beta;

                y2_fit = com.sameer.Analysis.Evaluate(theta, beta, x);
                for (int i = 0; i < num_collapse.Count; i++)
                {
                    y2_obs.Add((double)num_collapse[i] / num_gms[0]);

                }
                //Adjust
                if (FEMA_check == 1)
                {
                    //CMR = theta / Smt;
                    CMR = theta;
                    ACMR = SSF * CMR;
                    theta = ACMR;
                    beta = BTOT;
                    FragilityParameters.Theta2_Adj = theta;
                    FragilityParameters.Beta2_Adj = beta;
                    y2_adj = com.sameer.Analysis.Evaluate(theta, beta, x);
                }
            }
            if (c3_check == 1)
            {
                //c3
                theta = 0.8;
                beta = 0.4;
                num_collapse = new List<int>(Frag3);
                com.sameer.Analysis.fn_mle_pc(IM, num_gms, num_collapse, ref theta, ref beta);
                if (theta < 0)
                    theta = theta * -1;
                if (beta < 0)
                    beta = beta * -1;
                FragilityParameters.Theta3_Fitted = theta;
                FragilityParameters.Beta3_Fitted = beta;
                y3_fit = com.sameer.Analysis.Evaluate(theta, beta, x);
                for (int i = 0; i < num_collapse.Count; i++)
                {
                    y3_obs.Add((double)num_collapse[i] / num_gms[0]);

                }
                //Adjust
                if (FEMA_check == 1)
                {
                    //CMR = theta / Smt;
                    CMR = theta;
                    ACMR = SSF * CMR;
                    theta = ACMR;
                    beta = BTOT;
                    FragilityParameters.Theta3_Adj = theta;
                    FragilityParameters.Beta3_Adj = beta;
                    y3_adj = com.sameer.Analysis.Evaluate(theta, beta, x);
                }
            }
            if (c4_check == 1)
            {
                //c4
                theta = 0.8;
                beta = 0.4;
                num_collapse = new List<int>(Frag4);
                com.sameer.Analysis.fn_mle_pc(IM, num_gms, num_collapse, ref theta, ref beta);
                if (theta < 0)
                    theta = theta * -1;
                if (beta < 0)
                    beta = beta * -1;
                FragilityParameters.Theta4_Fitted = theta;
                FragilityParameters.Beta4_Fitted = beta;
                y4_fit = com.sameer.Analysis.Evaluate(theta, beta, x);
                for (int i = 0; i < num_collapse.Count; i++)
                {
                    y4_obs.Add((double)num_collapse[i] / num_gms[0]);

                }
                //Adjust
                if (FEMA_check == 1)
                {
                    //CMR = theta / Smt;
                    CMR = theta;
                    ACMR = SSF * CMR;
                    theta = ACMR;
                    beta = BTOT;
                    FragilityParameters.Theta4_Adj = theta;
                    FragilityParameters.Beta4_Adj = beta;
                    y4_adj = com.sameer.Analysis.Evaluate(theta, beta, x);
                }
            }
            if (c5_check == 1)
            {
                //c5
                theta = 0.8;
                beta = 0.4;
                num_collapse = new List<int>(Frag5);
                com.sameer.Analysis.fn_mle_pc(IM, num_gms, num_collapse, ref theta, ref beta);
                if (theta < 0)
                    theta = theta * -1;
                if (beta < 0)
                    beta = beta * -1;
                FragilityParameters.Theta5_Fitted = theta;
                FragilityParameters.Beta5_Fitted = beta;
                y5_fit = com.sameer.Analysis.Evaluate(theta, beta, x);
                for (int i = 0; i < num_collapse.Count; i++)
                {
                    y5_obs.Add((double)num_collapse[i] / num_gms[0]);

                }
                //Adjust
                if (FEMA_check == 1)
                {
                    ///CMR = theta / Smt;
                    CMR = theta;
                    ACMR = SSF * CMR;
                    theta = ACMR;
                    beta = BTOT;
                    FragilityParameters.Theta5_Adj = theta;
                    FragilityParameters.Beta5_Adj = beta;
                    y5_adj = com.sameer.Analysis.Evaluate(theta, beta, x);

                }
            }
            //dataGridView2[0,]
           // MessageBox.Show(""+results.GetLength(1));
            dataGridView2[5, results.GetLength(1)].Value = "" + FragilityParameters.Theta0_Fitted;
            dataGridView2[0, results.GetLength(1)].Value = "" + FragilityParameters.Theta1_Fitted;
            dataGridView2[1, results.GetLength(1)].Value = "" + FragilityParameters.Theta2_Fitted;
            dataGridView2[2, results.GetLength(1)].Value = "" + FragilityParameters.Theta3_Fitted;
            dataGridView2[3, results.GetLength(1)].Value = "" + FragilityParameters.Theta4_Fitted;
            dataGridView2[4, results.GetLength(1)].Value = "" + FragilityParameters.Theta5_Fitted;

            dataGridView2[5, results.GetLength(1) + 1].Value = "" + FragilityParameters.Beta0_Fitted;
            dataGridView2[0, results.GetLength(1) + 1].Value = "" + FragilityParameters.Beta1_Fitted;
            dataGridView2[1, results.GetLength(1) + 1].Value = "" + FragilityParameters.Beta2_Fitted;
            dataGridView2[2, results.GetLength(1) + 1].Value = "" + FragilityParameters.Beta3_Fitted;
            dataGridView2[3, results.GetLength(1) + 1].Value = "" + FragilityParameters.Beta4_Fitted;
            dataGridView2[4, results.GetLength(1) + 1].Value = "" + FragilityParameters.Beta5_Fitted;

            dataGridView2[5, results.GetLength(1) + 2].Value = "" + FragilityParameters.Theta0_Adj;
            dataGridView2[0, results.GetLength(1) + 2].Value = "" + FragilityParameters.Theta1_Adj;
            dataGridView2[1, results.GetLength(1) + 2].Value = "" + FragilityParameters.Theta2_Adj;
            dataGridView2[2, results.GetLength(1) + 2].Value = "" + FragilityParameters.Theta3_Adj;
            dataGridView2[3, results.GetLength(1) + 2].Value = "" + FragilityParameters.Theta4_Adj;
            dataGridView2[4, results.GetLength(1) + 2].Value = "" + FragilityParameters.Theta5_Adj;

            dataGridView2[5, results.GetLength(1) + 3].Value = "" + FragilityParameters.Beta0_Adj;
            dataGridView2[0, results.GetLength(1) + 3].Value = "" + FragilityParameters.Beta1_Adj;
            dataGridView2[1, results.GetLength(1) + 3].Value = "" + FragilityParameters.Beta2_Adj;
            dataGridView2[2, results.GetLength(1) + 3].Value = "" + FragilityParameters.Beta3_Adj;
            dataGridView2[3, results.GetLength(1) + 3].Value = "" + FragilityParameters.Beta4_Adj;
            dataGridView2[4, results.GetLength(1) + 3].Value = "" + FragilityParameters.Beta5_Adj;
        
            List<double> factors_list = new List<double>(Array.ConvertAll(scales, xxx => (double)xxx));
            Draw_frag_obs_fit(x, factors_list, y0_obs, y0_fit, y1_obs, y1_fit, y2_obs, y2_fit, y3_obs, y3_fit, y4_obs, y4_fit, y5_obs, y5_fit);
           // Draw_frag_obs_fit(graph3.zedGraphControl1, x, factors_list, y0_obs, y0_fit, y1_obs, y1_fit, y2_obs, y2_fit, y3_obs, y3_fit, y4_obs, y4_fit, y5_obs, y5_fit);
                if (FEMA_check == 1)
                {
                    Draw_frag_adj(zedGraphControl2,x, y0_adj, y1_adj, y2_adj, y3_adj, y4_adj, y5_adj);
                    Draw_frag_adj(graph2.zedGraphControl1, x, y0_adj, y1_adj, y2_adj, y3_adj, y4_adj, y5_adj);
                    String output="";
                    if (ACMR_collapse >= ACMR20)
                    {

                        output = String.Format("ACMR_Collapse= {0:0.00} >= ACMR20%= {1:0.00} \n", ACMR_collapse, ACMR20);// +ACMR_collapse + ">= ACMR20%= " + ACMR20 + "\n";
                        output += " The trial design (or the existing building) meets the collapse performance objective, and the building has an acceptably low probability of collapse for MCE ground motions";
                    }
                    else
                    {
                        output = String.Format("ACMR_Collapse= {0:0.00} <= ACMR20%= {1:0.00} \n",ACMR_collapse,ACMR20);// + "\n";
                        output += "The design does not meet the collapse performance objective, re-design and re-evaluation are required";
                    }
                    MessageBox.Show(output);

                }
        }




        GraphPane myPane2;
        private void Draw_frag_adj(ZedGraphControl zedGraphControl2, List<double> x,List<double> y0_adj, List<double> y1_adj, List<double> y2_adj, List<double> y3_adj, List<double> y4_adj, List<double> y5_adj)
        {
            myPane2 = zedGraphControl2.GraphPane;
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.GraphObjList.Clear();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
            myPane2.Title.Text = "Adjusted Fragility Curves";
            if(FEMA_check==1)
                myPane2.XAxis.Title.Text = "Sa[@Tn, 5%] (g)" ;
            else
                myPane2.XAxis.Title.Text = "PGA (g) " ;
            myPane2.YAxis.Title.Text = "Probability";

            int length = x.Count;

            PointPairList list0 = new PointPairList();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            

            for (int i = 0; i < length; i++) //each file
            {

                list0.Add(x[i], y0_adj[i]);
                if(c1_check!=0)
                list1.Add(x[i], y1_adj[i]);
                if (c2_check != 0)
                list2.Add(x[i], y2_adj[i]);
                if (c3_check != 0)
                list3.Add(x[i], y3_adj[i]);
                if (c4_check != 0)
                list4.Add(x[i], y4_adj[i]);
                if (c5_check != 0)
                list5.Add(x[i], y5_adj[i]);


            }


        
            LineItem myCurve1 = myPane2.AddCurve("IO_Adjusted", list1, Color.Pink, SymbolType.None);
            LineItem myCurve2 = myPane2.AddCurve("DCR_Adjusted", list2, Color.Red, SymbolType.None);
            LineItem myCurve3 = myPane2.AddCurve("LS_Adjusted", list3, Color.Blue, SymbolType.None);
            LineItem myCurve4 = myPane2.AddCurve("LSR_Adjusted", list4, Color.Green, SymbolType.None);
            LineItem myCurve5 = myPane2.AddCurve("CP_Adjusted", list5, Color.Gold, SymbolType.None);
            LineItem myCurve0 = myPane2.AddCurve("TC_Adjusted", list0, Color.Black, SymbolType.None);

            // myCurve1.Symbol.Type = SymbolType.None;

            myPane2.Legend.IsShowLegendSymbols = true;
            zedGraphControl2.AxisChange();
        }
        GraphPane myPane3;
        GraphPane myPane3_v;
        private void Draw_frag_obs_fit( List<double> x, List<double> x_factors, List<double> y0_obs, List<double> y0_fit, List<double> y1_obs, List<double> y1_fit, List<double> y2_obs, List<double> y2_fit, List<double> y3_obs, List<double> y3_fit, List<double> y4_obs, List<double> y4_fit, List<double> y5_obs, List<double> y5_fit)
        {
            ZedGraphControl zedGraphControl3_v = graph3.zedGraphControl1;
            myPane3 = zedGraphControl3.GraphPane;
            myPane3_v = zedGraphControl3_v.GraphPane;
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl3_v.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.GraphObjList.Clear();
            zedGraphControl3_v.GraphPane.GraphObjList.Clear();
            zedGraphControl3.AxisChange();
            zedGraphControl3_v.AxisChange();
            zedGraphControl3.Invalidate();
            zedGraphControl3_v.Invalidate();

            myPane3.Title.Text = "Observed & Fitted Fragility Curves";
            myPane3_v.Title.Text = "Observed & Fitted Fragility Curves";

            if (FEMA_check == 1)
            {
                myPane3.XAxis.Title.Text = "Sa[@Tn, 5%] (g)" ;
                myPane3_v.XAxis.Title.Text = "Sa[@Tn, 5%] (g)";
            }
            else
            {
                myPane3.XAxis.Title.Text = "PGA (g) " ;
                myPane3_v.XAxis.Title.Text = "PGA (g) " ;
            }
            myPane3.YAxis.Title.Text = "Probability";
            myPane3_v.YAxis.Title.Text = "Probability";

            int length = x.Count;

            PointPairList list0_obs = new PointPairList();
            PointPairList list1_obs = new PointPairList();
            PointPairList list2_obs = new PointPairList();
            PointPairList list3_obs = new PointPairList();
            PointPairList list4_obs = new PointPairList();
            PointPairList list5_obs = new PointPairList();

            PointPairList list0_fit = new PointPairList();
            PointPairList list1_fit = new PointPairList();
            PointPairList list2_fit = new PointPairList();
            PointPairList list3_fit = new PointPairList();
            PointPairList list4_fit = new PointPairList();
            PointPairList list5_fit = new PointPairList();

            x_factors.Insert(0, 0);
            for (int i = 0; i < x_factors.Count; i++)
            {
                list0_obs.Add(x_factors[i], y0_obs[i]);
                if(c1_check !=0)
                 list1_obs.Add(x_factors[i], y1_obs[i]);
                if (c2_check != 0)
                list2_obs.Add(x_factors[i], y2_obs[i]);
                if (c3_check != 0)
                list3_obs.Add(x_factors[i], y3_obs[i]);
                if (c4_check != 0)
                list4_obs.Add(x_factors[i], y4_obs[i]);
                if (c5_check != 0)
                list5_obs.Add(x_factors[i], y5_obs[i]);
            }


            for (int i = 0; i < length; i++) //each file
            {


                list0_fit.Add(x[i], y0_fit[i]);
                if (c1_check != 0)
                list1_fit.Add(x[i], y1_fit[i]);
                if (c2_check != 0)
                list2_fit.Add(x[i], y2_fit[i]);
                if (c3_check != 0)
                list3_fit.Add(x[i], y3_fit[i]);
                if (c4_check != 0)
                list4_fit.Add(x[i], y4_fit[i]);
                if (c5_check != 0)
                list5_fit.Add(x[i], y5_fit[i]);



            }




            if (c1_check!=0)
            {
                LineItem myCurve1 = myPane3.AddCurve("IO_Observed", list1_obs, Color.Pink, SymbolType.Circle);
                LineItem myCurve1_v = myPane3_v.AddCurve("IO_Observed", list1_obs, Color.Pink, SymbolType.Circle);

                LineItem myCurve11 = myPane3.AddCurve("IO_Fitted", list1_fit, Color.Pink, SymbolType.None);
                LineItem myCurve11_v = myPane3_v.AddCurve("IO_Fitted", list1_fit, Color.Pink, SymbolType.None);

                myCurve1.Line.IsVisible = false;
                myCurve1_v.Line.IsVisible = false;


            }
            if (c2_check != 0)
            {
                LineItem myCurve2 = myPane3.AddCurve("DCR_Observed", list2_obs, Color.Red, SymbolType.Circle);
                LineItem myCurve2_v = myPane3_v.AddCurve("DCR_Observed", list2_obs, Color.Red, SymbolType.Circle);

                LineItem myCurve22 = myPane3.AddCurve("DCR_Fitted", list2_fit, Color.Red, SymbolType.None);
                LineItem myCurve22_v = myPane3_v.AddCurve("DCR_Fitted", list2_fit, Color.Red, SymbolType.None);

                myCurve2.Line.IsVisible = false;
                myCurve2_v.Line.IsVisible = false;



            }
            if (c3_check != 0)
            {
                LineItem myCurve3 = myPane3.AddCurve("LS_Observed", list3_obs, Color.Blue, SymbolType.Circle);
                LineItem myCurve3_v = myPane3_v.AddCurve("LS_Observed", list3_obs, Color.Blue, SymbolType.Circle);

                LineItem myCurve33 = myPane3.AddCurve("LS_Fitted", list3_fit, Color.Blue, SymbolType.None);
                LineItem myCurve33_v = myPane3_v.AddCurve("LS_Fitted", list3_fit, Color.Blue, SymbolType.None);

                myCurve3.Line.IsVisible = false;
                myCurve3_v.Line.IsVisible = false;

            } if (c4_check != 0)
            {
                LineItem myCurve4 = myPane3.AddCurve("LSR_Observed", list4_obs, Color.Green, SymbolType.Circle);
                LineItem myCurve4_v = myPane3_v.AddCurve("LSR_Observed", list4_obs, Color.Green, SymbolType.Circle);

                LineItem myCurve44 = myPane3.AddCurve("LSR_Fitted", list4_fit, Color.Green, SymbolType.None);
                LineItem myCurve44_v = myPane3_v.AddCurve("LSR_Fitted", list4_fit, Color.Green, SymbolType.None);

                myCurve4.Line.IsVisible = false;
                myCurve4_v.Line.IsVisible = false;



            } if (c5_check != 0)
            {
                LineItem myCurve5 = myPane3.AddCurve("CP_Observed", list5_obs, Color.Gold, SymbolType.Circle);
                LineItem myCurve5_v = myPane3_v.AddCurve("CP_Observed", list5_obs, Color.Gold, SymbolType.Circle);

                LineItem myCurve55 = myPane3.AddCurve("CP_Fitted", list5_fit, Color.Gold, SymbolType.None);
                LineItem myCurve55_v = myPane3_v.AddCurve("CP_Fitted", list5_fit, Color.Gold, SymbolType.None);

                myCurve5.Line.IsVisible = false;
                myCurve5_v.Line.IsVisible = false;


            }

            myPane3.Legend.IsShowLegendSymbols = true;
            myPane3_v.Legend.IsShowLegendSymbols = true;

            LineItem myCurve0 = myPane3.AddCurve("TC_Observed", list0_obs, Color.Black, SymbolType.Circle);
            LineItem myCurve0_v = myPane3_v.AddCurve("TC_Observed", list0_obs, Color.Black, SymbolType.Circle);

            LineItem myCurve00 = myPane3.AddCurve("TC_Fitted", list0_fit, Color.Black, SymbolType.None);
            LineItem myCurve00_v = myPane3_v.AddCurve("TC_Fitted", list0_fit, Color.Black, SymbolType.None);

            myCurve0.Line.IsVisible = false;
            myCurve0_v.Line.IsVisible = false;
            zedGraphControl3.AxisChange();
            zedGraphControl3_v.AxisChange();

        }



        GraphPane myPane1, myPane4;

//        private void Draw1()
//        {
//            myPane1 = zedGraphControl1.GraphPane;
//            zedGraphControl1.GraphPane.CurveList.Clear();
//            zedGraphControl1.GraphPane.GraphObjList.Clear();
//            zedGraphControl1.AxisChange();
//            zedGraphControl1.Invalidate();
//            myPane1.Title.Text = "Max Response Output";
//            myPane1.XAxis.Title.Text = Convert.ToString(comboBox1.Items[comboBox1.SelectedIndex]);
//            if (FEMA_check == 1)
//                myPane1.XAxis.Title.Text = "Sa (g) @ Tn";
//            else
//                myPane1.XAxis.Title.Text = "PGA (g)";
            
////Maximum Story Shear
////Maximum Drift Ratio
////Maximum Story Drift
////Damage Index

//            int length = checkedListBox1.Items.Count;
//            for (int i = 0; i < length; i++)
//            {
//                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked) //test
//                {
//                    if (comboBox1.SelectedIndex == 0)
//                    {
//                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_Max_ss[i], Color.Black, SymbolType.Circle);
//                        myPane1.YAxis.Title.Text = "Maximum Story Shear";
//                    }
//                    if (comboBox1.SelectedIndex == 1)
//                    {
//                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_Max_dr[i], Color.Black, SymbolType.Circle);
//                        myPane1.YAxis.Title.Text = "Maximum Drift Ratio";
//                    }
//                    if (comboBox1.SelectedIndex == 2)
//                    {
//                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_Max_sd[i], Color.Black, SymbolType.Circle);
//                        myPane1.YAxis.Title.Text = "Maximum Story Drift";
//                    }
//                    if (comboBox1.SelectedIndex == 3)
//                    {
//                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_damage[i], Color.Black, SymbolType.Circle);
//                        myPane1.YAxis.Title.Text = "Damage Index";
//                    }
//                }
//            }

//            zedGraphControl1.AxisChange();
//        }

        private void Draw1(ZedGraphControl zedGraphControl1)
        {
            myPane1 = zedGraphControl1.GraphPane;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            myPane1.Title.Text = "Max Response Output";
            myPane1.XAxis.Title.Text = Convert.ToString(comboBox1.Items[comboBox1.SelectedIndex]);
            if (FEMA_check == 1)
                myPane1.YAxis.Title.Text = "Sa[@Tn, 5%] (g)";
            else
                myPane1.YAxis.Title.Text = "PGA (g)" ;

            //Maximum Story Shear
            //Maximum Drift Ratio
            //Maximum Story Drift
            //Damage Index

            int length = checkedListBox1.Items.Count;
            for (int i = 0; i < length; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked) //test
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_Max_ss[i], Color.Black, SymbolType.Circle);
                        myPane1.XAxis.Title.Text = "Maximum Story Shear " + units_force;
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_Max_dr[i], Color.Black, SymbolType.Circle);
                        myPane1.XAxis.Title.Text = "Maximum Drift Ratio (%)";
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_Max_sd[i], Color.Black, SymbolType.Circle);
                        myPane1.XAxis.Title.Text = "Maximum Story Drift";
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        LineItem myCurve = myPane1.AddCurve(Convert.ToString(batch[i, 4]), list_damage[i], Color.Black, SymbolType.Circle);
                        myPane1.XAxis.Title.Text = "Damage Index";
                    }
                }
            }

            zedGraphControl1.AxisChange();
        }
        private void Draw2(ZedGraphControl zedGraphControl4)
        {
            myPane4 = zedGraphControl4.GraphPane;
            zedGraphControl4.GraphPane.CurveList.Clear();
            zedGraphControl4.GraphPane.GraphObjList.Clear();
            zedGraphControl4.AxisChange();
            zedGraphControl4.Invalidate();
            if(comboBox3.SelectedIndex!=-1)
                myPane4.Title.Text = "Response Output at Intensity Measure=" + Convert.ToString(comboBox3.Items[comboBox3.SelectedIndex]);
            myPane4.XAxis.Title.Text = Convert.ToString(comboBox2.Items[comboBox2.SelectedIndex]);
            myPane4.YAxis.Title.Text = "Story No.";

            int SF_index = comboBox3.SelectedIndex;

            int length = checkedListBox1.Items.Count;
            for (int i = 0; i < length; i++)
            {
                if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked) //test
                {
                    //STORY SHEAR    DRIFT RATIO(%)    STORY DRIFT    DISPLACEMENT      VELOCITY    ACCELERATION    STORY VELOCITY DRIFT
                    if (comboBox2.SelectedIndex == 0)
                    {
                        
                        
                        LineItem myCurve = myPane4.AddCurve(Convert.ToString(batch[i, 4]), list_ss[i, SF_index], Color.Black, SymbolType.Circle);
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        LineItem myCurve = myPane4.AddCurve(Convert.ToString(batch[i, 4]), list_dr[i, SF_index], Color.Black, SymbolType.Circle);
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        LineItem myCurve = myPane4.AddCurve(Convert.ToString(batch[i, 4]), list_sd[i, SF_index], Color.Black, SymbolType.Circle);
                    }
                    if (comboBox2.SelectedIndex == 3)
                    {
                        LineItem myCurve = myPane4.AddCurve(Convert.ToString(batch[i, 4]), list_disp[i, SF_index], Color.Black, SymbolType.Circle);
                    }
                    if (comboBox2.SelectedIndex == 4)
                    {
                        LineItem myCurve = myPane4.AddCurve(Convert.ToString(batch[i, 4]), list_vel[i, SF_index], Color.Black, SymbolType.Circle);
                    }
                    if (comboBox2.SelectedIndex == 5)
                    {
                        LineItem myCurve = myPane4.AddCurve(Convert.ToString(batch[i, 4]), list_acc[i, SF_index], Color.Black, SymbolType.Circle);

                    }
                    if (comboBox2.SelectedIndex == 6)
                    {
                        LineItem myCurve = myPane4.AddCurve(Convert.ToString(batch[i, 4]), list_svd[i, SF_index], Color.Black, SymbolType.Circle);
                    }

                }
            }

            zedGraphControl4.AxisChange();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw1(zedGraphControl1);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw1(zedGraphControl1);

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw2(zedGraphControl4);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw2(zedGraphControl4);

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw2(zedGraphControl4);

        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void zedGraphControl3_DoubleClick(object sender, EventArgs e)
        {
            graph3.ShowDialog();
            //GraphViewer gv = new GraphViewer(zedGraphControl3,myPane3);
            //gv.ShowDialog();


        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl3_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_DoubleClick(object sender, EventArgs e)
        {
            GraphViewer gv = new GraphViewer();
            Draw1(gv.zedGraphControl1);
            gv.ShowDialog();
            
            //gv.ShowDialog();

        }

        private void zedGraphControl4_DoubleClick(object sender, EventArgs e)
        {
            GraphViewer gv = new GraphViewer();
            Draw2(gv.zedGraphControl1);
            gv.ShowDialog();
            //GraphViewer gv = new GraphViewer(zedGraphControl4,myPane4);
            //gv.ShowDialog();

        }

        private void zedGraphControl2_DoubleClick(object sender, EventArgs e)
        {
            graph2.ShowDialog();
            //GraphViewer gv = new GraphViewer(zedGraphControl2,myPane2);
            //gv.ShowDialog();

        }

        private void zedGraphControl4_Load(object sender, EventArgs e)
        {

        }

        private void btn_cklt1_selectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);

            Draw1(zedGraphControl1);
               
        }

        private void btn_cklt1_clearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);

            Draw1(zedGraphControl1);
        }

        private void btn_cklt2_selectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, true);

            Draw2(zedGraphControl4);
        }

        private void btn_cklt2_clearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);

            Draw2(zedGraphControl4);
        }


    }
}

