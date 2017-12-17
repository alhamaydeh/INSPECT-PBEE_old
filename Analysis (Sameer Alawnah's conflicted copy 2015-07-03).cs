using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SampleWizard.Properties;


namespace SampleWizard
{
    public partial class Analysis : Form
    {
        SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();

        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        String temp_in = "";
        String DTable;
        bool edit;
        String WHFILE_t;
        String WVFILE_t;

        String[] batch_files;
        public Analysis()
        {
            InitializeComponent();
        }
        int y;
        bool units;
        double h;
        double g;
        decimal SM1;
        decimal TS;
        decimal SMS;
        double[][] SSF;
        double[][] SSFD;

        double[] BTOT_arr;
        double[] ACMR10_arr;
        double[] ACMR20_arr;
        double[] T_CU;
        double[] NRT_N;
        double[] NRT_F;
        bool loading = true;
        public Analysis(String name, bool edit_c, bool units_c, double Total_Elv)
        {
            InitializeComponent();

            //SSF
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



            h = Total_Elv;
            edit = edit_c;
            units = units_c;
            if (units)
                h /= 12;
            else
                h /= 1000;
            DTable = name;
            wizardSample.CancelText = "Finish";
            wizardSample.HelpVisible = true;




            if (units)
                g = 32.2;
            else
                g = 9.81;

            if (!edit)
            {
                SM1 = 0.9M;
                TS = 0.6M;
                SMS = 1.5M;
                if (units)
                {
                    Ta = Convert.ToDecimal(0.028 * Math.Pow(h, 0.8));
                }
                else
                {
                    Ta = Convert.ToDecimal(0.0724 * Math.Pow(h, 0.8));
                }
                if (Ta <= TS)
                    SMT = Convert.ToDouble(SMS);
                else
                    SMT = Convert.ToDouble(SM1 / Ta);

                WHFILE_t = "";
                WVFILE_t = "";
                IOPT.SelectedIndex = 0;
                ITYP.SelectedIndex = 0;
                JOPT.SelectedIndex = 0;
                POWER2.SelectedIndex = 0;
                ITDMP.SelectedIndex = 0;
                IGMOT.SelectedIndex = 0;
                IWV.SelectedIndex = 0;
                ICNTRL.SelectedIndex = 0;
                ITPRNT.SelectedIndex = 0;
                NPRNT_1.SelectedIndex = 0;




                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();




                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "L_NLC";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "L_NLJ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "L_NLM";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "L_NLU";
                cmd.ExecuteNonQuery();

                //EDIT_4-10
                //cmd.CommandText = "DROP TABLE IF EXISTS FEMA_B1";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS FEMA_B2";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS FEMA_B3";
                //cmd.ExecuteNonQuery();



                //cmd.CommandText = @"create table FEMA_B1 ([id] integer  NOT NULL PRIMARY KEY, [b1] float null)";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = @"create table FEMA_B2 ([id] integer  NOT NULL PRIMARY KEY, [b2] float null)";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = @"create table FEMA_B3 ([id] integer  NOT NULL PRIMARY KEY, [b3] float null)";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = @"create table [" + DTable + @"L_NLC] ([IL] integer  NOT NULL PRIMARY KEY,
                                        [IFV] float  NULL,
                                        [LV] float  NULL,
                                        [JV] float  NULL,
                                        [FV] float  NULL
                                                        )";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"create table [" + DTable + @"L_NLJ] (
                                                [IL] integer  NOT NULL PRIMARY KEY,
                                                [LF] float  NULL,
                                                [IF_1] float  NULL,
                                                [FL] float  NULL
                                                )";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"create table [" + DTable + @"L_NLM] (
                                                [IL] integer  NOT NULL PRIMARY KEY,
                                                [IBM] float  NULL,
                                                [FM1] float  NULL,
                                                [FM2] float  NULL
                                                )";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"create table [" + DTable + @"L_NLU] (
                                                [IL] integer  NOT NULL PRIMARY KEY,
                                                [IBN] float  NULL,
                                                [FU] float  NULL
                                                )";
                cmd.ExecuteNonQuery();


                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();
            }
            else
            {
                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                SQLiteCommand cmd_load = new SQLiteCommand(cn);
                cn.Open();
                cmd_load.CommandText = "begin"; cmd_load.ExecuteNonQuery();

                cmd_load.CommandText = "select * from " + DTable;
                SQLiteDataReader reader = cmd_load.ExecuteReader();
                reader.Read();
                BSPRNT.Text = Convert.ToString(reader["BSPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DAMP.Text = Convert.ToString(reader["DAMP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DFPRNT.Text = Convert.ToString(reader["DFPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DRFLIM.Text = Convert.ToString(reader["DRFLIM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DRFLIM_1.Text = Convert.ToString(reader["DRFLIM_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DTCAL.Text = Convert.ToString(reader["DTCAL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DTCAL_1.Text = Convert.ToString(reader["DTCAL_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                Limits.DTCAL = Convert.ToDouble(DTCAL.Text);
                DTINP.Text = Convert.ToString(reader["DTINP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DTOUT.Text = Convert.ToString(reader["DTOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                DTPRNT.Text = Convert.ToString(reader["DTPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                EXPK.Text = Convert.ToString(reader["EXPK"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                GMAXH.Text = Convert.ToString(reader["GMAXH"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                GMAXV.Text = Convert.ToString(reader["GMAXV"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICDPRNT_1.YesNo = Convert.ToString(reader["ICDPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICDPRNT_2.YesNo = Convert.ToString(reader["ICDPRNT_2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICDPRNT_3.YesNo = Convert.ToString(reader["ICDPRNT_3"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICDPRNT_4.YesNo = Convert.ToString(reader["ICDPRNT_4"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICDPRNT_5.YesNo = Convert.ToString(reader["ICDPRNT_5"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICNTRL.SelectedIndex = Convert.ToInt16(reader["ICNTRL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();

                ICPRNT_1.YesNo = Convert.ToString(reader["ICPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICPRNT_2.YesNo = Convert.ToString(reader["ICPRNT_2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICPRNT_3.YesNo = Convert.ToString(reader["ICPRNT_3"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICPRNT_4.YesNo = Convert.ToString(reader["ICPRNT_4"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ICPRNT_5.YesNo = Convert.ToString(reader["ICPRNT_5"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ///////////
                //
                IGMOT.SelectedIndex = Convert.ToInt16(reader["IGMOT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IOCRL.Value = Convert.ToDecimal(reader["IOCRL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IOPT.SelectedIndex = Convert.ToInt16(reader["IOPT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ITDMP.SelectedIndex = Convert.ToInt16(reader["ITDMP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ITPRNT.SelectedIndex = Convert.ToInt16(reader["ITPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ITYP.SelectedIndex = Convert.ToInt16(reader["ITYP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IWV.SelectedIndex = Convert.ToInt16(reader["IWV"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                JOPT.SelectedIndex = Convert.ToInt16(reader["JOPT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                JSTP.Value = Convert.ToDecimal(reader["JSTP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                KBOUT.Value = Convert.ToDecimal(reader["KBOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                KBROUT.Value = Convert.ToDecimal(reader["KBROUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                KCOUT.Value = Convert.ToDecimal(reader["KCOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                KIWOUT.Value = Convert.ToDecimal(reader["KIWOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                KSOUT.Value = Convert.ToDecimal(reader["KSOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                KWOUT.Value = Convert.ToDecimal(reader["KWOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MSTEPS.Value = Convert.ToDecimal(reader["MSTEPS"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MSTEPS_1.Value = Convert.ToDecimal(reader["MSTEPS_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NDATA.Value = Convert.ToDecimal(reader["NDATA"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NLC.Value = Convert.ToDecimal(reader["NLC"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NLDED.Value = Convert.ToDecimal(reader["NLDED"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NLDED_1.Value = Convert.ToDecimal(reader["NLDED_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NLJ.Value = Convert.ToDecimal(reader["NLJ"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NLM.Value = Convert.ToDecimal(reader["NLM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NLU.Value = Convert.ToDecimal(reader["NLU"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NMOD.Value = Convert.ToDecimal(reader["NMOD"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NPRNT.Value = Convert.ToDecimal(reader["NPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NPRNT_1.SelectedIndex = Convert.ToInt16(reader["NPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NPTS.Value = Convert.ToDecimal(reader["NPTS"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NSOUT.Value = Convert.ToDecimal(reader["NSOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                PMAX.Text = Convert.ToString(reader["PMAX"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                POWER1.Text = Convert.ToString(reader["POWER1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                POWER2.SelectedIndex = Convert.ToInt16(reader["POWER2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                TDUR.Text = Convert.ToString(reader["TDUR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                WHFILE.Text = reader["WHFILE"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                WVFILE.Text = reader["WVFILE"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox37.Text = reader["textBox37"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox38.Text = reader["textBox38"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox39.Text = reader["textBox39"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox40.Text = reader["textBox40"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox41.Text = reader["textBox41"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox42.Text = reader["textBox42"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox43.Text = reader["textBox43"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox44.Text = reader["textBox44"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox45.Text = reader["textBox45"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox46.Text = reader["textBox46"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox47.Text = reader["textBox47"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox48.Text = reader["textBox48"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox49.Text = reader["textBox49"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox50.Text = reader["textBox50"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox51.Text = reader["textBox51"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox52.Text = reader["textBox52"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox53.Text = reader["textBox53"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox54.Text = reader["textBox54"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox55.Text = reader["textBox55"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox56.Text = reader["textBox56"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox57.Text = reader["textBox57"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox58.Text = reader["textBox58"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox59.Text = reader["textBox59"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                WHFILE_t = reader["WHFILE_t"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                WVFILE_t = reader["WVFILE_t"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();




                if (reader["ICDPRNT_1"].ToString() == "0")
                {
                    radioButton13.Checked = true;
                }
                if (reader["ICDPRNT_2"].ToString() == "0")
                {
                    radioButton14.Checked = true;
                }
                if (reader["ICDPRNT_3"].ToString() == "0")
                {
                    radioButton16.Checked = true;
                }
                if (reader["ICDPRNT_4"].ToString() == "0")
                {
                    radioButton18.Checked = true;
                }
                if (reader["ICDPRNT_5"].ToString() == "0")
                {
                    radioButton20.Checked = true;
                }

                if (reader["ICPRNT_1"].ToString() == "0")
                {
                    radioButton6.Checked = true;
                }
                if (reader["ICPRNT_2"].ToString() == "0")
                {
                    radioButton17.Checked = true;
                }
                if (reader["ICPRNT_3"].ToString() == "0")
                {
                    radioButton21.Checked = true;
                }
                if (reader["ICPRNT_4"].ToString() == "0")
                {
                    radioButton23.Checked = true;
                }
                if (reader["ICPRNT_5"].ToString() == "0")
                {
                    radioButton25.Checked = true;
                }
                if (reader.HasColumn("batch_check"))
                {
                    if (reader["batch_check"].ToString() == "0")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
                else
                {
                    radioButton1.Checked = true;
                }
                reader.Close();

                cmd_load.CommandText = "end"; cmd_load.ExecuteNonQuery();
                cn.Close();

                // Read batch data
                if (radioButton2.Checked)
                {
                    SQLiteCommand cmd_load_b = new SQLiteCommand(cn);
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd_load_b.Connection = cn;
                    cn.Open();
                    cmd_load_b.CommandText = "begin"; cmd_load_b.ExecuteNonQuery();

                    cmd_load_b.CommandText = "select * from batch_info";
                    SQLiteDataReader reader_b = cmd_load_b.ExecuteReader();
                    reader_b.Read();
                    start.Value = Convert.ToDecimal(reader_b["start_v"]);
                    inc.Value = Convert.ToDecimal(reader_b["inc_v"]);
                    end.Value = Convert.ToDecimal(reader_b["end_v"]);
                    int b_count = Convert.ToInt16(reader_b["count_v"]);
                    if (reader_b.HasColumn("FEMA"))
                    {
                        FEMA.Checked = Convert.ToBoolean(reader_b["FEMA"]);

                    }

                    reader_b.Close();
                    cmd_load_b.CommandText = "end"; cmd_load_b.ExecuteNonQuery();
                    double b1_value, b2_value, b3_value;
                  //  if (FEMA.Checked)
                   // {
                        cmd_load_b.CommandText = "begin"; cmd_load_b.ExecuteNonQuery();
                        if (TableExists("FEMA_B1", cn))
                        {
                            cmd_load_b.CommandText = "select * from FEMA_B1";
                            reader_b = cmd_load_b.ExecuteReader();
                            reader_b.Read();
                            b1_value = Convert.ToDouble(reader_b["b1_value"].ToString());
                            reader_b.Close();
                        }
                        if (TableExists("FEMA_B2", cn))
                        {
                            cmd_load_b.CommandText = "select * from FEMA_B2";
                            reader_b = cmd_load_b.ExecuteReader();
                            reader_b.Read();
                            b2_value = Convert.ToDouble(reader_b["b2_value"].ToString());
                            reader_b.Close();
                        }
                        if (TableExists("FEMA_B3", cn))
                        {
                            cmd_load_b.CommandText = "select * from FEMA_B3";
                            reader_b = cmd_load_b.ExecuteReader();
                            reader_b.Read();
                            b3_value = Convert.ToDouble(reader_b["b3_value"].ToString());
                            reader_b.Close();
                        }
                        // BTOT = Math.Sqrt(Math.Pow(b1_value, 2) + Math.Pow(b2_value, 2) + Math.Pow(b3_value, 2) + Math.Pow(Convert.ToDouble(BRTR.Text), 2));

                        cmd_load_b.CommandText = "select * from FEMA_info";
                        reader_b = cmd_load_b.ExecuteReader();
                        reader_b.Read();

                        c1.Text = Convert.ToString(reader_b["c1"]);
                        c2.Text = Convert.ToString(reader_b["c2"]);
                        c3.Text = Convert.ToString(reader_b["c3"]);
                        c4.Text = Convert.ToString(reader_b["c4"]);
                        c5.Text = Convert.ToString(reader_b["c5"]);

                        checkBox1.Checked = Convert.ToBoolean(reader_b["cc1"]);
                        checkBox2.Checked = Convert.ToBoolean(reader_b["cc2"]);
                        checkBox3.Checked = Convert.ToBoolean(reader_b["cc3"]);
                        checkBox4.Checked = Convert.ToBoolean(reader_b["cc4"]);
                        checkBox5.Checked = Convert.ToBoolean(reader_b["cc5"]);
                        checkBox6.Checked = Convert.ToBoolean(reader_b["cc6"]);


                        mu.Text = Convert.ToString(reader_b["mu"]);
                        radioButton8.Checked = Convert.ToBoolean(reader_b["radioButton8"]);
                        radioButton9.Checked = Convert.ToBoolean(reader_b["radioButton9"]);
                        radioButton10.Checked = Convert.ToBoolean(reader_b["radioButton10"]);
                        radioButton11.Checked = Convert.ToBoolean(reader_b["radioButton11"]);
                        radioButton3.Checked = Convert.ToBoolean(reader_b["radioButton3"]);
                        radioButton4.Checked = Convert.ToBoolean(reader_b["radioButton4"]);
                        radioButton5.Checked = Convert.ToBoolean(reader_b["radioButton5"]);
                        radioButton7.Checked = Convert.ToBoolean(reader_b["radioButton7"]);

                        reader_b.Close();



                        cmd_load_b.CommandText = "end"; cmd_load_b.ExecuteNonQuery();
                        //    cn.Close();

                        //batch_files
                        //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd_load_b.Connection = cn;
                        //cmd_load_b = new SQLiteCommand(cn);
                        //cn.Open(); cmd_load_b.CommandText = "begin"; cmd_load_b.ExecuteNonQuery();

                        //cmd_load_b.CommandText = "select * from batch_files";
                        //reader_b = cmd_load_b.ExecuteReader();
                        //reader_b.Read();

                        //for (int i = 0; i < b_count; i++)
                        //{
                        //    listBox1.Items.Add(reader_b["hor_name"]);
                        //   // listBox2.Items.Add(reader_b["hor_path"]);
                        //    listBox3.Items.Add(reader_b["ver_name"]);
                        //  //  listBox4.Items.Add(reader_b["ver_path"]);


                        //    reader_b.Read();

                        //}

                        //reader_b.Close();
                        //cmd_load_b.CommandText = "end"; cmd_load_b.ExecuteNonQuery(); cn.Close();
                 //   }
                    //////////////

                    ///FEMA Files
                    ///
                    SQLiteCommand cmd_load_FEMA = new SQLiteCommand(); ;
                    //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
                    cmd_load_FEMA.Connection = cn;
                    cmd_load_FEMA = new SQLiteCommand(cn);
                    cmd_load_FEMA.CommandText = "begin"; cmd_load_FEMA.ExecuteNonQuery();

                    if (TableExists("FEMA_files_F", cn))
                    {
                        cmd_load_FEMA.CommandText = "select * from FEMA_files_F";
                        SQLiteDataReader reader_FEMA = cmd_load_FEMA.ExecuteReader();
                        reader_FEMA.Read();
                        for (int i = 1; i < 23; i++)
                        {
                            if (reader_FEMA["Far"].ToString() == "1")
                                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                            else
                                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                            reader_FEMA.Read();

                        }
                        reader_FEMA.Close();
                    }

                    if (TableExists("FEMA_files_N", cn)) //Remember, the user either select near or far. not both of them
                    {
                        cmd_load_FEMA.CommandText = "select * from FEMA_files_N";
                        SQLiteDataReader reader_FEMA = cmd_load_FEMA.ExecuteReader();
                        reader_FEMA.Read();
                        for (int i = 1; i < 29; i++)
                        {
                            if (reader_FEMA["Near"].ToString() == "1")
                                checkedListBox2.SetItemCheckState(i, CheckState.Checked);
                            else
                                checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
                            reader_FEMA.Read();

                        }
                        reader_FEMA.Close();
                    }

                    if (TableExists("FEMA_final", cn))
                    {
                        cmd_load_FEMA.CommandText = "select * from FEMA_final";
                        SQLiteDataReader reader_FEMA = cmd_load_FEMA.ExecuteReader();
                        reader_FEMA.Read();
                        if (reader_FEMA["chs_n"].ToString() == "1")
                        {
                            near_check.Checked = true;
                            radioButtonYN1.Checked = false;
                        }
                        else
                        {
                            near_check.Checked = false;
                            radioButtonYN1.Checked = true;

                        }
                        reader_FEMA.Close();
                    }

                    cmd_load_FEMA.CommandText = "end"; cmd_load_FEMA.ExecuteNonQuery();
                    cn.Close();
                }

                ////


                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView1";
                reader = cmd.ExecuteReader();
                int dataGridView1_i = 0;
                while (reader.Read())
                {

                    dataGridView1["NSTLD", dataGridView1_i].Value = reader["NSTLD"];
                    dataGridView1["PX", dataGridView1_i].Value = reader["PX"];
                    dataGridView1_i++;
                }

                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView2";
                reader = cmd.ExecuteReader();

                int dataGridView2_i = 0;
                while (reader.Read())
                {

                    dataGridView2[0, dataGridView2_i].Value = reader["NSTLD_1"];
                    dataGridView2_i++;
                }

                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); 
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

                cmd.CommandText = "select * from " + DTable + "dataGridView6";
                reader = cmd.ExecuteReader();
                int dataGridView6_i = 0;
                while (reader.Read())
                {

                    dataGridView6[0, dataGridView6_i].Value = reader["Column1"];
                    dataGridView6_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView7";
                reader = cmd.ExecuteReader();
                int dataGridView7_i = 0;
                while (reader.Read())
                {

                    dataGridView7[0, dataGridView7_i].Value = reader["Column1"];
                    dataGridView7_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView8";
                reader = cmd.ExecuteReader();
                int dataGridView8_i = 0;
                while (reader.Read())
                {

                    dataGridView8[0, dataGridView8_i].Value = reader["Column1"];
                    dataGridView8_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView9";
                reader = cmd.ExecuteReader();
                int dataGridView9_i = 0;
                while (reader.Read())
                {

                    dataGridView9[0, dataGridView9_i].Value = reader["Column1"];
                    dataGridView9_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView10";
                reader = cmd.ExecuteReader();
                int dataGridView10_i = 0;
                while (reader.Read())
                {

                    dataGridView10[0, dataGridView10_i].Value = reader["Column1"];
                    dataGridView10_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView11";
                reader = cmd.ExecuteReader();
                int dataGridView11_i = 0;
                while (reader.Read())
                {

                    dataGridView11[0, dataGridView11_i].Value = reader["Column1"];
                    dataGridView11_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView4";
                reader = cmd.ExecuteReader();
                int dataGridView4_i = 0;
                while (reader.Read())
                {

                    dataGridView4[0, dataGridView4_i].Value = reader["UPRNT"];
                    dataGridView4_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();

                ///////////////

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView5";
                reader = cmd.ExecuteReader();
                int dataGridView5_i = 0;
                while (reader.Read())
                {

                    dataGridView5["ISO", dataGridView5_i].Value = reader["ISO"];
                    dataGridView5["FNAMES", dataGridView5_i].Value = reader["FNAMES"];
                    dataGridView5_i++;
                }
                reader.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();


                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "select * from " + DTable + "dataGridView3";
                SQLiteDataAdapter db = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                if (TableExists(DTable + "dataGridView3", cn) == true)
                    db.Fill(dt);
                int size_c = dt.Columns.Count;




                if (size_c != 0)
                {
                    reader = cmd.ExecuteReader();
                    int dataGridView3_i = 0;
                    while (reader.Read())
                    {


                        for (int i = 0; i < size_c; i++)
                        {

                            dataGridView3[i, dataGridView3_i].Value = reader["C" + i.ToString()];
                        }
                        dataGridView3_i++;


                    }
                    reader.Close();
                }

                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();
                populateEarhQuicksFile();











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
                radioButtonYN1_CheckedChanged_1(sender, e);




            }
            loading = false;
            NLC_ValueChanged(null, null);
            NLM_ValueChanged(null, null);
            NLJ_ValueChanged(null, null);
            NLU_ValueChanged(null, null);

        }
        private void Analysis_Load(object sender, EventArgs e)
        {
            wizardSample.HelpText = "Help";
          
            

        }
        private void setError(Control ctrl, int value, int limit, string name)
        {
            if (value > limit)
                errorProvider1.SetError(ctrl, String.Format("Maximum Number of {0} Shouldn't exceed {1}", name, limit));
        }
        public void validateRanges()
        {
            errorProvider1.Clear();
            setError(NSOUT, (int)NSOUT.Value, Limits.NZ1, "Output Histories for Dynamic Analysis");
            setError(NPTS, (int)NPTS.Value, Limits.NZ4, "Points in Monotonic Analysis and Quasi-Static Input");
            for(int i=0;i<22;i++)// Var Validation 
            {
                if(checkedListBox1.GetItemChecked(i))
                {
                   if(Limits.DTCAL%Limits.FEMA_FAR_DELTA[i]!=0)
                   {
                       errorProvider1.SetError(checkedListBox1, "Delta T for FEMA file " + (i + 1) + " is not muliple of " + Limits.DTCAL);
                   }
                }
            }
            for(int i=0;i<28;i++)
            {
                if(checkedListBox2.GetItemChecked(i))
                {
                    if(Limits.DTCAL%Limits.FEMA_NEAR_DETLA[i]!=0)
                    {
                        errorProvider1.SetError(checkedListBox2, "Delta T for FEMA file " + (i + 1) + " is not muliple of " + Limits.DTCAL);
                    }
                }
            }
        }


        private void wizardSample_BeforeSwitchPages(object sender,
             CristiPotlog.Controls.Wizard.BeforeSwitchPagesEventArgs e)
        {
            //wizardSample.CancelText = "Finish";

            //if (e.NewIndex == 8)
            //  e.NewIndex = 7;
           // if (e.NewIndex == 1)
             //   e.NewIndex = 0;
            if(IOPT.SelectedIndex ==0)
            {
                if (e.OldIndex == 0 && e.NewIndex == 1)
                    e.NewIndex = 9;
                if (e.OldIndex == 9 && e.NewIndex == 8)
                    e.NewIndex = 0;
            }
            else if(IOPT.SelectedIndex == 1)
            {
                if (e.OldIndex == 0 && e.NewIndex == 1)
                    e.NewIndex = 8;
                if (e.OldIndex == 8 && e.NewIndex == 7)
                    e.NewIndex = 0;
            }
            else if (IOPT.SelectedIndex == 2)
            {
                if (e.OldIndex == 1 && e.NewIndex == 2)
                    e.NewIndex = 8;
                if (e.OldIndex == 8 && e.NewIndex == 7)
                    e.NewIndex = 1;
            }
            else if (IOPT.SelectedIndex == 4)
            {
                if (e.OldIndex == 0 && e.NewIndex == 1)
                    e.NewIndex = 7;
                if (e.OldIndex == 7 && e.NewIndex == 6)
                    e.NewIndex = 0;
            }
            else if (IOPT.SelectedIndex == 3)
            {
                if (e.OldIndex == 0 && e.NewIndex == 1)
                    e.NewIndex = 2;
                if (e.OldIndex == 2 && e.NewIndex == 1)
                    e.NewIndex = 0;
                if(e.OldIndex==2&&e.NewIndex==3)
                {
                    if (radioButton1.Checked)//single mode 
                        e.NewIndex = 8; 
                    
                }
                if(e.OldIndex == 8 && e.NewIndex == 7)
                {
                    if (radioButton1.Checked)
                        e.NewIndex = 2;
                }
            }
        }

        private void wizardSample_BeforeSwitchPages_1(object sender, CristiPotlog.Controls.Wizard.BeforeSwitchPagesEventArgs e)
        {
          
        }

        private void wizardSample_AfterSwitchPages(object sender, CristiPotlog.Controls.Wizard.AfterSwitchPagesEventArgs e)
        {
            //wizardSample.CancelText = "Finish";

        }


        private void button35_Click(object sender, EventArgs e)
        {
            L_NLU temp_form = new L_NLU(NLU.Value, DTable);
            temp_form.ShowDialog();
        }
        private void button34_Click(object sender, EventArgs e)
        {
            L_NLJ temp_form = new L_NLJ(NLJ.Value, DTable);
            temp_form.ShowDialog();
        }


        private void button33_Click(object sender, EventArgs e)
        {
            L_NLM temp_form = new L_NLM(NLM.Value, DTable);
            temp_form.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            L_NLC temp_form = new L_NLC(NLC.Value, DTable);
            temp_form.ShowDialog();
        }

        private void NLU_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
                groupBox19.Enabled = false;
            else
                groupBox19.Enabled = true;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); 

            if (NLU.Value == 0)
            {
                cmd.CommandText = "begin";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from " + DTable + "L_NLU";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end";
                cmd.ExecuteNonQuery();
                button35.Enabled = false;
            }
            else
            {

                button35.Enabled = true;
                cmd.CommandText = "Select Count(IL) from " + DTable + "L_NLU";
                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    int nlu_count = rd.GetInt32(0);
                    rd.Close();
                    cn.Close();
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                    if (NLU.Value > nlu_count)
                    {
                        for (int i = 0; i < (NLU.Value - nlu_count); i++)
                        {
                            cmd.CommandText = "insert into " + DTable + "L_NLU (IL, IBN, FU) values (" + (nlu_count + i + 1) + ",0,0)";
                            cmd.ExecuteNonQuery();
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else if (NLU.Value < nlu_count)
                    {
                        while (nlu_count != NLU.Value)
                        {
                            cmd.CommandText = "Delete from " + DTable + "L_NLU where IL=" + (nlu_count);
                            cmd.ExecuteNonQuery();
                            nlu_count--;
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Can't get NLU count");
                    return;
                }
            }
            //if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
            //    groupBox19.Enabled = false;
            //else
            //    groupBox19.Enabled = true;
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NLU.Value == 0)
            //{
            //    button35.Enabled = false;
            //}
            //else
            //{
            //    button35.Enabled = true;
            //    if (!edit)
            //    {
            //        cmd.CommandText = "Delete from " + DTable + "L_NLU";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NLU.Value; k++)
            //        {
            //            cmd.CommandText = "insert into " + DTable + "L_NLU (IL, IBN, FU) values (" + k + ",0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); 
            //cn.Close();
        }

        private void NLJ_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
                groupBox19.Enabled = false;
            else
                groupBox19.Enabled = true;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); 

            if (NLJ.Value == 0)
            {
                cmd.CommandText = "begin";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from " + DTable + "L_NLJ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end";
                cmd.ExecuteNonQuery();
                button34.Enabled = false;
            }
            else
            {

                button34.Enabled = true;
                cmd.CommandText = "Select Count(IL) from " + DTable + "L_NLJ";
                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    int nlj_count = rd.GetInt32(0);
                    rd.Close();
                    cn.Close();
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                    if (NLJ.Value > nlj_count)
                    {
                        for (int i = 0; i < (NLJ.Value - nlj_count); i++)
                        {
                            cmd.CommandText = "insert into " + DTable + "L_NLJ (IL, LF, IF_1, FL) values(" + (nlj_count + i + 1) + ",0,0,0)";
                            cmd.ExecuteNonQuery();
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else if (NLJ.Value < nlj_count)
                    {
                        while (nlj_count != NLJ.Value)
                        {
                            cmd.CommandText = "Delete from " + DTable + "L_NLJ where IL=" + (nlj_count);
                            cmd.ExecuteNonQuery();
                            nlj_count--;
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Can't get NLJ count");
                    return;
                }

            }
            //if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
            //    groupBox19.Enabled = false;
            //else
            //    groupBox19.Enabled = true;
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NLJ.Value == 0)
            //{

            //    button34.Enabled = false;
            //}
            //else
            //{

            //    button34.Enabled = true;
            //    if (!edit)
            //    {
            //        cmd.CommandText = "Delete from " + DTable + "L_NLJ";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NLJ.Value; k++)
            //        {
            //            cmd.CommandText = "insert into " + DTable + "L_NLJ (IL, LF, IF_1, FL) values(" + k + ",0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            //cn.Close();
        }
        private void ValueChangedHandler(string tableName)
        {
            if (loading)
                return;

        }
        private void NLC_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
                return;
            if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
                groupBox19.Enabled = false;
            else
                groupBox19.Enabled = true;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();

            if (NLC.Value == 0)
            {
                cmd.CommandText = "begin";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from " + DTable + "L_NLC";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end";
                cmd.ExecuteNonQuery();
                button27.Enabled = false;
            }
            else
            {
                button27.Enabled = true;
                cmd.CommandText = "Select Count(IL) from " + DTable + "L_NLC";
                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    int nlc_count = rd.GetInt32(0);
                    rd.Close();
                    cn.Close();
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

                    if (NLC.Value > nlc_count)
                    {

                        for (int i = 0; i < (NLC.Value - nlc_count); i++)
                        {
                            cmd.CommandText = "insert into " + DTable + "L_NLC (IL, IFV, LV, JV, FV) values(" + (nlc_count + i + 1) + ",0,0,0,0)";
                            cmd.ExecuteNonQuery();
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else if (NLC.Value < nlc_count)
                    {

                        while (nlc_count != NLC.Value)
                        {
                            cmd.CommandText = "Delete from " + DTable + "L_NLC where IL=" + (nlc_count);
                            cmd.ExecuteNonQuery();
                            nlc_count--;
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                    }
                    //     Console.WriteLine("Hi");
                }
                else
                {
                    MessageBox.Show("Can't find NLC count");
                    return;
                }
            }
            //if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
            //    groupBox19.Enabled = false;
            //else
            //    groupBox19.Enabled = true;
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NLC.Value == 0)
            //{
            //    button27.Enabled = false;
            //}
            //else
            //{
            //    button27.Enabled = true;
            //    if (!edit)
            //    {
            //        cmd.CommandText = "Delete from " + DTable + "L_NLC";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NLC.Value; k++)
            //        {
            //            cmd.CommandText = "insert into " + DTable + "L_NLC (IL, IFV, LV, JV, FV) values(" + k + ",0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); 
            //cn.Close();
        }

        private void NLM_ValueChanged(object sender, EventArgs e)
        {
                        if (loading)
                return;
            if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
                groupBox19.Enabled = false;
            else
                groupBox19.Enabled = true;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();

            if (NLM.Value == 0)
            {
                cmd.CommandText = "begin";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from " + DTable + "L_NLM";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end";
                cmd.ExecuteNonQuery();
                button33.Enabled = false;
            }
            else
            {
                button33.Enabled = true;
                cmd.CommandText = "Select Count(IL) from " + DTable + "L_NLM";
                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    int nlm_count = rd.GetInt32(0);
                    rd.Close();
                    cn.Close();
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                    if (NLM.Value > nlm_count)
                    {
                        for (int i = 0; i < (NLM.Value - nlm_count); i++)
                        {
                            cmd.CommandText = "insert into " + DTable + "L_NLM (IL, IBM, FM1, FM2) values(" + (nlm_count + 1 + i) + ",0,0,0)";
                            cmd.ExecuteNonQuery();
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else if (NLM.Value < nlm_count)
                    {
                        while (nlm_count != NLM.Value)
                        {
                            cmd.CommandText = "Delete from " + DTable + "L_NLM where IL=" + (nlm_count);
                            cmd.ExecuteNonQuery();
                            nlm_count--;
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cant get NLM count");
                }
            }
            //if (NLU.Value == 0 && NLM.Value == 0 && NLJ.Value == 0 && NLC.Value == 0)
            //    groupBox19.Enabled = false;
            //else
            //    groupBox19.Enabled = true;
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NLM.Value == 0)
            //{
            //    button33.Enabled = false;
            //}
            //else
            //{
            //    button33.Enabled = true;
            //    if (!edit)
            //    {
            //        cmd.CommandText = "Delete from " + DTable + "L_NLM";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NLM.Value; k++)
            //        {
            //            cmd.CommandText = "insert into " + DTable + "L_NLM (IL, IBM, FM1, FM2) values(" + k + ",0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); 
            //cn.Close();
        }
        private void IOPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IOPT.SelectedIndex == 2)
            {
                groupBox20.Enabled = true;
                groupBox26.Enabled = false;
                groupBox30.Enabled = false;

                groupBox31.Enabled = true;
                groupBox32.Enabled = false;
            }

            else if (IOPT.SelectedIndex == 3)
            {
                groupBox26.Enabled = true;
                groupBox20.Enabled = false;
                groupBox30.Enabled = false;

                groupBox31.Enabled = false;
                groupBox32.Enabled = true;

            }
            else if (IOPT.SelectedIndex == 4)
            {
                groupBox30.Enabled = true;
                groupBox26.Enabled = false;
                groupBox20.Enabled = false;

                groupBox31.Enabled = false;
                groupBox32.Enabled = true;
            }
            else
            {
                groupBox30.Enabled = false;
                groupBox26.Enabled = false;
                groupBox20.Enabled = false;

                groupBox31.Enabled = false;
                groupBox32.Enabled = false;

            }

        }

        private void JOPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JOPT.SelectedIndex == 0)
            {
                groupBox21.Enabled = true;
                groupBox25.Enabled = false;
                if (ITYP.SelectedIndex == 3)
                {
                    groupBox25.Enabled = true;
                    MSTEPS_1.Value = MSTEPS.Value;
                    DRFLIM_1.Text = DRFLIM.Text;
                }
            }
            else
            {
                groupBox21.Enabled = false;
                groupBox25.Enabled = true;
                MSTEPS_1.Value = MSTEPS.Value;
                DRFLIM_1.Text = DRFLIM.Text;
            }
        }
        private void ITYP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ITYP.SelectedIndex == 3)
            {
                groupBox22.Enabled = false;
                groupBox25.Enabled = true;
                MSTEPS_1.Value = MSTEPS.Value;
                DRFLIM_1.Text = DRFLIM.Text;
            }
            else
            {

                groupBox22.Enabled = true;
                groupBox25.Enabled = false;
                if (ITYP.SelectedIndex == 2)
                {
                    groupBox23.Enabled = true;
                }
                else
                    groupBox23.Enabled = false;
                if (ITYP.SelectedIndex == 4)
                {
                    groupBox24.Enabled = true;
                }
                else
                    groupBox24.Enabled = false;
            }

        }
        private void NLDED_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView1.RowCount = (int)NLDED.Value;
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    dataGridView1[0, i].Value = 0;
            //    dataGridView1[1, i].Value = 0;
            //}

            if (NLDED.Value < dataGridView1.RowCount)
            {
                while (NLDED.Value != dataGridView1.RowCount)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView1.RowCount;
                while (NLDED.Value != dataGridView1.RowCount)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = 0;
                    dataGridView1[1, i].Value = 0;
                    i++;
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            WHFILE.Text = openFileDialog1.SafeFileName;
            WHFILE_t = System.IO.File.ReadAllText(openFileDialog1.FileName);

        }
        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            WVFILE.Text = openFileDialog2.SafeFileName;
            WVFILE_t = System.IO.File.ReadAllText(openFileDialog1.FileName);
        }

        private void IWV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IWV.SelectedIndex != 0)
            {
                checkboxYN1.Checked = true;
                button29.Enabled = true;
                if(listBox3.Items.Count<listBox1.Items.Count)
                {
                    MessageBox.Show("Please add more veritcal components");
                    openFileDialog4.ShowDialog();
                }
               
            }
            else
            {
                checkboxYN1.Checked = false;
                button29.Enabled = false;

                for(int i = listBox1.Items.Count;i<listBox3.Items.Count;i++)
                {
                    
                    SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
                    SQLiteCommand cmd = new SQLiteCommand(cn);



                        // delete selected file from the database 
                        try
                        {
                            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                            string sql = "DELETE FROM EQH WHERE txt_file_name='{0}';";
                            WaveFile wav = (WaveFile)listBox3.Items[i];
                            sql = String.Format(sql, wav.File_Name);

                            //cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            //  cmd.CommandText = "end"; cmd.ExecuteNonQuery();

                           

                           //istBox3.Items.RemoveAt(xx);
                            //   cn.Close();
                        }
                        catch (Exception ee)
                        {

                            MessageBox.Show("Error Deleting file :(");
                        }
                        finally
                        {
                            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                            cn.Close();
                            populateEarhQuicksFile();
                        }
                    
                }
            }
        }
        private void IGMOT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IGMOT.SelectedIndex != 1)
                groupBox29.Enabled = true;
            else
                groupBox29.Enabled = false;
        }
        private void NLDED_1_ValueChanged(object sender, EventArgs e)
        {
            int gv2Rows = dataGridView2.RowCount;
            int gv3Rows = dataGridView3.RowCount;
            int gv3Cols = dataGridView3.ColumnCount;
            dataGridView2.RowCount = (int)NLDED_1.Value;
            dataGridView3.RowCount = (int)NLDED_1.Value;
            dataGridView3.ColumnCount = (int)NPTS.Value;

            for (int i = gv2Rows; i < dataGridView2.RowCount; i++)
            {
                dataGridView2[0, i].Value = 0;
            }
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    if(i>=gv3Rows||j>=gv3Cols)
                        dataGridView3[j, i].Value = 0;
                }
            }

        }

        private void NPTS_ValueChanged(object sender, EventArgs e)
        {
            int gv3Rows = dataGridView3.RowCount;
            int gv3Cols = dataGridView3.ColumnCount;
            dataGridView3.RowCount = (int)NLDED_1.Value;
            dataGridView3.ColumnCount = (int)NPTS.Value;

            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                for (int j = 0; j < dataGridView3.ColumnCount; j++)

                    if (i >= gv3Rows || j >= gv3Cols)
                        dataGridView3[j, i].Value = 0;
            }

        }
        private void NPRNT_ValueChanged(object sender, EventArgs e)
        {
            if (NPRNT.Value > 0)
            {
                groupBox49.Enabled = true;
                groupBox35.Enabled = true;
            }
            else
            {
                groupBox49.Enabled = false;
                groupBox35.Enabled = false;


            }
            //dataGridView4.RowCount = (int)NPRNT.Value;

            //for (int i = 0; i < dataGridView4.RowCount; i++)
            //{
            //    dataGridView4[0, i].Value = 0;
            //}

            if (NPRNT.Value < dataGridView4.RowCount)
            {
                while (NPRNT.Value != dataGridView4.RowCount)
                {
                    dataGridView4.Rows.RemoveAt(dataGridView4.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView4.RowCount;
                while (NPRNT.Value != dataGridView4.RowCount)
                {
                    dataGridView4.Rows.Add();
                    dataGridView4[0, i].Value = 0;
                    i++;
                }
            }

        }
        private void KCOUT_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView6.RowCount = (int)KCOUT.Value;
            //for (int i = 0; i < dataGridView6.RowCount; i++)
            //{
            //    dataGridView6[0, i].Value = 0;
            //}

            if (KCOUT.Value < dataGridView6.RowCount)
            {
                while (KCOUT.Value != dataGridView6.RowCount)
                {
                    dataGridView6.Rows.RemoveAt(dataGridView6.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView6.RowCount;
                while (KCOUT.Value != dataGridView6.RowCount)
                {
                    dataGridView6.Rows.Add();
                    dataGridView6[0, i].Value = 0;
                    i++;
                }
            }

        }

        private void KBOUT_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView7.RowCount = (int)KBOUT.Value;
            //for (int i = 0; i < dataGridView7.RowCount; i++)
            //{
            //    dataGridView7[0, i].Value = 0;
            //}

            if (KBOUT.Value < dataGridView7.RowCount)
            {
                while (KBOUT.Value != dataGridView7.RowCount)
                {
                    dataGridView7.Rows.RemoveAt(dataGridView7.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView7.RowCount;
                while (KBOUT.Value != dataGridView7.RowCount)
                {
                    dataGridView7.Rows.Add();
                    dataGridView7[0, i].Value = 0;
                    i++;
                }
            }

        }

        private void KWOUT_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView8.RowCount = (int)KWOUT.Value;
            //for (int i = 0; i < dataGridView8.RowCount; i++)
            //{
            //    dataGridView8[0, i].Value = 0;
            //}
            if (KWOUT.Value < dataGridView8.RowCount)
            {
                while (KWOUT.Value != dataGridView8.RowCount)
                {
                    dataGridView8.Rows.RemoveAt(dataGridView8.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView8.RowCount;
                while (KWOUT.Value != dataGridView8.RowCount)
                {
                    dataGridView8.Rows.Add();
                    dataGridView8[0, i].Value = 0;
                    i++;
                }
            }

        }

        private void KSOUT_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView9.RowCount = (int)KSOUT.Value;
            //for (int i = 0; i < dataGridView9.RowCount; i++)
            //{
            //    dataGridView9[0, i].Value = 0;
            //}

            if (KSOUT.Value < dataGridView9.RowCount)
            {
                while (KSOUT.Value != dataGridView9.RowCount)
                {
                    dataGridView9.Rows.RemoveAt(dataGridView9.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView9.RowCount;
                while (KSOUT.Value != dataGridView9.RowCount)
                {
                    dataGridView9.Rows.Add();
                    dataGridView9[0, i].Value = 0;
                    i++;
                }
            }
        }

        private void KBROUT_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView10.RowCount = (int)KBROUT.Value;
            //for (int i = 0; i < dataGridView10.RowCount; i++)
            //{
            //    dataGridView10[0, i].Value = 0;
            //}

            if (KBROUT.Value < dataGridView10.RowCount)
            {
                while (KBROUT.Value != dataGridView10.RowCount)
                {
                    dataGridView10.Rows.RemoveAt(dataGridView10.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView10.RowCount;
                while (KBROUT.Value != dataGridView10.RowCount)
                {
                    dataGridView10.Rows.Add();
                    dataGridView10[0, i].Value = 0;
                    i++;
                }
            }
        }

        private void KIWOUT_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView11.RowCount = (int)KIWOUT.Value;
            //for (int i = 0; i < dataGridView11.RowCount; i++)
            //{
            //    dataGridView11[0, i].Value = 0;
            //}
            if (KIWOUT.Value < dataGridView11.RowCount)
            {
                while (KIWOUT.Value != dataGridView11.RowCount)
                {
                    dataGridView11.Rows.RemoveAt(dataGridView11.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView11.RowCount;
                while (KIWOUT.Value != dataGridView11.RowCount)
                {
                    dataGridView11.Rows.Add();
                    dataGridView11[0, i].Value = 0;
                    i++;
                }
            }
        }

        private void NPRNT_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NPRNT_1.SelectedIndex == 1)
            {
                groupBox33.Enabled = true;

                groupBox35.Enabled = true;
            }
            else
            {
                groupBox33.Enabled = false;
                groupBox35.Enabled = false;
            }
        }
        private void NSOUT_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView5.RowCount = (int)NSOUT.Value;
            //for (int i = 0; i < NSOUT.Value; i++)
            //{
            //    dataGridView5.Rows[i].Cells["ISO"].Value = (i + 1).ToString();
            //    dataGridView5.Rows[i].Cells["FNAMES"].Value = "LEVEL" + (i + 1) + ".OUT";
            //}
            if (NSOUT.Value < dataGridView5.RowCount)
            {
                while (NSOUT.Value != dataGridView5.RowCount)
                {
                    dataGridView5.Rows.RemoveAt(dataGridView5.RowCount - 1);
                }
            }
            else
            {
                int i = dataGridView5.RowCount;
                while (NSOUT.Value != dataGridView5.RowCount)
                {
                    dataGridView5.Rows.Add();
                    dataGridView5.Rows[i].Cells["ISO"].Value = (i + 1).ToString();
                    dataGridView5.Rows[i].Cells["FNAMES"].Value = "LEVEL" + (i + 1) + ".OUT";
                    i++;
                }
            }


        }

        private void JSTP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void IOCRL_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MSTEPS_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NMOD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void POWER2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MSTEPS_1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ITDMP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NDATA_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void button29_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();

        }

        private void ICNTRL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ITPRNT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ICDPRNT_1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ICPRNT_1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private PGA_Sa_Factor_output[] PGAonSa_N;
        private PGA_Sa_Factor_output[] PGAonSa_F;
        //public object [,] batch;
        private void wizardSample_Cancel(object sender, CancelEventArgs e)
        {
            try
            {
                SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;

                String path = Var.pp + @"\FEMA";

                //if (FEMA.Checked)
                //{
                //    for (int i = 1; i <= 22; i++)////////////
                //    {
                //        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                //        {
                //            //Insert to DB
                //            //cmd.CommandText = "insert into " + DTable + "fema_far (far_" + i.ToString() + ") VALUES(1)";
                //            listBox1.Items.Add("Far_EQ" + i.ToString() + "-1.AT2");
                //            listBox1.Items.Add("Far_EQ" + i.ToString() + "-2.AT2");
                //            listBox2.Items.Add(path + @"\PEER\Far\" + "EQ"+i.ToString() +"-1.AT2" );///////?? path of FEMA_far
                //            listBox2.Items.Add(path + @"\PEER\Far\" + "EQ"+i.ToString() +"-2.AT2" );
                //            listBox3.Items.Add("None");
                //            listBox4.Items.Add("None");
                //            listBox3.Items.Add("None");
                //            listBox4.Items.Add("None");

                //        }
                //        //else
                //        //{
                //        //    cmd.CommandText = "insert into " + DTable + "fema_far (far_" + i.ToString() + ") VALUES(0)";
                //        //}
                //    }

                //    //Near
                //    for (int i = 1; i <= 28; i++)//////////////////////////
                //    {
                //        if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
                //        {
                //            //Insert to DB
                //            //cmd.CommandText = "insert into " + DTable + "fema_far (far_" + i.ToString() + ") VALUES(1)";
                //            listBox1.Items.Add("FEMA_Near" + i.ToString());
                //            listBox2.Items.Add(openFileDialog3.FileNames[i]);///////?? path of FEMA_Near
                //            listBox3.Items.Add("None");
                //            listBox4.Items.Add("None");

                //        }

                //    }
                //}

                ///////////////

                //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
                if (radioButton2.Checked)
                {
                    cn.Open(); 
                    cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

                    cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "batch";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"create table [" + DTable + "batch] ([path_h] TEXT NULL,[name_h] TEXT NULL,[name_v] TEXT NULL,[path_v] TEXT NULL, [max_g] FLOAT NULL, [lines] FLOAT NULL,[BB] FLOAT NULL,[c1] FLOAT NULL,[c2] FLOAT NULL,[c3] FLOAT NULL,[c4] FLOAT NULL,[c5] FLOAT NULL,[time] FLOAT NULL,[max_v] FLOAT NULL,[SSF] FLOAT NULL,[duct] FLOAT NULL,[Smt] FLOAT NULL)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "end"; cmd.ExecuteNonQuery(); 
                    cn.Close();

                    //String path_h = "";
                    // String path_v = "";
                    //String name_v = "";
                    // String name_h = "";

                    //int count = 0;
                    //string line;
                    // double max;
                    // double max_v;
                    //batch = new object[listBox2.Items.Count, 4];





                    //decimal c1v, c2v, c3v, c4v, c5v;
                    //c1v = Convert.ToDecimal(c1.Text) / 100;
                    //c2v = Convert.ToDecimal(c2.Text) / 100;
                    //c3v = Convert.ToDecimal(c3.Text) / 100;
                    //c4v = Convert.ToDecimal(c4.Text) / 100;
                    //c5v = Convert.ToDecimal(c5.Text) / 100;

                    //if (!checkBox1.Checked)
                    //{
                    //    c1v = -1;
                    //}
                    //if (!checkBox2.Checked)
                    //{
                    //    c2v = -1;
                    //}
                    //if (!checkBox3.Checked)
                    //{
                    //    c3v = -1;
                    //}
                    //if (!checkBox4.Checked)
                    //{
                    //    c4v = -1;
                    //}
                    //if (!checkBox5.Checked)
                    //{
                    //    c5v = -1;
                    //}
                    //cmd.CommandText = "insert into " + DTable + "batch (max_v,path_h,name_h,path_v,name_v,max_g,lines,time,BB,c1,c2,c3,c4,c5,duct,SSF,Smt) VALUES('" + max_v + "','" + path_h + "','" + name_h + "','" + path_v + "','" + name_v + "'," + max + "," + (count - 1) + "," + time + "," + BB + "," + c1v + "," + c2v + "," + c3v + "," + c4v + "," + c5v + "," + mu.Text + "," + SSF_value + "," + SMT + ")";
                    //cmd.ExecuteNonQuery();
                    //reader.Close();
                    //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
                    //batch[i, 0] = path;
                    //batch[i, 1] = max;
                    //batch[i, 2] = count;



                    //  }
                }


                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable;
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "] ([id] FLOAT NULL, [BSPRNT] FLOAT  NULL, [DAMP] FLOAT  NULL, [DFPRNT] FLOAT  NULL, [DRFLIM] FLOAT  NULL, [DRFLIM_1] FLOAT  NULL, [DTCAL] FLOAT  NULL, [DTCAL_1] FLOAT  NULL, [DTINP] FLOAT  NULL, [DTOUT] FLOAT  NULL, [DTPRNT] FLOAT  NULL, [EXPK] FLOAT  NULL, [GMAXH] FLOAT  NULL, [GMAXV] FLOAT  NULL, [ICDPRNT_1] FLOAT  NULL, [ICDPRNT_2] FLOAT  NULL, [ICDPRNT_3] FLOAT  NULL, [ICDPRNT_4] FLOAT  NULL, [ICDPRNT_5] FLOAT  NULL, [ICNTRL] FLOAT  NULL, [ICPRNT_1] FLOAT  NULL, [ICPRNT_2] FLOAT  NULL, [ICPRNT_3] FLOAT  NULL, [ICPRNT_4] FLOAT  NULL, [ICPRNT_5] FLOAT  NULL, [IGMOT] FLOAT  NULL, [IOCRL] FLOAT  NULL, [IOPT] FLOAT  NULL, [ITDMP] FLOAT  NULL, [ITPRNT] FLOAT  NULL, [ITYP] FLOAT  NULL, [IWV] FLOAT  NULL, [JOPT] FLOAT  NULL, [JSTP] FLOAT  NULL, [KBOUT] FLOAT  NULL, [KBROUT] FLOAT  NULL, [KCOUT] FLOAT  NULL, [KIWOUT] FLOAT  NULL, [KSOUT] FLOAT  NULL, [KWOUT] FLOAT  NULL, [MSTEPS] FLOAT  NULL, [MSTEPS_1] FLOAT  NULL, [NDATA] FLOAT  NULL, [NLC] FLOAT  NULL, [NLDED] FLOAT  NULL, [NLDED_1] FLOAT  NULL, [NLJ] FLOAT  NULL, [NLM] FLOAT  NULL, [NLU] FLOAT  NULL, [NMOD] FLOAT  NULL, [NPRNT] FLOAT  NULL, [NPRNT_1] FLOAT  NULL, [NPTS] FLOAT  NULL, [NSOUT] FLOAT  NULL, [PMAX] FLOAT  NULL, [POWER1] FLOAT  NULL, [POWER2] FLOAT  NULL, [TDUR] FLOAT  NULL, [WHFILE] VARCHAR ( 80 )  NULL, [WVFILE] VARCHAR ( 80 )  NULL, [textBox37] VARCHAR ( 80 )  NULL, [textBox38] VARCHAR ( 80 )  NULL, [textBox39] VARCHAR ( 80 )  NULL, [textBox40] VARCHAR ( 80 )  NULL, [textBox41] VARCHAR ( 80 )  NULL, [textBox42] VARCHAR ( 80 )  NULL, [textBox43] VARCHAR ( 80 )  NULL, [textBox44] VARCHAR ( 80 )  NULL, [textBox45] VARCHAR ( 80 )  NULL, [textBox46] VARCHAR ( 80 )  NULL, [textBox47] VARCHAR ( 80 )  NULL, [textBox48] VARCHAR ( 80 )  NULL, [textBox49] VARCHAR ( 80 )  NULL, [textBox50] VARCHAR ( 80 )  NULL, [textBox51] VARCHAR ( 80 )  NULL, [textBox52] VARCHAR ( 80 )  NULL, [textBox53] VARCHAR ( 80 )  NULL, [textBox54] VARCHAR ( 80 )  NULL, [textBox55] VARCHAR ( 80 )  NULL, [textBox56] VARCHAR ( 80 )  NULL, [textBox57] VARCHAR ( 80 )  NULL, [textBox58] VARCHAR ( 80 )  NULL, [textBox59] VARCHAR ( 80 )  NULL, [temp_in] VARCHAR ( 10000 )  NULL, [WHFILE_t] Text  NULL, [WVFILE_t] Text  NULL,[batch_check] FLOAT NULL, [batch_count] FLOAT NULL, [batch_inc] FLOAT NULL, [batch_start] FLOAT NULL, [batch_end] FLOAT NULL)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into " + DTable + " (id, BSPRNT, DAMP, DFPRNT, DRFLIM, DRFLIM_1, DTCAL, DTCAL_1, DTINP, DTOUT, DTPRNT, EXPK, GMAXH, GMAXV, ICDPRNT_1, ICDPRNT_2, ICDPRNT_3, ICDPRNT_4, ICDPRNT_5, ICNTRL, ICPRNT_1, ICPRNT_2, ICPRNT_3, ICPRNT_4, ICPRNT_5, IGMOT, IOCRL, IOPT, ITDMP, ITPRNT, ITYP, IWV, JOPT, JSTP, KBOUT, KBROUT, KCOUT, KIWOUT, KSOUT, KWOUT, MSTEPS, MSTEPS_1, NDATA, NLC, NLDED, NLDED_1, NLJ, NLM, NLU, NMOD, NPRNT, NPRNT_1, NPTS, NSOUT, PMAX, POWER1, POWER2, TDUR,  WHFILE, WVFILE, textBox37, textBox38, textBox39, textBox40, textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48, textBox49, textBox50, textBox51, textBox52, textBox53, textBox54, textBox55, textBox56, textBox57, textBox58, textBox59,WHFILE_t,WVFILE_t,batch_check,batch_count,batch_start,batch_inc,batch_end) values(1, " + BSPRNT.Text + ", " + DAMP.Text + ", " + DFPRNT.Text + ", " + DRFLIM.Text + ", " + DRFLIM_1.Text + ", " + DTCAL.Text + ", " + DTCAL_1.Text + ", " + DTINP.Text + ", " + DTOUT.Text + ", " + DTPRNT.Text + ", " + EXPK.Text + ", " + GMAXH.Text + ", " + GMAXV.Text + ", " + ICDPRNT_1.YesNo + ", " + ICDPRNT_2.YesNo + ", " + ICDPRNT_3.YesNo + ", " + ICDPRNT_4.YesNo + ", " + ICDPRNT_5.YesNo + ", " + ICNTRL.SelectedIndex + ", " + ICPRNT_1.YesNo + ", " + ICPRNT_2.YesNo + ", " + ICPRNT_3.YesNo + ", " + ICPRNT_4.YesNo + ", " + ICPRNT_5.YesNo + ", " + IGMOT.SelectedIndex + ", " + IOCRL.Value + ", " + IOPT.SelectedIndex + ", " + ITDMP.SelectedIndex + ", " + ITPRNT.SelectedIndex + ", " + ITYP.SelectedIndex + ", " + IWV.SelectedIndex + ", " + JOPT.SelectedIndex + ", " + JSTP.Value + ", " + KBOUT.Value + ", " + KBROUT.Value + ", " + KCOUT.Value + ", " + KIWOUT.Value + ", " + KSOUT.Value + ", " + KWOUT.Value + ", " + MSTEPS.Value + ", " + MSTEPS_1.Value + ", " + NDATA.Value + ", " + NLC.Value + ", " + NLDED.Value + ", " + NLDED_1.Value + ", " + NLJ.Value + ", " + NLM.Value + ", " + NLU.Value + ", " + NMOD.Value + ", " + NPRNT.Value + ", " + NPRNT_1.SelectedIndex + ", " + NPTS.Value + ", " + NSOUT.Value + ", " + PMAX.Text + ", " + POWER1.Text + ", " + POWER2.SelectedIndex + ", " + TDUR.Text + ", '" + WHFILE.Text + "', '" + WVFILE.Text + "', '" + textBox37.Text + "', '" + textBox38.Text + "', '" + textBox39.Text + "', '" + textBox40.Text + "', '" + textBox41.Text + "', '" + textBox42.Text + "', '" + textBox43.Text + "', '" + textBox44.Text + "', '" + textBox45.Text + "', '" + textBox46.Text + "', '" + textBox47.Text + "', '" + textBox48.Text + "', '" + textBox49.Text + "', '" + textBox50.Text + "', '" + textBox51.Text + "', '" + textBox52.Text + "', '" + textBox53.Text + "', '" + textBox54.Text + "', '" + textBox55.Text + "', '" + textBox56.Text + "', '" + textBox57.Text + "', '" + textBox58.Text + "', '" + textBox59.Text + "', '" + WHFILE_t + "', '" + WVFILE_t + "', '" + radioButton2.YesNo + "', '" + listBox1.Items.Count + "', '" + start.Value.ToString() + "', '" + inc.Value.ToString() + "', '" + end.Value.ToString() + "'" + ")";
                cmd.ExecuteNonQuery();
                //if (radioButton2.Checked)
                //{
                cmd.CommandText = "DROP TABLE IF EXISTS batch_info";
                cmd.ExecuteNonQuery();
                //cmd.CommandText = "DROP TABLE IF EXISTS batch_files";
                //cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [batch_info] ([id] FLOAT NULL, [start_v] FLOAT  NULL, [inc_v] FLOAT  NULL, [end_v] FLOAT  NULL, [count_v] FLOAT  NULL, [FEMA] FLOAT  NULL)"; 
                cmd.ExecuteNonQuery();
                // cmd.CommandText = @"create table [batch_files] ([id] FLOAT NULL, [hor_name] Text  NULL, [hor_path] Text  NULL, [ver_name] Text  NULL, [ver_path] Text  NULL)";
                // cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into batch_info (id,start_v,inc_v,end_v,count_v,FEMA) values (" + 1 + ", " + start.Value + ", " + inc.Value + ", " + end.Value + ", " + listBox1.Items.Count + ", " + FEMA.YesNo + ")"; 
                cmd.ExecuteNonQuery();

                // }

                /////////FEMA
             //  if (FEMA.Checked)
            //    {
                    if (Ta <= TS)
                        SMT = Convert.ToDouble(SMS);
                    else
                        SMT = Convert.ToDouble(SM1 / Ta);

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


                    ////
                    double b1_value, b2_value, b3_value;
                    b1_value = 0;
                    b2_value = 0;
                    b3_value = 0;
                    SQLiteDataReader reader_b;
                    if (TableExists("FEMA_B1", cn))
                    {
                        cmd.CommandText = "select * from FEMA_B1";
                        reader_b = cmd.ExecuteReader();
                        reader_b.Read();
                        b1_value = Convert.ToDouble(reader_b["b1_value"].ToString());
                        reader_b.Close();
                    }
                    if (TableExists("FEMA_B2", cn))
                    {
                        cmd.CommandText = "select * from FEMA_B2";
                        reader_b = cmd.ExecuteReader();
                        reader_b.Read();
                        b2_value = Convert.ToDouble(reader_b["b2_value"].ToString());
                        reader_b.Close();
                    }
                    if (TableExists("FEMA_B3", cn))
                    {
                        cmd.CommandText = "select * from FEMA_B3";
                        reader_b = cmd.ExecuteReader();
                        reader_b.Read();
                        b3_value = Convert.ToDouble(reader_b["b3_value"].ToString());
                        reader_b.Close();
                    }
                    double BRTR = 0.1 + 0.1 * Convert.ToDouble(mu.Text);
                    if (BRTR > 0.4)
                        BRTR = 0.4;
                    if (BRTR < 0.2)
                        BRTR = 0.2;
                    double BTOT = Math.Sqrt(Math.Pow(b1_value, 2) + Math.Pow(b2_value, 2) + Math.Pow(b3_value, 2) + Math.Pow(Convert.ToDouble(BRTR), 2));

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

                    if (cc != BTOT_arr.Length && cc!=0)
                    {
                        ACMR10 = interpolate(BTOT_arr[cc - 1], ACMR10_arr[cc - 1], BTOT_arr[cc], ACMR10_arr[cc], BTOT);
                        ACMR20 = interpolate(BTOT_arr[cc - 1], ACMR20_arr[cc - 1], BTOT_arr[cc], ACMR20_arr[cc], BTOT);
                    }
                    else
                    {
                        ACMR10 = interpolate(BTOT_arr[0], ACMR10_arr[0], BTOT_arr[0], ACMR10_arr[0], BTOT_arr[0]);
                        ACMR20 = interpolate(BTOT_arr[0], ACMR20_arr[0], BTOT_arr[0], ACMR20_arr[0], BTOT_arr[0]);
                    }
                    double SF_N = (ACMR10 / SSF_value) * (SMT / SNRT_N);
                    double SF_F = (ACMR10 / SSF_value) * (SMT / SNRT_F);

                    cmd.CommandText = "DROP TABLE IF EXISTS FEMA_files_N";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS FEMA_files_F";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS FEMA_final";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DROP TABLE IF EXISTS FEMA_info";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"create table [FEMA_files_N] ([id] FLOAT NULL, [Near] FLOAT  NULL)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"create table [FEMA_files_F] ([id] FLOAT NULL, [Far] FLOAT  NULL)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"create table [FEMA_final] ([id] FLOAT NULL, [chs_n], FLOAT NULL, [SF_F] FLOAT NULL, [SF_N] FLOAT NULL, [period] FLOAT NULL, [ACMR20] FLOAT NULL)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"create table [FEMA_info] ([id] FLOAT NULL, [c1] FLOAT  NULL, [c2] FLOAT  NULL, [c3] FLOAT  NULL, [c4] FLOAT  NULL, [c5] FLOAT  NULL, [mu] FLOAT  NULL, [radioButton8] FLOAT  NULL, [radioButton9] FLOAT  NULL, [radioButton10] FLOAT  NULL, [radioButton11] FLOAT  NULL, [radioButton3] FLOAT  NULL, [radioButton4] FLOAT  NULL, [radioButton5] FLOAT  NULL, [radioButton7] FLOAT  NULL, [cc1] int null, [cc2] int null, [cc3] int null, [cc4] int null, [cc5] int null, [cc6] int null, [BTOT] FLOAT  NULL, [SSF] FLOAT  NULL, [Smt] FLOAT  NULL)";
                    cmd.ExecuteNonQuery();

                    for (int i = 1; i < checkedListBox1.Items.Count; i++) //Far
                    {
                        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                            cmd.CommandText = "insert into FEMA_files_F (Far) values(1)";
                        else
                            cmd.CommandText = "insert into FEMA_files_F (Far) values(0)";
                        cmd.ExecuteNonQuery();
                    }
                    for (int i = 1; i < checkedListBox2.Items.Count; i++) //Near
                    {
                        if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
                            cmd.CommandText = "insert into FEMA_files_N (Near) values(1)";
                        else
                            cmd.CommandText = "insert into FEMA_files_N (Near) values(0)";
                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = "insert into FEMA_info (id,c1 ,c2, c3, c4, c5,mu,radioButton8,radioButton9,radioButton10,radioButton11,radioButton3,radioButton4,radioButton5,radioButton7,cc1,cc2,cc3,cc4,cc5,cc6,BTOT,SSF,Smt) values (" + 1 + ", " + c1.Text + ", " + c2.Text + ", " + c3.Text + ", " + c4.Text + ", " + c5.Text + ", " + mu.Text + ", " + radioButton8.YesNo + ", " + radioButton9.YesNo + ", " + radioButton10.YesNo + ", " + radioButton11.YesNo + ", " + radioButton3.YesNo + ", " + radioButton4.YesNo + ", " + radioButton5.YesNo + ", " + radioButton7.YesNo + "," + checkBox1.YesNo + "," + checkBox2.YesNo + "," + checkBox3.YesNo + "," + checkBox4.YesNo + "," + checkBox5.YesNo + "," + checkBox6.YesNo + "," + BTOT.ToString() + "," + SSF_value.ToString() + "," + SMT.ToString() + ")";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "insert into FEMA_final (id,chs_n,SF_N,SF_F,period,ACMR20) values(1," + near_check.YesNo + ", " + SF_N + ", " + SF_F + ", " + T + ", " + ACMR20 + ")";
                    cmd.ExecuteNonQuery();

           //     }


                //////////////////

                //dataGridView1
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView1";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView1] ([NSTLD] FLOAT  NULL,[PX] FLOAT  NULL)";
                cmd.ExecuteNonQuery();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView1 (NSTLD, PX) VALUES (" + dataGridView1.Rows[i].Cells["NSTLD"].Value + ", " + dataGridView1.Rows[i].Cells["PX"].Value + ");";
                    cmd.ExecuteNonQuery();
                }

                //dataGridView2
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView2";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView2] ([NSTLD_1] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView2 (NSTLD_1) VALUES (" + dataGridView2.Rows[i].Cells["NSTLD_1"].Value + ");";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView6";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView6] ([Column1] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView6.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView6 (Column1) VALUES (" + dataGridView6.Rows[i].Cells["Column6"].Value + ");";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView7";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView7] ([Column1] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView7.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView7 (Column1) VALUES (" + dataGridView7.Rows[i].Cells["Column7"].Value + ");";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView8";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView8] ([Column1] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView8 (Column1) VALUES (" + dataGridView8.Rows[i].Cells["Column8"].Value + ");";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView9";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView9] ([Column1] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView9.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView9 (Column1) VALUES (" + dataGridView9.Rows[i].Cells["Column9"].Value + ");";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView10";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView10] ([Column1] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView10.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView10 (Column1) VALUES (" + dataGridView10.Rows[i].Cells["Column10"].Value + ");";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView11";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView11] ([Column1] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView11.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView11 (Column1) VALUES (" + dataGridView11.Rows[i].Cells["Column11"].Value + ");";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView4";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView4] ([UPRNT] FLOAT  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView4 (UPRNT) VALUES (" + dataGridView4.Rows[i].Cells["UPRNT"].Value + ");";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView5";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table [" + DTable + "dataGridView5] ([ISO] FLOAT  NULL,[FNAMES] VARCHAR ( 80 )  NULL)";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {

                    cmd.CommandText = @"INSERT INTO " + DTable + "dataGridView5 (ISO, FNAMES) VALUES (" + dataGridView5.Rows[i].Cells["ISO"].Value + ", '" + dataGridView5.Rows[i].Cells["FNAMES"].Value + "');";
                    cmd.ExecuteNonQuery();
                }

                String c_c = "";
                String i_c = "";
                for (int i = 0; i < dataGridView3.Columns.Count; i++)
                {
                    c_c += "C" + i.ToString();
                    i_c += "C" + i.ToString() + " float  NULL";
                    if (i != dataGridView3.Columns.Count - 1)
                    {
                        c_c += ", ";
                        i_c += ", ";
                    }
                }
                cmd.CommandText = "DROP TABLE IF EXISTS " + DTable + "dataGridView3";
                cmd.ExecuteNonQuery();
                if (i_c != "")
                {
                    cmd.CommandText = "Create table [" + DTable + "dataGridView3] (" + i_c + ")";
                    cmd.ExecuteNonQuery();
                }

                String c_r = "";
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {

                    c_r = "";
                    for (int j = 0; j < dataGridView3.Columns.Count; j++)
                    {
                        c_r += dataGridView3[j, i].Value.ToString();
                        if (j != dataGridView3.Columns.Count - 1)
                            c_r += ", ";
                    }
                    cmd.CommandText = "INSERT INTO " + DTable + "dataGridView3 (" + c_c + ") Values (" + c_r + ")";
                    cmd.ExecuteNonQuery();

                }
                cmd.CommandText = "end"; cmd.ExecuteNonQuery(); 
                cn.Close();


                //////////////////

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


                temp_in += textBox37.Text + "\n";
                temp_in += IOPT.SelectedIndex + "\n";

                temp_in += textBox38.Text + "\n";
                temp_in += NLU.Value + ", " + NLJ.Value + ", " + NLM.Value + ", " + NLC.Value + "\n";

                //Provide only when static loads are present #########QUESTION#######
                if (NLU.Value != 0 || NLJ.Value != 0 || NLM.Value != 0 || NLC.Value != 0)
                    temp_in += JSTP.Value + ", " + IOCRL.Value + "\n";

                if (NLU.Value != 0)
                {
                    temp_in += textBox39.Text + "\n";
                    cmd.CommandText = "select * from " + DTable + "L_NLU";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        temp_in += reader["IL"].ToString() + ", " + reader["IBN"].ToString() + ", " + reader["FU"].ToString() + "\n";


                    } reader.Close();
                }

                if (NLJ.Value != 0)
                {
                    temp_in += textBox40.Text + "\n";
                    cmd.CommandText = "select * from " + DTable + "L_NLJ";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        temp_in += reader["IL"].ToString() + ", " + reader["LF"].ToString() + ", " + reader["IF_1"].ToString() + ", " + reader["FL"].ToString() + "\n";


                    } reader.Close();
                }

                if (NLM.Value != 0)
                {
                    temp_in += textBox41.Text + "\n";
                    cmd.CommandText = "select * from " + DTable + "L_NLM";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        temp_in += reader["IL"].ToString() + ", " + reader["IBM"].ToString() + ", " + reader["FM1"].ToString() + ", " + reader["FM2"].ToString() + "\n";


                    } reader.Close();
                }

                if (NLC.Value != 0)
                {
                    temp_in += textBox42.Text + "\n";
                    cmd.CommandText = "select * from " + DTable + "L_NLC";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        temp_in += reader["IL"].ToString() + ", " + reader["IFV"].ToString() + ", " + reader["LV"].ToString() + ", " + reader["JV"].ToString() + ", " + reader["FV"].ToString() + "\n";


                    } reader.Close();
                }

                if (IOPT.SelectedIndex == 2)
                {
                    temp_in += textBox43.Text + "\n";
                    temp_in += (JOPT.SelectedIndex + 1).ToString() + "\n";


                    if (JOPT.SelectedIndex == 0)
                    {
                        temp_in += textBox44.Text + "\n";
                        temp_in += (ITYP.SelectedIndex + 1).ToString() + "\n";

                        if (ITYP.SelectedIndex == 3)
                        {
                            temp_in += textBox45.Text + "\n";
                            temp_in += NLDED.Value + "\n";
                            for (int i = 0; i < NLDED.Value; i++)
                            {
                                temp_in += dataGridView1[0, i].Value;
                                if (i != NLDED.Value - 1)
                                    temp_in += ", ";
                            }
                            temp_in += "\n";

                            for (int i = 0; i < NLDED.Value; i++)
                            {
                                temp_in += dataGridView1[1, i].Value;
                                if (i != NLDED.Value - 1)
                                    temp_in += ", ";
                            }
                            temp_in += "\n";
                            temp_in += MSTEPS.Value + ", " + DRFLIM.Text + "\n";

                        }
                        else
                        {

                            temp_in += PMAX.Text + ", " + MSTEPS.Value + ", " + DRFLIM.Text + "\n";

                            if (ITYP.SelectedIndex == 2)
                            {
                                temp_in += NMOD.Value + ", " + POWER1.Text + ", " + (POWER2.SelectedIndex + 1) + "\n";
                            }
                            if (ITYP.SelectedIndex == 4)
                            {
                                temp_in += EXPK.Text + "\n";
                            }
                        }
                    }


                    else
                    {
                        temp_in += textBox45.Text + "\n";
                        temp_in += NLDED.Value + "\n";
                        for (int i = 0; i < NLDED.Value; i++)
                        {
                            temp_in += dataGridView1[0, i].Value;
                            if (i != NLDED.Value - 1)
                                temp_in += ", ";
                        }
                        temp_in += "\n";

                        for (int i = 0; i < NLDED.Value; i++)
                        {
                            temp_in += dataGridView1[1, i].Value;
                            if (i != NLDED.Value - 1)
                                temp_in += ", ";
                        }
                        temp_in += "\n";
                        temp_in += MSTEPS_1.Value + ", " + DRFLIM_1.Text + "\n";

                    }
                }
                else if (IOPT.SelectedIndex == 3)
                {
                    temp_in += textBox46.Text + "\n";
                    temp_in += GMAXH.Text + "," + GMAXV.Text + "," + DTCAL.Text + "," + TDUR.Text + "," + DAMP.Text + "," + (ITDMP.SelectedIndex + 1) + "\n";

                    temp_in += textBox47.Text + "\n";
                    temp_in += IGMOT.SelectedIndex + "," + IWV.SelectedIndex + "," + NDATA.Value + "," + DTINP.Text + "\n";

                    if (IGMOT.SelectedIndex != 1)
                    {
                        temp_in += textBox48.Text + "\n";
                        temp_in += WHFILE.Text + "\n";
                        if (IWV.SelectedIndex != 0)
                            temp_in += WVFILE.Text + "\n";
                    }

                }
                else if (IOPT.SelectedIndex == 4)
                {
                    temp_in += textBox49.Text + "\n";
                    temp_in += ICNTRL.SelectedIndex + "\n";
                    temp_in += NLDED_1.Value + "\n";
                    for (int i = 0; i < NLDED_1.Value; i++)
                    {
                        temp_in += dataGridView2[0, i].Value;
                        if (i != NLDED_1.Value - 1)
                            temp_in += ", ";
                    }
                    temp_in += "\n";
                    temp_in += NPTS.Value + "\n";

                    //#########
                    for (int rowIndex = 0; rowIndex < NLDED_1.Value; ++rowIndex)
                    {

                        for (int columnIndex = 0; columnIndex < NPTS.Value; ++columnIndex)
                        {

                            temp_in += dataGridView3[columnIndex, rowIndex].Value.ToString();
                            if (columnIndex != NPTS.Value - 1)
                                temp_in += ", ";
                        }
                        temp_in += "\n";
                    }

                    temp_in += DTCAL_1.Text + "\n";
                }

                if (IOPT.SelectedIndex == 2)
                {

                    temp_in += textBox50.Text + "\n";
                    temp_in += NPRNT.Value + "\n";
                    if (NPRNT.Value > 0)
                    {
                        temp_in += (ITPRNT.SelectedIndex + 1).ToString();
                        for (int i = 0; i < NPRNT.Value; i++)
                        {
                            temp_in += dataGridView4[0, i].Value;
                            if (i != NPRNT.Value - 1)
                                temp_in += ", ";
                        }
                        temp_in += "\n";
                    }


                }

                if (IOPT.SelectedIndex == 3 || IOPT.SelectedIndex == 4)
                {
                    temp_in += textBox51.Text + "\n";
                    temp_in += NPRNT_1.SelectedIndex + "\n";
                    if (NPRNT_1.SelectedIndex == 1)
                    {
                        temp_in += DTPRNT.Text + "," + DFPRNT.Text + "," + BSPRNT.Text + "\n";
                    }
                }


                if (ICDPRNT_1.Checked)
                {
                    temp_in += "1, ";
                }
                else
                    temp_in += "0, ";
                if (ICDPRNT_2.Checked)
                {
                    temp_in += "1, ";
                }
                else
                    temp_in += "0, ";
                if (ICDPRNT_3.Checked)
                {
                    temp_in += "1, ";
                }
                else
                    temp_in += "0, ";
                if (ICDPRNT_4.Checked)
                {
                    temp_in += "1, ";
                }
                else
                    temp_in += "0, ";
                if (ICDPRNT_5.Checked)
                {
                    temp_in += "1";
                }
                else
                    temp_in += "0";
                temp_in += "\n";



                ////
                if (groupBox35.Enabled == true)
                {
                    if (ICPRNT_1.Checked)
                    {
                        temp_in += "1, ";
                    }
                    else
                        temp_in += "0, ";
                    if (ICPRNT_2.Checked)
                    {
                        temp_in += "1, ";
                    }
                    else
                        temp_in += "0, ";
                    if (ICPRNT_3.Checked)
                    {
                        temp_in += "1, ";
                    }
                    else
                        temp_in += "0, ";
                    if (ICPRNT_4.Checked)
                    {
                        temp_in += "1, ";
                    }
                    else
                        temp_in += "0, ";
                    if (ICPRNT_5.Checked)
                    {
                        temp_in += "1";
                    }
                    else
                        temp_in += "0";
                    temp_in += "\n";
                }


                temp_in += textBox52.Text + "\n";
                temp_in += NSOUT.Value + ", " + DTOUT.Text + ", ";


                for (int i = 0; i < NSOUT.Value; i++)
                {
                    temp_in += dataGridView5[0, i].Value;
                    if (i != NSOUT.Value - 1)
                        temp_in += ", ";
                }


                //Fnames;

                for (int i = 0; i < NSOUT.Value; i++)
                {
                    temp_in += "\n";
                    temp_in += dataGridView5[1, i].Value;

                }


                //
                temp_in += "\n";
                temp_in += textBox53.Text + "\n";
                temp_in += KCOUT.Value + ", " + KBOUT.Value + ", " + KWOUT.Value + ", " + KSOUT.Value + ", " + KBROUT.Value + ", " + KIWOUT.Value + "\n";


                if (KCOUT.Value != 0)
                {

                    temp_in += textBox54.Text + "\n";
                    for (int i = 0; i < KCOUT.Value; i++)
                    {
                        temp_in += dataGridView6[0, i].Value;
                        if (i != KCOUT.Value - 1)
                            temp_in += ", ";
                    }
                    temp_in += "\n";
                }

                if (KBOUT.Value != 0)
                {
                    temp_in += textBox55.Text + "\n";
                    for (int i = 0; i < KBOUT.Value; i++)
                    {
                        temp_in += dataGridView7[0, i].Value;
                        if (i != KBOUT.Value - 1)
                            temp_in += ", ";
                    }
                    temp_in += "\n";
                }

                if (KWOUT.Value != 0)
                {
                    temp_in += textBox56.Text + "\n";
                    for (int i = 0; i < KWOUT.Value; i++)
                    {
                        temp_in += dataGridView8[0, i].Value;
                        if (i != KWOUT.Value - 1)
                            temp_in += ", ";
                    }
                    temp_in += "\n";
                }

                if (KSOUT.Value != 0)
                {
                    temp_in += textBox57.Text + "\n";
                    for (int i = 0; i < KSOUT.Value; i++)
                    {
                        temp_in += dataGridView9[0, i].Value;
                        if (i != KSOUT.Value - 1)
                            temp_in += ", ";
                    }
                    temp_in += "\n";
                }

                if (KBROUT.Value != 0)
                {
                    temp_in += textBox58.Text + "\n";
                    for (int i = 0; i < KBROUT.Value; i++)
                    {
                        temp_in += dataGridView10[0, i].Value;
                        if (i != KBROUT.Value - 1)
                            temp_in += ", ";
                    }
                    temp_in += "\n";
                }

                if (KIWOUT.Value != 0)
                {
                    temp_in += textBox59.Text + "\n";
                    for (int i = 0; i < KIWOUT.Value; i++)
                    {
                        temp_in += dataGridView11[0, i].Value;
                        if (i != KIWOUT.Value - 1)
                            temp_in += ", ";
                    }
                    temp_in += "\n";
                }

                cmd.CommandText = "update " + DTable + " set temp_in =" + "'" + temp_in + "'" + "where id=1";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                cn.Close();
                
            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
            }

            ///////////////////
        }

        private void wizardSample_Finish(object sender, EventArgs e)
        {

        }

        public static bool TableExists(String tableName, SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
                cmd.Parameters.AddWithValue("@name", tableName);

                using (SQLiteDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        sqlDataReader.Close();
                        return true;
                    }
                    else
                    {
                        sqlDataReader.Close();
                        return false;
                    }
                }
            }
        }

        private void wizardPage28_Click(object sender, EventArgs e)
        {

        }

        private void wizardSample_Help(object sender, EventArgs e)
        {

            if (wizardSample.SelectedPage == wizardSample.Pages[3] || wizardSample.SelectedPage == wizardSample.Pages[4] || wizardSample.SelectedPage == wizardSample.Pages[5] || wizardSample.SelectedPage == wizardSample.Pages[6])
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "Acrobat.exe";
                myProcess.StartInfo.Arguments = "/A \"page=" + wizardSample.SelectedPage.Tag + "=OpenActions\"" + Var.pp + @"\Resources\FEMA.pdf";
                myProcess.Start();

                return;
            }
            else
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "Acrobat.exe";
                myProcess.StartInfo.Arguments = "/A \"page=" + wizardSample.SelectedPage.Tag + "=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
                myProcess.Start();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToInt16(dataGridView1[e.ColumnIndex, e.RowIndex].Value) == 0 || Convert.ToInt16(dataGridView1[e.ColumnIndex, e.RowIndex].Value) > Var.story_num)
            {
                MessageBox.Show("Story number should be between 1 and " + Var.story_num);

            }
        }

        private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e)
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

        private void ITYP_DropDown(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            if (!TableExists("EQH", cn))
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table EQH ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            }
            if (!TableExists("EQV", cn))
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table EQV ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            }


            if (listBox1.Items.Count == 0)
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM EQH;"; // always create EQH and 

                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();

            }


            for (int i = 0; i < openFileDialog3.SafeFileNames.Length; i++)
            {
                WaveFile wav = new WaveFile(openFileDialog3.FileNames[i]);
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                listBox1.Items.Add(wav);


                cmd.CommandText = "insert into EQH (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text,order_id) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "'," + listBox1.Items.Count + ")";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();

                //if (checkboxYN1.Checked == false)
                //{
                //    listBox3.Items.Add("None");

                //}


            }   
            cn.Close();
            if (checkboxYN1.Checked)
            {
                openFileDialog4.ShowDialog();

            }
         

            //WHFILE_t = System.IO.File.ReadAllText(openFileDialog3.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int xx = listBox1.SelectedIndex;
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);


            if (xx >= 0)
            {

                // delete selected file from the database 
                try
                {
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                    string sql = "DELETE FROM EQH WHERE txt_file_name='{0}';";
                    WaveFile wav = (WaveFile)listBox1.SelectedItem;
                    sql = String.Format(sql, wav.File_Name);

                    //cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    //  cmd.CommandText = "end"; cmd.ExecuteNonQuery();

                    if (listBox3.Items.Count >0 )
                    {
                        wav = (WaveFile)listBox1.SelectedItem;
                        string sql1 = "DELETE FROM EQV WHERE txt_file_name='{0}';";
                        sql1 = String.Format(sql1, wav.File_Name);
                        //cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


                        cmd.CommandText = sql1;
                        cmd.ExecuteNonQuery();
                        // cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                    }
                    listBox1.Items.RemoveAt(xx);

                    listBox3.Items.RemoveAt(xx);
                    //   cn.Close();
                }
                catch (Exception ee)
                {

                    MessageBox.Show("Error Deleting file :(");
                }
                finally
                {
                    cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox7.Enabled = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkboxYN1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxYN1.Checked == true)
            {
                listBox3.Enabled = true;
            }
            else
            {
                listBox3.Enabled = false;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
   {
            if(listBox3.Items.Count== listBox1.Items.Count) return;
       SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
       SQLiteCommand cmd = new SQLiteCommand(cn); 
            cn.Open();
       if (!TableExists("EQH", cn))
       {
           cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
           cmd.CommandText = @"create table EQH ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
           cmd.ExecuteNonQuery();
           cmd.CommandText = "end"; cmd.ExecuteNonQuery();
       }
       if (!TableExists("EQV", cn))
       {
           cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
           cmd.CommandText = @"create table EQV ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
           cmd.ExecuteNonQuery();
           cmd.CommandText = "end"; cmd.ExecuteNonQuery();
       }


       if (listBox3.Items.Count == 0)
       {
           cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
           cmd.CommandText = "DELETE FROM EQV;"; // always create EQH and 

           cmd.ExecuteNonQuery();
           cmd.CommandText = "end"; cmd.ExecuteNonQuery();

       }


       for (int i = 0; i < openFileDialog4.SafeFileNames.Length&&listBox3.Items.Count<listBox1.Items.Count; i++)
       {
           WaveFile wav = new WaveFile(openFileDialog4.FileNames[i]);
           cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
           listBox3.Items.Add(wav);


           cmd.CommandText = "insert into EQV (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text,order_id) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "'," + listBox1.Items.Count + ")";
           cmd.ExecuteNonQuery();
           cmd.CommandText = "end"; cmd.ExecuteNonQuery();
       }
       while(listBox3.Items.Count<listBox1.Items.Count)
       {
           MessageBox.Show("Please add more veritical components files");
           OpenFileDialog ofg = new OpenFileDialog();
           if(ofg.ShowDialog()== System.Windows.Forms.DialogResult.OK)
           {
               for (int i = 0; i < ofg.FileNames.Length && listBox3.Items.Count < listBox1.Items.Count;i++ )
               {
                   WaveFile wav = new WaveFile(ofg.FileNames[i]);
                   cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                   listBox3.Items.Add(wav);


                   cmd.CommandText = "insert into EQV (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text,order_id) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "'," + listBox1.Items.Count + ")";
                   cmd.ExecuteNonQuery();
                   cmd.CommandText = "end"; cmd.ExecuteNonQuery();
               }
           }
       }
      
       cn.Close();

       //WHFILE_t = System.IO.File.ReadAllText(openFileDialog3.FileName);
   }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // listBox3.SelectedIndex = listBox1.SelectedIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != listBox1.Items.Count)
                return;
            if (listBox3.SelectedIndex == 0)
                return;
            if (listBox3.SelectedIndex - 1 >= 0)
            {
                Object x = listBox3.Items[listBox3.SelectedIndex];
                Object y = listBox3.Items[listBox3.SelectedIndex - 1];

                // Object x1 = listBox4.Items[listBox3.SelectedIndex];
                // Object y1 = listBox4.Items[listBox3.SelectedIndex - 1];

                listBox3.Items[listBox3.SelectedIndex] = y;
                listBox3.Items[listBox3.SelectedIndex - 1] = x;

                //  listBox4.Items[listBox3.SelectedIndex] = y1;
                // listBox4.Items[listBox3.SelectedIndex - 1] = x1;

                listBox3.SelectedIndex -= 1;
                maintainID();

            }

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != listBox3.Items.Count)
                return;
            if (listBox3.SelectedIndex == listBox3.Items.Count - 1)
                return;
            if (listBox3.SelectedIndex + 1 < listBox3.Items.Count)
            {
                Object x = listBox3.Items[listBox3.SelectedIndex];
                Object y = listBox3.Items[listBox3.SelectedIndex + 1];

                // Object x1 = listBox4.Items[listBox3.SelectedIndex];
                // Object y1 = listBox4.Items[listBox3.SelectedIndex + 1];

                listBox3.Items[listBox3.SelectedIndex] = y;
                listBox3.Items[listBox3.SelectedIndex + 1] = x;

                //   listBox4.Items[listBox3.SelectedIndex] = y1;
                //  listBox4.Items[listBox3.SelectedIndex + 1] = x1;

                listBox3.SelectedIndex += 1;
                maintainID();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  listBox4.SelectedIndex = listBox3.SelectedIndex;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonYN1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox7.Enabled = true;
                groupBox29.Enabled = false;

                NDATA.Enabled = false;
                DTINP.Enabled = false;
                textBox47.Enabled = false;
                IGMOT.Enabled = false;
                GMAXH.Enabled = false;
                GMAXV.Enabled = false;
                FEMA.Enabled = true;
                if (FEMA.Checked)
                {
                    groupBox5.Enabled = true;
                    groupBox8.Enabled = true;
                    checkedListBox1.Enabled = true;
                    checkedListBox2.Enabled = true;
                }

            }
            else
            {
                groupBox7.Enabled = false;
                groupBox29.Enabled = true;

                NDATA.Enabled = true;
                DTINP.Enabled = true;
                textBox47.Enabled = true;
                IGMOT.Enabled = true;
                GMAXH.Enabled = true;
                GMAXV.Enabled = true;
                FEMA.Enabled = false;

                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
                checkedListBox1.Enabled = false;
                checkedListBox2.Enabled = false;
            }
        }

        private void start_TextChanged(object sender, EventArgs e)
        {

        }
        double[] BDR = new double[1];
        double[] BTD = new double[1];
        double[] BMDL = new double[1];


        private void button6_Click(object sender, EventArgs e)
        {



            b1 temp = new b1(BDR);
            temp.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            b2 temp = new b2(BTD);
            temp.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            b3 temp = new b3(BMDL);
            temp.Show();

        }

        private void wizardPage1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Analysis pushover = new Analysis("FEMA_pushover", true, 2, radioButton1.Checked, (double)data1["HIGT", 0].Value);
        }

        private void BRTR_ValueChanged(object sender, EventArgs e)
        {

        }
        double SMT;
        double Cu;
        double SD1;
        double T;



        double SNRT, SSF_value, SF;
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
       // double BTOT;
        double ACMR10;
        double ACMR20;
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

        void update_B()
        {
          //  BTOT = Math.Sqrt(Math.Pow(BDR[0], 2) + Math.Pow(BTD[0], 2) + Math.Pow(BMDL[0], 2) + Math.Pow(Convert.ToDouble(BRTR.Text), 2));



        }

        private void mu_TextChanged(object sender, EventArgs e)
        {
            //calculate BRTR
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateRanges();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FEMA_H1 temp = new FEMA_H1();
            temp.Show();
        }

        private void groupBox26_Enter(object sender, EventArgs e)
        {

        }

        private void FEMA_CheckedChanged(object sender, EventArgs e)
        {
            if (FEMA.Checked)
            {
                groupBox5.Enabled = true;
                groupBox8.Enabled = true;
                groupBox4.Enabled = false;
                label16.Text = "Sa(g)";
            }
            else
            {
                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
                groupBox4.Enabled = true;
                label16.Text = "PGA(g)";
            }
            near_check_CheckedChanged(sender, e);

        }

        private void wizardPage14_Click(object sender, EventArgs e)
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

        private void radioButtonYN1_CheckedChanged_1(object sender, EventArgs e)
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

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count <= 0)
                return;
            try
            {

                WaveFile wv = (WaveFile)listBox1.SelectedItem;

                WaveFileChanger www = new WaveFileChanger(wv,"EQH");

                www.ShowDialog();

                populateEarhQuicksFile();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error Editing file");
            }
        }
        public void maintainID()
        {
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            string sql = "UPDATE {0} SET order_id = {1} WHERE txt_file_name='{2}';";
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                WaveFile wave = (WaveFile)listBox1.Items[i];
                cmd.CommandText = String.Format(sql, "EQH", i, wave.File_Name);
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                if (listBox3.Items[i].ToString().Equals("None"))
                    continue;
                WaveFile wave = (WaveFile)listBox3.Items[i];
                cmd.CommandText = String.Format(sql, "EQV", i, wave.File_Name);
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void populateEarhQuicksFile()
        {
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            if (!TableExists("EQH", cn))
            {
                cn.Close();
                return;
            }
            if (!TableExists("EQV", cn))
            {
                cn.Close();
                return;
            }
            string sql1 = "SELECT * FROM EQH order by order_id;";
            string sql2 = "SELECT * FROM EQV order by order_id;";
           
            // cmd.CommandText = "insert into EQH (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "')";
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            cmd.CommandText = sql1;
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                WaveFile wave = new WaveFile();
                wave.File_Name = reader.GetString(reader.GetOrdinal("txt_file_name"));
                wave.deltaT = reader.GetDouble(reader.GetOrdinal("txt_deltaT"));
                wave.Header_Lines = reader.GetInt32(reader.GetOrdinal("txt_lines_to_skip"));
                wave.isTimeAndValues = reader.GetInt32(reader.GetOrdinal("rdb_values")) != 1;
                wave.Points_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_points_per_line"));
                wave.Prefix_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_prefix"));
                wave.Text = reader.GetString(reader.GetOrdinal("txt_text"));
                listBox1.Items.Add(wave);
            }
            reader.Close();
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
          //  reader.Close();
            cn.Close();

            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
            cmd = new SQLiteCommand(cn);
            cn.Open();
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            cmd.CommandText = sql2;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                WaveFile wave = new WaveFile();
                wave.File_Name = reader.GetString(reader.GetOrdinal("txt_file_name"));
                wave.deltaT = reader.GetDouble(reader.GetOrdinal("txt_deltaT"));
                wave.Header_Lines = reader.GetInt32(reader.GetOrdinal("txt_lines_to_skip"));
                wave.isTimeAndValues = !reader.GetBoolean(reader.GetOrdinal("rdb_values"));
                wave.Points_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_points_per_line"));
                wave.Prefix_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_prefix"));
                wave.Text = reader.GetString(reader.GetOrdinal("txt_text"));

               
                listBox3.Items.Add(wave);
            }

            reader.Close();
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
          //  reader.Close();
            cn.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count <= 0)
                return;
            try
            {

                WaveFile wv = (WaveFile)listBox3.SelectedItem;

                WaveFileChanger www = new WaveFileChanger(wv,"EQV");

                www.ShowDialog();

                populateEarhQuicksFile();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error Editing file");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void end_ValueChanged(object sender, EventArgs e)
        {

        }

        private void inc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void wizardPageA1_Click(object sender, EventArgs e)
        {

        }

        private void c1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void Analysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            wizardSample_Cancel(sender, e);
        }

        private void DTCAL_TextChanged(object sender, EventArgs e)
        {
            if(DTCAL.Text.Trim()!=string.Empty)
            {
                try
                {
                    Limits.DTCAL = Convert.ToDouble(DTCAL.Text);
                }
                catch { };
            }
            validateRanges();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateRanges();
        }

        //private void button35_Click_1(object sender, EventArgs e)
        //{
        //    L_NLU temp_form = new L_NLU(NLU.Value, DTable);
        //    temp_form.ShowDialog();
        //}

        //private void button34_Click_1(object sender, EventArgs e)
        //{
        //    L_NLJ temp_form = new L_NLJ(NLJ.Value, DTable);
        //    temp_form.ShowDialog();
        //}

        //private void button33_Click_1(object sender, EventArgs e)
        //{
        //    L_NLM temp_form = new L_NLM(NLM.Value, DTable);
        //    temp_form.ShowDialog();
        //}

        //private void button27_Click_1(object sender, EventArgs e)
        //{
        //    L_NLC temp_form = new L_NLC(NLC.Value, DTable);
        //    temp_form.ShowDialog();
        //}

    }
}
