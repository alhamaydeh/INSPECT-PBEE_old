using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWizard
{
    public partial class FEMA_opt : Form
    {
        public FEMA_opt(bool units_c, double h_c)
        {
            InitializeComponent();

            units = units_c;
            h = h_c;

            if (units)
                h /= 12;
            else
                h /= 1000;
            SSF = new double[12][];
            SSFD = new double[12][];
            SSF[0] = new double[9] { 0, 1, 1.1, 1.5, 2, 3, 4, 6, 8 };
            SSF[1] = new double[9] { 0.5, 1, 1.02, 1.04, 1.06, 1.08, 1.09, 1.12, 1.14 };
            SSF[2] = new double[9] { 0.6, 1, 1.02, 1.05, 1.07, 1.09, 1.11, 1.13, 1.16 };
            SSF[3] = new double[9] { 0.7, 1, 1.03, 1.06, 1.08, 1.10, 1.12, 1.15, 1.18 };
            SSF[4] = new double[9] { 0.8, 1, 1.03, 1.06, 1.08, 1.11, 1.14, 1.17, 1.20 };
            SSF[5] = new double[9] { 0.9, 1, 1.03, 1.07, 1.09, 1.13, 1.15, 1.19, 1.22 };
            SSF[6] = new double[9] { 1.0, 1, 1.04, 1.08, 1.10, 1.14, 1.17, 1.21, 1.25 };
            SSF[7] = new double[9] { 1.1, 1, 1.04, 1.08, 1.10, 1.15, 1.18, 1.23, 1.27 };
            SSF[8] = new double[9] { 1.2, 1, 1.04, 1.09, 1.12, 1.17, 1.20, 1.25, 1.30 };
            SSF[9] = new double[9] { 1.3, 1, 1.05, 1.10, 1.13, 1.18, 1.22, 1.27, 1.32 };
            SSF[10] = new double[9] { 1.4, 1, 1.05, 1.10, 1.14, 1.19, 1.23, 1.30, 1.35 };
            SSF[11] = new double[9] { 1.5, 1, 1.05, 1.11, 1.15, 1.21, 1.25, 1.32, 1.37 };
            //

            //SSD

            SSFD[0] = new double[9] { 0, 1, 1.1, 1.5, 2, 3, 4, 6, 8 };
            SSFD[1] = new double[9] { 0.5, 1, 1.05, 1.1, 1.13, 1.18, 1.22, 1.28, 1.33 };
            SSFD[2] = new double[9] { 0.6, 1, 1.05, 1.11, 1.14, 1.2, 1.24, 1.3, 1.36 };
            SSFD[3] = new double[9] { 0.7, 1, 1.06, 1.11, 1.15, 1.21, 1.25, 1.32, 1.38 };
            SSFD[4] = new double[9] { 0.8, 1, 1.06, 1.12, 1.16, 1.22, 1.27, 1.35, 1.41 };
            SSFD[5] = new double[9] { 0.9, 1, 1.06, 1.13, 1.17, 1.24, 1.29, 1.37, 1.44 };
            SSFD[6] = new double[9] { 1.0, 1, 1.07, 1.13, 1.18, 1.25, 1.31, 1.39, 1.46 };
            SSFD[7] = new double[9] { 1.1, 1, 1.07, 1.14, 1.19, 1.27, 1.32, 1.41, 1.49 };
            SSFD[8] = new double[9] { 1.2, 1, 1.07, 1.15, 1.2, 1.28, 1.34, 1.44, 1.52 };
            SSFD[9] = new double[9] { 1.3, 1, 1.08, 1.16, 1.21, 1.29, 1.36, 1.46, 1.55 };
            SSFD[10] = new double[9] { 1.4, 1, 1.08, 1.16, 1.22, 1.31, 1.38, 1.49, 1.58 };
            SSFD[11] = new double[9] { 1.5, 1, 1.08, 1.17, 1.23, 1.32, 1.4, 1.51, 1.61 };
            //

            //other 1-dim arrays;

            BTOT_arr = new double[28] { 0.275, 0.3, 0.325, 0.35, 0.375, 0.4, 0.425, 0.45, 0.475, 0.5, 0.525, 0.55, 0.575, 0.6, 0.625, 0.65, 0.675, 0.7, 0.725, 0.75, 0.775, 0.8, 0.825, 0.85, 0.875, 0.9, 0.925, 0.95 };

            ACMR10_arr = new double[28] { 1.42, 1.47, 1.52, 1.57, 1.62, 1.67, 1.72, 1.78, 1.84, 1.9, 1.96, 2.02, 2.09, 2.16, 2.23, 2.3, 2.38, 2.45, 2.53, 2.61, 2.7, 2.79, 2.88, 2.97, 3.07, 3.17, 3.27, 3.38 };
            ACMR20_arr = new double[28] { 1.26, 1.29, 1.31, 1.34, 1.37, 1.4, 1.43, 1.46, 1.49, 1.52, 1.56, 1.59, 1.62, 1.66, 1.69, 1.73, 1.76, 1.8, 1.84, 1.88, 1.92, 1.96, 2, 2.04, 2.09, 2.13, 2.18, 2.22 };
            T_CU = new double[25] { 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.2, 1.4, 1.6, 1.8, 2, 2.2, 2.4, 2.6, 2.8, 3, 3.5, 4, 4.5, 5 };
            NRT_N = new double[25] { 0.936, 1.02, 0.939, 0.901, 0.886, 0.855, 0.833, 0.805, 0.739, 0.633, 0.571, 0.476, 0.404, 0.356, 0.319, 0.284, 0.258, 0.23, 0.21, 0.19, 0.172, 0.132, 0.104, 0.086, 0.072 };
            NRT_F = new double[25] { 0.779, 0.775, 0.761, 0.748, 0.749, 0.736, 0.602, 0.537, 0.449, 0.399, 0.348, 0.301, 0.256, 0.208, 0.168, 0.148, 0.133, 0.118, 0.106, 0.091, 0.08, 0.063, 0.052, 0.046, 0.041 };


            object sender = new object();
            EventArgs e = new EventArgs();

            radioButton8_CheckedChanged(sender, e);
            radioButton9_CheckedChanged(sender, e);
            radioButton10_CheckedChanged(sender, e);
            radioButton11_CheckedChanged(sender, e);
            radioButton3_CheckedChanged(sender, e);
            radioButton4_CheckedChanged(sender, e);
            radioButton5_CheckedChanged(sender, e);
            radioButton7_CheckedChanged(sender, e);
            near_check_CheckedChanged(sender, e);
        }




        String DTable;
        bool edit;

        String[] batch_files;

        int y;
        bool units;
        double h;
        double g;
        decimal SM1;
        decimal TS;
        decimal SMS;
        public double[][] SSF;
        double[][] SSFD;

        double[] BTOT_arr;
        double[] ACMR10_arr;
        double[] ACMR20_arr;
        double[] T_CU;
        double[] NRT_N;
        double[] NRT_F;



        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                SM1 = 0.9M;
                TS = 0.6M;
                SMS = 1.5M;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                SM1 = 0.3M;
                TS = 0.4M;
                SMS = 0.75M;

            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                SM1 = 0.2M;
                TS = 0.4M;
                SMS = 0.5M;

            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
            {
                SM1 = 0.1M;
                TS = 0.4M;
                SMS = 0.25M;

            }
        }

        decimal Ta;

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
                return;

            if (units)
            {
                Ta = Convert.ToDecimal(0.028 * Math.Pow(h, 0.8));
            }
            else
            {
                Ta = Convert.ToDecimal(0.0724 * Math.Pow(h, 0.8));
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton4.Checked)
                return;
            if (units)
            {
                Ta = Convert.ToDecimal(0.016 * Math.Pow(h, 0.9));
            }
            else
            {
                Ta = Convert.ToDecimal(0.0466 * Math.Pow(h, 0.9));
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton5.Checked)
                return;
            if (units)
            {
                Ta = Convert.ToDecimal(0.03 * Math.Pow(h, 0.75));
            }
            else
            {
                Ta = Convert.ToDecimal(0.0731 * Math.Pow(h, 0.75));
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton7.Checked)
                return;
            if (units)
            {
                Ta = Convert.ToDecimal(0.02 * Math.Pow(h, 0.75));
            }
            else
            {
                Ta = Convert.ToDecimal(0.0488 * Math.Pow(h, 0.75));
            }
        }

        private void near_check_CheckedChanged(object sender, EventArgs e)
        {
            if (near_check.Checked)
            {
                checkedListBox1.Enabled = false;
                checkedListBox2.Enabled = true;
            }
            else
            {
                checkedListBox1.Enabled = true;
                checkedListBox2.Enabled = false;

            }
        }

        private void radioButtonYN1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonYN1.Checked)
            {
                checkedListBox1.Enabled = true;
                checkedListBox2.Enabled = false;
            }
            else
            {
                checkedListBox1.Enabled = false;
                checkedListBox2.Enabled = true;

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        double b1;
        double b1_check;
        double b2;
        double b2_check;
        double b3;
        double b3_check;

      
 b1_post t1 = new b1_post();
        private void button6_Click(object sender, EventArgs e)
        {
           
            t1.ShowDialog();

        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                for (int i = 1; i < checkedListBox2.Items.Count; i++)
                    checkedListBox2.SetItemCheckState(i, CheckState.Checked);
            }
            if (e.Index == 0 && e.NewValue == CheckState.Unchecked)
            {
                for (int i = 1; i < checkedListBox2.Items.Count; i++)
                    checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);

            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                for (int i = 1; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
            if (e.Index == 0 && e.NewValue == CheckState.Unchecked)
            {
                for (int i = 1; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FEMA_H1 temp = new FEMA_H1();
            temp.Show();
        }

        b2_post t2 = new b2_post();

        private void button7_Click(object sender, EventArgs e)
        {
            t2.ShowDialog();

        }

        b3_post t3 = new b3_post();

        private void button8_Click(object sender, EventArgs e)
        {
            t3.ShowDialog();


        }

        public double SMT;
        public double Cu;
        public double SD1;
        public double T;
        public double BTOT;
        public double SF_N;
        public double SF_F;
        double interpolate(double x0, double y0, double x1, double y1, double x)
        {
            if (x <= x0)
                return y0;
            if (x >= x1)
                return y1;
            if (x0 == x1)
                return x0;
            return y0 * (x - x1) / (x0 - x1) + y1 * (x - x0) / (x1 - x0);
        }
        /*
        public double calc_PGAonSa(double T, int typ)
        {

            double[] T_sa = { 0.01, 0.02, 0.022, 0.025, 0.029, 0.03, 0.032, 0.035, 0.036, 0.04, 0.042, 0.044, 0.045, 0.046, 0.048, 0.05, 0.055, 0.06, 0.065, 0.067, 0.07, 0.075, 0.08, 0.085, 0.09, 0.095, 0.1, 0.11, 0.12, 0.13, 0.133, 0.14, 0.15, 0.16, 0.17, 0.18, 0.19, 0.2, 0.22, 0.24, 0.25, 0.26, 0.28, 0.29, 0.3, 0.32, 0.34, 0.35, 0.36, 0.38, 0.4, 0.42, 0.44, 0.45, 0.46, 0.48, 0.5, 0.55, 0.6, 0.65, 0.667, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.2, 2.4, 2.5, 2.6, 2.8, 3, 3.2, 3.4, 3.5, 3.6, 3.8, 4, 4.2, 4.4, 4.6, 4.8, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10, 11, 12, 13, 14, 15, 20 };

            double[] PGAonSa_FAR = { 1.12728517, 1.101873333, 1.085648428, 1.069900352, 1.04155715, 1.033199911, 1.027824788, 1.022532303, 1.016858432, 0.998696982, 0.98613952, 0.97693505, 0.975746687, 0.973600326, 0.957820009, 0.940659133, 0.908552542, 0.891033733, 0.856671147, 0.845773644, 0.832123985, 0.813654081, 0.78341332, 0.749857577, 0.728713086, 0.713941555, 0.704129378, 0.648294901, 0.583679069, 0.557128111, 0.548412355, 0.548480498, 0.540022298, 0.537239623, 0.521683221, 0.49585988, 0.503623225, 0.493937693, 0.484015418, 0.496222925, 0.491289552, 0.480481334, 0.488945398, 0.492470426, 0.48992809, 0.488154615, 0.48854842, 0.488209635, 0.494433933, 0.505364292, 0.5041819, 0.507417461, 0.50076976, 0.493946597, 0.491597305, 0.500017837, 0.504926291, 0.545492972, 0.612299791, 0.633500584, 0.643522523, 0.678403939, 0.759422835, 0.821084598, 0.845462609, 0.897903424, 0.974112455, 1.042807448, 1.167375659, 1.233659183, 1.342411961, 1.435096532, 1.539819652, 1.69294551, 1.883646094, 2.091343981, 2.234471182, 2.324617621, 2.558419856, 2.869801278, 3.035936833, 3.240695661, 3.733926192, 4.169199371, 4.491438587, 4.882599649, 5.13282308, 5.345590296, 5.707235721, 6.056539222, 6.369639828, 6.568989455, 6.739070328, 7.084701589, 7.418592866, 8.25266449, 9.062764158, 10.18858806, 11.90078878, 13.66499223, 15.65047928, 18.06088155, 20.9659014, 24.29106016, 27.78895003, 35.62580876, 45.47503852, 57.14114499, 70.62466973, 85.14510262, 173.1329988 };


            double[] PGAonSa_NEAR = { 1.07728643, 1.010830462, 0.986461199, 0.935904648, 0.884158196, 0.883060099, 0.875718828, 0.887077573, 0.885663894, 0.857146817, 0.83280225, 0.81241195, 0.801745304, 0.791695351, 0.783687781, 0.773129427, 0.769739215, 0.73680321, 0.699880173, 0.695163999, 0.688323714, 0.682384669, 0.686259561, 0.676123852, 0.671543026, 0.664413308, 0.653041882, 0.653924009, 0.650966191, 0.630847841, 0.629685786, 0.62799529, 0.62725386, 0.62400705, 0.61040706, 0.595676746, 0.587813975, 0.588543913, 0.597260738, 0.605691374, 0.600152194, 0.587529235, 0.554734802, 0.549341295, 0.547590036, 0.555177484, 0.570473794, 0.578827798, 0.582809939, 0.596892942, 0.590002288, 0.596149849, 0.612254622, 0.613943823, 0.618473585, 0.636615325, 0.652814626, 0.652260735, 0.652280887, 0.666692144, 0.674535245, 0.676928801, 0.677119091, 0.714577848, 0.75960154, 0.814630994, 0.87267809, 0.935068316, 1.018129903, 1.095908233, 1.208913166, 1.336140035, 1.434801868, 1.515897427, 1.586901132, 1.687933448, 1.771655974, 1.867121272, 2.050864044, 2.268761633, 2.362385931, 2.466002725, 2.719792646, 2.958822334, 3.230859204, 3.518217263, 3.666120205, 3.819273861, 4.173520924, 4.560402375, 4.877519915, 5.176297068, 5.533739337, 5.926415279, 6.359607444, 7.709447251, 9.179656675, 10.86007726, 13.02923118, 15.07993381, 17.4767361, 20.1147159, 22.95528843, 26.28771692, 29.64841219, 37.50707904, 46.84385681, 57.24393065, 68.20158945, 79.2969345, 147.7607778 };


            int i;
            for (i = 0; i < T_sa.Length; i++)
            {
                if (T <= T_sa[i])
                    break;

            }


            //If naer
            if (typ == 1)
            {
                if (T <= T_sa[0])
                    return PGAonSa_FAR[0];
                if (T >= T_sa[T_sa.Length - 1])
                    return PGAonSa_NEAR[T_sa.Length - 1];
                else
                    return interpolate(T_sa[i - 1], PGAonSa_NEAR[i - 1], T_sa[i], PGAonSa_NEAR[i], T);
            }

            //if far

            if (typ == 2)
            {
                if (T <= T_sa[0])
                    return PGAonSa_FAR[0];
                if (T >= T_sa[T_sa.Length - 1])
                    return PGAonSa_FAR[T_sa.Length - 1];
                else
                    return interpolate(T_sa[i - 1], PGAonSa_FAR[i - 1], T_sa[i], PGAonSa_FAR[i], T);
            }
            return 0;

        }
        */
        public double calc_SNRT(double T, int typ)
        {

            int i;
            for (i = 0; i < T_CU.Length; i++)
            {
                if (T <= T_CU[i])
                    break;

            }

            //if Near

            if (typ == 1)
            {
                if (T <= T_CU[0])
                    return NRT_N[0];
                if (T >= T_CU[T_CU.Length - 1])
                    return NRT_N[T_CU.Length - 1];
                else
                    return interpolate(T_CU[i - 1], NRT_N[i - 1], T_CU[i], NRT_N[i], T);
            }

            //If far
            if (typ == 2)
            {
                if (T <= T_CU[0])
                    return NRT_F[0];
                if (T >= T_CU[T_CU.Length - 1])
                    return NRT_F[T_CU.Length - 1];
                else
                    return interpolate(T_CU[i - 1], NRT_F[i - 1], T_CU[i], NRT_F[i], T);
            }

            return 0;
        }

        public double calc_SSF(double t, double u, int typ)
        {
            if (typ == 1)
            {
                Interpol1 inp1 = new Interpol1();
                return inp1.Interpolate(t, u);
            }
            if (typ == 2)
            {
                Interpol2 inp2 = new Interpol2();
                return inp2.Interpolate(t, u);
            }
            else
                return 0;
        }
        public double SSF_value;
      //  public double PGAonSa_N, PGAonSa_F;
        public double ACMR20;
        public double ACMR10;
        private void wizardSample_Cancel(object sender, CancelEventArgs e)
        {

           



            SD1 = (0.666667) * Convert.ToDouble(SM1);
            SD1 = Math.Round(SD1, 2);
            if (SD1 >= 0.4 || SD1 == 0.3)
                Cu = 1.4;
            else if (SD1 <= 0.3 && SD1 > 0.2)
                Cu = interpolate(0.3, 1.4, 0.2, 1.5, SD1); //Cu = 1.5;
            else if (SD1 <= 0.2 && SD1 > 0.15)
                Cu = interpolate(0.2, 1.5, 0.15, 1.6, SD1);        //Cu = 1.6;
            else if (SD1 <= 0.15 && SD1 > 0.1)
                Cu = interpolate(0.15, 1.6, 0.1, 1.7, SD1);
            else if (SD1 <= 0.1)
                Cu = 1.7;


            T = Cu * Convert.ToDouble(Ta);


            if (T < 0.25)
                T = 0.25;

            if (Convert.ToDecimal(T) <= TS)
                SMT = Convert.ToDouble(SMS);
            else
                SMT = Convert.ToDouble(SM1 / Convert.ToDecimal(T));

            double BRTR = 0.1 + 0.1 * Convert.ToDouble(mu.Text);
            if (BRTR > 0.4)
                BRTR = 0.4;
            if (BRTR < 0.2)
                BRTR = 0.2;
           // b1_post t1 = new b1_post();
            
            BTOT = Math.Sqrt(Math.Pow(t1.y[0], 2) + Math.Pow(t2.y[0], 2) + Math.Pow(t3.y[0], 2) + Math.Pow(Convert.ToDouble(BRTR), 2));

            if (BTOT == null)
                BTOT = 0;
            /////
            int cc;
            double SNRT_N = calc_SNRT(T, 1); //1:Near, 2:Far
            double SNRT_F = calc_SNRT(T, 2);
            for (cc = 0; cc < BTOT_arr.Length; cc++)
            {
                if (BTOT <= BTOT_arr[cc])
                    break;

            }

            if (radioButton8.Checked)
                SSF_value = calc_SSF(T, Convert.ToDouble(mu.Text), 2);
            else
                SSF_value = calc_SSF(T, Convert.ToDouble(mu.Text), 1);

            if (cc != BTOT_arr.Length && cc != 0)
            {
                ACMR10 = interpolate(BTOT_arr[cc - 1], ACMR10_arr[cc - 1], BTOT_arr[cc], ACMR10_arr[cc], BTOT);
                ACMR20 = interpolate(BTOT_arr[cc - 1], ACMR20_arr[cc - 1], BTOT_arr[cc], ACMR20_arr[cc], BTOT);
            }
            else
            {
                ACMR10 = interpolate(BTOT_arr[0], ACMR10_arr[0], BTOT_arr[0], ACMR10_arr[0], BTOT_arr[0]);
                ACMR20 = interpolate(BTOT_arr[0], ACMR20_arr[0], BTOT_arr[0], ACMR20_arr[0], BTOT_arr[0]);
            }
            SF_N = (ACMR10 / SSF_value) * (SMT / SNRT_N);
            SF_F = (ACMR10 / SSF_value) * (SMT / SNRT_F);
         //   PGAonSa_N = calc_PGAonSa(T, 1);
          //  PGAonSa_F = calc_PGAonSa(T, 2);
        }

        private void ITDMP_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void wizardPage1_Click(object sender, EventArgs e)
        {
            //SSF, Smt, FEMA_check
        }

        private void wizardPage4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                c1.Enabled = true;
            }
            else
            {
                c1.Enabled = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                c2.Enabled = true;
            }
            else
            {
                c2.Enabled = false;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                c3.Enabled = true;
            }
            else
            {
                c3.Enabled = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                c4.Enabled = true;
            }
            else
            {
                c4.Enabled = false;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                c5.Enabled = true;
            }
            else
            {
                c5.Enabled = false;

            }
        }

        private void checkbox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox6.Checked)
                c6_drift.Enabled = true;
            else
                c6_drift.Enabled = false;
        }

        private void checkbox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox7.Checked)
                c6_damage.Enabled = true;
            else
                c6_damage.Enabled = false;
        }

        private void FEMA_opt_Load(object sender, EventArgs e)
        {

        }

    }
}
