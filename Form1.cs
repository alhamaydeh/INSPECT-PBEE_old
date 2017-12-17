using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CristiPotlog.Controls;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections;
using SampleWizard.Properties;
using System.Configuration;
using System.Threading;

namespace SampleWizard
{


    public partial class Form1 : Form
    {
        Settings settings = new Settings();
        Batch_opt batch_options = null;
        bool PlotNeedsSaving = false;
        string batch_template = "[BATCH_TEMPLATE]";
        bool done6 = false;
        public static string __message;
        int J = 0;// Maximum number of columns lines, needed for limits warnings SAAA 10.06.15

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

        public static bool FileInUse(string path)
        {
            try
            {
                //Just opening the file as open/create
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    //If required we can check for read/write by using fs.CanRead or fs.CanWrite
                }
                return false;
            }
            catch (IOException ex)
            {
                //check if message is for a File IO
                __message = ex.Message.ToString();
                if (__message.Contains("The process cannot access the file"))
                    return true;
                else
                    throw;
            }
        }
        bool loading = true;
        public Form1()
        {

            InitializeComponent();
            txt_batch_template.Text = batch_template;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            // this.title.Text = " INSPECT-Lite";
            // Console.Write(wizardSample.ToString());
           // this.Text = " INSPECT";
            if (Limits.LastDay != DateTime.MaxValue)
            {
                this.Text += "       [Expiration date : " + Limits.LastDay.ToString("dd/MM/yyyy") + " ]";
            }
            else
            {
                this.Text += "       [Unlimited Version]";
            }
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //da.SelectCommand = new SQLiteCommand("Select * From G_info", cn);
            //ds.Clear();
            //da.Fill(ds, "G_info");
            //bs.DataSource = ds.Tables["G_info"];


            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();




            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            String fi = Var.pp + "\\orginal.db";
            System.IO.File.Copy(fi, Var.pp + "\\Database.db", true);



            cmd.CommandText = "Delete from concrete";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from REINFORCEMENT";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from MASONRY";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from Hysteretic_1";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from columns";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from columns_1";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from beams_1";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from beams_2";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_column"; cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_beam"; cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_shear"; cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_edge";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_Transverse";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_Spring";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_Moment";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_Brace";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_Infill";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from L_NLU";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from L_NLM";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from L_NLJ";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from L_NLC";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Transverse";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Rotational";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Edge";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Shear_1";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from Shear_2";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Hysteretic_damper";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Delete from C_brace_sp";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Visco";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Friction";
            cmd.ExecuteNonQuery(); cmd.CommandText = "Delete from Infill";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
            loading = false;// Done loading, allow other DB transactions
            forceGUIUpdate();
        }

        void forceGUIUpdate()
        {

            // force some buttons handlers to execute since they were forbidded

            NFR_ValueChanged(null, null);
            NCON_ValueChanged(null, null);
            NSTL_ValueChanged(null, null);
            NMSR_ValueChanged(null, null);
            MCOL_ValueChanged(null, null);
            MBEM_ValueChanged(null, null);
            MEDG_ValueChanged(null, null);
            MTRN_ValueChanged(null, null);
            MSPR_ValueChanged(null, null);
            MBRV_ValueChanged(null, null);
            MBRF_ValueChanged(null, null);
            MBRH_ValueChanged(null, null);
            NCOL_ValueChanged(null, null);
            NBEM_ValueChanged(null, null);
            NWAL_ValueChanged(null, null);
            NHYS_ValueChanged_1(null, null);
            IPT_ValueChanged(null, null);
            NEDG_ValueChanged(null, null);
            NTRN_ValueChanged(null, null);
            NSPR_ValueChanged(null, null);
            NMR_ValueChanged(null, null);
            NBR_ValueChanged(null, null);
            NIW_ValueChanged(null, null);
            MWAL_ValueChanged(null, null);
            //serchTag flora1
        }

        SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();

        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();



        private void Form1_Load(object sender, EventArgs e)
        {
            Settings set = new Settings();
            SettingsProperty val = set.Properties["Setting123"];
            Console.WriteLine(val.DefaultValue);
            //for (int i = 0; i < set.PropertyValues.Count;i++ )
            // {
            //    Console.WriteLine(set.PropertyValues[i].Name + "  :  " + set.PropertyValues[i].PropertyValue);
            // }
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            //  Text = "Sample Wizard";

            wizardSample.CancelText = "Finish";


            //   //1
            //   NSO.DataBindings.Add(new Binding("Value", bs, "NSO"));
            //   NFR.DataBindings.Add(new Binding("Value", bs, "NFR"));
            //   NCON.DataBindings.Add(new Binding("Value", bs, "NCON"));
            //   NSTL.DataBindings.Add(new Binding("Value", bs, "NSTL"));
            //   NMSR.DataBindings.Add(new Binding("Value", bs, "NMSR"));
            //   NPDEL.DataBindings.Add(new Binding("YesNo", bs, "NPDEL"));
            //   IFLEX.DataBindings.Add(new Binding("YesNo", bs, "IFLEX"));
            //   IFLEXDIST.DataBindings.Add(new Binding("YesNo", bs, "IFLEXDIST"));
            //   title.DataBindings.Add(new Binding("Text", bs, "title"));
            //   textBox1.DataBindings.Add(new Binding("Text", bs, "textBox1"));
            //   //2

            //   MCOL.DataBindings.Add(new Binding("Value", bs, "MCOL"));
            //   MBEM.DataBindings.Add(new Binding("Value", bs, "MBEM"));
            //   MWAL.DataBindings.Add(new Binding("Value", bs, "MWAL"));
            //   MEDG.DataBindings.Add(new Binding("Value", bs, "MEDG"));
            //   MTRN.DataBindings.Add(new Binding("Value", bs, "MTRN"));
            //   MSPR.DataBindings.Add(new Binding("Value", bs, "MSPR"));
            //   MBRV.DataBindings.Add(new Binding("Value", bs, "MBRV"));
            //   MBRF.DataBindings.Add(new Binding("Value", bs, "MBRF"));
            //   MBRH.DataBindings.Add(new Binding("Value", bs, "MBRH"));
            //   MIW.DataBindings.Add(new Binding("Value", bs, "MIW"));

            //   NCOL.DataBindings.Add(new Binding("Value", bs, "NCOL"));
            //   NBEM.DataBindings.Add(new Binding("Value", bs, "NBEM"));
            //   NWAL.DataBindings.Add(new Binding("Value", bs, "NWAL"));
            //   NEDG.DataBindings.Add(new Binding("Value", bs, "NEDG"));
            //   NTRN.DataBindings.Add(new Binding("Value", bs, "NTRN"));
            //   NSPR.DataBindings.Add(new Binding("Value", bs, "NSPR"));
            //   NMR.DataBindings.Add(new Binding("Value", bs, "NMR"));
            //   NBR.DataBindings.Add(new Binding("Value", bs, "NBR"));
            //   NIW.DataBindings.Add(new Binding("Value", bs, "NIW"));
            //   NHYS.DataBindings.Add(new Binding("Value", bs, "NHYS"));
            //   IU.DataBindings.Add(new Binding("YesNo", bs, "IU"));
            //   IUSER.DataBindings.Add(new Binding("YesNo", bs, "IUSER"));

            //   textBox2.DataBindings.Add(new Binding("Text", bs, "textBox2"));
            //   textBox3.DataBindings.Add(new Binding("Text", bs, "textBox3"));
            //   textBox4.DataBindings.Add(new Binding("Text", bs, "textBox4"));
            //   textBox9.DataBindings.Add(new Binding("Text", bs, "textBox9"));

            //   //3 

            //   // Another table

            //   //4 

            //   // Another table

            //   //5

            //   IUCOL.DataBindings.Add(new Binding("YesNo", bs, "IUCOL"));
            //   IUBEM.DataBindings.Add(new Binding("YesNo", bs, "IUBEM"));
            //   IUWAL.DataBindings.Add(new Binding("YesNo", bs, "IUWAL"));


            //   textBox10.DataBindings.Add(new Binding("Text", bs, "textBox10"));
            //   textBox11.DataBindings.Add(new Binding("Text", bs, "textBox11"));
            //   textBox12.DataBindings.Add(new Binding("Text", bs, "textBox12"));
            //   textBox13.DataBindings.Add(new Binding("Text", bs, "textBox13"));
            //   textBox14.DataBindings.Add(new Binding("Text", bs, "textBox14"));
            //   textBox15.DataBindings.Add(new Binding("Text", bs, "textBox15"));
            //   textBox16.DataBindings.Add(new Binding("Text", bs, "textBox16"));
            //   textBox17.DataBindings.Add(new Binding("Text", bs, "textBox17"));
            //   textBox18.DataBindings.Add(new Binding("Text", bs, "textBox18"));
            //   textBox19.DataBindings.Add(new Binding("Text", bs, "textBox19"));
            //   textBox20.DataBindings.Add(new Binding("Text", bs, "textBox20"));
            //   textBox21.DataBindings.Add(new Binding("Text", bs, "textBox21"));
            //   textBox22.DataBindings.Add(new Binding("Text", bs, "textBox22"));


            //   //6
            //   ITMODEL.DataBindings.Add(new Binding("YesNo", bs, "ITMODEL"));
            //   ITDVCON.DataBindings.Add(new Binding("YesNo", bs, "ITDVCON"));
            //   ITDFCON.DataBindings.Add(new Binding("YesNo", bs, "ITDFCON"));
            //   ITDHCON.DataBindings.Add(new Binding("YesNo", bs, "ITDHCON"));
            //   ICCTYPE.DataBindings.Add(new Binding("YesNo", bs, "ICCTYPE"));

            //   IPT.DataBindings.Add(new Binding("Value", bs, "IPT"));

            //   textBox23.DataBindings.Add(new Binding("Text", bs, "textBox23"));
            //   textBox24.DataBindings.Add(new Binding("Text", bs, "textBox24"));
            //   textBox25.DataBindings.Add(new Binding("Text", bs, "textBox25"));
            //   textBox35.DataBindings.Add(new Binding("Text", bs, "textBox35"));
            //   textBox36.DataBindings.Add(new Binding("Text", bs, "textBox36"));

            //   //7
            //   textBox26.DataBindings.Add(new Binding("Text", bs, "textBox26"));
            //   textBox27.DataBindings.Add(new Binding("Text", bs, "textBox27"));
            //   textBox28.DataBindings.Add(new Binding("Text", bs, "textBox28"));
            //   textBox29.DataBindings.Add(new Binding("Text", bs, "textBox29"));
            //   textBox30.DataBindings.Add(new Binding("Text", bs, "textBox30"));
            //   textBox31.DataBindings.Add(new Binding("Text", bs, "textBox31"));
            //   textBox32.DataBindings.Add(new Binding("Text", bs, "textBox32"));
            //   textBox33.DataBindings.Add(new Binding("Text", bs, "textBox33"));
            //   textBox34.DataBindings.Add(new Binding("Text", bs, "textBox34"));

            //   //8

            //   NLU.DataBindings.Add(new Binding("Value", bs, "NLU"));
            //   NLJ.DataBindings.Add(new Binding("Value", bs, "NLJ"));
            //   NLM.DataBindings.Add(new Binding("Value", bs, "NLM"));
            //   NLC.DataBindings.Add(new Binding("Value", bs, "NLC"));
            //   JSTP.DataBindings.Add(new Binding("Value", bs, "JSTP"));
            //   IOCRL.DataBindings.Add(new Binding("Value", bs, "IOCRL"));


            //   IOPT.DataBindings.Add(new Binding("SelectedIndex", bs, "IOPT"));

            ////   MessageBox.Show(IOPT.SelectedIndex.ToString());
            //   textBox37.DataBindings.Add(new Binding("Text", bs, "textBox37"));
            //   textBox38.DataBindings.Add(new Binding("Text", bs, "textBox38"));

            //   //9
            //   textBox39.DataBindings.Add(new Binding("Text", bs, "textBox39"));
            //   textBox40.DataBindings.Add(new Binding("Text", bs, "textBox40"));
            //   textBox41.DataBindings.Add(new Binding("Text", bs, "textBox41"));
            //   textBox42.DataBindings.Add(new Binding("Text", bs, "textBox42"));
            //   textBox43.DataBindings.Add(new Binding("Text", bs, "textBox43"));
            //   textBox44.DataBindings.Add(new Binding("Text", bs, "textBox44"));
            //   textBox45.DataBindings.Add(new Binding("Text", bs, "textBox45"));
            //   PMAX.DataBindings.Add(new Binding("Text", bs, "PMAX"));
            //   DRFLIM.DataBindings.Add(new Binding("Text", bs, "DRFLIM"));
            //   POWER1.DataBindings.Add(new Binding("Text", bs, "POWER1"));
            //   EXPK.DataBindings.Add(new Binding("Text", bs, "EXPK"));
            //   DRFLIM_1.DataBindings.Add(new Binding("Text", bs, "DRFLIM_1"));


            //   NLDED.DataBindings.Add(new Binding("Value", bs, "NLDED"));
            //   MSTEPS.DataBindings.Add(new Binding("Value", bs, "MSTEPS"));
            //   NMOD.DataBindings.Add(new Binding("Value", bs, "NMOD"));
            //   MSTEPS_1.DataBindings.Add(new Binding("Value", bs, "MSTEPS_1"));


            //   ITYP.DataBindings.Add(new Binding("SelectedIndex", bs, "ITYP"));
            //   JOPT.DataBindings.Add(new Binding("SelectedIndex", bs, "JOPT"));
            //   POWER2.DataBindings.Add(new Binding("SelectedIndex", bs, "POWER2"));
            //   // Another table for dataGridView1



            //   //10

            //   ITDMP.DataBindings.Add(new Binding("SelectedIndex", bs, "ITDMP"));
            //   IGMOT.DataBindings.Add(new Binding("SelectedIndex", bs, "IGMOT"));
            //   IWV.DataBindings.Add(new Binding("SelectedIndex", bs, "IWV"));

            //   textBox46.DataBindings.Add(new Binding("Text", bs, "textBox46"));
            //   GMAXH.DataBindings.Add(new Binding("Text", bs, "GMAXH"));
            //   GMAXV.DataBindings.Add(new Binding("Text", bs, "GMAXV"));
            //   DTCAL.DataBindings.Add(new Binding("Text", bs, "DTCAL"));
            //   TDUR.DataBindings.Add(new Binding("Text", bs, "TDUR"));
            //   DAMP.DataBindings.Add(new Binding("Text", bs, "DAMP"));
            //   textBox47.DataBindings.Add(new Binding("Text", bs, "textBox47"));
            //   DTINP.DataBindings.Add(new Binding("Text", bs, "DTINP"));
            //   textBox48.DataBindings.Add(new Binding("Text", bs, "textBox48"));
            //   WHFILE.DataBindings.Add(new Binding("Text", bs, "WHFILE"));
            //   WVFILE.DataBindings.Add(new Binding("Text", bs, "WVFILE"));

            //   NDATA.DataBindings.Add(new Binding("Value", bs, "NDATA"));

            //   //11

            //   // Another table 
            //   // Another table 
            //   NLDED_1.DataBindings.Add(new Binding("Value", bs, "NLDED_1"));
            //   NPTS.DataBindings.Add(new Binding("Value", bs, "NPTS"));
            //   DTCAL_1.DataBindings.Add(new Binding("Text", bs, "DTCAL_1"));


            //   ICNTRL.DataBindings.Add(new Binding("SelectedIndex", bs, "ICNTRL"));

            //   textBox49.DataBindings.Add(new Binding("Text", bs, "textBox49"));


            //   //12
            //   textBox50.DataBindings.Add(new Binding("Text", bs, "textBox50"));
            //   textBox51.DataBindings.Add(new Binding("Text", bs, "textBox51"));
            //   DTPRNT.DataBindings.Add(new Binding("Text", bs, "DTPRNT"));
            //   DFPRNT.DataBindings.Add(new Binding("Text", bs, "DFPRNT"));
            //   BSPRNT.DataBindings.Add(new Binding("Text", bs, "BSPRNT"));


            //   ITPRNT.DataBindings.Add(new Binding("SelectedIndex", bs, "ITPRNT"));
            //   NPRNT_1.DataBindings.Add(new Binding("SelectedIndex", bs, "NPRNT_1"));

            //   NPRNT.DataBindings.Add(new Binding("Value", bs, "NPRNT"));

            //   //Another table


            //   //13
            //   ICDPRNT_1.DataBindings.Add(new Binding("YesNo", bs, "ICDPRNT_1"));
            //   ICDPRNT_2.DataBindings.Add(new Binding("YesNo", bs, "ICDPRNT_2"));
            //   ICDPRNT_3.DataBindings.Add(new Binding("YesNo", bs, "ICDPRNT_3"));
            //   ICDPRNT_4.DataBindings.Add(new Binding("YesNo", bs, "ICDPRNT_4"));
            //   ICDPRNT_5.DataBindings.Add(new Binding("YesNo", bs, "ICDPRNT_5"));

            //   ICPRNT_1.DataBindings.Add(new Binding("YesNo", bs, "ICPRNT_1"));
            //   ICPRNT_2.DataBindings.Add(new Binding("YesNo", bs, "ICPRNT_2"));
            //   ICPRNT_3.DataBindings.Add(new Binding("YesNo", bs, "ICPRNT_3"));
            //   ICPRNT_4.DataBindings.Add(new Binding("YesNo", bs, "ICPRNT_4"));
            //   ICPRNT_5.DataBindings.Add(new Binding("YesNo", bs, "ICPRNT_5"));

            //   //14

            //   NSOUT.DataBindings.Add(new Binding("Value", bs, "NSOUT"));
            //   KCOUT.DataBindings.Add(new Binding("Value", bs, "KCOUT"));
            //   KBOUT.DataBindings.Add(new Binding("Value", bs, "KBOUT"));
            //   KWOUT.DataBindings.Add(new Binding("Value", bs, "KWOUT"));
            //   KSOUT.DataBindings.Add(new Binding("Value", bs, "KSOUT"));
            //   KBROUT.DataBindings.Add(new Binding("Value", bs, "KBROUT"));
            //   KIWOUT.DataBindings.Add(new Binding("Value", bs, "KIWOUT"));

            //   textBox52.DataBindings.Add(new Binding("Text", bs, "textBox52"));
            //   textBox53.DataBindings.Add(new Binding("Text", bs, "textBox53"));
            //   DTOUT.DataBindings.Add(new Binding("Text", bs, "DTOUT"));
            //   //Another Table
            //   //Another Tablee


            //   //15

            //   //Tablesssss 

            //   textBox54.DataBindings.Add(new Binding("Text", bs, "textBox54"));
            //   textBox55.DataBindings.Add(new Binding("Text", bs, "textBox55"));
            //   textBox56.DataBindings.Add(new Binding("Text", bs, "textBox56"));
            //   textBox57.DataBindings.Add(new Binding("Text", bs, "textBox57"));
            //   textBox58.DataBindings.Add(new Binding("Text", bs, "textBox58"));
            //   textBox59.DataBindings.Add(new Binding("Text", bs, "textBox59"));

            //   textBox5.DataBindings.Add(new Binding("Text", bs, "textBox5"));
            //   textBox6.DataBindings.Add(new Binding("Text", bs, "textBox6"));
            //   textBox7.DataBindings.Add(new Binding("Text", bs, "textBox7"));
            //   textBox8.DataBindings.Add(new Binding("Text", bs, "textBox8"));




        }

        private void wizardPage2_Click(object sender, EventArgs e)
        {

        }

        private void wizardPage6_Click(object sender, EventArgs e)
        {

        }

        private void wizardPage6_Enter(object sender, EventArgs e)
        {

        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void wizard1_BeforeSwitchPages(object sender, CristiPotlog.Controls.Wizard.BeforeSwitchPagesEventArgs e)
        {

        }

        private void wizardSample_AfterSwitchPages(object sender, Wizard.AfterSwitchPagesEventArgs e)
        {

            // get wizard page to be displayed
            WizardPage newPage = this.wizardSample.Pages[e.NewIndex];

            // check if license page
            if (newPage == this.wizardPageF3 && !done6)
            {



            }
        }






        private void wizardPage6_Click_1(object sender, EventArgs e)
        {

        }
        private void setError(Control ctrl, int value, int limit, string name)
        {
            if (value > limit)
                errorProvider1.SetError(ctrl, String.Format("Maximum Number of {0} Shouldn't exceed {1}", name, limit));
        }
        public void validateRanges()
        {
            errorProvider1.Clear();
            setError(NSO, (int)NSO.Value, Limits.NN1, "Stories");
            setError(NFR, (int)NFR.Value, Limits.NN2, "Frames");
            setError(MCOL, (int)MCOL.Value, Limits.NNC, "Column Elements");
            setError(MBEM, (int)MBEM.Value, Limits.NNB, "Beam Elements");
            setError(MWAL, (int)MWAL.Value, Limits.NNW, "Wall Elements");
            setError(MEDG, (int)MEDG.Value, Limits.NNE, "Edge Beams");
            setError(MTRN, (int)MTRN.Value, Limits.NNT, "Transverse Beams");
            setError(MSPR, (int)MSPR.Value, Limits.NNR, "Rotational Spring Elements");
            setError(MBRV, (int)MBRV.Value, Limits.NND1, "Viscoelastic Damper Elements");
            setError(MBRF, (int)MBRF.Value, Limits.NND2, "Friction Damper Elements");
            setError(MBRH, (int)MBRH.Value, Limits.NND3, "Hysteretic Damper Elements");
            setError(MIW, (int)MIW.Value, Limits.NND4, "Infill Panels");
            setError(NCON, (int)NCON.Value, Limits.NP1, "Concrete Types");
            setError(NSTL, (int)NSTL.Value, Limits.NP2, "Steel Reinforcement Types");
            setError(NHYS, (int)NHYS.Value, Limits.NZ3, "Hysteretic Properties Specified");

            setError(data2, J, Limits.NN4, "Column lines");
            int L = (int)NSO.Value;
            int I = (int)NFR.Value;
            int DOF = (L * I + L * I * J);
            if (DOF > Limits.NN5)
            {
                MessageBox.Show("Degree of Freedom exceeds the IDARC limit\r\nYou can decrease it by decreasing Number of Stories, Number of frames or Number of Column lines");
            }


        }
        bool change1 = false;
        bool change2 = false;
        //  bool change3 = false;

        private void populateFrames()
        {

            // hnadles grids
            J = 0;
            int newFramesCount = (int)NFR.Value;
            int newL = (int)NSO.Value;
            int[] newJ = new int[newFramesCount];
            for (int i = 0; i < newFramesCount; i++)
            {
                newJ[i] = Convert.ToInt32(data2[1, i].Value);
                if (newJ[i] > J)
                    J = newJ[i];
            }
            validateRanges();
            int oldFramesCount = (int)tabControl1.TabPages.Count;
            int oldL = 0;
            try
            {
                for (int i = 0; i < oldFramesCount; i++)
                {
                    if (temp_level[i].ColumnCount != 0)
                        oldL = temp_level[i].Rows.Count;
                }
            }
            catch
            {
                Console.WriteLine("Can't get old level value, assume it to be Zero ");
            }
            int[] oldJ = new int[oldFramesCount];
            for (int i = 0; i < oldFramesCount; i++)
            {
                oldJ[i] = Convert.ToInt32(temp_level[i].ColumnCount);
            }
            if (oldFramesCount > newFramesCount)// remove extra frames
            {
                DataGridView[] tt = new DataGridView[newFramesCount];
                for (int i = 0; i < newFramesCount; i++)
                {
                    tt[i] = temp_level[i];
                }
                temp_level = tt;
                for (int i = newFramesCount; i < oldFramesCount; i++)
                    tabControl1.TabPages.RemoveAt(tabControl1.TabPages.Count - 1);
            }
            else // Add more frames 
            {
                DataGridView[] tt = new DataGridView[newFramesCount];
                for (int i = 0; i < oldFramesCount; i++)
                {
                    tt[i] = temp_level[i];
                }
                temp_level = tt;
                // add the new frames

                for (int rowIndex = oldFramesCount; rowIndex < newFramesCount; ++rowIndex)
                {
                    TabPage tabPage = new TabPage("Frame " + (rowIndex + 1));
                    tabControl1.Controls.Add(tabPage);
                    temp_level[rowIndex] = new DataGridView();
                    temp_level[rowIndex].Location = tabControl1.Location;
                    temp_level[rowIndex].RowHeadersWidth = temp_level[rowIndex].RowHeadersWidth + (40);
                    temp_level[rowIndex].ColumnHeadersHeight = temp_level[rowIndex].ColumnHeadersHeight + (40);
                    temp_level[rowIndex].Dock = DockStyle.Fill;
                    temp_level[rowIndex].Show();
                    temp_level[rowIndex].AutoGenerateColumns = true;
                    temp_level[rowIndex].RowCount = newL + 1;
                    temp_level[rowIndex].AllowUserToAddRows = false;
                    temp_level[rowIndex].ColumnCount = newJ[rowIndex];
                    tabPage.Controls.Add(temp_level[rowIndex]);
                    for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                    {
                        temp_level[rowIndex].Columns[columnIndex].HeaderCell.Value = String.Format("J{0}", columnIndex + 1);

                        for (int k1 = 0; k1 < newL; k1++)
                        {
                            temp_level[rowIndex].Rows[k1].HeaderCell.Value = String.Format("L{0}", newL - k1 - 1);

                            temp_level[rowIndex][columnIndex, k1].Value = 0;
                        }
                    }
                }

            }
            // New Tabs are added with fresh Zeros, now we have to handle the modifications in the old tabs SAAA[15.06.15 12:01 am]
            for (int framIndex = 0; framIndex < ((oldFramesCount < newFramesCount) ? oldFramesCount : newFramesCount); framIndex++)// loop through all frames 
            {
                // we have to remove extra columns and rows 
                if (newJ[framIndex] < oldJ[framIndex])// remove some columns 
                {
                    for (int i = newJ[framIndex]; i < oldJ[framIndex]; i++)
                    {
                        temp_level[framIndex].Columns.RemoveAt(temp_level[framIndex].Columns.Count - 1);
                    }
                }
                if (newL < oldL)
                {
                    if (newJ[framIndex] > 0)// if there is columns then remove the rows 
                    {
                        for (int i = newL; i < oldL; i++)
                        {
                            temp_level[framIndex].Rows.RemoveAt(0);
                        }
                    }
                }

                // Add any needed extra columns 
                if (newJ[framIndex] > oldJ[framIndex])// Add some columns 
                {

                    for (int i = oldJ[framIndex]; i < newJ[framIndex]; i++)
                    {
                        DataGridViewColumn col = new DataGridViewTextBoxColumn();
                        col.HeaderCell.Value = String.Format("J{0}", i + 1);
                        temp_level[framIndex].Columns.Add(col);
                        for (int k1 = 0; k1 < oldL; k1++)
                        {
                            // temp_level[framIndex].Rows[k1].HeaderCell.Value = String.Format("L{0}", newL - k1 - 1);
                            if (temp_level[framIndex].RowCount < oldL)
                            {
                                string[] row = new string[newJ[framIndex]];
                                for (int j = 0; j < newJ[framIndex]; j++)
                                    row[j] = "0";
                                temp_level[framIndex].Rows.Add(row);
                                temp_level[framIndex].Rows[k1].HeaderCell.Value = String.Format("L{0}", oldL - k1 - 1);
                            }
                            else
                            {
                                temp_level[framIndex][i, k1].Value = 0;
                            }
                        }

                    }
                }
                if (newL > oldL) // Add some rows 
                {
                    for (int i = oldL; i < newL; i++)
                    {
                        if (newJ[framIndex] == 0)// No Columns there , so I cant add any row 
                            continue;
                        string[] row = new string[newJ[framIndex]];
                        for (int j = 0; j < newJ[framIndex]; j++)
                            row[j] = "0";
                        temp_level[framIndex].Rows.Insert(0, row);// Add(row);
                        temp_level[framIndex].Rows[0].HeaderCell.Value = String.Format("L{0}", i);
                    }
                }
                // then move to rows 

            }
            // New Tabs are added with fresh Zeros, now we have to handle the modifications in the old tabs SAAA[15.06.15 12:01 am]


            // Handle tabs 



        }
        private void NSO_ValueChanged(object sender, EventArgs e)
        {

            // return;
            // validateRanges();
            //Stories Elevations Grid 
            Var.story_num = (int)NSO.Value;
            int intial_size = data1.Rows.Count;
            if (data1.Rows.Count < Var.story_num)// Add some rows
            {
                for (int i = data1.Rows.Count; i < Var.story_num; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.HeaderCell.Value = String.Format("{0}", i + 1);
                    data1.Rows.Insert(0, row);
                    data1["HIGT", 0].Value = 0;
                }
            }
            else // remove some data 
            {
                for (int i = Var.story_num; i < intial_size; i++)
                {
                    data1.Rows.RemoveAt(0);
                }

            }

            populateFrames();
            return;

            //Var.story_num = (int)NSO.Value;

            //change1 = true;
            //int size = Convert.ToInt32(NSO.Value);
            //data1.ColumnCount = 1;
            //data1.RowCount = size;
            //int k = size;
            //for (int rowIndex = 0; rowIndex < Convert.ToInt32(NSO.Value); rowIndex++)
            //{

            //    data1.Rows[rowIndex].HeaderCell.Value = String.Format("{0}", k);
            //    data1["HIGT", rowIndex].Value = 0;
            //    k--;
            //}

            //  NVLN_change = false;
            // change1 = false;
            //change2 = false;
            int size11 = Convert.ToInt32(NFR.Value);
            int size2 = Convert.ToInt32(NSO.Value);
            //if (size11 < temp_level.Length)
            //{
            //    DataGridView[] tt = new DataGridView[size11];
            //    for (int i = 0; i < size11; i++)
            //    {
            //        tt[i] = temp_level[i];
            //    }
            //    temp_level = tt;
            //}
            //else
            //{
            //    DataGridView[] tt = new DataGridView[size11];
            //    for (int i = 0; i < temp_level.Length; i++)
            //    {
            //        tt[i] = temp_level[i];
            //    }
            //    temp_level = tt;
            //}

            //if (size11 < tabControl1.Controls.Count)// Remove some tabs 
            //{
            //    int newSize = tabControl1.Controls.Count;
            //    for (int i = size11; i < newSize; i++)
            //    {
            //        tabControl1.Controls.RemoveAt(tabControl1.Controls.Count - 1);
            //    }
            //}
            //else // Add some tabs 
            {

                for (int frameIndex = 0; frameIndex < Convert.ToInt32(NFR.Value); frameIndex++)
                {
                    //TabPage tabPage = new TabPage("Frame " + (rowIndex + 1));
                    //tabControl1.Controls.Add(tabPage);
                    //temp_level[rowIndex] = new DataGridView();
                    //temp_level[rowIndex].Location = tabControl1.Location;
                    //temp_level[rowIndex].RowHeadersWidth = temp_level[rowIndex].RowHeadersWidth + (40);

                    //temp_level[rowIndex].ColumnHeadersHeight = temp_level[rowIndex].ColumnHeadersHeight + (40);
                    //Size t_z = tabControl1.Size;
                    //temp_level[rowIndex].Dock = DockStyle.Fill;
                    //temp_level[rowIndex].Show();
                    //temp_level[rowIndex].AutoGenerateColumns = true;
                    //temp_level[rowIndex].RowCount = size2 + 1;
                    //temp_level[rowIndex].AllowUserToAddRows = false;
                    //temp_level[rowIndex].ColumnCount = Convert.ToInt32(data2[1, rowIndex].Value);
                    // tabPage.Controls.Add(temp_level[rowIndex]);
                    if (temp_level[frameIndex].Columns.Count < Convert.ToInt32(NSO.Value))// Add new Columns 
                        if (temp_level[frameIndex].Columns.Count == 0)
                        {
                            continue;
                        }
                    if (temp_level[frameIndex].Rows.Count < Convert.ToInt32(NSO.Value))// Add some levels for the frame
                    {
                        for (int rowIndex = temp_level[frameIndex].Rows.Count; rowIndex < Convert.ToInt32(NSO.Value); ++rowIndex)
                        {
                            //temp_level[rowIndex].Columns[columnIndex].HeaderCell.Value = String.Format("J{0}", columnIndex + 1);
                            DataGridViewRow row = new DataGridViewRow();
                            row.HeaderCell.Value = String.Format("L{0}", rowIndex);
                            temp_level[frameIndex].Rows.Add(row);
                            // data1.Rows.Insert(0, row);
                            // data1["HIGT", i].Value = 0;
                            for (int k1 = 0; k1 < Convert.ToInt32(data2[1, frameIndex].Value); k1++)
                            {

                                // temp_level[rowIndex].Rows[k1].HeaderCell.Value = String.Format("L{0}", size2 - k1 - 1);

                                temp_level[frameIndex][rowIndex, k1].Value = 0;
                            }
                        }
                    }
                    else // Remove some rows
                    {
                        for (int rowIndex = Convert.ToInt32(NSO.Value); rowIndex < temp_level[frameIndex].Rows.Count; ++rowIndex)
                        {
                            temp_level[frameIndex].Rows.RemoveAt(0);
                        }
                    }
                }
            }


            //int size11 = Convert.ToInt32(NFR.Value);
            //int size2 = Convert.ToInt32(NSO.Value);
            //temp_level = new DataGridView[size11];
            //tabControl1.Controls.Clear();
            //for (int rowIndex = 0; rowIndex < size11; ++rowIndex)
            //{
            //    TabPage tabPage = new TabPage("Frame " + (rowIndex + 1));
            //    tabControl1.Controls.Add(tabPage);
            //    temp_level[rowIndex] = new DataGridView();
            //    temp_level[rowIndex].Location = tabControl1.Location;
            //    temp_level[rowIndex].RowHeadersWidth = temp_level[rowIndex].RowHeadersWidth + (40);

            //    temp_level[rowIndex].ColumnHeadersHeight = temp_level[rowIndex].ColumnHeadersHeight + (40);
            //    Size t_z = tabControl1.Size;
            //    temp_level[rowIndex].Dock = DockStyle.Fill;
            //    temp_level[rowIndex].Show();
            //    temp_level[rowIndex].AutoGenerateColumns = true;
            //    temp_level[rowIndex].RowCount = size2 + 1;
            //    temp_level[rowIndex].AllowUserToAddRows = false;
            //    temp_level[rowIndex].ColumnCount = Convert.ToInt32(data2[1, rowIndex].Value);
            //    tabPage.Controls.Add(temp_level[rowIndex]);
            //    for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
            //    {
            //        temp_level[rowIndex].Columns[columnIndex].HeaderCell.Value = String.Format("J{0}", columnIndex + 1);

            //        for (int k1 = 0; k1 < size2; k1++)
            //        {
            //            temp_level[rowIndex].Rows[k1].HeaderCell.Value = String.Format("L{0}", size2 - k1 - 1);

            //            temp_level[rowIndex][columnIndex, k1].Value = 0;
            //        }
            //    }
            //}


        }

        private void do_temp()
        {
            J = 0;
            int size11 = Convert.ToInt32(NFR.Value);
            int size2 = Convert.ToInt32(NSO.Value);
            temp_level = new DataGridView[size11];
            tabControl1.Controls.Clear();
            for (int rowIndex = 0; rowIndex < size11; ++rowIndex)
            {
                TabPage tabPage = new TabPage("Frame " + (rowIndex + 1));
                tabControl1.Controls.Add(tabPage);
                temp_level[rowIndex] = new DataGridView();
                temp_level[rowIndex].Location = tabControl1.Location;

                temp_level[rowIndex].RowHeadersWidth = temp_level[rowIndex].RowHeadersWidth + (40);

                temp_level[rowIndex].ColumnHeadersHeight = temp_level[rowIndex].ColumnHeadersHeight + (40);

                Size t_z = tabControl1.Size;
                temp_level[rowIndex].Dock = DockStyle.Fill;
                temp_level[rowIndex].Show();
                temp_level[rowIndex].AutoGenerateColumns = true;
                temp_level[rowIndex].RowCount = size2 + 1;
                temp_level[rowIndex].AllowUserToAddRows = false;
                temp_level[rowIndex].ColumnCount = Convert.ToInt32(data2[1, rowIndex].Value);
                if (temp_level[rowIndex].ColumnCount > J)
                    J = temp_level[rowIndex].ColumnCount;
                tabPage.Controls.Add(temp_level[rowIndex]);
                for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                {
                    temp_level[rowIndex].Columns[columnIndex].HeaderCell.Value = String.Format("J{0}", columnIndex + 1);

                    for (int k1 = 0; k1 < size2; k1++)
                    {
                        temp_level[rowIndex].Rows[k1].HeaderCell.Value = String.Format("L{0}", size2 - k1 - 1);

                        temp_level[rowIndex][columnIndex, k1].Value = 0;
                    }
                }
            }
            validateRanges();

        }
        private void NFR_ValueChanged(object sender, EventArgs e)
        {

            validateRanges();
            change2 = true;
            int newRows = (int)NFR.Value;
            int oldRows = data2.Rows.Count;

            if (newRows < oldRows)// Remove extra rows 
            {
                for (int i = newRows; i < oldRows; i++)
                {
                    data2.Rows.RemoveAt(data2.Rows.Count - 1);
                }
            }
            else // Add new Rows 
            {
                for (int i = oldRows; i < newRows; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.HeaderCell.Value = String.Format("{0}", i + 1);
                    data2.Rows.Insert(i, row);
                    data2["NDUP", i].Value = 0;
                    data2["NVLN", i].Value = 0;
                }
            }







            //int size1 = Convert.ToInt32(NFR.Value);
            //data2.ColumnCount = 2;
            //data2.RowCount = size1;

            //for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
            //{
            //    data2.Rows[rowIndex].HeaderCell.Value = String.Format("{0}", rowIndex + 1);
            //    data2["NDUP", rowIndex].Value = 0;
            //    data2["NVLN", rowIndex].Value = 0;
            //}

            populateFrames();
            return;
            //   MessageBox.Show("hi");
            //NVLN_change = false;
            //  change1 = false;
            // change2 = false;
            int size11 = Convert.ToInt32(NFR.Value);
            int size2 = Convert.ToInt32(NSO.Value);
            temp_level = new DataGridView[size11];
            tabControl1.Controls.Clear();
            for (int rowIndex = 0; rowIndex < size11; ++rowIndex)
            {
                TabPage tabPage = new TabPage("Frame " + (rowIndex + 1));
                tabControl1.Controls.Add(tabPage);
                temp_level[rowIndex] = new DataGridView();
                temp_level[rowIndex].Location = tabControl1.Location;
                Size t_z = tabControl1.Size;
                temp_level[rowIndex].Dock = DockStyle.Fill;
                temp_level[rowIndex].Show();
                temp_level[rowIndex].AutoGenerateColumns = true;
                temp_level[rowIndex].RowCount = size2 + 1;
                temp_level[rowIndex].AllowUserToAddRows = false;
                temp_level[rowIndex].ColumnCount = Convert.ToInt32(data2[1, rowIndex].Value);
                tabPage.Controls.Add(temp_level[rowIndex]);
                for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                {
                    for (int k1 = 0; k1 < size2; k1++)
                    {
                        temp_level[rowIndex][columnIndex, k1].Value = 0;
                    }
                }
            }


        }



        private void HIGT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //change3 = true;
            decimal result = 0;
            if ((data1.CurrentCell == null) || (data1.CurrentCell.Value == null))
                return;
            string x = data1.CurrentCell.Value.ToString();
            if (!decimal.TryParse(x, out result))
            {
                data1.CurrentCell.Value = null;
                MessageBox.Show("You have entered a wrong Value!");
            }
            else if (e.RowIndex != 0)
            {
                decimal max_HIGHT = Convert.ToDecimal(data1["HIGT", e.RowIndex - 1].Value);
                //Make the if to For # to compare all previous values (from 0 to RowIndex)
                for (int i = e.RowIndex - 1; i >= 0; i--)
                {
                    if (Convert.ToDecimal(data1["HIGT", e.RowIndex].Value) > Convert.ToDecimal(data1["HIGT", i].Value))
                    {
                        MessageBox.Show("Elevation should be less than previous values");
                        data1["HIGT", e.RowIndex].Value = 0;

                    }
                }
            }
        }

        bool NVLN_change = false;
        private void NVLN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show("hi");
            NVLN_change = true;
            decimal result = 0;
            if ((data2.CurrentCell == null) || (data2.CurrentCell.Value == null))
                return;
            string x = data2.CurrentCell.Value.ToString();
            if (!decimal.TryParse(x, out result))
            {
                data2.CurrentCell.Value = null;
                MessageBox.Show("You have entered a wrong Value!");
            }
            populateFrames();
            return;
            do_temp();

        }


        /*
                private void d1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
                {

                    if (Convert.ToBoolean(dataGridView1["d1", e.RowIndex].Value) == true)
                    {
                        dataGridView1["HC", e.RowIndex].Value = "200";
                        dataGridView1["HC", e.RowIndex].ReadOnly = true;
                    }
                    else
                        dataGridView1["HC", e.RowIndex].ReadOnly = false;

                }

                private void d2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
                {
                    if (Convert.ToBoolean(dataGridView1["d2", e.RowIndex].Value) == true)
                    {
                        dataGridView1["HBD", e.RowIndex].Value = "0.01";
                        dataGridView1["HBD", e.RowIndex].ReadOnly = true;
                    }
                    else
                        dataGridView1["HBD", e.RowIndex].ReadOnly = false;
                }
                private void d3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
                {
                    if (Convert.ToBoolean(dataGridView1["d3", e.RowIndex].Value) == true)
                    {
                        dataGridView1["HBE", e.RowIndex].Value = "0.01";
                        dataGridView1["HBE", e.RowIndex].ReadOnly = true;
                    }
                    else
                        dataGridView1["HBE", e.RowIndex].ReadOnly = false;
                }
                private void d4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
                {
                    if (Convert.ToBoolean(dataGridView1["d4", e.RowIndex].Value) == true)
                    {
                        dataGridView1["HS", e.RowIndex].Value = "1.0";
                        dataGridView1["HS", e.RowIndex].ReadOnly = true;
                    }
                    else
                        dataGridView1["HS", e.RowIndex].ReadOnly = false;
                }


                private void IBILINEAR_CellValueChanged(object sender, DataGridViewCellEventArgs e)
                {
            
                    //if(Convert.ToString(dataGridView1["IBILINEAR",e.RowIndex].Value).CompareTo("Trilinear Model") == 0)
                   // {
                
                   // }
                    if (Convert.ToString(dataGridView1["IBILINEAR", e.RowIndex].Value).CompareTo("Nonlinear Elastic-Cyclic Model") == 0)
                    {
                        dataGridView1["d1", e.RowIndex].Value = true;
                        dataGridView1["d2", e.RowIndex].Value = true;
                        dataGridView1["d3", e.RowIndex].Value = true;
                        dataGridView1["d4", e.RowIndex].Value = true;
                        dataGridView1["d1", e.RowIndex].ReadOnly = true;
                        dataGridView1["d2", e.RowIndex].ReadOnly = true;
                        dataGridView1["d3", e.RowIndex].ReadOnly = true;
                        dataGridView1["d4", e.RowIndex].ReadOnly = true;
                    }
                    else {
                        dataGridView1["d1", e.RowIndex].ReadOnly = false;
                        dataGridView1["d2", e.RowIndex].ReadOnly = false;
                        dataGridView1["d3", e.RowIndex].ReadOnly = false;
                        dataGridView1["d4", e.RowIndex].ReadOnly = false;
            
                    }
                }

                */
        private void NDUP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal result = 0;
            if ((data2.CurrentCell == null) || (data2.CurrentCell.Value == null))
                return;
            string x = data2.CurrentCell.Value.ToString();
            if (!decimal.TryParse(x, out result))
            {
                data2.CurrentCell.Value = null;
                MessageBox.Show("You have entered a wrong Value!");
            }

        }

        private void check_decimal(TextBox x)
        {
            decimal temp_check_decimal = 0;
            if (!decimal.TryParse(x.Text, out temp_check_decimal) && x.Text != "")
            {
                MessageBox.Show("You have entered a wrong Value!");
                x.Text = "0";
            }
            else if (x.Text == "")
            {
                MessageBox.Show("You have not entered a Value!");
                x.Text = "0";
            }

        }




        DataGridView[] temp_level;
        private void wizardSample_BeforeSwitchPages(object sender, Wizard.BeforeSwitchPagesEventArgs e)
        {

            /*if (e.NewIndex == 4 && (NVLN_change || change1 || change2))
            {
               // MessageBox.Show("hi");
                NVLN_change = false;
                change1 = false;
                change2 = false;
                int size1 = Convert.ToInt32(NFR.Value);
                int size2 = Convert.ToInt32(NSO.Value);
                temp_level = new DataGridView[size1];
                tabControl1.Controls.Clear();
                for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
                {
                    TabPage tabPage = new TabPage("Frame " + (rowIndex + 1));
                    tabControl1.Controls.Add(tabPage);
                    temp_level[rowIndex] = new DataGridView();
                    temp_level[rowIndex].Location = tabControl1.Location;
                    Size t_z = tabControl1.Size;
                    temp_level[rowIndex].Dock = DockStyle.Fill;
                    temp_level[rowIndex].Show();
                    temp_level[rowIndex].AutoGenerateColumns = true;
                    temp_level[rowIndex].RowCount = size2 + 1;
                    temp_level[rowIndex].AllowUserToAddRows = false;
                    temp_level[rowIndex].ColumnCount = Convert.ToInt32(data2[1, rowIndex].Value);
                    tabPage.Controls.Add(temp_level[rowIndex]);
                    for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                    {
                        for (int k = 0; k < size2; k++)
                        {
                            temp_level[rowIndex][columnIndex, k].Value = 0;
                        }
                    }
                }
            }*/
        }



        private void NHYS_ValueChanged(object sender, EventArgs e)
        {


            //    temp_level[rowIndex].DataSource = dt[rowIndex];
            //    temp_level[rowIndex].Refresh();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Edit_Hy_Mod temp_form = new Edit_Hy_Mod(NHYS.Value);
            temp_form.ShowDialog();

        }




        private void button3_Click(object sender, EventArgs e)
        {


            Edit_Columns_1 temp_form = new Edit_Columns_1(MCOL.Value);
            temp_form.ShowDialog();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            Edit_Columns temp_form = new Edit_Columns(MCOL.Value);
            temp_form.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Edit_Beams_1 temp_form = new Edit_Beams_1(MBEM.Value);
            temp_form.ShowDialog();

            //  label49.Enabled = true;
            //   dataGridView4.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Edit_Beams_2 temp_form = new Edit_Beams_2(MBEM.Value);
            temp_form.ShowDialog();

            //  label49.Enabled = true;
            //   dataGridView4.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Edit_Shear_1 temp_form = new Edit_Shear_1(MWAL.Value);
            temp_form.ShowDialog();

            //  label49.Enabled = true;
            //   dataGridView4.Enabled = true;
        }


        private void button8_Click(object sender, EventArgs e)
        {
            Edit_Shear_2 temp_form = new Edit_Shear_2(MWAL.Value);
            temp_form.ShowDialog();
            //  label49.Enabled = true;
            //   dataGridView4.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Edit_Edge temp_form = new Edit_Edge(MEDG.Value);
            temp_form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Edit_Transverse temp_form = new Edit_Transverse(MTRN.Value);
            temp_form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Edit_Rotational temp_form = new Edit_Rotational(MSPR.Value);
            temp_form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Edit_Visco temp_form = new Edit_Visco(MBRV.Value, ITDVCON.Checked);
            temp_form.ShowDialog();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Edit_Friction temp_form = new Edit_Friction(MBRF.Value, ITDFCON.Checked);
            temp_form.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Edit_Hysteretic temp_form = new Edit_Hysteretic(MBRH.Value, ITDHCON.Checked);
            temp_form.ShowDialog();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void IUBEM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Edit_Concrete temp_form = new Edit_Concrete(NCON.Value);
            temp_form.ShowDialog();

        }

        private void button16_Click(object sender, EventArgs e)
        {

            Edit_REINFORCEMENT temp_form = new Edit_REINFORCEMENT(NSTL.Value);
            temp_form.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Edit_MASONRY temp_form = new Edit_MASONRY(NMSR.Value);
            temp_form.ShowDialog();
        }

        private void wizardPage1_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Edit_Concrete temp_form = new Edit_Concrete(NCON.Value);
            temp_form.ShowDialog();
        }

        private void NCON_ValueChanged(object sender, EventArgs e)
        {

            string tableName = "concrete";
            string insertTemplate = "insert into concrete (IM,FC,EC,EPS0,FT,EPSU,ZF) values({0},0,0,0,0,0,0)";
            string deleteTemplate = "Delete from concrete where IM={0}";
            ValueChangedHandler(tableName, (int)NCON.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (NCON.Value == 0)
                button15.Enabled = false;
            else
                button15.Enabled = true;
            return;

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NCON.Value == 0)
            //{
            //    button15.Enabled = false;
            //}

            //else
            //{
            //    button15.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from concrete";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NCON.Value; k++)
            //        {
            //            cmd.CommandText = "insert into concrete (IM,FC,EC,EPS0,FT,EPSU,ZF) values(" + k + ",0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}

            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void NSTL_ValueChanged(object sender, EventArgs e)
        {

            string tableName = "REINFORCEMENT";
            string insertTemplate = "insert into REINFORCEMENT (IM,FS,FSU,ES,ESH,EPSH) values({0},0,0,0,0,0)";
            string deleteTemplate = "Delete from REINFORCEMENT where IM={0}";
            ValueChangedHandler(tableName, (int)NSTL.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (NSTL.Value == 0)
            {
                button16.Enabled = false;

            }
            else
            {
                button16.Enabled = true;
            }
            return;


            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NSTL.Value == 0)
            //{
            //    button16.Enabled = false;

            //}
            //else
            //{
            //    button16.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from REINFORCEMENT";
            //        cmd.ExecuteNonQuery();

            //        for (int k = 1; k <= (int)NSTL.Value; k++)
            //        {
            //            cmd.CommandText = "insert into REINFORCEMENT (IM,FS,FSU,ES,ESH,EPSH) values(" + k + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }
        private void ValueChangedHandler(string tableName, int newValue, string insertTemplate, string deleteTemplate)
        {
            if (loading)
                return;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();

            if (newValue == 0)
            {
                cmd.CommandText = "begin";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from " + tableName;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end";
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            else
            {
                cmd.CommandText = "Select Count(*) from " + tableName;
                SQLiteDataReader rd = cmd.ExecuteReader();
                // rd.IsClosed
                if (rd.Read())
                {
                    int oldValue = rd.GetInt32(0);
                    rd.Close();
                    cn.Close();
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

                    if (newValue > oldValue)// Insert More Rows 
                    {

                        for (int i = 0; i < (newValue - oldValue); i++)
                        {
                            cmd.CommandText = String.Format(insertTemplate, (oldValue + i + 1));
                            cmd.ExecuteNonQuery();
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else if (newValue < oldValue) // Remove last rows 
                    {

                        while (oldValue != newValue)
                        {
                            cmd.CommandText = String.Format(deleteTemplate, oldValue);
                            cmd.ExecuteNonQuery();
                            oldValue--;
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    else
                    {
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                }
                else
                {
                    rd.Close();
                    cn.Close();
                    MessageBox.Show("Can't update " + tableName);
                    return;
                }
            }
        }
        private void NMSR_ValueChanged(object sender, EventArgs e)
        {

            string tableName = "MASONRY";
            string insertTemplate = "insert into MASONRY (IM, FM, FMCR, EPSM, VM, SIGMM, CFM) values({0},0,0,0,0,0,0)";
            string deleteTemplate = "Delete from MASONRY where IM={0}";
            ValueChangedHandler(tableName, (int)NMSR.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (NMSR.Value == 0)
            {
                button17.Enabled = false;

            }
            else
            {
                button17.Enabled = true;
            }
            return;

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


            //if (NMSR.Value == 0)
            //{
            //    button17.Enabled = false;
            //}
            //else
            //{
            //    button17.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from MASONRY";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NMSR.Value; k++)
            //        {
            //            cmd.CommandText = "insert into MASONRY (IM, FM, FMCR, EPSM, VM, SIGMM, CFM) values(" + k + ",0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }



        private void NHYS_ValueChanged_1(object sender, EventArgs e)
        {
            string tableName = "Hysteretic_1";
            string insertTemplate = "insert into Hysteretic_1 (IR, HC, HBD, HBE,HS, IBILINEAR, NTRANS, ETA, HSR, HSS, HSM, NGAP, PHIGAP, STIFFGAP,Ty) values({0},0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate = "Delete from Hysteretic_1 where IR={0}";
            ValueChangedHandler(tableName, (int)NHYS.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (NHYS.Value == 0)
            {
                button1.Enabled = false;

            }
            else
            {
                button1.Enabled = true;
            }
            return;




            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (NHYS.Value == 0)
            //{
            //    button1.Enabled = false;

            //}
            //else
            //{

            //    button1.Enabled = true;


            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from Hysteretic_1";
            //        cmd.ExecuteNonQuery();

            //        for (int k = 1; k <= (int)NHYS.Value; k++)
            //        {
            //            cmd.CommandText = "insert into Hysteretic_1 (IR, HC, HBD, HBE,HS, IBILINEAR, NTRANS, ETA, HSR, HSS, HSM, NGAP, PHIGAP, STIFFGAP,Ty) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void IUCOL_CheckedChanged(object sender, EventArgs e)
        {
            if (IUCOL.Checked)
            {
                button3.Enabled = true;
                button4.Enabled = false;
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void IUBEM_CheckedChanged_1(object sender, EventArgs e)
        {
            if (IUBEM.Checked)
            {
                button5.Enabled = true;
                button6.Enabled = false;
            }
            else
            {
                button5.Enabled = false;
                button6.Enabled = true;
            }
        }

        private void IUWAL_CheckedChanged(object sender, EventArgs e)
        {
            if (IUWAL.Checked)
            {
                button7.Enabled = true;
                button8.Enabled = false;
            }
            else
            {
                button7.Enabled = false;
                button8.Enabled = true;
            }
        }

        private void IUSER_CheckedChanged(object sender, EventArgs e)
        {
            if (!IUSER.Checked)
            {
                button15.Enabled = false;
                button16.Enabled = false;
                button17.Enabled = false;
            }
            else
            {
                button15.Enabled = true;
                button16.Enabled = true;
                button17.Enabled = true;
            }
        }

        private void MCOL_ValueChanged(object sender, EventArgs e)
        {

            string tableName1 = "columns";
            string insertTemplate1 = "insert into Columns (KC, ICTYPE, AN, ANYY, ANB, AMLC, RAMC1, RAMC2, KHYSC, EI, EA, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N, KHYSC_1, GA_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1, AN_2, ANY_2, ANB_2, AMLC_2, RAMC1_2, RAMC2_2, NEV_2, KHYSC_2, EI_2, EA_2, PCP_2, PYP_2, UYP_2, UNSP_2, ULP_2, EI3P_2, PCN_2, PYN_2, UYN_2, UNSN_2, ULN_2, EI3N_2, UUP_2, UUN_2, KHYSC_t, EI_t, EA_t, PCP_t, PYP_t, UYP_t, UUP_t, EI3P_t, PCN_t, PYN_t, UYN_t, UUN_t, EI3N_t,KHYSC_2_t,EI_2_t,EA_2_t,PCP_2_t,PYP_2_t,UYP_2_t,UNSP_2_t,ULP_2_t,EI3P_2_t,PCN_2_t,PYN_2_t,UYN_2_t,UNSN_2_t,ULN_2_t,EI3N_2_t,UUP_2_t,UUN_2_t) values({0},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate1 = "Delete from Columns where KC={0}";

            string tableName2 = "columns_1";
            string insertTemplate2 = "insert into columns_1 (KC, ICTYPE, IMC, IMS, AN, AMLC, RAMC1, RAMC2, KHYSC, D, B, DC, AT, HBD, HBS, CEF, KHYSC_t, D_t, B_t, DC_t, AT_t, HBD_t, HBS_t, CEF_t, KHYSC_1, IMC_2, IMS_2, KHYSC_2, AMLC_2, RAMC1_2, RAMC2_2, AN_2, DO_2, CVR_2, DST_2, NBAR_2, BDIA_2, HBD_2, HBS_2) values({0},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate2 = "Delete from columns_1 where KC={0}";

            ValueChangedHandler(tableName1, (int)MCOL.Value, insertTemplate1, deleteTemplate1);
            ValueChangedHandler(tableName2, (int)MCOL.Value, insertTemplate2, deleteTemplate2);
            validateRanges();

            if (MCOL.Value == 0)
            {
                groupBox11.Enabled = false;
            }
            else
                groupBox11.Enabled = true;

            return;



            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (!Var.Dont_del)
            //{
            //    cmd.CommandText = "Delete from columns";
            //    cmd.ExecuteNonQuery();
            //    cmd.CommandText = "Delete from columns_1";
            //    cmd.ExecuteNonQuery();
            //    for (int k = 1; k <= (int)MCOL.Value; k++)
            //    {
            //        cmd.CommandText = "insert into Columns (KC, ICTYPE, AN, ANYY, ANB, AMLC, RAMC1, RAMC2, KHYSC, EI, EA, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N, KHYSC_1, GA_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1, AN_2, ANY_2, ANB_2, AMLC_2, RAMC1_2, RAMC2_2, NEV_2, KHYSC_2, EI_2, EA_2, PCP_2, PYP_2, UYP_2, UNSP_2, ULP_2, EI3P_2, PCN_2, PYN_2, UYN_2, UNSN_2, ULN_2, EI3N_2, UUP_2, UUN_2, KHYSC_t, EI_t, EA_t, PCP_t, PYP_t, UYP_t, UUP_t, EI3P_t, PCN_t, PYN_t, UYN_t, UUN_t, EI3N_t,KHYSC_2_t,EI_2_t,EA_2_t,PCP_2_t,PYP_2_t,UYP_2_t,UNSP_2_t,ULP_2_t,EI3P_2_t,PCN_2_t,PYN_2_t,UYN_2_t,UNSN_2_t,ULN_2_t,EI3N_2_t,UUP_2_t,UUN_2_t) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            //        cmd.ExecuteNonQuery();
            //    }
            //    for (int k = 1; k <= (int)MCOL.Value; k++)
            //    {
            //        cmd.CommandText = "insert into columns_1 (KC, ICTYPE, IMC, IMS, AN, AMLC, RAMC1, RAMC2, KHYSC, D, B, DC, AT, HBD, HBS, CEF, KHYSC_t, D_t, B_t, DC_t, AT_t, HBD_t, HBS_t, CEF_t, KHYSC_1, IMC_2, IMS_2, KHYSC_2, AMLC_2, RAMC1_2, RAMC2_2, AN_2, DO_2, CVR_2, DST_2, NBAR_2, BDIA_2, HBD_2, HBS_2) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            //        cmd.ExecuteNonQuery();
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
            //if (MCOL.Value == 0)
            //{
            //    groupBox11.Enabled = false;
            //}
            //else
            //    groupBox11.Enabled = true;

        }

        private void MBEM_ValueChanged(object sender, EventArgs e)
        {
            string tableName1 = "beams_1";
            string insertTemplate1 = "insert into beams_1 (KB, ICTYPE, IMC, IMS, AMLB, RAMB1, RAMB2, KHYSB, D, B, BSL, TSL, BC, AT1, AT2, HBD, HBS, KHYSB_1,KHYSB_t,D_t,B_t,BSL_t,TSL_t,BC_t,AT1_t,AT2_t,HBD_t,HBS_t) values({0},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate1 = "Delete from beams_1 where KB={0}";

            string tableName2 = "beams_2";
            string insertTemplate2 = "insert into beams_2 (KB, ICTYPE, AMLB, RAMB1, RAMB2, KHYSB, EI, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N, KHYSB_1, GA_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1,KHYSB_t,EI_t,PCP_t,PYP_t,UYP_t,UUP_t,EI3P_t,PCN_t,PYN_t,UYN_t,UUN_t,EI3N_t) values({0},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate2 = "Delete from beams_2 where KB={0}";

            ValueChangedHandler(tableName1, (int)MBEM.Value, insertTemplate1, deleteTemplate1);
            ValueChangedHandler(tableName2, (int)MBEM.Value, insertTemplate2, deleteTemplate2);
            validateRanges();

            if (MBEM.Value == 0)
            {
                groupBox12.Enabled = false;
            }
            else
                groupBox12.Enabled = true;

            return;



            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (!Var.Dont_del)
            //{
            //    cmd.CommandText = "Delete from beams_1";
            //    cmd.ExecuteNonQuery();
            //    cmd.CommandText = "Delete from beams_2";
            //    cmd.ExecuteNonQuery();
            //    for (int k = 1; k <= (int)MBEM.Value; k++)
            //    {
            //        cmd.CommandText = "insert into beams_1 (KB, ICTYPE, IMC, IMS, AMLB, RAMB1, RAMB2, KHYSB, D, B, BSL, TSL, BC, AT1, AT2, HBD, HBS, KHYSB_1,KHYSB_t,D_t,B_t,BSL_t,TSL_t,BC_t,AT1_t,AT2_t,HBD_t,HBS_t) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            //        cmd.ExecuteNonQuery();
            //    }
            //    for (int k = 1; k <= (int)MBEM.Value; k++)
            //    {
            //        cmd.CommandText = "insert into beams_2 (KB, ICTYPE, AMLB, RAMB1, RAMB2, KHYSB, EI, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N, KHYSB_1, GA_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1,KHYSB_t,EI_t,PCP_t,PYP_t,UYP_t,UUP_t,EI3P_t,PCN_t,PYN_t,UYN_t,UUN_t,EI3N_t) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            //        cmd.ExecuteNonQuery();
            //    }

            //} cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
            //if (MBEM.Value == 0)
            //{
            //    groupBox12.Enabled = false;
            //}
            //else
            //    groupBox12.Enabled = true;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            C_column temp_form = new C_column(NCOL.Value);
            temp_form.ShowDialog();
        }

        private void NCOL_ValueChanged(object sender, EventArgs e)
        {

            string tableName = "C_column";
            string insertTemplate = "insert into C_column (M, ITC, IC, JC, LBC, LTC) values({0},0,0,0,0,0)";
            string deleteTemplate = "Delete from C_column where M={0}";
            ValueChangedHandler(tableName, (int)NCOL.Value, insertTemplate, deleteTemplate);

            if (NCOL.Value == 0)
            {
                button18.Enabled = false;

            }
            else
            {
                button18.Enabled = true;
            }
            return;



            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NCOL.Value == 0)
            //{
            //    button18.Enabled = false;
            //}
            //else
            //{
            //    button18.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_column";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NCOL.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_column (M, ITC, IC, JC, LBC, LTC) values(" + k + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            C_beam temp_form = new C_beam(NBEM.Value);
            temp_form.ShowDialog();
        }

        private void NBEM_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "C_beam";
            string insertTemplate = "insert into C_beam (M, ITB, LB, IB, JLB, JRB) values({0},0,0,0,0,0)";
            string deleteTemplate = "Delete from C_beam where M={0}";
            ValueChangedHandler(tableName, (int)NBEM.Value, insertTemplate, deleteTemplate);

            if (NBEM.Value == 0)
            {
                button19.Enabled = false;

            }
            else
            {
                button19.Enabled = true;
            }
            return;





            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NBEM.Value == 0)
            //{
            //    button19.Enabled = false;
            //}
            //else
            //{
            //    button19.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_beam";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NBEM.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_beam (M, ITB, LB, IB, JLB, JRB) values(" + k + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            C_edge temp_form = new C_edge(NEDG.Value);
            temp_form.ShowDialog();
        }

        private void NWAL_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "C_shear";
            string insertTemplate = "insert into C_shear (M, ITW, IW, JW, LBW, LTW) values({0},0,0,0,0,0)";
            string deleteTemplate = "Delete from C_shear where M={0}";
            ValueChangedHandler(tableName, (int)NWAL.Value, insertTemplate, deleteTemplate);

            if (NWAL.Value == 0)
            {
                button20.Enabled = false;

            }
            else
            {
                button20.Enabled = true;
            }
            return;






            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NWAL.Value == 0)
            //{
            //    button20.Enabled = false;
            //}
            //else
            //{
            //    button20.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_shear";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NWAL.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_shear (M, ITW, IW, JW, LBW, LTW) values(" + k + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }

            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void NEDG_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "C_edge";
            string insertTemplate = "insert into C_edge (M, ITE, IE, JE, LBE, LTE) values({0},0,0,0,0,0)";
            string deleteTemplate = "Delete  from C_edge where M={0}";
            ValueChangedHandler(tableName, (int)NEDG.Value, insertTemplate, deleteTemplate);

            if (NEDG.Value == 0)
            {
                button21.Enabled = false;

            }
            else
            {
                button21.Enabled = true;
            }
            return;



            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NEDG.Value == 0)
            //{
            //    button21.Enabled = false;
            //}
            //else
            //{
            //    button21.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_edge";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NEDG.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_edge (M, ITE, IE, JE, LBE, LTE) values(" + k + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            C_Transverse temp_form = new C_Transverse(NTRN.Value);
            temp_form.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            C_Spring temp_form = new C_Spring(NSPR.Value);
            temp_form.ShowDialog();
        }

        private void NTRN_ValueChanged(object sender, EventArgs e)
        {

            string tableName = "C_Transverse";
            string insertTemplate = "insert into C_Transverse (M, ITT, LT, IWT, JWT, IFT, JFT) values({0},0,0,0,0,0,0)";
            string deleteTemplate = "Delete from C_Transverse where M={0}";
            ValueChangedHandler(tableName, (int)NTRN.Value, insertTemplate, deleteTemplate);

            if (NTRN.Value == 0)
            {
                button22.Enabled = false;

            }
            else
            {
                button22.Enabled = true;
            }
            return;



            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NTRN.Value == 0)
            //{
            //    button22.Enabled = false;
            //}
            //else
            //{
            //    button22.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_Transverse";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NTRN.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_Transverse (M, ITT, LT, IWT, JWT, IFT, JFT) values(" + k + ",0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void NSPR_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "C_Spring";
            string insertTemplate = "insert into C_Spring (M, ITRSP, ISP, JSP, LSP, KSPL) values({0},0,0,0,0,0)";
            string deleteTemplate = "Delete from C_Spring where M={0}";
            ValueChangedHandler(tableName, (int)NSPR.Value, insertTemplate, deleteTemplate);

            if (NSPR.Value == 0)
            {
                button23.Enabled = false;

            }
            else
            {
                button23.Enabled = true;
            }
            return;




            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NSPR.Value == 0)
            //{
            //    button23.Enabled = false;
            //}
            //else
            //{
            //    button23.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_Spring";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NSPR.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_Spring (M, ITRSP, ISP, JSP, LSP, KSPL) values(" + k + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }
        private void button24_Click(object sender, EventArgs e)
        {
            C_Moment temp_form = new C_Moment(NMR.Value);
            temp_form.ShowDialog();
        }
        private void button25_Click(object sender, EventArgs e)
        {
            C_brace temp_form = new C_brace(NBR.Value);
            temp_form.ShowDialog();
        }

        private void NMR_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "C_Moment";
            string insertTemplate = "insert into C_Moment (IDM, IHTY, INUM, IREG) values({0},0,0,0)";
            string deleteTemplate = "Delete from C_Moment where IDM={0}";
            ValueChangedHandler(tableName, (int)NMR.Value, insertTemplate, deleteTemplate);

            if (NMR.Value == 0)
            {
                button24.Enabled = false;

            }
            else
            {
                button24.Enabled = true;
            }
            return;





            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NMR.Value == 0)
            //{
            //    button24.Enabled = false;
            //}
            //else
            //{
            //    button24.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_Moment";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NMR.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_Moment (IDM, IHTY, INUM, IREG) values(" + k + ",0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }


            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void NBR_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "C_Brace";
            string insertTemplate = "insert into C_Brace (M, IF_1, ITBR, ITD, LT, LB, JT, JB, AMLBR) values({0},0,0,0,0,0,0,0,0)";
            string deleteTemplate = "Delete from C_Brace where M={0}";
            ValueChangedHandler(tableName, (int)NBR.Value, insertTemplate, deleteTemplate);

            if (NBR.Value == 0)
            {
                button25.Enabled = false;

            }
            else
            {
                button25.Enabled = true;
            }
            return;



            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NBR.Value == 0)
            //{
            //    button25.Enabled = false;
            //}
            //else
            //{
            //    button25.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_Brace";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NBR.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_Brace (M, IF_1, ITBR, ITD, LT, LB, JT, JB, AMLBR) values(" + k + ",0,0,0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void button26_Click(object sender, EventArgs e)
        {
            C_Infill temp_form = new C_Infill(NIW.Value);
            temp_form.ShowDialog();
        }

        private void NIW_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "C_Infill";
            string insertTemplate = "insert into C_Infill (M, IF_1, ITIW, LT, LB, JL, JR, JBMT) values({0},0,0,0,0,0,0,0)";
            string deleteTemplate = "Delete from C_Infill where M={0}";
            ValueChangedHandler(tableName, (int)NIW.Value, insertTemplate, deleteTemplate);

            if (NIW.Value == 0)
            {
                button26.Enabled = false;

            }
            else
            {
                button26.Enabled = true;
            }
            return;




            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //if (NIW.Value == 0)
            //{
            //    button26.Enabled = false;
            //}
            //else
            //{
            //    button26.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from C_Infill";
            //        cmd.ExecuteNonQuery();
            //        for (int k = 1; k <= (int)NIW.Value; k++)
            //        {
            //            cmd.CommandText = "insert into C_Infill (M, IF_1, ITIW, LT, LB, JL, JR, JBMT) values(" + k + ",0,0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }






        private void ReadfromDB(String i)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            temp_in.Text = "";
            temp_in.Text += title.Text + "\n";
            temp_in.Text += textBox1.Text + "\n";
            temp_in.Text += NSO.Value + ", " + NFR.Value + ", " + NCON.Value + ", " + NSTL.Value + ", " + NMSR.Value + ", ";

            if (NPDEL.Checked)
                temp_in.Text += "1, ";
            else
                temp_in.Text += "0, ";
            if (IFLEX.Checked)
                temp_in.Text += "0, ";
            else
                temp_in.Text += "1, ";
            if (IFLEXDIST.Checked)
                temp_in.Text += "0, ";
            else
                temp_in.Text += "1, ";

            temp_in.Text += "1\n";
            temp_in.Text += textBox2.Text + "\n";

            temp_in.Text += MCOL.Value + ", " + MBEM.Value + ", " + MWAL.Value + ", " + MEDG.Value + ", " + MTRN.Value + ", " + MSPR.Value + ", " + MBRV.Value + ", " + MBRF.Value + ", " + MBRH.Value + ", " + MIW.Value + "\n";

            temp_in.Text += textBox3.Text + "\n";
            temp_in.Text += NCOL.Value + ", " + NBEM.Value + ", " + NWAL.Value + ", " + NEDG.Value + ", " + NTRN.Value + ", " + NSPR.Value + ", " + NMR.Value + ", " + NBR.Value + ", " + NIW.Value + "\n";

            temp_in.Text += textBox4.Text + "\n";
            if (IU.Checked)
                temp_in.Text += "2\n";
            else
                temp_in.Text += "1\n";

            temp_in.Text += textBox5.Text + "\n";
            for (int rowIndex = Convert.ToInt32(NSO.Value) - 1; rowIndex >= 0; rowIndex--)
            {
                temp_in.Text += data1["HIGT", rowIndex].Value.ToString();
                if (rowIndex != 0)
                    temp_in.Text += ", ";
                else
                    temp_in.Text += "\n";
            }

            temp_in.Text += textBox6.Text + "\n";

            for (int rowIndex = 0; rowIndex < Convert.ToInt32(NFR.Value); rowIndex++)
            {
                temp_in.Text += data2["NDUP", rowIndex].Value.ToString();
                if (rowIndex != NFR.Value - 1)
                    temp_in.Text += ", ";
                else
                    temp_in.Text += "\n";
            }

            temp_in.Text += textBox7.Text + "\n";
            for (int rowIndex = 0; rowIndex < NFR.Value; rowIndex++)
            {
                temp_in.Text += data2["NVLN", rowIndex].Value.ToString();
                if (rowIndex != NFR.Value - 1)
                    temp_in.Text += ", ";
                else
                    temp_in.Text += "\n";
            }

            temp_in.Text += textBox8.Text + "\n";

            //for (int rowIndex = 0; rowIndex < NFR.Value; ++rowIndex)
            //{
            //    for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
            //    {
            //        for (int k = 0; k < NSO.Value; k++)
            //        {
            //            temp_level[rowIndex][columnIndex, k].Value.ToString();
            //        }
            //    }
            //}

            for (int k = (Convert.ToInt16(NSO.Value)) - 1; k >= 0; k--) /////EDIT: 
            {
                temp_in.Text += ((Convert.ToInt16(NSO.Value)) - (k + 1) + 1).ToString() + ", ";
                for (int rowIndex = 0; rowIndex < NFR.Value; ++rowIndex)
                {
                    if (rowIndex != 0)
                        temp_in.Text += "   ";
                    temp_in.Text += (rowIndex + 1).ToString() + ", ";
                    for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                    {

                        temp_in.Text += temp_level[rowIndex][columnIndex, k].Value.ToString();
                        if (columnIndex != temp_level[rowIndex].ColumnCount - 1)
                            temp_in.Text += ", ";
                    }
                    temp_in.Text += "\n";
                }
            }

            temp_in.Text += textBox9.Text + "\n";
            if (IUSER.Checked)
                temp_in.Text += "0\n";
            else
                temp_in.Text += "1\n";
            if (IUSER.Checked && NCON.Value != 0)
            {
                temp_in.Text += textBox10.Text + "\n";
                cmd.CommandText = "select * from concrete";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_in.Text += reader["IM"].ToString() + ", " + reader["FC"].ToString() + ", " + reader["EC"].ToString() + ", " + reader["EPS0"].ToString() + ", " + reader["FT"].ToString() + ", " + reader["EPSU"].ToString() + ", " + reader["ZF"].ToString() + "\n";
                }
                reader.Close();
            }

            if (IUSER.Checked && NSTL.Value != 0)
            {

                temp_in.Text += textBox11.Text + "\n";
                cmd.CommandText = "select * from REINFORCEMENT";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_in.Text += reader["IM"].ToString() + ", " + reader["FS"].ToString() + ", " + reader["FSU"].ToString() + ", " + reader["ES"].ToString() + ", " + reader["ESH"].ToString() + ", " + reader["EPSH"].ToString() + "\n";
                } reader.Close();

            }

            if (IUSER.Checked && NMSR.Value != 0)
            {
                temp_in.Text += textBox12.Text + "\n";
                cmd.CommandText = "select * from MASONRY";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_in.Text += reader["IM"].ToString() + ", " + reader["FM"].ToString() + ", " + reader["FMCR"].ToString() + ", " + reader["EPSM"].ToString() + ", " + reader["VM"].ToString() + ", " + reader["SIGMM"].ToString() + ", " + reader["CFM"].ToString() + "\n";
                } reader.Close();

            }

            temp_in.Text += textBox13.Text + "\n";
            temp_in.Text += NHYS.Value.ToString() + "\n";
            if (NHYS.Value != 0)
            {

                cmd.CommandText = "select * from Hysteretic_1";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ty"].ToString() == "0")
                        temp_in.Text += reader["IR"].ToString() + ", " + "1" + ", " + reader["HC"].ToString() + ", " + reader["HBD"].ToString() + ", " + reader["HBE"].ToString() + ", " + reader["HS"].ToString() + ", " + reader["IBILINEAR"].ToString() + "\n";
                    else if (reader["ty"].ToString() == "1")
                        temp_in.Text += reader["IR"].ToString() + ", " + "2" + ", " + reader["HC"].ToString() + ", " + reader["HBD"].ToString() + ", " + reader["HBE"].ToString() + ", " + reader["NTRANS"].ToString() + ", " + reader["ETA"].ToString() + ", " + reader["HSR"].ToString() + ", " + reader["HSS"].ToString() + ", " + reader["HSM"].ToString() + ", " + reader["NGAP"].ToString() + ", " + reader["PHIGAP"].ToString() + ", " + reader["STIFFGAP"].ToString() + "\n";
                } reader.Close();

            }
            if (MCOL.Value != 0)
            {
                temp_in.Text += textBox14.Text + "\n";
                if (IUCOL.Checked)
                    temp_in.Text += "0\n";
                else
                    temp_in.Text += "1\n";
                temp_in.Text += textBox17.Text + "\n";
                if (IUCOL.Checked)
                {
                    //    temp_in.Text += "COLUMN DIMENSIONS\n";
                    cmd.CommandText = "select * from Columns_1";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["ICTYPE"].ToString() == "0")
                        {
                            temp_in.Text += (Convert.ToInt32(reader["ICTYPE"]) + 1).ToString() + "\n" + reader["KC"].ToString() + ", " + reader["IMC"].ToString() + ", " + reader["IMS"].ToString() + ", " + reader["AN"].ToString() + ", " + reader["AMLC"].ToString() + ", " + reader["RAMC1"].ToString() + ", " + reader["RAMC2"].ToString() + "\n";
                            temp_in.Text += "    " + reader["KHYSC"].ToString() + ", " + reader["D"].ToString() + ", " + reader["B"].ToString() + ", " + reader["DC"].ToString() + ", " + reader["AT"].ToString() + ", " + reader["HBD"].ToString() + ", " + reader["HBS"].ToString() + ", " + reader["CEF"] + "\n";
                            if (Convert.ToDecimal(reader["KHYSC"]) >= 0)
                            {
                                temp_in.Text += "    " + reader["KHYSC_t"].ToString() + ", " + reader["D_t"].ToString() + ", " + reader["B_t"].ToString() + ", " + reader["DC_t"].ToString() + ", " + reader["AT_t"].ToString() + ", " + reader["HBD_t"].ToString() + ", " + reader["HBS_t"].ToString() + ", " + reader["CEF"] + "\n";

                            }
                        }
                        else if (reader["ICTYPE"].ToString() == "1")
                        {
                            temp_in.Text += (Convert.ToInt32(reader["ICTYPE"]) + 1).ToString() + "\n" + reader["KC"].ToString() + ", " + reader["IMC"].ToString() + ", " + reader["IMS"].ToString() + ", " + reader["AN"].ToString() + ", " + reader["AMLC"].ToString() + ", " + reader["RAMC1"].ToString() + ", " + reader["RAMC2"].ToString() + "\n";
                            temp_in.Text += "    " + reader["KHYSC"].ToString() + ", " + reader["D"].ToString() + ", " + reader["B"].ToString() + ", " + reader["DC"].ToString() + ", " + reader["AT"].ToString() + ", " + reader["HBD"].ToString() + ", " + reader["HBS"].ToString() + ", " + reader["CEF"] + "\n";
                            if (Convert.ToDecimal(reader["KHYSC"]) >= 0)
                            {
                                temp_in.Text += "    " + reader["KHYSC"].ToString() + ", " + reader["D"].ToString() + ", " + reader["B"].ToString() + ", " + reader["DC"].ToString() + ", " + reader["AT"].ToString() + ", " + reader["HBD"].ToString() + ", " + reader["HBS"].ToString() + ", " + reader["CEF"] + "\n";

                            }
                            temp_in.Text += reader["KHYSC_1"].ToString() + "\n";
                        }
                        else if (reader["ICTYPE"].ToString() == "2")
                        {
                            temp_in.Text += (Convert.ToInt16(reader["ICTYPE"]) + 1).ToString() + "\n" + reader["KC"].ToString() + ", " + reader["IMC_2"].ToString() + ", " + reader["IMS_2"].ToString() + ", " + reader["KHYSC_2"].ToString() + ", " + reader["AMLC_2"].ToString() + ", " + reader["RAMC1_2"].ToString() + ", " + reader["RAMC2_2"].ToString() + "\n" + "        " + reader["AN_2"].ToString() + ", " + reader["DO_2"].ToString() + ", " + reader["CVR_2"].ToString() + ", " + reader["DST_2"].ToString() + ", " + reader["NBAR_2"].ToString() + ", " + reader["BDIA_2"].ToString() + ", " + reader["HBD_2"].ToString() + ", " + reader["HBS_2"] + "\n";

                        }
                    } reader.Close();
                }

                else
                {
                    //D3
                    // temp_in.Text += "USER INPUT COLUMN PROPERTIES (Rectangular or Circular)\n";
                    cmd.CommandText = "select * from Columns";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temp_in.Text += (Convert.ToInt32(reader["ICTYPE"]) + 1).ToString() + "\n";
                        if (reader["ICTYPE"].ToString() == "0")
                        {
                            temp_in.Text += reader["KC"].ToString() + ", " + reader["AN"].ToString() + ", " + reader["ANYY"].ToString() + ", " + reader["ANB"].ToString() + ", " + reader["AMLC"].ToString() + ", " + reader["RAMC1"].ToString() + ", " + reader["RAMC2"] + "\n";
                            temp_in.Text += "  " + reader["KHYSC"].ToString() + ", " + reader["EI"].ToString() + ", " + reader["EA"].ToString() + ", " + reader["PCP"].ToString() + ", " + reader["PYP"].ToString() + ", " + reader["UYP"].ToString() + ", " + reader["UUP"].ToString() + ", " + reader["EI3P"] + ", \n";
                            temp_in.Text += "    " + reader["PCN"].ToString() + ", " + reader["PYN"].ToString() + ", " + reader["UYN"].ToString() + ", " + reader["UUN"].ToString() + ", " + reader["EI3N"] + "\n";
                            if (Convert.ToDecimal(reader["KHYSC"]) >= 0)
                            {
                                temp_in.Text += "  " + reader["KHYSC_t"].ToString() + ", " + reader["EI_t"].ToString() + ", " + reader["EA_t"].ToString() + ", " + reader["PCP_t"].ToString() + ", " + reader["PYP_t"].ToString() + ", " + reader["UYP_t"].ToString() + ", " + reader["UUP_t"].ToString() + ", " + reader["EI3P_t"] + "\n";
                                temp_in.Text += "    " + reader["PCN_t"].ToString() + ", " + reader["PYN_t"].ToString() + ", " + reader["UYN_t"].ToString() + ", " + reader["UUN_t"].ToString() + ", " + reader["EI3N_t"] + "\n";


                            }
                        }
                        else if (reader["ICTYPE"].ToString() == "1")
                        {
                            temp_in.Text += reader["KC"].ToString() + ", " + reader["AN"].ToString() + ", " + reader["ANYY"].ToString() + ", " + reader["ANB"].ToString() + ", " + reader["AMLC"].ToString() + ", " + reader["RAMC1"].ToString() + ", " + reader["RAMC2"] + "\n";
                            temp_in.Text += "  " + reader["KHYSC"].ToString() + ", " + reader["EI"].ToString() + ", " + reader["EA"].ToString() + ", " + reader["PCP"].ToString() + ", " + reader["PYP"].ToString() + ", " + reader["UYP"].ToString() + ", " + reader["UUP"].ToString() + ", " + reader["EI3P"] + ", \n";
                            temp_in.Text += "    " + reader["PCN"].ToString() + ", " + reader["PYN"].ToString() + ", " + reader["UYN"].ToString() + ", " + reader["UUN"].ToString() + ", " + reader["EI3N"] + "\n";
                            if (Convert.ToDecimal(reader["KHYSC"]) >= 0)
                            {
                                temp_in.Text += "  " + reader["KHYSC"].ToString() + ", " + reader["EI"].ToString() + ", " + reader["EA"].ToString() + ", " + reader["PCP"].ToString() + ", " + reader["PYP"].ToString() + ", " + reader["UYP"].ToString() + ", " + reader["UUP"].ToString() + ", " + reader["EI3P"] + "\n";
                                temp_in.Text += "    " + reader["PCN"].ToString() + ", " + reader["PYN"].ToString() + ", " + reader["UYN"].ToString() + ", " + reader["UUN"].ToString() + ", " + reader["EI3N"] + "\n";


                            }

                            temp_in.Text += "  " + reader["KHYSC_1"].ToString() + ", " + reader["GA_1"].ToString() + ", " + reader["PCP_1"].ToString() + ", " + reader["PYP_1"].ToString() + ", " + reader["UYP_1"].ToString() + ", " + reader["UUP_1"].ToString() + ", " + reader["EI3P_1"] + ", \n";
                            temp_in.Text += "    " + reader["PCN_1"].ToString() + ", " + reader["PYN_1"].ToString() + ", " + reader["UYN_1"].ToString() + ", " + reader["UUN_1"].ToString() + ", " + reader["EI3N_1"] + "\n";
                        }
                        else if (reader["ICTYPE"].ToString() == "2")
                        {
                            temp_in.Text += reader["KC"].ToString() + ", " + reader["AN_2"].ToString() + ", " + reader["ANY_2"].ToString() + ", " + reader["ANB_2"].ToString() + ", " + reader["AMLC_2"].ToString() + ", " + reader["RAMC1_2"].ToString() + ", " + reader["RAMC2_2"].ToString() + ", ";

                            if (reader["NEV_2"].ToString() == "1")
                            {
                                temp_in.Text += "0\n" + reader["KHYSC_2"].ToString() + ", " + reader["EI_2"].ToString() + ", " + reader["EA_2"].ToString() + ", " + reader["PCP_2"].ToString() + ", " + reader["PYP_2"].ToString() + ", " + reader["UYP_2"].ToString() + ", " + reader["UNSP_2"].ToString() + ", " + reader["ULP_2"] + ", \n";
                                temp_in.Text += reader["EI3P_2"].ToString() + ", " + reader["PCN_2"].ToString() + ", " + reader["PYN_2"].ToString() + ", " + reader["UYN_2"].ToString() + ", " + reader["UNSN_2"].ToString() + ", " + reader["ULN_2"].ToString() + ", " + reader["EI3N_2"] + "\n";
                                if (Convert.ToDecimal(reader["KHYSC_2"]) >= 0)
                                {
                                    temp_in.Text += reader["KHYSC_2_t"].ToString() + ", " + reader["EI_2_t"].ToString() + ", " + reader["EA_2_t"].ToString() + ", " + reader["PCP_2_t"].ToString() + ", " + reader["PYP_2_t"].ToString() + ", " + reader["UYP_2_t"].ToString() + ", " + reader["UNSP_2_t"].ToString() + ", " + reader["ULP_2_t"] + ", \n";
                                    temp_in.Text += reader["EI3P_2_t"].ToString() + ", " + reader["PCN_2_t"].ToString() + ", " + reader["PYN_2_t"].ToString() + ", " + reader["UYN_2_t"].ToString() + ", " + reader["UNSN_2_t"].ToString() + ", " + reader["ULN_2_t"].ToString() + ", " + reader["EI3N_2_t"] + "\n";
                                }
                            }
                            else
                            {
                                temp_in.Text += "1\n" + reader["KHYSC_2"].ToString() + ", " + reader["EI_2"].ToString() + ", " + reader["EA_2"].ToString() + ", " + reader["PCP_2"].ToString() + ", " + reader["PYP_2"].ToString() + ", " + reader["UYP_2"].ToString() + ", " + reader["UNSP_2"].ToString() + ", " + reader["UUP_2"] + ", \n";
                                temp_in.Text += reader["EI3P_2"].ToString() + ", " + reader["PCN_2"].ToString() + ", " + reader["PYN_2"].ToString() + ", " + reader["UYN_2"].ToString() + ", " + reader["UNSN_2"].ToString() + ", " + reader["UUN_2"].ToString() + ", " + reader["EI3N_2"] + "\n";
                                if (Convert.ToDecimal(reader["KHYSC_2"]) >= 0)
                                {
                                    temp_in.Text += reader["KHYSC_2_t"].ToString() + ", " + reader["EI_2_t"].ToString() + ", " + reader["EA_2_t"].ToString() + ", " + reader["PCP_2_t"].ToString() + ", " + reader["PYP_2_t"].ToString() + ", " + reader["UYP_2_t"].ToString() + ", " + reader["UNSP_2_t"].ToString() + ", " + reader["ULP_2_t"] + ", \n";
                                    temp_in.Text += reader["EI3P_2_t"].ToString() + ", " + reader["PCN_2_t"].ToString() + ", " + reader["PYN_2_t"].ToString() + ", " + reader["UYN_2_t"].ToString() + ", " + reader["UNSN_2_t"].ToString() + ", " + reader["ULN_2_t"].ToString() + ", " + reader["EI3N_2_t"] + "\n";
                                }

                            }
                        }
                    } reader.Close();
                }

            }
            if (MBEM.Value != 0)
            {
                temp_in.Text += textBox15.Text + "\n";
                if (IUBEM.Checked)
                {
                    temp_in.Text += "0\n";
                    temp_in.Text += textBox18.Text + "\n";
                    cmd.CommandText = "select * from Beams_1";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temp_in.Text += (Convert.ToInt32(reader["ICTYPE"]) + 1).ToString() + "\n";
                        if (reader["ICTYPE"].ToString() == "0")
                        {
                            temp_in.Text += reader["KB"].ToString() + ", " + reader["IMC"].ToString() + ", " + reader["IMS"].ToString() + ", " + reader["AMLB"].ToString() + ", " + reader["RAMB1"].ToString() + ", " + reader["RAMB2"].ToString() + "\n";
                            temp_in.Text += reader["KHYSB"].ToString() + ", " + reader["D"].ToString() + ", " + reader["B"].ToString() + ", " + reader["BSL"].ToString() + ", " + reader["TSL"].ToString() + ", " + reader["BC"].ToString() + ", " + reader["AT1"].ToString() + ", " + reader["AT2"].ToString() + ", " + reader["HBD"].ToString() + ", " + reader["HBS"].ToString() + "\n";

                            if (Convert.ToDecimal(reader["KHYSB"]) >= 0)
                            {
                                temp_in.Text += reader["KHYSB_t"].ToString() + ", " + reader["D_t"].ToString() + ", " + reader["B_t"].ToString() + ", " + reader["BSL_t"].ToString() + ", " + reader["TSL_t"].ToString() + ", " + reader["BC_t"].ToString() + ", " + reader["AT1_t"].ToString() + ", " + reader["AT2_t"].ToString() + ", " + reader["HBD_t"].ToString() + ", " + reader["HBS_t"].ToString() + "\n";

                            }
                        }
                        else
                        {
                            temp_in.Text += reader["KB"].ToString() + ", " + reader["IMC"].ToString() + ", " + reader["IMS"].ToString() + ", " + reader["AMLB"].ToString() + ", " + reader["RAMB1"].ToString() + ", " + reader["RAMB2"].ToString() + "\n";
                            temp_in.Text += reader["KHYSB"].ToString() + ", " + reader["D"].ToString() + ", " + reader["B"].ToString() + ", " + reader["BSL"].ToString() + ", " + reader["TSL"].ToString() + ", " + reader["BC"].ToString() + ", " + reader["AT1"].ToString() + ", " + reader["AT2"].ToString() + ", " + reader["HBD"].ToString() + ", " + reader["HBS"].ToString() + "\n";
                            /*Not Sure*/
                            if (Convert.ToDecimal(reader["KHYSB"]) >= 0)
                            {
                                temp_in.Text += reader["KHYSB_t"].ToString() + ", " + reader["D_t"].ToString() + ", " + reader["B_t"].ToString() + ", " + reader["BSL_t"].ToString() + ", " + reader["TSL_t"].ToString() + ", " + reader["BC_t"].ToString() + ", " + reader["AT1_t"].ToString() + ", " + reader["AT2_t"].ToString() + ", " + reader["HBD_t"].ToString() + ", " + reader["HBS_t"].ToString() + "\n";

                            }

                            temp_in.Text += reader["KHYSB_1"].ToString() + "\n";
                        }
                    } reader.Close();
                }
                else
                {
                    //E2
                    temp_in.Text += "1\n";
                    temp_in.Text += textBox18.Text + "\n";
                    cmd.CommandText = "select * from Beams_2";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temp_in.Text += (Convert.ToInt32(reader["ICTYPE"]) + 1).ToString() + "\n";
                        if (reader["ICTYPE"].ToString() == "0")
                        {
                            temp_in.Text += reader["KB"].ToString() + ", " + reader["AMLB"].ToString() + ", " + reader["RAMB1"].ToString() + ", " + reader["RAMB2"].ToString() + "\n";
                            temp_in.Text += reader["KHYSB"].ToString() + ", " + reader["EI"].ToString() + ", " + reader["PCP"].ToString() + ", " + reader["PYP"].ToString() + ", " + reader["UYP"].ToString() + ", " + reader["UUP"].ToString() + ", " + reader["EI3P"].ToString() + ", " + reader["PCN"].ToString() + ", " + reader["PYN"].ToString() + ", " + reader["UYN"].ToString() + ", " + reader["UUN"].ToString() + ", " + reader["EI3N"].ToString() + "\n";

                            if (Convert.ToDecimal(reader["KHYSB"]) >= 0)
                            {
                                temp_in.Text += reader["KHYSB_t"].ToString() + ", " + reader["EI_t"].ToString() + ", " + reader["PCP_t"].ToString() + ", " + reader["PYP_t"].ToString() + ", " + reader["UYP_t"].ToString() + ", " + reader["UUP_t"].ToString() + ", " + reader["EI3P_t"].ToString() + ", " + reader["PCN_t"].ToString() + ", " + reader["PYN_t"].ToString() + ", " + reader["UYN_t"].ToString() + ", " + reader["UUN_t"].ToString() + ", " + reader["EI3N_t"].ToString() + "\n";

                            }
                        }

                        else
                        {

                            temp_in.Text += reader["KB"].ToString() + ", " + reader["AMLB"].ToString() + ", " + reader["RAMB1"].ToString() + ", " + reader["RAMB2"].ToString() + "\n";
                            temp_in.Text += reader["KHYSB"].ToString() + ", " + reader["EI"].ToString() + ", " + reader["PCP"].ToString() + ", " + reader["PYP"].ToString() + ", " + reader["UYP"].ToString() + ", " + reader["UUP"].ToString() + ", " + reader["EI3P"].ToString() + ", " + reader["PCN"].ToString() + ", " + reader["PYN"].ToString() + ", " + reader["UYN"].ToString() + ", " + reader["UUN"].ToString() + ", " + reader["EI3N"].ToString() + "\n";
                            /*Not Sure*/
                            if (Convert.ToDecimal(reader["KHYSB"]) >= 0)
                            {
                                temp_in.Text += reader["KHYSB_t"].ToString() + ", " + reader["EI_t"].ToString() + ", " + reader["PCP_t"].ToString() + ", " + reader["PYP_t"].ToString() + ", " + reader["UYP_t"].ToString() + ", " + reader["UUP_t"].ToString() + ", " + reader["EI3P_t"].ToString() + ", " + reader["PCN_t"].ToString() + ", " + reader["PYN_t"].ToString() + ", " + reader["UYN_t"].ToString() + ", " + reader["UUN_t"].ToString() + ", " + reader["EI3N_t"].ToString() + "\n";

                            }
                            temp_in.Text += reader["KHYSB_1"].ToString() + ", " + reader["GA_1"].ToString() + ", " + reader["PCP_1"].ToString() + ", " + reader["PYP_1"].ToString() + ", " + reader["UYP_1"].ToString() + ", " + reader["UUP_1"].ToString() + ", " + reader["EI3P_1"].ToString() + ", " + reader["PCN_1"].ToString() + ", " + reader["PYN_1"].ToString() + ", " + reader["UYN_1"].ToString() + ", " + reader["UUN_1"].ToString() + ", " + reader["EI3N_1"].ToString() + "\n";
                        }
                    } reader.Close();

                }
            }
            //Shear , like Beam,

            ////////////////////
            ////////////////////

            if (MWAL.Value != 0)
            {
                temp_in.Text += textBox16.Text + "\n";
                if (IUWAL.Checked)
                {
                    temp_in.Text += "0\n";
                    temp_in.Text += textBox22.Text + "\n";
                    cmd.CommandText = "select * from Shear_1";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temp_in.Text += reader["KW"].ToString() + ", " + reader["IMC"].ToString() + ", " + reader["KHYSW_1"].ToString() + ", " + reader["KHYSW_2"].ToString() + ", " + reader["KHYSW_3"].ToString() + ", " + reader["AN"].ToString() + ", " + reader["AMLW"].ToString() + ", " + reader["NSECT"].ToString() + "\n";
                        SQLiteCommand cmd2 = new SQLiteCommand("select * from NSECT_" + reader["KW"], cn);
                        SQLiteDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            temp_in.Text += reader2["KS"].ToString() + ", " + reader2["IMS"].ToString() + ", " + reader2["DWAL"].ToString() + ", " + reader2["BWAL"].ToString() + ", " + reader2["PT"].ToString() + ", " + reader2["PW"].ToString() + "\n";
                        } reader2.Close();

                    } reader.Close();
                }
                else
                {
                    //E2
                    temp_in.Text += "1\n";
                    temp_in.Text += textBox22.Text + "\n";
                    cmd.CommandText = "select * from Shear_2";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temp_in.Text += reader["KW"].ToString() + ", " + reader["AMLW"].ToString() + ", " + reader["EAW"].ToString() + "\n";

                        temp_in.Text += reader["KHYSW_1"].ToString() + ", " + reader["EI_1"].ToString() + ", " + reader["PCP_1"].ToString() + ", " + reader["PYP_1"].ToString() + ", " + reader["UYP_1"].ToString() + ", " + reader["UUP_1"].ToString() + ", " + reader["EI3P_1"].ToString() + ", " + reader["PCN_1"].ToString() + ", " + reader["PYN_1"].ToString() + ", " + reader["UYN_1"].ToString() + ", " + reader["UUN_1"].ToString() + ", " + reader["EI3N_1"].ToString() + "\n";
                        if (Convert.ToDecimal(reader["KHYSW_1"]) >= 0)
                        {
                            temp_in.Text += reader["KHYSW_1"].ToString() + ", " + reader["EI_1"].ToString() + ", " + reader["PCP_1"].ToString() + ", " + reader["PYP_1"].ToString() + ", " + reader["UYP_1"].ToString() + ", " + reader["UUP_1"].ToString() + ", " + reader["EI3P_1"].ToString() + ", " + reader["PCN_1"].ToString() + ", " + reader["PYN_1"].ToString() + ", " + reader["UYN_1"].ToString() + ", " + reader["UUN_1"].ToString() + ", " + reader["EI3N_1"].ToString() + "\n";
                        }
                        temp_in.Text += reader["KHYSW_2"].ToString() + ", " + reader["GA_2"].ToString() + ", " + reader["PCP_2"].ToString() + ", " + reader["PYP_2"].ToString() + ", " + reader["UYP_2"].ToString() + ", " + reader["UUP_2"].ToString() + ", " + reader["GA3P_2"].ToString() + ", " + reader["PCN_2"].ToString() + ", " + reader["PYN_2"].ToString() + ", " + reader["UYN_2"].ToString() + ", " + reader["UUN_2"].ToString() + ", " + reader["GA3N_2"].ToString() + "\n";
                    } reader.Close();
                }

                //Do not forget K3
            }
            //Edge
            if (MEDG.Value != 0)
            {
                temp_in.Text += textBox19.Text + "\n";
                cmd.CommandText = "select * from Edge";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_in.Text += reader["KE"].ToString() + ", " + reader["IMC"].ToString() + ", " + reader["IMS"].ToString() + ", " + reader["AN"].ToString() + ", " + reader["DC"].ToString() + ", " + reader["BC"].ToString() + ", " + reader["AG"].ToString() + ", " + reader["AMLE"].ToString() + ", " + reader["ARME"].ToString() + "\n";
                } reader.Close();

            }


            //      TRN
            if (MTRN.Value != 0)
            {
                temp_in.Text += textBox20.Text + "\n";
                cmd.CommandText = "select * from Transverse";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_in.Text += reader["KT"].ToString() + ", " + reader["AKV"].ToString() + ", " + reader["ARV"].ToString() + ", " + reader["ALV"].ToString() + "\n";
                }
                reader.Close();

            }


            //SPR

            if (MSPR.Value != 0)
            {
                temp_in.Text += textBox21.Text + "\n";
                cmd.CommandText = "select * from Rotational";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["KS"].ToString() + ", " + reader["KHYSR"].ToString() + ", " + reader["EI"].ToString() + ", " + reader["PCP"].ToString() + ", " + reader["PYP"].ToString() + ", " + reader["UYP"].ToString() + ", " + reader["UUP"].ToString() + ", " + reader["EI3P"].ToString() + ", " + reader["PCN"].ToString() + ", " + reader["PYN"].ToString() + ", " + reader["UYN"].ToString() + ", " + reader["UUN"].ToString() + ", " + reader["EI3N"].ToString() + "\n";
                } reader.Close();
            }

            //Brace



            if (MBRV.Value != 0)
            {
                temp_in.Text += textBox23.Text + "\n";
                cmd.CommandText = "select * from Visco";
                if (ITMODEL.Checked)
                {
                    temp_in.Text += "0, ";
                }
                else
                    temp_in.Text += "1, ";
                if (ITDVCON.Checked)
                {
                    temp_in.Text += "0\n";
                }
                else
                    temp_in.Text += "1\n";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_in.Text += reader["ITDV"].ToString() + ", " + reader["CDV"].ToString() + ", " + reader["KDV"].ToString() + ", " + reader["ALPHADV"].ToString() + "\n";
                    if (!ITDVCON.Checked)
                    {
                        temp_in.Text += reader["KDVCH"].ToString() + ", " + reader["ANGDV"].ToString() + "\n";
                    }
                }
                reader.Close();

            }

            //Friction


            if (MBRF.Value != 0)
            {
                temp_in.Text += textBox24.Text + "\n";
                cmd.CommandText = "select * from Friction";
                if (ITDFCON.Checked)
                {
                    temp_in.Text += "0\n";
                }
                else
                    temp_in.Text += "1\n";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp_in.Text += reader["ITDF"].ToString() + ", " + reader["KDF"].ToString() + ", " + reader["FYDF"].ToString() + "\n";
                    if (!ITDFCON.Checked)
                    {
                        temp_in.Text += reader["KDFCH"].ToString() + ", " + reader["ANGDF"].ToString() + "\n";
                    }
                }
                reader.Close();

            }

            //DAMPER

            if (MBRH.Value != 0)
            {
                temp_in.Text += textBox25.Text + "\n";
                cmd.CommandText = "select * from Hysteretic_damper";
                if (ITDHCON.Checked)
                    temp_in.Text += "0\n";
                else
                    temp_in.Text += "1\n";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["ITDH"].ToString() + ", 1, " + reader["KDH"].ToString() + ", " + reader["FYDH"].ToString() + ", " + reader["RPSTDH"].ToString() + "\n";
                    if (!ITDHCON.Checked)
                    {
                        temp_in.Text += reader["KDHCH"].ToString() + ", " + reader["ANGDH"].ToString() + "\n";
                    }
                }
                reader.Close();

                if (ITDHCON.Checked)
                {

                    //cmd.CommandText = "select * from C_brace_sp";
                    //
                    //SQLiteDataReader reader = cmd.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    temp_in.Text += reader["ITDH"].ToString() + ", 2, " + reader["KDH"].ToString() + ", " + reader["FYDH"].ToString() + ", " + reader["RPSTDH"].ToString() + reader["POWER"].ToString() + ", " + reader["ETA"].ToString() + "\n";
                    //}
                    //reader.Close();
                }
                else
                {

                }


            }
            //INfill

            if (MIW.Value != 0)
            {
                temp_in.Text += textBox36.Text + "\n";

                if (ICCTYPE.Checked)
                {
                    temp_in.Text += textBox35.Text + "\n";
                    temp_in.Text += IPT.Value + ", ";
                    temp_in.Text += "0\n";
                    cmd.CommandText = "select * from Infill";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temp_in.Text += reader["IMT"].ToString() + ", " + reader["TMP"].ToString() + ", " + reader["VLMP"].ToString() + ", " + reader["VHMP"].ToString() + "\n";
                        temp_in.Text += reader["QMPC"].ToString() + ", " + reader["QMPB"].ToString() + ", " + reader["QMPJ"].ToString() + "\n";
                    }
                    reader.Close();
                }
                else
                {
                    temp_in.Text += textBox35.Text + "\n";
                    temp_in.Text += IPT.Value + ", ";
                    temp_in.Text += "1\n";
                    cmd.CommandText = "select * from Infill";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        temp_in.Text += reader["EAIW"].ToString() + ", " + reader["VYIW"].ToString() + ", " + "\n";
                    }
                    reader.Close();


                }

                //I3
                cmd.CommandText = "select * from Infill";

                SQLiteDataReader reader_1 = cmd.ExecuteReader();
                while (reader_1.Read())
                {
                    temp_in.Text += reader_1["AIW"].ToString() + ", " + reader_1["BTA"].ToString() + ", " + reader_1["GMA"].ToString() + ", " + reader_1["ETA"].ToString() + ", " + reader_1["ALPHIW"].ToString() + "\n";
                    temp_in.Text += reader_1["IS_1"].ToString() + ", " + reader_1["AS_1"].ToString() + ", " + reader_1["ZS"].ToString() + ", " + reader_1["ZBS"].ToString() + "\n";
                    temp_in.Text += reader_1["SK"].ToString() + ", " + reader_1["SP1"].ToString() + ", " + reader_1["SP2"].ToString() + ", " + reader_1["MU"].ToString() + "\n";
                }
                reader_1.Close();

            }





            if (NCOL.Value != 0)
            {
                temp_in.Text += textBox26.Text + "\n";
                cmd.CommandText = "select * from C_column";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["M"].ToString() + ", " + reader["ITC"].ToString() + ", " + reader["IC"].ToString() + ", " + reader["JC"].ToString() + ", " + reader["LBC"].ToString() + ", " + reader["LTC"].ToString() + "\n";
                }
                reader.Close();

            }


            if (NBEM.Value != 0)
            {
                temp_in.Text += textBox27.Text + "\n";
                cmd.CommandText = "select * from C_beam";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["M"].ToString() + ", " + reader["ITB"].ToString() + ", " + reader["LB"].ToString() + ", " + reader["IB"].ToString() + ", " + reader["JLB"].ToString() + ", " + reader["JRB"].ToString() + "\n";

                }
                reader.Close();

            }


            if (NWAL.Value != 0)
            {
                temp_in.Text += textBox28.Text + "\n";
                cmd.CommandText = "select * from C_shear";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    temp_in.Text += reader["M"].ToString() + ", " + reader["ITW"].ToString() + ", " + reader["IW"].ToString() + ", " + reader["JW"].ToString() + ", " + reader["LBW"].ToString() + ", " + reader["LTW"].ToString() + "\n";
                }
                reader.Close();

            }


            if (NEDG.Value != 0)
            {
                temp_in.Text += textBox31.Text + "\n";
                cmd.CommandText = "select * from C_edge";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["M"].ToString() + ", " + reader["ITE"].ToString() + ", " + reader["IE"].ToString() + ", " + reader["JE"].ToString() + ", " + reader["LBE"].ToString() + ", " + reader["LTE"].ToString() + "\n";

                }
                reader.Close();

            }


            if (NTRN.Value != 0)
            {
                temp_in.Text += textBox30.Text + "\n";
                cmd.CommandText = "select * from C_Transverse";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    temp_in.Text += reader["M"].ToString() + ", " + reader["ITT"].ToString() + ", " + reader["LT"].ToString() + ", " + reader["IWT"].ToString() + ", " + reader["JWT"].ToString() + ", " + reader["IFT"].ToString() + ", " + reader["JFT"].ToString() + "\n";
                } reader.Close();

            }


            if (NSPR.Value != 0)
            {
                temp_in.Text += textBox29.Text + "\n";
                cmd.CommandText = "select * from C_Spring";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["M"].ToString() + ", " + reader["ITRSP"].ToString() + ", " + reader["ISP"].ToString() + ", " + reader["JSP"].ToString() + ", " + reader["LSP"].ToString() + ", " + reader["KSPL"].ToString() + "\n";
                } reader.Close();

            }


            if (NMR.Value != 0)
            {
                temp_in.Text += textBox34.Text + "\n";
                cmd.CommandText = "select * from C_Moment";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["IDM"].ToString() + ", " + (Convert.ToInt16(reader["IHTY"]) + 1).ToString() + ", " + reader["INUM"].ToString() + ", " + (Convert.ToInt16(reader["IREG"]) + 1).ToString() + "\n";


                } reader.Close();

            }


            if (NBR.Value != 0)
            {
                temp_in.Text += textBox33.Text + "\n";
                cmd.CommandText = "select * from C_Brace";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    temp_in.Text += reader["M"].ToString() + ", " + reader["IF_1"].ToString() + ", " + (Convert.ToInt16(reader["ITBR"]) + 1).ToString() + ", " + reader["ITD"].ToString() + ", " + reader["LT"].ToString() + ", " + reader["LB"].ToString() + ", " + reader["JT"].ToString() + ", " + reader["JB"].ToString() + ", " + reader["AMLBR"].ToString() + "\n";


                } reader.Close();

            }


            if (NIW.Value != 0)
            {
                temp_in.Text += textBox32.Text + "\n";
                cmd.CommandText = "select * from C_Infill";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    temp_in.Text += reader["M"].ToString() + ", " + reader["IF_1"].ToString() + ", " + reader["ITIW"].ToString() + ", " + reader["LT"].ToString() + ", " + reader["LB"].ToString() + ", " + reader["JL"].ToString() + ", " + reader["JR"].ToString() + ", " + reader["JBMT"].ToString() + "\n";
                } reader.Close();

            }


            if (dataGridView12.Rows.Count > 0)
            {
                // int de = i;
                cmd.CommandText = "select * from " + i;
                SQLiteDataReader reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    //temp_in.Text += "\n";
                    temp_in.Text += reader1["temp_in"];
                }

                reader1.Close();
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {

            //int x = checkedListBox1.SelectedIndex;
            if (checkedListBox1.Items.Count > 0)
            {
                checkedListBox1.SelectedIndex = 0;
            }
            if (checkedListBox1.SelectedItem != null)
            {
                validateRanges();
                ReadfromDB(checkedListBox1.SelectedItem.ToString());
            }
        }

        private void NSO_Enter(object sender, EventArgs e)
        {

        }

        private void wizardPage9_Click(object sender, EventArgs e)
        {

        }





        private void button20_Click(object sender, EventArgs e)
        {
            C_shear temp_form = new C_shear(NWAL.Value);
            temp_form.ShowDialog();
        }

        private void MTRN_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "Transverse";
            string insertTemplate = "insert into Transverse (KT, AKV, ARV, ALV) values({0},0,0,0)";
            string deleteTemplate = "Delete from Transverse where KT={0}";
            ValueChangedHandler(tableName, (int)MTRN.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (MTRN.Value == 0)
            {
                button10.Enabled = false;
            }
            else
            {
                button10.Enabled = true;
            }
            return;



            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (MTRN.Value == 0)
            //    button10.Enabled = false;
            //else
            //{
            //    button10.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from Transverse";
            //        cmd.ExecuteNonQuery();
            //        for (int i = 1; i <= MTRN.Value; i++)
            //        {
            //            cmd.CommandText = "insert into Transverse (KT, AKV, ARV, ALV) values(" + i + ",0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MSPR_ValueChanged(object sender, EventArgs e)
        {

            string tableName = "Rotational";
            string insertTemplate = "insert into Rotational (KS, KHYSR, EI, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N) values({0},0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate = "Delete from Rotational where KS={0}";
            ValueChangedHandler(tableName, (int)MSPR.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (MSPR.Value == 0)
            {
                button11.Enabled = false;

            }
            else
            {
                button11.Enabled = true;
            }
            return;



            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (MSPR.Value == 0)
            //    button11.Enabled = false;
            //else
            //{
            //    button11.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from Rotational";
            //        cmd.ExecuteNonQuery();
            //        for (int i = 1; i <= MSPR.Value; i++)
            //        {
            //            cmd.CommandText = "insert into Rotational (KS, KHYSR, EI, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N) values(" + i + ",0,0,0,0,0,0,0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MEDG_ValueChanged(object sender, EventArgs e)
        {


            string tableName = "Edge";
            string insertTemplate = "insert into Edge (KE, IMC, IMS, AN, DC, BC, AG, AMLE, ARME) values({0},0,0,0,0,0,0,0,0)";
            string deleteTemplate = "Delete from Edge where KE={0}";
            ValueChangedHandler(tableName, (int)MEDG.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (MEDG.Value == 0)
            {
                button9.Enabled = false;

            }
            else
            {
                button9.Enabled = true;
            }
            return;


            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (MEDG.Value == 0)
            //    button9.Enabled = false;
            //else
            //{
            //    button9.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from Edge";
            //        cmd.ExecuteNonQuery();
            //        for (int i = 1; i <= MEDG.Value; i++)
            //        {
            //            cmd.CommandText = "insert into Edge (KE, IMC, IMS, AN, DC, BC, AG, AMLE, ARME) values(" + i + ",0,0,0,0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void MWAL_ValueChanged(object sender, EventArgs e)
        {

            string tableName1 = "Shear_1";
            string insertTemplate1 = "insert into Shear_1 (KW, IMC, KHYSW_1, KHYSW_2, KHYSW_3, AN, AMLW, NSECT) values({0},0,0,0,0,0,0,0)";
            string deleteTemplate1 = "Delete from Shear_1 where KW={0}";

            string tableName2 = "Shear_2";
            string insertTemplate2 = "insert into Shear_2 (KW, AMLW, EAW, KHYSW_1, EI_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1, KHYSW_2, GA_2, PCP_2, PYP_2, UYP_2, UUP_2, GA3P_2, PCN_2, PYN_2, UYN_2, UUN_2, GA3N_2) values({0},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate2 = "Delete from Shear_2 where KW={0}";

            ValueChangedHandler(tableName1, (int)MWAL.Value, insertTemplate1, deleteTemplate1);
            ValueChangedHandler(tableName2, (int)MWAL.Value, insertTemplate2, deleteTemplate2);
            validateRanges();

            if (MWAL.Value == 0)
            {
                groupBox10.Enabled = false;
            }
            else
                groupBox10.Enabled = true;



            if (loading)
                return;
            // cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); 
            // cmd.Connection = cn;
            // cn.Open();
            int oldValue = 0;
            int newValue = (int)MWAL.Value;
            //cmd.CommandText = "select name from sqlite_master where name like \"NSECT_%\"";
            // SQLiteDataReader rd = cmd.ExecuteReader();

            using (SQLiteConnection c = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"))
            {
                c.Open();
                using (SQLiteCommand cmd1 = new SQLiteCommand("select name from sqlite_master where name like \"NSECT_%\"", c))
                {
                    using (SQLiteDataReader rdr = cmd1.ExecuteReader())
                    {
                        while (rdr.Read())// finding the maximum value for NSECT_ table id 
                        {
                            string tt = rdr.GetString(0);
                            tt = tt.Replace("NSECT_", "");
                            if (Convert.ToInt32(tt) > oldValue)
                                oldValue = Convert.ToInt32(tt);
                        }
                        rdr.Close();
                    }
                }
            }
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
            cn.Open();
            cmd.Connection = cn;
            if (newValue < oldValue)
            {
                //cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                for (int i = newValue; i < oldValue; i++)
                {
                    cmd.CommandText = String.Format("drop table if exists NSECT_{0}", i + 1);
                    cmd.ExecuteNonQuery();
                }
                //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); 
                cn.Close();
            }
            else
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                for (int i = oldValue; i < newValue; i++)
                {
                    cmd.CommandText = @"
                                        CREATE TABLE [NSECT_" + (i + 1) + @"] (
                                            [KS] integer  NOT NULL PRIMARY KEY,
                                            [IMS] float  NULL,
                                            [DWAL] float  NULL,
                                            [BWAL] float  NULL,
                                            [PT] float  NULL,
                                            [PW] float  NULL
    
                                        )";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
            }

            return;




            //            validateRanges();
            //            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;


            //            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            //            if (MWAL.Value == 0)
            //                groupBox10.Enabled = false;
            //            else
            //            {
            //                groupBox10.Enabled = true;
            //                if (!Var.Dont_del)
            //                {
            //                    cmd.CommandText = "Delete from Shear_1";
            //                    cmd.ExecuteNonQuery();
            //                    cmd.CommandText = "Delete from Shear_2";
            //                    cmd.ExecuteNonQuery();
            //                    for (int i = 1; i <= MWAL.Value; i++)
            //                    {

            //                        cmd.CommandText = "insert into Shear_1 (KW, IMC, KHYSW_1, KHYSW_2, KHYSW_3, AN, AMLW, NSECT) values(" + i + ",0,0,0,0,0,0,0)";
            //                        cmd.ExecuteNonQuery();

            //                        cmd.CommandText = "insert into Shear_2 (KW, AMLW, EAW, KHYSW_1, EI_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1, KHYSW_2, GA_2, PCP_2, PYP_2, UYP_2, UUP_2, GA3P_2, PCN_2, PYN_2, UYN_2, UUN_2, GA3N_2) values(" + i + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            //                        cmd.ExecuteNonQuery();

            //                        cmd.CommandText = @"drop table if exists NSECT_" + i;
            //                        cmd.ExecuteNonQuery();
            //                        cmd.CommandText = @"
            //                                        CREATE TABLE [NSECT_" + i + @"] (
            //                                            [KS] integer  NOT NULL PRIMARY KEY,
            //                                            [IMS] float  NULL,
            //                                            [DWAL] float  NULL,
            //                                            [BWAL] float  NULL,
            //                                            [PT] float  NULL,
            //                                            [PW] float  NULL
            //    
            //                                        )";
            //                        cmd.ExecuteNonQuery();

            //                    }
            //                }
            //            } cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void MBRH_ValueChanged(object sender, EventArgs e)
        {
            string tableName1 = "Hysteretic_damper";
            string insertTemplate1 = "insert into Hysteretic_damper (ITDH, KDH, FYDH, RPSTDH,KDHCH, ANGDH) values({0},0,0,0,0,0)";
            string deleteTemplate1 = "Delete from Hysteretic_damper where ITDH={0}";

            string tableName2 = "C_brace_sp";
            string insertTemplate2 = "insert into C_brace_sp (ITDH, KDH, FYDH, RPSTDH, POWER, ETA) values({0},0,0,0,0,0)";
            string deleteTemplate2 = "Delete from C_brace_sp where ITDH={0}";

            ValueChangedHandler(tableName1, (int)MBRH.Value, insertTemplate1, deleteTemplate1);
            ValueChangedHandler(tableName2, (int)MBRH.Value, insertTemplate2, deleteTemplate2);
            validateRanges();

            if (MBRH.Value == 0)
            {
                groupBox8.Enabled = false;
            }
            else
                groupBox8.Enabled = true;

            return;



            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (MBRH.Value == 0)
            //    groupBox8.Enabled = false;
            //else
            //{
            //    groupBox8.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from Hysteretic_damper";
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = "Delete from C_brace_sp";
            //        cmd.ExecuteNonQuery();
            //        for (int i = 1; i <= MBRH.Value; i++)
            //        {
            //            cmd.CommandText = "insert into Hysteretic_damper (ITDH, KDH, FYDH, RPSTDH,KDHCH, ANGDH) values(" + i + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //        for (int i = 1; i <= MBRH.Value; i++)
            //        {
            //            cmd.CommandText = "insert into C_brace_sp (ITDH, KDH, FYDH, RPSTDH, POWER, ETA) values(" + i + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MIW_ValueChanged(object sender, EventArgs e)
        {
            validateRanges();
            if (MIW.Value != 0)
                groupBox48.Enabled = true;
            else
                groupBox48.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();



        }




        private void button29_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }







        private void dataGridView3_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells[0].Value = 0;
        }






        private void MBRV_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "Visco";
            string insertTemplate = "insert into Visco (ITDV, CDV, KDV, ALPHADV, KDVCH, ANGDV) values({0},0,0,0,0,0)";
            string deleteTemplate = "Delete from Visco where ITDV={0}";
            ValueChangedHandler(tableName, (int)MBRV.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (MBRV.Value == 0)
            {
                groupBox17.Enabled = false;

            }
            else
            {
                groupBox17.Enabled = true;
            }
            return;





            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (MBRV.Value == 0)
            //    groupBox17.Enabled = false;
            //else
            //{
            //    groupBox17.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from Visco";
            //        cmd.ExecuteNonQuery();
            //        for (int i = 1; i <= MBRV.Value; i++)
            //        {
            //            cmd.CommandText = "insert into Visco (ITDV, CDV, KDV, ALPHADV, KDVCH, ANGDV) values(" + i + ",0,0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MBRF_ValueChanged(object sender, EventArgs e)
        {
            string tableName = "Friction";
            string insertTemplate = "insert into Friction (ITDF, KDF, FYDF, KDFCH, ANGDF) values({0},0,0,0,0)";
            string deleteTemplate = "Delete from Friction where ITDF={0}";
            ValueChangedHandler(tableName, (int)MBRF.Value, insertTemplate, deleteTemplate);
            validateRanges();
            if (MBRF.Value == 0)
            {
                groupBox9.Enabled = false;

            }
            else
            {
                groupBox9.Enabled = true;
            }
            return;




            //validateRanges();
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (MBRF.Value == 0)
            //    groupBox9.Enabled = false;
            //else
            //{
            //    groupBox9.Enabled = true;
            //    if (!Var.Dont_del)
            //    {
            //        cmd.CommandText = "Delete from Friction";
            //        cmd.ExecuteNonQuery();
            //        for (int i = 1; i <= MBRF.Value; i++)
            //        {
            //            cmd.CommandText = "insert into Friction (ITDF, KDF, FYDF, KDFCH, ANGDF) values(" + i + ",0,0,0,0)";
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void button30_Click(object sender, EventArgs e)
        {
            Edit_Infill temp = new Edit_Infill(IPT.Value, ICCTYPE.Checked);
            temp.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
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
                    bool res = false;
                    if (sqlDataReader.Read())
                        res = true;
                    sqlDataReader.Close();
                    return res;
                }
            }
        }

        private void ICCTYPE_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void IPT_ValueChanged(object sender, EventArgs e)
        {

            string tableName = "Infill";
            string insertTemplate = "insert into Infill (IMT, TMP, VLMP, VHMP, QMPC, QMPB, QMPJ, EAIW, VYIW, AIW, BTA, GMA, ETA, ALPHIW, IS_1, AS_1, ZS, ZBS, SK, SP1, SP2, MU) values({0},0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            string deleteTemplate = "Delete from Infill where IMT={0}";
            ValueChangedHandler(tableName, (int)IPT.Value, insertTemplate, deleteTemplate);

            if (IPT.Value == 0)
            {
                button30.Enabled = false;

            }
            else
            {
                button30.Enabled = true;
            }
            return;


            //SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;

            //cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            //if (!Var.Dont_del)
            //{
            //    cmd.CommandText = "Delete from Infill";
            //    cmd.ExecuteNonQuery();
            //    for (int i = 1; i <= IPT.Value; i++)
            //    {
            //        cmd.CommandText = "insert into Infill (IMT, TMP, VLMP, VHMP, QMPC, QMPB, QMPJ, EAIW, VYIW, AIW, BTA, GMA, ETA, ALPHIW, IS_1, AS_1, ZS, ZBS, SK, SP1, SP2, MU) values(" + i + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
            //        cmd.ExecuteNonQuery();
            //    }

            //}
            //cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }



        private void ITDHCON_CheckedChanged(object sender, EventArgs e)
        {
            if (ITDHCON.Checked)
            {
                // button14.Enabled = false;
                // button32.Enabled = true;
            }
            else
            {
                //  button14.Enabled = true;
                // button32.Enabled = false;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            C_brace_sp temp_form = new C_brace_sp(MBRH.Value);
            temp_form.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About result = new About("Do you want to save changes to" + title.Text);
            DialogResult a = result.ShowDialog();
            if (a == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.OK)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.Cancel)
            {

            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New1 result = new New1("Do you want to save changes to " + title.Text);
            DialogResult a = result.ShowDialog();
            if (a == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.OK)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.No)
            {

                //     bs.MoveNext();

            }
            if (a == DialogResult.Cancel)
            {
                return;
            }

            OpenFileDialog a1 = new OpenFileDialog();
            a1.Filter = settings.preFileExt;
            if (a1.ShowDialog() == DialogResult.OK)
            {

                loading = true;
                Var.Load_file = a1.FileName;
                System.IO.File.Copy(Var.Load_file, Var.pp + "\\Database.db", true);
                //  cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                //////////////////////////////////////

                //
                checkedListBox1.Items.Clear();
                //




                //da.SelectCommand = new SQLiteCommand("Select * From G_info", cn);
                //ds.Clear();
                //da.Fill(ds, "G_info");

                //bs.DataSource = ds.Tables["G_info"];
                // bs.ResetBindings(true);

                Var.Dont_del = true;
                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open();
                SQLiteCommand cmd_load = new SQLiteCommand(cn);
                cmd_load.CommandText = "select * from G_info";
                SQLiteDataReader reader = cmd_load.ExecuteReader();
                reader.Read();
                ICCTYPE.YesNo = Convert.ToString(reader["ICCTYPE"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox4.Text = reader["textBox4"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();

                ////////
                //BSPRNT.Text = Convert.ToString(reader["BSPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DAMP.Text = Convert.ToString(reader["DAMP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DFPRNT.Text = Convert.ToString(reader["DFPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DRFLIM.Text = Convert.ToString(reader["DRFLIM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DRFLIM_1.Text = Convert.ToString(reader["DRFLIM_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DTCAL.Text = Convert.ToString(reader["DTCAL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DTCAL_1.Text = Convert.ToString(reader["DTCAL_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DTINP.Text = Convert.ToString(reader["DTINP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DTOUT.Text = Convert.ToString(reader["DTOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //DTPRNT.Text = Convert.ToString(reader["DTPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //EXPK.Text = Convert.ToString(reader["EXPK"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //GMAXH.Text = Convert.ToString(reader["GMAXH"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //GMAXV.Text = Convert.ToString(reader["GMAXV"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICCTYPE.YesNo = Convert.ToString(reader["ICCTYPE"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICDPRNT_1.YesNo = Convert.ToString(reader["ICDPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICDPRNT_2.YesNo = Convert.ToString(reader["ICDPRNT_2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICDPRNT_3.YesNo = Convert.ToString(reader["ICDPRNT_3"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICDPRNT_4.YesNo = Convert.ToString(reader["ICDPRNT_4"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICDPRNT_5.YesNo = Convert.ToString(reader["ICDPRNT_5"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICNTRL.SelectedIndex = Convert.ToInt16(reader["ICNTRL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();

                //ICPRNT_1.YesNo = Convert.ToString(reader["ICPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICPRNT_2.YesNo = Convert.ToString(reader["ICPRNT_2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICPRNT_3.YesNo = Convert.ToString(reader["ICPRNT_3"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICPRNT_4.YesNo = Convert.ToString(reader["ICPRNT_4"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ICPRNT_5.YesNo = Convert.ToString(reader["ICPRNT_5"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                /////////////
                IFLEX.YesNo = Convert.ToString(reader["IFLEX"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IFLEXDIST.YesNo = Convert.ToString(reader["IFLEXDIST"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();

                ////
                //IGMOT.SelectedIndex = Convert.ToInt16(reader["IGMOT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //IOCRL.Value = Convert.ToDecimal(reader["IOCRL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //IOPT.SelectedIndex = Convert.ToInt16(reader["IOPT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IPT.Value = Convert.ToDecimal(reader["IPT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ITDFCON.YesNo = Convert.ToString(reader["ITDFCON"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ITDHCON.YesNo = Convert.ToString(reader["ITDHCON"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ITDMP.SelectedIndex = Convert.ToInt16(reader["ITDMP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ITDVCON.YesNo = Convert.ToString(reader["ITDVCON"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                ITMODEL.YesNo = Convert.ToString(reader["ITMODEL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ITPRNT.SelectedIndex = Convert.ToInt16(reader["ITPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //ITYP.SelectedIndex = Convert.ToInt16(reader["ITYP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IU.YesNo = Convert.ToString(reader["IU"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IUBEM.YesNo = Convert.ToString(reader["IUBEM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IUCOL.YesNo = Convert.ToString(reader["IUCOL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IUSER.YesNo = Convert.ToString(reader["IUSER"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                IUWAL.YesNo = Convert.ToString(reader["IUWAL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //IWV.SelectedIndex = Convert.ToInt16(reader["IWV"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //JOPT.SelectedIndex = Convert.ToInt16(reader["JOPT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //JSTP.Value = Convert.ToDecimal(reader["JSTP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //KBOUT.Value = Convert.ToDecimal(reader["KBOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //KBROUT.Value = Convert.ToDecimal(reader["KBROUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //KCOUT.Value = Convert.ToDecimal(reader["KCOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //KIWOUT.Value = Convert.ToDecimal(reader["KIWOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //KSOUT.Value = Convert.ToDecimal(reader["KSOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //KWOUT.Value = Convert.ToDecimal(reader["KWOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MBEM.Value = Convert.ToDecimal(reader["MBEM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MBRF.Value = Convert.ToDecimal(reader["MBRF"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MBRH.Value = Convert.ToDecimal(reader["MBRH"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MBRV.Value = Convert.ToDecimal(reader["MBRV"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MCOL.Value = Convert.ToDecimal(reader["MCOL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MEDG.Value = Convert.ToDecimal(reader["MEDG"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MIW.Value = Convert.ToDecimal(reader["MIW"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MSPR.Value = Convert.ToDecimal(reader["MSPR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //MSTEPS.Value = Convert.ToDecimal(reader["MSTEPS"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //MSTEPS_1.Value = Convert.ToDecimal(reader["MSTEPS_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MTRN.Value = Convert.ToDecimal(reader["MTRN"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                MWAL.Value = Convert.ToDecimal(reader["MWAL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NBEM.Value = Convert.ToDecimal(reader["NBEM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NBR.Value = Convert.ToDecimal(reader["NBR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NCOL.Value = Convert.ToDecimal(reader["NCOL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NCON.Value = Convert.ToDecimal(reader["NCON"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NDATA.Value = Convert.ToDecimal(reader["NDATA"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NEDG.Value = Convert.ToDecimal(reader["NEDG"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NFR.Value = Convert.ToDecimal(reader["NFR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NHYS.Value = Convert.ToDecimal(reader["NHYS"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NIW.Value = Convert.ToDecimal(reader["NIW"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NLC.Value = Convert.ToDecimal(reader["NLC"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NLDED.Value = Convert.ToDecimal(reader["NLDED"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NLDED_1.Value = Convert.ToDecimal(reader["NLDED_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NLJ.Value = Convert.ToDecimal(reader["NLJ"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NLM.Value = Convert.ToDecimal(reader["NLM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NLU.Value = Convert.ToDecimal(reader["NLU"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NMOD.Value = Convert.ToDecimal(reader["NMOD"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NMR.Value = Convert.ToDecimal(reader["NMR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NMSR.Value = Convert.ToDecimal(reader["NMSR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NPDEL.YesNo = Convert.ToString(reader["NPDEL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NPRNT.Value = Convert.ToDecimal(reader["NPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NPRNT_1.SelectedIndex = Convert.ToInt16(reader["NPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NPTS.Value = Convert.ToDecimal(reader["NPTS"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NSO.Value = Convert.ToDecimal(reader["NSO"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //NSOUT.Value = Convert.ToDecimal(reader["NSOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NSPR.Value = Convert.ToDecimal(reader["NSPR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NSTL.Value = Convert.ToDecimal(reader["NSTL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NTRN.Value = Convert.ToDecimal(reader["NTRN"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                NWAL.Value = Convert.ToDecimal(reader["NWAL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //PMAX.Text = Convert.ToString(reader["PMAX"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //POWER1.Text = Convert.ToString(reader["POWER1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //POWER2.SelectedIndex = Convert.ToInt16(reader["POWER2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //TDUR.Text = Convert.ToString(reader["TDUR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //WHFILE.Text = reader["WHFILE"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //WVFILE.Text = reader["WVFILE"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox1.Text = reader["textBox1"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox10.Text = reader["textBox10"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox11.Text = reader["textBox11"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox12.Text = reader["textBox12"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox13.Text = reader["textBox13"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox14.Text = reader["textBox14"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox15.Text = reader["textBox15"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox16.Text = reader["textBox16"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox17.Text = reader["textBox17"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox18.Text = reader["textBox18"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox19.Text = reader["textBox19"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox2.Text = reader["textBox2"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox20.Text = reader["textBox20"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox21.Text = reader["textBox21"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox22.Text = reader["textBox22"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox23.Text = reader["textBox23"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox24.Text = reader["textBox24"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox25.Text = reader["textBox25"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox26.Text = reader["textBox26"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox27.Text = reader["textBox27"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox28.Text = reader["textBox28"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox29.Text = reader["textBox29"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox3.Text = reader["textBox3"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox30.Text = reader["textBox30"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox31.Text = reader["textBox31"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox32.Text = reader["textBox32"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox33.Text = reader["textBox33"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox34.Text = reader["textBox34"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox35.Text = reader["textBox35"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox36.Text = reader["textBox36"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox37.Text = reader["textBox37"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox38.Text = reader["textBox38"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox39.Text = reader["textBox39"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox4.Text = reader["textBox4"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox40.Text = reader["textBox40"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox41.Text = reader["textBox41"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox42.Text = reader["textBox42"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox43.Text = reader["textBox43"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox44.Text = reader["textBox44"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox45.Text = reader["textBox45"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox46.Text = reader["textBox46"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox47.Text = reader["textBox47"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox48.Text = reader["textBox48"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox49.Text = reader["textBox49"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox50.Text = reader["textBox50"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox51.Text = reader["textBox51"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox52.Text = reader["textBox52"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox53.Text = reader["textBox53"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox54.Text = reader["textBox54"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox55.Text = reader["textBox55"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox56.Text = reader["textBox56"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox57.Text = reader["textBox57"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox58.Text = reader["textBox58"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                //textBox59.Text = reader["textBox59"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox9.Text = reader["textBox9"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                title.Text = reader["title"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox5.Text = reader["textBox5"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox6.Text = reader["textBox6"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox7.Text = reader["textBox7"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                textBox8.Text = reader["textBox8"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
                Var.Dont_del = false;
                reader.Close();
                cn.Close();
                ///////////////////////////////



                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "select * from G_info";
                reader = cmd.ExecuteReader();
                reader.Read();
                while (dataGridView12.Rows.Count > 0)
                {

                    dataGridView12.Rows.RemoveAt(0);

                }
                String d_12 = reader["d_12"].ToString();
                Char[] d_text = d_12.ToCharArray();
                String temp = "";
                for (int i = 0; i < d_text.Length; i++)
                {

                    if (d_text[i] != ',')
                        temp += d_text[i].ToString();
                    else
                    {
                        dataGridView12.Rows.Add(temp);
                        checkedListBox1.Items.Add(temp, true);


                        temp = "";
                    }


                }
                if (temp != "")
                {
                    dataGridView12.Rows.Add(temp);
                    checkedListBox1.Items.Add(temp, true);

                }
                if (reader["IFLEX"].ToString() == "0")
                {
                    radioButton2.Checked = true;
                }
                if (reader["IFLEXDIST"].ToString() == "0")
                {
                    radioButton4.Checked = true;
                }
                if (reader["IUSER"].ToString() == "0")
                {
                    radioButton5.Checked = true;
                }
                if (reader["IU"].ToString() == "1")
                {
                    radioButton1.Checked = false;
                }
                ///// ADD the rest of radio :) Enjoyyy....

                if (reader["IUCOL"].ToString() == "0")
                {
                    radioButton7.Checked = true;
                }
                if (reader["IUBEM"].ToString() == "0")
                {
                    radioButton3.Checked = true;
                }
                if (reader["IUWAL"].ToString() == "0")
                {
                    radioButton8.Checked = true;
                }
                if (reader["ITMODEL"].ToString() == "0")
                {
                    radioButton9.Checked = true;
                }
                if (reader["ITDVCON"].ToString() == "0")
                {
                    radioButton11.Checked = true;
                }
                if (reader["ITDFCON"].ToString() == "0")
                {
                    radioButton12.Checked = true;
                }
                if (reader["ITDHCON"].ToString() == "0")
                {
                    radioButton10.Checked = true;
                }
                if (reader["ICCTYPE"].ToString() == "0")
                {
                    radioButton15.Checked = true;
                }
                //////////
                //if (reader["ICDPRNT_1"].ToString() == "0")
                //{
                //    radioButton13.Checked = true;
                //}
                //if (reader["ICDPRNT_2"].ToString() == "0")
                //{
                //    radioButton14.Checked = true;
                //}
                //if (reader["ICDPRNT_3"].ToString() == "0")
                //{
                //    radioButton16.Checked = true;
                //}
                //if (reader["ICDPRNT_4"].ToString() == "0")
                //{
                //    radioButton18.Checked = true;
                //}
                //if (reader["ICDPRNT_5"].ToString() == "0")
                //{
                //    radioButton20.Checked = true;
                //}

                //if (reader["ICPRNT_1"].ToString() == "0")
                //{
                //    radioButton6.Checked = true;
                //}
                //if (reader["ICPRNT_2"].ToString() == "0")
                //{
                //    radioButton17.Checked = true;
                //}
                //if (reader["ICPRNT_3"].ToString() == "0")
                //{
                //    radioButton21.Checked = true;
                //}
                //if (reader["ICPRNT_4"].ToString() == "0")
                //{
                //    radioButton23.Checked = true;
                //}
                //if (reader["ICPRNT_5"].ToString() == "0")
                //{
                //    radioButton25.Checked = true;
                //}
                //////////////
                reader.Close();
                cn.Close();
                //MessageBox.Show(title.Text);
                ///////////////////
                //////////////// For Tables ///////////

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open();
                cmd.Connection = cn;

                cmd.CommandText = "select * from data1";
                reader = cmd.ExecuteReader();
                int data1_i = 0;
                while (reader.Read())
                {

                    data1[0, data1_i].Value = reader["HIGT"];
                    data1_i++;
                }
                reader.Close();
                cn.Close();


                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "select * from data2";
                reader = cmd.ExecuteReader();
                int data2_i = 0;
                while (reader.Read())
                {

                    data2["NDUP", data2_i].Value = reader["NDUP"];
                    data2["NVLN", data2_i].Value = reader["NVLN"];
                    data2_i++;
                }
                reader.Close();
                cn.Close();

                do_temp();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView1";
                //reader = cmd.ExecuteReader();
                //int dataGridView1_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView1["NSTLD", dataGridView1_i].Value = reader["NSTLD"];
                //    dataGridView1["PX", dataGridView1_i].Value = reader["PX"];
                //    dataGridView1_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView2";
                //reader = cmd.ExecuteReader();

                //int dataGridView2_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView2[0, dataGridView2_i].Value = reader["NSTLD_1"];
                //    dataGridView2_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView6";
                //reader = cmd.ExecuteReader();
                //int dataGridView6_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView6[0, dataGridView6_i].Value = reader["Column1"];
                //    dataGridView6_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView7";
                //reader = cmd.ExecuteReader();
                //int dataGridView7_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView7[0, dataGridView7_i].Value = reader["Column1"];
                //    dataGridView7_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView8";
                //reader = cmd.ExecuteReader();
                //int dataGridView8_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView8[0, dataGridView8_i].Value = reader["Column1"];
                //    dataGridView8_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView9";
                //reader = cmd.ExecuteReader();
                //int dataGridView9_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView9[0, dataGridView9_i].Value = reader["Column1"];
                //    dataGridView9_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView10";
                //reader = cmd.ExecuteReader();
                //int dataGridView10_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView10[0, dataGridView10_i].Value = reader["Column1"];
                //    dataGridView10_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView11";
                //reader = cmd.ExecuteReader();
                //int dataGridView11_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView11[0, dataGridView11_i].Value = reader["Column1"];
                //    dataGridView11_i++;
                //}
                //reader.Close();
                //cn.Close();

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView4";
                //reader = cmd.ExecuteReader();
                //int dataGridView4_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView4[0, dataGridView4_i].Value = reader["UPRNT"];
                //    dataGridView4_i++;
                //}
                //reader.Close();
                //cn.Close();

                /////////////////

                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView5";
                //reader = cmd.ExecuteReader();
                //int dataGridView5_i = 0;
                //while (reader.Read())
                //{

                //    dataGridView5["ISO", dataGridView5_i].Value = reader["ISO"];
                //    dataGridView5["FNAMES", dataGridView5_i].Value = reader["FNAMES"];
                //    dataGridView5_i++;
                //}
                //reader.Close();
                //cn.Close();


                //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                //cn.Open();
                //cmd.CommandText = "select * from dataGridView3";
                //SQLiteDataAdapter db = new SQLiteDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //if(TableExists("dataGridView3",cn) == true)
                //    db.Fill(dt);
                //int size_c = dt.Columns.Count;




                //if (size_c != 0)
                //{
                //    reader = cmd.ExecuteReader();
                //    int dataGridView3_i = 0;
                //    while (reader.Read())
                //    {


                //        for (int i = 0; i < size_c; i++)
                //        {

                //            dataGridView3[i, dataGridView3_i].Value = reader["C" + i.ToString()];
                //        }
                //        dataGridView3_i++;


                //    }
                //}
                //reader.Close();
                //cn.Close();
                ///////////////////

                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open();
                int size1 = Convert.ToInt32(NFR.Value);
                int size2 = Convert.ToInt32(NSO.Value);
                for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
                {
                    int k = 0;
                    cmd.CommandText = "select * from temp" + rowIndex.ToString();
                    SQLiteDataAdapter db1 = new SQLiteDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    db1.Fill(dt1);
                    int size_c1 = dt1.Columns.Count;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        for (int columnIndex = 0; columnIndex < size_c1; ++columnIndex)
                        {
                            temp_level[rowIndex][columnIndex, k].Value = reader["C" + columnIndex.ToString()];


                        }

                        k++;

                    }
                    reader.Close();

                }

                cn.Close();
                /////////////

                loading = false;
                forceGUIUpdate();
                if (dataGridView12.Rows.Count > 0)
                {
                    int de = Convert.ToInt16((dataGridView12.Rows[0].Cells[0].Value).ToString().Remove(0, 9));
                    Analysis temp_form = new Analysis("Analysis_" + de.ToString(), true, radioButton1.Checked, Convert.ToDouble(data1["HIGT", 0].Value));
                    temp_form.Show();
                    temp_form.Close();
                }
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String d_12 = "";
            for (int i = 0; i < dataGridView12.Rows.Count; i++)
            {
                d_12 += dataGridView12[0, i].Value.ToString();
                if (i != dataGridView12.Rows.Count - 1)
                    d_12 += ",";
            }
            // cn.State == ConnectionState.Closed
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from G_info"; cmd.ExecuteNonQuery();
            //The new insert 
            cmd.CommandText = "insert into G_info (ID_n, ICCTYPE, IFLEX, IFLEXDIST, IPT, ITDFCON, ITDHCON, ITDVCON, ITMODEL, IU, IUBEM, IUCOL, IUSER, IUWAL, MBEM, MBRF, MBRH, MBRV, MCOL, MEDG, MIW, MSPR, MTRN, MWAL, NBEM, NBR, NCOL, NCON, NEDG, NFR, NHYS, NIW, NMR, NMSR, NPDEL, NSO, NSPR, NSTL, NTRN, NWAL, textBox1, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox2, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox3, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36, textBox9, title, textBox5, textBox6, textBox7, textBox8,textBox4,d_12) values(1," + ICCTYPE.YesNo + ", " + IFLEX.YesNo + ", " + IFLEXDIST.YesNo + ", " + IPT.Value + ", " + ITDFCON.YesNo + ", " + ITDHCON.YesNo + ", " + ITDVCON.YesNo + ", " + ITMODEL.YesNo + ", " + IU.YesNo + ", " + IUBEM.YesNo + ", " + IUCOL.YesNo + ", " + IUSER.YesNo + ", " + IUWAL.YesNo + ", " + MBEM.Value + ", " + MBRF.Value + ", " + MBRH.Value + ", " + MBRV.Value + ", " + MCOL.Value + ", " + MEDG.Value + ", " + MIW.Value + ", " + MSPR.Value + ", " + MTRN.Value + ", " + MWAL.Value + ", " + NBEM.Value + ", " + NBR.Value + ", " + NCOL.Value + ", " + NCON.Value + ", " + NEDG.Value + ", " + NFR.Value + ", " + NHYS.Value + ", " + NIW.Value + ", " + NMR.Value + ", " + NMSR.Value + ", " + NPDEL.YesNo + ", " + NSO.Value + ", " + NSPR.Value + ", " + NSTL.Value + ", " + NTRN.Value + ", " + NWAL.Value + ", '" + textBox1.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "', '" + textBox2.Text + "', '" + textBox20.Text + "', '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "', '" + textBox27.Text + "', '" + textBox28.Text + "', '" + textBox29.Text + "', '" + textBox3.Text + "', '" + textBox30.Text + "', '" + textBox31.Text + "', '" + textBox32.Text + "', '" + textBox33.Text + "', '" + textBox34.Text + "', '" + textBox35.Text + "', '" + textBox36.Text + "', '" + textBox9.Text + "', '" + title.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox4.Text + "', '" + d_12 + "'" + ")";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();



            cn.Open();

            //Table data1 saving

            cmd.CommandText = "Delete from data1";
            cmd.ExecuteNonQuery();
            for (int i = 0; i < data1.Rows.Count; i++)
            {

                cmd.CommandText = @"INSERT INTO data1 (ID_n,HIGT) VALUES (" + (i + 1).ToString() + ", " + data1.Rows[i].Cells["HIGT"].Value + ");";
                cmd.ExecuteNonQuery();
            }
            //data2
            cmd.CommandText = "Delete from data2";
            cmd.ExecuteNonQuery();
            for (int i = 0; i < data2.Rows.Count; i++)
            {

                cmd.CommandText = @"INSERT INTO data2 (ID_n, NDUP, NVLN) VALUES (" + (i + 1).ToString() + ", " + data2.Rows[i].Cells["NDUP"].Value + ", " + data2.Rows[i].Cells["NVLN"].Value + ");";
                cmd.ExecuteNonQuery();
            }

            ///////////////////

            ////dataGridView1
            //cmd.CommandText = "Delete from dataGridView1";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView1 (ID_n, NSTLD, PX) VALUES (" + (i + 1).ToString() + ", " + dataGridView1.Rows[i].Cells["NSTLD"].Value + ", " + dataGridView1.Rows[i].Cells["PX"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}

            ////dataGridView2
            //cmd.CommandText = "Delete from dataGridView2";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView2 (ID_n,NSTLD_1) VALUES (" + (i + 1).ToString() + ", " + dataGridView2.Rows[i].Cells["NSTLD_1"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}

            //cmd.CommandText = "Delete from dataGridView6";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView6.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView6 (ID_n,Column1) VALUES (" + (i + 1).ToString() + ", " + dataGridView6.Rows[i].Cells["Column1"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}

            //cmd.CommandText = "Delete from dataGridView7";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView7.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView7 (ID_n,Column1) VALUES (" + (i + 1).ToString() + ", " + dataGridView7.Rows[i].Cells["Column1"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}
            //cmd.CommandText = "Delete from dataGridView8";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView8.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView8 (ID_n,Column1) VALUES (" + (i + 1).ToString() + ", " + dataGridView8.Rows[i].Cells["Column1"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}
            //cmd.CommandText = "Delete from dataGridView9";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView9.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView9 (ID_n,Column1) VALUES (" + (i + 1).ToString() + ", " + dataGridView9.Rows[i].Cells["Column1"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}
            //cmd.CommandText = "Delete from dataGridView10";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView10.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView10 (ID_n,Column1) VALUES (" + (i + 1).ToString() + ", " + dataGridView10.Rows[i].Cells["Column1"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}
            //cmd.CommandText = "Delete from dataGridView11";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView11.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView11 (ID_n,Column1) VALUES (" + (i + 1).ToString() + ", " + dataGridView11.Rows[i].Cells["Column1"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}

            //cmd.CommandText = "Delete from dataGridView4";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView4.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView4 (ID_n,UPRNT) VALUES (" + (i + 1).ToString() + ", " + dataGridView4.Rows[i].Cells["UPRNT"].Value + ");";
            //    cmd.ExecuteNonQuery();
            //}

            ////////////

            //Done
            int size1 = Convert.ToInt32(NFR.Value);
            int size2 = Convert.ToInt32(NSO.Value);

            for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
            {
                cmd.CommandText = "DROP TABLE IF EXISTS temp" + rowIndex.ToString();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"create table [temp" + rowIndex.ToString() + "] (";

                for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                {

                    cmd.CommandText += "[C" + columnIndex + "] FLOAT  NULL";

                    if (columnIndex != temp_level[rowIndex].ColumnCount - 1)
                        cmd.CommandText += ", ";
                }
                cmd.CommandText += ")";
                cmd.ExecuteNonQuery();
            }


            String c_line = "";
            String v_line = "";
            for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
            {

                for (int k = 0; k < size2; k++)
                {
                    c_line = "";
                    v_line = "";
                    for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                    {
                        c_line += "C" + columnIndex;
                        if (columnIndex != temp_level[rowIndex].ColumnCount - 1)
                            c_line += ",";

                        v_line += temp_level[rowIndex][columnIndex, k].Value.ToString();
                        if (columnIndex != temp_level[rowIndex].ColumnCount - 1)
                            v_line += ", ";


                    }
                    cmd.CommandText = "insert into temp" + rowIndex.ToString() + " (" + c_line + ") values (" + v_line + ")";
                    cmd.ExecuteNonQuery();


                }


            }
            ///////////// Done from Nodels /////////

            //cmd.CommandText = "Delete from dataGridView5";
            //cmd.ExecuteNonQuery();
            //for (int i = 0; i < dataGridView5.Rows.Count; i++)
            //{

            //    cmd.CommandText = @"INSERT INTO dataGridView5 (ID_n,ISO, FNAMES) VALUES (" + (i + 1).ToString() + ", " + dataGridView5.Rows[i].Cells["ISO"].Value + ", '"+ dataGridView5.Rows[i].Cells["FNAMES"].Value + "');";
            //    cmd.ExecuteNonQuery();
            //}

            //String c_c = "";
            //String i_c = "";
            //for (int i = 0; i < dataGridView3.Columns.Count; i++)
            //{
            //    c_c += "C" + i.ToString();
            //    i_c += "C" + i.ToString() + " float  NULL";
            //    if (i != dataGridView3.Columns.Count - 1)
            //    {
            //        c_c += ", ";
            //        i_c += ", ";
            //    }
            //}
            //cmd.CommandText = "DROP TABLE IF EXISTS dataGridView3";
            //cmd.ExecuteNonQuery();
            //if (i_c != "")
            //{
            //    cmd.CommandText = "Create table [dataGridView3] (" + i_c + ")";
            //    cmd.ExecuteNonQuery();
            //}

            //String c_r = "";
            //for (int i = 0; i < dataGridView3.Rows.Count; i++)
            //{

            //    c_r = "";
            //    for (int j = 0; j < dataGridView3.Columns.Count; j++)
            //    {
            //        c_r += dataGridView3[j, i].Value.ToString();
            //        if (j != dataGridView3.Columns.Count - 1)
            //            c_r += ", ";
            //    }
            //    cmd.CommandText = "insert into dataGridView3 (" + c_c + ") Values (" + c_r + ")";
            //    cmd.ExecuteNonQuery();

            //}


            cn.Close();




            SaveFileDialog a = new SaveFileDialog();
            a.FileName = title.Text;
            a.Filter = settings.preFileExt;
            if (a.ShowDialog() == DialogResult.OK)
            {
                string path = a.FileName;
                System.IO.File.Copy(Var.pp + "\\Database.db", path, true);

            }

            Var.Load_file = a.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String d_12 = "";
            for (int i = 0; i < dataGridView12.Rows.Count; i++)
            {
                d_12 += dataGridView12[0, i].Value.ToString();
                if (i != dataGridView12.Rows.Count - 1)
                    d_12 += ",";
            }
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from G_info"; cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into G_info (ID_n, ICCTYPE, IFLEX, IFLEXDIST, IPT, ITDFCON, ITDHCON, ITDVCON, ITMODEL, IU, IUBEM, IUCOL, IUSER, IUWAL, MBEM, MBRF, MBRH, MBRV, MCOL, MEDG, MIW, MSPR, MTRN, MWAL, NBEM, NBR, NCOL, NCON, NEDG, NFR, NHYS, NIW, NMR, NMSR, NPDEL, NSO, NSPR, NSTL, NTRN, NWAL, textBox1, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox2, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox3, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36, textBox9, title, textBox5, textBox6, textBox7, textBox8,textBox4,d_12) values(1," + ICCTYPE.YesNo + ", " + IFLEX.YesNo + ", " + IFLEXDIST.YesNo + ", " + IPT.Value + ", " + ITDFCON.YesNo + ", " + ITDHCON.YesNo + ", " + ITDVCON.YesNo + ", " + ITMODEL.YesNo + ", " + IU.YesNo + ", " + IUBEM.YesNo + ", " + IUCOL.YesNo + ", " + IUSER.YesNo + ", " + IUWAL.YesNo + ", " + MBEM.Value + ", " + MBRF.Value + ", " + MBRH.Value + ", " + MBRV.Value + ", " + MCOL.Value + ", " + MEDG.Value + ", " + MIW.Value + ", " + MSPR.Value + ", " + MTRN.Value + ", " + MWAL.Value + ", " + NBEM.Value + ", " + NBR.Value + ", " + NCOL.Value + ", " + NCON.Value + ", " + NEDG.Value + ", " + NFR.Value + ", " + NHYS.Value + ", " + NIW.Value + ", " + NMR.Value + ", " + NMSR.Value + ", " + NPDEL.YesNo + ", " + NSO.Value + ", " + NSPR.Value + ", " + NSTL.Value + ", " + NTRN.Value + ", " + NWAL.Value + ", '" + textBox1.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox17.Text + "', '" + textBox18.Text + "', '" + textBox19.Text + "', '" + textBox2.Text + "', '" + textBox20.Text + "', '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "', '" + textBox27.Text + "', '" + textBox28.Text + "', '" + textBox29.Text + "', '" + textBox3.Text + "', '" + textBox30.Text + "', '" + textBox31.Text + "', '" + textBox32.Text + "', '" + textBox33.Text + "', '" + textBox34.Text + "', '" + textBox35.Text + "', '" + textBox36.Text + "', '" + textBox9.Text + "', '" + title.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox4.Text + "', '" + d_12 + "'" + ")";

            cmd.ExecuteNonQuery();
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();



            //Table data1 saving
            cn.Open();
            cmd.CommandText = "Delete from data1";
            cmd.ExecuteNonQuery();
            for (int i = 0; i < data1.Rows.Count; i++)
            {

                cmd.CommandText = @"INSERT INTO data1 (ID_n,HIGT) VALUES (" + (i + 1).ToString() + ", " + data1.Rows[i].Cells["HIGT"].Value + ");";
                cmd.ExecuteNonQuery();
            }
            //data2
            cmd.CommandText = "Delete from data2";
            cmd.ExecuteNonQuery();
            for (int i = 0; i < data2.Rows.Count; i++)
            {

                cmd.CommandText = @"INSERT INTO data2 (ID_n, NDUP, NVLN) VALUES (" + (i + 1).ToString() + ", " + data2.Rows[i].Cells["NDUP"].Value + ", " + data2.Rows[i].Cells["NVLN"].Value + ");";
                cmd.ExecuteNonQuery();
            }



            //Done
            int size1 = Convert.ToInt32(NFR.Value);
            int size2 = Convert.ToInt32(NSO.Value);

            for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
            {
                cmd.CommandText = "DROP TABLE IF EXISTS temp" + rowIndex.ToString();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"create table [temp" + rowIndex.ToString() + "] (";

                for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                {

                    cmd.CommandText += "[C" + columnIndex + "] FLOAT  NULL";

                    if (columnIndex != temp_level[rowIndex].ColumnCount - 1)
                        cmd.CommandText += ", ";
                }
                cmd.CommandText += ")";
                if (temp_level[rowIndex].ColumnCount != 0)
                    cmd.ExecuteNonQuery();
            }


            String c_line = "";
            String v_line = "";
            for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
            {

                for (int k = 0; k < size2; k++)
                {
                    c_line = "";
                    v_line = "";
                    for (int columnIndex = 0; columnIndex < temp_level[rowIndex].ColumnCount; ++columnIndex)
                    {
                        c_line += "C" + columnIndex;
                        if (columnIndex != temp_level[rowIndex].ColumnCount - 1)
                            c_line += ",";

                        v_line += temp_level[rowIndex][columnIndex, k].Value.ToString();
                        if (columnIndex != temp_level[rowIndex].ColumnCount - 1)
                            v_line += ", ";


                    }
                    cmd.CommandText = "insert into temp" + rowIndex.ToString() + " (" + c_line + ") values (" + v_line + ")";
                    if (c_line != "" || v_line != "")
                        cmd.ExecuteNonQuery();


                }


            }


            cn.Close();



            if (Var.Load_file == null)
            {
                SaveFileDialog a = new SaveFileDialog();
                a.FileName = title.Text;
                a.Filter = settings.preFileExt;
                if (a.ShowDialog() == DialogResult.OK)
                {
                    string path = a.FileName;
                    System.IO.File.Copy(Var.pp + "\\Database.db", path, true);

                }

                Var.Load_file = a.FileName;
            }
            else
            {

                System.IO.File.Copy(Var.pp + "\\Database.db", Var.Load_file, true);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void wizardPage13_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (dataGridView12.Rows.Count > 0)
            {
                MessageBox.Show("This version is restricted to only one analysis per project");
                return;
            }
            if (NSO.Value == 0)
            {
                MessageBox.Show("Number of Stories should be more than 0");
                return;
            }

            int num_ana = dataGridView12.Rows.Count + 1;
            if (num_ana != 1)
                num_ana = Convert.ToInt16((dataGridView12[0, (num_ana - 2)].Value).ToString().Remove(0, 9)) + 1;
            dataGridView12.Rows.Add("Analysis_" + num_ana.ToString());


            Analysis temp_form = new Analysis("Analysis_" + num_ana.ToString(), false, radioButton1.Checked, Convert.ToDouble(data1["HIGT", 0].Value));
            checkedListBox1.Items.Add("Analysis_" + num_ana.ToString(), true);
            temp_form.ShowDialog();
        }

        private void wizardPage16_Click(object sender, EventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (dataGridView12.Rows.Count != 0)
            {
                int de = Convert.ToInt16((dataGridView12.CurrentRow.Cells[0].Value).ToString().Remove(0, 9));
                Analysis temp_form = new Analysis("Analysis_" + de.ToString(), true, radioButton1.Checked, Convert.ToDouble(data1["HIGT", 0].Value));
                temp_form.ShowDialog();
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (dataGridView12.CurrentCell.RowIndex < 0)
                return;

            DialogResult t = MessageBox.Show("Are you sure that you want to delete " + dataGridView12.CurrentCell.Value.ToString() + " ?", "Delete", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                if (dataGridView12.Rows.Count != 0)
                {
                    int de = dataGridView12.CurrentRow.Index;
                    dataGridView12.Rows.RemoveAt(de);

                    checkedListBox1.Items.RemoveAt(de);
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                    cmd.CommandText = "drop table if exists Analysis_" + de.ToString();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "L_NLC";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "L_NLJ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "L_NLM";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "L_NLU";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView1";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView2";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView6";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView7";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView8";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView9";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView10";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView11";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView4";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView5";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DROP TABLE IF EXISTS Analysis_" + de.ToString() + "dataGridView3";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=11=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();

        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            New1 result = new New1("Do you want to save changes to " + title.Text);
            DialogResult a = result.ShowDialog();
            if (a == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.OK)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.No)
            {

                //     bs.MoveNext();

            }
            if (a == DialogResult.Cancel)
            {
                return;

            }
            Var.Dont_del = true;
            String fi = Var.pp + "\\orginal.db";
            System.IO.File.Copy(fi, Var.pp + "\\Database.db", true);


            //
            checkedListBox1.Items.Clear();
            //

            while (dataGridView12.Rows.Count > 0)
            {

                dataGridView12.Rows.RemoveAt(0);

            }
            temp_in.Text = "";

            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();
            SQLiteCommand cmd_load = new SQLiteCommand(cn);
            cmd_load.CommandText = "select * from G_info";
            SQLiteDataReader reader = cmd_load.ExecuteReader();
            reader.Read();
            ICCTYPE.YesNo = Convert.ToString(reader["ICCTYPE"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox4.Text = reader["textBox4"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();

            ////////
            //BSPRNT.Text = Convert.ToString(reader["BSPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DAMP.Text = Convert.ToString(reader["DAMP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DFPRNT.Text = Convert.ToString(reader["DFPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DRFLIM.Text = Convert.ToString(reader["DRFLIM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DRFLIM_1.Text = Convert.ToString(reader["DRFLIM_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DTCAL.Text = Convert.ToString(reader["DTCAL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DTCAL_1.Text = Convert.ToString(reader["DTCAL_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DTINP.Text = Convert.ToString(reader["DTINP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DTOUT.Text = Convert.ToString(reader["DTOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //DTPRNT.Text = Convert.ToString(reader["DTPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //EXPK.Text = Convert.ToString(reader["EXPK"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //GMAXH.Text = Convert.ToString(reader["GMAXH"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //GMAXV.Text = Convert.ToString(reader["GMAXV"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICCTYPE.YesNo = Convert.ToString(reader["ICCTYPE"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICDPRNT_1.YesNo = Convert.ToString(reader["ICDPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICDPRNT_2.YesNo = Convert.ToString(reader["ICDPRNT_2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICDPRNT_3.YesNo = Convert.ToString(reader["ICDPRNT_3"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICDPRNT_4.YesNo = Convert.ToString(reader["ICDPRNT_4"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICDPRNT_5.YesNo = Convert.ToString(reader["ICDPRNT_5"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICNTRL.SelectedIndex = Convert.ToInt16(reader["ICNTRL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();

            //ICPRNT_1.YesNo = Convert.ToString(reader["ICPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICPRNT_2.YesNo = Convert.ToString(reader["ICPRNT_2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICPRNT_3.YesNo = Convert.ToString(reader["ICPRNT_3"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICPRNT_4.YesNo = Convert.ToString(reader["ICPRNT_4"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ICPRNT_5.YesNo = Convert.ToString(reader["ICPRNT_5"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            /////////////
            IFLEX.YesNo = Convert.ToString(reader["IFLEX"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            IFLEXDIST.YesNo = Convert.ToString(reader["IFLEXDIST"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();

            ////
            //IGMOT.SelectedIndex = Convert.ToInt16(reader["IGMOT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //IOCRL.Value = Convert.ToDecimal(reader["IOCRL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //IOPT.SelectedIndex = Convert.ToInt16(reader["IOPT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            decimal IPT_t = Convert.ToDecimal(reader["IPT"]); reader.Close(); IPT.Value = IPT_t; reader = cmd_load.ExecuteReader(); reader.Read();
            ITDFCON.YesNo = Convert.ToString(reader["ITDFCON"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            ITDHCON.YesNo = Convert.ToString(reader["ITDHCON"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ITDMP.SelectedIndex = Convert.ToInt16(reader["ITDMP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            ITDVCON.YesNo = Convert.ToString(reader["ITDVCON"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            ITMODEL.YesNo = Convert.ToString(reader["ITMODEL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ITPRNT.SelectedIndex = Convert.ToInt16(reader["ITPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //ITYP.SelectedIndex = Convert.ToInt16(reader["ITYP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            IU.YesNo = Convert.ToString(reader["IU"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            IUBEM.YesNo = Convert.ToString(reader["IUBEM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            IUCOL.YesNo = Convert.ToString(reader["IUCOL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            IUSER.YesNo = Convert.ToString(reader["IUSER"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            IUWAL.YesNo = Convert.ToString(reader["IUWAL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //IWV.SelectedIndex = Convert.ToInt16(reader["IWV"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //JOPT.SelectedIndex = Convert.ToInt16(reader["JOPT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //JSTP.Value = Convert.ToDecimal(reader["JSTP"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //KBOUT.Value = Convert.ToDecimal(reader["KBOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //KBROUT.Value = Convert.ToDecimal(reader["KBROUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //KCOUT.Value = Convert.ToDecimal(reader["KCOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //KIWOUT.Value = Convert.ToDecimal(reader["KIWOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //KSOUT.Value = Convert.ToDecimal(reader["KSOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //KWOUT.Value = Convert.ToDecimal(reader["KWOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MBEM_t = Convert.ToDecimal(reader["MBEM"]); reader.Close(); MBEM.Value = MBEM_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MBRF_t = Convert.ToDecimal(reader["MBRF"]); reader.Close(); MBRF.Value = MBRF_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MBRH_t = Convert.ToDecimal(reader["MBRH"]); reader.Close(); MBRH.Value = MBRH_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MBRV_t = Convert.ToDecimal(reader["MBRV"]); reader.Close(); MBRV.Value = MBRV_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MCOL_t = Convert.ToDecimal(reader["MCOL"]); reader.Close(); MCOL.Value = MCOL_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MEDG_t = Convert.ToDecimal(reader["MEDG"]); reader.Close(); MEDG.Value = MEDG_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MIW_t = Convert.ToDecimal(reader["MIW"]); reader.Close(); MIW.Value = MIW_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MSPR_t = Convert.ToDecimal(reader["MSPR"]); reader.Close(); MSPR.Value = MSPR_t; reader = cmd_load.ExecuteReader(); reader.Read();
            //MSTEPS.Value = Convert.ToDecimal(reader["MSTEPS"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //MSTEPS_1.Value = Convert.ToDecimal(reader["MSTEPS_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MTRN_t = Convert.ToDecimal(reader["MTRN"]); reader.Close(); MTRN.Value = MTRN_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal MWAL_t = Convert.ToDecimal(reader["MWAL"]); reader.Close(); MWAL.Value = MWAL_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NBEM_t = Convert.ToDecimal(reader["NBEM"]); reader.Close(); NBEM.Value = NBEM_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NBR_t = Convert.ToDecimal(reader["NBR"]); reader.Close(); NBR.Value = NBR_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NCOL_t = Convert.ToDecimal(reader["NCOL"]); reader.Close(); NCOL.Value = NCOL_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NCON_t = Convert.ToDecimal(reader["NCON"]); reader.Close(); NCON.Value = NCON_t; reader = cmd_load.ExecuteReader(); reader.Read();
            //NDATA.Value = Convert.ToDecimal(reader["NDATA"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NEDG_t = Convert.ToDecimal(reader["NEDG"]); reader.Close(); NEDG.Value = NEDG_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NFR_t = Convert.ToDecimal(reader["NFR"]); reader.Close(); NFR.Value = 1; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NHYS_t = Convert.ToDecimal(reader["NHYS"]); reader.Close(); NHYS.Value = NHYS_t; reader = cmd_load.ExecuteReader(); reader.Read();
            NIW.Value = Convert.ToDecimal(reader["NIW"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NLC.Value = Convert.ToDecimal(reader["NLC"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NLDED.Value = Convert.ToDecimal(reader["NLDED"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NLDED_1.Value = Convert.ToDecimal(reader["NLDED_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NLJ.Value = Convert.ToDecimal(reader["NLJ"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NLM.Value = Convert.ToDecimal(reader["NLM"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NLU.Value = Convert.ToDecimal(reader["NLU"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NMOD.Value = Convert.ToDecimal(reader["NMOD"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NMR_t = Convert.ToDecimal(reader["NMR"]); reader.Close(); NMR.Value = NMR_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NMSR_t = Convert.ToDecimal(reader["NMSR"]); reader.Close(); NMSR.Value = NMSR_t; reader = cmd_load.ExecuteReader(); reader.Read();
            NPDEL.YesNo = Convert.ToString(reader["NPDEL"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NPRNT.Value = Convert.ToDecimal(reader["NPRNT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NPRNT_1.SelectedIndex = Convert.ToInt16(reader["NPRNT_1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NPTS.Value = Convert.ToDecimal(reader["NPTS"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            NSO.Value = Convert.ToDecimal(reader["NSO"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //NSOUT.Value = Convert.ToDecimal(reader["NSOUT"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NSPR_t = Convert.ToDecimal(reader["NSPR"]); reader.Close(); NSPR.Value = NSPR_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NSTL_t = Convert.ToDecimal(reader["NSTL"]); reader.Close(); NSTL.Value = NSTL_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NTRN_t = Convert.ToDecimal(reader["NTRN"]); reader.Close(); NTRN.Value = NTRN_t; reader = cmd_load.ExecuteReader(); reader.Read();
            decimal NWAL_t = Convert.ToDecimal(reader["NWAL"]); reader.Close(); NWAL.Value = NWAL_t; reader = cmd_load.ExecuteReader(); reader.Read();
            //PMAX.Text = Convert.ToString(reader["PMAX"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //POWER1.Text = Convert.ToString(reader["POWER1"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //POWER2.SelectedIndex = Convert.ToInt16(reader["POWER2"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //TDUR.Text = Convert.ToString(reader["TDUR"]); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //WHFILE.Text = reader["WHFILE"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //WVFILE.Text = reader["WVFILE"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox1.Text = reader["textBox1"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox10.Text = reader["textBox10"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox11.Text = reader["textBox11"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox12.Text = reader["textBox12"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox13.Text = reader["textBox13"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox14.Text = reader["textBox14"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox15.Text = reader["textBox15"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox16.Text = reader["textBox16"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox17.Text = reader["textBox17"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox18.Text = reader["textBox18"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox19.Text = reader["textBox19"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox2.Text = reader["textBox2"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox20.Text = reader["textBox20"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox21.Text = reader["textBox21"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox22.Text = reader["textBox22"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox23.Text = reader["textBox23"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox24.Text = reader["textBox24"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox25.Text = reader["textBox25"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox26.Text = reader["textBox26"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox27.Text = reader["textBox27"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox28.Text = reader["textBox28"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox29.Text = reader["textBox29"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox3.Text = reader["textBox3"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox30.Text = reader["textBox30"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox31.Text = reader["textBox31"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox32.Text = reader["textBox32"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox33.Text = reader["textBox33"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox34.Text = reader["textBox34"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox35.Text = reader["textBox35"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox36.Text = reader["textBox36"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox37.Text = reader["textBox37"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox38.Text = reader["textBox38"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox39.Text = reader["textBox39"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox4.Text = reader["textBox4"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox40.Text = reader["textBox40"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox41.Text = reader["textBox41"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox42.Text = reader["textBox42"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox43.Text = reader["textBox43"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox44.Text = reader["textBox44"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox45.Text = reader["textBox45"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox46.Text = reader["textBox46"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox47.Text = reader["textBox47"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox48.Text = reader["textBox48"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox49.Text = reader["textBox49"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox50.Text = reader["textBox50"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox51.Text = reader["textBox51"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox52.Text = reader["textBox52"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox53.Text = reader["textBox53"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox54.Text = reader["textBox54"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox55.Text = reader["textBox55"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox56.Text = reader["textBox56"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox57.Text = reader["textBox57"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox58.Text = reader["textBox58"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            //textBox59.Text = reader["textBox59"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox9.Text = reader["textBox9"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            title.Text = reader["title"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox5.Text = reader["textBox5"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox6.Text = reader["textBox6"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox7.Text = reader["textBox7"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            textBox8.Text = reader["textBox8"].ToString(); reader.Close(); reader = cmd_load.ExecuteReader(); reader.Read();
            Var.Dont_del = false;
            reader.Close();
            cn.Close();
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from G_info";
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader["IFLEX"].ToString() == "0")
            {
                radioButton2.Checked = true;
            }
            if (reader["IFLEXDIST"].ToString() == "0")
            {
                radioButton4.Checked = true;
            }
            if (reader["IUSER"].ToString() == "0")
            {
                radioButton5.Checked = true;
            }
            if (reader["IU"].ToString() == "1")
            {
                radioButton1.Checked = false;
            }
            ///// ADD the rest of radio :) Enjoyyy....

            if (reader["IUCOL"].ToString() == "0")
            {
                radioButton7.Checked = true;
            }
            if (reader["IUBEM"].ToString() == "0")
            {
                radioButton3.Checked = true;
            }
            if (reader["IUWAL"].ToString() == "0")
            {
                radioButton8.Checked = true;
            }
            if (reader["ITMODEL"].ToString() == "0")
            {
                radioButton9.Checked = true;
            }
            if (reader["ITDVCON"].ToString() == "0")
            {
                radioButton11.Checked = true;
            }
            if (reader["ITDFCON"].ToString() == "0")
            {
                radioButton12.Checked = true;
            }
            if (reader["ITDHCON"].ToString() == "0")
            {
                radioButton10.Checked = true;
            }
            if (reader["ICCTYPE"].ToString() == "0")
            {
                radioButton15.Checked = true;
            }
            reader.Close();
            cn.Close();

            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from data1";
            reader = cmd.ExecuteReader();
            int data1_i = 0;
            while (reader.Read())
            {

                data1[0, data1_i].Value = reader["HIGT"];
                data1_i++;
            }
            reader.Close();
            cn.Close();


            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select * from data2";
            reader = cmd.ExecuteReader();
            int data2_i = 0;
            while (reader.Read())
            {

                data2["NDUP", data2_i].Value = reader["NDUP"];
                data2["NVLN", data2_i].Value = reader["NVLN"];
                data2_i++;
            }
            reader.Close();
            cn.Close();

            do_temp();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView1";
            //reader = cmd.ExecuteReader();
            //int dataGridView1_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView1["NSTLD", dataGridView1_i].Value = reader["NSTLD"];
            //    dataGridView1["PX", dataGridView1_i].Value = reader["PX"];
            //    dataGridView1_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView2";
            //reader = cmd.ExecuteReader();

            //int dataGridView2_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView2[0, dataGridView2_i].Value = reader["NSTLD_1"];
            //    dataGridView2_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView6";
            //reader = cmd.ExecuteReader();
            //int dataGridView6_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView6[0, dataGridView6_i].Value = reader["Column1"];
            //    dataGridView6_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView7";
            //reader = cmd.ExecuteReader();
            //int dataGridView7_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView7[0, dataGridView7_i].Value = reader["Column1"];
            //    dataGridView7_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView8";
            //reader = cmd.ExecuteReader();
            //int dataGridView8_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView8[0, dataGridView8_i].Value = reader["Column1"];
            //    dataGridView8_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView9";
            //reader = cmd.ExecuteReader();
            //int dataGridView9_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView9[0, dataGridView9_i].Value = reader["Column1"];
            //    dataGridView9_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView10";
            //reader = cmd.ExecuteReader();
            //int dataGridView10_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView10[0, dataGridView10_i].Value = reader["Column1"];
            //    dataGridView10_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView11";
            //reader = cmd.ExecuteReader();
            //int dataGridView11_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView11[0, dataGridView11_i].Value = reader["Column1"];
            //    dataGridView11_i++;
            //}
            //reader.Close();
            //cn.Close();

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView4";
            //reader = cmd.ExecuteReader();
            //int dataGridView4_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView4[0, dataGridView4_i].Value = reader["UPRNT"];
            //    dataGridView4_i++;
            //}
            //reader.Close();
            //cn.Close();

            /////////////////

            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView5";
            //reader = cmd.ExecuteReader();
            //int dataGridView5_i = 0;
            //while (reader.Read())
            //{

            //    dataGridView5["ISO", dataGridView5_i].Value = reader["ISO"];
            //    dataGridView5["FNAMES", dataGridView5_i].Value = reader["FNAMES"];
            //    dataGridView5_i++;
            //}
            //reader.Close();
            //cn.Close();


            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //cmd.CommandText = "select * from dataGridView3";
            //SQLiteDataAdapter db = new SQLiteDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //if(TableExists("dataGridView3",cn) == true)
            //    db.Fill(dt);
            //int size_c = dt.Columns.Count;




            //if (size_c != 0)
            //{
            //    reader = cmd.ExecuteReader();
            //    int dataGridView3_i = 0;
            //    while (reader.Read())
            //    {


            //        for (int i = 0; i < size_c; i++)
            //        {

            //            dataGridView3[i, dataGridView3_i].Value = reader["C" + i.ToString()];
            //        }
            //        dataGridView3_i++;


            //    }
            //}
            //reader.Close();
            //cn.Close();
            ///////////////////
            for (int i = 0; i < data2.Rows.Count; i++)
            {
                data2["NDUP", i].Value = 0;
                data2["NVLN", i].Value = 0;
            }


            temp_in.Text = "";
            //cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            //cn.Open();
            //int size1 = Convert.ToInt32(NFR.Value);
            //int size2 = Convert.ToInt32(NSO.Value);
            //for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
            //{
            //    int k = 0;
            //    cmd.CommandText = "select * from temp" + rowIndex.ToString();
            //    SQLiteDataAdapter db1 = new SQLiteDataAdapter(cmd);
            //    DataTable dt1 = new DataTable();
            //    db1.Fill(dt1);
            //    int size_c1 = dt1.Columns.Count;
            //    reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {

            //        for (int columnIndex = 0; columnIndex < size_c1; ++columnIndex)
            //        {
            //            temp_level[rowIndex][columnIndex, k].Value = reader["C" + columnIndex.ToString()];


            //        }

            //        k++;

            //    }
            //    reader.Close();

            //}

            //cn.Close();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=2=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=6=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=8=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=38=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=44=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=46=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=48=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=46=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=46=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }


        public object[,] batch;
        ProgressWindow progressWindow;
        public void DoIDARC(String xx)
        {

            //  progressWindow.Show();
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();

            cmd.CommandText = "select * from " + xx;
            SQLiteDataReader reader1 = cmd.ExecuteReader();
            int batch_check = 0;
            int earth_check = 0;
            reader1.Read();
            if (Convert.ToInt16(reader1["IOPT"]) == 3)
            {
                if (DataRecordExtensions.HasColumn(reader1, "batch_check"))
                {
                    batch_check = Convert.ToInt16(reader1["batch_check"]);
                }
                else
                    batch_check = 0;
            }
            else
                batch_check = 0;

            if (Convert.ToInt16(reader1["IOPT"].ToString()) == 3)
                earth_check = 3;
            else
                earth_check = 0;

            reader1.Close();

            int factor_c = 0;

            int FEMA_check = 0;
            if (TableExists("batch_info", cn))
            {
                cmd.CommandText = "select * from batch_info";
                reader1 = cmd.ExecuteReader();
                reader1.Read();
                FEMA_check = Convert.ToInt16(reader1["FEMA"].ToString());

                reader1.Close();
            }

            if (batch_check != 0)
            {

                //FEMA



                //BATCH
                if (Directory.Exists(Var.pp + @"\IDARC_" + xx))
                    Directory.Delete(Var.pp + @"\IDARC_" + xx, true);
                cmd.CommandText = "select * from " + xx;
                reader1 = cmd.ExecuteReader();
                reader1.Read();

                decimal batch_start = Convert.ToDecimal(reader1["batch_start"]);
                int batch_ver = Convert.ToInt16(reader1["IWV"]);
                decimal batch_end = Convert.ToDecimal(reader1["batch_end"]);
                decimal batch_inc = Convert.ToDecimal(reader1["batch_inc"]);
                int count = Convert.ToInt16(reader1["batch_count"]);
                String search = Convert.ToString(reader1["textBox46"]);
                //dobue
                reader1.Close();
                int factors = 0;// decimal xfactor = 0;// = (((batch_end - batch_start)+batch_inc) / batch_inc);
                for (decimal s = batch_start; s <= batch_end; s += batch_inc)
                {
                    factors++;
                }

                //if (((batch_end - batch_start) % batch_inc) == 0)
                //    xfactors += 1;
                // int factors = Convert.ToInt16(xfactors);
                //  if()
                batch = new object[count, 11];
                //ExecutionState.Init(factors, count);// Initalize the exectuion state, to be used in parallization SAAA 20.06.15
                results_class[, ,] results = new results_class[count, factors, (int)NSO.Value];
                for (int i = 0; i < results.GetLength(0); i++)
                {
                    for (int j = 0; j < results.GetLength(1); j++)
                    {
                        for (int k = 0; k < results.GetLength(2); k++)
                        {
                            results[i, j, k] = new results_class();
                        }
                    }
                }
                decimal[] factors_m = new decimal[factors];

                decimal scale_f = batch_start;

                for (int o = 0; o < factors_m.GetLength(0); o++)
                {
                    factors_m[o] = count;
                }

                List<WaveFile> Hfiles = new List<WaveFile>();
                List<WaveFile> Vfiles = new List<WaveFile>();
                List<string> HfilesNames = new List<string>();
                List<string> VfilesNames = new List<string>();
                string error_message = "";
                double suggested_DTCAL = 0.0;
                if (FEMA_check == 0)
                {

                    string sql1 = "SELECT * FROM EQH order by order_id;";
                    string sql2 = "SELECT * FROM EQV order by order_id;";

                    // cmd.CommandText = "insert into EQH (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "')";
                    //  cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

                    cmd.CommandText = sql1;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    double dumpDeltaT = 0;
                    int kk = 0;
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
                        wave.ID = kk;
                        Hfiles.Add(wave);
                        //HfilesNames.Add("HFile_" + kk + ".dat");
                        HfilesNames.Add(wave.ToString() + ".h");
                        wave.getValues(ref dumpDeltaT);

                        kk++;
                    }
                    reader.Close();
                    cmd.CommandText = sql2;
                    reader = cmd.ExecuteReader();
                    kk = 0;
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
                        wave.ID = kk;
                        Vfiles.Add(wave);
                        // VfilesNames.Add("VFile_" + kk + ".dat");
                        VfilesNames.Add(wave.ToString() + ".v");
                        wave.getValues(ref dumpDeltaT);
                        kk++;
                    }
                    reader.Close();
                }
                if (FEMA_check != 1)
                {
                    for (int ii = 0; ii < count; ii++)
                    {

                        // batch[ii, 0] = reader1["path_h"];
                        // batch[ii, 1] = Hfiles[ii].Max;              //Max H
                        batch[ii, 1] = 1;
                        batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
                        //batch[ii, 3] = reader1["path_v"];
                        batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
                        batch[ii, 6] = batch_end;
                        batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H
                        double check = Hfiles[ii].deltaT / Limits.DTCAL;
                        if (Math.Abs(check - (int)check) > Limits.WAVE_FILE_EPSLON)
                        {
                            string error = String.Format("Delta T {0} for the file {1} is not a multiple of {2}\r\n", Hfiles[ii].deltaT, Hfiles[ii], Limits.DTCAL);
                            if (!error_message.Contains(error))
                                error_message += error;


                        }
                        if (ii < VfilesNames.Count && batch_ver != 0) //hmmm
                        {
                            batch[ii, 5] = VfilesNames[ii];    //Name V
                            //   batch[ii, 8] = Vfiles[ii].Max;      //Max V
                            batch[ii, 8] = 1;
                            batch[ii, 9] = Vfiles[ii].deltaT;   //Delta V (No need- Delta of H should be same as V)
                            batch[ii, 10] = Vfiles[ii].values.Count; //Line V (No need- Numer of Lines for H should be same as V)
                            check = Vfiles[ii].deltaT / Limits.DTCAL;
                            if (Math.Abs(check - (int)check) > Limits.WAVE_FILE_EPSLON)
                            {
                                string error = String.Format("Delta T {0} for the file {1} is not a multiple of {2}\r\n", Vfiles[ii].deltaT, Vfiles[ii], Limits.DTCAL);
                                if (!error_message.Contains(error))
                                    error_message += error;
                            }
                        }



                    }
                }
                double ACMR20 = 0;
                PGA_Sa_Factor_output[] PGAonSa;
                if (FEMA_check == 1)
                {
                    double SF_FEMA = 0;
                    double PGAonSa_H1 = 0;
                    double PGAonSa_H2 = 0;
                    double PGAonSa_V = 0;


                    PGA_Sa_Factor_output[] PGAonSa_N;
                    PGA_Sa_Factor_output[] PGAonSa_F;

                    //Interpolate; PGAonSa now is [22] for FAR, [28] for Near. H1,H2,V

                    int nEQ = 0;
                    //GET Near_Check, SF(N, F)
                    cmd.CommandText = "select * from FEMA_final";
                    reader1 = cmd.ExecuteReader();
                    reader1.Read();
                    double T = Convert.ToDouble(reader1["period"].ToString());
                    int Near_check = Convert.ToInt16(reader1["chs_n"].ToString());
                    double SF_N = Convert.ToDouble(reader1["SF_N"].ToString());
                    double SF_F = Convert.ToDouble(reader1["SF_F"].ToString());
                    ACMR20 = Convert.ToDouble(reader1["ACMR20"].ToString());

                    reader1.Close();
                    PGAonSa_N = calc_PGAonSa(T, 1);
                    PGAonSa_F = calc_PGAonSa(T, 2);

                    //ArrayList selected = new ArrayList();
                    ArrayList normlized = new ArrayList();
                    Hfiles.Clear();
                    HfilesNames.Clear();
                    Vfiles.Clear();
                    VfilesNames.Clear();
                    //List<WaveFile> Hfiles1 = new List<WaveFile>();
                    //List<WaveFile> Hfiles2 = new List<WaveFile>();
                    //List<WaveFile> Vfiles1 = new List<WaveFile>();
                    //List<WaveFile> Vfiles2 = new List<WaveFile>();
                    //List<string> HfilesNames1 = new List<string>();
                    //List<string> VfilesNames1 = new List<string>();
                    //List<string> HfilesNames2 = new List<string>();
                    //List<string> VfilesNames2 = new List<string>();


                    String FEMA_path = Var.pp + @"\FEMA";
                    int tt = 0;


                    //GET FILE + Create Normilized factors

                    if (Near_check != 0) //Near
                    {
                        SF_FEMA = SF_N;
                        PGAonSa = PGAonSa_N;
                        normlized.AddRange(new double[] { 0.9, 0.96, 1.72, 1.04, 1.63, 1.09, 1.08, 0.77, 0.69, 0.8, 2.79, 0.74, 0.86, 1.08, 0.86, 1.13, 1.99, 1.27, 1.95, 1.15, 1.17, 0.66, 0.77, 1.18, 0.9, 0.78, 0.62, 0.57 });

                        cmd.CommandText = "select * from FEMA_files_N";
                        reader1 = cmd.ExecuteReader();
                        reader1.Read();
                        for (int i = 1; i < 29; i++)
                        {

                            if (reader1["Near"].ToString() == "1")
                            {
                                //   MessageBox.Show(i + "            1");
                                nEQ += 2;
                                WaveFile wave = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-1.dat");         //H1
                                wave.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-1.dat";
                                wave.Header_Lines = 1;
                                wave.isTimeAndValues = false;
                                wave.Points_Per_Line = 1;
                                wave.Prefix_Per_Line = 0;
                                double delta_t = 0;
                                wave.FEMA_Delta(ref delta_t);
                                wave.deltaT = delta_t;
                                wave.values = wave.getValues(ref delta_t);
                                wave.FEMA_Modify((double)normlized[i - 1]);
                                wave.FEMA_max();
                                wave.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                wave.FEMA_max();
                                wave.ID = tt;
                                wave.EQID = i - 1;
                                Hfiles.Add(wave);
                                // HfilesNames.Add("HFile_" + tt + ".dat");
                                HfilesNames.Add(wave.ToString() + ".h");
                                if (System.IO.File.Exists(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat") && batch_ver == 1)
                                {
                                    WaveFile wave3 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat");            //V
                                    wave3.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat";
                                    wave3.Header_Lines = 1;
                                    wave3.isTimeAndValues = false;
                                    wave3.Points_Per_Line = 1;
                                    wave3.Prefix_Per_Line = 0;
                                    double delta_t3 = 0;
                                    wave3.FEMA_Delta(ref delta_t3);
                                    wave3.deltaT = delta_t3;
                                    wave3.values = wave3.getValues(ref delta_t3);
                                    wave3.FEMA_Modify((double)normlized[i - 1]);
                                    wave3.FEMA_max();
                                    wave3.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                    wave3.FEMA_max();
                                    wave3.ID = tt;
                                    wave3.EQID = i - 1;
                                    Vfiles.Add(wave3);
                                    //VfilesNames.Add("VFile_" + tt + ".dat");
                                    VfilesNames.Add(wave3.ToString() + ".v");
                                }
                                tt++;

                                WaveFile wave2 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-2.dat");            //H2
                                wave2.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-2.dat";
                                wave2.Header_Lines = 1;
                                wave2.isTimeAndValues = false;
                                wave2.Points_Per_Line = 1;
                                wave2.Prefix_Per_Line = 0;
                                double delta_t2 = 0;
                                wave2.FEMA_Delta(ref delta_t2);
                                wave2.deltaT = delta_t2;
                                wave2.values = wave2.getValues(ref delta_t2);
                                wave2.FEMA_Modify((double)normlized[i - 1]);
                                wave2.FEMA_max();
                                wave2.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                wave2.FEMA_max();
                                wave2.ID = tt;
                                wave2.EQID = i - 1;
                                Hfiles.Add(wave2);
                                // HfilesNames.Add("HFile_" + tt + ".dat");
                                HfilesNames.Add(wave2.ToString() + ".h");
                                if (System.IO.File.Exists(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat") && batch_ver == 1)
                                {
                                    WaveFile wave4 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat");            //V
                                    wave4.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat";
                                    wave4.Header_Lines = 1;
                                    wave4.isTimeAndValues = false;
                                    wave4.Points_Per_Line = 1;
                                    wave4.Prefix_Per_Line = 0;
                                    double delta_t4 = 0;
                                    wave4.FEMA_Delta(ref delta_t4);
                                    wave4.deltaT = delta_t4;
                                    wave4.getValues(ref delta_t4);
                                    wave4.values = wave4.FEMA_Modify((double)normlized[i - 1]);
                                    wave4.FEMA_max();
                                    wave4.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                    wave4.FEMA_max();
                                    wave4.ID = tt;
                                    wave4.EQID = i - 1;
                                    Vfiles.Add(wave4);
                                    //VfilesNames.Add("VFile_" + tt + ".dat");
                                    VfilesNames.Add(wave4.ToString() + ".v");
                                }
                                tt++;


                            }
                            reader1.Read();

                        }
                        reader1.Close();


                    }
                    else //FAR
                    {
                        SF_FEMA = SF_F;
                        PGAonSa = PGAonSa_F;
                        normlized.AddRange(new double[] { 0.65, 0.83, 0.63, 1.09, 1.31, 1.01, 1.03, 1.1, 0.69, 1.36, 0.99, 1.15, 1.09, 0.88, 0.79, 0.87, 1.17, 0.82, 0.41, 0.96, 2.1, 1.44 });

                        cmd.CommandText = "select * from FEMA_files_F";
                        reader1 = cmd.ExecuteReader();
                        reader1.Read();
                        for (int i = 1; i < 23; i++)
                        {
                            if (reader1["Far"].ToString() == "1")
                            {
                                nEQ += 2;
                                //      MessageBox.Show(i + "         1");
                                WaveFile wave = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-1.AT2");         //H1
                                wave.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-1.AT2";
                                wave.Header_Lines = 1;
                                wave.isTimeAndValues = false;
                                wave.Points_Per_Line = 1;
                                wave.Prefix_Per_Line = 0;
                                double delta_t = 0;
                                wave.FEMA_Delta(ref delta_t);
                                wave.deltaT = delta_t;
                                wave.values = wave.getValues(ref delta_t);
                                wave.FEMA_Modify((double)normlized[i - 1]);
                                wave.FEMA_max();
                                wave.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                wave.FEMA_max();
                                wave.ID = tt;
                                wave.EQID = i - 1;
                                Hfiles.Add(wave);
                                //HfilesNames.Add("HFile_" + tt + ".dat");
                                HfilesNames.Add(wave.ToString() + ".h");
                                if (System.IO.File.Exists(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2") && batch_ver == 1)
                                {
                                    WaveFile wave3 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2");            //V
                                    wave3.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2";
                                    wave3.Header_Lines = 1;
                                    wave3.isTimeAndValues = false;
                                    wave3.Points_Per_Line = 1;
                                    wave3.Prefix_Per_Line = 0;
                                    double delta_t3 = 0;
                                    wave3.FEMA_Delta(ref delta_t3);
                                    wave3.deltaT = delta_t3;
                                    wave3.values = wave3.getValues(ref delta_t3);
                                    wave3.FEMA_Modify((double)normlized[i - 1]);
                                    wave3.FEMA_max();
                                    wave3.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                    wave3.FEMA_max();
                                    wave3.ID = tt;
                                    wave3.EQID = i - 1;
                                    Vfiles.Add(wave3);
                                    //VfilesNames.Add("VFile_" + tt + ".dat");
                                    VfilesNames.Add(wave3.ToString() + ".v");

                                }
                                tt++;

                                WaveFile wave2 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-2.AT2");            //H2
                                wave2.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-2.AT2";
                                wave2.Header_Lines = 1;
                                wave2.isTimeAndValues = false;
                                wave2.Points_Per_Line = 1;
                                wave2.Prefix_Per_Line = 0;
                                double delta_t2 = 0;
                                wave2.FEMA_Delta(ref delta_t2);
                                wave2.deltaT = delta_t2;
                                wave2.values = wave2.getValues(ref delta_t2);
                                wave2.FEMA_Modify((double)normlized[i - 1]);
                                wave2.FEMA_max();
                                wave2.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                wave2.FEMA_max();
                                wave2.ID = tt;
                                wave2.EQID = i - 1;
                                Hfiles.Add(wave2);
                                //HfilesNames.Add("HFile_" + tt + ".dat");
                                HfilesNames.Add(wave2.ToString() + ".h");
                                if (System.IO.File.Exists(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2") && batch_ver == 1)
                                {
                                    WaveFile wave4 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2");            //V
                                    wave4.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2";
                                    wave4.Header_Lines = 1;
                                    wave4.isTimeAndValues = false;
                                    wave4.Points_Per_Line = 1;
                                    wave4.Prefix_Per_Line = 0;
                                    double delta_t4 = 0;
                                    wave4.FEMA_Delta(ref delta_t4);
                                    wave4.deltaT = delta_t4;
                                    wave4.getValues(ref delta_t4);
                                    wave4.values = wave4.FEMA_Modify((double)normlized[i - 1]);
                                    wave4.FEMA_max();
                                    wave4.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
                                    wave4.FEMA_max();
                                    wave4.ID = tt;
                                    wave4.EQID = i - 1;
                                    Vfiles.Add(wave4);
                                    // VfilesNames.Add("VFile_" + tt + ".dat");
                                    VfilesNames.Add(wave4.ToString() + ".v");

                                }
                                tt++;



                            }
                            reader1.Read();

                        }
                        reader1.Close();

                    }
                    batch = new object[nEQ, 11];
                    results = new results_class[nEQ, factors, (int)NSO.Value];
                    for (int i = 0; i < results.GetLength(0); i++)
                    {
                        for (int j = 0; j < results.GetLength(1); j++)
                        {
                            for (int k = 0; k < results.GetLength(2); k++)
                            {
                                results[i, j, k] = new results_class();
                            }
                        }
                    }
                    count = nEQ;
                    for (int o = 0; o < factors_m.GetLength(0); o++)
                    {
                        factors_m[o] = nEQ;
                    }

                    for (int ii = 0; ii < Hfiles.Count; ii++)
                    {

                        // batch[ii, 0] = reader1["path_h"];
                        //batch[ii, 1] = Hfiles[ii].Max * SF_FEMA;              //Max H             (EDIT:20/5)
                        if (Hfiles[ii].ID % 2 == 0)
                            batch[ii, 1] = 1 / PGAonSa[Hfiles[ii].EQID].Horziantal1;
                        else
                            batch[ii, 1] = 1 / PGAonSa[Hfiles[ii].EQID].Horziantal2;

                        batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
                        //batch[ii, 3] = reader1["path_v"];
                        batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
                        batch[ii, 6] = batch_end;
                        batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H

                        double check = Hfiles[ii].deltaT / Limits.DTCAL;
                        if (Math.Abs(check - (int)check) > Limits.WAVE_FILE_EPSLON)
                        {
                            string error = String.Format("Delta T {0} for the file {1} is not a multiple of {2}\r\n", Hfiles[ii].deltaT, Hfiles[ii], Limits.DTCAL);
                            if (!error_message.Contains(error))
                                error_message += error;
                        }
                        int eI = -1;
                        for (int l = 0; l < Vfiles.Count; l++)
                        {
                            if (Vfiles[l].ID == Hfiles[ii].ID)
                            {
                                eI = l;
                                break;
                            }
                        }
                        if (eI != -1)
                        {

                            batch[ii, 5] = VfilesNames[eI];    //Name V
                            //   batch[ii, 8] = Vfiles[eI].Max * SF_FEMA;      //Max V               (EDIT:20/5)
                            batch[ii, 8] = 1 / PGAonSa[Vfiles[eI].EQID].Vertical;                                               //(EDIT:20/5)
                            batch[ii, 9] = Vfiles[eI].deltaT;   //Delta V (No need- Delta of H should be same as V)
                            batch[ii, 10] = Vfiles[eI].values.Count; //Line V (No need- Numer of Lines for H should be same as V)
                            check = Vfiles[eI].deltaT / Limits.DTCAL;
                            if (Math.Abs(check - (int)check) > Limits.WAVE_FILE_EPSLON)
                            {
                                string error = String.Format("Delta T {0} for the file {1} is not a multiple of {2}\r\n", Vfiles[eI].deltaT, Vfiles[eI], Limits.DTCAL);
                                if (!error_message.Contains(error))
                                    error_message += error;
                            }
                        }
                        else
                        {
                            batch[ii, 5] = "NONE";    //Name V
                        }




                    }

                }

                reader1.Close();
                cn.Close();

                if (error_message != String.Empty)
                {
                    if (ErrorForm.Show(error_message) == DialogResult.No)
                        return;

                }

                scale_f = batch_start;

                factor_c = 0;
                Process p = new Process();
                int vFileIndex = -1;
                int scaleIndex = 0;


                ExecutionState.Init(factors, count);

                progressWindow = new ProgressWindow();
                Thread th = new Thread(new ThreadStart(showProgressBar));
                th.Start();

                for (scale_f = batch_start, factor_c = 0, scaleIndex = 0; factor_c < factors; scale_f += batch_inc, scaleIndex++, factor_c++)
                {




                    for (int i = 0; i < count; i++)
                    {
                        String path = Var.pp + @"\IDARC_" + xx + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
                        if (System.IO.Directory.Exists(path))
                            System.IO.Directory.Delete(path, true);
                        //  System.Threading.Thread.Sleep(100);
                        ExecutionState.Paths[scaleIndex, i] = path;
                        ExecutionState.Scales[scaleIndex, i] = (double)scale_f;

                        System.IO.Directory.CreateDirectory(path);


                        int hLines = 0, vLines = 0;
                        //Copy the Eq files

                        if (i < HfilesNames.Count)
                        {
                            Hfiles[i].writeToFile(path + @"\" + HfilesNames[i], ref hLines);
                            ExecutionState.HFiles[scaleIndex, i] = HfilesNames[i];
                        }
                        else
                            ExecutionState.HFiles[scaleIndex, i] = null;

                        vFileIndex = -1;
                        for (int l = 0; l < Vfiles.Count; l++)
                        {
                            if (Vfiles[l].ID == Hfiles[i].ID)
                            {
                                vFileIndex = l;
                                break;
                            }
                        }
                        if (vFileIndex != -1 && batch_ver != 0)
                        {
                            Vfiles[vFileIndex].writeToFile(path + @"\" + VfilesNames[vFileIndex], ref vLines);
                            ExecutionState.VFiles[scaleIndex, i] = VfilesNames[vFileIndex];
                        }
                        else
                            ExecutionState.VFiles[scaleIndex, i] = null;


                        String line;

                        for (int k = 0; k < (int)NSO.Value; k++)
                        {
                            results[i, factor_c, k].scale_factor = scale_f;
                        }

                        List<string> list = new List<string>(Regex.Split(temp_in.Text, "\n"));
                        //    int old_count = list.Count;

                        for (int k = 0; k < list.Count; k++)
                        {
                            if (list[k].Equals(search))
                            {///////////////EDITING MAX_G,LINES,
                                String edit1 = list[k + 1];
                                List<string> edit_values1 = new List<string>(Regex.Split(edit1, ","));
                                edit_values1[0] = Convert.ToString(Convert.ToDecimal(batch[i, 1]) * scale_f); //SF * PGA_H
                                if (vFileIndex != -1 && batch_ver != 0)
                                {
                                    edit_values1[1] = Convert.ToString(Convert.ToDecimal(batch[i, 8]) * scale_f); //SF * PGA_V

                                }
                                else
                                {
                                    edit_values1[1] = "0";
                                }
                                decimal xxx1 = Convert.ToDecimal(batch[i, 2]);
                                decimal xxx2 = Convert.ToDecimal(batch[i, 7]);
                                edit_values1[3] = Convert.ToString(xxx1 * xxx2); //Number of Lines_H

                                String edit2 = list[k + 3];
                                List<string> edit_values2 = new List<string>(Regex.Split(edit2, ","));
                                edit_values2[2] = Convert.ToString(Convert.ToDecimal(batch[i, 2])); //Lines
                                edit_values2[3] = Convert.ToString(Convert.ToDecimal(batch[i, 7])); //DeltaT
                                if (vFileIndex == -1 || batch_ver == 0)
                                {
                                    edit_values2[1] = "0";
                                }
                                else
                                {
                                    edit_values2[1] = "1";

                                }
                                String edit3 = list[k + 5]; //Edit H Name
                                List<string> edit_values3 = new List<string>(Regex.Split(edit3, ","));
                                edit_values3[0] = batch[i, 4].ToString();




                                list[k + 1] = String.Join(",", edit_values1.ToArray());
                                list[k + 3] = String.Join(",", edit_values2.ToArray());
                                list[k + 5] = String.Join(",", edit_values3.ToArray());

                                if (vFileIndex != -1 && batch_ver != 0) //Edit V Name
                                {
                                    String edit4 = list[k + 6];
                                    List<string> edit_values4 = new List<string>(Regex.Split(edit4, ","));
                                    edit_values4[0] = batch[i, 5].ToString();
                                    list[k + 6] = String.Join(",", edit_values4.ToArray());



                                }
                                else
                                {

                                }

                                break;
                            }
                        }
                        //int new_count = list.Count;
                        //      int stop_count = new_count - old_count;
                        temp_in.Text = "";
                        for (int k = 0; k < list.Count; k++)
                        {
                            temp_in.Text += list[k] + "\n";
                        }

                        //Run the input file, for loop; until failure.



                        //Run all the files for specific scale factor



                        System.IO.File.Copy(Var.pp + @"\idarc2d_7.0.exe", path + @"\idarc2d_7.0.exe", true);
                        ////////////
                        if (batch_ver == 1)
                        {
                            StreamWriter sw = new StreamWriter((path + @"\test.dat"));
                            for (int v = 0; v < temp_in.Lines.Length; v++)
                            {
                                if (temp_in.Lines[v].StartsWith(search))
                                {
                                    for (int vv = 0; vv <= 5; vv++)
                                    {
                                        sw.WriteLine(temp_in.Lines[v + vv]);
                                    }
                                    if (vFileIndex != -1)
                                        sw.WriteLine(temp_in.Lines[v + 6]);

                                    v += 6;
                                }
                                else
                                {
                                    sw.WriteLine(temp_in.Lines[v]);
                                }
                            }
                            sw.Flush();
                            sw.Close();

                        }
                        else
                        {
                            temp_in.SaveFile(path + @"\test.dat", RichTextBoxStreamType.PlainText);
                        }

                        System.IO.File.Copy(Var.pp + @"\IDARC.dat", path + @"\IDARC.dat", true);

                        string[] lines = { "test.dat", "test.out" };

                        ExecutionState.Text[scaleIndex, i] = File.ReadAllText(path + @"\test.dat");

                        System.IO.File.WriteAllLines(path + @"\IDARC.dat", lines);

                        // System.Threading.Thread.Sleep(100);
                        //
                        //MessageBox.Show(i.ToString());


                        path = Var.pp + @"\IDARC_" + xx + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();

                        Action DoIncProgressBar = () =>
                        {
                            progressWindow.progressBar.Value++;// states[i][j].changeState(RunningState.Fail);
                            progressWindow.progressBar.Refresh();
                        };
                        this.Invoke(DoIncProgressBar);
                        continue;
                    }


                }
                // progressWindow.Close();
                Action DoCloseProgressBar = () =>
                {
                    progressWindow.Close();
                };
                this.Invoke(DoCloseProgressBar);
                DialogResult res = System.Windows.Forms.DialogResult.Cancel;

                /////
                String results_t = Helpers.ObjectToString(results);
                String batch_t = Helpers.ObjectToString(batch);
                String factors_t = Helpers.ObjectToString(factors_m);
                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;

                cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "DROP TABLE IF EXISTS Plot";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table Plot ([id] integer  NOT NULL PRIMARY KEY, [results_t] TEXT NULL, [batch_t] TEXT NULL, [factors_t] TEXT NULL)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into Plot (id,results_t,batch_t,factors_t) values (" + 1 + ", '" + results_t + "', '" + batch_t + "', '" + factors_t + "')";
                cmd.ExecuteNonQuery();
                double BB, duct, SSF, Smt, c1, c2, c3, c4, c5, cc1, cc2, cc3, cc4, cc5, c6_drift, c6_damage, checkbox6, checkbox7;
                BB = duct = SSF = Smt = c1 = c2 = c3 = c4 = c5 = cc1 = cc2 = cc3 = cc4 = cc5 = c6_drift = c6_damage = checkbox6 = checkbox7 = -1;

                cmd.CommandText = "select * from FEMA_info";
                reader1 = cmd.ExecuteReader();
                BB = Convert.ToDouble(reader1["BTOT"]);
                duct = Convert.ToDouble(reader1["mu"]);
                SSF = Convert.ToDouble(reader1["SSF"]);
                Smt = Convert.ToDouble(reader1["Smt"]);

                c1 = Convert.ToDouble(reader1["c1"]);
                c2 = Convert.ToDouble(reader1["c2"]);
                c3 = Convert.ToDouble(reader1["c3"]);
                c4 = Convert.ToDouble(reader1["c4"]);
                c5 = Convert.ToDouble(reader1["c5"]);

                cc1 = Convert.ToDouble(reader1["cc1"]);
                cc2 = Convert.ToDouble(reader1["cc2"]);
                cc3 = Convert.ToDouble(reader1["cc3"]);
                cc4 = Convert.ToDouble(reader1["cc4"]);
                cc5 = Convert.ToDouble(reader1["cc5"]);
                c6_drift = Convert.ToDouble(reader1["c6_drift"]);
                c6_damage = Convert.ToDouble(reader1["c6_damage"]);

                checkbox6 = Convert.ToDouble(reader1["checkbox6"]);
                checkbox7 = Convert.ToDouble(reader1["checkbox7"]);
                reader1.Close();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


                ////


                try
                {
                    ExecutionMonitors mon = new ExecutionMonitors(results, factors_m, (int)NSO.Value, checkbox6, checkbox7, c6_drift, c6_damage);
                    res = mon.ShowDialog();
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("Error in Creating Execution Monitor Form\r\nTry to decrease the total number of runs.");
                    return;
                }
                //PLOT


                // Save plot inforamtion to be used in the last veiw tab;
                PlotInfo.results = results;
                PlotInfo.batch = batch;
                PlotInfo.factors = factors_m;
                PlotInfo.BTOT = BB;
                PlotInfo.c1 = c1;
                PlotInfo.c2 = c2;
                PlotInfo.c3 = c3;
                PlotInfo.c4 = c4;
                PlotInfo.c5 = c5;
                PlotInfo.ductt = duct;
                PlotInfo.Smtt = Smt;
                PlotInfo.SSFf = SSF;
                PlotInfo.FEMA_check = FEMA_check;
                PlotInfo.cc1 = cc1;
                PlotInfo.cc2 = cc2;
                PlotInfo.cc3 = cc3;
                PlotInfo.cc4 = cc4;
                PlotInfo.cc5 = cc5;
                PlotInfo.ACMR20 = ACMR20;
                PlotInfo.units = Analysis.units;
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    plot t = new plot(ref results, ref batch, ref factors_m, BB, c1, c2, c3, c4, c5, duct, SSF, Smt, FEMA_check, cc1, cc2, cc3, cc4, cc5, ACMR20, Analysis.units);
                    t.Show();
                }


            }
            /////// if(batch)
            //#for(all the files)
            //Read start,end,step
            //#for(int i = start;i<end;i+=step)
            /*
             * array of "batch", the 1st column is path, second is max(g), third is #lines*deta t
             * {
             * adjust the above line to input:
             * mutiplie with i,
             * create the folder and run the idarc
             * if it's fail, stop and get the factor and save it in fouth column
             * if not, take the max drift%, base shear, shear at max drift%. save them in columns
             * 
             * 
             * 
             * //
             */










                //if(earth_check ==3)
            #region Single file mode
            else
            {
                ///
                String path = Var.pp + @"\IDARC_" + xx + @"\IDARC_tempFile";

                if (System.IO.Directory.Exists(path))
                    System.IO.Directory.Delete(path, true);
                //?  System.Threading.Thread.Sleep(100);


                System.IO.Directory.CreateDirectory(path);
                System.IO.File.Copy(Var.pp + @"\idarc2d_7.0.exe", path + @"\idarc2d_7.0.exe", true);


                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                cn.Open();
                if (dataGridView12.Rows.Count > 0)
                {
                    int de = dataGridView12.CurrentRow.Index;
                    cmd.CommandText = "select * from " + dataGridView12[0, de].Value.ToString();
                    reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1["WHFILE"].ToString() != "None")
                        {
                            String temp = reader1["WHFILE_t"].ToString();
                            System.IO.File.WriteAllText(path + @"\" + reader1["WHFILE"], temp);

                        }
                        if (reader1["WVFILE"].ToString() != "None")
                        {
                            String temp = reader1["WVFILE_t"].ToString();
                            System.IO.File.WriteAllText(path + @"\" + reader1["WVFILE"], temp);

                        }
                    }
                    reader1.Close();
                }
                cn.Close();


                temp_in.SaveFile(path + @"\test.dat", RichTextBoxStreamType.PlainText);
                System.IO.File.Copy(Var.pp + @"\IDARC.dat", path + @"\IDARC.dat", true);

                string[] lines = { "test.dat", "test.out" };
                System.IO.File.WriteAllLines(path + @"\IDARC.dat", lines);

                //?   System.Threading.Thread.Sleep(100);

                ProcessStartInfo startInfo = new ProcessStartInfo(path + @"\idarc2d_7.0.exe");
                startInfo.WorkingDirectory = path;
                startInfo.UseShellExecute = false;
                startInfo.Verb = "runas";
                Process p = new Process();
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();
                System.Threading.Thread.Sleep(100);
                Process.Start(path);
                Process.Start("notepad.exe", path + @"\test.out");
            }
            #endregion

        }
        void showProgressBar()
        {

            progressWindow.label.Text = "Copying Files, Please wait..";
            progressWindow.progressBar.Minimum = 0;
            progressWindow.progressBar.Maximum = ExecutionState.FilesCount * ExecutionState.ScalesCount;
            progressWindow.progressBar.Value = 0;
            progressWindow.Refresh();
            progressWindow.ShowDialog();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                PlotNeedsSaving = true;
                if (checkedListBox1.Items.Count > 0)
                {
                    checkedListBox1.SelectedIndex = 0;
                }
                /////For each analysis
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        String xx = checkedListBox1.Items[i].ToString();
                        // ReadfromDB(xx);
                        DoIDARC(xx);
                        break;
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Error in Creating Execution Monitor Form\r\nTry to decrease the total number of runs.");
                return;
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=1=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(PlotNeedsSaving == true)
            {
                if(MessageBox.Show("You have some plots generated, do you want to save them ? ","Plot Info",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    SavePlot();
                }
            }
            New1 result = new New1("Do you want to save your data before closing the program?");
            DialogResult a = result.ShowDialog();
            if (a == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.OK)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            if (a == DialogResult.No)
            {



            }
            if (a == DialogResult.Cancel)
            {
                e.Cancel = true;

            }


        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void Analysis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wizardPage8_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            if (PlotInfo.results == null)
            {
                MessageBox.Show("No Plots to Show");
                return;
            }
            plot t = new plot(ref PlotInfo.results, ref PlotInfo.batch, ref PlotInfo.factors, PlotInfo.BTOT, PlotInfo.c1, PlotInfo.c2, PlotInfo.c3, PlotInfo.c4, PlotInfo.c5, PlotInfo.ductt, PlotInfo.SSFf, PlotInfo.Smtt, PlotInfo.FEMA_check, PlotInfo.cc1, PlotInfo.cc2, PlotInfo.cc3, PlotInfo.cc4, PlotInfo.cc5, PlotInfo.ACMR20, Analysis.units);
            t.Show();
        }

        //private void button29_Click_1(object sender, EventArgs e)
        //{
        //    if (batch_options == null)
        //        batch_options = new Batch_opt();
        //    batch_options.ShowDialog();
        //}


        FEMA_opt FEMA;

        //private void button33_Click(object sender, EventArgs e)
        //{
        //    if (FEMA == null)
        //        FEMA = new FEMA_opt(units_post.Checked, Convert.ToDouble(h_post.Text));

        //    FEMA.ShowDialog();
        //}

        //private void button35_Click(object sender, EventArgs e)
        //{
        //    openFileDialog3.ShowDialog();
        //}

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            StreamReader t = new StreamReader(openFileDialog3.FileName);
            load_input.Text = t.ReadToEnd();
        }

        //private void button34_Click(object sender, EventArgs e)
        //{
        //    double tempp;
        //    int tempp_t;
        //    if (load_input.Text.Trim().Equals(String.Empty))
        //    {
        //        MessageBox.Show("Please load input file first ");
        //        return;
        //    }

        //    if (!Int32.TryParse(NSO_post.Text, out tempp_t))
        //    {
        //        MessageBox.Show("Number of Stories input should contain numeric ");
        //        return;
        //    }
        //    if (!Double.TryParse(h_post.Text, out tempp))
        //    {
        //        MessageBox.Show("Total Elevation input should contain numeric ");
        //        return;
        //    }
        //    if (!load_input.Text.Contains(batch_template))
        //    {
        //        MessageBox.Show("Please Make sure the you have " + batch_template + " in your input content");
        //        return;
        //    }
        //    if (chb_isFEMA.Checked == false)
        //    {
        //        if (batch_options == null)
        //        {
        //            batch_options = new Batch_opt();
        //            batch_options.ShowDialog();
        //        }
        //        if (Directory.Exists(Var.pp + @"\IDARC_BATCH"))
        //            Directory.Delete(Var.pp + @"\IDARC_BATCH", true);

        //        decimal batch_start = batch_options.start.Value;
        //        int batch_ver = batch_options.IWV.SelectedIndex;
        //        decimal batch_end = batch_options.end.Value;
        //        decimal batch_inc = batch_options.inc.Value;
        //        int count = batch_options.listBox1.Items.Count;
        //        //String search = Convert.ToString(reader1["textBox46"]);
        //        //dobue
        //        //reader1.Close();
        //        decimal xfactors = ((batch_end - batch_start) / batch_inc);
        //        //if (((batch_end - batch_start) % batch_inc) == 0)
        //        //    xfactors += 1;
        //        int factors = Convert.ToInt16(xfactors);
        //        batch = new object[count, 11];

        //        results_class[, ,] results = new results_class[count, factors, Convert.ToInt16(NSO_post.Text)];
        //        for (int i = 0; i < results.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < results.GetLength(1); j++)
        //            {
        //                for (int k = 0; k < results.GetLength(2); k++)
        //                {
        //                    results[i, j, k] = new results_class();
        //                }
        //            }
        //        }
        //        decimal[] factors_m = new decimal[factors];

        //        decimal scale_f = batch_start;

        //        for (int o = 0; o < factors_m.GetLength(0); o++)
        //        {
        //            factors_m[o] = count;
        //        }

        //        List<WaveFile> Hfiles = new List<WaveFile>();
        //        List<WaveFile> Vfiles = new List<WaveFile>();
        //        List<string> HfilesNames = new List<string>();
        //        List<string> VfilesNames = new List<string>();




        //        double dumpDeltaT = 0;
        //        int kk = 0;
        //        for (int i = 0; i < batch_options.listBox1.Items.Count; i++)
        //        {
        //            WaveFile wave = (WaveFile)batch_options.listBox1.Items[i];
        //            Hfiles.Add(wave);
        //            HfilesNames.Add("HFile_" + i + ".dat");
        //            wave.getValues(ref dumpDeltaT);
        //        }

        //        for (int i = 0; i < batch_options.listBox3.Items.Count; i++)
        //        {
        //            WaveFile wave = (WaveFile)batch_options.listBox3.Items[i];

        //            Vfiles.Add(wave);
        //            VfilesNames.Add("VFile_" + i + ".dat");
        //            wave.getValues(ref dumpDeltaT);

        //        }


        //        for (int ii = 0; ii < count; ii++)
        //        {

        //            // batch[ii, 0] = reader1["path_h"];
        //           // batch[ii, 1] = Hfiles[ii].Max;              //Max H
        //            batch[ii, 1] = 1;
        //            batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
        //            //batch[ii, 3] = reader1["path_v"];
        //            batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
        //            batch[ii, 6] = batch_end;
        //            batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H
        //            if (ii < VfilesNames.Count)
        //            {
        //                batch[ii, 5] = VfilesNames[ii];    //Name V
        //            //    batch[ii, 8] = Vfiles[ii].Max;      //Max V
        //                batch[ii, 8] = 1;

        //                batch[ii, 9] = Vfiles[ii].deltaT;   //Delta V (No need- Delta of H should be same as V)
        //                batch[ii, 10] = Vfiles[ii].values.Count; //Line V (No need- Numer of Lines for H should be same as V)

        //            }
        //        }




        //        scale_f = batch_start;
        //        int scalesCount = (int)((batch_end - batch_start) / batch_inc);
        //        int factor_c = 0;
        //        Process p = new Process();
        //        ExecutionState.Init(scalesCount + 1, count);
        //        progressWindow = new ProgressWindow();
        //        Thread th = new Thread(new ThreadStart(showProgressBar));
        //        th.Start();
        //        int scaleIndex = 0;
        //        for (; scale_f <= batch_end; scale_f += batch_inc,scaleIndex++)
        //        {



        //            //Do u want to include batch_end?

        //            for (int i = 0; i < count; i++)
        //            {
        //                String path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
        //                if (System.IO.Directory.Exists(path))
        //                    System.IO.Directory.Delete(path, true);
        //                //  System.Threading.Thread.Sleep(100);

        //                ExecutionState.Paths[scaleIndex, i] = path;
        //                ExecutionState.Scales[scaleIndex, i] = (double)scale_f;
        //                System.IO.Directory.CreateDirectory(path);


        //                int hLines = 0, vLines = 0;
        //                //Copy the Eq files
        //                if (i < HfilesNames.Count)
        //                {
        //                    Hfiles[i].writeToFile(path + @"\" + HfilesNames[i], ref hLines);
        //                    ExecutionState.HFiles[scaleIndex, i] = HfilesNames[i];
        //                }
        //                else
        //                    ExecutionState.HFiles[scaleIndex, i] = null;

        //                if (i < VfilesNames.Count)
        //                {
        //                    Vfiles[i].writeToFile(path + @"\" + VfilesNames[i], ref vLines);
        //                    ExecutionState.VFiles[scaleIndex, i] = VfilesNames[i];
        //                }
        //                else
        //                    ExecutionState.VFiles[scaleIndex, i] = null;


        //                String line = "DYNAMIC ANALYSIS CONTROL PARAMETERS\n";
        //                line += (Hfiles[i].Max * (double)scale_f) + ",";
        //                if (batch_options.listBox3.Enabled)
        //                    line += (Vfiles[i].Max * (double)scale_f) + ",";
        //                else
        //                    line += "0,";
        //                line += batch_options.DTCAL.Text + ",";
        //                line += Convert.ToDouble(Hfiles[i].deltaT) * Hfiles[i].values.Count + ",";
        //                line += batch_options.DAMP.Text + ",";
        //                line += (batch_options.ITDMP.SelectedIndex + 1) + "\n";
        //                line += "INPUT WAVE INFORMATION\n";
        //                line += "0,";
        //                line += batch_options.IWV.SelectedIndex + ",";
        //                line += Hfiles[i].values.Count + ",";
        //                line += Hfiles[i].deltaT + "\n";
        //                line += "Recorded Table Motion\n";
        //                line += HfilesNames[i] + "";
        //                if (batch_options.listBox3.Enabled)
        //                    line += "\n" + VfilesNames[i];
        //                for (int k = 0; k < Convert.ToInt16(NSO_post.Text); k++)
        //                {
        //                    results[i, factor_c, k].scale_factor = scale_f;
        //                }
        //                System.IO.File.Copy(Var.pp + @"\idarc2d_7.0.exe", path + @"\idarc2d_7.0.exe", true);
        //                string text = load_input.Text;
        //                text = text.Replace(batch_template, line);
        //                text = text.Replace("\n", "\r\n");
        //                ExecutionState.Text[scaleIndex, i] = text;
        //                StreamWriter sw = new StreamWriter(path + @"\test.dat");
        //                sw.Write(text);
        //                sw.Flush();
        //                sw.Close();



        //                // temp_in.SaveFile(path + @"\test.dat", RichTextBoxStreamType.PlainText);
        //                System.IO.File.Copy(Var.pp + @"\IDARC.dat", path + @"\IDARC.dat", true);

        //                string[] lines = { "test.dat", "test.out" };
        //                System.IO.File.WriteAllLines(path + @"\IDARC.dat", lines);

        //                // System.Threading.Thread.Sleep(100);
        //                //
        //                //MessageBox.Show(i.ToString());


        //                path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
        //                ProcessStartInfo startInfo = new ProcessStartInfo(path + @"\idarc2d_7.0.exe");
        //                startInfo.WorkingDirectory = path;
        //                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        //                startInfo.UseShellExecute = false;

        //                startInfo.Verb = "runas";
        //                p = new Process();
        //                p.StartInfo = startInfo;
        //               // p.Start();
        //              //  p.WaitForExit();
        //                path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
        //                Action DoIncProgressBar = () =>
        //                {
        //                    progressWindow.progressBar.Value++;// states[i][j].changeState(RunningState.Fail);
        //                    progressWindow.progressBar.Refresh();
        //                };
        //                this.Invoke(DoIncProgressBar);
        //                continue;

        //                //Process.Start(path);
        //                //Process.Start("notepad.exe", path + @"\test.out");

        //                //Reading from the output
        //                /////?? add delay
        //                while (FileInUse(path + @"\test.out"))
        //                {
        //                    System.Threading.Thread.Sleep(100); //test
        //                }

        //                String output = System.IO.File.ReadAllText(path + @"\test.out");
        //                //int nso_i1 = output.IndexOf(" NUMBER OF STORIES ............");
        //                //int nso_i2 = output.IndexOf("NUMBER OF FRAMES");
        //                //if (nso_i1 == -1 || nso_i2 == -1)
        //                //{
        //                //    MessageBox.Show("Can't detect Number of stories");
        //                //    return; 
        //                //}
        //                //int nso = Convert.ToInt32(output.Substring(nso_i1 + 33, nso_i2));
        //                if (output.Contains("CHOLESKY DECOMPOSITION FAILED"))
        //                {
        //                    for (int k = 0; k < Convert.ToInt16(NSO_post.Text); k++)
        //                    {
        //                        results[i, factor_c, k].not_failure = false;
        //                    }
        //                    //if ((scale_f + batch_inc) < batch_end)
        //                    //    break;//record the last SF
        //                    //else
        //                    //{
        //                    //    results[i, factor_c, 0, 11] = scale_f;
        //                    //    break;
        //                    //}
        //                }
        //                else if (output.Contains("********** MAXIMUM RESPONSE **********"))
        //                {
        //                    factors_m[factor_c]--;
        //                    //List<string> out_list = new List<string>(Regex.Split(output, "\n"));
        //                    int index1 = output.IndexOf("********** MAXIMUM RESPONSE **********");
        //                    int index2 = output.IndexOf("********** MAXIMUM FORCES **********");
        //                    if (index1 == -1 || index2 == -1)
        //                        MessageBox.Show("error"); //Need edit



        //                    // string[] f_list= new string[index2-index1+1];
        //                    char[] f_list = new char[index2 - index1 + 1 - 6];
        //                    output.CopyTo(index1, f_list, 0, index2 - index1 - 6);
        //                    string temp = new string(f_list);
        //                    while (temp.Contains("  "))
        //                    {
        //                        temp = temp.Replace("  ", " ");
        //                    }
        //                    while (temp.Contains("\r"))
        //                    {
        //                        temp = temp.Replace("\r", "");
        //                    }


        //                    List<string> edit_out = new List<string>(Regex.Split(temp, "\n"));

        //                    //  int max_d_i = 0;
        //                    for (int j = 10; j < 10 + (Convert.ToInt16(NSO_post.Text)); j++)
        //                    {
        //                        String[] temp_string = edit_out[j].Split(' ');
        //                        if (temp_string[0] == "")
        //                        {
        //                            temp_string = RemoveIndices(temp_string, 0);
        //                        }

        //                        results[i, factor_c, j - 10].not_failure = true;
        //                        results[i, factor_c, j - 10].story_shear = Convert.ToDecimal(temp_string[1]);
        //                        results[i, factor_c, j - 10].drift_ratio = Convert.ToDecimal(temp_string[2]);
        //                        results[i, factor_c, j - 10].story_drift = Convert.ToDecimal(temp_string[3]);
        //                        results[i, factor_c, j - 10].displacment = Convert.ToDecimal(temp_string[4]);
        //                        results[i, factor_c, j - 10].velocity = Convert.ToDecimal(temp_string[5]);
        //                        results[i, factor_c, j - 10].acceleration = Convert.ToDecimal(temp_string[6]);
        //                        results[i, factor_c, j - 10].story_velocity_drift = Convert.ToDecimal(temp_string[7]);


        //                    }


        //                }


        //            }
        //            //while (factor_c < factors)
        //            //{

        //            //    results[i, factor_c, 0, 11] = scale_f;
        //            //    scale_f += batch_inc;
        //            //    //results[i, factor_c, 0, 8] = 0;
        //            //    //results[i, factor_c, 0, 9] = 0;
        //            //    //results[i, factor_c, 0, 10] = 0;

        //            //    factor_c++;
        //            //}
        //            factor_c++;

        //            //  reader1.Close();
        //        }



        //        Action DoCloseProgressBar = () =>
        //        {
        //            progressWindow.Close();
        //        };
        //        this.Invoke(DoCloseProgressBar);


        //        ExecutionMonitors mon = new ExecutionMonitors(results, factors_m, Convert.ToInt32(NSO_post.Text));
        //        mon.ShowDialog();


        //        //PLOT
        //        String results_t = Helpers.ObjectToString(results);
        //        String batch_t = Helpers.ObjectToString(batch);
        //        String factors_t = Helpers.ObjectToString(factors_m);




        //        plot t = new plot(ref results, ref batch, ref factors_m, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0);


        //        t.Show();



        //    }
        //    else // FEMA 
        //    {

        //        if (Directory.Exists(Var.pp + @"\IDARC_BATCH"))
        //            Directory.Delete(Var.pp + @"\IDARC_BATCH", true);

        //        decimal batch_start = FEMA.start.Value;
        //        decimal batch_end = FEMA.end.Value;
        //        decimal batch_inc = FEMA.inc.Value;
        //        int batch_ver = FEMA.IWV.SelectedIndex;

        //        int count = 0;
        //        //String search = Convert.ToString(reader1["textBox46"]);
        //        //dobue
        //        //reader1.Close();
        //        decimal xfactors = ((batch_end - batch_start) / batch_inc);
        //        //if (((batch_end - batch_start) % batch_inc) == 0)
        //        //    xfactors += 1;
        //        int factors = Convert.ToInt16(xfactors);
        //        batch = new object[count, 11];

        //        results_class[, ,] results = new results_class[count, factors, Convert.ToInt16(NSO_post.Text)];
        //        for (int i = 0; i < results.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < results.GetLength(1); j++)
        //            {
        //                for (int k = 0; k < results.GetLength(2); k++)
        //                {
        //                    results[i, j, k] = new results_class();
        //                }
        //            }
        //        }
        //        decimal[] factors_m = new decimal[factors];

        //        decimal scale_f = batch_start;

        //        for (int o = 0; o < factors_m.GetLength(0); o++)
        //        {
        //            factors_m[o] = count;
        //        }

        //        List<WaveFile> Hfiles = new List<WaveFile>();
        //        List<WaveFile> Vfiles = new List<WaveFile>();
        //        List<string> HfilesNames = new List<string>();
        //        List<string> VfilesNames = new List<string>();




        //        double dumpDeltaT = 0;
        //        int kk = 0;


        //        double SF_FEMA = 0;
        //        double PGAonSa = 0;
        //        int nEQ = 0;
        //        //GET Near_Check, SF(N, F)

        //        bool Near_check = FEMA.near_check.Checked;
        //        double SF_N = FEMA.SF_N;
        //        double SF_F = FEMA.SF_F;
        //        double PGAonSa_N = FEMA.PGAonSa_N;
        //        double PGAonSa_F = FEMA.PGAonSa_F;
        //        //ArrayList selected = new ArrayList();
        //        ArrayList normlized = new ArrayList();
        //        Hfiles.Clear();
        //        HfilesNames.Clear();
        //        Vfiles.Clear();
        //        VfilesNames.Clear();


        //        String FEMA_path = Var.pp + @"\FEMA";
        //        int tt = 0;


        //        //GET FILE + Create Normilized factors

        //        if (Near_check) //Near
        //        {
        //            SF_FEMA = SF_N;
        //            PGAonSa = PGAonSa_N;
        //            normlized.AddRange(new double[] { 0.9, 0.96, 1.72, 1.04, 1.63, 1.09, 1.08, 0.77, 0.69, 0.8, 2.79, 0.74, 0.86, 1.08, 0.86, 1.13, 1.99, 1.27, 1.95, 1.15, 1.17, 0.66, 0.77, 1.18, 0.9, 0.78, 0.62, 0.57 });


        //            //*!*
        //            for (int i = 1; i < 29; i++)
        //            {

        //                if (FEMA.checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
        //                {
        //                    //   MessageBox.Show(i + "            1");
        //                    nEQ += 2;
        //                    WaveFile wave = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-1.dat");         //H1
        //                    wave.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-1.dat";
        //                    wave.Header_Lines = 1;
        //                    wave.isTimeAndValues = false;
        //                    wave.Points_Per_Line = 1;
        //                    wave.Prefix_Per_Line = 0;
        //                    double delta_t = 0;
        //                    wave.FEMA_Delta(ref delta_t);
        //                    wave.deltaT = delta_t;
        //                    wave.values = wave.getValues(ref delta_t);
        //                    wave.FEMA_Modify((double)normlized[i - 1]);
        //                    wave.FEMA_max();
        //                    wave.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                    wave.FEMA_max();
        //                    wave.ID = tt;
        //                    Hfiles.Add(wave);
        //                    HfilesNames.Add("HFile_" + tt + ".dat");

        //                    if (System.IO.File.Exists(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat") && batch_ver == 1)
        //                    {
        //                        WaveFile wave3 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat");            //V
        //                        wave3.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat";
        //                        wave3.Header_Lines = 1;
        //                        wave3.isTimeAndValues = false;
        //                        wave3.Points_Per_Line = 1;
        //                        wave3.Prefix_Per_Line = 0;
        //                        double delta_t3 = 0;
        //                        wave3.FEMA_Delta(ref delta_t3);
        //                        wave3.deltaT = delta_t3;
        //                        wave3.values = wave3.getValues(ref delta_t3);
        //                        wave3.FEMA_Modify((double)normlized[i - 1]);
        //                        wave3.FEMA_max();
        //                        wave3.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                        wave3.FEMA_max();
        //                        wave3.ID = tt;
        //                        Vfiles.Add(wave3);
        //                        VfilesNames.Add("VFile_" + tt + ".dat");
        //                    }
        //                    tt++;

        //                    WaveFile wave2 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-2.dat");            //H2
        //                    wave2.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-2.dat";
        //                    wave2.Header_Lines = 1;
        //                    wave2.isTimeAndValues = false;
        //                    wave2.Points_Per_Line = 1;
        //                    wave2.Prefix_Per_Line = 0;
        //                    double delta_t2 = 0;
        //                    wave2.FEMA_Delta(ref delta_t2);
        //                    wave2.deltaT = delta_t2;
        //                    wave2.values = wave2.getValues(ref delta_t2);
        //                    wave2.FEMA_Modify((double)normlized[i - 1]);
        //                    wave2.FEMA_max();
        //                    wave2.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                    wave2.FEMA_max();
        //                    wave2.ID = tt;
        //                    Hfiles.Add(wave2);
        //                    HfilesNames.Add("HFile_" + tt + ".dat");
        //                    if (System.IO.File.Exists(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat") && batch_ver == 1)
        //                    {
        //                        WaveFile wave4 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat");            //V
        //                        wave4.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat";
        //                        wave4.Header_Lines = 1;
        //                        wave4.isTimeAndValues = false;
        //                        wave4.Points_Per_Line = 1;
        //                        wave4.Prefix_Per_Line = 0;
        //                        double delta_t4 = 0;
        //                        wave4.FEMA_Delta(ref delta_t4);
        //                        wave4.deltaT = delta_t4;
        //                        wave4.getValues(ref delta_t4);
        //                        wave4.values = wave4.FEMA_Modify((double)normlized[i - 1]);
        //                        wave4.FEMA_max();
        //                        wave4.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                        wave4.FEMA_max();
        //                        wave4.ID = tt;
        //                        Vfiles.Add(wave4);
        //                        VfilesNames.Add("VFile_" + tt + ".dat");
        //                    }
        //                    tt++;


        //                }

        //            }




        //        }
        //        else //FAR
        //        {

        //            SF_FEMA = SF_F;
        //            PGAonSa = PGAonSa_F;
        //            normlized.AddRange(new double[] { 0.65, 0.83, 0.63, 1.09, 1.31, 1.01, 1.03, 1.1, 0.69, 1.36, 0.99, 1.15, 1.09, 0.88, 0.79, 0.87, 1.17, 0.82, 0.41, 0.96, 2.1, 1.44 });

        //            for (int i = 1; i < 22; i++)
        //            {
        //                if (FEMA.checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
        //                    {
        //                        nEQ += 2;
        //                        //      MessageBox.Show(i + "         1");
        //                        WaveFile wave = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-1.AT2");         //H1
        //                        wave.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-1.AT2";
        //                        wave.Header_Lines = 1;
        //                        wave.isTimeAndValues = false;
        //                        wave.Points_Per_Line = 1;
        //                        wave.Prefix_Per_Line = 0;
        //                        double delta_t = 0;
        //                        wave.FEMA_Delta(ref delta_t);
        //                        wave.deltaT = delta_t;
        //                        wave.values = wave.getValues(ref delta_t);
        //                        wave.FEMA_Modify((double)normlized[i - 1]);
        //                        wave.FEMA_max();
        //                        wave.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                        wave.FEMA_max();
        //                        wave.ID = tt;
        //                        Hfiles.Add(wave);
        //                        HfilesNames.Add("HFile_" + tt + ".dat");

        //                        if (System.IO.File.Exists(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2") && batch_ver == 1)
        //                        {
        //                            WaveFile wave3 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2");            //V
        //                            wave3.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2";
        //                            wave3.Header_Lines = 1;
        //                            wave3.isTimeAndValues = false;
        //                            wave3.Points_Per_Line = 1;
        //                            wave3.Prefix_Per_Line = 0;
        //                            double delta_t3 = 0;
        //                            wave3.FEMA_Delta(ref delta_t3);
        //                            wave3.deltaT = delta_t3;
        //                            wave3.values = wave3.getValues(ref delta_t3);
        //                            wave3.FEMA_Modify((double)normlized[i - 1]);
        //                            wave3.FEMA_max();
        //                            wave3.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                            wave3.FEMA_max();
        //                            wave3.ID = tt;
        //                            Vfiles.Add(wave3);
        //                            VfilesNames.Add("VFile_" + tt + ".dat");


        //                        }
        //                        tt++;

        //                        WaveFile wave2 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-2.AT2");            //H2
        //                        wave2.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-2.AT2";
        //                        wave2.Header_Lines = 1;
        //                        wave2.isTimeAndValues = false;
        //                        wave2.Points_Per_Line = 1;
        //                        wave2.Prefix_Per_Line = 0;
        //                        double delta_t2 = 0;
        //                        wave2.FEMA_Delta(ref delta_t2);
        //                        wave2.deltaT = delta_t2;
        //                        wave2.values = wave2.getValues(ref delta_t2);
        //                        wave2.FEMA_Modify((double)normlized[i - 1]);
        //                        wave2.FEMA_max();
        //                        wave2.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                        wave2.FEMA_max();
        //                        wave2.ID = tt;
        //                        Hfiles.Add(wave2);
        //                        HfilesNames.Add("HFile_" + tt + ".dat");
        //                        if (System.IO.File.Exists(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2") && batch_ver == 1)
        //                        {
        //                            WaveFile wave4 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2");            //V
        //                            wave4.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2";
        //                            wave4.Header_Lines = 1;
        //                            wave4.isTimeAndValues = false;
        //                            wave4.Points_Per_Line = 1;
        //                            wave4.Prefix_Per_Line = 0;
        //                            double delta_t4 = 0;
        //                            wave4.FEMA_Delta(ref delta_t4);
        //                            wave4.deltaT = delta_t4;
        //                            wave4.getValues(ref delta_t4);
        //                            wave4.values = wave4.FEMA_Modify((double)normlized[i - 1]);
        //                            wave4.FEMA_max();
        //                            wave4.FEMA_Modify((double)SF_FEMA);       // EDIT:20/5
        //                            wave4.FEMA_max();
        //                            wave4.ID = tt;
        //                            Vfiles.Add(wave4);
        //                            VfilesNames.Add("VFile_" + tt + ".dat");

        //                        }
        //                        tt++;



        //                    }

        //                }

        //        }

        //            batch = new object[nEQ, 11];
        //            results = new results_class[nEQ, factors, Convert.ToInt16(NSO_post.Text)];
        //            for (int i = 0; i < results.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < results.GetLength(1); j++)
        //                {
        //                    for (int k = 0; k < results.GetLength(2); k++)
        //                    {
        //                        results[i, j, k] = new results_class();
        //                    }
        //                }
        //            }
        //            count = nEQ;
        //            for (int o = 0; o < factors_m.GetLength(0); o++)
        //            {
        //                factors_m[o] = nEQ;
        //            }
        //            for (int ii = 0; ii < Hfiles.Count; ii++)
        //            {

        //                // batch[ii, 0] = reader1["path_h"];
        //                //batch[ii, 1] = Hfiles[ii].Max * SF_FEMA;              //Max H             (EDIT:20/5)
        //                batch[ii, 1] = PGAonSa_F;                                                        //  (EDIT:20/5)
        //                batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
        //                //batch[ii, 3] = reader1["path_v"];
        //                batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
        //                batch[ii, 6] = batch_end;
        //                batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H

        //                int eI = -1;
        //                for (int l = 0; l < Vfiles.Count; l++)
        //                {
        //                    if (Vfiles[l].ID == Hfiles[ii].ID)
        //                    {
        //                        eI = l;
        //                        break;
        //                    }
        //                }
        //                if (eI != -1)
        //                {

        //                    batch[ii, 5] = VfilesNames[eI];    //Name V
        //                    //   batch[ii, 8] = Vfiles[eI].Max * SF_FEMA;      //Max V               (EDIT:20/5)
        //                    batch[ii, 8] = 1;                                               //(EDIT:20/5)
        //                    batch[ii, 9] = Vfiles[eI].deltaT;   //Delta V (No need- Delta of H should be same as V)
        //                    batch[ii, 10] = Vfiles[eI].values.Count; //Line V (No need- Numer of Lines for H should be same as V)

        //                }
        //                else
        //                {
        //                    batch[ii, 5] = "NONE";    //Name V
        //                }




        //            }




        //        scale_f = batch_start;

        //        scale_f = batch_start;

        //        int factor_c = 0;
        //        Process p = new Process();

        //        for (; scale_f <= batch_end; scale_f += batch_inc)
        //        {



        //            //Do u want to include batch_end?

        //            for (int i = 0; i < count; i++)
        //            {
        //                String path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
        //                if (System.IO.Directory.Exists(path))
        //                    System.IO.Directory.Delete(path, true);
        //                //  System.Threading.Thread.Sleep(100);


        //                System.IO.Directory.CreateDirectory(path);


        //                int hLines = 0, vLines = 0;
        //                //Copy the Eq files
        //                if (i < HfilesNames.Count)
        //                {
        //                    Hfiles[i].writeToFile(path + @"\" + HfilesNames[i], ref hLines);
        //                }
        //                int eI = -1;
        //                for (int l = 0; l < Vfiles.Count; l++)
        //                {
        //                    if (Vfiles[l].ID == Hfiles[i].ID)
        //                    {
        //                        eI = l;
        //                        break;
        //                    }
        //                }

        //                if (eI!=-1)
        //                {
        //                    Vfiles[eI].writeToFile(path + @"\" + VfilesNames[eI], ref vLines);
        //                }


        //                String line = "DYNAMIC ANALYSIS CONTROL PARAMETERS\n";
        //                double val = Convert.ToDouble(batch[i, 1]);
        //                val = val * Convert.ToDouble(scale_f);
        //                line += ""+ val+ ",";

        //                line += (Convert.ToDouble(batch[i, 8]) * Convert.ToDouble(scale_f)) + ",";

        //                line += FEMA.DTCAL.Text + ",";
        //                line += Convert.ToDouble(Hfiles[i].deltaT) * Hfiles[i].values.Count + ",";
        //                line += FEMA.DAMP.Text + ",";
        //                line += (FEMA.ITDMP.SelectedIndex + 1) + "\n";
        //                line += "INPUT WAVE INFORMATION\n";
        //                line += "0,";
        //                if(eI!=-1)
        //                     line += "1" + ",";
        //                else
        //                    line += "0" + ",";
        //                line += Hfiles[i].values.Count + ",";
        //                line += Hfiles[i].deltaT + "\n";
        //                line += "Recorded Table Motion\n";
        //                line += HfilesNames[i] + "";
        //                 eI = -1;
        //                for (int l = 0; l < Vfiles.Count; l++)
        //                {
        //                    if (Vfiles[l].ID == Hfiles[i].ID)
        //                    {
        //                        eI = l;
        //                        break;
        //                    }
        //                }
        //                if(eI!=-1)
        //                     line += "\n" + VfilesNames[eI];

        //                for (int k = 0; k < (Convert.ToInt16(NSO_post.Text)); k++)
        //                {
        //                    results[i, factor_c, k].scale_factor = scale_f;
        //                }



        //                //Run the input file, for loop; until failure.



        //                //Run all the files for specific scale factor



        //                System.IO.File.Copy(Var.pp + @"\idarc2d_7.0.exe", path + @"\idarc2d_7.0.exe", true);
        //                string text = load_input.Text;
        //                text = text.Replace(batch_template, line);
        //                text = text.Replace("\n", "\r\n");
        //                StreamWriter sw = new StreamWriter(path + @"\test.dat");
        //                sw.Write(text);
        //                sw.Flush();
        //                sw.Close();



        //                // temp_in.SaveFile(path + @"\test.dat", RichTextBoxStreamType.PlainText);
        //                System.IO.File.Copy(Var.pp + @"\IDARC.dat", path + @"\IDARC.dat", true);

        //                string[] lines = { "test.dat", "test.out" };
        //                System.IO.File.WriteAllLines(path + @"\IDARC.dat", lines);

        //                // System.Threading.Thread.Sleep(100);
        //                //
        //                //MessageBox.Show(i.ToString());


        //                path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
        //                ProcessStartInfo startInfo = new ProcessStartInfo(path + @"\idarc2d_7.0.exe");
        //                startInfo.WorkingDirectory = path;
        //                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        //                startInfo.UseShellExecute = false;

        //                startInfo.Verb = "runas";
        //                p = new Process();
        //                p.StartInfo = startInfo;
        //                p.Start();
        //                p.WaitForExit();
        //                path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();


        //                //Process.Start(path);
        //                //Process.Start("notepad.exe", path + @"\test.out");

        //                //Reading from the output
        //                /////?? add delay
        //                while (FileInUse(path + @"\test.out"))
        //                {
        //                    System.Threading.Thread.Sleep(100); //test
        //                }

        //                String output = System.IO.File.ReadAllText(path + @"\test.out");
        //                //int nso_i1 = output.IndexOf(" NUMBER OF STORIES ............");
        //                //int nso_i2 = output.IndexOf("NUMBER OF FRAMES");
        //                //if (nso_i1 == -1 || nso_i2 == -1)
        //                //{
        //                //    MessageBox.Show("Can't detect Number of stories");
        //                //    return; 
        //                //}
        //                //int nso = Convert.ToInt32(output.Substring(nso_i1 + 33, nso_i2));
        //                if (output.Contains("CHOLESKY DECOMPOSITION FAILED"))
        //                {
        //                    for (int k = 0; k < Convert.ToInt16(NSO_post.Text); k++)
        //                    {
        //                        results[i, factor_c, k].not_failure = false;
        //                    }
        //                    //if ((scale_f + batch_inc) < batch_end)
        //                    //    break;//record the last SF
        //                    //else
        //                    //{
        //                    //    results[i, factor_c, 0, 11] = scale_f;
        //                    //    break;
        //                    //}
        //                }
        //                else if (output.Contains("********** MAXIMUM RESPONSE **********"))
        //                {
        //                    factors_m[factor_c]--;
        //                    //List<string> out_list = new List<string>(Regex.Split(output, "\n"));
        //                    int index1 = output.IndexOf("********** MAXIMUM RESPONSE **********");
        //                    int index2 = output.IndexOf("********** MAXIMUM FORCES **********");
        //                    if (index1 == -1 || index2 == -1)
        //                        MessageBox.Show("error"); //Need edit

        //                    ///////////READ Damage Index
        //                    int index3 = output.IndexOf("    OVERALL STRUCTURAL DAMAGE :      ");
        //                    int index4 = output.IndexOf("\n", index3);
        //                    char[] damage_list = new char[index4 - index3 - 37];
        //                    output.CopyTo(index3 + 37, damage_list, 0, index4 - index3 - 38);
        //                    string temp_damage = new string(damage_list);
        //                    double damage_index = Convert.ToDouble(temp_damage);
        //                    //double damge_inex= 
        //                    // string[] f_list= new string[index2-index1+1];
        //                    char[] f_list = new char[index2 - index1 + 1 - 6];
        //                    output.CopyTo(index1, f_list, 0, index2 - index1 - 6);
        //                    string temp = new string(f_list);
        //                    while (temp.Contains("  "))
        //                    {
        //                        temp = temp.Replace("  ", " ");
        //                    }
        //                    while (temp.Contains("\r"))
        //                    {
        //                        temp = temp.Replace("\r", "");
        //                    }

        //                    List<string> edit_out = new List<string>(Regex.Split(temp, "\n"));
        //                    //  int max_d_i = 0;
        //                    for (int j = 10; j < 10 + (Convert.ToInt16(NSO_post.Text)); j++)
        //                    {
        //                        String[] temp_string = edit_out[j].Split(' ');
        //                        if (temp_string[0] == "")
        //                        {
        //                            temp_string = RemoveIndices(temp_string, 0);
        //                        }


        //                        results[i, factor_c, j - 10].not_failure = true;
        //                        results[i, factor_c, j - 10].story_shear = Convert.ToDecimal(temp_string[1]);
        //                        results[i, factor_c, j - 10].drift_ratio = Convert.ToDecimal(temp_string[2]);
        //                        results[i, factor_c, j - 10].story_drift = Convert.ToDecimal(temp_string[3]);
        //                        results[i, factor_c, j - 10].displacment = Convert.ToDecimal(temp_string[4]);
        //                        results[i, factor_c, j - 10].velocity = Convert.ToDecimal(temp_string[5]);
        //                        results[i, factor_c, j - 10].acceleration = Convert.ToDecimal(temp_string[6]);
        //                        results[i, factor_c, j - 10].story_velocity_drift = Convert.ToDecimal(temp_string[7]);
        //                        results[i, factor_c, j - 10].damage_index = Convert.ToDecimal(damage_index);

        //                    }


        //                }
        //            }
        //            //while (factor_c < factors)
        //            //{

        //            //    results[i, factor_c, 0, 11] = scale_f;
        //            //    scale_f += batch_inc;
        //            //    //results[i, factor_c, 0, 8] = 0;
        //            //    //results[i, factor_c, 0, 9] = 0;
        //            //    //results[i, factor_c, 0, 10] = 0;

        //            //    factor_c++;
        //            //}
        //            factor_c++;

        //            //  reader1.Close();
        //        }






        //        //PLOT
        //        String results_t = Helpers.ObjectToString(results);
        //        String batch_t = Helpers.ObjectToString(batch);
        //        String factors_t = Helpers.ObjectToString(factors_m);




        //        plot t = new plot(ref results, ref batch, ref factors_m, FEMA.BTOT, Convert.ToDouble(FEMA.c1.Text), Convert.ToDouble(FEMA.c2.Text), Convert.ToDouble(FEMA.c3.Text), Convert.ToDouble(FEMA.c4.Text), Convert.ToDouble(FEMA.c5.Text), Convert.ToDouble(FEMA.mu.Text), FEMA.SSF_value, FEMA.SMT, Convert.ToInt16(chb_isFEMA.Checked), Convert.ToInt16(FEMA.checkBox1.YesNo), Convert.ToInt16(FEMA.checkBox2.YesNo), Convert.ToInt16(FEMA.checkBox3.YesNo), Convert.ToInt16(FEMA.checkBox4.YesNo), Convert.ToInt16(FEMA.checkBox5.YesNo));
        //        t.Show();

        //    }





        //}
        private List<string> split(string str, char ch)
        {
            string[] parts = str.Split(ch);
            List<string> res = new List<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Trim() != String.Empty)
                {
                    res.Add(parts[i]);
                }
            }

            return res;
        }

        //private void btn_batch_example_Click(object sender, EventArgs e)
        //{
        //    WaveBatchExample wvb = new WaveBatchExample();
        //    wvb.ShowDialog();
        //}

        private void wizardPage4_Click(object sender, EventArgs e)
        {

        }

        private void cleanWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure that you want to delete all output files ?", "Deleting", MessageBoxButtons.YesNo);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Directory.Delete(Var.pp + @"\IDARC_Analysis_1", true);
                    MessageBox.Show("Workspace cleaned sucessfuly");
                }
                catch
                {
                    MessageBox.Show("Can't delete some files");
                }
            }

        }

        private void exportOutputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Please choose the destination folder : ";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                try
                {
                    Utilites.BackUpSkipping(Var.pp + @"\IDARC_Analysis_1", fd.SelectedPath + @"\IDARC_Analysis_1", "idarc2d_7.0");
                    MessageBox.Show("Workspace Exported sucessfuly");
                }
                catch
                {
                    MessageBox.Show("Can't copy some files");
                }
            }
        }

        private void button28_Click_1(object sender, EventArgs e)
        {

        }


        private PGA_Sa_Factor_output[] calc_PGAonSa(double T, int typ)
        {

            double[] T_sa = { 0.01, 0.02, 0.022, 0.025, 0.029, 0.03, 0.032, 0.035, 0.036, 0.04, 0.042, 0.044, 0.045, 0.046, 0.048, 0.05, 0.055, 0.06, 0.065, 0.067, 0.07, 0.075, 0.08, 0.085, 0.09, 0.095, 0.1, 0.11, 0.12, 0.13, 0.133, 0.14, 0.15, 0.16, 0.17, 0.18, 0.19, 0.2, 0.22, 0.24, 0.25, 0.26, 0.28, 0.29, 0.3, 0.32, 0.34, 0.35, 0.36, 0.38, 0.4, 0.42, 0.44, 0.45, 0.46, 0.48, 0.5, 0.55, 0.6, 0.65, 0.667, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.2, 2.4, 2.5, 2.6, 2.8, 3, 3.2, 3.4, 3.5, 3.6, 3.8, 4, 4.2, 4.4, 4.6, 4.8, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10, 11, 12, 13, 14, 15, 20 };

            // double[] PGAonSa_FAR = { 1.12728517, 1.101873333, 1.085648428, 1.069900352, 1.04155715, 1.033199911, 1.027824788, 1.022532303, 1.016858432, 0.998696982, 0.98613952, 0.97693505, 0.975746687, 0.973600326, 0.957820009, 0.940659133, 0.908552542, 0.891033733, 0.856671147, 0.845773644, 0.832123985, 0.813654081, 0.78341332, 0.749857577, 0.728713086, 0.713941555, 0.704129378, 0.648294901, 0.583679069, 0.557128111, 0.548412355, 0.548480498, 0.540022298, 0.537239623, 0.521683221, 0.49585988, 0.503623225, 0.493937693, 0.484015418, 0.496222925, 0.491289552, 0.480481334, 0.488945398, 0.492470426, 0.48992809, 0.488154615, 0.48854842, 0.488209635, 0.494433933, 0.505364292, 0.5041819, 0.507417461, 0.50076976, 0.493946597, 0.491597305, 0.500017837, 0.504926291, 0.545492972, 0.612299791, 0.633500584, 0.643522523, 0.678403939, 0.759422835, 0.821084598, 0.845462609, 0.897903424, 0.974112455, 1.042807448, 1.167375659, 1.233659183, 1.342411961, 1.435096532, 1.539819652, 1.69294551, 1.883646094, 2.091343981, 2.234471182, 2.324617621, 2.558419856, 2.869801278, 3.035936833, 3.240695661, 3.733926192, 4.169199371, 4.491438587, 4.882599649, 5.13282308, 5.345590296, 5.707235721, 6.056539222, 6.369639828, 6.568989455, 6.739070328, 7.084701589, 7.418592866, 8.25266449, 9.062764158, 10.18858806, 11.90078878, 13.66499223, 15.65047928, 18.06088155, 20.9659014, 24.29106016, 27.78895003, 35.62580876, 45.47503852, 57.14114499, 70.62466973, 85.14510262, 173.1329988 };


            //  double[] PGAonSa_NEAR = { 1.07728643, 1.010830462, 0.986461199, 0.935904648, 0.884158196, 0.883060099, 0.875718828, 0.887077573, 0.885663894, 0.857146817, 0.83280225, 0.81241195, 0.801745304, 0.791695351, 0.783687781, 0.773129427, 0.769739215, 0.73680321, 0.699880173, 0.695163999, 0.688323714, 0.682384669, 0.686259561, 0.676123852, 0.671543026, 0.664413308, 0.653041882, 0.653924009, 0.650966191, 0.630847841, 0.629685786, 0.62799529, 0.62725386, 0.62400705, 0.61040706, 0.595676746, 0.587813975, 0.588543913, 0.597260738, 0.605691374, 0.600152194, 0.587529235, 0.554734802, 0.549341295, 0.547590036, 0.555177484, 0.570473794, 0.578827798, 0.582809939, 0.596892942, 0.590002288, 0.596149849, 0.612254622, 0.613943823, 0.618473585, 0.636615325, 0.652814626, 0.652260735, 0.652280887, 0.666692144, 0.674535245, 0.676928801, 0.677119091, 0.714577848, 0.75960154, 0.814630994, 0.87267809, 0.935068316, 1.018129903, 1.095908233, 1.208913166, 1.336140035, 1.434801868, 1.515897427, 1.586901132, 1.687933448, 1.771655974, 1.867121272, 2.050864044, 2.268761633, 2.362385931, 2.466002725, 2.719792646, 2.958822334, 3.230859204, 3.518217263, 3.666120205, 3.819273861, 4.173520924, 4.560402375, 4.877519915, 5.176297068, 5.533739337, 5.926415279, 6.359607444, 7.709447251, 9.179656675, 10.86007726, 13.02923118, 15.07993381, 17.4767361, 20.1147159, 22.95528843, 26.28771692, 29.64841219, 37.50707904, 46.84385681, 57.24393065, 68.20158945, 79.2969345, 147.7607778 };

            PGA_Sa_Factor[] PGAonSa_NEAR = new PGA_Sa_Factor[28];
            PGA_Sa_Factor[] PGAonSa_FAR = new PGA_Sa_Factor[22];

            PGA_Sa_Factor_output[] PGAonSa_NEAR_output = new PGA_Sa_Factor_output[28];
            PGA_Sa_Factor_output[] PGAonSa_FAR_output = new PGA_Sa_Factor_output[22];

            for (int j = 0; j < 28; j++)
            {
                PGAonSa_NEAR[j] = new PGA_Sa_Factor();
                PGAonSa_NEAR_output[j] = new PGA_Sa_Factor_output();
            }
            for (int j = 0; j < 22; j++)
            {
                PGAonSa_FAR[j] = new PGA_Sa_Factor();
                PGAonSa_FAR_output[j] = new PGA_Sa_Factor_output();
            }
            //28 EQ (NEAR)
            //H1
            PGAonSa_NEAR[0].Horziantal1 = new List<double>() { 1, 1.724427721, 1.937740593, 2.125126244, 2.342631967, 2.513323159, 2.572117817, 2.263809703, 2.150470683, 1.857797778, 1.738572433, 1.90470383, 2.117778788, 2.335299514, 2.639385197, 2.661914111, 2.901881017, 2.851462633, 2.595441919, 2.316838707, 1.973262159, 1.812026209, 2.180188445, 2.256858769, 2.336369053, 2.51960965, 2.714683768, 2.623444988, 2.117838587, 1.488185341, 1.371883547, 1.170829868, 1.102850676, 1.134511184, 1.27989266, 1.272442751, 1.273153919, 1.383200516, 1.446178165, 1.782634882, 1.916935373, 1.821007339, 1.59417862, 1.602687566, 1.850537127, 1.858887036, 1.552208952, 1.500413027, 1.462682722, 1.243117225, 1.116144257, 1.128554772, 1.245933607, 1.253444817, 1.230960485, 1.162640069, 1.123389904, 1.332886513, 1.432982536, 1.413002512, 1.395851088, 1.422735749, 1.656308139, 1.761183223, 1.646454659, 1.572632439, 1.461059123, 1.302780159, 0.958206946, 0.858643764, 0.894878, 0.796015698, 0.655797589, 0.567555878, 0.585290726, 0.669366807, 0.761031902, 0.834132237, 0.897167114, 0.862007776, 0.823629103, 0.786462504, 0.708130857, 0.626661537, 0.544126321, 0.497572424, 0.473395691, 0.449205454, 0.402010262, 0.357690395, 0.317159569, 0.281671225, 0.25043789, 0.222446823, 0.197296016, 0.145421193, 0.113057039, 0.09857404, 0.086075734, 0.07531456, 0.066068832, 0.058136129, 0.051332745, 0.045498311, 0.040592405, 0.03271498, 0.026723416, 0.022115502, 0.018529266, 0.01570356, 0.007900509 };
            PGAonSa_NEAR[1].Horziantal1 = new List<double>() { 1, 1.008708218, 1.021102924, 1.053162217, 1.033204749, 1.02557931, 1.007283354, 1.009460628, 1.007884345, 0.99439368, 1.029131952, 1.036052427, 1.030372887, 1.01829127, 1.011059756, 1.031045048, 1.04230777, 1.036179537, 1.009682925, 1.024573851, 1.047113062, 1.031088101, 1.089838479, 1.048616125, 1.037396749, 1.064636399, 1.129945252, 1.230718427, 1.258526852, 1.224882489, 1.235045738, 1.198326422, 1.289086596, 1.347353136, 1.28276184, 1.505772822, 1.579967965, 1.589107303, 1.512139753, 1.756612731, 1.513309518, 1.768872711, 2.084608804, 1.867359075, 1.816836884, 2.069159647, 1.859224318, 1.611431246, 1.411444777, 1.197170422, 1.172162522, 1.323105846, 1.383302469, 1.462710006, 1.522750816, 1.578974514, 1.567363849, 1.519561347, 1.807393536, 2.167442458, 2.244285827, 2.313202968, 2.23966915, 2.055715843, 2.026731503, 1.958236988, 1.933136537, 1.929833137, 1.772046951, 1.527803592, 1.306099736, 1.164426667, 1.029332282, 0.878239881, 0.765394755, 0.697179941, 0.62348211, 0.626598359, 0.703875776, 0.713498368, 0.70434585, 0.679218161, 0.616341389, 0.541494001, 0.471607132, 0.409217127, 0.382186887, 0.358036833, 0.319709603, 0.294463298, 0.279311883, 0.270055158, 0.263070835, 0.2560282, 0.247619716, 0.221760294, 0.192279405, 0.162830966, 0.143144501, 0.127269729, 0.114654953, 0.100662408, 0.085719905, 0.076136823, 0.067995329, 0.054463778, 0.043972708, 0.035878339, 0.029606653, 0.02471174, 0.011665638 };
            PGAonSa_NEAR[2].Horziantal1 = new List<double>() { 1, 1.013288611, 1.011650494, 1.041665602, 1.043342921, 1.024978747, 1.021468182, 1.07218417, 1.087247885, 1.130102322, 1.109735761, 1.06465914, 1.067790458, 1.085318616, 1.14896511, 1.180531562, 1.218876443, 1.363128059, 1.486801686, 1.416538416, 1.460437653, 1.517857631, 1.624691559, 1.459809099, 1.409606702, 1.502353884, 1.716969638, 1.775726009, 1.983641297, 2.029823943, 2.121021984, 2.330358236, 2.607449709, 2.456652674, 2.333015165, 2.494373406, 2.614896775, 3.039802845, 2.364375036, 2.370377793, 2.526638888, 2.712601474, 2.724407895, 2.789748446, 2.768096587, 3.199798704, 3.69602782, 3.805062349, 3.8937334, 3.903583243, 3.50478353, 3.089119892, 3.032108673, 3.038572165, 2.965114589, 2.766497232, 2.729589171, 2.455863348, 2.533575006, 2.245202155, 2.066329852, 1.75560391, 1.479983614, 1.37833845, 1.295742394, 1.148685851, 1.105131503, 1.08740249, 1.079353298, 1.313692524, 1.396444948, 1.371019561, 1.36599201, 1.252716613, 1.19010611, 1.201615653, 1.04280158, 0.967908065, 0.816717688, 0.679269609, 0.762836906, 0.834096966, 0.892239758, 0.848258593, 0.694894925, 0.534236155, 0.452587555, 0.407051214, 0.319336428, 0.249143898, 0.211954904, 0.200487779, 0.188960001, 0.177556788, 0.166442173, 0.140638993, 0.132070484, 0.110071048, 0.086705707, 0.077796097, 0.072468451, 0.065310335, 0.057693026, 0.050376824, 0.043727101, 0.032830079, 0.024886688, 0.0192201, 0.015178017, 0.012673755, 0.006366235 };
            PGAonSa_NEAR[3].Horziantal1 = new List<double>() { 1, 1.134507936, 1.146049099, 1.158279697, 1.207351293, 1.215402553, 1.233119528, 1.236267831, 1.242514781, 1.275521736, 1.296490488, 1.294011063, 1.290035899, 1.279110493, 1.253566526, 1.232795482, 1.210733335, 1.173295289, 1.144759845, 1.204013827, 1.280306668, 1.288065755, 1.127014461, 1.097311019, 1.123546037, 1.166289383, 1.142864072, 1.169671194, 1.242626107, 1.465776661, 1.558050994, 1.654157754, 1.960345369, 1.991954745, 1.766821345, 1.58079634, 1.589224075, 1.70415183, 1.567770756, 1.558469967, 1.549853995, 1.783387183, 2.367487036, 2.176344508, 1.920420738, 1.880757099, 2.074687624, 2.047167739, 2.01916883, 2.043453799, 2.056717971, 2.163619642, 2.044554585, 2.048615206, 2.078088143, 2.201669056, 1.888671857, 2.038708593, 2.278002085, 2.596582666, 2.456473794, 2.239096478, 2.2683724, 2.119639933, 2.033226373, 2.080817473, 2.333128466, 2.294172046, 2.196069043, 2.459991413, 2.297434217, 2.510106515, 2.294742534, 2.034775003, 2.126757857, 2.239516606, 2.10884456, 1.831937257, 1.510660372, 1.436890148, 1.352666612, 1.228351456, 1.000387793, 0.875108814, 0.772822315, 0.652864342, 0.592639838, 0.536975767, 0.445542844, 0.378151451, 0.326041491, 0.317450925, 0.32205247, 0.323488619, 0.333215771, 0.309290187, 0.291534409, 0.238689053, 0.170885639, 0.139418237, 0.118180225, 0.097957564, 0.080160466, 0.065345492, 0.053463746, 0.037035934, 0.028521032, 0.024781823, 0.020494093, 0.016676887, 0.010361802 };
            PGAonSa_NEAR[4].Horziantal1 = new List<double>() { 1, 1.003179835, 1.011661207, 1.001890382, 0.995660454, 0.997435467, 1.048919386, 1.052615857, 1.042627307, 1.074784776, 1.061855286, 1.040933868, 1.063612624, 1.086123377, 1.127205437, 1.166786729, 1.322256999, 1.305404962, 1.29174752, 1.375427754, 1.380872046, 1.290194894, 1.217498415, 1.160702275, 1.255931066, 1.511183513, 1.534527293, 1.94200142, 1.82307206, 1.818589371, 1.815844986, 1.719858721, 2.045592135, 2.249556441, 2.150616807, 2.150442005, 1.864593649, 1.869342231, 1.726381928, 1.564435648, 1.3850634, 1.343922683, 1.619593314, 1.595877402, 1.472458943, 1.409802095, 1.287119163, 1.25498403, 1.359801658, 1.366085192, 1.157644413, 0.945243989, 0.837610501, 0.893924383, 0.948145889, 1.139566822, 1.198941674, 1.209498912, 1.266784107, 1.359021461, 1.364368835, 1.222831028, 0.979950842, 0.867243836, 0.922113273, 0.937502998, 0.907086747, 0.869648523, 1.003926238, 0.953190663, 0.852785609, 0.810163352, 0.780626159, 0.739013867, 0.699569114, 0.709605444, 0.618484101, 0.575745116, 0.474741269, 0.355582531, 0.306883589, 0.286075015, 0.246795741, 0.213416215, 0.19257977, 0.169299541, 0.152398132, 0.142580265, 0.124896755, 0.109572329, 0.096397631, 0.089782013, 0.081928663, 0.073930753, 0.066368313, 0.0641575, 0.06006322, 0.056379413, 0.046217459, 0.036382986, 0.028073308, 0.022117022, 0.017282438, 0.014909933, 0.012983756, 0.010763698, 0.009053051, 0.007711527, 0.006643198, 0.005780067, 0.003230566 };
            PGAonSa_NEAR[5].Horziantal1 = new List<double>() { 1, 1.009537616, 1.004846795, 1.013956707, 1.013536479, 1.020381546, 1.039845294, 1.029053957, 1.016721442, 1.038505465, 1.056722711, 1.060926274, 1.062304517, 1.069397079, 1.055887412, 1.060600147, 1.077250176, 1.118120774, 1.150897224, 1.175439279, 1.221194312, 1.180545945, 1.184243946, 1.137998562, 1.199160473, 1.315239406, 1.382003232, 1.261590285, 1.392909552, 1.308096055, 1.331027067, 1.45774523, 1.437153312, 1.387816034, 1.45020769, 1.683280517, 1.802437164, 1.797454505, 1.813514153, 1.911110555, 1.98239376, 1.975223597, 2.092670202, 2.215518922, 2.224273058, 2.0870786, 2.066394902, 2.072051731, 2.058512673, 1.984592864, 1.917817952, 1.882028755, 1.844481821, 1.816639305, 1.782481776, 1.705265115, 1.642044347, 1.678711639, 1.855549786, 1.95457986, 1.971077009, 1.996282663, 2.047154416, 2.122707956, 2.202414271, 2.258960641, 2.278300899, 2.260152488, 2.162657405, 2.039359842, 1.92027306, 1.821011732, 1.742548053, 1.776275042, 1.793217168, 1.775046328, 1.724844361, 1.637338831, 1.440038444, 1.268826704, 1.18094297, 1.088365063, 0.903091688, 0.759705707, 0.651501269, 0.55518308, 0.511715064, 0.471379934, 0.399484435, 0.338235643, 0.286599231, 0.256445618, 0.233386193, 0.212873577, 0.194622765, 0.157204786, 0.128884629, 0.107161655, 0.090264568, 0.076932144, 0.066268087, 0.057631227, 0.050552535, 0.044686572, 0.039777027, 0.032098492, 0.026445995, 0.022168415, 0.01885496, 0.016236557, 0.008801135 };
            PGAonSa_NEAR[6].Horziantal1 = new List<double>() { 1, 1.00700108, 1.025408706, 1.021945714, 1.054937209, 1.044696422, 1.032954698, 1.035178004, 1.024742366, 1.047015397, 1.036175339, 1.027020531, 1.037720932, 1.056838885, 1.067296099, 1.083147417, 1.089071381, 1.187432377, 1.243855804, 1.311910733, 1.442741224, 1.331162824, 1.467124162, 1.403226996, 1.275348202, 1.165594374, 1.234076136, 1.489355379, 1.767299695, 2.052318682, 2.044432662, 1.891547575, 1.47190043, 1.215679381, 1.342027635, 1.682635787, 1.788430548, 1.701617429, 1.498777291, 1.301643353, 1.221976155, 1.239471745, 1.399587552, 1.566141462, 1.578878513, 1.66113848, 1.603664699, 1.552745932, 1.713566045, 1.54734012, 1.384856835, 1.375608532, 1.383593232, 1.39361107, 1.404912079, 1.392409685, 1.570383521, 2.036901221, 2.307036287, 2.419056237, 2.415229468, 2.400705142, 2.312100734, 2.112494951, 1.811730684, 1.450228343, 1.177519742, 1.020788318, 0.769982279, 0.599634049, 0.472452703, 0.394803088, 0.354540566, 0.317915983, 0.334323755, 0.307644254, 0.2501305, 0.226678497, 0.203360465, 0.207686151, 0.220418018, 0.225357526, 0.247183319, 0.236013103, 0.198701441, 0.148017414, 0.122831608, 0.114390874, 0.094199017, 0.07579574, 0.070722562, 0.065462996, 0.060237417, 0.055202791, 0.050439602, 0.040058924, 0.03535342, 0.032435241, 0.03090808, 0.02794864, 0.024327543, 0.022435166, 0.018827099, 0.016133057, 0.014449379, 0.011091056, 0.008943767, 0.007816743, 0.00680357, 0.005924818, 0.003164376 };
            PGAonSa_NEAR[7].Horziantal1 = new List<double>() { 1, 1.051321366, 1.219164879, 1.480226082, 1.835500451, 1.777212939, 1.791104682, 1.918446799, 1.780111561, 2.057077926, 2.234641823, 2.18581045, 2.11932981, 2.148455758, 2.023061581, 2.075572396, 2.153092731, 1.996380832, 2.775714313, 3.031202654, 3.166805022, 3.143261251, 2.793912893, 2.735271958, 2.382137309, 2.261055449, 2.536094422, 3.044506727, 2.353081224, 1.966798721, 1.886544146, 1.882259227, 1.872916787, 1.539262906, 1.270596382, 1.27957033, 1.484852096, 1.740071945, 2.009627371, 1.754655467, 1.987042501, 1.956768612, 1.716624064, 1.559361481, 1.47877814, 0.984653741, 0.865123246, 0.801567393, 0.868633237, 1.03462922, 0.969719946, 0.936968529, 0.995729738, 1.013909551, 0.966093244, 0.834040729, 0.824758699, 0.574299248, 0.797321103, 0.954300947, 0.978474306, 1.020949258, 0.996669872, 0.894385769, 0.734292235, 0.577094857, 0.562744349, 0.649291783, 0.784291413, 0.817960773, 0.771684735, 0.72611349, 0.66813406, 0.594616179, 0.529173482, 0.480121698, 0.453821222, 0.443909332, 0.426082531, 0.42101186, 0.423007197, 0.425666368, 0.4325195, 0.441038929, 0.440746601, 0.441962488, 0.448205895, 0.450641231, 0.444398645, 0.427042529, 0.407688746, 0.390289616, 0.367321459, 0.344707275, 0.322603637, 0.272802951, 0.236237846, 0.207196419, 0.185871409, 0.169590357, 0.155838477, 0.143221936, 0.130259492, 0.117606705, 0.106457092, 0.088166539, 0.072260062, 0.060883409, 0.051529051, 0.044782343, 0.025466834 };
            PGAonSa_NEAR[8].Horziantal1 = new List<double>() { 1, 1.002528036, 0.998870936, 1.003182405, 1.03803248, 1.046838273, 1.050837559, 1.030169373, 1.01940502, 1.007934021, 1.016813115, 1.037663815, 1.05112349, 1.057155205, 1.052118112, 1.067398382, 1.041819477, 1.111304043, 1.113387726, 1.111319498, 1.159365592, 1.195038799, 1.195978644, 1.126426005, 1.211018441, 1.275864354, 1.228639119, 1.206244209, 1.277539483, 1.465244875, 1.368371491, 1.410748625, 1.529264588, 1.581661812, 1.671907412, 1.684308369, 1.707562436, 1.813279684, 1.620134099, 1.767212493, 1.983200749, 1.984490621, 2.04274398, 2.105336309, 2.098773303, 1.968796229, 1.948477615, 2.10395893, 2.162479355, 2.209290921, 2.243065118, 2.219021218, 2.168792342, 2.137123989, 2.110275327, 2.047918243, 1.993942487, 2.005414963, 2.131492873, 2.328118272, 2.364994981, 2.39508253, 2.384516942, 2.354528264, 2.315028626, 2.247720023, 2.172947208, 2.080802598, 1.910424679, 1.717700718, 1.500335083, 1.281390916, 1.109355711, 0.997976207, 0.895520688, 0.801220685, 0.714870159, 0.636872663, 0.503914109, 0.398210953, 0.354618726, 0.315575145, 0.256099079, 0.228792881, 0.204734093, 0.183566777, 0.176688406, 0.170465198, 0.15453056, 0.138375904, 0.132867866, 0.128828463, 0.120899556, 0.110598102, 0.09920895, 0.072434555, 0.058482626, 0.049429939, 0.042295457, 0.036585096, 0.031949908, 0.028139364, 0.024970665, 0.02230971, 0.020053616, 0.016460202, 0.013754868, 0.011667434, 0.010022989, 0.008704342, 0.004849704 };
            PGAonSa_NEAR[9].Horziantal1 = new List<double>() { 1, 1.006299149, 1.012672412, 1.033479804, 0.99720067, 0.990754766, 0.991180602, 0.994420853, 0.993127769, 0.994750108, 1.00697127, 1.009478074, 1.002977732, 0.996248484, 0.987341689, 0.992156235, 1.082752572, 1.100638474, 1.092378876, 1.078735586, 1.014734524, 1.074356877, 1.215080112, 1.265000077, 1.370270596, 1.522073911, 1.663533708, 1.799927262, 1.607829794, 1.459433162, 1.434975262, 1.426629414, 1.346754551, 1.360866802, 1.222394411, 1.379352022, 1.569556105, 1.509754367, 1.431693854, 1.446507413, 1.386144234, 1.405475222, 1.475988923, 1.51819335, 1.739979097, 1.987096387, 1.891533502, 1.809834451, 1.805904042, 1.816378573, 1.8594491, 1.888119605, 1.945355673, 1.975626545, 1.968388821, 2.117436094, 2.199338471, 2.19372079, 2.000712622, 1.689638051, 1.578357302, 1.364270041, 1.401630734, 1.875705285, 1.95621062, 1.718885738, 1.354262665, 1.01094136, 0.685750767, 0.803348538, 0.888586597, 0.838513646, 0.725710089, 0.625921646, 0.627284253, 0.67484876, 0.720648601, 0.736717038, 0.742494755, 0.672949309, 0.634052198, 0.592333456, 0.480071498, 0.430726091, 0.367644749, 0.303074541, 0.272440635, 0.243608125, 0.192437709, 0.150102105, 0.124829313, 0.108632323, 0.094467306, 0.082163158, 0.071660702, 0.051649821, 0.041647069, 0.03403885, 0.028192117, 0.023647583, 0.02006696, 0.017207878, 0.015100936, 0.01391614, 0.012804361, 0.010826284, 0.009175578, 0.007818382, 0.006707619, 0.005797345, 0.003105646 };
            PGAonSa_NEAR[10].Horziantal1 = new List<double>() { 1, 1.010169463, 1.005472558, 1.006058687, 1.018831217, 1.017065564, 1.014351083, 1.017120059, 1.051245131, 1.115913711, 1.110654896, 1.148341551, 1.194860713, 1.248106433, 1.307532547, 1.231634265, 1.219709442, 1.298821747, 1.263200471, 1.294128475, 1.267735101, 1.501209497, 1.798317664, 1.751542374, 1.725201073, 1.56313877, 1.629014728, 1.590285393, 1.63094629, 1.602049757, 1.643600141, 1.680629217, 2.010030197, 1.767486541, 2.070103596, 1.98156115, 2.027925908, 2.40587207, 3.046402904, 2.843751154, 3.323894514, 3.886539192, 4.257840538, 3.699160103, 3.232417184, 2.680684318, 2.248088268, 2.299769363, 2.173530575, 1.84241662, 1.871402768, 2.170717397, 2.320229995, 2.33596163, 2.431394122, 2.488401242, 2.651277949, 3.076135035, 2.461862547, 1.817535193, 1.711529973, 1.594955656, 1.39036871, 1.235619096, 1.540246429, 1.785669868, 1.963158631, 1.798554416, 1.288506358, 1.215216592, 1.211371633, 1.160888228, 1.303541661, 1.326305636, 1.209435227, 1.148907699, 1.021005587, 0.872863853, 0.60006267, 0.51440134, 0.48703504, 0.461383834, 0.41386795, 0.451570953, 0.480092679, 0.460073823, 0.439468778, 0.416941495, 0.396349529, 0.367538251, 0.332056181, 0.29020704, 0.260240337, 0.230595157, 0.201510433, 0.135008989, 0.114375666, 0.097248765, 0.081584038, 0.068119536, 0.056873425, 0.047632868, 0.040095779, 0.035366358, 0.040070771, 0.038826216, 0.031079864, 0.027815464, 0.024907585, 0.020543586, 0.007466305 };
            PGAonSa_NEAR[11].Horziantal1 = new List<double>() { 1, 1.014959171, 1.021908608, 1.027015972, 1.041730634, 1.0456705, 1.053180255, 1.067227523, 1.071215636, 1.083271933, 1.088176484, 1.094253195, 1.096622581, 1.098589617, 1.104582935, 1.113109654, 1.129299308, 1.14933687, 1.166840653, 1.16884611, 1.158920989, 1.197079843, 1.231873133, 1.242156264, 1.247514311, 1.26040315, 1.295012396, 1.303648961, 1.285322714, 1.35457018, 1.411229374, 1.409953289, 1.304739869, 1.367635883, 1.161787079, 1.31426201, 1.253112962, 1.320946026, 1.529189789, 1.241540518, 1.114105076, 1.214115141, 1.51723767, 1.383049683, 1.176239973, 1.033026422, 1.335826969, 1.394690654, 1.335187037, 1.132655299, 0.988456908, 1.002695651, 0.930078086, 0.897243139, 0.886181886, 0.958844801, 0.932037059, 1.086034349, 1.200630207, 1.018642308, 1.02374161, 1.079135552, 1.288213746, 1.133572367, 1.168762088, 1.15593636, 1.400798983, 1.640418319, 1.92742665, 1.440937093, 1.068726451, 0.959013476, 0.894420761, 0.899982755, 0.821788331, 0.76451188, 0.979412827, 0.979164538, 0.729746681, 0.525031867, 0.526851139, 0.506157647, 0.440217925, 0.428955874, 0.392386142, 0.431613734, 0.464750884, 0.494294337, 0.543279761, 0.58948866, 0.589063004, 0.602598956, 0.595274126, 0.567289437, 0.51971073, 0.376911372, 0.293942777, 0.239199727, 0.208309646, 0.180751998, 0.156692059, 0.135194999, 0.1158468, 0.098925632, 0.084546028, 0.062013625, 0.048077854, 0.041892456, 0.035674217, 0.031888665, 0.02011448 };
            PGAonSa_NEAR[12].Horziantal1 = new List<double>() { 1, 1.004364139, 1.004995812, 1.003114939, 1.001500224, 1.003669627, 1.006454582, 1.000102318, 1.003624554, 1.004612202, 1.000171078, 1.008623327, 1.009886016, 1.010663764, 1.011174366, 1.006649348, 1.008871062, 1.039662502, 1.048127253, 1.054741399, 1.049824875, 1.041264057, 1.082075086, 1.134366777, 1.114033477, 1.046317443, 1.014334707, 1.037401967, 1.077000315, 1.093536008, 1.108371448, 1.146124454, 1.109441015, 1.000223389, 1.073805101, 1.059804984, 1.025562699, 1.012197874, 1.027481407, 1.09074875, 1.241756828, 1.231436537, 1.22968792, 1.290172611, 1.254842664, 1.461734746, 1.516781125, 1.64171294, 1.642258416, 1.489625424, 1.586832376, 1.444648313, 1.611163641, 1.712382047, 1.842750529, 2.054922676, 2.068848769, 2.314019923, 2.042825146, 2.579845148, 2.627903312, 2.944563761, 2.93905274, 2.312715781, 1.738406328, 1.412338882, 1.528419376, 1.819206882, 2.193911196, 2.423445146, 2.461706123, 2.092793134, 2.030875664, 1.891774298, 1.827245582, 1.705753754, 1.594020291, 1.533245096, 1.345115027, 1.436567501, 1.473017681, 1.347099534, 1.179637354, 1.035502341, 0.942281512, 0.943033269, 0.930950872, 0.911266025, 0.859095075, 0.80540153, 0.756546537, 0.710422543, 0.663835981, 0.617338247, 0.574148574, 0.486668075, 0.456476724, 0.451262458, 0.454935046, 0.441086925, 0.39470467, 0.351568293, 0.303656566, 0.270089217, 0.245930083, 0.19850652, 0.154536697, 0.114873438, 0.100023161, 0.087149528, 0.039958171 };
            PGAonSa_NEAR[13].Horziantal1 = new List<double>() { 1, 1.00419781, 1.001891462, 1.003237738, 1.010802598, 1.007988399, 1.024317281, 1.012054919, 1.024589009, 1.012587743, 1.000899248, 1.023286496, 1.036055226, 1.046980213, 1.059310321, 1.064237024, 1.048652364, 1.077390474, 1.017855403, 1.032235214, 1.027774825, 1.049177276, 1.078080055, 1.235892783, 1.256601698, 1.357493034, 1.429602496, 1.224715106, 1.24334094, 1.466564882, 1.532148429, 1.631826015, 1.778727355, 1.496074412, 1.427627958, 1.360438028, 1.400604773, 1.359608999, 1.806794676, 2.172065947, 2.169832785, 2.13322273, 2.659665372, 2.863639173, 3.088537739, 3.105570789, 3.360784672, 3.559499467, 3.675830574, 3.737544165, 4.622236673, 4.61997928, 3.985793017, 3.589812313, 3.226658985, 2.841772387, 2.642763364, 2.539862875, 1.907319093, 1.895905046, 2.127480597, 2.398497215, 2.454750043, 2.284515477, 2.043125338, 1.782534263, 1.543382973, 1.308070981, 0.883158322, 0.794130533, 0.736572473, 0.620607295, 0.708407982, 0.726519536, 0.683459967, 0.626226545, 0.568792357, 0.538484704, 0.587912197, 0.563773677, 0.525034306, 0.502781809, 0.51981387, 0.557244795, 0.587962636, 0.590994662, 0.591445151, 0.569312818, 0.473118737, 0.375377613, 0.366056289, 0.359835727, 0.364741414, 0.403968362, 0.420761827, 0.425473916, 0.371992266, 0.319942687, 0.266954548, 0.213188684, 0.183239543, 0.160786181, 0.138692122, 0.118162092, 0.101008285, 0.07341331, 0.05258302, 0.041736288, 0.03473946, 0.029160933, 0.013796078 };
            PGAonSa_NEAR[14].Horziantal1 = new List<double>() { 1, 1.264279981, 1.393079683, 1.661751013, 1.838569048, 1.885410645, 1.666924976, 2.026424141, 1.975725065, 1.681944433, 2.058184506, 2.462702231, 2.551954129, 2.493419292, 2.503176929, 2.668025799, 2.456627732, 2.561548406, 3.027012921, 3.333075711, 3.754840895, 3.765037818, 2.883964983, 2.671434382, 2.398475898, 2.087963966, 2.21742699, 2.364096291, 2.170700706, 1.620274194, 1.601776142, 1.569554527, 1.704433122, 1.926074785, 1.924189974, 1.866568029, 1.856706062, 1.676799298, 1.601292928, 1.397762196, 1.405234173, 1.597517815, 2.028222467, 1.960374771, 2.022397811, 1.93062963, 1.815026074, 1.859619076, 1.819645439, 1.655450006, 1.544754097, 1.326977737, 1.190307405, 1.180192163, 1.175723116, 1.14966674, 1.159040413, 1.237511138, 1.40576818, 1.618466258, 1.646264814, 1.522104794, 1.351133515, 1.282256792, 1.23566504, 1.155955666, 1.101563157, 1.075247054, 1.195604781, 0.796173573, 0.555346513, 0.667196784, 0.743584745, 0.735763398, 0.631193467, 0.491313466, 0.344729003, 0.276695983, 0.23068999, 0.210769751, 0.203057951, 0.206028347, 0.212194959, 0.227915351, 0.251175398, 0.257649922, 0.263796355, 0.275804233, 0.283513699, 0.278417297, 0.259223115, 0.237361369, 0.211869887, 0.186473813, 0.164869187, 0.121329468, 0.102862249, 0.085103159, 0.068701516, 0.054695588, 0.043326761, 0.035092568, 0.030356339, 0.026353731, 0.023047584, 0.017840001, 0.014070174, 0.011322826, 0.009293215, 0.007767315, 0.003890164 };
            PGAonSa_NEAR[15].Horziantal1 = new List<double>() { 1, 1.182698923, 1.305624035, 1.546956015, 1.745239529, 1.752275066, 1.788900176, 1.759064409, 1.73105775, 1.618350525, 1.447405311, 1.433540445, 1.421992283, 1.398532947, 1.438627578, 1.407973917, 1.490705094, 1.513781424, 1.379122762, 1.349706351, 1.317064466, 1.26066335, 1.423060171, 1.63796824, 1.862809668, 1.722252588, 1.588006012, 2.144417868, 2.436969319, 2.535726253, 2.313277371, 2.217225269, 1.738719512, 1.751835552, 1.904611466, 1.937512268, 1.996484875, 1.945385527, 1.795135995, 1.694062522, 1.672739458, 1.561130359, 1.576424638, 1.738783952, 1.9302041, 2.045646063, 2.02820758, 1.856406965, 1.895226343, 2.2798627, 2.638265325, 2.985164567, 2.96532032, 2.786510605, 2.57586087, 2.519479086, 2.330135893, 2.437922702, 2.125143668, 2.007913905, 1.812534822, 1.853655869, 1.67983613, 1.677047031, 1.783089001, 1.401845333, 0.863093535, 0.707586682, 0.602449352, 0.434975642, 0.337909847, 0.311633487, 0.34036138, 0.382747766, 0.362533071, 0.397621532, 0.417890753, 0.404830397, 0.31197155, 0.283659874, 0.269520889, 0.253037277, 0.217117538, 0.181830799, 0.151128561, 0.127017735, 0.116200374, 0.109913862, 0.098871588, 0.088195168, 0.080482432, 0.076617678, 0.070908781, 0.064239974, 0.064310329, 0.063687259, 0.061291872, 0.055406078, 0.05051068, 0.042495372, 0.037236663, 0.030676082, 0.025651671, 0.022384327, 0.019554035, 0.01506945, 0.012077298, 0.009659059, 0.008196649, 0.007057678, 0.003776933 };
            PGAonSa_NEAR[16].Horziantal1 = new List<double>() { 1, 0.991247002, 0.989592438, 1.003021313, 1.03670657, 1.056469924, 1.069662013, 1.019577229, 1.034848261, 1.087987765, 1.105484216, 1.083092356, 1.051667027, 1.046129543, 1.028962757, 1.037550188, 1.202335479, 1.116569095, 1.273291921, 1.285217848, 1.379725116, 1.435109496, 1.579143173, 1.53662085, 1.483341844, 1.506852654, 1.445979249, 1.710160607, 1.56295657, 1.611622842, 1.711308926, 1.807814005, 1.43496669, 1.508179756, 1.629524582, 1.81459342, 2.122843001, 2.136952864, 2.145998081, 2.949062787, 3.075908753, 3.038837275, 2.678830726, 2.351183066, 2.036412882, 1.707392966, 1.477667062, 1.695800375, 1.88640376, 2.005471771, 2.108971392, 2.047585501, 1.874963886, 1.821650004, 1.76421862, 1.716471591, 1.829691543, 2.176438088, 2.774814509, 2.88255645, 2.843988633, 2.541020661, 1.739221382, 1.866257511, 1.536564315, 1.242769314, 1.121389613, 1.030178625, 0.98277521, 0.805516632, 0.849870098, 0.742134398, 0.725874006, 0.543206432, 0.479894684, 0.513438236, 0.578418499, 0.437591158, 0.328640141, 0.250732623, 0.251398413, 0.273045076, 0.247424376, 0.188585456, 0.187093669, 0.183603887, 0.156957152, 0.130111737, 0.135939348, 0.145309127, 0.15513012, 0.147306387, 0.142003927, 0.130653077, 0.124084346, 0.090270967, 0.068241482, 0.051203588, 0.035421723, 0.03793011, 0.035501753, 0.034955457, 0.035134606, 0.029437246, 0.022922333, 0.015462589, 0.01089211, 0.009388134, 0.007205483, 0.006938925, 0.003727486 };
            PGAonSa_NEAR[17].Horziantal1 = new List<double>() { 1, 0.973636798, 0.968841104, 1.105965634, 1.250101338, 1.293099261, 1.421579355, 1.341291461, 1.448027182, 1.814904141, 1.755016777, 1.587333342, 1.569711048, 1.570523447, 1.468459869, 1.4736533, 1.158752967, 1.522219542, 2.037810415, 2.21029039, 2.247009144, 2.223544346, 1.970940648, 2.038892768, 2.132556477, 2.268664661, 2.145869669, 1.986589489, 1.634901856, 1.888569289, 1.853097061, 1.80905402, 1.897459137, 1.887956604, 2.429582334, 2.677552817, 2.622233506, 2.424753636, 1.822533924, 1.200181944, 1.048756648, 0.975564554, 1.097874645, 1.116227252, 1.036425105, 1.119966827, 1.087677342, 0.905410494, 0.818283468, 0.72858706, 0.732711679, 0.674068639, 0.614972772, 0.625498504, 0.648519952, 0.606896846, 0.501698084, 0.480287555, 0.602366113, 0.469984217, 0.499420996, 0.450718931, 0.385158481, 0.483634217, 0.456924307, 0.344618574, 0.336452185, 0.348625649, 0.256967804, 0.308252453, 0.194225872, 0.162332432, 0.179878479, 0.152584911, 0.120183975, 0.083199279, 0.075312879, 0.07131315, 0.064635364, 0.06556331, 0.063103991, 0.058651062, 0.062822275, 0.076514147, 0.07353992, 0.078292083, 0.078874912, 0.07669329, 0.066114997, 0.050310159, 0.040095322, 0.034987869, 0.031052895, 0.026895315, 0.022900612, 0.014952496, 0.011028794, 0.008573275, 0.006750454, 0.005889818, 0.005151, 0.004521907, 0.003987586, 0.003533471, 0.003146482, 0.002531208, 0.002073116, 0.001725418, 0.00145664, 0.001245222, 0.000655192 };
            PGAonSa_NEAR[18].Horziantal1 = new List<double>() { 1, 1.479814674, 1.359935268, 1.688205272, 2.00308753, 2.045613752, 1.958777891, 2.049475029, 2.130185399, 2.20340057, 2.453032472, 2.536340632, 2.583443733, 2.615726018, 2.691604202, 2.764659107, 2.386390044, 2.046277176, 2.053299034, 1.820124146, 1.6456975, 1.371545933, 1.339836131, 1.363836238, 1.319704754, 1.27535393, 1.229781922, 0.952944233, 0.745839484, 0.635226955, 0.657539245, 0.732390986, 0.753371023, 0.714880693, 0.684988225, 0.697409721, 0.753839333, 0.778039959, 0.786347294, 1.093527871, 1.235962573, 1.327225112, 1.35402539, 1.304345744, 1.231492102, 1.111296452, 1.053352518, 1.026940417, 1.003836491, 0.912229569, 0.865510918, 0.927348367, 0.981283058, 1.041409209, 1.101688731, 1.201983153, 1.265553891, 1.261187033, 1.107693649, 0.901883882, 0.832634906, 0.703882204, 0.532004522, 0.40876793, 0.333852456, 0.294586144, 0.272416975, 0.254508814, 0.264365691, 0.187133451, 0.193562328, 0.184126352, 0.171158687, 0.179187235, 0.185223815, 0.187368445, 0.179243216, 0.164188393, 0.131823069, 0.114394604, 0.105514507, 0.098267029, 0.08494296, 0.071097935, 0.061546922, 0.05518027, 0.052190296, 0.049344431, 0.044100176, 0.03944745, 0.035344974, 0.031732612, 0.02855209, 0.025751584, 0.0232851, 0.018317247, 0.01465388, 0.011913864, 0.009831943, 0.008225153, 0.00696625, 0.00596584, 0.00516032, 0.004503791, 0.003962691, 0.003133392, 0.002537876, 0.002096886, 0.001761689, 0.001501146, 0.000785617 };
            PGAonSa_NEAR[19].Horziantal1 = new List<double>() { 1, 1.497542015, 1.672799377, 1.491938902, 1.266881343, 1.236149656, 1.308780568, 1.483992579, 1.468296597, 1.50397069, 1.536323623, 1.644806594, 1.676113444, 1.639975738, 1.554302419, 1.54238691, 1.628738131, 1.811594913, 1.78953925, 1.847634824, 1.951498219, 2.085066346, 1.74536108, 1.902433525, 2.435418795, 2.228645882, 2.032432029, 1.717387641, 2.158723567, 3.18781015, 3.361175878, 3.014214442, 2.620141633, 2.275619698, 2.277029664, 2.248007132, 2.300257577, 1.919888097, 2.206840832, 2.235405555, 2.248662681, 2.526030651, 2.738565943, 2.857093422, 2.96573179, 2.849069938, 2.890259881, 3.384898139, 3.825590123, 3.724586209, 4.075515326, 4.048925846, 3.594609198, 3.459349111, 3.273012119, 3.069574981, 3.237612496, 3.484103055, 2.924146368, 3.178030655, 3.148872714, 2.75263552, 2.220721267, 2.343252965, 2.331493929, 2.05467232, 1.54933508, 1.336104907, 1.02720548, 1.029357184, 0.9384427, 0.757112594, 0.567373627, 0.443526963, 0.374890599, 0.33692273, 0.317344396, 0.281040332, 0.242451305, 0.25118665, 0.254940257, 0.250396768, 0.21000582, 0.1888333, 0.176233141, 0.173842882, 0.165892711, 0.154315251, 0.124923118, 0.094120374, 0.081512907, 0.072228835, 0.065278473, 0.05830105, 0.051680074, 0.037786249, 0.02790019, 0.021184063, 0.016633094, 0.013503527, 0.011396766, 0.010152986, 0.009069138, 0.008106943, 0.007270807, 0.005930716, 0.004933143, 0.004175758, 0.003586861, 0.003118563, 0.001754742 };
            PGAonSa_NEAR[20].Horziantal1 = new List<double>() { 1, 1.002805036, 1.022590273, 1.024678029, 1.032144761, 1.025226127, 1.000402289, 1.024451577, 1.036193968, 1.037778669, 1.029167294, 1.026730804, 1.03671405, 1.053186243, 1.086282165, 1.118601216, 1.16024273, 1.204258973, 1.217317202, 1.215268761, 1.205541841, 1.223133139, 1.1946791, 1.207843203, 1.242161007, 1.269003722, 1.357678108, 1.222528544, 1.145869437, 1.337659298, 1.341485613, 1.407644643, 1.46812209, 1.572833721, 1.699136169, 1.713508068, 1.690607449, 1.585776943, 2.096608572, 2.623389372, 2.860941311, 3.05007148, 3.302849738, 3.345838511, 3.350166333, 3.19483528, 2.796531675, 2.565689718, 2.534334676, 2.537554229, 2.575419579, 2.575031066, 2.53003162, 2.493029977, 2.44865432, 2.344990902, 2.231043488, 1.924757187, 1.678702842, 1.462651327, 1.393179253, 1.681835715, 1.601421185, 0.943537862, 0.865219911, 0.788801961, 0.7017163, 0.612558981, 0.63415336, 0.392348515, 0.419199898, 0.385401091, 0.288541765, 0.276795505, 0.300284621, 0.291562728, 0.262036795, 0.26600381, 0.262404102, 0.216855784, 0.191621454, 0.17013945, 0.132614243, 0.10848651, 0.094702473, 0.08545488, 0.081216245, 0.076874415, 0.06752508, 0.057428128, 0.048840512, 0.043579251, 0.037737094, 0.034648103, 0.032805946, 0.027893527, 0.023237465, 0.018559269, 0.014475436, 0.012999518, 0.011623097, 0.010361621, 0.009230861, 0.008231143, 0.007353366, 0.005915867, 0.00481899, 0.003976876, 0.003323523, 0.002810561, 0.001405211 };
            PGAonSa_NEAR[21].Horziantal1 = new List<double>() { 1, 1.009767232, 1.059812343, 1.168227153, 1.274264553, 1.281244087, 1.301275808, 1.314108246, 1.314301439, 1.246463262, 1.30730066, 1.380840372, 1.413193995, 1.437703691, 1.475416943, 1.494462779, 1.566512045, 1.62238616, 1.707399979, 1.702356365, 1.657347565, 1.651677233, 1.735749648, 1.821257405, 1.874367722, 1.844842295, 1.801993147, 1.760005072, 1.974554211, 2.110784253, 2.108214977, 2.065773462, 1.96433885, 1.805684407, 1.711881274, 1.780841435, 1.742668103, 1.792316205, 1.953636853, 2.070822387, 2.153010667, 2.14139515, 2.060782959, 1.923429605, 1.827602255, 1.625985802, 1.456909526, 1.352611533, 1.280486582, 1.161290108, 1.018410488, 0.890834324, 0.895601094, 0.945532016, 1.003399809, 1.06597263, 1.040143773, 0.814592557, 0.800600294, 0.815603006, 0.806343655, 0.762692521, 0.6849145, 0.623629105, 0.588866538, 0.563895168, 0.533699936, 0.494713665, 0.416443697, 0.372774904, 0.347288949, 0.32054219, 0.29182718, 0.259777688, 0.227472994, 0.198275465, 0.174420569, 0.155484275, 0.130516358, 0.123783262, 0.123748407, 0.124972565, 0.126212854, 0.123357771, 0.132414104, 0.135957115, 0.133829529, 0.131650956, 0.122425795, 0.11370068, 0.104887466, 0.096072062, 0.088207953, 0.083037535, 0.077530388, 0.063623257, 0.050263507, 0.039203923, 0.030190432, 0.024051881, 0.020887608, 0.018210038, 0.016018266, 0.014148039, 0.012542979, 0.009972183, 0.008052416, 0.006598159, 0.005482655, 0.004615369, 0.002274407 };
            PGAonSa_NEAR[22].Horziantal1 = new List<double>() { 1, 1.001904684, 1.002500479, 1.008110915, 1.022278748, 1.026619085, 1.037324664, 1.059941494, 1.071122912, 1.079170064, 1.067586401, 1.062581191, 1.059410658, 1.052635599, 1.057185427, 1.053705905, 1.069972636, 1.17957899, 1.213670951, 1.228031006, 1.235765315, 1.29272159, 1.324115005, 1.287562949, 1.310565418, 1.387559402, 1.370894411, 1.412701021, 1.413937777, 1.430650591, 1.436388024, 1.412873715, 1.396989834, 1.710574611, 2.161997259, 2.292167508, 2.283619144, 2.07942419, 1.899835502, 2.065962012, 1.709612837, 1.528392853, 1.579040078, 1.616056416, 1.663429093, 1.731048173, 1.734467518, 1.713664509, 1.68135608, 1.62795239, 1.647897242, 1.692423122, 1.70235968, 1.696939739, 1.72048593, 1.80631362, 1.885719744, 2.096478407, 2.261632516, 2.325153429, 2.327200519, 2.308093898, 2.223928057, 2.093861425, 1.942544107, 1.792718601, 1.650333559, 1.506528439, 1.217612497, 1.034547741, 0.863233497, 0.720078903, 0.606482914, 0.516626799, 0.525288609, 0.490551037, 0.366678281, 0.32916113, 0.264851403, 0.193725568, 0.183360196, 0.173497099, 0.155060797, 0.138304146, 0.123209118, 0.109731943, 0.10357465, 0.097783018, 0.087269156, 0.078022032, 0.069928001, 0.066498733, 0.059867328, 0.051264407, 0.04635859, 0.0367078, 0.029578, 0.024223338, 0.020133846, 0.016958465, 0.014455023, 0.012453218, 0.01083154, 0.009502153, 0.008400484, 0.006699007, 0.005465214, 0.004543558, 0.003837557, 0.003402182, 0.001958087 };
            PGAonSa_NEAR[23].Horziantal1 = new List<double>() { 1, 1.018682125, 1.01800532, 1.031579726, 1.072101345, 1.084441374, 1.121168563, 1.096484185, 1.067457309, 1.000108577, 1.055093664, 1.083522359, 1.057215952, 1.073313546, 1.107499116, 1.20155717, 1.28260559, 1.32091708, 1.564915978, 1.606689542, 1.62045547, 1.803996088, 1.784065761, 1.805840742, 1.84183295, 2.046781057, 2.309819204, 1.755994189, 1.68834795, 1.990775002, 2.011659192, 2.082663536, 2.522906253, 2.775518721, 2.918343319, 2.854683319, 3.078440848, 2.997716719, 2.675309516, 2.890090306, 2.775678562, 2.559896388, 2.529279453, 2.740546617, 2.84928299, 3.421140396, 3.648126431, 3.296475775, 2.80938, 2.226571887, 2.345352912, 2.460392501, 2.218326097, 2.239020205, 2.277977683, 2.1482808, 1.989234767, 1.942388045, 1.594015718, 1.779199677, 1.658092746, 1.405615351, 1.387411598, 1.133036269, 1.181229977, 0.996609926, 0.794985652, 0.88618154, 1.187632553, 1.216979687, 1.316272756, 1.282678455, 1.011084916, 0.82518988, 0.705703825, 0.6042781, 0.56864935, 0.522699179, 0.43985449, 0.478199675, 0.518724173, 0.447844822, 0.32368046, 0.309623938, 0.242481703, 0.225099217, 0.200308393, 0.189510759, 0.156819229, 0.123076376, 0.109800368, 0.099679223, 0.119120954, 0.133829484, 0.131714598, 0.104749732, 0.068810344, 0.044856425, 0.037612047, 0.030599108, 0.024697569, 0.020035995, 0.017075073, 0.015131721, 0.013199802, 0.010249652, 0.008399699, 0.00712503, 0.006118376, 0.005271073, 0.002693368 };
            PGAonSa_NEAR[24].Horziantal1 = new List<double>() { 1, 1.009366235, 1.019669931, 1.012963511, 1.020550068, 1.021052752, 1.025430952, 1.022160861, 1.046357593, 1.039609723, 1.030559209, 1.038894501, 1.04341601, 1.038303627, 1.024212605, 1.025035419, 1.020477752, 1.057421047, 1.086375636, 1.09870065, 1.140600231, 1.148393153, 1.172428056, 1.200459294, 1.201896794, 1.233789438, 1.390005499, 1.55639782, 1.670800286, 1.478413477, 1.422469174, 1.43733671, 1.657351729, 1.739915787, 2.01163669, 2.102963321, 1.949348429, 1.927844143, 2.100675669, 2.504479839, 2.513462888, 2.707192392, 2.692870312, 2.757268963, 2.617044863, 2.612046245, 2.502025507, 2.633041233, 2.674481784, 2.360359498, 2.516068025, 2.639872442, 2.912846968, 3.061506455, 2.951924022, 2.599532945, 3.096024079, 3.393524286, 3.202630095, 3.019849398, 3.053620933, 3.133469176, 2.888129915, 2.778651546, 2.527266851, 2.049492311, 1.587908601, 1.456711645, 1.585088721, 1.781503175, 2.006633663, 1.326878549, 1.017237646, 0.961761193, 0.944430506, 1.012978944, 1.0600522, 1.059400034, 1.064923383, 1.152688896, 1.192879351, 1.227418141, 1.264349529, 1.269242319, 1.253003426, 1.290687076, 1.330562252, 1.334218174, 1.355874147, 1.323343447, 1.269713695, 1.208669356, 1.157118687, 1.095962346, 1.0270951, 0.831002982, 0.640439504, 0.554944447, 0.498749684, 0.437061778, 0.375295602, 0.317410808, 0.26089274, 0.216858737, 0.200530376, 0.165787381, 0.133041277, 0.105223723, 0.083877253, 0.071602243, 0.036028983 };
            PGAonSa_NEAR[25].Horziantal1 = new List<double>() { 1, 1.006321808, 1.000450227, 1.029135992, 1.055926717, 1.061940295, 1.054872649, 1.043809235, 1.041864325, 1.081319695, 1.096739778, 1.103721705, 1.109828213, 1.118570192, 1.118418781, 1.093155985, 1.055639517, 1.03687898, 1.076654595, 1.057145816, 1.020003469, 1.104258653, 1.172587449, 1.147385938, 1.199433851, 1.264122175, 1.325704371, 1.348696204, 1.152241703, 1.117494093, 1.105886922, 1.193474348, 1.16383866, 1.257903711, 1.23541518, 1.349328685, 1.536802273, 1.68201999, 1.546696057, 1.675669943, 1.63179001, 1.791345703, 1.726499559, 1.776645422, 1.793579815, 1.842914749, 2.408940135, 2.488681231, 2.378671966, 2.057390356, 2.176572401, 1.722872706, 1.390745587, 1.552863449, 1.679568575, 1.783164705, 1.698562437, 1.691038154, 1.61509475, 1.452008338, 1.536296969, 1.757552622, 2.202138019, 1.888392108, 1.697451089, 1.604643389, 1.497376144, 1.767336253, 1.877023469, 1.546825237, 1.038172582, 0.980946254, 1.030160219, 1.185783634, 1.197663985, 1.132147908, 1.065086679, 1.004907237, 1.116945328, 0.905065337, 0.809268673, 0.696508375, 0.50953188, 0.384377114, 0.313341948, 0.283437886, 0.277551685, 0.2744762, 0.270826716, 0.264447228, 0.259538589, 0.262716817, 0.239135363, 0.212497051, 0.206625871, 0.178598463, 0.143092096, 0.153403702, 0.15177978, 0.164673363, 0.166607878, 0.148662777, 0.149875446, 0.147862522, 0.138535107, 0.108999799, 0.098290899, 0.087728403, 0.076294894, 0.065385675, 0.033102699 };
            PGAonSa_NEAR[26].Horziantal1 = new List<double>() { 1, 1.002460272, 1.003142965, 1.004169482, 1.006818015, 1.008031802, 1.010349392, 1.012763095, 1.013707371, 1.016454989, 1.022487263, 1.026661699, 1.028554216, 1.031039259, 1.041389642, 1.056820096, 1.070188598, 1.080168404, 1.110813307, 1.12132718, 1.126740174, 1.13973909, 1.159009074, 1.168850162, 1.185718334, 1.185727252, 1.217092499, 1.112614666, 1.132698135, 1.195729848, 1.231449866, 1.402786062, 1.469324381, 1.378154608, 1.638459907, 1.88272241, 1.832015838, 1.623246449, 1.751134024, 1.874527118, 1.755523474, 1.656533939, 1.606359451, 1.623844921, 1.73358514, 1.626836286, 1.484988675, 1.420881893, 1.504105077, 1.832233824, 2.002897235, 2.139599381, 2.338390944, 2.467845047, 2.482579927, 2.242698947, 1.828070287, 2.017488442, 1.763836677, 1.806130962, 1.898282665, 1.938402042, 2.27444468, 2.831091378, 3.290945248, 3.476715106, 3.162425513, 2.566922767, 2.320564624, 2.203806238, 1.727741127, 1.432159709, 1.428355849, 1.543335665, 1.511797019, 1.420842259, 1.340856171, 1.185989826, 0.782924444, 0.478797271, 0.398418014, 0.36619836, 0.317765086, 0.319491934, 0.315234068, 0.255803091, 0.237359275, 0.208437257, 0.142729762, 0.108419322, 0.104671346, 0.099861182, 0.104214665, 0.099128749, 0.087031335, 0.057335118, 0.047179872, 0.041711787, 0.035556014, 0.029414667, 0.024999049, 0.021606955, 0.018846882, 0.016777351, 0.015153007, 0.012344492, 0.01018725, 0.008681371, 0.00745506, 0.006396331, 0.003576025 };
            PGAonSa_NEAR[27].Horziantal1 = new List<double>() { 1, 1.001356268, 1.001465107, 1.001921205, 1.003782579, 1.003482221, 1.002935024, 1.001537866, 1.005566082, 1.020505178, 1.025757072, 1.040471275, 1.045733693, 1.050677413, 1.058730237, 1.068762894, 1.094958626, 1.109175542, 1.076790464, 1.064468596, 1.059779533, 1.068236142, 1.069486879, 1.073814851, 1.085202274, 1.101294994, 1.032107871, 1.030977397, 1.221133974, 1.360144412, 1.432136374, 1.49153347, 1.407152294, 1.535597609, 1.589802341, 1.521372576, 1.561858884, 1.746537472, 1.848657772, 1.948400169, 2.040797489, 2.057917859, 1.852026044, 1.627179545, 1.80023319, 2.095580688, 1.954846277, 1.947213471, 1.936902104, 2.085408224, 2.289649427, 2.115615035, 1.946173796, 1.923929312, 1.88254133, 1.781550301, 1.768693863, 1.964491987, 2.370105814, 2.541598442, 2.60034732, 2.688387806, 2.772675177, 2.824060038, 2.85839789, 2.955180909, 2.968936615, 2.900754892, 2.677371395, 2.342595605, 2.170932503, 2.136499643, 2.114894057, 2.028720959, 1.913529851, 1.800899449, 1.737889345, 1.678752017, 1.844636171, 1.770227821, 1.675213873, 1.587694729, 1.389722246, 1.172507951, 1.036207644, 0.910522369, 0.849660768, 0.790469622, 0.677928214, 0.580750731, 0.605550808, 0.627515981, 0.603022876, 0.544057825, 0.465377124, 0.304161588, 0.25265902, 0.209681429, 0.175780944, 0.198223712, 0.196344931, 0.176626094, 0.152868007, 0.127467936, 0.118772155, 0.09433882, 0.070289155, 0.051913568, 0.042290256, 0.035755454, 0.018264824 };


            //H2
            PGAonSa_NEAR[0].Horziantal2 = new List<double>() { 1, 1.36648111656965, 1.48980685233784, 1.45764791165887, 1.49531931368095, 1.37732198785261, 1.34628507413994, 1.13273782774605, 1.14511290368663, 1.0427209663341, 1.20167515569619, 1.36837190697852, 1.43058703981335, 1.49033641540069, 1.49185068669335, 1.51145448670146, 2.09178251458513, 1.76612515096755, 1.39990006739692, 1.34960043569906, 1.54624529600272, 1.42293196321718, 1.41471720202886, 1.53952442977841, 1.70581830560639, 1.8322999360139, 1.62734042621521, 1.337483386094, 1.46613177327436, 1.47967162217503, 1.45243976635438, 1.85946534728462, 1.80986271891541, 1.47958967389679, 1.29235092556151, 1.24123801257264, 1.32478516815897, 1.50897942721697, 1.64281779819151, 2.42498465684601, 2.34594222026235, 2.17362713932071, 1.78244791910066, 1.90510876640599, 1.99590900906149, 1.80505036164661, 1.75304687020699, 1.82378329508711, 1.83882501229778, 1.81090789168564, 1.83575106593669, 1.80606209066004, 1.65386088238805, 1.54572946481351, 1.49750733270979, 1.55764009335016, 1.48835858263144, 1.37881566133479, 1.46720928239222, 1.41381599245013, 1.38974977646946, 1.35064715884212, 1.32597563301169, 1.30800459707693, 1.25056682738127, 1.15021828142058, 1.0369996476224, 0.964525033316405, 0.956738617993228, 0.862148156728518, 0.869949854298176, 0.896756907963003, 0.925495061730309, 0.947290424476578, 0.965493130408725, 0.976231898566636, 0.975701671058282, 0.9656778462575, 0.931138197354931, 0.957279255147736, 1.00294437948874, 1.04306559206634, 1.10462846090281, 1.12877972590737, 1.12065732264344, 1.08148405231135, 1.05006397502748, 1.01421138181851, 0.935348788483299, 0.84732969320558, 0.760757095779597, 0.679152335869226, 0.602012206749748, 0.550034850166432, 0.506968372172757, 0.415384526791882, 0.338238196181077, 0.274176569303991, 0.221954253813308, 0.17986878530282, 0.146176304411719, 0.119319439482636, 0.101306056221391, 0.0905646967260334, 0.0813065346221509, 0.0663327901860514, 0.0549454567763806, 0.0461485748862192, 0.0392448532605337, 0.0337458801610527, 0.0180473807226199 };
            PGAonSa_NEAR[1].Horziantal2 = new List<double>() { 1, 1.00915540728456, 1.01320288156641, 1.03334328578958, 1.03683900612683, 1.03158210595253, 1.01295737343811, 1.01594992998117, 1.02299678047631, 1.01032071843521, 1.04313526666722, 1.07857219121759, 1.06671086665435, 1.04883842901224, 1.02782809060529, 1.02927343446478, 1.05968426205521, 1.05004146146385, 1.00645844082306, 1.01844869977659, 1.03888171047559, 1.10261877468001, 1.13504417547949, 1.16493436387075, 1.0771907817665, 1.14781208995401, 1.22728831370654, 1.18378883402606, 1.38216600824882, 1.27837382405975, 1.13834169915067, 1.22149393827218, 1.44538094145121, 1.34721157536727, 1.31716219029906, 1.34754552609387, 1.46854160712775, 1.57105574249266, 1.56921080858059, 1.59851386598794, 1.64474036130187, 1.67432323830336, 1.65616863680546, 1.61074643634935, 1.57333095497334, 1.60923971545778, 1.62296195753519, 1.65451401431577, 1.68660589061803, 1.7391224661462, 1.77877437312845, 2.1400956330881, 2.31615181353146, 2.31957443552844, 2.26758084346108, 2.03660564553613, 1.77383394827578, 1.79579861428563, 1.82140306616636, 2.34369049438134, 2.53670421108243, 2.79450692612102, 2.92328361154391, 2.8050987264479, 2.52633405003805, 2.15954874242084, 1.76087508303481, 1.42585516000758, 1.30102322758369, 1.17709404900658, 1.06132908126894, 1.05005936309821, 0.976528399983889, 0.937413755146986, 0.976471072131013, 0.991788903927682, 0.990958822191804, 0.977857170105379, 0.9333878054493, 0.884202425714078, 0.862201743320826, 0.892312931650494, 0.913176220918102, 0.901447666809667, 0.871209249007258, 0.820790787648469, 0.790511238709983, 0.757112543099783, 0.683463514444594, 0.605565618121057, 0.551482649586803, 0.505468842738191, 0.459886593146359, 0.415980490628388, 0.374795223417725, 0.288007673833927, 0.222359823276771, 0.173902272846908, 0.136272589891245, 0.112209319548222, 0.0971578171855264, 0.0847774091603942, 0.0744601218717693, 0.0658271439498123, 0.0585646853180385, 0.0470733917992187, 0.0385114023820682, 0.0319963369846274, 0.0269491629813808, 0.0229758739247564, 0.0119172245476587 };
            PGAonSa_NEAR[2].Horziantal2 = new List<double>() { 1, 1.03988779739429, 1.01659774400617, 1.10905877952596, 1.07867609092656, 1.05806209505294, 1.05877828848024, 1.2047576899529, 1.2196062513941, 1.17204946096777, 1.18848416655658, 1.16269254079131, 1.175295379516, 1.21106142959633, 1.29182144230528, 1.3167564202951, 1.2485927495238, 1.1721948652489, 1.25311018210494, 1.23462898860185, 1.31570672513363, 1.49286915749356, 1.53079956576713, 1.56813660082534, 1.66747216513471, 1.74187306082509, 1.81202877024793, 1.95321106792638, 2.32377480651176, 2.96263140911908, 2.82807243113174, 2.52330567661407, 2.61622798401295, 3.10671405814996, 3.59697398222417, 3.71210942321834, 3.83371690157708, 4.04345484284427, 3.40937152247873, 2.30947321266428, 2.33160095991575, 2.53337229343079, 2.76613732289681, 3.25843569124422, 3.49485377124565, 3.37414965565482, 2.95534232344285, 2.68295060554696, 2.40973998311454, 2.15508232821335, 2.12199542935564, 2.02339771443032, 1.93091564169539, 1.88302473079325, 1.82799508842901, 1.69404711779325, 1.53930169439299, 1.27053580240115, 1.38764100734848, 1.23634197478195, 1.1499077920298, 1.19733279049068, 1.27972102177754, 1.34286669799562, 1.34976504833764, 1.31712488093091, 1.29604899443658, 1.24978320840424, 1.23024241987373, 1.20148083432358, 1.14329406283383, 1.07040970285862, 1.00069886866188, 0.946361598172485, 0.910293292809882, 0.88404565446931, 0.863297082292945, 0.845540435229044, 1.00741097777573, 1.05294974240239, 1.06847861025682, 1.05575140446614, 0.9944897964866, 0.965483807995812, 0.891322674683908, 0.788406452608878, 0.732762090443319, 0.676313364169353, 0.569701089016192, 0.52419697392035, 0.480707481545258, 0.438520440284163, 0.398913860957001, 0.363307446215111, 0.330930862739287, 0.261012688225069, 0.204860493873375, 0.158706390703778, 0.124750902357313, 0.10922262230743, 0.0959090350817218, 0.0844923549832058, 0.0746985722846447, 0.0665149099715472, 0.059488170742988, 0.0480616835897656, 0.0393539161858786, 0.0326411883304093, 0.0274039117464075, 0.0232675930672476, 0.0117867494625456 };
            PGAonSa_NEAR[3].Horziantal2 = new List<double>() { 1, 1.00716513462383, 1.01270461820431, 1.01707485490301, 1.02449334774249, 1.02847700138872, 1.04440391511601, 1.04347236803939, 1.05320727885062, 1.05208269694302, 1.08317439618859, 1.10301077863371, 1.10018918440217, 1.08426483762742, 1.04950008599291, 1.0175605223235, 1.11519225191045, 1.12749437195656, 1.11496353643917, 1.04960481765653, 1.01307040894121, 1.07579286746567, 1.10065149255455, 1.12451259988654, 1.07916276275968, 1.12607998110723, 1.19570985222054, 1.15266359830273, 1.19713964478511, 1.2294606576019, 1.23347023746878, 1.24478562095865, 1.23690019945221, 1.1363293092074, 1.23517546404085, 1.51960612680232, 1.54886912905867, 1.72552449257766, 2.15729232712216, 2.03709759810251, 2.10714921951808, 2.17302184219916, 2.15585278013795, 2.04373779093198, 2.27145779801677, 2.27060428629735, 1.99412167868428, 1.65299422178983, 1.59180012680746, 1.80709120639068, 2.25144095880811, 2.50219628459289, 2.50775861405099, 2.5055890257645, 2.61576057520273, 2.58160727166315, 2.24979964935428, 1.60449319372534, 1.73663811359792, 1.86676900250791, 1.69458244666514, 1.70848531831495, 2.29645324167601, 1.8415230242808, 1.32667371722964, 1.13791542918163, 1.14203846835076, 1.31003935138243, 1.39948378584428, 1.44880059142587, 1.28040953160817, 0.926364142753365, 0.727516191053144, 0.809362959388244, 0.734320155454646, 0.574069928921084, 0.523367225663365, 0.520634704684945, 0.517862909332669, 0.521144758154567, 0.527688176873298, 0.56022224675088, 0.555442324426864, 0.478110055523183, 0.389599478395244, 0.341969930717951, 0.32879247985584, 0.317506873015425, 0.316696486098669, 0.322601247025544, 0.301983740922614, 0.274320720184205, 0.237918637872304, 0.198780132814124, 0.166414198327887, 0.110255257760539, 0.0792253193930697, 0.0555175618057998, 0.0472878606247449, 0.0391540351210447, 0.0363263315424561, 0.0352944936301073, 0.0332357463542857, 0.030384580829485, 0.0271687283573814, 0.0208947883162588, 0.01583832819515, 0.0128433619890802, 0.0112321115494896, 0.00975339286951924, 0.00500555745224826 };
            PGAonSa_NEAR[4].Horziantal2 = new List<double>() { 1, 1.02921326660467, 1.0268917331506, 1.00296944593999, 1.05896707209632, 1.07537290147325, 1.09850411139934, 1.09072854975283, 1.09387389261416, 1.09067073319955, 1.0664238779306, 1.0436499681856, 1.06250978904606, 1.066578055406, 1.14269278302579, 1.1552582472713, 1.37896242229945, 1.36825901815868, 1.45593491508003, 1.62566443150115, 1.77829952033674, 1.77750263080613, 1.64288244579316, 1.60718944251383, 1.75582876511184, 1.74935851157555, 1.84171081934315, 1.78735775292448, 2.09706298027507, 1.98994450834516, 2.22739648083794, 2.44653651314179, 2.83027690764035, 2.62105929714649, 2.52683116342812, 3.09109930987225, 3.31487690274583, 3.47942464881797, 3.43557278155744, 2.20580612794283, 1.70329829670599, 1.44394669864422, 1.343452657726, 1.45392418383828, 1.6493114017914, 2.26002948950125, 2.75320162987617, 2.78676673926876, 2.56484875923841, 1.95443657921786, 1.63228886251285, 1.72141262052763, 1.99595804170134, 2.18653486124027, 2.25125942195683, 2.11977448485145, 1.83041823699281, 1.30953177769076, 1.33169234251872, 1.08203465322304, 1.04368912436983, 0.918492425725613, 0.769977607557144, 0.740923107043219, 0.930705178405364, 1.09699721012187, 1.14030027898781, 1.06039596691302, 0.834546155352161, 0.737268121971514, 0.778434731535412, 0.8269718809652, 0.912875348734766, 0.816346483285204, 0.653634183348833, 0.480688353482453, 0.435735524448142, 0.426228831187901, 0.418564314032598, 0.459662400274093, 0.49932241446821, 0.512656930644609, 0.511700357300181, 0.464804708531154, 0.457774032108071, 0.465196576281141, 0.462511318584504, 0.45697102442367, 0.441940556017816, 0.419828936420146, 0.393603164309138, 0.363740761587783, 0.332675223924429, 0.308697261514365, 0.287630561401791, 0.27189185551368, 0.250715150996035, 0.209876566247369, 0.167982630561402, 0.141493594292986, 0.122890552346924, 0.10722850692575, 0.0916677475405022, 0.0772543867162645, 0.0670363357153345, 0.0534358328030933, 0.0430938280064608, 0.0351986870441975, 0.0291172421809995, 0.0243782732122755, 0.0116633730605452 };
            PGAonSa_NEAR[5].Horziantal2 = new List<double>() { 1, 1.00753900044156, 1.01107572838075, 1.01349313402383, 1.0132385960224, 1.01662417312937, 1.01155114813164, 1.01077080676857, 1.01920643394678, 1.00804263501447, 1.00774416250448, 1.01465276320852, 1.01407113480619, 1.01357193399102, 1.02925494127186, 1.02879201665642, 1.00629472679084, 1.03023782475008, 1.0362306529454, 1.05969470353377, 1.07395386997522, 1.0221298925761, 1.05725835365304, 1.12744836637188, 1.14420877678468, 1.15590079749194, 1.31420166866488, 1.34874225377177, 1.54863378793458, 1.49579125546083, 1.51398558343516, 1.50762817943256, 1.71879798409127, 1.76008977150226, 1.76966306061088, 2.13264352124203, 2.52213301635996, 2.69839504015675, 2.41699048213286, 2.06622583022618, 2.22293498236876, 2.49391819434813, 2.9895881260743, 3.1427563180544, 3.13922140392521, 2.85433634607172, 2.40935232674537, 2.152331420973, 1.89934503321388, 1.52854685000658, 1.46591095281252, 1.45797210803617, 1.47526315863723, 1.47888090342248, 1.56999583428306, 1.7468888624207, 1.86222218728959, 1.96163590344162, 2.00919057520147, 2.2559664775669, 2.27593249482913, 2.09778410864641, 1.89919186703725, 1.70459585189717, 1.46259571122613, 1.36222752795232, 1.33552159431479, 1.29504299838107, 1.17230731342294, 1.020086937928, 0.862496878735315, 0.71167676454993, 0.651801083086403, 0.624255960028465, 0.645597651398216, 0.732184103325903, 0.76918421477445, 0.769883539291457, 0.715645783869224, 0.626552445005785, 0.590819783668898, 0.554313834674444, 0.482793291563305, 0.427007751619279, 0.399036584748962, 0.355369915462347, 0.336550830714897, 0.321824910503592, 0.292485324765701, 0.269072262391396, 0.246611047191104, 0.224612958140692, 0.201036914862379, 0.177230598329562, 0.154471777217378, 0.111248886774121, 0.0868966134353743, 0.0674529331423593, 0.0556628860820515, 0.0464213226665183, 0.0389980433020935, 0.0334036890073643, 0.0284633139799808, 0.0248160040919553, 0.0224499494249315, 0.0186156155738562, 0.0156735351620166, 0.0133709436910751, 0.0115373228688589, 0.010054492898027, 0.00565880500958196 };
            PGAonSa_NEAR[6].Horziantal2 = new List<double>() { 1, 1.00468721877741, 1.01005644466623, 1.01589022394272, 1.05388036764578, 1.01777326784941, 1.053686841356, 1.01658216319654, 0.999205278121055, 1.04658069444336, 1.05340211994055, 1.04007995675605, 1.01660037212427, 0.989356806497186, 1.08648036776616, 1.184172468944, 1.22715622296877, 1.19850048727693, 1.50430167106791, 1.56621458363556, 1.63443335321768, 1.59784243769687, 1.30376118193698, 1.18577936919459, 1.33171474525861, 1.4936386132803, 1.62166754049455, 1.72786622066331, 1.55290852256071, 1.59790714710948, 1.57188342915343, 1.56168341988343, 1.67525596334859, 1.71394316286366, 1.61280686557838, 1.64796213506149, 1.63600443756083, 1.48827962050789, 1.15188683617924, 1.10315628436747, 1.14750781479022, 1.1745322713365, 1.59737893771824, 1.6672952007286, 1.68594054077807, 1.52877341653058, 1.30569524093873, 1.37375750403456, 1.45282954697994, 1.59376875444313, 1.7408050934434, 1.91060710671876, 2.04453301775205, 2.07125048080598, 2.07994261027537, 2.1018384696555, 2.18257926301096, 2.58366174614287, 2.80608003621319, 2.85281076620158, 2.83309997814929, 2.76253060153268, 2.52973472752522, 2.21551183941471, 1.90130400000482, 1.69232570444472, 1.59171761655068, 1.48254034707119, 1.24738483680888, 1.01008955180756, 0.816028732183091, 0.765713702684628, 0.721425978752439, 0.681837512558141, 0.645494298649289, 0.608734085246675, 0.573338036553896, 0.560471999484732, 0.54676112836361, 0.500378625307219, 0.476499497674374, 0.448583104643246, 0.384954188745619, 0.32141059898042, 0.276131767626393, 0.245898627137141, 0.230052044426172, 0.215491373181891, 0.188194234180655, 0.172331398873033, 0.157954472263138, 0.144311576122648, 0.131807053988116, 0.120227259457055, 0.109727615509311, 0.0875699689334625, 0.0705068492655933, 0.0573508688818755, 0.0471756448217722, 0.0392206759515143, 0.0329432609811873, 0.0279439923480367, 0.0239180134752085, 0.020662031466231, 0.0179982007773557, 0.0149699206572309, 0.0127583636163352, 0.0109935122041952, 0.00956510459147894, 0.00839418024611247, 0.00483058774807031 };
            PGAonSa_NEAR[7].Horziantal2 = new List<double>() { 1, 1.04026548920679, 1.11099407677206, 1.24999610600877, 1.63515108997487, 1.78278880798387, 1.9750921629844, 1.41862274826063, 1.44537353344502, 1.94380316466225, 1.95305653389922, 2.05037516269095, 2.09701707811097, 2.10242505312962, 1.97572641627576, 2.21066928675164, 2.51476071891178, 3.26017406452312, 2.89564913456824, 2.52942330924458, 2.50693660021545, 3.33535363982263, 3.52472372911029, 3.94662802165931, 3.08285727992563, 2.71259790272748, 2.61249179925447, 2.0573120744257, 2.06627635375384, 1.77091992271829, 1.60483901617221, 1.86063000416813, 2.07458644255553, 2.23252921895258, 1.8251915687925, 1.57280860192008, 1.4726788229804, 1.31295166404264, 1.52134187560785, 1.22276807325937, 1.17766132494142, 1.21199262073086, 1.18284600292704, 1.17076852433931, 1.14050853656333, 1.00682837841121, 0.891056966288005, 0.863159291654959, 0.855771923014859, 0.736438225411626, 0.599098338542974, 0.592121676945765, 0.563823513102813, 0.551657438426653, 0.549668823833968, 0.538065228402834, 0.588419581604661, 0.51034960564772, 0.584464158770172, 0.446275693332926, 0.431368747262524, 0.455066767931207, 0.480055475356643, 0.414947692794621, 0.374333675796882, 0.360539227444601, 0.364187243035519, 0.373501047016362, 0.344825072568421, 0.326414531253797, 0.269074793914408, 0.217761833527825, 0.182084026723371, 0.156879498728067, 0.138688017784014, 0.132171906317424, 0.143736997963287, 0.149450884932871, 0.150805620057357, 0.146734312043897, 0.144736850303139, 0.142047566504697, 0.13829450660639, 0.14684234693655, 0.148233716730518, 0.147141654678366, 0.144312187195685, 0.139018103632502, 0.125915601945625, 0.11755170753073, 0.106837400010093, 0.094845065876986, 0.0812317597662858, 0.0714413063374863, 0.0640787470943037, 0.0488990721086181, 0.0379923578085739, 0.0319262048164622, 0.0268559790210444, 0.0248101071813298, 0.0229146991626984, 0.0212548744982203, 0.0197192837299078, 0.0182007891406865, 0.0167257078808775, 0.0140099574028511, 0.0116668213879182, 0.0109772671907252, 0.0104065638362231, 0.00938304849047094, 0.00509507257465093 };
            PGAonSa_NEAR[8].Horziantal2 = new List<double>() { 1, 0.982289510490372, 0.989893826568957, 1.00074068280362, 1.07492371973039, 1.1317703037518, 1.17217097866, 1.03848450714519, 1.12856225215199, 1.54663458409778, 1.75493766296099, 1.74979660989809, 1.72011530673978, 1.66017214305935, 1.62088002888827, 1.71036325687754, 1.89054605033153, 1.34715729101423, 1.7898497304863, 1.90170433001771, 1.80706567873376, 1.5889717503825, 1.643822103921, 1.72312381740691, 2.0098624953579, 2.10703728726155, 2.19862082726961, 2.11934436433382, 1.83512232454512, 2.34505554197227, 2.44483011409348, 2.58246819405807, 2.56227185973997, 2.66284705906022, 2.14358694534241, 2.27324133510949, 2.29184052081005, 2.41930447667619, 2.49852961735563, 2.70850128541723, 2.88055812337912, 2.77179805061647, 3.71232972045178, 3.96209050741494, 3.91868830166647, 3.3653070990382, 3.49336639307798, 3.51668927925281, 3.46640783826345, 3.36949499515621, 2.94987806858337, 2.34544764401076, 2.31361347484316, 2.33707801044552, 2.34091896811061, 2.27371965853866, 2.15467665849411, 1.90741834475048, 1.86531664497788, 1.88848967016418, 1.95076532775111, 1.98799983002069, 1.87680051305833, 1.72082704379082, 1.62953419304271, 1.61909832543689, 1.63170512448624, 1.61406443324524, 1.47958185088996, 1.48663270775609, 1.59265956243465, 1.3594481502535, 1.07208559895434, 1.030018387738, 0.971562132468492, 0.905865949140465, 0.844786100126438, 0.943350904021017, 1.03286636238727, 0.952948371247137, 0.890985574134897, 0.821094104283951, 0.678241888363417, 0.52951799573861, 0.40958178314458, 0.34738105605191, 0.316289417289154, 0.28628170458047, 0.231335275778092, 0.184633172119862, 0.146452944368111, 0.119375424563366, 0.106182463759815, 0.0974944679739882, 0.0896734898580036, 0.0733187290720669, 0.0606648367202943, 0.0564051099723045, 0.0576710247473867, 0.051043309620398, 0.0428831735055626, 0.0355384453995859, 0.0297828185813666, 0.0245781669783981, 0.0204058522974203, 0.0154880510496325, 0.0127661854486622, 0.0107025791076127, 0.00923695916862872, 0.00815892490958558, 0.00472994126065116 };
            PGAonSa_NEAR[9].Horziantal2 = new List<double>() { 1, 1.0106193281362, 1.01390099021973, 1.0343882828063, 1.06256553476367, 1.06453614986663, 1.0349448007368, 1.0420151693634, 1.02419580990182, 1.04478052536606, 1.04295071035463, 1.02432582430775, 1.02952534542331, 1.05135486969016, 1.10831337199923, 1.1208313325105, 1.0394316459519, 1.23610053384454, 1.23144041424536, 1.18984401084946, 1.22348128167709, 1.27824911744955, 1.46757893246097, 1.62632546697329, 1.63891892728385, 1.5109385609832, 1.47116165585597, 1.38206251383381, 1.43578695175891, 1.57404537303466, 1.60410812696722, 1.62879445109301, 1.5286024658891, 1.46058582216937, 1.41023425571266, 1.34854365107651, 1.37352306448527, 1.43618789789801, 1.57158107834347, 1.79388695476015, 1.96226323075365, 2.18605565601354, 2.6704912082594, 2.93139459852864, 3.06686046511628, 3.21117411097814, 3.26908855329254, 3.28725070997948, 3.28524715164111, 3.21899490540485, 3.14401680503607, 3.03033333395859, 2.85220304662793, 2.78662607809962, 2.69696889408269, 2.53272165990764, 2.33475508990572, 1.75603271532918, 1.60584790495091, 1.54967793004873, 1.5309788337954, 1.49023825110577, 1.41207602876683, 1.28874874792258, 1.14344457752001, 1.01130890860116, 0.966449131892991, 1.01645356340295, 1.08522848771557, 1.09226603034248, 1.05956781757748, 1.01001310226331, 0.996242478156642, 0.957551996383513, 0.894914947834797, 0.831299684495249, 0.772656856694816, 0.722539878900198, 0.618983580434954, 0.594524107414174, 0.57850185420004, 0.536254089181676, 0.462569333200779, 0.401765382263456, 0.317203145105925, 0.253139455163436, 0.235345301380193, 0.217140001950802, 0.180224117168185, 0.147729542836992, 0.134568427203187, 0.124008772045004, 0.114314421962282, 0.105508589626234, 0.0974261368112636, 0.0801290976226473, 0.0664409136694966, 0.0556270211436953, 0.0469967141174308, 0.0400673097123692, 0.0344608165420529, 0.0298864196963501, 0.0261218168159155, 0.0229970981816272, 0.0203819914689916, 0.0163011335286637, 0.0133136979145173, 0.0110694546569777, 0.00934483525099697, 0.00799294334795185, 0.00422728534609858 };
            PGAonSa_NEAR[10].Horziantal2 = new List<double>() { 1, 1.00692580608784, 1.00950129685372, 1.01114990588052, 1.02182791314984, 1.02523486497974, 1.04976231577304, 1.08546439507629, 1.10616981410318, 1.10604012873117, 1.08758837255701, 1.09107252838765, 1.09078800128384, 1.07870947874288, 1.05394911475637, 1.09011268314264, 1.11601896269052, 1.22562955959021, 1.29592857328742, 1.25853234327154, 1.19693959871269, 1.31971564638833, 1.38076969786344, 1.72855637193244, 1.7946568759271, 1.69587652564647, 1.46592744558853, 1.67222867998508, 1.67608714510015, 1.78077273397583, 1.84578717719619, 2.08128236712671, 2.59294103869742, 2.45740594557552, 2.41589665073431, 2.99043711343783, 3.17468706355884, 2.94874304947128, 2.34652495250653, 2.56297807926856, 3.34030872925685, 4.12223908951327, 4.80024115406969, 4.83248466763244, 4.78289627772621, 3.58645373398451, 2.43243955967696, 2.01964234596067, 1.85800405971599, 1.9189800397297, 1.8799685979233, 1.74781703519288, 1.51810694055292, 1.50731703085558, 1.48505191752184, 1.43407645798454, 1.43178679551349, 1.36888548651532, 2.20185419720851, 1.77700188238968, 1.56733750292768, 1.40520866766714, 1.15924799833448, 1.06371368592719, 1.13147754578024, 1.24911519010401, 1.31433131793301, 1.15161824790291, 0.91307523486498, 0.908929640264055, 0.97599519426782, 1.00034611681226, 0.985413214896035, 0.944819958535379, 0.913096921382038, 0.878411939728832, 0.833039408738799, 0.780648253367916, 0.68306933613234, 0.639391823315608, 0.632797387208425, 0.623596231750796, 0.591807701315938, 0.554937586203905, 0.504839996877142, 0.461579732648618, 0.450835364637098, 0.439805168330745, 0.41799928868224, 0.392300982832953, 0.364132322452485, 0.348840508678944, 0.332205215173622, 0.314019162206473, 0.287245508722317, 0.223913765733568, 0.190143261131689, 0.155151155023899, 0.131747759782788, 0.107990527329349, 0.087467795522168, 0.0748880541989434, 0.0650388188655349, 0.0567059048048647, 0.0496513241787316, 0.038569253723575, 0.0304775371056307, 0.0246734010530973, 0.0203990319138785, 0.0170410916125227, 0.00984927870644263 };
            PGAonSa_NEAR[11].Horziantal2 = new List<double>() { 1, 1.00376361931776, 1.00612095400518, 1.00521776861181, 1.00059258534738, 0.999880511763435, 0.996323785720306, 1.00444048809471, 1.0094635030205, 1.02440039970463, 1.02795938024278, 1.03371146417659, 1.03565067674738, 1.03857128834679, 1.0543340239025, 1.06331402445052, 1.09528519188701, 1.11958240508836, 1.15143165637056, 1.15174797936547, 1.16234427942697, 1.20008348568517, 1.21661621800481, 1.20664892205656, 1.26154899763417, 1.28418117954486, 1.30512301045149, 1.28078729741194, 1.33250402600785, 1.43439055276403, 1.43833904067421, 1.34466598615601, 1.33450705813025, 1.40144214844358, 1.46472495680908, 1.52426426288938, 1.53858117344038, 1.43864998756559, 1.32571799596896, 1.51725521126526, 1.26917699485524, 1.37138209910136, 1.44588535580614, 1.45173837174819, 1.44052295266705, 1.47559630526418, 1.39789964306141, 1.35945425959088, 1.34404721398175, 1.31136761483791, 1.41218672490894, 1.4221573158884, 1.42507081715733, 1.53005016424863, 1.61382217028791, 1.66533356641343, 1.75018009946832, 2.02837611497786, 2.7555045230373, 2.80472708643977, 2.49786776797015, 2.17401302543174, 2.26689822064847, 2.00237138192568, 1.66463935536703, 1.63797145393078, 1.77248052376429, 1.96935863778554, 1.51691339513424, 1.41919334861534, 1.27214876614955, 1.31366425158222, 1.40878209056896, 1.30734507543714, 1.49940411962143, 1.42611759654181, 1.19655849599515, 0.994723961362811, 0.768262883832114, 0.69932528166447, 0.641633794394909, 0.634574276766666, 0.724277338960553, 0.63131531749013, 0.560825755628694, 0.478425696526239, 0.421256905258141, 0.385543449495323, 0.379041485830152, 0.370528859444028, 0.359960307013665, 0.34728120039027, 0.332179552146297, 0.314301753407496, 0.311446348741246, 0.348507819109031, 0.341478303606949, 0.321689560196578, 0.249764925537498, 0.206549897697952, 0.164652795625863, 0.135651769310357, 0.113358594083026, 0.0934480212297126, 0.0793420620443969, 0.059874618860273, 0.0453193388155716, 0.0345220245087889, 0.0265056298209341, 0.0230881622015526, 0.0117229752813697 };
            PGAonSa_NEAR[12].Horziantal2 = new List<double>() { 1, 1.01424364808715, 1.02425191168426, 1.03382255380067, 1.04283860380125, 1.0350719864058, 1.03222686483781, 1.01513052991771, 1.01032134917771, 1.01984892747821, 1.01429660494186, 1.01754559526996, 1.01851162141086, 1.01579452740372, 1.00710378379637, 1.0384356195952, 1.05747273594898, 1.09051257579814, 1.19334605849696, 1.16837311886777, 1.10359582862929, 1.29006215156135, 1.21150385828513, 1.29451110930062, 1.2680175514147, 1.15131402832901, 1.11042260733947, 1.12190842537739, 1.04410083916247, 1.11772017830748, 1.1215755537192, 1.14237712263876, 1.16726975407069, 1.16600635482257, 1.29874591184721, 1.1673046706782, 1.1244806154634, 1.13455987616243, 1.17265447689103, 1.37299724158801, 1.51927978677592, 1.51300701823811, 1.59240563786822, 1.66497573295779, 1.73558409664917, 1.48373118867771, 1.61735937336328, 1.53610028049675, 1.63711926349236, 1.76660692047161, 2.07016143111535, 2.09268962627591, 2.28210058310735, 2.38129168170021, 2.33540485806399, 2.30601496758575, 2.20494826522655, 2.63816559783051, 3.2477449690988, 3.0225863895064, 3.14392043669037, 2.84662065433722, 2.56361747692594, 2.12084405079203, 2.31274397979492, 2.72725939547714, 3.19363935799998, 3.38792292740837, 3.16695841432046, 3.52372583479789, 2.61890210547143, 2.12840931575088, 2.20766070368603, 1.80698273955702, 2.07681188095765, 2.15105797320732, 2.31296860996986, 2.54425039863127, 3.52201841269102, 3.60092238038152, 3.38576508106472, 3.25024267042214, 2.62613217099827, 2.09699600786788, 1.6107339470897, 1.23962336619374, 1.13540660389437, 1.08612297629162, 1.09329193775533, 1.13668338784204, 1.16536796284873, 1.15429881632701, 1.063225247035, 1.04863534259011, 1.06616289761287, 1.00962476285804, 0.854245277528835, 0.670764906481686, 0.494832749450063, 0.433455987616243, 0.385257102619909, 0.358427065026362, 0.334833447782214, 0.279213677999046, 0.224256974592349, 0.160768339948091, 0.122096102142716, 0.0955175223175316, 0.0771665754955249, 0.0644265529161187, 0.0354420442509806 };
            PGAonSa_NEAR[13].Horziantal2 = new List<double>() { 1, 1.00348101321074, 1.01142833087706, 1.0034156375168, 1.00144544301344, 0.999164471472433, 1.00726426776022, 1.00260998393543, 1.0055280290043, 1.01779363434734, 1.0367281424515, 1.04544483697882, 1.04028675292508, 1.03108992533397, 1.02040633418697, 1.04082857581282, 1.16363225803573, 1.14039983153634, 1.10224331746922, 1.06966973246986, 1.05022502236256, 1.10397470639621, 1.03651087011557, 1.08110077925111, 1.1709622894762, 1.09881972623298, 1.1226157028537, 1.52938715039766, 1.40342622954318, 1.09755295091721, 1.06409145923787, 1.10792809294445, 1.17738598488677, 1.34238337276891, 1.43160761547297, 1.72489985588248, 2.0700583007635, 2.4439180332353, 2.83875230585116, 2.55495389655625, 2.2528347735062, 1.92017045790727, 2.02659025405538, 2.05136512014675, 2.0896263905187, 2.3463627544002, 2.66878132140767, 2.69242520739323, 2.56701833099539, 2.38847672887187, 2.05581532317029, 1.71075038299099, 1.55187561313962, 1.5261973209157, 1.51268336960682, 1.46246377905266, 1.54740116097145, 1.93498319340284, 2.00683787080095, 2.05388703118886, 2.21607501017009, 2.4146522255574, 2.49531652020507, 2.42676515828581, 2.2574537505764, 2.01398457870797, 1.71204567530085, 1.46722941494962, 1.10055092116681, 1.24702060459519, 1.39583566529274, 1.02411276744624, 1.07361380734656, 1.03843353629544, 0.932056612635046, 0.797015260083716, 0.725214318790119, 0.753759829875761, 0.732068873002574, 0.638756224512936, 0.596747394332412, 0.560194621694914, 0.507629265885275, 0.484465706956653, 0.48145745506973, 0.484132620705937, 0.484438741907818, 0.483482937622858, 0.47543920535747, 0.458521062128054, 0.477419293511841, 0.505589621831679, 0.519407366424557, 0.509104971831224, 0.488711441192623, 0.390886705862337, 0.3201853177831, 0.241455910884199, 0.184696015632745, 0.148471789806086, 0.117423165615256, 0.0996754688475119, 0.0852519418230041, 0.0733023707321748, 0.0634030551206337, 0.0483439677148828, 0.037805735640481, 0.0302727873576987, 0.0247604717991178, 0.0206314438464498, 0.0101319328062022 };
            PGAonSa_NEAR[14].Horziantal2 = new List<double>() { 1, 1.18203448237839, 1.04962482842327, 1.24995762907409, 1.58099299480971, 1.54479597225041, 1.66784318305914, 1.5357081743828, 1.55724894052266, 1.42726821265753, 1.69699642205608, 1.7681663047611, 1.71097270168867, 1.73495872969718, 1.6532961721595, 1.71646764923653, 1.80173735090028, 1.81148368484526, 1.70133663424968, 1.49146373885951, 1.36678192919829, 1.39225655503748, 1.49072352388883, 1.39866222224582, 1.48563901277989, 1.55620549266054, 1.72938006128367, 1.6352359478611, 1.43938731845334, 1.88733989405431, 2.0365355815721, 1.95032146770437, 1.63758932097477, 1.81287733096247, 1.65132566885825, 1.36300121742391, 1.44940217176009, 1.43820501647259, 1.0608638441436, 1.03658173014682, 1.09659325503867, 1.11941637980359, 1.03759659039628, 0.996080434106982, 0.923720081531871, 1.12855931092418, 1.14482259956963, 1.16955292649349, 1.32316335819503, 1.37088220964277, 1.52071397154226, 1.40993288853731, 1.18991139065259, 1.16226512723734, 1.13286072564346, 1.06944216991415, 1.46466693593475, 1.69388139326223, 1.11049296070878, 0.727475003195687, 0.709331160130245, 0.682027029179376, 0.715646878457314, 0.730322635712544, 0.513535928299, 0.481904857974698, 0.496133116993171, 0.459704636869934, 0.37305456190913, 0.346849114171982, 0.329482956269529, 0.317372324658899, 0.387209309923618, 0.448716681647937, 0.488887178169846, 0.478303125075298, 0.434392449929817, 0.371311738522992, 0.25048119078025, 0.231154126846505, 0.233478503953054, 0.233574987145784, 0.206276267421597, 0.175127000469245, 0.161942801904588, 0.160341180905272, 0.159912162518128, 0.157521829705225, 0.144896110573619, 0.140818802317884, 0.136563842469186, 0.127727615592991, 0.115975656422636, 0.102969415746792, 0.0900979860843669, 0.0628271086529394, 0.0440298650705522, 0.0318839788075943, 0.0247874408900059, 0.0209384557706751, 0.0178571195203162, 0.0153770624431055, 0.0133780123686348, 0.0117635065238974, 0.0104172035352259, 0.00832366119104979, 0.00679396866715973, 0.00564718679513667, 0.00476880176655111, 0.00408289305006549, 0.00218578844431521 };
            PGAonSa_NEAR[15].Horziantal2 = new List<double>() { 1, 1.03977548363758, 1.05836879968189, 1.08028102752861, 1.14500836256683, 1.18092706974655, 1.22788068589901, 1.27000921483982, 1.29982757713521, 1.34618479516696, 1.32563118693904, 1.26491744658757, 1.26501161471189, 1.28372547110113, 1.3207105165083, 1.4004137994381, 1.39875556566419, 1.41824527991925, 1.4189206660568, 1.46048843153598, 1.59489799160746, 1.68179124239017, 1.57796316662702, 1.56369515205258, 1.55904592252665, 1.70903824885368, 1.69543275591892, 1.9329036676812, 2.43432191424757, 2.1395615341737, 2.23159801120009, 2.16901222912031, 2.51156421873712, 2.89188380116581, 3.2089576527746, 3.20560516463277, 2.94643184498383, 3.01877406223921, 2.72526539780694, 2.80884604039118, 2.67612044308933, 2.39827816414868, 2.33172625737924, 2.62851536876533, 2.80805616022269, 2.83000942581758, 2.92314067161169, 3.11983755741265, 3.21973552908013, 3.22615362706155, 3.03454079081413, 2.72204284109348, 2.18032655498653, 2.03237067867044, 1.94291867926375, 1.70467847052956, 1.61483924973734, 2.23857185548898, 2.39682190299114, 1.85282731431352, 1.42562049654132, 1.29874567286534, 1.20256579836881, 1.12575342539768, 1.01156801376398, 0.841843863332206, 0.779687112255994, 0.57761608247481, 0.747314889845807, 0.668471212662885, 0.501383512422152, 0.357402380009291, 0.322118407153896, 0.321646666017438, 0.273185845295923, 0.190939251139569, 0.194620169911715, 0.223889990018436, 0.228003155918615, 0.145560249524946, 0.126951753373168, 0.111214574549829, 0.0899092293895628, 0.0665413578811966, 0.0521819667784634, 0.0499462456956998, 0.048719217025494, 0.0474437149273587, 0.0473570596697863, 0.0521653715762265, 0.0577002445926978, 0.0615771925832053, 0.0617868324403013, 0.0649016875776935, 0.0609644179567292, 0.0608692849950684, 0.0508397493944359, 0.0411435843912989, 0.0312841817748402, 0.023533733479251, 0.0190808676486309, 0.0155099146041768, 0.0125997464922052, 0.011155487911167, 0.00988262303509268, 0.00782187198769742, 0.00629835523535534, 0.00516955987079413, 0.00432091467608931, 0.00367101310879467, 0.00193959320656743 };
            PGAonSa_NEAR[16].Horziantal2 = new List<double>() { 1, 1.00161580152167, 0.99935133197992, 1.01874877494467, 1.03787509189138, 1.03783283848597, 1.03094475093378, 0.996838819299008, 1.01914079265041, 1.03303238214919, 1.0444341506107, 1.0541109629199, 1.04623383269295, 1.03160006995286, 1.0686261813837, 1.09789801045146, 1.03708049312854, 1.13564634212661, 1.08411283693668, 1.10639524852631, 1.20623613315613, 1.36649195405177, 1.31900851601737, 1.34593332490873, 1.41893625486941, 1.42161973734814, 1.5993770752584, 1.55221327641121, 1.47181560926868, 1.8999474571079, 1.9102165995633, 1.76586605592238, 1.61525379234094, 1.59117795843282, 1.53373523624935, 1.69585177192394, 1.72987710910025, 1.4986566938197, 1.73585322731902, 1.66118480896179, 1.68057755710372, 1.90488249836561, 2.11813230558445, 1.98203565170205, 1.74704216381254, 1.80054084358924, 1.61558477734998, 1.68567339604312, 1.83727744094598, 1.84774102731331, 2.07521771262755, 2.41643626171603, 2.60210320237777, 2.68539679273179, 2.67396372545146, 2.47253156974922, 2.274857619717, 2.15471475625849, 2.68991321228776, 3.01539745391934, 3.18989736726073, 3.23122158898626, 3.18765950171498, 2.46634809685576, 2.41236702403397, 1.84573672920301, 1.71646752141133, 1.71153639250597, 1.3036450995635, 1.06835975018848, 1.04231522057647, 1.03530780627753, 0.742549218370685, 0.730555510998209, 0.699835329089474, 0.53406974237551, 0.530800971984818, 0.460454138036398, 0.413211700906922, 0.425421370129268, 0.412460920490437, 0.358275036022984, 0.27740800396869, 0.278296420940944, 0.282373326833612, 0.242447105974279, 0.23405499280714, 0.238022196339838, 0.262653271293858, 0.263829011422895, 0.235987655745857, 0.214774098818978, 0.173940407831434, 0.143688964858077, 0.119121387382742, 0.0669269685098671, 0.0501057313223321, 0.036475604331287, 0.0325898950980964, 0.0288167051185697, 0.0242656612442767, 0.0216110128023906, 0.0197820663245445, 0.0182729155280091, 0.0153569610724853, 0.0122048179054283, 0.00984406537227793, 0.00802630822216058, 0.00724395512218863, 0.00724657639826495, 0.00402056801878868 };
            PGAonSa_NEAR[17].Horziantal2 = new List<double>() { 1, 1.18837564901517, 1.28575680463119, 1.375121138801, 1.32145023200888, 1.18663076893456, 1.03750569593038, 1.08406150321218, 1.04484141246237, 1.17101669950518, 1.20321154204078, 1.39407815779171, 1.52036575895464, 1.63974523948579, 1.79959149750021, 1.73851909019145, 1.34801573039477, 1.90177568623927, 2.42699903088959, 2.50041155102591, 2.33722795915617, 2.08909558252521, 2.19164318766727, 1.98480389954625, 1.95397206908281, 2.11390015595618, 2.22480312939228, 1.96072375219013, 1.60533941327104, 1.62673765988717, 1.60130653411461, 1.24927717841258, 1.30578963244402, 1.48733016500549, 1.83445380038893, 1.9731280445149, 1.866557187141, 1.80638730401186, 1.46786452349932, 1.06526172398965, 1.16232438885074, 1.23370402341268, 1.20884810638393, 1.08164755187308, 1.11559048346415, 1.2318396090185, 1.14858436074012, 1.07387782149115, 0.983760982716461, 0.760539877930596, 0.734255646191268, 0.735480993241899, 0.655728902594777, 0.629097941121729, 0.610694390070148, 0.65713667986625, 0.674038109785448, 0.480504274354515, 0.423336387207743, 0.486519096609397, 0.497211721743372, 0.532682767163202, 0.580439372837953, 0.54622456085179, 0.516850326994538, 0.524190856988826, 0.469479600546809, 0.390485389537458, 0.240530555858625, 0.220936876255511, 0.235884120708798, 0.168257542695411, 0.125446127730035, 0.115000032089749, 0.121608915815753, 0.123999120740888, 0.117749241077445, 0.11919295886736, 0.13590634285971, 0.10938488765379, 0.1058460301772, 0.101322338315802, 0.10058547746337, 0.0980809528088157, 0.0890513788964977, 0.0888461649541437, 0.0868039733526728, 0.0823215168182372, 0.0698146094998492, 0.0566752693934396, 0.0484516214949972, 0.0396308475544403, 0.03289261807423, 0.0285544049597915, 0.0247644532227735, 0.0175861930647635, 0.0143545628413547, 0.0118462114842792, 0.0098865466937932, 0.00834141727583706, 0.00711026198070764, 0.00611866468138089, 0.00531176795260986, 0.00464854505079807, 0.00409833422114971, 0.00324903891202916, 0.00263505772945775, 0.00217850083112449, 0.00183059179914385, 0.00155977036575895, 0.000815111704414908 };
            PGAonSa_NEAR[18].Horziantal2 = new List<double>() { 1, 1.20640792552565, 1.30526051924987, 1.48578749179334, 1.81413344023029, 1.78648647795566, 1.97414403523391, 1.69647708238641, 1.70101310119018, 1.87798359300035, 2.24131146575089, 2.31505563692069, 2.57698580038045, 2.74813035536926, 2.59978347053179, 2.28075286601687, 1.87201035722102, 2.06764520520849, 1.91095067799606, 1.80011478797367, 1.7544447460566, 1.5544869366867, 1.59863217135498, 1.76232629244314, 1.65516866782822, 1.66305310758716, 1.51828269405586, 1.57766547985792, 1.64521257343905, 1.77032541496221, 1.75235573119203, 1.62989269270912, 1.39282369998148, 1.09706948723128, 0.933390359072774, 1.18241976415333, 1.37919144445567, 1.40572103892059, 1.26806384988974, 0.904680740029965, 0.907599626702355, 0.97804403817989, 1.07678747285491, 1.0911864720637, 1.0868503589886, 1.0447533689376, 1.05914447713078, 1.01490402420753, 1.02357940676397, 1.07990994772991, 1.16184104759019, 1.25759299824925, 1.37671392858947, 1.46876972753901, 1.63390606324596, 1.90139202775954, 2.03522943916974, 1.86086087823847, 1.68417709332862, 1.5446452620238, 1.513991033702, 1.44092496380654, 1.3072082849351, 1.17184922268236, 1.04310519881151, 0.928347474033298, 0.828017682187768, 0.738563025015572, 0.58812817744895, 0.473240776980961, 0.409610520512432, 0.385583956197498, 0.389635466643099, 0.403579417285322, 0.400515335925795, 0.379634130431123, 0.346317210410249, 0.311460227177079, 0.248200085643823, 0.199709768446038, 0.176154534493207, 0.162976775162871, 0.137764664663401, 0.114907759288251, 0.0953387770819656, 0.0790128444691345, 0.07196982370419, 0.0656146627695571, 0.0547371607915425, 0.0459324707927209, 0.0388121443782301, 0.033490496060805, 0.0300287601215427, 0.0270579505664697, 0.0244929496405905, 0.0194422524956652, 0.0157837935373634, 0.0130589995454775, 0.0109799010571857, 0.00936140114977358, 0.00811070147972325, 0.00709162942107301, 0.00625152559635035, 0.00555159251216268, 0.00496265971415585, 0.00403475518913186, 0.00334534345908456, 0.0028193809656078, 0.00240904815413363, 0.00208270205208491, 0.00114382901536959 };
            PGAonSa_NEAR[19].Horziantal2 = new List<double>() { 1, 1.00166533933686, 1.00976313834137, 0.991347549104779, 1.0917385529911, 1.09871538589718, 1.11783644648014, 1.20862066613969, 1.20618897420829, 1.22282991459428, 1.24723677211576, 1.27236866995623, 1.32591432071253, 1.39875695513902, 1.50516116827953, 1.3398195582591, 1.39992061717772, 1.4280408355042, 1.67315882158414, 1.76837571004238, 1.95859580959113, 1.86703159835613, 1.6541273038759, 1.84549446148658, 2.14894795028848, 2.09740841572563, 2.14405570713273, 2.50907832313276, 2.96728285210462, 2.81926235251863, 3.08435077165994, 3.63305883401736, 3.26997532530452, 3.10141926444778, 2.99618167834183, 2.57180775204095, 2.10962419863575, 1.87001161685375, 1.93956626854679, 2.46172536271288, 2.6654482510379, 2.96963705881109, 2.65019038238365, 2.48301798625784, 2.24859355421762, 2.40798580122786, 2.85610539097522, 2.92327638366967, 2.75598143438197, 2.70154015721199, 2.8404284695739, 2.89474521691811, 3.02735564472945, 3.12538631425121, 3.15228673328419, 3.00661451041297, 2.82867522601669, 2.29556897183234, 2.09401646047097, 1.91724617510593, 1.97930867761383, 1.82800928794834, 1.48016091625488, 1.43436220666061, 1.39848378018786, 0.979638978151736, 0.832289358293854, 0.76202429359468, 0.694441759475979, 0.704389715892121, 0.709514019389887, 0.482421429092421, 0.344784937979205, 0.238764790634725, 0.166474021002845, 0.135986490688233, 0.120407275783554, 0.109037010857222, 0.0926952187860556, 0.0817048884281944, 0.0893822510208975, 0.0974914553761206, 0.1080303552322, 0.106076126466166, 0.0933426355136529, 0.0747636354723406, 0.0649934602074825, 0.0584417088733826, 0.055574716017639, 0.0518174732740216, 0.0474094139408966, 0.0426369961508424, 0.0377731774219915, 0.0330660290739587, 0.0287061608067477, 0.019881522719083, 0.0140395518586669, 0.0104415886922174, 0.00825767158085079, 0.00688835742985462, 0.00596701461881321, 0.00529316989485532, 0.00476158567187498, 0.00431867459150758, 0.00393620989324236, 0.00330019851635561, 0.00279326329222465, 0.00238549729602262, 0.00205575022400544, 0.00178735879948504, 0.00099517120775548 };
            PGAonSa_NEAR[20].Horziantal2 = new List<double>() { 1, 1.01107561019204, 1.00460964257614, 0.998402355086834, 1.03960125566523, 1.05461008786219, 1.05659896316697, 1.06109262426121, 1.07762578450599, 1.07145556966894, 1.03655736309473, 1.02756465605174, 1.04323831067173, 1.06570910146039, 1.10029312248452, 1.11298688145885, 1.06552332397956, 1.03744876362705, 1.13674589513576, 1.17420646402078, 1.23496584863133, 1.31898366255851, 1.33616694043129, 1.27469012751128, 1.21325887874488, 1.2280802765827, 1.27368688769285, 1.35871788270834, 1.60120947974642, 1.94360835373192, 1.9679667431385, 1.75213493948356, 1.79383028222644, 1.9895948041953, 2.10345258231734, 1.96835921618886, 2.08003882065887, 2.12915904934121, 2.00680914853645, 2.14022078317738, 2.0456950469901, 2.04003100847763, 1.89164616452346, 2.02382653146816, 2.04554944880836, 1.95097421338149, 1.68116711336796, 1.62378589652754, 1.55223671323392, 1.52343954682721, 1.6609699738441, 1.65666064046217, 1.48837151022594, 1.45624463973977, 1.498458171175, 1.77386117058039, 2.14410823391891, 2.85255833402543, 2.85075440776231, 2.68059300503256, 2.69167959204342, 2.75932786245922, 2.81945183423678, 2.73887577078497, 2.38194690243493, 1.86721466536132, 1.45794583954749, 1.13549930131513, 0.795909457399277, 0.884490728419626, 0.863643264157973, 0.800876364361625, 0.710091030965606, 0.557034618608359, 0.435827963839459, 0.352441627659264, 0.278947062116575, 0.253751534942425, 0.186460052560322, 0.193074290074243, 0.185519235632328, 0.176922522506103, 0.181393132280815, 0.163582850232491, 0.151518456485301, 0.141598270384729, 0.143057276005068, 0.145688626586642, 0.130294590892927, 0.104571575796902, 0.0838403001269376, 0.0770961219313319, 0.074817106522985, 0.0718435691478488, 0.0684621290430679, 0.0593932884415962, 0.0506885261383945, 0.0479428302422543, 0.0394836794379537, 0.0352331652361248, 0.0305838818463506, 0.0284448726554395, 0.0246573109652, 0.0224352300378783, 0.020042035002797, 0.0154968657040066, 0.0117591760509838, 0.00890897255526052, 0.00680494420772946, 0.00555207496048863, 0.00325537237615197 };
            PGAonSa_NEAR[21].Horziantal2 = new List<double>() { 1, 0.99728613701872, 1.10650812239812, 1.24060515680773, 1.263066843035, 1.24189515445803, 1.19119955739413, 1.16731681424876, 1.17978523130557, 1.22751514436646, 1.20939713672945, 1.33703014082318, 1.37469657439158, 1.42824083825508, 1.53570756558346, 1.61551891512883, 1.69272686593292, 1.81666025412392, 1.86162013594591, 1.90640870458211, 1.88879246671329, 1.8604087738563, 1.9586901187865, 1.98884030334604, 1.91692433854856, 1.88218052665231, 1.83961247646784, 1.73522845034586, 1.70218185596774, 1.8068542124789, 1.85974318000335, 1.87465398012954, 1.9245501156598, 1.77723013726586, 1.51884585464217, 1.25218237084343, 1.01370879941285, 0.852614960040965, 1.07000249948746, 1.10345631373342, 1.17570273511331, 1.24956586617538, 1.19260282769732, 1.09042059727453, 1.02680162026701, 1.11063180864598, 0.985694880918613, 0.936932408054903, 0.914940662916499, 0.806001203872989, 0.730901060550318, 0.737706313031317, 0.76690210527991, 0.793167225072761, 0.786225670953241, 0.660575406353941, 0.506362178542041, 0.402372734429925, 0.335853322212018, 0.235619100577691, 0.236322139935725, 0.258238713222663, 0.346188000775122, 0.37876699440845, 0.368064132916565, 0.341587820475015, 0.323662844416735, 0.311948673446175, 0.28665432837274, 0.257366981864206, 0.247623755053973, 0.238996404295374, 0.230918659937709, 0.224312055861204, 0.227598928684099, 0.231020698939075, 0.238158186663971, 0.232286825079876, 0.20749200304432, 0.190442690122531, 0.187389851706438, 0.180932374353948, 0.148019085973944, 0.118053226913208, 0.0981661063882968, 0.0853045208894431, 0.0794266905943444, 0.0738285594995034, 0.0631395809286298, 0.0547977708690821, 0.0499701184869395, 0.0455991046779733, 0.0508218071387983, 0.0547647439335941, 0.0549292513988236, 0.0461722643016086, 0.0368740585965986, 0.0266698120890941, 0.0184274572910611, 0.0133111094260634, 0.0113724900980042, 0.0098112372088495, 0.00854006528623812, 0.00749420296774351, 0.00662522385391011, 0.00528021875664073, 0.00430361189980706, 0.00357397687178378, 0.00301535546549912, 0.00257853492589066, 0.0013649916356103 };
            PGAonSa_NEAR[22].Horziantal2 = new List<double>() { 1, 1.0136688281257, 1.02835882474035, 1.06283235589049, 1.07365530812882, 1.09254542723233, 1.10996114338344, 1.04780906717157, 1.05441916441369, 1.24480909584646, 1.29008760393043, 1.35619178622741, 1.38987408299198, 1.4148479867017, 1.41902510508063, 1.38233301477099, 1.35615540763497, 1.30901624154358, 1.29620348729467, 1.37709556741831, 1.45788814139203, 1.49301381230957, 1.55114466311069, 1.58839848168595, 1.58886819351186, 1.69595393015053, 1.71218520213016, 1.6493219244361, 1.80992378042909, 2.01913171575565, 1.98392793786023, 2.0041662048012, 1.6837649617661, 1.73102931301382, 2.32544267397206, 1.99199007591998, 2.01001887834956, 2.32761468993242, 2.6796802878103, 2.27441206844825, 2.23875034827152, 2.37754644797283, 3.02992374619041, 3.05027328882591, 3.02160481806638, 2.71916604002758, 2.2079687092747, 2.04079302763617, 1.8557950455781, 1.91577371488342, 2.04194430309102, 2.10299507091472, 2.46434790945069, 2.40630907508927, 2.27074104048766, 1.98365723833413, 1.66517015123651, 1.58018440950483, 1.20068828296896, 0.996025745771845, 1.0280177219383, 1.29136299458301, 1.53508779438306, 1.50023389295021, 1.40553934687159, 1.1287100279516, 0.910544399216106, 0.672617919067475, 0.584218902402228, 0.56674979531692, 0.350380199089337, 0.29916031788898, 0.279800379963698, 0.258721981529091, 0.290396393982724, 0.267873979419988, 0.229417420381171, 0.216117834968729, 0.284828650409858, 0.336711905942935, 0.337797913923115, 0.333964466246872, 0.313146816723367, 0.272235986645205, 0.210707482306095, 0.178643711917499, 0.168682504336542, 0.156251083333084, 0.128027180372337, 0.10207927194881, 0.0913637221548624, 0.0821829316780075, 0.0727497807654826, 0.0636258478886935, 0.0551503955208965, 0.0385755705340249, 0.031261547528203, 0.0255344871196244, 0.0212238486068497, 0.0183066278799541, 0.0157950177591729, 0.0136646445875716, 0.0118703347130093, 0.0103601202462274, 0.00908799296737611, 0.00710296297215668, 0.00571697069896972, 0.00501274534685704, 0.00437147635883672, 0.00381094644686008, 0.00203214027242858 };
            PGAonSa_NEAR[23].Horziantal2 = new List<double>() { 1, 0.994630572023003, 0.99458985373517, 1.0035282719568, 1.02163132111023, 1.02063986311761, 1.02877554937911, 1.03339416659898, 1.03052859016268, 0.999678131629514, 1.04490279208962, 1.06689799250223, 1.06210831538533, 1.07743153349165, 1.10129266560225, 1.09488028931098, 1.17360231245404, 1.20341046899496, 1.22757946583208, 1.20606555989046, 1.22480135831038, 1.18066596590996, 1.25051161774619, 1.37560595383236, 1.64952907899757, 1.87448727812034, 1.84016865557908, 1.92504495708314, 1.98453480648795, 1.79320043372517, 1.76552470899889, 1.87046413892994, 2.06810790734069, 2.05402713561495, 1.95500155225007, 2.43994106404857, 2.53942941398628, 2.34731019083951, 2.34989547895586, 2.05339330914509, 2.07763771021893, 2.0807579375347, 2.17810739243747, 2.51147383182141, 2.78091255930813, 3.26713415857166, 3.01448687740068, 2.93992070490466, 3.15330392280847, 3.39075832748232, 3.51835306805836, 3.73145190426937, 3.47503872007556, 3.4244360140114, 3.35735640501899, 3.19244949370364, 2.98250901780811, 2.81183906840004, 2.57973405572028, 2.61654209527692, 2.22604294292826, 2.17287864722214, 2.52662577459002, 1.97165016139738, 1.70782129368248, 1.80292370233079, 1.90844245224057, 1.76131413642005, 1.34789403507245, 1.64467541599979, 1.65037339100824, 1.37992467763073, 0.950041892439519, 0.844852120442541, 0.768286012147838, 0.771129613635154, 0.973048371386979, 1.0655338221395, 0.924066425531099, 0.723352412041496, 0.630801898204711, 0.522604574365705, 0.340735587718934, 0.249763392277184, 0.234486709356955, 0.242796256244279, 0.244506855214602, 0.241528603304558, 0.221152439574815, 0.20789450042431, 0.207819419348598, 0.19629118875641, 0.166720081591693, 0.144341138246343, 0.139633263954254, 0.119546824846084, 0.0955478537907541, 0.0733305340408118, 0.0546652493542704, 0.0495542209245033, 0.0492884317620742, 0.0469581823183959, 0.041194584079925, 0.0339032313731607, 0.0268304432325667, 0.0233216040247765, 0.0187674035671375, 0.0146461096045823, 0.0115787514307954, 0.00965906728406219, 0.00558751857367931 };
            PGAonSa_NEAR[24].Horziantal2 = new List<double>() { 1, 0.999074939809003, 1.0089417311415, 1.03046210792038, 1.02973820175749, 1.02567290368323, 1.03397826791482, 1.03486638778275, 1.01617427388983, 1.05809253830308, 1.04418652441848, 1.04080384626369, 1.04168048048495, 1.04498089657579, 1.04828938366157, 1.03848157267683, 1.07837060270465, 1.06106421656094, 1.04857031637059, 1.04186362998586, 1.05072465117781, 1.05515221275639, 1.08344291261099, 1.16138202750843, 1.21184219839002, 1.17517846211537, 1.08027722005133, 1.07022138118316, 1.1363495262326, 1.18893019582717, 1.19152377901367, 1.16139785907546, 1.19494432876018, 1.25603337915175, 1.3279707780315, 1.37427593862567, 1.53567534981555, 1.58594088554957, 1.39430752725823, 1.65927487697941, 1.78703717500276, 1.84942875981092, 1.902000116719, 1.93369894940479, 1.95280951334384, 1.89253718555714, 1.86617328053661, 1.84585268820008, 1.91307041756845, 1.95901952311595, 1.93297255985884, 2.18476773539057, 1.98194301132547, 1.80160159582196, 1.73507828244261, 1.55721745619623, 1.25841246012618, 1.49347273804158, 1.81036949014904, 1.738395771792, 1.68363748567398, 1.64970981668908, 2.01524735116154, 2.05181361465097, 1.65164499294098, 1.44606247198433, 1.29158952658027, 1.26587409496208, 1.307499009751, 1.41664493706486, 1.71256703582156, 2.01697982127092, 1.66366332527476, 1.39276162130147, 1.10179697598444, 0.862401952932441, 0.800474450334201, 0.747306771068091, 0.663451616868628, 0.598365251014152, 0.572683034644435, 0.643273198212461, 0.810022747788858, 0.917131059299462, 0.979844863060049, 0.991224655523727, 0.976476774780748, 0.943372036858371, 0.892041129790291, 0.819306875370179, 0.726790922738228, 0.632962812580322, 0.544683821876866, 0.500544171313697, 0.478950224311575, 0.370007623986004, 0.326625405257074, 0.290322473499198, 0.251819481643453, 0.213798017763639, 0.178231253872525, 0.157446982875832, 0.147807079628436, 0.124510773536573, 0.12147319250068, 0.109678768192333, 0.0873551101194135, 0.0634950760722317, 0.0503978379667053, 0.0431512330617754, 0.0218867378652591 };
            PGAonSa_NEAR[25].Horziantal2 = new List<double>() { 1, 1.00791360619708, 1.00662192124668, 1.00596261066943, 1.02201564868174, 1.02703110724399, 1.05544347797762, 1.10221850961983, 1.10672562563249, 1.15650247797417, 1.15017027752747, 1.12363310509599, 1.11265159053587, 1.10390922624501, 1.15824800664259, 1.20305418969164, 1.25031219373771, 1.21893715376407, 1.17655397623788, 1.20376831231213, 1.25521990748354, 1.26879230902466, 1.31264632857972, 1.33513116835159, 1.34681177137176, 1.28405198186254, 1.36654504657301, 1.38697991592772, 1.57267560134293, 1.56787500599017, 1.62488109701763, 1.76056408169939, 1.63443029458498, 1.75206570930386, 1.77418095929846, 1.72813508443717, 2.09244536570439, 2.21198667346962, 2.34829764756107, 2.0277424109594, 2.14133426294559, 2.22867490476016, 2.60666501917325, 2.76994915634869, 2.83205997126596, 2.79718698329861, 3.12703019893013, 3.42375127986121, 3.73315430153953, 3.87755114824966, 3.88011008763976, 3.57278679148778, 3.57226999222295, 3.65504870598162, 3.64864039509774, 3.16708057589604, 3.46806133561602, 2.87802754320833, 2.58016198681441, 2.17824594570977, 2.13131994603989, 2.23824320823972, 2.37711500099131, 2.37323462154163, 2.34790550654315, 2.44345166783651, 2.27176594067332, 1.91232641417421, 1.67290490361067, 1.57991548922567, 1.65175904375223, 1.8917859924848, 1.95922265873489, 1.73591087749696, 1.40587503668492, 1.12682003389577, 1.028088509861, 0.85418085907072, 0.63942915292842, 0.59157949202704, 0.623984998413583, 0.638186955422775, 0.534425251876999, 0.496328062920467, 0.519853705090535, 0.520247412166833, 0.518127595546005, 0.536768075210893, 0.508165271778469, 0.43073370774657, 0.392823506160404, 0.360130471455611, 0.370356206242371, 0.370471468139012, 0.359771844086986, 0.434288660265246, 0.377432284418753, 0.302792720584804, 0.215764100241518, 0.16485032083838, 0.121402474184311, 0.0896729099149975, 0.0847208140747304, 0.08333112519102, 0.0752956796521095, 0.0625497497595317, 0.0532363379416167, 0.0464699321489547, 0.0412315295159721, 0.0392308586165628, 0.0331971802179264 };
            PGAonSa_NEAR[26].Horziantal2 = new List<double>() { 1, 1.01208214002125, 1.00984152383211, 1.02571485223005, 1.0341985251265, 1.03758249720415, 1.03529254252144, 1.03016226573481, 1.0332923646249, 1.07718995736969, 1.09540906475527, 1.09636085757251, 1.09220600048736, 1.08355995067077, 1.06796342743628, 1.06302865153496, 1.08454440418094, 1.11175840537989, 1.18021012175721, 1.18873641569974, 1.21022807818924, 1.19553655727574, 1.20896844096846, 1.22404586765795, 1.21581768940191, 1.28822505580114, 1.43274120964088, 1.70556732781792, 1.9973160322771, 2.05651272747825, 1.97083631757868, 1.88347938762822, 1.76847923474838, 1.61077858459212, 1.55744158831961, 1.65266557581497, 1.86975216788245, 1.72313206316439, 1.713081603552, 2.1200567693803, 2.40981479302386, 2.50255263004283, 2.60956156841743, 2.70881301313192, 2.66885114970272, 2.45017970330193, 2.63024204121455, 2.44597550772321, 2.13926264663725, 2.03333405912651, 2.49747053356917, 2.6175923926992, 2.30484263105277, 2.21561060671059, 2.20488770744173, 2.10720582907663, 1.99241878142723, 1.56752378208044, 2.14541698671057, 1.60140357590577, 1.68930415582996, 2.10696770714523, 2.63751078266139, 2.26595602249279, 1.91843953231741, 2.54380933938305, 2.39490900869933, 1.8648852613643, 1.80903709791444, 1.24369996080717, 1.23057128879558, 0.815980158976502, 0.646903395692865, 0.740247192801861, 0.69849686688984, 0.57149819462808, 0.514537019621433, 0.461966970542371, 0.551866570182502, 0.476711304491239, 0.455046146547834, 0.474707883689018, 0.426040903232621, 0.46384113838961, 0.456742649491003, 0.372324023723245, 0.338851214560832, 0.304522278298753, 0.250023626884244, 0.22821075458709, 0.215252867886802, 0.200627872866979, 0.18175082624604, 0.170148613101895, 0.170593377615983, 0.152956325472839, 0.122697259003464, 0.114328338640889, 0.0966971005643582, 0.0837394686638024, 0.0658524811471362, 0.06077163550852, 0.0577086416024031, 0.0526550132078916, 0.0461713792263168, 0.0315130286052077, 0.0224915661288694, 0.0167029563254728, 0.0131562830371016, 0.0105965186017703, 0.00555127543480416 };
            PGAonSa_NEAR[27].Horziantal2 = new List<double>() { 1, 1.00325989004675, 1.00353608357576, 1.00431695189865, 1.00491839522824, 1.0048807630199, 1.00539249385285, 1.00887078510867, 1.0109996928943, 1.02181794478414, 1.02418541389045, 1.02078507506618, 1.02386856413637, 1.02779004184567, 1.03549422849605, 1.03361530609433, 1.05900931867559, 1.05822744234712, 1.06706765128652, 1.06556202695138, 1.08959052797316, 1.10097191898054, 1.08408916951764, 1.0407190574207, 1.13973477357171, 1.10405104002656, 1.22613093186084, 1.06634121526497, 1.5303940562615, 1.29002202156191, 1.1844579651593, 1.39252778903384, 1.40028170395951, 1.15439890275233, 1.0750278713543, 1.07806062414362, 1.29082439400385, 1.3569855122718, 1.04843030011014, 0.904941377755467, 0.966353445732676, 1.14508795520692, 1.28734576674616, 1.23840339980122, 1.10130052879973, 1.12060954769446, 1.22591656267409, 1.33607712452296, 1.47925961318122, 1.65524092341375, 1.85863360139562, 1.96946213494238, 1.87338710707102, 1.78896159969142, 1.77783355408656, 1.70529209649705, 1.63673797298142, 1.61607587459604, 1.59125004116023, 1.82839780201023, 1.94996092298367, 2.03475670441312, 1.87983901478879, 1.64340727390267, 1.37505300429343, 1.47741059494505, 1.61470364299937, 1.84415931326596, 2.13640129911759, 1.97181985999474, 1.68323122236805, 1.63620574603501, 1.64049380177369, 1.5238944362796, 1.44978385000339, 1.4077516973134, 1.33961287209686, 1.25813275702294, 1.08414998585432, 0.915293259063482, 0.833407253742557, 0.754261679592658, 0.71883263545747, 0.820523262416781, 0.82112067372405, 0.717238306631266, 0.693044828696172, 0.676219199549489, 0.63772380243897, 0.597205338128752, 0.556730554060347, 0.51886919245985, 0.482827280931827, 0.447235275894487, 0.413637777898739, 0.342721561306563, 0.353531749151763, 0.350432467994143, 0.307892851694827, 0.255041506309779, 0.204303142222195, 0.168889453372014, 0.135542243161858, 0.10697318100353, 0.0904419230864862, 0.069076438407163, 0.0532160754041934, 0.041828804364261, 0.0336746776230153, 0.0277477056112983, 0.0134424264172726 };


            //Vertical
            PGAonSa_NEAR[0].Vertical = new List<double>() { 1, 1.49775784753363, 1.4932735426009, 1.56053811659193, 1.4932735426009, 1.42600896860987, 1.56053811659193, 1.99551569506726, 1.89686098654709, 1.53363228699552, 1.60986547085202, 1.77578475336323, 1.78923766816144, 1.80269058295964, 1.76681614349776, 1.87443946188341, 1.77130044843049, 1.77130044843049, 1.66367713004484, 1.7219730941704, 1.83856502242152, 2.05381165919283, 2.06726457399103, 2.39461883408072, 2.66816143497758, 2.82062780269058, 2.90582959641256, 3.77578475336323, 3.57399103139013, 2.79820627802691, 2.54708520179372, 2.11659192825112, 1.73094170403587, 1.43497757847534, 1.25112107623318, 1.17488789237668, 1.11210762331839, 1.0627802690583, 0.982062780269058, 0.79372197309417, 0.708520179372197, 0.650224215246637, 0.57847533632287, 0.547085201793722, 0.511210762331838, 0.52914798206278, 0.524663677130045, 0.506726457399103, 0.479820627802691, 0.419730941704036, 0.371748878923767, 0.353363228699552, 0.337668161434978, 0.328251121076233, 0.316591928251121, 0.2847533632287, 0.239910313901345, 0.233183856502242, 0.222421524663677, 0.216591928251121, 0.213452914798206, 0.206726457399103, 0.197309417040359, 0.188340807174888, 0.17847533632287, 0.168161434977578, 0.169955156950673, 0.169506726457399, 0.171748878923767, 0.177130044843049, 0.174887892376682, 0.165470852017937, 0.154260089686099, 0.139461883408072, 0.124215246636771, 0.113004484304933, 0.104932735426009, 0.1, 0.089237668161435, 0.0789237668161435, 0.0730941704035874, 0.0690582959641256, 0.062780269058296, 0.0582959641255605, 0.0524663677130045, 0.0520179372197309, 0.0515695067264574, 0.0502242152466368, 0.047085201793722, 0.0475336322869955, 0.0457399103139013, 0.0431390134529148, 0.0395067264573991, 0.0349775784753363, 0.0301345291479821, 0.022780269058296, 0.0173094170403587, 0.0133632286995516, 0.0102690582959641, 0.00847533632286995, 0.00717488789237668, 0.00614349775784753, 0.00538116591928251, 0.0047085201793722, 0.00416143497757848, 0.0032780269058296, 0.00261883408071749, 0.00218385650224215, 0.00191479820627803, 0.00169506726457399, 0.000995515695067265 };
            PGAonSa_NEAR[1].Vertical = new List<double>() { 1, 1.17966101694915, 1.21864406779661, 1.71186440677966, 1.84745762711864, 1.86440677966102, 1.8135593220339, 2.16949152542373, 2.10169491525424, 2.50847457627119, 3, 3.40677966101695, 3.30508474576271, 3.33898305084746, 3.01694915254237, 2.30508474576271, 2.33898305084746, 2.06779661016949, 2.84745762711864, 2.96610169491525, 2.93220338983051, 2.8135593220339, 3.08474576271186, 2.52542372881356, 1.93220338983051, 1.84745762711864, 1.93220338983051, 2.08474576271186, 1.86440677966102, 1.56440677966102, 1.43389830508475, 1.27796610169492, 1.08474576271186, 0.95593220338983, 0.972881355932203, 0.864406779661017, 0.625423728813559, 0.567796610169492, 0.603389830508475, 0.703389830508475, 0.694915254237288, 0.672881355932203, 0.747457627118644, 0.827118644067797, 0.872881355932204, 0.861016949152542, 0.855932203389831, 0.840677966101695, 0.813559322033898, 0.723728813559322, 0.620338983050847, 0.525423728813559, 0.461016949152542, 0.488135593220339, 0.505084745762712, 0.522033898305085, 0.535593220338983, 0.596610169491525, 0.566101694915254, 0.447457627118644, 0.413559322033898, 0.367796610169492, 0.323728813559322, 0.355932203389831, 0.403389830508475, 0.445762711864407, 0.476271186440678, 0.496610169491525, 0.5, 0.466101694915254, 0.440677966101695, 0.447457627118644, 0.466101694915254, 0.471186440677966, 0.447457627118644, 0.406779661016949, 0.355932203389831, 0.313559322033898, 0.230508474576271, 0.15728813559322, 0.132372881355932, 0.116610169491525, 0.105423728813559, 0.106271186440678, 0.107627118644068, 0.106610169491525, 0.104915254237288, 0.102542372881356, 0.0974576271186441, 0.0920338983050848, 0.0886440677966102, 0.0876271186440678, 0.0888135593220339, 0.0871186440677966, 0.0825423728813559, 0.0661016949152542, 0.0491525423728814, 0.038135593220339, 0.0293220338983051, 0.0225423728813559, 0.0176271186440678, 0.013864406779661, 0.0118305084745763, 0.010271186440678, 0.00903389830508475, 0.00720338983050848, 0.00591525423728814, 0.00494915254237288, 0.00420338983050847, 0.00361016949152542, 0.00188135593220339 };
            PGAonSa_NEAR[2].Vertical = new List<double>() { 1, 1.05371900826446, 1.26859504132231, 1.36776859504132, 1.38842975206612, 1.39256198347107, 1.42148760330579, 1.67768595041322, 1.66942148760331, 2.08677685950413, 2.06611570247934, 1.94628099173554, 1.87603305785124, 1.93801652892562, 2.15702479338843, 2.07438016528926, 2.1900826446281, 2.4297520661157, 2.51239669421488, 2.25619834710744, 2.28925619834711, 2.52892561983471, 2.46280991735537, 2.09090909090909, 2.13636363636364, 2.02066115702479, 1.88842975206612, 1.83057851239669, 1.33471074380165, 1.53305785123967, 1.53305785123967, 1.32644628099174, 1.08677685950413, 1.21074380165289, 1.52892561983471, 1.57438016528926, 1.58264462809917, 1.78925619834711, 1.75206611570248, 1.42148760330579, 1.26446280991736, 1.22314049586777, 1.34297520661157, 1.52479338842975, 1.49173553719008, 1.36776859504132, 1.10743801652893, 0.933884297520661, 0.797520661157025, 0.809917355371901, 0.834710743801653, 1.07438016528926, 1.03305785123967, 1, 0.995867768595041, 0.966942148760331, 0.962809917355372, 0.834710743801653, 0.739669421487603, 0.694214876033058, 0.71900826446281, 0.805785123966942, 0.685950413223141, 0.661157024793388, 0.628099173553719, 0.603305785123967, 0.607438016528926, 0.690082644628099, 0.900826446280992, 0.776859504132231, 0.665289256198347, 0.690082644628099, 0.809917355371901, 0.87603305785124, 0.847107438016529, 0.78099173553719, 0.698347107438017, 0.65702479338843, 0.578512396694215, 0.5, 0.458677685950413, 0.421487603305785, 0.383471074380165, 0.368595041322314, 0.351652892561983, 0.331818181818182, 0.320661157024793, 0.308264462809917, 0.282231404958678, 0.25495867768595, 0.227685950413223, 0.2, 0.173140495867769, 0.153719008264463, 0.153305785123967, 0.129752066115702, 0.103719008264463, 0.0818181818181818, 0.0694214876033058, 0.0586776859504132, 0.0504132231404959, 0.0429752066115702, 0.0373140495867769, 0.0324380165289256, 0.0283884297520661, 0.0221900826446281, 0.0177685950413223, 0.014504132231405, 0.0120247933884298, 0.0101652892561983, 0.00516528925619835 };
            PGAonSa_NEAR[3].Vertical = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            PGAonSa_NEAR[4].Vertical = new List<double>() { 1, 1.10869565217391, 1.10386473429952, 1.26328502415459, 1.33333333333333, 1.30434782608696, 1.31159420289855, 1.52415458937198, 1.59420289855072, 1.91062801932367, 2.05314009661836, 2.06280193236715, 1.97584541062802, 1.92753623188406, 2.02173913043478, 2.04830917874396, 2.7536231884058, 2.9951690821256, 2.77777777777778, 2.38164251207729, 2.3792270531401, 2.89855072463768, 3.30917874396135, 2.77777777777778, 2.39613526570048, 2.23188405797101, 2.09661835748792, 1.65700483091787, 1.39371980676328, 1.27294685990338, 1.14251207729469, 1.30193236714976, 1.15700483091787, 0.975845410628019, 1.11835748792271, 1.09661835748792, 1.11111111111111, 1.07971014492754, 0.756038647342995, 0.794685990338164, 0.714975845410628, 0.690821256038647, 0.688405797101449, 0.611111111111111, 0.541062801932367, 0.630434782608696, 0.688405797101449, 0.695652173913043, 0.816425120772947, 0.971014492753623, 0.961352657004831, 0.908212560386473, 0.830917874396135, 0.806763285024155, 0.789855072463768, 0.717391304347826, 0.613526570048309, 0.71256038647343, 0.702898550724638, 0.968599033816425, 1.08454106280193, 1.11594202898551, 0.91304347826087, 0.642512077294686, 0.582125603864734, 0.642512077294686, 0.606280193236715, 0.56280193236715, 0.690821256038647, 0.833333333333333, 0.780193236714976, 0.492753623188406, 0.333333333333333, 0.347826086956522, 0.36231884057971, 0.357487922705314, 0.342995169082126, 0.301932367149758, 0.251207729468599, 0.208454106280193, 0.206763285024155, 0.206038647342995, 0.195652173913043, 0.179468599033816, 0.16280193236715, 0.153381642512077, 0.149275362318841, 0.145169082125604, 0.135748792270531, 0.12487922705314, 0.113768115942029, 0.116908212560386, 0.118599033816425, 0.117632850241546, 0.114492753623188, 0.101207729468599, 0.0884057971014493, 0.0830917874396135, 0.0731884057971015, 0.0601449275362319, 0.0502415458937198, 0.0420289855072464, 0.0357487922705314, 0.0316425120772947, 0.027536231884058, 0.0205072463768116, 0.0152415458937198, 0.01243961352657, 0.0102657004830918, 0.00867149758454106, 0.00439613526570048 };
            PGAonSa_NEAR[5].Vertical = new List<double>(){
                    1,1.01276595744681,1.0468085106383,1.08085106382979,1.19574468085106,1.20425531914894,1.13617021276596,1.09787234042553,1.14042553191489,1.28085106382979,1.33191489361702,1.45531914893617,1.4468085106383,1.44255319148936,1.40851063829787,1.38297872340426,1.52340425531915,1.72765957446809,1.83829787234043,2.03829787234043,2.55744680851064,2.53191489361702,1.88085106382979,1.77446808510638,1.91914893617021,2.00851063829787,1.94468085106383,2.17872340425532,2.54042553191489,1.86808510638298,1.88510638297872,2.02978723404255,2.47234042553192,2.84255319148936,2.27659574468085,1.94042553191489,2.20425531914894,1.82553191489362,1.88085106382979,1.70212765957447,1.70212765957447,1.83404255319149,2.57021276595745,2.55744680851064,2.2,1.99148936170213,2.05531914893617,1.9063829787234,1.71063829787234,1.51063829787234,1.34468085106383,1.34893617021277,1.28510638297872,1.20851063829787,1.11914893617021,1.02553191489362,1.18723404255319,1.05531914893617,1,0.731914893617021,0.702127659574468,0.736170212765957,0.6,0.65531914893617,0.672340425531915,0.672340425531915,0.642553191489362,0.612765957446809,0.748936170212766,0.719148936170213,0.634042553191489,0.595744680851064,0.519148936170213,0.380425531914894,0.376170212765957,0.379148936170213,0.35063829787234,0.314893617021277,0.282553191489362,0.287659574468085,0.285957446808511,0.259148936170213,0.28468085106383,0.313617021276596,0.348510638297872,0.353617021276596,0.348510638297872,0.338297872340426,0.317872340425532,0.32468085106383,0.298297872340426,0.281702127659574,0.257446808510638,0.231489361702128,0.20468085106383,0.135744680851064,0.105531914893617,0.0842553191489362,0.0680851063829787,0.0553191489361702,0.0451063829787234,0.0370212765957447,0.0307234042553192,0.0265106382978723,0.0236595744680851,0.0191063829787234,0.0157021276595745,0.0131063829787234,0.0111063829787234,0.00948936170212766,0.00502127659574468};
            PGAonSa_NEAR[6].Vertical = new List<double>() { 1, 1, 1.01807228915663, 1.02409638554217, 1.09036144578313, 1.1144578313253, 1.12048192771084, 1.1144578313253, 1.12048192771084, 1.13253012048193, 1.14457831325301, 1.16265060240964, 1.16265060240964, 1.16867469879518, 1.17469879518072, 1.13855421686747, 1.2710843373494, 1.33132530120482, 1.25301204819277, 1.2289156626506, 1.34939759036145, 1.51204819277108, 1.59036144578313, 1.79518072289157, 1.93373493975904, 2.1566265060241, 2.49397590361446, 1.92771084337349, 2.54819277108434, 2.62048192771084, 2.4578313253012, 2.5, 2.56024096385542, 2.26506024096386, 2.08433734939759, 2.4578313253012, 2.83132530120482, 2.89156626506024, 2.78915662650602, 2.26506024096386, 2.01807228915663, 2.01807228915663, 2.56626506024096, 2.26506024096386, 2.16867469879518, 2.44578313253012, 2.50602409638554, 2.51807228915663, 2.44578313253012, 1.90963855421687, 1.96385542168675, 2.64457831325301, 3.1566265060241, 3.09638554216867, 2.84939759036145, 2.37951807228916, 2.14457831325301, 1.53614457831325, 1.52409638554217, 1.60240963855422, 1.46385542168675, 1.18674698795181, 0.91566265060241, 0.94578313253012, 0.993975903614458, 0.903614457831325, 0.933734939759036, 0.909638554216867, 0.765060240963855, 0.704819277108434, 0.620481927710843, 0.680722891566265, 0.57289156626506, 0.516265060240964, 0.513855421686747, 0.483734939759036, 0.414457831325301, 0.448795180722892, 0.478915662650602, 0.564457831325301, 0.552409638554217, 0.545180722891566, 0.486144578313253, 0.460240963855422, 0.436144578313253, 0.407228915662651, 0.396385542168675, 0.386144578313253, 0.363855421686747, 0.398795180722891, 0.406024096385542, 0.378313253012048, 0.343975903614458, 0.305421686746988, 0.268072289156626, 0.220481927710843, 0.19578313253012, 0.162650602409639, 0.129518072289157, 0.100602409638554, 0.100602409638554, 0.100602409638554, 0.0909638554216868, 0.0855421686746988, 0.0795180722891566, 0.0644578313253012, 0.0525903614457831, 0.042289156626506, 0.0331927710843373, 0.0257228915662651, 0.0115060240963855 };
            PGAonSa_NEAR[7].Vertical = new List<double>() { 1, 1.24559341950646, 1.35135135135135, 1.99764982373678, 2.22091656874266, 2.23266745005875, 2.58519388954172, 2.49118683901293, 2.47943595769683, 2.36192714453584, 2.13866039952996, 2.29142185663925, 2.30317273795535, 2.29142185663925, 2.12690951821387, 2.25616921269095, 3.21974148061105, 2.737955346651, 2.90246768507638, 2.90246768507638, 3.6545240893067, 4.30082256169213, 4.84136310223267, 4.46533490011751, 3.23149236192714, 2.7027027027027, 2.03290246768508, 1.90364277320799, 1.52761457109283, 1.25734430082256, 1.16451233842538, 1.25734430082256, 1.19858989424207, 1.12338425381904, 1.08695652173913, 0.701527614571093, 0.646298472385429, 0.695652173913043, 0.72855464159812, 0.54406580493537, 0.491186839012926, 0.438307873090482, 0.410105757931845, 0.459459459459459, 0.511163337250294, 0.54171562867215, 0.568742655699177, 0.54171562867215, 0.508813160987074, 0.423031727379553, 0.391304347826087, 0.438307873090482, 0.432432432432432, 0.414806110458284, 0.404230317273795, 0.421856639247944, 0.45593419506463, 0.373678025851939, 0.343125734430082, 0.394829612220917, 0.376028202115159, 0.353701527614571, 0.333725029377203, 0.312573443008226, 0.316098707403055, 0.356051703877791, 0.380728554641598, 0.394829612220917, 0.403055229142186, 0.399529964747356, 0.405405405405405, 0.424206815511163, 0.401880141010576, 0.36780258519389, 0.331374853113984, 0.290246768507638, 0.257344300822562, 0.230317273795535, 0.186839012925969, 0.160987074030552, 0.150411280846063, 0.141010575793184, 0.132784958871915, 0.115041128084606, 0.099882491186839, 0.0949471210340776, 0.0924794359576968, 0.0901292596944771, 0.0857814336075206, 0.081786133960047, 0.0780258519388954, 0.0745005875440658, 0.0709753231492362, 0.0674500587544066, 0.063924794359577, 0.0561692126909518, 0.0566392479435958, 0.054289071680376, 0.0490011750881316, 0.0433607520564042, 0.0368977673325499, 0.0301997649823737, 0.027614571092832, 0.0252643948296122, 0.0229142185663925, 0.0188014101057579, 0.0153936545240893, 0.0123384253819036, 0.00978848413631022, 0.00814336075205641, 0.0045710928319624 };
            PGAonSa_NEAR[8].Vertical = new List<double>() { 1, 0.996926229508197, 1.00102459016393, 1.00204918032787, 1.09631147540984, 1.14754098360656, 1.12704918032787, 1.11680327868852, 1.17827868852459, 1.39344262295082, 1.62909836065574, 1.9672131147541, 2.03893442622951, 2.02868852459016, 1.98770491803279, 2.02868852459016, 2.52049180327869, 2.89959016393443, 2.44877049180328, 2.46926229508197, 2.53073770491803, 3.41188524590164, 4.06762295081967, 3.37090163934426, 2.82786885245902, 2.46926229508197, 2.30532786885246, 2.34631147540984, 2.86885245901639, 2.42827868852459, 2.37704918032787, 2.75614754098361, 2.57172131147541, 2.39754098360656, 2.47950819672131, 2.45901639344262, 2.32581967213115, 2.17213114754098, 2.45901639344262, 2.37704918032787, 2.35655737704918, 2.16188524590164, 1.74180327868852, 1.50614754098361, 1.19877049180328, 0.901639344262295, 0.801229508196721, 0.73155737704918, 0.676229508196721, 0.639344262295082, 0.670081967213115, 0.725409836065574, 0.774590163934426, 0.795081967213115, 0.819672131147541, 0.876024590163934, 0.920081967213115, 0.902663934426229, 0.83094262295082, 0.719262295081967, 0.680327868852459, 0.609631147540984, 0.504098360655738, 0.454918032786885, 0.434426229508197, 0.4375, 0.425204918032787, 0.404713114754098, 0.283811475409836, 0.233606557377049, 0.189549180327869, 0.149590163934426, 0.123975409836066, 0.129098360655738, 0.14344262295082, 0.146516393442623, 0.144467213114754, 0.130122950819672, 0.0870901639344262, 0.0579918032786885, 0.0461065573770492, 0.0361680327868852, 0.025922131147541, 0.0221311475409836, 0.0190573770491803, 0.0165983606557377, 0.0154713114754098, 0.0145491803278689, 0.0128073770491803, 0.0113729508196721, 0.0101946721311475, 0.00917008196721312, 0.00828893442622951, 0.00754098360655738, 0.00688524590163934, 0.00557377049180328, 0.00462090163934426, 0.00389344262295082, 0.00331967213114754, 0.00286885245901639, 0.00251024590163934, 0.00221311475409836, 0.0019672131147541, 0.00175204918032787, 0.00157786885245902, 0.00130122950819672, 0.00108606557377049, 0.000923155737704918, 0.00079405737704918, 0.000690573770491803, 0.000386270491803279 };
            PGAonSa_NEAR[9].Vertical = new List<double>() { 1, 1, 1.09157509157509, 1.13003663003663, 1.01648351648352, 0.994505494505495, 0.941391941391941, 0.928571428571428, 0.948717948717949, 1.04945054945055, 1.1025641025641, 1.12454212454212, 1.13369963369963, 1.15750915750916, 1.21794871794872, 1.25457875457875, 1.33516483516484, 1.3956043956044, 1.46886446886447, 1.503663003663, 1.51282051282051, 1.50549450549451, 1.84981684981685, 1.83150183150183, 1.95970695970696, 2.01465201465201, 2.36263736263736, 2.27106227106227, 2.41758241758242, 2.58241758241758, 2.67399267399267, 2.52747252747253, 2.21611721611722, 2.1978021978022, 2.28937728937729, 1.88644688644689, 1.66849816849817, 1.62271062271062, 1.14468864468864, 1, 1.02380952380952, 0.915750915750916, 0.657509157509157, 0.646520146520146, 0.703296703296703, 0.677655677655678, 0.778388278388278, 0.78021978021978, 0.706959706959707, 0.582417582417582, 0.65018315018315, 0.646520146520146, 0.595238095238095, 0.564102564102564, 0.529304029304029, 0.402930402930403, 0.419413919413919, 0.461538461538462, 0.672161172161172, 0.498168498168498, 0.474358974358974, 0.470695970695971, 0.639194139194139, 0.598901098901099, 0.529304029304029, 0.498168498168498, 0.357142857142857, 0.326007326007326, 0.326007326007326, 0.293040293040293, 0.272893772893773, 0.252747252747253, 0.247252747252747, 0.230769230769231, 0.210622710622711, 0.206959706959707, 0.19047619047619, 0.184981684981685, 0.217948717948718, 0.250915750915751, 0.250915750915751, 0.241758241758242, 0.214285714285714, 0.184981684981685, 0.158241758241758, 0.127472527472527, 0.116483516483516, 0.10970695970696, 0.0946886446886447, 0.0791208791208791, 0.0677655677655678, 0.0620879120879121, 0.0565934065934066, 0.0512820512820513, 0.0463369963369963, 0.0353479853479853, 0.0296703296703297, 0.0272893772893773, 0.0227106227106227, 0.0178021978021978, 0.014010989010989, 0.0124175824175824, 0.0112637362637363, 0.0100915750915751, 0.00895604395604396, 0.00701465201465201, 0.00551282051282051, 0.00439560439560439, 0.00368131868131868, 0.00315018315018315, 0.00165934065934066 };
            PGAonSa_NEAR[10].Vertical = new List<double>() { 1, 1.02054794520548, 1.01369863013699, 1.04109589041096, 1.07534246575342, 1.08904109589041, 1.14383561643836, 1.25342465753425, 1.26027397260274, 1.47260273972603, 1.47945205479452, 1.56164383561644, 1.61643835616438, 1.63698630136986, 1.67123287671233, 1.79452054794521, 1.76027397260274, 2.24657534246575, 2.58219178082192, 2.71917808219178, 2.76027397260274, 3.32876712328767, 4.36986301369863, 3.64383561643836, 3.00684931506849, 2.94520547945206, 2.58219178082192, 2.8013698630137, 3.37671232876712, 3.6027397260274, 3.21917808219178, 2.46575342465753, 2.61643835616438, 2.17123287671233, 2.08219178082192, 1.83561643835616, 2.02054794520548, 1.93835616438356, 1.51369863013699, 1.25342465753425, 1.19178082191781, 1.36986301369863, 1.46575342465753, 1.45205479452055, 1.47260273972603, 1.51369863013699, 1.64383561643836, 1.68493150684932, 1.77397260273973, 1.6027397260274, 1.48630136986301, 1.36986301369863, 1.14383561643836, 1.06849315068493, 1.04794520547945, 0.904109589041096, 0.883561643835617, 0.732876712328767, 0.904109589041096, 0.842465753424658, 0.849315068493151, 0.842465753424658, 0.780821917808219, 0.63972602739726, 0.507534246575343, 0.455479452054795, 0.472602739726027, 0.565068493150685, 0.767123287671233, 0.712328767123288, 0.51986301369863, 0.508904109589041, 0.502054794520548, 0.458904109589041, 0.443150684931507, 0.455479452054795, 0.453424657534247, 0.432876712328767, 0.445205479452055, 0.445205479452055, 0.446575342465753, 0.434246575342466, 0.394520547945205, 0.354794520547945, 0.314383561643836, 0.297260273972603, 0.277397260273973, 0.271917808219178, 0.257534246575343, 0.243150684931507, 0.213013698630137, 0.184931506849315, 0.16986301369863, 0.154794520547945, 0.141095890410959, 0.111643835616438, 0.0883561643835617, 0.0719178082191781, 0.0801369863013699, 0.086986301369863, 0.0965753424657534, 0.0924657534246575, 0.0821917808219178, 0.0594520547945206, 0.0517808219178082, 0.0427397260273973, 0.0350684931506849, 0.0283561643835616, 0.0227397260273973, 0.0193150684931507, 0.00945205479452055 };
            PGAonSa_NEAR[11].Vertical = new List<double>() { 1, 1.01515151515152, 1.01515151515152, 1.00378787878788, 1.04924242424242, 1.03409090909091, 1.0530303030303, 1.07575757575758, 1.05681818181818, 1.06439393939394, 1.10606060606061, 1.09848484848485, 1.07575757575758, 1.04924242424242, 1.02272727272727, 1.03409090909091, 1.22727272727273, 1.37878787878788, 1.57575757575758, 1.61363636363636, 1.60227272727273, 1.62878787878788, 1.56439393939394, 1.5, 1.58712121212121, 1.65530303030303, 1.67045454545455, 1.43181818181818, 2.10227272727273, 2.57575757575758, 2.50378787878788, 2.58333333333333, 2.54545454545455, 2.08712121212121, 1.71590909090909, 1.76515151515152, 2.26515151515152, 2.41666666666667, 1.73863636363636, 1.67424242424242, 1.45075757575758, 1.34090909090909, 1.45833333333333, 1.54545454545455, 1.53409090909091, 1.62121212121212, 1.78409090909091, 1.89015151515152, 1.90909090909091, 1.73106060606061, 1.58333333333333, 1.56060606060606, 1.64772727272727, 1.66287878787879, 1.65151515151515, 1.48863636363636, 1.50378787878788, 1.31439393939394, 1.48484848484848, 1.45454545454545, 1.43560606060606, 1.67045454545455, 1.86363636363636, 1.48106060606061, 1.26893939393939, 1.13257575757576, 1.20454545454545, 1.46969696969697, 1.56439393939394, 1.32954545454545, 1.31818181818182, 1.66287878787879, 2.07575757575758, 2.18939393939394, 2.06060606060606, 1.84469696969697, 1.58712121212121, 1.45075757575758, 1.23863636363636, 1.13636363636364, 1.11363636363636, 1.09469696969697, 1.12121212121212, 1.35606060606061, 1.5, 1.56439393939394, 1.56439393939394, 1.54924242424242, 1.47348484848485, 1.36742424242424, 1.25757575757576, 1.14772727272727, 1.04166666666667, 1.01136363636364, 0.950757575757576, 0.715909090909091, 0.511363636363636, 0.393939393939394, 0.303030303030303, 0.237121212121212, 0.203787878787879, 0.175757575757576, 0.152272727272727, 0.132575757575758, 0.116287878787879, 0.090530303030303, 0.0727272727272727, 0.059469696969697, 0.05, 0.0424242424242424, 0.0228030303030303 };
            PGAonSa_NEAR[12].Vertical = new List<double>() { 1, 1.00561797752809, 1.00561797752809, 1.02247191011236, 1.02808988764045, 1.03932584269663, 1.04494382022472, 1.06741573033708, 1.08988764044944, 1.12359550561798, 1.10112359550562, 1.14606741573034, 1.14606741573034, 1.12921348314607, 1.15730337078652, 1.20224719101124, 1.24157303370787, 1.23595505617978, 1.3876404494382, 1.41573033707865, 1.33707865168539, 1.2752808988764, 1.34831460674157, 1.34269662921348, 1.17415730337079, 1.06179775280899, 1.12921348314607, 1.14606741573034, 1.03370786516854, 1.1123595505618, 1.18539325842697, 1.20224719101124, 1.05056179775281, 1.17977528089888, 1.14606741573034, 1.12359550561798, 1.28089887640449, 1.20786516853933, 1.23033707865169, 1.30898876404494, 1.20786516853933, 1.18539325842697, 0.98876404494382, 1.17415730337079, 1.34831460674157, 1.28651685393258, 1.06179775280899, 1.02247191011236, 0.97752808988764, 1.06741573033708, 1.06179775280899, 1.01685393258427, 0.938202247191011, 0.955056179775281, 0.910112359550562, 0.955056179775281, 1.04494382022472, 1.26966292134831, 1.30337078651685, 1.28651685393258, 1.18539325842697, 1.19662921348315, 1.28089887640449, 1.17977528089888, 1.34269662921348, 1.57303370786517, 1.63483146067416, 1.60112359550562, 1.66292134831461, 1.78651685393258, 1.53370786516854, 1.47191011235955, 1.52247191011236, 1.86516853932584, 1.85393258426966, 1.7247191011236, 1.64606741573034, 1.65730337078652, 1.97191011235955, 1.8876404494382, 1.75842696629214, 1.66292134831461, 1.51123595505618, 1.42134831460674, 1.26404494382022, 1.12359550561798, 1.07865168539326, 1.03932584269663, 0.966292134831461, 0.904494382022472, 0.842696629213483, 0.780898876404495, 0.724719101123596, 0.668539325842697, 0.617977528089888, 0.55561797752809, 0.494943820224719, 0.401685393258427, 0.321348314606742, 0.288202247191011, 0.267977528089888, 0.242696629213483, 0.216292134831461, 0.190449438202247, 0.16685393258427, 0.133707865168539, 0.105056179775281, 0.0853932584269663, 0.0735955056179775, 0.0634831460674157, 0.0343820224719101 };
            PGAonSa_NEAR[13].Vertical = new List<double>() { 1, 1.11781609195402, 1.14655172413793, 1.23850574712644, 1.22701149425287, 1.26149425287356, 1.33045977011494, 1.42241379310345, 1.49137931034483, 1.49137931034483, 1.51149425287356, 1.72126436781609, 1.82183908045977, 1.84770114942529, 1.91954022988506, 2.10057471264368, 2.55459770114943, 3.47701149425287, 3.04597701149425, 2.79885057471264, 2.83333333333333, 3.24712643678161, 3.10344827586207, 2.50862068965517, 1.97126436781609, 2.08908045977011, 2.5, 2.64942528735632, 2.61494252873563, 2.22988505747126, 2.24425287356322, 2.6551724137931, 2.36206896551724, 2.17241379310345, 2.04310344827586, 2.00574712643678, 1.74425287356322, 1.8735632183908, 2.06609195402299, 1.17816091954023, 1.2816091954023, 1.14942528735632, 1.01724137931034, 1.13793103448276, 1.13793103448276, 1.06609195402299, 1.19252873563218, 1.1867816091954, 1.18390804597701, 1.01149425287356, 0.816091954022989, 0.71551724137931, 0.701149425287356, 0.686781609195402, 0.655172413793104, 0.563218390804598, 0.485632183908046, 0.413793103448276, 0.600574712643678, 0.514367816091954, 0.488505747126437, 0.53735632183908, 0.416666666666667, 0.436781609195402, 0.442528735632184, 0.385057471264368, 0.376436781609195, 0.396551724137931, 0.353448275862069, 0.313218390804598, 0.32183908045977, 0.270977011494253, 0.256034482758621, 0.199137931034483, 0.165229885057471, 0.207758620689655, 0.211206896551724, 0.198275862068966, 0.225574712643678, 0.254310344827586, 0.259770114942529, 0.238793103448276, 0.200862068965517, 0.161206896551724, 0.170977011494253, 0.175862068965517, 0.191954022988506, 0.203448275862069, 0.196551724137931, 0.16551724137931, 0.133045977011494, 0.118390804597701, 0.122988505747126, 0.134195402298851, 0.147701149425287, 0.170114942528736, 0.157183908045977, 0.15316091954023, 0.141666666666667, 0.12183908045977, 0.0974137931034483, 0.0841954022988506, 0.0744252873563218, 0.0649425287356322, 0.0563218390804598, 0.042816091954023, 0.0318965517241379, 0.0235919540229885, 0.0200574712643678, 0.0173563218390805, 0.0089367816091954 };
            PGAonSa_NEAR[14].Vertical = new List<double>() { 1, 1.32044198895028, 1.90055248618785, 2.09944751381215, 2.16022099447514, 2.22651933701657, 2.17127071823204, 2.19889502762431, 2.38121546961326, 2.72375690607735, 2.89502762430939, 2.93922651933702, 3.02762430939227, 3.13812154696133, 3.21546961325967, 3.32044198895028, 2.37016574585635, 2.09944751381215, 1.98342541436464, 2.24309392265193, 2.54696132596685, 2.50276243093923, 2.06629834254144, 2.12707182320442, 2.5414364640884, 2.44198895027624, 2.16574585635359, 1.96132596685083, 1.27624309392265, 1.30939226519337, 1.30386740331492, 1.23204419889503, 1.14917127071823, 1.25966850828729, 1.42541436464088, 1.58011049723757, 1.53591160220994, 1.33149171270718, 1.20994475138122, 0.933701657458563, 0.773480662983425, 0.685082872928177, 0.845303867403315, 0.911602209944751, 0.972375690607735, 0.839779005524862, 0.61878453038674, 0.635359116022099, 0.679558011049724, 0.674033149171271, 0.508839779005525, 0.514364640883978, 0.527624309392265, 0.558011049723757, 0.569060773480663, 0.61878453038674, 0.646408839779005, 0.668508287292818, 0.701657458563536, 0.685082872928177, 0.668508287292818, 0.61878453038674, 0.471823204419889, 0.358563535911602, 0.312707182320442, 0.260773480662983, 0.233701657458564, 0.255801104972376, 0.252486187845304, 0.204972375690608, 0.166298342541436, 0.148066298342541, 0.124309392265193, 0.107182320441989, 0.0983425414364641, 0.0883977900552486, 0.0795580110497238, 0.0674033149171271, 0.0558011049723757, 0.0530939226519337, 0.0496132596685083, 0.0448066298342541, 0.0430386740331492, 0.0366298342541436, 0.0287292817679558, 0.0256353591160221, 0.0242541436464088, 0.0228176795580111, 0.0202209944751381, 0.0178453038674033, 0.0157458563535912, 0.0140331491712707, 0.0125414364640884, 0.0112707182320442, 0.0101657458563536, 0.00812154696132597, 0.00657458563535912, 0.00547513812154696, 0.00462430939226519, 0.00396132596685083, 0.00343093922651934, 0.003, 0.00265193370165746, 0.00235911602209945, 0.00211049723756906, 0.00172375690607735, 0.00143646408839779, 0.00121546961325967, 0.00104419889502762, 0.000906077348066298, 0.000503314917127072 };
            PGAonSa_NEAR[15].Vertical = new List<double>() { 1, 1.58458646616541, 1.69736842105263, 1.70864661654135, 1.74624060150376, 1.83082706766917, 2.23684210526316, 3.1203007518797, 3.28947368421053, 2.98872180451128, 2.61278195488722, 2.53759398496241, 2.5187969924812, 2.34962406015038, 2.14285714285714, 2.25563909774436, 1.99248120300752, 1.8515037593985, 2.23684210526316, 2.19924812030075, 2.19924812030075, 1.93609022556391, 1.61466165413534, 1.56015037593985, 2.08646616541353, 1.80263157894737, 1.77067669172932, 1.70300751879699, 1.74624060150376, 2.10526315789474, 2.18045112781955, 2.19924812030075, 1.74624060150376, 1.13345864661654, 1.1203007518797, 1.41917293233083, 1.34210526315789, 1.09398496240601, 0.684210526315789, 0.567669172932331, 0.599624060150376, 0.629699248120301, 0.554511278195489, 0.550751879699248, 0.610902255639098, 0.648496240601504, 0.697368421052632, 0.674812030075188, 0.605263157894737, 0.518796992481203, 0.451127819548872, 0.383458646616541, 0.353383458646617, 0.332706766917293, 0.302631578947368, 0.330827067669173, 0.330827067669173, 0.293233082706767, 0.231203007518797, 0.283834586466165, 0.31015037593985, 0.332706766917293, 0.332706766917293, 0.327067669172932, 0.317669172932331, 0.338345864661654, 0.342105263157895, 0.332706766917293, 0.296992481203008, 0.25187969924812, 0.186842105263158, 0.133646616541353, 0.0922932330827068, 0.081203007518797, 0.0849624060150376, 0.0845864661654135, 0.0883458646616541, 0.0947368421052631, 0.0834586466165414, 0.0659774436090226, 0.0616541353383459, 0.0605263157894737, 0.0605263157894737, 0.0593984962406015, 0.0569548872180451, 0.056015037593985, 0.0545112781954887, 0.0520676691729323, 0.0456766917293233, 0.0394736842105263, 0.0334586466165414, 0.0293233082706767, 0.0268796992481203, 0.0244360902255639, 0.0223684210526316, 0.0178571428571429, 0.0142481203007519, 0.011296992481203, 0.00900375939849624, 0.00712406015037594, 0.0056203007518797, 0.00468045112781955, 0.00426691729323308, 0.00389097744360902, 0.00355263157894737, 0.00293233082706767, 0.00244360902255639, 0.00204887218045113, 0.00172744360902256, 0.00146804511278195, 0.000733082706766917 };
            PGAonSa_NEAR[16].Vertical = new List<double>() { 1, 0.981900452488688, 0.995475113122172, 0.995475113122172, 1.06334841628959, 1.03619909502262, 1.26244343891403, 1.35294117647059, 1.46153846153846, 1.61085972850679, 1.50226244343891, 1.6606334841629, 1.79185520361991, 1.90497737556561, 2.07239819004525, 2.1131221719457, 2.07239819004525, 2.4841628959276, 2.84162895927602, 2.89592760180995, 2.86425339366516, 3.58371040723982, 3.67873303167421, 3.51131221719457, 3.30316742081448, 2.97285067873303, 2.76923076923077, 2.46606334841629, 1.94117647058824, 1.82805429864253, 1.75565610859729, 1.7737556561086, 1.90045248868778, 1.87330316742081, 1.85067873303167, 1.69230769230769, 1.63800904977376, 1.53393665158371, 1.37556561085973, 1.01809954751131, 0.986425339366516, 0.954751131221719, 0.85972850678733, 0.83710407239819, 0.755656108597285, 0.719457013574661, 0.828054298642534, 0.873303167420814, 0.900452488687783, 0.841628959276018, 0.669683257918552, 0.570135746606335, 0.484162895927602, 0.470588235294118, 0.479638009049774, 0.479638009049774, 0.45158371040724, 0.427601809954751, 0.524886877828054, 0.515837104072398, 0.529411764705882, 0.556561085972851, 0.538461538461538, 0.4, 0.341628959276018, 0.291402714932127, 0.286425339366516, 0.234389140271493, 0.160180995475113, 0.153846153846154, 0.184615384615385, 0.156108597285068, 0.165610859728507, 0.152488687782805, 0.129411764705882, 0.11447963800905, 0.135746606334842, 0.128506787330317, 0.0945701357466063, 0.081447963800905, 0.0642533936651584, 0.0515837104072398, 0.0592760180995475, 0.0638009049773756, 0.0515837104072398, 0.0561085972850679, 0.0592760180995475, 0.06289592760181, 0.0692307692307692, 0.0710407239819004, 0.0665158371040724, 0.0570135746606335, 0.046606334841629, 0.0378733031674208, 0.0304072398190045, 0.0261538461538462, 0.0292307692307692, 0.02710407239819, 0.021447963800905, 0.0158823529411765, 0.0133031674208145, 0.0116742081447964, 0.0101809954751131, 0.00873303167420814, 0.00742081447963801, 0.00529411764705882, 0.00391402714932127, 0.00327601809954751, 0.00274660633484163, 0.00233031674208145, 0.00123981900452489 };
            PGAonSa_NEAR[17].Vertical = new List<double>() { 1, 1.10416666666667, 1.1875, 1.26666666666667, 1.36666666666667, 1.275, 1.39583333333333, 1.46666666666667, 1.46666666666667, 1.725, 1.575, 1.475, 1.47916666666667, 1.5, 1.56666666666667, 1.50833333333333, 1.15, 1.57083333333333, 1.89166666666667, 1.72916666666667, 1.3125, 1.33333333333333, 1.4375, 1.475, 1.9125, 2.27083333333333, 2.24583333333333, 1.55833333333333, 1.02083333333333, 0.870833333333333, 0.816666666666667, 0.6625, 0.616666666666667, 0.7625, 1.00833333333333, 1.14166666666667, 1.12083333333333, 0.995833333333333, 0.75, 0.508333333333333, 0.4375, 0.369166666666667, 0.2675, 0.254583333333333, 0.282083333333333, 0.282083333333333, 0.275, 0.251666666666667, 0.279583333333333, 0.278333333333333, 0.274166666666667, 0.2725, 0.247083333333333, 0.235, 0.237083333333333, 0.268333333333333, 0.290833333333333, 0.240416666666667, 0.243333333333333, 0.257916666666667, 0.249166666666667, 0.301666666666667, 0.275, 0.25875, 0.2375, 0.254583333333333, 0.220833333333333, 0.1625, 0.121666666666667, 0.1075, 0.0920833333333333, 0.075, 0.0779166666666667, 0.0704166666666667, 0.0595833333333333, 0.0595833333333333, 0.0579166666666667, 0.0458333333333333, 0.0394166666666667, 0.0483333333333333, 0.055, 0.0529166666666667, 0.0305, 0.028625, 0.0234166666666667, 0.0203333333333333, 0.018625, 0.0169166666666667, 0.01375, 0.0120416666666667, 0.0100833333333333, 0.00866666666666667, 0.00895833333333333, 0.009625, 0.00975, 0.00866666666666667, 0.00695833333333333, 0.0055, 0.004375, 0.00360416666666667, 0.00304166666666667, 0.002625, 0.00230416666666667, 0.00204583333333333, 0.00183333333333333, 0.0015, 0.00125, 0.00105416666666667, 0.0009, 0.000779166666666667, 0.000429166666666667 };
            PGAonSa_NEAR[18].Vertical = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            PGAonSa_NEAR[19].Vertical = new List<double>() { 1, 1.04901960784314, 1.07450980392157, 1.08039215686275, 1.04117647058824, 1.05098039215686, 1.06862745098039, 1.13333333333333, 1.11176470588235, 1.24117647058824, 1.16666666666667, 1.11372549019608, 1.16862745098039, 1.21960784313725, 1.29607843137255, 1.38235294117647, 1.44509803921569, 1.64705882352941, 1.65686274509804, 1.72941176470588, 2.03921568627451, 2.43137254901961, 2.17647058823529, 2.3921568627451, 2.76470588235294, 2.80392156862745, 3.2156862745098, 3.17647058823529, 2.35294117647059, 2.70588235294118, 2.70588235294118, 2.47058823529412, 2.15686274509804, 1.65490196078431, 1.49607843137255, 1.75294117647059, 1.71176470588235, 1.68039215686275, 1.65490196078431, 2, 2.05882352941176, 2.13725490196078, 1.94313725490196, 1.67058823529412, 1.37254901960784, 1.6156862745098, 2.03921568627451, 2.3921568627451, 2.41176470588235, 1.81960784313725, 1.43921568627451, 1.17843137254902, 1.02352941176471, 0.974509803921569, 0.933333333333333, 0.825490196078431, 0.786274509803922, 0.558823529411765, 0.488235294117647, 0.398039215686275, 0.362745098039216, 0.36078431372549, 0.474509803921569, 0.482352941176471, 0.464705882352941, 0.409803921568627, 0.411764705882353, 0.472549019607843, 0.33921568627451, 0.305882352941176, 0.311764705882353, 0.227450980392157, 0.172352941176471, 0.180980392156863, 0.171960784313725, 0.134313725490196, 0.102352941176471, 0.0929411764705882, 0.101372549019608, 0.100588235294118, 0.0998039215686275, 0.0954901960784314, 0.0825490196078431, 0.0741176470588235, 0.0672549019607843, 0.0631372549019608, 0.0625490196078431, 0.0623529411764706, 0.0633333333333333, 0.0580392156862745, 0.0486274509803922, 0.0409803921568627, 0.0366666666666667, 0.032156862745098, 0.0280392156862745, 0.0195686274509804, 0.0140392156862745, 0.0107058823529412, 0.00864705882352941, 0.00731372549019608, 0.00635294117647059, 0.0056078431372549, 0.00498039215686275, 0.00447058823529412, 0.00401960784313726, 0.00327450980392157, 0.00270588235294118, 0.00225490196078431, 0.00191176470588235, 0.00163921568627451, 0.000874509803921569 };
            PGAonSa_NEAR[20].Vertical = new List<double>() { 1, 1.05194805194805, 1.08225108225108, 1.12770562770563, 1.16883116883117, 1.16883116883117, 1.16666666666667, 1.2012987012987, 1.23160173160173, 1.35281385281385, 1.41125541125541, 1.45238095238095, 1.47402597402597, 1.48917748917749, 1.53246753246753, 1.5952380952381, 1.62554112554113, 1.58874458874459, 1.52813852813853, 1.5, 1.49350649350649, 1.38961038961039, 1.41991341991342, 1.43506493506494, 1.58874458874459, 1.8008658008658, 2.04112554112554, 2.16233766233766, 2.0995670995671, 1.7034632034632, 1.62987012987013, 1.48917748917749, 1.7012987012987, 1.89393939393939, 2.15584415584416, 2.29437229437229, 2.57575757575758, 2.96536796536797, 3.00865800865801, 2.81385281385281, 2.74891774891775, 2.55411255411255, 1.9047619047619, 1.66233766233766, 1.46753246753247, 1.03463203463203, 0.943722943722944, 0.893939393939394, 0.857142857142857, 0.753246753246753, 0.673160173160173, 0.751082251082251, 0.824675324675325, 0.865800865800866, 0.930735930735931, 0.913419913419913, 0.904761904761905, 0.746753246753247, 0.584415584415584, 0.623376623376623, 0.638528138528139, 0.625541125541126, 0.675324675324675, 0.586580086580087, 0.441558441558441, 0.422077922077922, 0.463203463203463, 0.413419913419913, 0.387445887445887, 0.344155844155844, 0.274891774891775, 0.202380952380952, 0.1995670995671, 0.195454545454545, 0.177056277056277, 0.146753246753247, 0.145670995670996, 0.162770562770563, 0.158658008658009, 0.137012987012987, 0.117316017316017, 0.105411255411255, 0.101515151515152, 0.0865800865800866, 0.0805194805194805, 0.0725108225108225, 0.067965367965368, 0.0632034632034632, 0.0649350649350649, 0.0645021645021645, 0.062987012987013, 0.0603896103896104, 0.0575757575757576, 0.0545454545454545, 0.0512987012987013, 0.0428571428571429, 0.0359307359307359, 0.0344155844155844, 0.029004329004329, 0.025974025974026, 0.0257575757575758, 0.0238095238095238, 0.0211688311688312, 0.0181601731601732, 0.0151948051948052, 0.0116017316017316, 0.00965367965367965, 0.00811688311688312, 0.00683982683982684, 0.0058008658008658, 0.00285714285714286 };
            PGAonSa_NEAR[21].Vertical = new List<double>() { 1, 1.00134408602151, 1.03897849462366, 1.21639784946237, 1.4247311827957, 1.50537634408602, 1.57258064516129, 1.41129032258065, 1.39784946236559, 1.47849462365591, 1.47849462365591, 1.53225806451613, 1.63978494623656, 1.70698924731183, 1.8010752688172, 1.92204301075269, 2.02956989247312, 2.16397849462366, 2.29838709677419, 2.25806451612903, 2.21774193548387, 2.21774193548387, 2.39247311827957, 2.39247311827957, 2.31182795698925, 2.20430107526882, 2.06989247311828, 2.08333333333333, 2.28494623655914, 2.23118279569892, 2.25806451612903, 2.31182795698925, 2.01612903225806, 2.13709677419355, 1.98924731182796, 1.8010752688172, 1.5994623655914, 1.39784946236559, 1.08467741935484, 0.895161290322581, 0.817204301075269, 0.745967741935484, 0.803763440860215, 0.834677419354839, 0.708333333333333, 0.595430107526882, 0.702956989247312, 0.727150537634409, 0.743279569892473, 0.885752688172043, 0.963709677419355, 0.770161290322581, 0.614247311827957, 0.610215053763441, 0.618279569892473, 0.681451612903226, 0.829301075268817, 0.852150537634409, 0.530913978494624, 0.600806451612903, 0.670698924731183, 0.736559139784946, 0.662634408602151, 0.551075268817204, 0.520161290322581, 0.522849462365591, 0.504032258064516, 0.463709677419355, 0.404569892473118, 0.428763440860215, 0.461021505376344, 0.461021505376344, 0.442204301075269, 0.400537634408602, 0.352150537634409, 0.309139784946237, 0.275537634408602, 0.254032258064516, 0.241935483870968, 0.254032258064516, 0.263440860215054, 0.271505376344086, 0.287634408602151, 0.297043010752688, 0.301075268817204, 0.298387096774194, 0.295698924731183, 0.293010752688172, 0.28494623655914, 0.276881720430108, 0.266129032258065, 0.254032258064516, 0.239247311827957, 0.225806451612903, 0.211021505376344, 0.17741935483871, 0.149193548387097, 0.12755376344086, 0.111693548387097, 0.0974462365591398, 0.0821236559139785, 0.0698924731182796, 0.0608870967741936, 0.0508064516129032, 0.0448924731182796, 0.0338709677419355, 0.0270161290322581, 0.0220430107526882, 0.0182795698924731, 0.0153225806451613, 0.00733870967741935 };
            PGAonSa_NEAR[22].Vertical = new List<double>() { 1, 1.09119496855346, 1.11949685534591, 1.10377358490566, 1.24528301886792, 1.24528301886792, 1.22012578616352, 1.28301886792453, 1.35220125786164, 1.55345911949686, 1.71383647798742, 1.99056603773585, 1.99685534591195, 1.89937106918239, 1.81132075471698, 1.92452830188679, 2.25157232704403, 1.79559748427673, 2.29559748427673, 2.61006289308176, 3.04088050314465, 3.36477987421384, 3.39622641509434, 3.12264150943396, 2.89308176100629, 3.23899371069182, 3.49056603773585, 3.71069182389937, 2.46540880503145, 3.05345911949686, 2.92138364779874, 3.06603773584906, 2.86477987421384, 2.33962264150943, 2.5251572327044, 3.13207547169811, 2.49685534591195, 2.42767295597484, 2.65094339622642, 2.5377358490566, 2.43710691823899, 2.42767295597484, 1.94654088050314, 1.64150943396226, 1.74213836477987, 1.79874213836478, 1.92452830188679, 2.12578616352201, 2.27672955974843, 1.90880503144654, 1.57547169811321, 1.37735849056604, 1.18867924528302, 1.12893081761006, 1.13522012578616, 1.31761006289308, 1.35220125786164, 1.28930817610063, 1.30817610062893, 1.27358490566038, 1.16352201257862, 0.915094339622641, 0.836477987421384, 0.808176100628931, 0.874213836477987, 0.90251572327044, 0.883647798742138, 0.836477987421384, 0.767295597484277, 0.688679245283019, 0.591194968553459, 0.484276729559748, 0.383647798742138, 0.297169811320755, 0.235534591194969, 0.199685534591195, 0.176729559748428, 0.162578616352201, 0.173270440251572, 0.159433962264151, 0.157232704402516, 0.163522012578616, 0.177672955974843, 0.235220125786164, 0.281132075471698, 0.284276729559748, 0.275471698113208, 0.264779874213836, 0.242767295597484, 0.20503144654088, 0.151572327044025, 0.132389937106918, 0.120754716981132, 0.106289308176101, 0.0977987421383648, 0.0757861635220126, 0.0569182389937107, 0.0522012578616352, 0.0415094339622641, 0.0342767295597484, 0.0292767295597484, 0.025188679245283, 0.0217610062893082, 0.0188993710691824, 0.0165094339622642, 0.0127672955974843, 0.0100943396226415, 0.00811320754716981, 0.00663522012578616, 0.00550314465408805, 0.00323899371069182 };
            PGAonSa_NEAR[23].Vertical = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            PGAonSa_NEAR[24].Vertical = new List<double>() { 1, 1.01239669421488, 1.0495867768595, 1.04132231404959, 1.16942148760331, 1.30578512396694, 1.52479338842975, 1.58264462809917, 1.72314049586777, 2.04132231404959, 2.11157024793388, 2.26446280991736, 2.25206611570248, 2.19421487603306, 2.03305785123967, 1.78512396694215, 1.80165289256198, 1.8099173553719, 2.11157024793388, 2.08264462809917, 2.22727272727273, 2.05785123966942, 2.33884297520661, 2.3801652892562, 2.08677685950413, 1.89669421487603, 2.08677685950413, 2.0702479338843, 2.35123966942149, 3.05785123966942, 3.09504132231405, 2.99173553719008, 2.7396694214876, 3.13223140495868, 2.82644628099174, 2.87603305785124, 2.74793388429752, 2.95867768595041, 2.07851239669422, 1.90495867768595, 2.32644628099174, 2.52066115702479, 2.23553719008265, 2.04545454545455, 1.95454545454545, 1.79338842975207, 2.02066115702479, 2.02066115702479, 1.94628099173554, 1.71487603305785, 1.63636363636364, 1.36363636363636, 1.0702479338843, 1.0702479338843, 1.21074380165289, 1.37190082644628, 1.29752066115702, 1.39256198347107, 0.971074380165289, 1.18181818181818, 1.2603305785124, 1.34710743801653, 1.34710743801653, 1.32644628099174, 1.3099173553719, 1.29338842975207, 1.25619834710744, 1.21900826446281, 1.13636363636364, 1.04132231404959, 0.958677685950413, 1.0495867768595, 0.975206611570248, 0.826446280991736, 0.801652892561983, 0.950413223140496, 1.02892561983471, 1.17768595041322, 0.925619834710744, 0.946280991735537, 0.929752066115702, 0.900826446280992, 0.834710743801653, 0.756198347107438, 0.665289256198347, 0.648760330578512, 0.644628099173554, 0.628099173553719, 0.578512396694215, 0.512396694214876, 0.446280991735537, 0.392148760330578, 0.344214876033058, 0.306611570247934, 0.275619834710744, 0.231404958677686, 0.204545454545455, 0.184297520661157, 0.166115702479339, 0.155785123966942, 0.139256198347107, 0.126446280991736, 0.110330578512397, 0.100826446280992, 0.0946280991735537, 0.0809917355371901, 0.0669421487603306, 0.0541322314049587, 0.043801652892562, 0.0353719008264463, 0.0145867768595041 };
            PGAonSa_NEAR[25].Vertical = new List<double>() { 1, 1.06329113924051, 1.11392405063291, 1.17299578059072, 1.28691983122363, 1.30379746835443, 1.30379746835443, 1.21518987341772, 1.21518987341772, 1.34177215189873, 1.41350210970464, 1.29113924050633, 1.22362869198312, 1.17299578059072, 1.13924050632911, 1.13502109704641, 1.51054852320675, 1.90717299578059, 2.11392405063291, 1.9620253164557, 1.62025316455696, 1.42616033755274, 1.44303797468354, 1.69198312236287, 1.63291139240506, 1.71729957805907, 1.56962025316456, 1.79746835443038, 2.24894514767933, 1.91139240506329, 1.83122362869198, 1.67932489451477, 1.91983122362869, 2.0379746835443, 2.05485232067511, 1.9493670886076, 2.08438818565401, 2.30379746835443, 2.20253164556962, 2.41350210970464, 2.63291139240506, 2.33755274261603, 1.56118143459916, 1.57805907172996, 1.55696202531646, 1.62869198312236, 1.35864978902954, 1.27004219409283, 1.29535864978903, 1.75105485232068, 1.88607594936709, 2.09704641350211, 2.17299578059072, 2.09704641350211, 1.957805907173, 1.62447257383966, 1.43459915611814, 1.25316455696203, 1.16877637130802, 1.27004219409283, 1.31645569620253, 1.41772151898734, 1.37974683544304, 1.37974683544304, 1.42616033755274, 1.29113924050633, 1.31223628691983, 1.33333333333333, 1.09704641350211, 1.0379746835443, 0.89873417721519, 0.738396624472574, 0.751054852320675, 0.784810126582279, 0.742616033755274, 0.645569620253165, 0.691983122362869, 0.675105485232068, 0.60337552742616, 0.620253164556962, 0.624472573839662, 0.632911392405063, 0.645569620253165, 0.670886075949367, 0.69620253164557, 0.721518987341772, 0.729957805907173, 0.738396624472574, 0.721518987341772, 0.691983122362869, 0.670886075949367, 0.717299578059072, 0.729957805907173, 0.704641350210971, 0.649789029535865, 0.476793248945148, 0.335443037974684, 0.247679324894515, 0.193248945147679, 0.166244725738397, 0.135864978902954, 0.123206751054852, 0.121097046413502, 0.119831223628692, 0.110970464135021, 0.0873417721518987, 0.0565400843881857, 0.0421940928270042, 0.0340928270042194, 0.0276793248945148, 0.0164978902953587 };
            PGAonSa_NEAR[26].Vertical = new List<double>() { 1, 1.01246105919003, 1.02180685358255, 1.02492211838006, 1.03738317757009, 1.0404984423676, 1.04672897196262, 1.07165109034268, 1.07476635514019, 1.09034267912773, 1.17133956386293, 1.20872274143302, 1.22741433021807, 1.27414330218069, 1.35514018691589, 1.37383177570093, 1.42367601246106, 1.62616822429907, 1.45482866043614, 1.41744548286604, 1.37694704049844, 1.55763239875389, 1.68847352024922, 1.69158878504673, 1.73208722741433, 1.52647975077882, 1.61059190031153, 1.62305295950156, 1.85981308411215, 1.60436137071651, 1.70716510903427, 2.1588785046729, 2.8816199376947, 2.82242990654206, 2.44859813084112, 2.17757009345794, 2.31152647975078, 2.14018691588785, 2.06853582554517, 2.31775700934579, 2.40809968847352, 2.26168224299065, 2.42056074766355, 2.59190031152648, 2.64797507788162, 2.86915887850467, 2.65420560747664, 2.62305295950156, 2.83177570093458, 2.89096573208723, 2.83489096573209, 2.89719626168224, 3.27102803738318, 3.20872274143302, 3.11526479750779, 2.8006230529595, 2.51713395638629, 2.49532710280374, 1.93769470404984, 1.66043613707165, 1.62305295950156, 1.51401869158878, 1.84735202492212, 1.61682242990654, 1.66355140186916, 1.25545171339564, 0.922118380062305, 0.881619937694704, 0.666666666666667, 0.626168224299065, 0.654205607476635, 0.654205607476635, 0.707165109034268, 0.688473520249221, 0.616822429906542, 0.476635514018692, 0.398753894080997, 0.339563862928349, 0.261682242990654, 0.285358255451713, 0.302803738317757, 0.29190031152648, 0.281619937694704, 0.286915887850467, 0.279439252336449, 0.208722741433022, 0.172897196261682, 0.159501557632399, 0.135202492211838, 0.120560747663551, 0.0993769470404984, 0.102803738317757, 0.11214953271028, 0.11588785046729, 0.112461059190031, 0.0875389408099689, 0.0959501557632399, 0.109034267912773, 0.0953271028037383, 0.0831775700934579, 0.0672897196261682, 0.0570093457943925, 0.0470404984423676, 0.0433021806853583, 0.0383177570093458, 0.0272274143302181, 0.0201557632398754, 0.0167289719626168, 0.0138317757009346, 0.011619937694704, 0.00529595015576324 };
            PGAonSa_NEAR[27].Vertical = new List<double>() { 1, 1, 1.03765690376569, 1.01673640167364, 1.14644351464435, 1.11297071129707, 1.07949790794979, 1.09205020920502, 1.12970711297071, 1.1673640167364, 1.27615062761506, 1.30962343096234, 1.2928870292887, 1.2928870292887, 1.38493723849372, 1.52719665271967, 1.6234309623431, 2.39748953974895, 3.19665271966527, 3.43514644351464, 3.43514644351464, 2.84518828451883, 2.80334728033473, 3.00836820083682, 3, 3.38912133891213, 3.33054393305439, 1.97071129707113, 2.3347280334728, 2.73640167364017, 2.69456066945607, 2.68200836820084, 3.29707112970711, 2.72803347280335, 1.92887029288703, 1.69456066945607, 1.44769874476987, 1.581589958159, 1.32217573221757, 1.46443514644351, 1.46861924686192, 1.49372384937239, 2.13389121338912, 2.36401673640167, 2.39748953974895, 1.86192468619247, 1.1673640167364, 0.97907949790795, 0.99581589958159, 1.09623430962343, 1.10878661087866, 1.05020920502092, 0.98326359832636, 1.05857740585774, 1.13389121338912, 1.27615062761506, 1.37238493723849, 1.35983263598326, 1.34728033472803, 1.29707112970711, 1.2928870292887, 1.30962343096234, 1.23012552301255, 1.14225941422594, 1.08786610878661, 0.97489539748954, 0.99163179916318, 1.07949790794979, 1.2928870292887, 1.59414225941423, 1.57322175732218, 1.47280334728033, 1.30962343096234, 1.1255230125523, 0.97907949790795, 0.941422594142259, 0.9581589958159, 0.97071129707113, 0.945606694560669, 0.866108786610879, 0.824267782426778, 0.782426778242678, 0.732217573221757, 0.794979079497908, 0.807531380753138, 0.786610878661088, 0.761506276150628, 0.732217573221757, 0.661087866108787, 0.585774058577406, 0.518828451882845, 0.468619246861925, 0.435146443514644, 0.402928870292887, 0.371548117154812, 0.301255230125523, 0.238493723849372, 0.18326359832636, 0.138493723849372, 0.11673640167364, 0.099163179916318, 0.0845188284518828, 0.0723849372384937, 0.0623430962343096, 0.0539748953974895, 0.0409623430962343, 0.0320502092050209, 0.0258995815899582, 0.0213389121338912, 0.0179497907949791, 0.00916317991631799 };

            //22 EQ (FAR)
            //H1
            PGAonSa_FAR[0].Horziantal1 = new List<double>() { 1, 0.999395021894446, 0.992734679694353, 0.997555968849322, 1.01289079039753, 1.01012517620071, 0.993104723518976, 1.04301686881734, 1.06720237042436, 1.17040283636247, 1.19982947165692, 1.21689257875658, 1.22193718947137, 1.21284331223391, 1.18254348964056, 1.1718032858641, 1.09041106352873, 1.02488271151678, 1.03637416902048, 1.08770172636499, 1.14908255036794, 1.12356448901347, 1.29184733380856, 1.47724688287767, 1.47723861997995, 1.33608443162876, 1.17352710498436, 1.1330520821609, 1.60466076561777, 1.79652837702396, 1.94381944183903, 2.14933602033834, 2.17295629507746, 2.17333549508603, 2.16420610972056, 2.25779436908086, 2.348302130845, 2.34550391170044, 2.11320460185339, 1.68180697513627, 1.80937829957605, 2.32557022927085, 2.64608133192551, 2.25724276482811, 1.99583125644283, 1.90911594140757, 1.62793958169192, 1.46139931502811, 1.43442653703297, 1.57694187029126, 2.02653931084753, 2.04634168019995, 2.02023762307251, 2.14609517786222, 2.20932197787866, 2.16260176763481, 2.84233855191154, 3.11045395020108, 2.2571244044014, 1.97295039938828, 1.85469002074211, 1.84384999222841, 1.8690511602895, 2.65637198940205, 3.12352942752858, 2.80302055808951, 2.57265320305647, 2.31406470250888, 1.98576704702795, 1.82043316343029, 1.56668873083678, 1.22893519386991, 1.23018758117739, 1.16483989630733, 1.00542872379768, 0.790423658864705, 0.568195704722447, 0.449816519006451, 0.477053933049983, 0.495858948316245, 0.462954749692263, 0.412456161977807, 0.298100114161981, 0.237355309961392, 0.195091637768857, 0.161379953048875, 0.148828477429337, 0.138910029996552, 0.12523466629506, 0.116746615785082, 0.110600940451753, 0.105127708667199, 0.0994889509425063, 0.0935347961788788, 0.0872666066378314, 0.0715470913706763, 0.0575277454705921, 0.0462082455679603, 0.0375041537810127, 0.0309359317243462, 0.0259799350044932, 0.0221979620567737, 0.0192613952059114, 0.0169355904890028, 0.0150562948987996, 0.0122133891101261, 0.0101653294171665, 0.00861882761540812, 0.00741097062696188, 0.00644412226587414, 0.00360088149486092 };
            PGAonSa_FAR[1].Horziantal1 = new List<double>() { 1, 1.00063496785399, 1.00307126121257, 1.0053651961037, 1.01756016240647, 1.01754249032085, 1.01823955592012, 1.04366821444683, 1.06036784446208, 1.04209981684847, 1.03623022996783, 1.01883304346204, 1.04680795499116, 1.07619884238021, 1.07845203329617, 1.09428892190951, 1.09323105122892, 1.12509161258272, 1.05190635169119, 1.10460303832241, 1.12083803975336, 1.0524522227802, 1.27078887699296, 1.39070968641375, 1.35405925352129, 1.44492592696225, 1.61361236574737, 1.86943224988722, 1.79587636608903, 1.89709839080934, 1.88852718384025, 1.7862482702219, 1.69732675342679, 1.74278524832471, 1.67820850213857, 1.78138623766697, 1.66690352170304, 1.80931353274318, 2.72972115903355, 2.47744722796156, 2.32768759287049, 2.00615602193499, 1.92454583967197, 1.86142630421219, 2.11962357475857, 2.61305839495246, 2.75042204376688, 2.82344948311604, 2.84309249716878, 2.75663181829562, 2.60956324913075, 2.45129548659842, 2.21442695071599, 2.37069899480195, 2.52642835859214, 2.53552702822772, 2.41455104802831, 2.97402547038428, 3.41291171664185, 2.74304885693514, 2.37674456620184, 1.88852522027518, 1.52789710526329, 1.25442673472383, 1.08922046957677, 1.12874875252257, 1.06406008312753, 0.927783758469715, 0.678642450018678, 0.580535130388084, 0.586110673399731, 0.61604595920399, 0.719955368165996, 0.750578147189819, 0.766698034618634, 0.79334803061787, 0.796270306330877, 0.760682407586037, 0.64554459722617, 0.516565862144969, 0.470964026997056, 0.424092501586806, 0.333096723742594, 0.252801639184119, 0.209716971731045, 0.181097863592116, 0.16795505988628, 0.155628755625, 0.136044550346054, 0.119163339651104, 0.103984171701984, 0.0905296274969798, 0.0794589003741082, 0.0698268773768341, 0.0620476743780776, 0.0516748228250694, 0.0433326411766467, 0.0366128797105312, 0.031195820944465, 0.0268041849462302, 0.0232144934664827, 0.0202586653353696, 0.0178060498421539, 0.0157551306728008, 0.0140270952343785, 0.011307017634287, 0.00929507523154114, 0.0077704160450756, 0.0065900189042227, 0.00565874908141972, 0.00303167083187907 };
            PGAonSa_FAR[2].Horziantal1 = new List<double>() { 1, 0.98819009010724, 1.04529550534111, 0.993091028321073, 1.08979293585968, 1.10667178570539, 1.09776369982962, 1.03925409890297, 1.04647151751498, 1.19296330972478, 1.25131223069967, 1.2859983330287, 1.31476190812169, 1.34781325501772, 1.37734801400511, 1.39436251660215, 1.4607937589617, 1.5344735708104, 1.55796718960647, 1.55578263450423, 1.56755873105171, 1.52046632596837, 1.45886213833199, 1.33819642012522, 1.30992367103236, 1.14785697274445, 1.1352238277053, 1.11011728571491, 1.27607757739895, 1.27321755413164, 1.24745271689564, 1.15233085106992, 1.17950160460298, 1.14603398081452, 1.34545830195504, 1.5089711198088, 1.82828491657223, 2.07497989503752, 2.11753146072187, 2.25776765093232, 2.52525517427385, 2.79557290123961, 2.66716738817334, 2.68530678355612, 2.84246029627679, 2.98818250207306, 2.68989022244522, 2.50931497756804, 2.31405488970925, 2.070932943477, 2.12866323998143, 2.27172297764578, 2.34806792009454, 2.33213571079313, 2.27106268554907, 2.05221446127553, 2.10599498630626, 2.18068387357696, 1.92110121811911, 1.25058524377625, 1.16078831421437, 1.16277717790892, 1.23107494355235, 1.16748668466406, 1.0071547174875, 1.11090138257976, 1.03891037426714, 1.00821597728489, 0.766433518769801, 0.57917361515381, 0.523314235005678, 0.480161217770324, 0.447891704641228, 0.412086966326567, 0.368296154850212, 0.427312955955988, 0.395059417635683, 0.366523882938199, 0.321607513059073, 0.272297005775027, 0.250444266088663, 0.248289929999719, 0.220929076242038, 0.194277370871294, 0.173406283185169, 0.15662647715396, 0.149658664929317, 0.143841172061071, 0.128162935594763, 0.110261764548092, 0.110123688950771, 0.105215495511278, 0.104538176930858, 0.100953869145282, 0.0951407027877506, 0.0796182340195002, 0.0701944280665676, 0.0606578532759074, 0.0516274003647848, 0.0453639573967824, 0.0398120324123545, 0.0334247846762179, 0.0307243231240549, 0.0282221888230387, 0.0260887797336121, 0.0218561875825948, 0.0178164779353944, 0.0142867241218415, 0.0113640529793884, 0.00901990953732028, 0.00463282767294827 };
            PGAonSa_FAR[3].Horziantal1 = new List<double>() { 1, 0.99377623713895, 0.993892307554505, 0.997519974561545, 1.01057360431857, 1.01202541755492, 1.00219264852535, 1.02311630031709, 1.0195043084144, 0.99979323790927, 1.02597663364445, 1.01696718081009, 1.00077031941384, 0.993809080214734, 1.04116580976096, 1.07885846425778, 1.06848751664547, 1.02938858135827, 1.13069902008205, 1.16317373091369, 1.18687038330855, 1.10141381976914, 1.07936641228212, 1.11299697545129, 1.26147678890262, 1.34302502642375, 1.41821626269683, 1.52622109062897, 1.58085666684581, 1.61509109474929, 1.6905193236715, 2.07259849937001, 2.67458520688152, 2.54368315687644, 2.47623392928587, 2.52581129861522, 2.35667617622997, 2.44954594447729, 2.85249390910231, 2.60295371216328, 2.48851686641228, 2.52520818031446, 1.72926818162818, 1.73748678812633, 1.76168541707721, 1.85667244406227, 1.85865459832918, 1.9722815636887, 1.95388869481617, 1.5758551889074, 1.42296022106376, 1.26513841863576, 1.21494561485224, 1.27928855926384, 1.38972190872014, 1.52814576951327, 1.530064850146, 1.50414905083511, 1.39760238082442, 1.25119615974872, 1.20636909347139, 1.15628713506864, 1.15740230677821, 1.29551714408556, 1.12471896777199, 1.08388270841917, 1.06045925070015, 1.30446613580313, 1.63090242322185, 1.60068343454972, 1.38178246836615, 1.1798972011728, 0.924519520729952, 0.719559693783104, 0.675344329792253, 0.549042922914315, 0.460139702501448, 0.368224958647582, 0.378101431360957, 0.31486559717669, 0.280539843129527, 0.257426528546604, 0.246663703325511, 0.236026689477676, 0.207019796910362, 0.188929121656724, 0.184367181108663, 0.178193578581537, 0.169047715017646, 0.160342583137768, 0.153868503788897, 0.15008110000418, 0.147929020141763, 0.146069542227238, 0.143770265670626, 0.135259094546258, 0.126696718081009, 0.116439862835373, 0.107111794844234, 0.100514255387757, 0.0992933513671677, 0.0918936944280229, 0.0830459190985472, 0.0753433594286499, 0.0687840000477718, 0.0557837776105767, 0.0440430498080173, 0.0340152376942967, 0.0258404841666517, 0.021365913664511, 0.0115365409075438 };
            PGAonSa_FAR[4].Horziantal1 = new List<double>() { 1, 0.998917129220641, 1.01333435276656, 1.02730695937697, 1.07545357160369, 1.08478429430151, 1.08364657358244, 1.08937091274455, 1.12514470826896, 1.11265180344109, 1.11371223560875, 1.11668452059906, 1.12398330234866, 1.16790979345673, 1.26115178224906, 1.24863228351103, 1.31847080030217, 1.67446103701291, 1.66641887236835, 1.63246052674225, 1.75885224007985, 1.54837016728401, 1.60684352725003, 1.53111030405981, 1.78350978115705, 2.05043493509008, 2.30753696345747, 2.53994779283012, 2.52895619733679, 2.64612231702767, 2.66784621739026, 2.60515232077574, 2.73646598514232, 2.34422991100182, 2.07777389026522, 2.75290767009922, 2.77213091184701, 2.22950586021742, 2.09257714103831, 1.83496899731817, 1.73881539089308, 2.19178406077373, 2.34568800523235, 2.186028972403, 2.42029264936013, 2.56296648419366, 2.52448135642239, 2.34212109703204, 2.12825204045931, 2.46607448123176, 2.63323299672646, 2.62552533360814, 2.69811673563077, 2.76512590969872, 2.80500763328328, 2.89720082474364, 2.82047988710885, 2.09602229899367, 2.05363659255553, 2.26611154649405, 2.28830915088138, 2.25879240378199, 2.23457158457321, 2.03788510267327, 1.84822065964532, 1.86208231978678, 1.60481823477935, 1.09419936955812, 0.779313760769495, 0.773376254796253, 0.732916944725389, 0.689298361233392, 0.880582124072226, 0.971127739692159, 0.877569117156978, 0.777481689677324, 0.665443623819168, 0.653944250853706, 0.620956167418637, 0.566513862491201, 0.564670156563336, 0.593904758897117, 0.662837420623411, 0.653263197435682, 0.687497039349845, 0.554783454931217, 0.436290132911377, 0.373484749639112, 0.34294505116419, 0.262882380952777, 0.235381784667447, 0.311458609487544, 0.390078310754827, 0.353364919142047, 0.307573654742899, 0.245301604028313, 0.192475627096867, 0.179475277220737, 0.116874500844772, 0.0851999072537383, 0.0795541032325729, 0.0916033468435937, 0.0895949664376543, 0.0805422747599692, 0.0554734837939205, 0.0436404819148945, 0.0358507516519389, 0.0209413745561102, 0.0153143940369805, 0.0118956637798423, 0.00714262563337137 };
            PGAonSa_FAR[5].Horziantal1 = new List<double>() { 1, 1.01785265679554, 1.03542384971736, 1.05740119201177, 1.03465357055861, 1.01850849759325, 1.03164738380283, 1.04364624595855, 1.03622818791215, 1.03323044779731, 1.03465193572488, 1.03953000710063, 1.03694642486386, 1.03473258752219, 1.03105938860488, 1.02883492484397, 1.03136237778937, 1.09514459831863, 1.09896493227156, 1.14716664241663, 1.18502721180742, 1.33315431903998, 1.50374513160139, 1.50687665560974, 1.45251162230545, 1.50949102721508, 1.65553617369345, 2.07377595911608, 1.89360747315194, 1.93148929538121, 1.82847406254547, 1.78473871814867, 2.21364170657023, 2.98710007198718, 3.6727765852574, 3.8521232948003, 3.68695331841275, 3.41085987349657, 3.65429206522551, 5.6605600177434, 5.10530236522295, 4.58865403594127, 3.43738505075341, 3.83188677795525, 3.25735171104423, 2.57279287910023, 2.68771106384625, 2.58220461687944, 2.12200600637912, 2.13527676917619, 2.02155037821878, 2.01262691078004, 2.15380978927538, 2.13825298398026, 2.06215365366265, 1.76002275688551, 1.45513743774689, 1.14802029809558, 1.16824591604911, 1.22877263767888, 1.05523449237595, 0.890562322858954, 0.987969803531132, 0.954931993641587, 0.821427384227887, 0.700287839725261, 0.645749241573386, 0.676487657822761, 0.659051338683599, 0.636261211553479, 0.78063065345939, 0.864752657830935, 0.886236552811396, 0.827436760544269, 0.809431519267333, 0.81365402231766, 0.762669552693143, 0.684917677947564, 0.560975211016164, 0.429302160323784, 0.44577501745185, 0.466955650775538, 0.47600091332711, 0.468603563174607, 0.430918193465134, 0.370693916075266, 0.341622485285134, 0.313104445712349, 0.258971586044841, 0.213285367311718, 0.177839283855635, 0.160934748881365, 0.153518298421459, 0.15201498706574, 0.154236208406424, 0.150444347807606, 0.133815527541771, 0.122693235984434, 0.11087619458663, 0.104482278129903, 0.0905772270931185, 0.0734355322391936, 0.0649463583806209, 0.0534882992225276, 0.04570501932101, 0.0380404828426925, 0.0307188527390822, 0.0243337643844933, 0.0191346934060071, 0.01556598761123, 0.00862461983303988 };
            PGAonSa_FAR[6].Horziantal1 = new List<double>() { 1, 0.989693486183753, 0.990759599917778, 0.992126909134808, 0.992639777543583, 0.991938687448407, 0.988913273646191, 0.992155662393511, 0.998729350673927, 1.03159758815219, 1.05185313732719, 1.07622407312545, 1.08249330314173, 1.09050730536695, 1.10375399282841, 1.10035662197744, 1.08563332213112, 1.10455011142398, 1.18074889799567, 1.10121881189088, 1.05244166147341, 1.25342857119552, 1.24774378684903, 1.22391202563241, 1.32849109423891, 1.4202172522815, 1.3995377454835, 1.28906854124318, 1.38446879476128, 1.6219023971653, 1.56923947834655, 1.43844926538483, 1.4538139056469, 1.59732284729858, 1.75719096568533, 1.67257440772366, 2.27037769954354, 2.97310938147458, 3.50527714062913, 3.20552951674949, 3.01311515659718, 2.63618848434028, 2.66456040549844, 2.53875572210241, 2.57537840104148, 2.60671741378917, 2.27456221634197, 2.11150676863945, 2.10930439137712, 2.5013560934069, 3.23641785785368, 4.17830731809179, 4.40510323439493, 4.521943426638, 4.61302396186461, 4.53240267939586, 4.15937910906498, 2.51676457729039, 1.74903523640481, 1.80194714620849, 1.88525227007997, 1.70722738647969, 1.30957471279369, 1.17778282602525, 1.15770509842179, 1.0627922228349, 0.791421210361288, 0.619077032631074, 0.59043817519177, 0.43861668684153, 0.414152557857266, 0.408834224616378, 0.457838546169984, 0.409137867185231, 0.3342284909311, 0.270078747222558, 0.261005156825575, 0.326814228662227, 0.391928328118321, 0.386861636872037, 0.354180193613432, 0.315878405935651, 0.223209304146669, 0.162470961247949, 0.127840495681709, 0.105338073066721, 0.0978143444909572, 0.0920828615895617, 0.0839467089958139, 0.0777491174177045, 0.0716828935648168, 0.0650604470988982, 0.0578145035515373, 0.0502075536645926, 0.045985474098412, 0.0409482498442022, 0.0344902883319684, 0.0291566404121545, 0.0244370479008898, 0.0228924677066238, 0.0200820711808331, 0.0190249504872964, 0.0170661398362736, 0.0147425706473684, 0.0128773814223768, 0.0104871903212861, 0.00833069591858708, 0.00658590331726957, 0.00523651900406869, 0.00426533180852695, 0.00220904557126403 };
            PGAonSa_FAR[7].Horziantal1 = new List<double>() { 1, 0.999200991762331, 0.999674018812126, 1.00027681826416, 1.00146204334398, 1.00184737436769, 1.00302684162762, 1.00346842212261, 1.0038515386002, 1.00731996072281, 1.00776375576391, 1.00938214606349, 1.01007086990472, 1.0108858228744, 1.01232882112181, 1.01433077080821, 1.01498406191162, 1.01644920562016, 1.02123926886317, 1.02313049124391, 1.02689832000103, 1.02854549940008, 1.04493624100285, 1.12885203687308, 1.32321610559665, 1.34076151154288, 1.20690282881691, 1.54622709993228, 1.63126522777271, 2.18308051336722, 2.24358279900027, 2.16545538376091, 2.42516317883036, 2.35731524373959, 2.27649228297116, 2.20371698277836, 1.72803380637515, 1.67132592405258, 1.84321677881866, 1.81463673249922, 1.81748729625622, 1.92886257811258, 1.78861404403138, 1.79644290745102, 1.85107753170233, 2.20979546895007, 2.56714260215369, 2.46007638412454, 2.33251985672772, 2.06427011439016, 2.22730411343082, 2.17526227976893, 2.22709240282239, 2.34795214277267, 2.41949615532649, 2.51563403119587, 2.84533654235829, 2.38157958259349, 2.54018891849983, 3.89408268849441, 3.97649879373673, 3.41253096489103, 2.39053919325857, 2.08374704745639, 2.48925524371301, 2.30243259032359, 1.80944716513737, 1.46022564453257, 1.60296908626499, 1.72692653331851, 1.5114507535879, 1.31828475431161, 1.01008460009062, 0.720192541497272, 0.567788363800321, 0.541282018461342, 0.53796285674677, 0.626411385601641, 0.703678671130601, 0.645590240761024, 0.591572146147642, 0.542765321448012, 0.50011006294183, 0.406727082437365, 0.376780439711418, 0.349156545821838, 0.330898410354509, 0.310896807023123, 0.269212582696688, 0.228991154659914, 0.1927924496379, 0.163833583060317, 0.139608884581843, 0.112972855422471, 0.0945275022267261, 0.0694575557877384, 0.0573340230906294, 0.0469547554941782, 0.0381873674317333, 0.0342374586931786, 0.0306475022798752, 0.0273840142545904, 0.0244404838517512, 0.0218199671449939, 0.0194996100184295, 0.0156704826248926, 0.0127449343364932, 0.0105136905455269, 0.00879936610832054, 0.00746669654827555, 0.00387430413424756 };
            PGAonSa_FAR[8].Horziantal1 = new List<double>() { 1, 1.00222061221606, 1.00296978845865, 1.00086036707072, 1.00430343752694, 1.00668202403196, 1.00552621620175, 1.01201245465449, 1.01902228334691, 1.02532843751893, 1.01677219114184, 1.00985785197905, 1.01691350282832, 1.02578665908732, 1.04199680782988, 1.06330699467213, 1.06956059755938, 1.01546930380122, 1.07209715835336, 1.09877750971638, 1.12574625227629, 1.14055866501792, 1.14633065460636, 1.13216135423379, 1.17399409951611, 1.22244253885511, 1.24118251926373, 1.25041840756149, 1.42794722184749, 1.37103097609846, 1.36511318873826, 1.43174148869458, 1.53320263871536, 1.64833449277276, 1.53649190053324, 1.96526360076917, 1.99950556931466, 1.68683567886166, 1.65929944651321, 1.62758666876445, 1.84003004395402, 2.12376276171101, 2.18912822865961, 2.14955711123024, 2.13172876743845, 2.52318488983937, 2.95037172023106, 3.0942148405469, 3.197100002211, 3.43570045895857, 3.38829855922962, 2.93476591126331, 2.41411533917528, 2.45229801320896, 2.43383200443738, 2.20842672668621, 2.1124812185233, 2.55449712425912, 2.50159944962142, 2.20775060954684, 2.07953636949449, 1.81470192686976, 1.57725855969105, 1.44267343766472, 1.4381155750152, 1.46263235153221, 1.45030587090777, 1.39252893765335, 1.14793571183439, 0.879282008458834, 0.791949463608395, 0.745359224881367, 0.789238906792286, 0.696593555225793, 0.684738754425603, 0.703704641271792, 0.855046573576124, 0.98412470548049, 0.995418425185395, 0.78891014082783, 0.649236836784361, 0.5251453091089, 0.429566698635365, 0.513048900572649, 0.63955169908878, 0.737350601343711, 0.755729772321559, 0.75756458120311, 0.725492275762226, 0.665433847705736, 0.57981947351944, 0.49172269199724, 0.419210891189681, 0.369834152631361, 0.3418006056856, 0.325756121663915, 0.325476061768267, 0.319135076348365, 0.303111933275249, 0.274015696812412, 0.235497047034361, 0.197775158046387, 0.165169040500057, 0.138610454309061, 0.127867081138222, 0.105990782376478, 0.0860532735444976, 0.0693746172808491, 0.0559722772746776, 0.0454317392456519, 0.0188159234238059 };
            PGAonSa_FAR[9].Horziantal1 = new List<double>() { 1, 1.02104424882919, 1.04643241560374, 1.01377780857337, 1.01110397117533, 1.05945183011214, 1.0829240789641, 1.03639199955958, 1.01138777571279, 1.10254076249452, 1.1155203114826, 1.06791850728305, 1.04535604655533, 1.03536071651629, 1.01329704938199, 1.02168541928086, 1.07217177862866, 1.34150845433784, 1.38150543594845, 1.36427973445767, 1.3969248496975, 1.26403503609728, 1.12828819354141, 1.1183678486477, 1.17143312748804, 1.21160428345524, 1.24283559649259, 1.4988495949853, 1.62181099566985, 2.04753061577042, 2.20685269310573, 2.3298886043461, 2.77458136457778, 3.29142502149891, 3.64356285748456, 3.02940794007263, 3.31037775428032, 3.16020433926697, 2.08969694611131, 1.60277900643733, 1.41986555827864, 1.51744543644202, 1.55333342192338, 1.31463055103641, 1.16542956996494, 1.08657367243071, 0.956761097326922, 0.895341619033698, 0.904543909972265, 0.963606576671837, 0.950195625803243, 0.900308673028698, 1.11627585801041, 1.15200675435816, 1.12563666185117, 1.0489876056199, 1.03137653743277, 1.06619432352958, 0.670862196286432, 0.701766991728854, 0.760400154906022, 0.760489377737195, 0.679240125215701, 0.880044649382749, 0.867605183276984, 0.656352570661635, 0.536181281809363, 0.553515664301945, 0.499456594990992, 0.532508433455904, 0.427990815743463, 0.368375774292814, 0.273232248927902, 0.249152952611287, 0.219734761404861, 0.175692236284837, 0.173952960584391, 0.185603943649138, 0.164826698888132, 0.148139609052131, 0.16077489079695, 0.171274614585845, 0.183721863959861, 0.214501415225971, 0.216813710321943, 0.201795229805741, 0.191282881935414, 0.17950708182493, 0.157713313754933, 0.136281657494433, 0.119569319495568, 0.110784240210642, 0.107521199914194, 0.105519666040841, 0.106258791770997, 0.104541916696249, 0.0964479346812941, 0.0931592665503606, 0.0983209971695481, 0.0979682822326969, 0.093956814251354, 0.0899520379823491, 0.0848510548226839, 0.077756700729539, 0.0689424341886702, 0.0546078371816216, 0.0422671806154857, 0.0304641865250745, 0.0232272657378633, 0.019797834353068, 0.00926901822613621 };
            PGAonSa_FAR[10].Horziantal1 = new List<double>() { 1, 1.00316661363106, 0.999781866398479, 0.99895344890057, 0.997274555450664, 0.996473098285527, 1.00181941397223, 1.00750028287925, 1.00841734268339, 1.01276244964851, 1.01407165974753, 1.01311579340379, 1.01785591009301, 1.0239456773804, 1.02068551956442, 1.00529035257171, 1.02934754769222, 1.01793556562165, 1.02803221024484, 1.03885719234278, 1.09065942931511, 1.07901746743621, 1.09564096352961, 1.01553895543416, 1.09944359592017, 1.09177460671615, 1.00796963776342, 1.27927718530858, 1.41712740922231, 1.53908941884552, 1.54389897881612, 1.62035439765919, 1.64848178604852, 1.51448852368077, 1.64911086047987, 1.83251955338983, 1.8521336039715, 1.70667566433732, 1.84136662743802, 2.04634603750509, 2.30306722804071, 2.28246095551504, 1.85357761573438, 1.69704510667918, 1.4956003596345, 1.67042136957674, 1.89131513728732, 1.88391534292114, 1.86305539817348, 1.82926184651319, 1.90422382631663, 1.85725933511734, 1.71459015596553, 1.63934019078929, 1.81211017299138, 2.07471075852079, 2.23342746302043, 2.04191187974384, 1.96367136007935, 2.31288773349793, 2.41985734716044, 2.33385347712722, 1.93817505507465, 1.73945779502876, 1.6404904983209, 1.8400664041166, 2.0863310704355, 2.03959247414565, 1.69697852282703, 2.05663262992736, 2.24115568325857, 2.08538582482891, 1.75889211005861, 1.54809171905209, 1.29306657854178, 1.03052113914759, 0.847229274346304, 0.730471425927915, 0.60009575003033, 0.574169713660841, 0.53773486636866, 0.519131828265948, 0.510636872503361, 0.50879417460737, 0.390510779843965, 0.390391745889877, 0.386239241908122, 0.377326237591609, 0.353531456376752, 0.334308289771291, 0.325978200528504, 0.352122452197492, 0.367301282944199, 0.359855574314319, 0.364220656435084, 0.36539065317942, 0.372188864483887, 0.352312114053645, 0.323593068906934, 0.296301695927478, 0.262096182212635, 0.229752034381777, 0.203737641648976, 0.177016929046531, 0.152904955431711, 0.126246864329478, 0.101041363277821, 0.0792690563597587, 0.0616184941346979, 0.047987880921929, 0.0223670681986127 };
            PGAonSa_FAR[11].Horziantal1 = new List<double>() { 1, 1.00943566112532, 1.02427123393779, 1.03979998865254, 1.05711861163453, 1.04405775364661, 1.01451312164796, 1.02432479959572, 1.03250977308953, 1.09249943350793, 1.11793501569439, 1.10244854965695, 1.09870247765836, 1.10200451854517, 1.09916236702414, 1.10902056251694, 1.1869304023521, 1.24808370620787, 1.35214345447042, 1.29702897373485, 1.25482522618275, 1.36491005374538, 1.47601333361996, 1.7019095804646, 1.68635016645881, 1.64910617594416, 1.48196934141376, 1.44562891897102, 1.75859508556233, 2.40503672243016, 2.5280023286965, 2.34187717324156, 2.14941294505749, 2.32864434129923, 2.49157450965398, 3.04045229150008, 3.40919123257046, 3.40738444883229, 2.66873657995256, 3.47812212899527, 3.65743493094083, 3.8250038147911, 3.62173271511986, 3.79752322265094, 3.81920321788642, 3.83032514001957, 3.71299168075996, 3.51142093832232, 3.45695030269883, 3.03498929920261, 2.75412622958734, 2.56275974498518, 2.28660728161686, 2.27651085990854, 2.33462642711071, 2.56714578563376, 2.6353612986007, 2.58538982583761, 1.57188599395483, 1.24761077783326, 1.38056426486949, 1.5786130652983, 1.33870411282055, 1.5383429675163, 1.62681546172716, 1.13830476674447, 0.817041561664468, 0.700656425993581, 0.664808666641528, 0.679553671203419, 0.525218324106766, 0.525773010590847, 0.393417555932943, 0.413688280996984, 0.418741777935812, 0.38448372044506, 0.329406700429477, 0.247892702348678, 0.180419249946875, 0.154896870250233, 0.135621691131254, 0.134953283345767, 0.143943891382942, 0.158688437817495, 0.160578142603763, 0.145807130505325, 0.143351990862826, 0.141259159463202, 0.132807344415551, 0.1467222222418, 0.170365575043196, 0.189968033284008, 0.198678055947215, 0.194222344702762, 0.193345418497561, 0.187790307364679, 0.172207317421279, 0.149058565941616, 0.128791858301919, 0.110721976967472, 0.0944502806734754, 0.0846901596714734, 0.0776206910040354, 0.0704753846419506, 0.0628394943824778, 0.0478214106868421, 0.0339870575503085, 0.0272155478551007, 0.0224886252268171, 0.0185115513284107, 0.00806240681073244 };
            PGAonSa_FAR[12].Horziantal1 = new List<double>() { 1, 1.04790361333636, 1.03107221048998, 1.15120725731229, 1.12123613220006, 1.17088852819519, 1.25191817295069, 1.28809846550042, 1.29902942368516, 1.32134375854466, 1.34564346009971, 1.27821332511107, 1.26510618163061, 1.22429776234164, 1.31601072772862, 1.36596273219657, 1.23817807021116, 1.37774791389117, 1.40839504880031, 1.48851752951968, 1.39914344943404, 1.44456467567625, 1.35027527134444, 1.45682321936576, 1.49127819373906, 1.71859201470699, 1.723004306993, 2.38303149476509, 2.45384187265961, 2.0120017918332, 2.13990261270224, 2.38332237677753, 2.49620398973768, 1.92705842656102, 2.09838599267365, 2.20753074138068, 2.3913119360525, 2.57481388399238, 2.5604404341511, 2.86793180949943, 2.93474934696988, 3.36875888402146, 4.12006058102712, 3.52394055923036, 3.32227981686068, 3.45438873084299, 3.77360265129258, 3.69052480932684, 3.77511523775726, 3.9006540966853, 3.541721207044, 3.16637481504752, 2.62642798827939, 2.28504885848202, 2.05365609601433, 1.60627354932292, 1.52131195544463, 1.71658046863031, 2.06830685337413, 2.06073616419708, 2.03545851731621, 1.90052300585836, 1.50309304539893, 1.24386209865554, 1.14270109158323, 1.02016975874246, 0.822089386103209, 0.932644912570563, 0.967100856550566, 1.19678109965036, 1.27472681330999, 1.34617887692394, 1.15540662396519, 0.844298615595542, 0.583593672734465, 0.410314094397031, 0.359039546379198, 0.312780967783848, 0.242546342352615, 0.226896696162103, 0.212112908761948, 0.187331293280819, 0.156542440655221, 0.138581717483754, 0.109845037455907, 0.0821192112055508, 0.0706593519536606, 0.0611886602556271, 0.0479212601784464, 0.0406110267553275, 0.0369461654963514, 0.0350294081714575, 0.0336764965394737, 0.0322726805553132, 0.0305996435725741, 0.0253705933799132, 0.0198814946681327, 0.0152333940307133, 0.011736623790658, 0.00926302133328679, 0.00845603706224681, 0.00775024094726697, 0.00686359378908727, 0.00595536318558466, 0.0052947701353377, 0.00433955239075926, 0.00354478516424168, 0.00301097788714941, 0.00268166066480114, 0.002396382979136, 0.00142952995406003 };
            PGAonSa_FAR[13].Horziantal1 = new List<double>() { 1, 1.04214466895017, 1.05808323431299, 1.07948271592024, 1.1287296695358, 1.13621355134797, 1.1822643159281, 1.15258735919217, 1.22578480889297, 1.14192069967822, 1.21925188004546, 1.33276272579098, 1.36705210839576, 1.36094834222505, 1.29676402400808, 1.23504596064042, 1.41034264169298, 1.44765368717796, 1.4480962611884, 1.48486852869623, 1.48986791624533, 1.53922609452129, 1.6408838247693, 1.66891690963533, 1.81092165367108, 2.08382262348932, 2.32481713646568, 2.57664264249766, 3.13330418603487, 3.22578516652853, 3.11051743607488, 2.99157500020117, 3.06690556722342, 3.08196202446764, 3.25282956787789, 3.524877576876, 3.5654406025444, 3.63374720708977, 3.52604168063681, 3.14626132251843, 2.87685981669389, 2.52619993437387, 2.25975428648576, 2.01790681268927, 1.91326622301975, 1.90852039908553, 1.96125018664106, 1.94696264585943, 1.92201041255945, 1.86833289075932, 1.95465896319662, 2.01480968870506, 1.9813028127143, 2.10289711629504, 2.17298295777129, 2.14603154166857, 1.90133550060485, 1.35511280272733, 1.26818554490696, 1.10053028413251, 1.06320171450489, 0.928080560987146, 0.874895145723081, 0.883191933172219, 0.812623820137922, 0.670630699257996, 0.526413979258925, 0.478172160395974, 0.334188797602411, 0.284628734050571, 0.237286547448851, 0.268032119250002, 0.307694082114914, 0.26603239999392, 0.216945667111029, 0.160174955317907, 0.133214133399854, 0.133841068543538, 0.122598740943997, 0.0965301482310004, 0.092872984835358, 0.0990084553988218, 0.109548654977348, 0.107175796655571, 0.116560958534839, 0.107396851197677, 0.100188867341346, 0.0940759457001923, 0.0835462069619127, 0.0825975249830794, 0.0791844299780859, 0.0739795986792519, 0.0676590874749767, 0.0607903745964306, 0.0538117066637341, 0.0405059112688284, 0.0351550394874367, 0.0298877292555726, 0.0264896370624888, 0.0215830917058054, 0.0182871402297987, 0.0163715010948119, 0.0145903150501092, 0.0129804364405605, 0.0115478198983063, 0.00917812665127045, 0.00736462823336078, 0.00597778904329804, 0.0049112840279063, 0.00408292853457934, 0.00188949597525877 };
            PGAonSa_FAR[14].Horziantal1 = new List<double>() { 1, 1.00747201913311, 1.05678289744179, 1.1289245968362, 1.1249522175886, 1.22273589304495, 1.21357877763325, 1.12223971630316, 1.13332941759917, 1.11538623110017, 1.12913007783757, 1.16368529130496, 1.19823081047904, 1.28493010699649, 1.31001760749783, 1.44689209510216, 2.02182850719098, 1.80252382372581, 1.8580801079374, 1.8012875162023, 1.78369902678799, 2.00535201024478, 1.96049974652274, 2.02114040245003, 2.00295504870242, 2.26947778362603, 2.14205865351588, 2.39730369388691, 2.79358739605009, 2.6438732921649, 3.05737672042818, 3.41628797145392, 3.76344441662879, 3.95371868339331, 3.57577050148199, 3.75147861733526, 3.36016751738843, 3.20086556733381, 2.48654821760913, 2.29991216209923, 2.31781619125662, 2.30126936316286, 2.12516777305165, 2.14665298820889, 2.15860548160964, 2.15605455187939, 2.28694461916349, 2.34644476999529, 2.30652328996943, 2.17527206273843, 2.04961881468446, 1.8357301998336, 1.63215308163526, 1.51261826325025, 1.39244875377959, 1.2859645451181, 1.20946782701655, 1.06309540306115, 1.28663269101987, 1.42423101919147, 1.44759160489406, 1.54616431979231, 1.27039227862844, 1.21672372043407, 1.09744247434861, 0.863673525094058, 0.736619166530281, 0.673321894067226, 0.430396209569332, 0.308506248162124, 0.402242841287121, 0.411110648572934, 0.355077823315612, 0.340383175496932, 0.297846137118746, 0.292642392536383, 0.301754648080996, 0.320144912577433, 0.410384717079653, 0.407384048173415, 0.386201256950666, 0.33386461862365, 0.249197322018002, 0.188533741938292, 0.163704451790565, 0.167263987202012, 0.172036335732006, 0.175871588250288, 0.177081930274461, 0.165989871934584, 0.149603265798324, 0.134557798612271, 0.118581166041005, 0.104990907323126, 0.103718940006961, 0.089964619631096, 0.106096455937441, 0.0823091502533727, 0.0571194795038879, 0.0494330644212402, 0.0505380047661708, 0.0393812037537064, 0.0306769068817507, 0.0221892489526837, 0.0183042894206557, 0.0158440678623342, 0.0134800098919809, 0.0114021616753412, 0.00965439464175499, 0.00821315736100047, 0.00406878994500294 };
            PGAonSa_FAR[15].Horziantal1 = new List<double>() { 1, 1.03212684361006, 1.04643437984858, 1.04384884533077, 1.08095302433842, 1.12908969197468, 1.22388629677872, 1.29657186373435, 1.30390498900408, 1.30257481496204, 1.28267468548991, 1.22936471557725, 1.19338162344322, 1.15483532919923, 1.08040225133003, 1.00509067236739, 1.02660710985702, 1.01543336874881, 1.0388687183822, 1.07574594429516, 1.12452578527725, 1.18424878525659, 1.19500016470151, 1.1221708328704, 1.01398567041051, 1.16729206713792, 1.28363302494139, 1.56898732021714, 1.85511934159595, 2.23765478452297, 2.28060140057696, 2.20967171918784, 2.3451317304992, 2.19566483298988, 2.20901207569123, 2.51725680984904, 2.68250657828988, 2.57357439678771, 2.641471337192, 1.88612788988336, 1.80079352628162, 1.87621732559367, 1.8247637370828, 1.56860404026756, 1.68066192140221, 1.8226120095873, 1.71667432482152, 1.52655155799252, 1.43573654235146, 1.52854165468626, 1.62080492697582, 1.47627070004841, 1.71446257897996, 1.8578254711161, 1.91590033939677, 1.80922093953556, 1.7511737076096, 2.07254571025152, 1.86635058865436, 1.83761631695047, 1.7934160153513, 1.7097618862845, 1.69646154163961, 1.57442721561214, 1.37497033977084, 1.23455169645345, 0.953793969021601, 0.863336551061096, 1.07782760386105, 1.32082848766609, 1.21744563035734, 1.02015974371329, 0.82066685686434, 0.630185934044583, 0.547508010355538, 0.549918793781988, 0.544185227223875, 0.498792375045991, 0.450918950667153, 0.44174144766484, 0.408818732870345, 0.36620794039927, 0.288509027038405, 0.234583324726051, 0.218916135667144, 0.246027008814043, 0.247125679533297, 0.258261092646552, 0.282047144829573, 0.265687986113709, 0.192821331245998, 0.166392266510489, 0.182187866914482, 0.1739098853845, 0.173385827518998, 0.221632928912038, 0.225199777345894, 0.204710016475734, 0.199828152121662, 0.189589776000366, 0.163880931417734, 0.131406260555552, 0.101428771622656, 0.0835292629914595, 0.0612838677943788, 0.0407257976717348, 0.0245197555271314, 0.0193267449008134, 0.0151645423894225, 0.0118365111419174, 0.00576097958873754 };
            PGAonSa_FAR[16].Horziantal1 = new List<double>() { 1, 1.00520274620303, 1.01321044758975, 0.992055277243017, 1.09372098876867, 1.1143321576625, 1.01126585162695, 1.03606541324547, 1.02525422129435, 1.14168768918435, 1.03624890912016, 1.02533749536291, 1.04413400094865, 1.1018510904823, 1.36481741742006, 1.58178214457508, 1.48587154995848, 1.33403990752812, 1.18329564030959, 1.12260097974662, 1.04199984140265, 1.02049399935013, 1.02069988297692, 0.947999319579721, 0.970289360649739, 1.05924322284036, 1.11667199160397, 1.15720072753917, 1.18820420726539, 1.19866179827213, 1.13144372336354, 1.36025240830489, 1.62383659535435, 1.46395435911503, 1.59041837687123, 1.63090568500349, 1.45177584043517, 1.30156741464774, 1.44152476074921, 1.3391154410837, 1.20325735516118, 1.29071333027437, 1.70502002448425, 1.8192383603043, 1.72383138549428, 1.47672646707253, 1.38320048190159, 1.63507022535679, 1.80850102701197, 1.91255929877376, 2.36201246223636, 2.58445047170157, 2.85078730610271, 2.97101162719413, 2.99360861062238, 2.64529494189541, 2.1218651131659, 1.61886023744827, 1.22300837406544, 1.14863605235721, 1.06212643054074, 0.86174098458823, 0.824154668819239, 0.848939375013469, 0.87125891770074, 0.72836626529821, 0.677103334540598, 0.703776981164368, 0.866678425467302, 0.574131391833994, 0.556099626752234, 0.471339178838176, 0.414385783651878, 0.343373298609302, 0.307243860577449, 0.316501719149207, 0.343840512164814, 0.362229853586194, 0.34084222723401, 0.325345090460119, 0.317896036719261, 0.298910804475626, 0.271452540371708, 0.230839693442627, 0.202736118076771, 0.177705146609438, 0.165119798535339, 0.152165408244844, 0.126852853256236, 0.104398293592981, 0.0880225944726523, 0.0755809673977837, 0.0645576148800299, 0.0549861603938068, 0.0468187318112591, 0.0350166830599412, 0.0282824053819319, 0.0230183753229224, 0.0189080886529875, 0.0156982290032701, 0.0134599141021706, 0.0127832390641585, 0.0113689399022764, 0.00965650702107106, 0.00825151865328674, 0.00606844082278964, 0.00472322984542617, 0.00392482402076077, 0.00332173564082011, 0.00285370608312886, 0.00162719203816212 };
            PGAonSa_FAR[17].Horziantal1 = new List<double>() { 1.002671297, 1.006695892, 1.006518629, 1.006252852, 1.0058987, 1.025630729, 1.024389785, 1.022533989, 1.021916884, 1.004926068, 1.007249912, 1.009584529, 1.0107559, 1.011929993, 1.01428638, 1.013354965, 1.017951511, 1.028658429, 1.078464078, 1.099763445, 1.031994797, 1.089737734, 1.261736608, 1.301988471, 1.309557773, 1.372756622, 1.439784268, 1.60514852, 2.167929274, 1.868343805, 1.82846643, 1.514207752, 1.631179148, 1.751130905, 2.053807732, 2.098291155, 1.901624889, 1.840263071, 2.560874783, 2.850808037, 2.411982778, 2.226033665, 2.357052768, 2.407314232, 2.481126306, 2.295818513, 2.482409994, 2.259728934, 2.026911428, 1.72594093, 1.834969573, 1.790982401, 1.71495276, 1.832509184, 1.922009108, 2.027188988, 2.056682697, 1.921206795, 2.254913401, 2.210165214, 2.120197437, 1.936442673, 1.664390446, 1.396596911, 1.303521876, 1.32152412, 1.362970309, 1.405959627, 1.288259008, 1.195309439, 1.142925861, 0.967487979, 0.765161881, 0.610295405, 0.545746102, 0.470955693, 0.414304987, 0.364546731, 0.302818397, 0.284949607, 0.257451292, 0.241893098, 0.177247566, 0.143530975, 0.119196565, 0.102862305, 0.096420549, 0.090236898, 0.07908833, 0.069907146, 0.069227579, 0.068501189, 0.069662743, 0.070015814, 0.071096706, 0.07881594, 0.078821771, 0.072918777, 0.062740492, 0.055568792, 0.052597282, 0.048236913, 0.042771522, 0.037113994, 0.033877434, 0.027405648, 0.022170202, 0.017934911, 0.014508709, 0.011737034, 0.004066364 };
            PGAonSa_FAR[18].Horziantal1 = new List<double>() { 1, 1.03019105032841, 1.04738725584314, 1.06930319275775, 1.09464572758752, 1.10313254088969, 1.11767896946847, 1.11813765255991, 1.11220652735442, 1.13508716889917, 1.13879809152551, 1.16272311918615, 1.16526263576358, 1.15962142179409, 1.16528380575242, 1.19847776019166, 1.25363116763367, 1.30194343437789, 1.32874934468594, 1.32719276245126, 1.40473313905948, 1.62183990137137, 1.48356106262759, 1.41966062743731, 1.52152561524545, 1.74096725090935, 1.80608084407098, 1.60229029876441, 1.88021814497385, 2.00037341508085, 1.88128575927194, 1.82216209684035, 2.22212728396982, 2.7022508696602, 2.78785554187674, 2.47811625911008, 2.07544631187922, 1.94646345045532, 1.88800282031296, 1.4914674654025, 1.63623578780732, 1.65023179667637, 2.21872626645783, 2.30426448843163, 2.04408179730853, 1.72566046689822, 1.67513740645879, 1.74695130108693, 1.57332681376085, 1.678574883396, 1.40411156466505, 1.3230428565842, 1.35745996593396, 1.3595778469004, 1.32902661273416, 1.34236664597692, 1.37362531060343, 1.67336941836338, 1.79428416181987, 1.97376744355625, 1.89410830389872, 1.99681509279071, 1.89190309672833, 1.61518311599302, 2.01236415556296, 1.91578843065991, 1.59507427284764, 1.42968314701293, 1.0432414663628, 0.948356106262759, 0.844294144057658, 0.786221336349665, 0.782699767512359, 0.71185322376296, 0.77444258978354, 0.872189132680259, 0.799708971459033, 0.677439054689432, 0.746563478652565, 0.993430834853211, 1.06733967629323, 1.09909171927066, 1.09940485868885, 1.11260934519754, 1.11005365710087, 1.01721855161405, 0.976714188391143, 0.922728658666567, 0.786449795812517, 0.662112864855202, 0.587718877837697, 0.548821963628195, 0.526053934662946, 0.504128294836787, 0.477746372360698, 0.386607806256967, 0.351223052000843, 0.305909572980743, 0.251222934389794, 0.197567274255147, 0.150492099330764, 0.11663228993711, 0.102992730755084, 0.0904025561585409, 0.0793794311800416, 0.0625367350761135, 0.0513077613589486, 0.0434245573634661, 0.0373923160585244, 0.0325760847928619, 0.017959618834351 };
            PGAonSa_FAR[19].Horziantal1 = new List<double>() { 1, 1.02099900640859, 1.02272995498229, 1.07655997322373, 1.10303435621567, 1.10365895348297, 1.08341097848032, 1.06911697850599, 1.07677602623603, 1.16276849109796, 1.18490182841436, 1.18999537810645, 1.1892855797973, 1.19286928287861, 1.21981490126251, 1.23037730597672, 1.24175343323383, 1.2831361051932, 1.27805980608243, 1.28658790443935, 1.29032665237954, 1.29268219822054, 1.33252893732422, 1.34256036073069, 1.33555452098817, 1.36273218072803, 1.3176570428759, 1.35113368927033, 1.43082864008829, 1.3542850759541, 1.3427936643243, 1.40783508780861, 1.35777179710876, 1.58119228023864, 1.63790314555935, 1.77338374149541, 1.86747787875913, 2.06127132997564, 1.62664461677728, 1.92322229078043, 2.09241935826575, 2.17417701578828, 2.27051730496272, 2.40600168761175, 2.54305334868495, 2.48200943186052, 2.47649555702863, 2.55401798646587, 2.70701591660648, 2.7005027702961, 2.82764796949087, 2.84357530499343, 2.90139841206295, 2.9005064307853, 2.88405105919621, 2.89668816187272, 2.73912513887244, 2.38922023796125, 2.11597734115107, 1.94548963566141, 1.86025703786902, 1.54129610349339, 1.11676960565382, 0.859243671403354, 0.798079842001505, 0.720909997616475, 0.715185539468804, 0.632094327861603, 0.474485233186837, 0.410232918611126, 0.311999904069938, 0.345547025400219, 0.320460051966324, 0.238699028476713, 0.231864221936723, 0.229952983751004, 0.230195333381158, 0.237256921953532, 0.207824253602058, 0.179390372871315, 0.176702500892507, 0.172316182959665, 0.133389594070681, 0.102205339559811, 0.0991457596282963, 0.10100953767811, 0.10513314187993, 0.107927462567816, 0.10904062995757, 0.107734045684168, 0.108965610966152, 0.113255136307993, 0.117952217152001, 0.128723669459508, 0.138045799451894, 0.156360152587703, 0.161175946883356, 0.154029388679369, 0.142901522532099, 0.130531320008171, 0.120702485745655, 0.111668082827194, 0.103492737820827, 0.0969907412764126, 0.0891052481106932, 0.0728422625778301, 0.0573751809996207, 0.0438135313139074, 0.0373510848827476, 0.0329057994140272, 0.0166364185437017 };
            PGAonSa_FAR[20].Horziantal1 = new List<double>() { 1, 1.00127733602701, 1.06155386913241, 1.26217289578423, 1.3784950831844, 1.35120697246756, 1.27168363162302, 1.2942219862381, 1.25155835858651, 1.17634877878215, 1.26506427689572, 1.33167741545581, 1.31152840011396, 1.2791309452891, 1.30561786112046, 1.33720332910289, 1.43727326098405, 1.3122264238908, 1.35961390694743, 1.38367047406909, 1.43484291227434, 1.65690210399993, 1.70050376855137, 1.9756244226303, 2.55572491733361, 2.7258281747779, 2.60308779472834, 2.28617075465997, 2.79994431350203, 2.66238096471462, 2.77838845864954, 2.45301872620373, 2.38795617602113, 2.49174976473534, 2.60746673918862, 3.18925336924897, 3.17606084937018, 2.78200246919975, 2.36736857554802, 3.25317326702755, 3.23496335051413, 3.12642648087234, 2.614349417666, 2.31104535211997, 2.31976913845649, 2.05019814032997, 2.22669886986627, 2.38467887452839, 2.53505443463096, 2.48854628022827, 1.9658244623447, 1.74555285037168, 1.4825394769786, 1.31827121482901, 1.17063594844035, 1.31979503915322, 1.32352948794323, 1.37672304384988, 1.32393353881219, 0.996658378443714, 0.991464425393043, 0.855471953862226, 0.933193901249277, 1.30356782097438, 1.52398706691877, 1.12502223143136, 1.06713244752951, 1.07308701770744, 0.912516943372443, 1.11493865851658, 1.23821475131014, 1.16146926018977, 0.944199107289319, 0.665448038885579, 0.458305058406071, 0.359227123209614, 0.337544786621427, 0.340360365027153, 0.325708427223359, 0.375369041760557, 0.388631450352681, 0.3918638141366, 0.404673349046423, 0.417294067877093, 0.436319683666157, 0.471934436703014, 0.477879941637097, 0.48294568623896, 0.482747977587264, 0.459340222918663, 0.423535488271301, 0.376471116406365, 0.325982413426921, 0.285668928660848, 0.257689355677001, 0.196887297434968, 0.14630578362558, 0.122936448323793, 0.102777202206739, 0.0854135477911022, 0.0702657411484369, 0.0573071045611127, 0.0523922315176945, 0.0478092759028551, 0.0435494746475347, 0.0360442297564471, 0.0298670862579537, 0.0248656617196336, 0.0208393120774949, 0.0175996529306638, 0.00849460833829763 };
            PGAonSa_FAR[21].Horziantal1 = new List<double>() { 1, 1.02826730485395, 1.05109361840514, 1.04336560404037, 1.03678221303114, 1.05864040537122, 1.10443729170662, 1.15118117458703, 1.16896508593014, 1.17057500785226, 1.16074981446428, 1.155203199831, 1.15921772025939, 1.1534568014476, 1.12225372391729, 1.11685859537648, 1.08071067824076, 1.08549513715745, 1.03334834296451, 1.05603706822989, 1.14973385700269, 1.1287306577276, 1.26729651526396, 1.36677534751466, 1.50837454033005, 1.65699240345889, 1.71353118250878, 1.5810272702762, 1.59044914931526, 1.82382362015627, 1.95448273753436, 2.07996909127801, 1.97379429578424, 1.89681434476011, 1.59398780884401, 1.8931697839447, 1.82352148183974, 1.72625851588102, 2.10400256831467, 2.36231832092259, 3.13187072816168, 3.59312225344596, 2.77573720915365, 2.40632489180558, 2.21589658920029, 2.1013036142636, 2.18356250816496, 2.20758014170204, 2.21111602166946, 2.16090685967941, 2.0387879444866, 1.84178681320514, 1.73867120291076, 1.81103430256637, 1.83100850823723, 1.77973227265273, 2.0268511183565, 1.65795663328414, 1.07231390142008, 0.83027776156367, 0.839637100472803, 0.911668598461791, 0.973231434614989, 0.991187400804405, 0.860094393902754, 0.717244954401296, 0.707570413237383, 0.683877432463609, 0.580677601460937, 0.539294102604727, 0.487466124096295, 0.427555737153562, 0.369601327518491, 0.316811342833874, 0.269412345143689, 0.227358082547412, 0.209595240279179, 0.183449463405685, 0.140788811709736, 0.128378153759774, 0.120972123779425, 0.113315127206624, 0.0979704754995567, 0.08363864034978, 0.0733435899146397, 0.0666945734624162, 0.0632992559114321, 0.0606793247889618, 0.0558752143736675, 0.0514269989910192, 0.0473176121344529, 0.04377878583202, 0.0408396776820682, 0.0380059149065095, 0.0353152995394267, 0.0292693089176666, 0.024235717918998, 0.0201366432349647, 0.0168213492546606, 0.0141467719564498, 0.0119855518402086, 0.0102318710061178, 0.00879959084857228, 0.0076221964649539, 0.00664771005839858, 0.00515394600424161, 0.00408856794220736, 0.00330929012783203, 0.00272599918280897, 0.00228021313676276, 0.00111479866247509 };

            //H2
            PGAonSa_FAR[0].Horziantal2 = new List<double>() { 1, 0.990394532368361, 0.996331084099168, 0.999878105759473, 1.02979377307806, 1.03823953286097, 1.05334575512878, 1.13629730428369, 1.11855595016158, 1.13220044893347, 1.19819580405773, 1.18659268122803, 1.16282189397861, 1.13103953221624, 1.16478872302989, 1.21943159406035, 1.27685304934057, 1.08611515802228, 1.09429013126096, 1.11822109358677, 1.18430570350203, 1.44195466783417, 1.68303629083684, 1.7077354890951, 1.57685734082375, 1.50580307250048, 1.53320751698611, 1.56289490963607, 1.8474941868536, 2.23270960419832, 2.24411527850618, 2.18675245334825, 2.1352264482698, 2.17542535549297, 2.30760102262216, 2.42098885846346, 2.34620623820472, 2.33769781873782, 2.31067557817662, 2.17621917914202, 2.16975979178449, 2.37122981617744, 2.32886703433731, 2.5327003966499, 2.53088306433659, 2.39028964287808, 2.18560604305305, 2.07456744166555, 1.93834287097001, 1.85975533710406, 2.15106061085334, 2.78986299288843, 3.3524059203126, 3.54454952421958, 3.6728991225428, 3.99376908878918, 4.44219482970972, 4.61311674707993, 3.43967212262601, 2.18910168780205, 1.94548244833749, 1.80016638060137, 1.70611157574196, 1.95095318273921, 2.32849631466364, 2.33815718876824, 2.06602074136279, 1.87295739000455, 1.77698934926407, 1.64615330991218, 1.38109277279981, 1.19378323255064, 1.19136529407036, 1.17205543306807, 1.026336610643, 0.790918335089887, 0.580765814165884, 0.437892869670477, 0.328662332604453, 0.319436852638325, 0.312049860184284, 0.29632751793709, 0.23621915093509, 0.204349952118733, 0.166897231469507, 0.132025767435057, 0.116794930972601, 0.103344798107879, 0.0818051388597025, 0.0669245921932481, 0.0574242961212044, 0.0528107905214233, 0.0497483639475923, 0.0478879556200196, 0.0474694453449395, 0.0468493360994931, 0.0446583828281035, 0.0407395132168615, 0.0359211447017611, 0.0309550121602097, 0.0263072552862308, 0.0221986537637416, 0.0186974079240121, 0.0157766002950848, 0.0133687155711732, 0.00978695908927071, 0.00752496464563329, 0.00621684804059542, 0.00554743710811254, 0.00492853673116719, 0.00278485021817054 };
            PGAonSa_FAR[1].Horziantal2 = new List<double>() { 1, 0.997404277036315, 0.997157870378687, 0.999568894012382, 1.00545116615226, 1.00936239635758, 1.02399337280207, 1.06146747210226, 1.07433070267106, 1.07945072025342, 1.09448046973647, 1.10581116078457, 1.1082511361439, 1.11962937564653, 1.14280766227495, 1.16963344368097, 1.23520762296823, 1.31474245115453, 1.3599356722242, 1.37409243208232, 1.40109974292136, 1.52936159331701, 1.60510332279166, 1.70458483331097, 1.77097071754844, 1.83905841380469, 1.78531492398059, 1.79196367720728, 2.25211458543559, 2.00104965854926, 2.21996760365299, 2.44016132662301, 1.84660720644377, 2.35710157300854, 2.48537251044217, 2.66557058673736, 2.84904210996795, 3.07217961058872, 3.39431299351333, 2.85448587969396, 2.54199532334534, 2.27222652506385, 2.09014743190797, 2.22429345638169, 2.43612921767999, 2.72236668734144, 2.70528094268509, 2.57557721182202, 2.40775018675976, 2.08262146252706, 2.15235792785949, 2.26436940711304, 2.17564187772017, 2.2065230139803, 2.27954264726549, 2.35060117095994, 2.43848550775938, 2.35666412722698, 2.08675289490841, 2.50723634646129, 2.58825045989922, 2.69259712828467, 2.20733028107476, 1.51337432362323, 1.22231163679743, 1.33477789060263, 1.42790079913103, 1.36039932248735, 1.05306534319946, 0.767026097761736, 0.643741408258427, 0.653050972999874, 0.642153923856962, 0.547309761275059, 0.445365452138254, 0.395149001006971, 0.337575007687, 0.307008747858999, 0.279806171366743, 0.248964553155474, 0.228276326258476, 0.208283405695037, 0.186321704390202, 0.166159426798098, 0.153567581675037, 0.135629367193468, 0.131596138220187, 0.128088583827397, 0.119395120260608, 0.109491664755923, 0.0992526650908757, 0.0918498779061351, 0.0848783657701846, 0.0778075090632637, 0.0708852148608996, 0.0550193310883419, 0.0418671961099024, 0.0314253441715633, 0.0269936802820786, 0.0246534298813508, 0.0223464000008453, 0.0204725893726034, 0.0186957775915757, 0.0170477904233186, 0.015546294760266, 0.012962575139766, 0.010878029761106, 0.00920538079443958, 0.00786096409246378, 0.00677204108609123, 0.00360548307644841 };
            PGAonSa_FAR[2].Horziantal2 = new List<double>() { 1, 1.02064523977275, 1.017472852296, 1.02319935313744, 1.05215910694392, 1.03339022874796, 0.992268881194321, 1.05946996579299, 1.06726227562322, 1.09843836833888, 1.10832157547797, 1.11629354215627, 1.13261832844968, 1.13993861071653, 1.1172402896881, 1.0858789105501, 1.04573013314065, 1.12530159526225, 1.13728292025108, 1.1410706446707, 1.17671245835798, 1.09522902148331, 1.04573233601754, 1.05109352644242, 1.11671282305648, 1.16863609979179, 1.28251492173729, 1.3593745200329, 1.46160391710672, 1.40500099557797, 1.43575193305506, 1.48432169688096, 1.48471454325857, 1.38520447531572, 1.36948694874995, 1.28110385671118, 1.14932555864652, 1.14666301478632, 1.13862226939642, 1.20468409950003, 1.23446772926105, 1.24294390998164, 1.09186094511006, 1.13210248811273, 1.26303537098221, 1.55403907879115, 1.64524674852312, 1.73649602815179, 1.79451368616812, 1.77308091790943, 1.71373663848086, 1.67269581831553, 1.65065236363182, 1.66840387985363, 1.69926863263638, 1.70082900376239, 1.63509760519135, 1.48242355129943, 1.44422811377565, 1.44042203204868, 1.47327794077027, 1.53724091873183, 1.59230794554439, 1.64458099017603, 1.66717883554215, 1.62552732895181, 1.52450706652309, 1.38540395805576, 1.15699719977633, 0.947165833673249, 0.714260188886902, 0.553141161696915, 0.42514177654433, 0.347550823123305, 0.302408858110619, 0.346574703899692, 0.391294206078888, 0.381788302797176, 0.255691224215785, 0.168464764923053, 0.146480053622919, 0.131719309916997, 0.123328796630773, 0.131903862047038, 0.125226207920003, 0.100765548669934, 0.0890567685044412, 0.0785866660106989, 0.0683859386452283, 0.0642437713350156, 0.0588556446211315, 0.0527006230347737, 0.0463476362457936, 0.040088283962579, 0.0341631937700684, 0.0262606911428317, 0.0261832477821619, 0.0255082495903567, 0.0228489855690759, 0.0174043673013277, 0.0176620916585252, 0.0158693537358895, 0.0128711403914243, 0.0115109618213288, 0.0103574865321615, 0.00835656450580354, 0.00671815034708161, 0.00537793228919417, 0.00432236263930596, 0.00350438549953844, 0.00150102807040346 };
            PGAonSa_FAR[3].Horziantal2 = new List<double>() { 1, 1.00698136093283, 1.01131438037973, 1.02151890492617, 1.02636073389142, 1.01794698976473, 1.02617445173363, 1.03553377373892, 1.05052526745657, 1.10903986920461, 1.10450187909866, 1.12843461496262, 1.11636214457183, 1.11071158578565, 1.16090829733285, 1.21277310833182, 1.18470117086475, 1.2075216394759, 1.29642826569503, 1.39035004165727, 1.43483952605961, 1.30319561314561, 1.49824629515534, 1.78567122465146, 1.69910910105897, 1.70103944238335, 1.47765036104979, 1.65811858637765, 1.63245535558189, 1.7324608415613, 1.69704221310438, 1.41557107839887, 1.49180810646899, 1.73087925178475, 1.79208168201334, 1.82366826342829, 1.78867826479074, 2.44625910461582, 2.90178559586779, 2.03484682060365, 1.8932392236676, 2.10140079359816, 2.58334920851183, 2.34774086162431, 2.60208473245903, 2.9634064073828, 2.72934769896321, 2.45562988086382, 2.31488346212323, 2.43518677047024, 2.30335205398686, 2.56007479017636, 3.26728656224416, 3.41828965247828, 3.59866986099372, 4.03059126800878, 4.28019127379619, 3.27028576527001, 1.80063498704465, 1.38743674545176, 1.28662132394166, 1.19066280276879, 1.0245467435588, 0.891832160378689, 1.02001176772725, 1.05507169753083, 1.05693843766541, 1.11837477558727, 1.4228032269616, 1.54836795127003, 1.53995661856287, 1.46703227805596, 1.3349537067738, 1.16725123494822, 0.992097175383747, 0.898463262626494, 0.746893187378148, 0.656416124197751, 0.531107010358252, 0.401165559624156, 0.348996608338448, 0.326218640996302, 0.305927450032373, 0.260266287028854, 0.231049226718046, 0.203031124191722, 0.187512373596403, 0.183365425308089, 0.166955172916865, 0.143331098751246, 0.140902407440676, 0.137466677196532, 0.129660399789242, 0.118641900584408, 0.11010677162772, 0.0893812840085509, 0.0808182428709396, 0.0676126163057776, 0.0552869468655766, 0.0409558806684937, 0.0349573239030754, 0.0314897629212901, 0.0282962296250122, 0.0254075901840757, 0.0228307774295956, 0.0185197621858071, 0.0151627647889345, 0.0125470678947222, 0.0104992000115748, 0.0088799619478, 0.00456261672777606 };
            PGAonSa_FAR[4].Horziantal2 = new List<double>() { 1, 0.991328365262196, 0.996408602866907, 1.01455331680572, 1.02107666258087, 1.01065195629799, 0.983088364404009, 0.999592079165436, 1.02230296576796, 1.1367587767908, 1.10940126255027, 1.13727143024102, 1.14982494691383, 1.15843616984638, 1.2156368335858, 1.28438010430352, 1.32036662626039, 1.33580212480176, 1.22273070393303, 1.22107276686633, 1.29581769636801, 1.46140617227979, 1.42767803556618, 1.6572914508262, 1.87623710109153, 2.07312764336935, 2.28684372030576, 2.29507242923773, 3.27916690426761, 3.17270662390038, 2.91298667496247, 2.56300810139246, 2.60794601555915, 2.5778784390267, 2.32278648604854, 2.32541694026063, 2.29830813069501, 1.91614248604177, 1.69950434089874, 1.68478531507579, 1.90573810522607, 2.04951057968797, 1.80471545192829, 2.02158338776983, 2.10275794005907, 2.16969055040801, 1.72255003311357, 1.56026275183113, 1.38710162790054, 1.350409078257, 1.49358110454235, 1.50816152197098, 1.68225733509412, 1.71178741593867, 1.70910925333832, 1.74989710232235, 1.75028018091924, 1.69600525526246, 2.20103750218075, 2.16569207933482, 2.038791436429, 1.73598940139805, 1.6258606565013, 1.14226556690833, 1.38258231673063, 1.40443614613333, 1.37488037615665, 1.36228253867344, 0.967499295666102, 0.955942573780034, 0.869396734487858, 0.943334008966919, 1.07921935526489, 1.35592546651182, 1.14059097425046, 0.783140533103129, 0.664800299461883, 0.629625102403656, 0.535997531584929, 0.457482227919626, 0.487707609120941, 0.494842977297018, 0.33686525965502, 0.257655869515017, 0.308243896572731, 0.329808652664302, 0.28861598812541, 0.255447140517294, 0.20758760982104, 0.238600066509445, 0.279982011961537, 0.282492094240158, 0.288106157656745, 0.268584308626411, 0.256978862078719, 0.184641455935799, 0.12843998651744, 0.12756655602461, 0.0957510457735167, 0.0814551001960843, 0.0967030680728126, 0.118405444515144, 0.106041632202767, 0.0864809954058798, 0.0755508342757387, 0.0464734749830198, 0.0321085075065903, 0.0241544746798316, 0.016403583605704, 0.0129565537492865, 0.0064699631939665 };
            PGAonSa_FAR[5].Horziantal2 = new List<double>() { 1, 1.00163251622303, 1.02019375653474, 1.01162686804372, 1.00470198408442, 1.00860563241818, 1.01875733202465, 1.03029643321298, 1.02022828343581, 1.01440088051505, 1.03568921888289, 1.03970066494594, 1.02171294018175, 1.0159796296555, 1.05101362811049, 1.04322267241904, 1.04172299251768, 1.02490865526154, 1.07475074081288, 1.0865246776413, 1.07276162232156, 0.992664219561572, 1.15039680897636, 1.13869798792507, 1.29754255440557, 1.5380920012767, 1.51998804473105, 1.3247637213463, 1.5563077090136, 1.72531715330708, 1.73135145407013, 1.9383157145105, 2.34394776369789, 2.53170979586167, 3.10424778401868, 3.52736309622489, 2.78779951098311, 2.54903544753058, 2.97845916719533, 3.43883190485967, 3.94460092832558, 4.01950058287207, 3.40170099018408, 3.28023218945622, 3.34266526063989, 3.23287762216659, 3.02704194333213, 3.07832888744573, 3.05575989096879, 2.6685393776671, 2.33237097283893, 1.87890941379911, 1.97176832818373, 1.98771422163055, 1.96515339564165, 2.04111863996692, 2.06502417014857, 1.86442972760911, 1.50425827387107, 1.38708530490285, 1.29901956779173, 1.26867147600921, 1.28779094514888, 1.08602074302418, 0.736217638607717, 0.636571947868069, 0.524677641301343, 0.599427327857701, 0.747704817662381, 0.800882043718437, 0.718218053457658, 0.533267459871702, 0.465969258406971, 0.41588785662533, 0.381476923774354, 0.371294123600507, 0.337513372585061, 0.324105338148826, 0.305400982514365, 0.284660857537526, 0.272759619234172, 0.260747710352509, 0.240185148530248, 0.225663476574288, 0.212100914488463, 0.196834673864427, 0.18915504766162, 0.180936459168777, 0.186996167513981, 0.187919748939352, 0.18324512281166, 0.177305204363673, 0.173304801637682, 0.168158132152636, 0.160865339023859, 0.173113058732894, 0.177465978483152, 0.163142849386541, 0.149637770637533, 0.137858378031613, 0.114490940378367, 0.0944266992572499, 0.0754927792653045, 0.0605999299446542, 0.0522886195907745, 0.0384197169163102, 0.0284692485233161, 0.0214207793433194, 0.0178534124833988, 0.0150931844160855, 0.0074326929691369 };
            PGAonSa_FAR[6].Horziantal2 = new List<double>() { 1, 0.987830018974816, 0.989010419146201, 0.990585490386773, 0.994042315879677, 0.994474817562926, 0.993139269367574, 0.995001258186715, 0.995825668029136, 0.999871205886954, 1.00132534668145, 1.00624332650965, 1.01014221760509, 1.01323476403898, 1.01737827893659, 1.02590886987629, 1.00253252582683, 1.0130490114733, 1.11268528499629, 1.13130134761999, 1.1398582924706, 1.20559323503608, 1.21643935710059, 1.37243920747839, 1.38159209076627, 1.3096104211865, 1.37159609486048, 1.63777739616559, 1.73082391676925, 1.75673172398784, 1.77368281452968, 1.87040528064365, 1.9521874171127, 1.68195781503975, 1.80534682596897, 2.24685793371736, 2.24053937104266, 2.23381699844257, 2.36460040670035, 2.22003857872508, 2.1851026442324, 2.06569689941987, 2.0812457068629, 2.20614539197617, 2.19273677713773, 2.03884311431816, 1.68129344144671, 1.91662663989336, 2.05211443378197, 2.19739546848752, 2.56737887402491, 3.08110373579439, 3.24147791032189, 3.18924190849922, 3.14504384950727, 2.82216380910927, 2.28820169413141, 1.59579370328557, 1.51381625033155, 2.05341087617402, 2.20034965688908, 2.29795051585655, 1.82035304039119, 1.33558496330855, 0.985245847983841, 0.815269498493576, 0.685954683174983, 0.595079597312241, 0.473158541727592, 0.4759469555282, 0.444626182525487, 0.37478066745105, 0.436985461142434, 0.51652283948938, 0.546813684650802, 0.445980646027871, 0.420747838979305, 0.425845195427001, 0.367006688792617, 0.294675404830077, 0.285072804804233, 0.248678478886267, 0.192034041601774, 0.163142589110224, 0.134718961043819, 0.109888561212484, 0.101925195699042, 0.0950471649992859, 0.0823612424083734, 0.0881156188578385, 0.0944222797663173, 0.0971635328182702, 0.0997591592592341, 0.101748475723797, 0.0987050028224189, 0.0861041566068405, 0.0720689350299584, 0.0646056349762305, 0.0583900650856587, 0.048557888490652, 0.0415093012303026, 0.0363656129069554, 0.0314213216741364, 0.0269277673306719, 0.0229889628120813, 0.0167537550072431, 0.0123571788053347, 0.00930106027734516, 0.00755932180335562, 0.00651030862980066, 0.00338692386950223 };
            PGAonSa_FAR[7].Horziantal2 = new List<double>() { 1, 0.999482681570446, 1.00045286704105, 1.00172866306906, 1.0047911710988, 1.0057447101843, 1.00759331259222, 1.00936721968234, 1.01049362507475, 1.01444479397111, 1.01642272598642, 1.01722089881089, 1.01822693803404, 1.02051944404488, 1.02539726171233, 1.02681391176818, 1.02535543233437, 1.01959791723844, 1.02571994548522, 1.02567384780338, 1.00848154662845, 1.03003562753244, 1.03155855835476, 1.07862855981879, 1.05686319787302, 1.15667534981951, 1.35786313342163, 1.47324050910621, 1.71960274042182, 1.80459662180822, 1.79883953354268, 1.873208326095, 1.68431667229371, 1.59225149187891, 1.39790665304793, 1.3840666777358, 1.26502667049676, 1.58111676756226, 1.93822739901086, 1.86495129225034, 1.74965928264324, 1.68599923768093, 1.66617595399793, 1.83181474195329, 2.08767565671056, 1.89581667805592, 2.02156347117252, 2.15766858413104, 2.20363437538281, 2.33000946282969, 2.34922451321061, 2.41339077901241, 2.3215667577665, 2.4734240461728, 2.52081374359701, 2.52198240519777, 2.50655974280908, 2.91984978985006, 3.16514323787556, 3.00267622652913, 2.97160468164642, 2.93085219674661, 2.68088111450536, 2.30718726884467, 1.76206681517519, 1.42173872772959, 1.17069416706397, 0.989855522182162, 1.1932107504916, 1.58526299794567, 1.32970257178113, 0.940819539953672, 1.01515375924461, 0.981102084596929, 0.899824188563421, 0.748359584113544, 0.629618784976083, 0.510080666674919, 0.427319535045122, 0.344438890906848, 0.289624350844335, 0.238607960984288, 0.197557463107983, 0.195151334848012, 0.201799218132096, 0.173521704965446, 0.16621287482644, 0.1586588733129, 0.151560129090582, 0.154919284239587, 0.140596521076244, 0.134660718927495, 0.121241171546974, 0.120017448826238, 0.115211680128186, 0.0932905250910109, 0.0881695421518483, 0.0715800535330672, 0.0544704720872134, 0.0481491140495064, 0.0446763366513705, 0.0400054890387822, 0.0348645731205271, 0.03016009127341, 0.0275814808538827, 0.0228624867735934, 0.0188321408403693, 0.0155105894484967, 0.0128321860843903, 0.0106975646338585, 0.00498708624662857 };
            PGAonSa_FAR[8].Horziantal2 = new List<double>() { 1, 1.00287939919263, 1.0037868778098, 1.00540590527921, 1.00800238628184, 1.00931709146929, 1.0115384520396, 1.0094710362846, 1.01007199732833, 1.01796269815593, 1.02353626882222, 1.02797350173414, 1.02864443769392, 1.02848939523287, 1.02876572754841, 1.02732204898628, 1.02659897485376, 1.01142374805957, 1.02218122515376, 1.04599794246306, 1.08416171285423, 1.17096957518091, 1.27363320466181, 1.28729587562357, 1.27247820692982, 1.2699088926593, 1.24255226783215, 1.28976996912597, 1.57525472927528, 1.77880407654652, 1.78801744049319, 1.75919161684041, 1.7048340044065, 1.61452931715733, 1.74545759890543, 1.68782159305168, 1.67869851046729, 1.74977299313999, 1.94455791357302, 2.08538037403925, 2.69243390045945, 3.14228534782884, 3.64599497881955, 3.66421864225063, 3.47105220046414, 2.84864590305099, 3.17605716319495, 3.45722735234401, 3.61819161217542, 3.62333682659091, 3.3231005309038, 2.66238036004427, 2.18377388717245, 2.18901102941883, 2.17497570772767, 2.01023170478379, 1.91114941894751, 2.0507894405382, 1.81092228860235, 1.89066350764222, 1.91416986561798, 1.85921074331746, 1.64710497307612, 1.5879893407622, 1.57608866562774, 1.60148763927409, 1.62894277780659, 1.62954483649606, 1.67837223527049, 1.77200635646649, 1.81468392056008, 1.7131700749939, 1.4881677905187, 1.37977829202481, 1.24771394693377, 1.12615928541067, 1.06979654861761, 1.00797796366408, 0.863241298481983, 0.680504960947137, 0.60266047374939, 0.534498868464446, 0.419347323377138, 0.328051187611531, 0.26095446334316, 0.229306674811198, 0.224381318837824, 0.219106280372201, 0.210100481235334, 0.200974215478287, 0.203381434913861, 0.212852279110457, 0.214554041627666, 0.207702399700562, 0.206625032963674, 0.195878010945174, 0.1797247269126, 0.137373410574664, 0.11606324964059, 0.0973026179125357, 0.0782019904159062, 0.0654546462383818, 0.0568982781505657, 0.0492404703082711, 0.042526445716067, 0.0318570821338123, 0.0241241678816233, 0.0202882253071556, 0.0173351740852426, 0.0149288876485492, 0.0079235204352824 };
            PGAonSa_FAR[9].Horziantal2 = new List<double>() { 1, 1.0306707294819, 1.03558737150701, 1.03465484070631, 1.02960040459324, 1.09644543391358, 1.19461962500642, 1.27321588311486, 1.2430009913726, 1.04419466059082, 1.1342650696456, 1.20529680474131, 1.18565034712938, 1.14949764744526, 1.17309469880074, 1.17192531113533, 1.27441878826114, 1.42811952780573, 1.40946891179167, 1.29128255012912, 1.32443133869563, 1.40735507599903, 1.51069468330822, 1.39707340253824, 1.30450035491288, 1.63155052611272, 1.82760469929978, 2.31737777105773, 2.42379353827659, 2.43163513913106, 2.37763996713797, 2.66081650073031, 3.13454289232025, 2.66903200770455, 2.52070747208925, 2.3841781104036, 2.59129975576929, 2.64977062870601, 2.55512247659921, 2.43341231044934, 2.54810242644216, 2.86902858147318, 2.53707517524056, 2.3364157001839, 2.04873590683034, 1.60935971928737, 1.7895623585283, 1.88609121372757, 1.96152938030647, 1.96490570787802, 1.77761672835125, 1.49795506125133, 1.2985506296445, 1.26195028538273, 1.23798677623655, 1.20192569100011, 1.17297552553548, 1.16373587331286, 1.1326919825441, 1.19172892849083, 1.21540791146618, 1.25460995707528, 1.28428112079477, 1.22990310468701, 1.28544008079947, 1.31624115604026, 1.12486229901615, 0.915659590505764, 0.79320012245053, 0.881129136895075, 0.896816807601467, 0.87999401154342, 0.839066188086696, 0.735724048345614, 0.741015043390241, 0.768020301165738, 0.686402702849656, 0.554030402589635, 0.480525896722959, 0.538860241787659, 0.561637157628244, 0.561306600783713, 0.514625687946295, 0.471506715041081, 0.453462393014063, 0.482237895161789, 0.503681560097216, 0.524965756307059, 0.612572258102479, 0.691298191620183, 0.740805670859828, 0.762307432762071, 0.76305598983452, 0.756570729705352, 0.741873314350025, 0.685365076125647, 0.605535523688293, 0.559292349150853, 0.503766024148973, 0.450039364419183, 0.404287705117672, 0.362566187714279, 0.322611041551993, 0.285423396542337, 0.249978362604025, 0.193255016635843, 0.155463684554326, 0.135704980623172, 0.116346251963566, 0.0988484883243717, 0.0439486422813338 };
            PGAonSa_FAR[10].Horziantal2 = new List<double>() { 1, 1.00568089532574, 1.04297508955986, 1.03231821329865, 0.990335201410608, 0.985057114307878, 0.984125457869508, 0.982706533419439, 0.98415469395021, 0.986132352387028, 1.00200104730138, 1.01145404672835, 1.01079266161381, 1.00454003848768, 0.997445416237329, 1.02213756030754, 1.05736508848137, 1.07012111533699, 1.20443102039119, 1.22632299762083, 1.20779446905328, 1.17861036360589, 1.25504777175587, 1.2789511913378, 1.47126937864883, 1.52085117275665, 1.99488433556784, 2.62296435666979, 2.00841739247944, 2.16378052409248, 2.12586457587543, 2.08450071920759, 2.49487913804238, 2.26546816060873, 2.68388195380179, 2.93049414173912, 2.8663859136665, 2.83423207211047, 3.59848985897814, 3.56405235467394, 3.25796163446583, 3.1548186908213, 3.35289118850515, 3.44365232712705, 2.9143493282848, 2.7702102528986, 2.70187643662852, 2.66128766094462, 2.68194392649659, 3.09335470382551, 3.07848783194321, 2.70963049492137, 2.44541948578282, 2.51342390887698, 2.66169956483718, 2.84939390356251, 2.85037363711137, 2.11845160519077, 1.47272858392119, 1.63426312732508, 1.72352607923368, 1.6866990126001, 1.67098754283086, 1.66694321833375, 1.86637032109013, 2.03030612125567, 2.03602469864098, 2.11246730431641, 1.97450808669992, 1.87755084804125, 2.17232980378042, 2.0156653417308, 1.69692254517624, 1.25920904057578, 0.95466263511942, 0.793606913748364, 0.756449154557515, 0.722578830218933, 0.565356348842316, 0.517601549902092, 0.578588988782441, 0.611577293050779, 0.515747267725836, 0.446694958530244, 0.495089118070886, 0.51289869892944, 0.468326864579774, 0.454674264582632, 0.443316437044323, 0.448307880618038, 0.475181361153955, 0.497827629265707, 0.508261531684765, 0.500956994374978, 0.487658150954331, 0.431777085929389, 0.351126303766777, 0.320544973538099, 0.296155325449553, 0.272821879503169, 0.247245116599987, 0.218952711614001, 0.190234824200198, 0.163202494292467, 0.138249044629852, 0.120133589398088, 0.0996453988256191, 0.0811098535987017, 0.0649356091564806, 0.0517768390469297, 0.0196728287662244 };
            PGAonSa_FAR[11].Horziantal2 = new List<double>() { 1, 1.00233010145256, 1.01456749868404, 1.03386383817908, 1.02808103482046, 1.01079528373882, 1.0056938371531, 1.03369379793144, 1.03622120346882, 1.05136698248872, 1.06225386315419, 1.02403211584357, 1.01735175826638, 1.0257466285515, 1.0427946581055, 1.04641548700747, 1.10299823287287, 1.12792694630913, 1.08542453740563, 1.06776618054926, 1.06817561641981, 1.12932888151543, 1.13397019105971, 1.17794221644952, 1.20817015886925, 1.18879394111442, 1.15682422214957, 1.22926806402601, 1.08439783869518, 1.33561209586443, 1.32978002627373, 1.15456443269814, 1.17512351833601, 1.24392189819444, 1.33202092236431, 1.41358762680973, 1.36621288321535, 1.42980530511223, 2.21994000520883, 2.06294909100214, 1.94006188891039, 2.00430720796066, 2.09866591348323, 2.29020919733589, 2.68751840010064, 3.12681773861777, 3.25795918699238, 3.3682772818337, 3.17916191442838, 2.74666657738159, 2.31257200104368, 2.59044957350032, 3.20409397605518, 3.31186505452887, 3.2547090506134, 2.75388671110353, 2.66215824839891, 3.17588068770877, 2.0408304660466, 2.22270250155272, 2.54270437653942, 2.88735515189664, 2.38699845002694, 1.59876193480451, 1.3218271171386, 1.25158327559698, 1.12578601762153, 0.875452095405254, 0.799810731572456, 1.07425497379682, 1.04622583592958, 0.90293308665141, 0.704635067560506, 0.50212358984379, 0.469862578302817, 0.374838061177659, 0.316508516481348, 0.281041373351225, 0.238111089613602, 0.21009225939006, 0.194123973450762, 0.172620004529623, 0.129991751493472, 0.112221230254345, 0.097062201966201, 0.0914031381633214, 0.0907286690966558, 0.0902518628495062, 0.0900496799727744, 0.0909478081668585, 0.0960413625891844, 0.1011456790525, 0.10337767852253, 0.1017546909943, 0.102044668209864, 0.103950577837896, 0.103544059676235, 0.10096301134343, 0.0894177568414892, 0.0722295337668602, 0.061388523311657, 0.0538213974725466, 0.0460184633575224, 0.0391426910316086, 0.0339764330434837, 0.0244926355353506, 0.0193838468461121, 0.0153810372359444, 0.0123510204686845, 0.0100755423530557, 0.00456222050082712 };
            PGAonSa_FAR[12].Horziantal2 = new List<double>() { 1, 1.11011147186935, 1.1604810266678, 1.22873160359058, 1.3165934747238, 1.31477497971424, 1.32402096264884, 1.32689835329708, 1.3351467555248, 1.44058461802452, 1.48338221986079, 1.49586686631514, 1.50067258951263, 1.46192022927373, 1.45623007126868, 1.5030797519789, 1.51139410084189, 1.64162194315841, 1.64644464926867, 1.60307029007036, 1.68694382339182, 1.44617111409452, 1.32983044215785, 1.53459364190624, 1.65620916243583, 1.56316110674775, 1.72046610817145, 1.93445323512358, 2.40442535006305, 2.65258540585522, 2.88048286170461, 2.86601209668615, 2.15107778637216, 1.75350956303407, 1.73054072491453, 2.12277807810331, 1.92429701217631, 1.87917208961949, 1.854254407121, 1.88981618533342, 1.69074799585088, 1.5040982856301, 1.7066329743322, 1.58369168382051, 1.73916231010843, 2.00102934095932, 2.31869913534918, 2.49749612315391, 2.54249863640444, 2.51401586556944, 2.48421636760198, 2.25810101480623, 2.18267725253525, 2.05316423645596, 1.87061667161818, 1.76642341401099, 1.86069468053266, 1.75776984800734, 2.40174778433642, 2.96566429986619, 2.95238013316809, 2.65721269819004, 1.9407492640554, 1.42310015794109, 1.15738197592441, 0.872002433188229, 0.692561638599646, 0.644139163721675, 0.659350780739789, 0.717906320047623, 0.542675082251334, 0.683802646202477, 0.629953138188638, 0.373450943312581, 0.310828988905747, 0.217474138001385, 0.209009369053913, 0.240506717183113, 0.156754181601153, 0.117212049751553, 0.118152395836848, 0.111804999107846, 0.0985157375359205, 0.0827932215681228, 0.0728530786161088, 0.0734567880812595, 0.0702864752714454, 0.0685970503988889, 0.0659579498668826, 0.0589747084728634, 0.0538283345122121, 0.0503570271433263, 0.0445647290486547, 0.0400545747004446, 0.0358166542382623, 0.0249884813945574, 0.0181467716254787, 0.0132440473236584, 0.0102152881945157, 0.00801439092327274, 0.00662410792839563, 0.00559271578610264, 0.00482702903350243, 0.00427695910580774, 0.00388917524579458, 0.00329918444523992, 0.00284825502776927, 0.00248029926980092, 0.00220828594108164, 0.00197469369552372, 0.00117876853591191 };
            PGAonSa_FAR[13].Horziantal2 = new List<double>() { 1, 1.01797104787674, 1.02241311672908, 1.02327557562372, 1.03718982233617, 1.0212746169155, 1.09200624971781, 1.08761284625764, 1.08663142751547, 1.03631060091756, 1.15120202166854, 1.34332055326062, 1.34127849933234, 1.28262886122712, 1.1651506045188, 1.18109609062794, 1.42189866946114, 1.31055874088572, 1.38465423374042, 1.49320860934046, 1.78062181934487, 1.88620706529571, 1.79449443011068, 1.49989604531505, 1.73890043790742, 2.11229512207849, 2.25701978004865, 2.75376095613437, 2.6257025728041, 2.73480037861675, 2.81745313995869, 3.117718609673, 3.10642823868861, 2.85236785521073, 2.89025927028407, 2.58411123610907, 2.57786476266023, 3.5725696976284, 3.73656936562228, 2.36490122142023, 1.99176500455427, 2.13925629006953, 2.62841972386716, 3.0551078790081, 3.33180578074565, 2.97705129359371, 1.92098443599649, 1.5792117125703, 1.47252392512343, 1.47513914922621, 1.30523934315779, 1.11440747046213, 1.28586673198644, 1.37138128875151, 1.47569744941976, 1.7126530290016, 1.89360501599604, 1.83496619242242, 1.34046849091593, 1.04000295236713, 1.06984457084829, 1.11823229992373, 1.3089652196553, 1.1591828756218, 1.11536185287533, 1.06273671995797, 1.03291537872354, 1.02706579858422, 1.03883687549798, 1.04745930153807, 1.04549538260055, 1.01569134461667, 0.958532760055014, 0.939892563035877, 0.902679219093488, 0.853572594030325, 0.847738154235227, 0.811974768616338, 0.689519664468343, 0.619559918858569, 0.571225992077815, 0.519994852282961, 0.427849365470877, 0.344344148676017, 0.274944325439536, 0.224116216200871, 0.211319380965397, 0.199768731241857, 0.179740110583993, 0.162930137855538, 0.148499199859844, 0.135837654414613, 0.124533981556357, 0.114324468932149, 0.105027243156902, 0.0851394006640663, 0.0726840883363384, 0.061615631540257, 0.0520042436221976, 0.0438431114272559, 0.0370067323162807, 0.0327459690861207, 0.0308041658657154, 0.0301020594382878, 0.0270742339188591, 0.0208697208526069, 0.0169724881019875, 0.0147108451096823, 0.0120805076990002, 0.0104929074246356, 0.00614335689008678 };
            PGAonSa_FAR[14].Horziantal2 = new List<double>() { 1, 1.00166624890799, 1.05448809407726, 1.19728239509123, 1.27701667265886, 1.26331638170341, 1.25266642697887, 1.08359241350252, 1.13901911859102, 1.10279276158822, 1.15972279967305, 1.21269140874805, 1.17480657972899, 1.20851501847411, 1.39068312416486, 1.4652068842641, 1.75591028816973, 1.99175968527119, 2.64259379679221, 2.84450782943561, 2.71323987902347, 2.79719242243597, 3.32963831271759, 4.15554421591682, 3.89588377096296, 2.77411100655512, 2.47793905190118, 2.94101706190226, 3.66304562622623, 3.75008898558822, 3.67997731540501, 3.23759979596627, 3.07865408724516, 2.74845324602476, 2.90267499153017, 3.01325840397842, 2.80558947144455, 2.78323788694274, 2.61156798688377, 2.05752028422745, 2.22728783692137, 2.42052166193373, 2.62669902651262, 2.75447535193925, 2.76103186990177, 2.35707020160296, 3.02650304884068, 2.96299974256494, 2.66273594640884, 1.99570197116289, 2.00840223360307, 1.75309266046868, 1.73330944431716, 1.8221161640302, 1.87407138428872, 1.82973033926989, 1.88967880838875, 1.56237057208212, 1.26006484332455, 1.06140414372733, 0.959775523010925, 0.879550104818542, 1.17203661041581, 0.996641778619011, 0.803897897786517, 0.882556970218692, 1.03107845348332, 1.07931512304339, 0.951464618033974, 0.697532751183134, 0.628132566890741, 0.82480018871924, 0.906658155955394, 0.949110014502906, 0.928257176625375, 0.852562894614941, 0.820909150550056, 0.883167356516846, 0.760729767568646, 0.681199882668638, 0.651604422618631, 0.635874163510545, 0.586291094641383, 0.475626323941042, 0.361909821157413, 0.278422295989696, 0.249695654332716, 0.227978783841693, 0.198371778098558, 0.179234024021024, 0.16714067818883, 0.170740601377068, 0.167924628758108, 0.155829149265871, 0.162179479893445, 0.145940013842867, 0.123048772876275, 0.116946903969545, 0.101095943513444, 0.0964278941553069, 0.079571541122708, 0.0584023432771862, 0.0422756620976431, 0.0384990439408342, 0.0344349400192269, 0.0257923007575291, 0.020708626387552, 0.0171496614958313, 0.014300048834892, 0.0119719465579976, 0.00653131285697678 };
            PGAonSa_FAR[15].Horziantal2 = new List<double>() { 1, 1.01876556662815, 1.02925304425819, 1.0392730180241, 1.03959199802686, 1.0481071095602, 1.05901360917216, 1.0484353242072, 1.04794896627777, 1.06364055070801, 1.06237501967172, 1.08970648837647, 1.09185123449878, 1.09451658368954, 1.12252872262938, 1.14990174723317, 1.1081938613472, 1.18772030879111, 1.23589975639778, 1.22024395621393, 1.28606542206749, 1.45498745819881, 1.59043044600638, 1.68089109699493, 1.63992852385366, 1.53074155347494, 1.51804391765929, 1.41103439943453, 1.37587195242311, 1.30848713825686, 1.38035037009761, 1.32192700860246, 1.6283482799898, 1.71312000535609, 1.88158838958963, 2.10769711444302, 1.8932663667716, 1.94315422356073, 1.91644301512673, 2.01747925764234, 1.75651475292132, 2.02668004150973, 1.81366180962858, 1.5726145086265, 1.37375491023349, 1.45260992208654, 1.44017816706934, 1.39925022384393, 1.65361465137871, 2.09966528262436, 2.13044204318043, 2.0186001125857, 2.34566466159454, 2.45214780509822, 2.48761961269133, 2.43660205109144, 2.20796957492548, 1.69273183478144, 1.2571621399595, 1.19051340389371, 1.18694036613056, 1.04267829308375, 0.825290920151494, 0.695145539916942, 0.65541309834242, 0.651255199778061, 0.834485932366235, 0.954282354634195, 1.11866941089511, 1.24109270466954, 1.19609536155364, 1.19401872093251, 1.2026938996325, 1.16329313569656, 1.14117000633727, 1.22562852335345, 1.31888842587409, 1.29432234833925, 1.10086116905209, 1.00123590321939, 0.935342099319368, 0.8465756207701, 0.6769890750311, 0.540425232280161, 0.44205203029425, 0.36806163663291, 0.337040388870869, 0.309524073370788, 0.307322072454249, 0.30258116001753, 0.287605953113403, 0.304055855745623, 0.349355441071619, 0.372956459806788, 0.333508252886115, 0.354984456939431, 0.404249244586863, 0.372320346730109, 0.285973383446669, 0.228416616357094, 0.186682296302025, 0.149909096470865, 0.127021800301588, 0.109789069182492, 0.0978932698297632, 0.0654902884248737, 0.0448781777276542, 0.0330994659682197, 0.0238009487827392, 0.0185292751689267, 0.009284241964609 };
            PGAonSa_FAR[16].Horziantal2 = new List<double>() { 1, 0.995260213651493, 1.00434463219712, 0.998222666097149, 1.02706376047812, 1.0439910775637, 1.03237856661873, 1.05596056849923, 1.04530894589105, 1.12068434233487, 1.11064247456604, 1.11550297380152, 1.16384246658729, 1.23528901966692, 1.33129703417722, 1.37820379224177, 1.37011774837106, 1.50537086369211, 2.00943417639764, 2.12244035373347, 2.07048188171788, 1.56780384396604, 1.42504830235036, 1.43416848767731, 1.5033094590068, 1.61696528489961, 1.59218715931281, 1.978226627956, 2.74153032300843, 3.67888858853964, 3.68213855088134, 2.87646910334743, 2.46881033494903, 2.38131619003991, 2.41772918081002, 2.67884147268346, 2.58646447430054, 3.00830580322905, 2.77994247050788, 2.53921518052251, 2.47763441259596, 2.28442054031226, 1.85349100981317, 2.01171705999809, 2.38328680212647, 2.71531499185274, 3.00012587155736, 3.07453075014633, 2.94767732585532, 2.60389011894518, 2.34913777983207, 2.39553176606049, 2.75097619239227, 2.92951433525717, 2.89183162374997, 2.51624740432902, 2.1015556486409, 1.92127353127496, 1.77829272771919, 1.71639796872195, 1.64581944791222, 1.50701441607634, 1.17246054133024, 1.15855826855763, 1.23285928591621, 1.02852400810805, 1.20613496594934, 1.1981018844279, 0.952058756567847, 0.920328462860668, 0.841845483377732, 0.803433679789636, 0.589241214612381, 0.506208287851056, 0.49079039771973, 0.512790407349248, 0.536322198171355, 0.548451263977417, 0.604675956400294, 0.583302209355352, 0.551486281719804, 0.53110781414755, 0.473423561917457, 0.399011805101306, 0.376554049453078, 0.333625004556826, 0.278495016380498, 0.259981339369665, 0.228902001082633, 0.207185064892634, 0.190183359780117, 0.172989167480017, 0.156731411419095, 0.143147875693927, 0.129692034256323, 0.126437566675815, 0.112987709295855, 0.104682387542705, 0.0929520525661634, 0.0775867464816148, 0.0664100056195116, 0.0573212193996271, 0.0493363886418459, 0.0421948629272497, 0.0374021486206059, 0.0326235002885416, 0.0269066961605048, 0.0211718710772611, 0.0162742638061496, 0.0124073932688293, 0.0050055266555377 };
            PGAonSa_FAR[17].Horziantal2 = new List<double>() { 1.009375342, 1.02236729, 1.023551134, 1.02533205, 1.027716267, 1.027584704, 1.033036097, 1.041322506, 1.044114263, 1.034330406, 1.039620257, 1.044964493, 1.047657269, 1.050363959, 1.055819513, 1.084831931, 1.087263777, 1.089781231, 1.108593549, 1.116301598, 1.094625175, 1.135279729, 1.169140302, 1.211867419, 1.277634359, 1.267146657, 1.361094058, 1.236691806, 1.479650557, 1.57540442, 1.551550799, 1.392701423, 1.428946448, 1.554252182, 1.740586178, 1.988295924, 2.095220065, 2.066712118, 1.936640284, 2.307842164, 2.634530349, 2.857548632, 2.950058413, 2.814555306, 2.710888389, 2.411797545, 2.370655729, 2.326199335, 2.433710443, 3.211298477, 3.787354088, 4.036015758, 3.992183078, 3.867462734, 3.738109235, 3.457640771, 3.204738534, 2.483109761, 1.845033079, 1.358767888, 1.238595909, 1.048059181, 0.832779407, 0.729690053, 0.653417672, 0.577067539, 0.647531181, 0.710107226, 0.716690345, 0.63302469, 0.575805209, 0.512655562, 0.418844886, 0.317034821, 0.223495767, 0.181314222, 0.142640128, 0.127610012, 0.122047152, 0.105687869, 0.097173658, 0.089590442, 0.078254235, 0.071568337, 0.067889033, 0.065630581, 0.064682418, 0.06373598, 0.06165347, 0.059178482, 0.05630395, 0.053115517, 0.04972885, 0.048965638, 0.049655235, 0.048967908, 0.045913919, 0.041654158, 0.03700402, 0.032460818, 0.029401766, 0.025960174, 0.02366876, 0.02229573, 0.020224634, 0.017271672, 0.014953971, 0.013097563, 0.01158491, 0.010334121, 0.006417635 };
            PGAonSa_FAR[18].Horziantal2 = new List<double>() { 1, 1.00148474407879, 1.00219396553997, 1.00407651655733, 1.01444837814563, 1.01453803539126, 1.00945620243551, 1.03238359438158, 1.02530293224399, 1.05470498371227, 1.07203369505135, 1.06665777628433, 1.05690598119307, 1.04272531908059, 1.06648072205978, 1.10757011033366, 1.19383143081663, 1.14401013001305, 1.19196922219954, 1.21043183399798, 1.21621736331853, 1.16815053175285, 1.22268473975917, 1.34084972466185, 1.47015757323704, 1.59019657037177, 1.71505721865142, 1.88348375408198, 1.6308180834395, 1.54267170053174, 1.55285696454721, 1.67274803978371, 1.64344694689453, 1.55426963123247, 1.8214899125553, 1.82109084991302, 1.65937479516333, 1.75333056576233, 1.37935211213133, 1.47398998099116, 1.62756380167817, 1.77673537626283, 1.94182098637536, 2.14485973915015, 2.21207856385668, 1.92645971162513, 1.91138122135269, 2.1909124219486, 2.29280624918536, 2.26062281397679, 2.10365809096368, 1.79027487605576, 1.98252738501458, 2.18367755939416, 2.35362776571884, 2.55710249882529, 2.5717013102766, 2.00733481657057, 1.81555796818097, 2.35096391584675, 2.45976813179665, 2.1028137557822, 1.90554546388332, 2.29762312865614, 2.74169345710554, 2.96216489348744, 2.81029506274877, 2.43793948060578, 1.61398035225503, 1.24783045789738, 0.923293831405703, 1.07226424225438, 1.0879424566236, 1.28428755514737, 1.20593817266479, 0.982889278826751, 0.991003887407577, 1.113364680721, 1.24260020076191, 1.09610854905695, 1.02055838130749, 0.943857737809566, 0.806541262047535, 0.742164597141365, 0.740863185805726, 0.740542479075581, 0.761048623108314, 0.789413463303691, 0.841178593466172, 0.890385604009813, 0.929906869477886, 0.946166976951056, 0.931788164791524, 0.895960928527604, 0.856545895594263, 0.735526444994777, 0.64385479946286, 0.533652231850121, 0.414921929132603, 0.348094381705301, 0.289972628170307, 0.235616704978187, 0.187304483791502, 0.151252200306844, 0.133853948095738, 0.102464946402798, 0.0779880411800501, 0.0602965821502721, 0.0478139077223519, 0.0389780982668526, 0.0196866466708406 };
            PGAonSa_FAR[19].Horziantal2 = new List<double>() { 1, 1.29050582777404, 1.34640408082377, 1.23825727200075, 1.40890977765642, 1.46190889419406, 1.53413502919425, 1.57329395421246, 1.55500018719915, 1.48720390926702, 1.39750768349584, 1.29725930649283, 1.25128005991941, 1.19961231154878, 1.11888596318077, 1.06722860387269, 0.985312413812435, 1.05808368056651, 1.18751356213708, 1.21695694948897, 1.24514326027209, 1.30017647684935, 1.32539347594315, 1.28936616721412, 1.24905209605218, 1.22912959845881, 1.21824519324538, 1.21645611826595, 1.24053306475973, 1.34662519143808, 1.34931145017788, 1.3533653407936, 1.39341635305092, 1.43987271242154, 1.4796396916291, 1.53973159758888, 1.50625548978647, 1.42620717476501, 1.46461926339978, 1.62979555697038, 1.91839195345543, 1.87859733542108, 1.69843393702934, 1.64524232880442, 1.52799666138654, 1.5232949245117, 1.55731341978732, 1.6239825824426, 1.74638886966803, 1.91615203236526, 2.00886637881776, 1.93606806129704, 1.73703714521106, 1.64877010161091, 1.65219300369165, 1.77979872269416, 1.77527085560203, 1.73577320794062, 1.82945197302999, 1.61938218793265, 1.47951345471809, 1.29288766737907, 1.26248887831252, 1.28452192376427, 1.22347147976906, 1.09985672894681, 0.967304836069414, 0.85064644471578, 0.781398442307085, 0.586001345873651, 0.498173779221444, 0.374045259852997, 0.340686176019339, 0.334597401283814, 0.333109609118382, 0.316824067498327, 0.305822638316156, 0.292110643908216, 0.251206552401353, 0.156266339496138, 0.144598951802395, 0.121668957814329, 0.101559829533125, 0.114390125764503, 0.103152668842359, 0.0833938283871921, 0.0728134894724493, 0.0621711690184825, 0.0592995537211564, 0.0593706109886095, 0.0556412511646041, 0.0529664791996266, 0.0542864389998351, 0.0574521627774002, 0.0608038115706322, 0.0663214426918727, 0.0616753167046913, 0.0586422984997214, 0.057465511742679, 0.0576390286892982, 0.0531155916502516, 0.0488591731207901, 0.0417277285451647, 0.0338383920553859, 0.029929517071288, 0.023842134078105, 0.0191262249537834, 0.0156319127695104, 0.0121581238842784, 0.0103500349601756, 0.00469417050098216 };
            PGAonSa_FAR[20].Horziantal2 = new List<double>() { 1, 1.24721773161332, 1.29828168220036, 1.40890305962367, 1.50857365976491, 1.52830776923483, 1.59566690273491, 1.46271914752472, 1.42402188561747, 1.42662959299644, 1.40556473598706, 1.43338393361403, 1.41559813416445, 1.4405889952358, 1.47313951832119, 1.57964265045864, 1.6333825391181, 1.71862807498802, 1.72224330567251, 1.75679592647819, 2.00609643736173, 2.38514732351409, 2.95664761187593, 2.96642651454708, 3.09697822693827, 2.95029817311073, 2.95182066383982, 3.09876666796156, 3.17796507186136, 2.51238312381032, 2.48177543236844, 2.30989683718364, 2.42688657867397, 2.75367723594971, 2.26679745046302, 2.02227607632674, 2.08512451354504, 2.08435355651245, 2.42347105972726, 2.32814979276794, 2.48324712360314, 2.11385411779706, 1.90841598211858, 1.92607030052383, 1.86667075054759, 1.63982809849524, 1.46621385391858, 1.38313028476603, 1.39049571341913, 1.27623270949562, 1.50369690830293, 1.77476450450074, 1.76653199820309, 1.54834518156835, 1.32591710518583, 1.4516518302261, 1.49141040313881, 1.57380768108277, 1.03327615900043, 0.922855489383404, 0.982564816668609, 0.944907450293691, 0.781725031301453, 0.697312706746472, 0.724141314232723, 0.819180693801565, 0.921039158441631, 0.784149462073197, 0.619494853812004, 0.463410817503314, 0.423416574779346, 0.358144553447543, 0.319639781781309, 0.279429691009585, 0.290353624245105, 0.361755401430554, 0.462792956201871, 0.546124446808447, 0.55530471230055, 0.43916053337477, 0.361326793147447, 0.287057135486236, 0.214948747294429, 0.217921812605645, 0.223774761018261, 0.205108187982035, 0.21431838533309, 0.216974551445445, 0.217950648789229, 0.22524147191037, 0.220900505703986, 0.199509237041398, 0.19433535834063, 0.196298061551058, 0.190876161789417, 0.153590627792105, 0.112910940517776, 0.0974540488691136, 0.0822385544256818, 0.0670862107262634, 0.0593805748709842, 0.0522448396180276, 0.046021154503176, 0.0405797816020168, 0.0357826658180163, 0.027907548904474, 0.021938458902711, 0.0174237783468649, 0.0139961571676592, 0.0113709687862009, 0.00547090633270481 };
            PGAonSa_FAR[21].Horziantal2 = new List<double>() { 1, 1.0070954191073, 1.01340672459143, 1.0133286622882, 1.02598110194143, 1.02647359256999, 1.04063809269042, 1.08595452902569, 1.08858611715882, 1.06481106859995, 1.07986598669958, 1.12778291317727, 1.14935762022943, 1.15410069846722, 1.14235390846211, 1.1327649382213, 1.12184351427604, 1.13189863705122, 1.1927961187169, 1.16074043681253, 1.12891227796273, 1.20445151870846, 1.25637500876614, 1.38938397101667, 1.4212511610181, 1.50515798255276, 1.36574664213099, 1.62202645296635, 1.71921560712956, 2.25665869859986, 2.42670917571602, 2.63828435558458, 2.40451060489083, 2.96424809976997, 2.78741826067669, 2.3452061019335, 2.09114408555882, 1.95002743287039, 2.21072791828463, 2.32526054880338, 2.25049558456131, 2.28204544812681, 2.24119569870363, 2.15946034197001, 2.0755398753986, 2.53866035567851, 2.88851179930753, 3.08089063376118, 3.08937879859577, 2.65555135626905, 2.69692596361725, 2.78017750606173, 2.85916798912459, 2.89296960107942, 2.91415716987976, 2.97031093865477, 3.26509228328746, 2.88786953060122, 3.06767081444051, 3.28486489351001, 3.20364201897041, 2.83437305340064, 2.10574268824359, 1.71990166688404, 1.38338523207193, 1.18617605461061, 1.0124639477503, 0.93865604003898, 0.807314310882805, 0.668794023093114, 0.497287017636051, 0.357947075662363, 0.313578334727983, 0.271111870579048, 0.23600769707003, 0.208865561164829, 0.188572218260931, 0.173482267322771, 0.152482492307214, 0.135337630567929, 0.126488760773629, 0.117182242793437, 0.097468211030965, 0.093368670805238, 0.0905435770114768, 0.0898384142055622, 0.0907085867581582, 0.0903688888084995, 0.086870618713565, 0.0814613136235537, 0.0797832914303775, 0.0736838330748709, 0.0649755071590431, 0.056814601077831, 0.0512791587295392, 0.0377827576873122, 0.0316149472175073, 0.0259543830555299, 0.0218730890998687, 0.0181720156797339, 0.0149936423648562, 0.0123895981663609, 0.0109010833207196, 0.00975826389437599, 0.00875979626373508, 0.00712737387940136, 0.00588043964943045, 0.0049176712428312, 0.00416506813474569, 0.0035683040393434, 0.00188463343560764 };


            //Vertical
            PGAonSa_FAR[0].Vertical = new List<double>() { 1, 1.02416918429003, 1.0392749244713, 1.06042296072508, 1.07250755287009, 1.04833836858006, 1.06344410876133, 1.06042296072508, 1.09365558912387, 1.24773413897281, 1.30513595166163, 1.23564954682779, 1.22960725075529, 1.22960725075529, 1.27794561933535, 1.41087613293051, 1.61631419939577, 1.6404833836858, 1.84894259818731, 2.07552870090634, 2.28700906344411, 1.9214501510574, 1.89425981873112, 2.00604229607251, 2.06042296072508, 2.12990936555891, 2.04833836858006, 2.34441087613293, 2.40785498489426, 2.39577039274924, 2.4380664652568, 2.44410876132931, 2.37764350453172, 2.06646525679758, 2.19033232628399, 2.46525679758308, 2.7583081570997, 3.26283987915408, 3.68580060422961, 3.59516616314199, 3.38368580060423, 3.202416918429, 2.6404833836858, 2.29305135951662, 2.10271903323263, 1.77945619335347, 1.56797583081571, 1.54682779456193, 1.37160120845921, 1.40181268882175, 1.36555891238671, 1.77341389728097, 1.93655589123867, 1.90634441087613, 1.93353474320242, 1.86404833836858, 1.81570996978852, 1.59818731117825, 1.72507552870091, 1.1631419939577, 1.01208459214502, 0.987915407854985, 1.03323262839879, 1.32326283987915, 1.34138972809668, 1.18429003021148, 1.03323262839879, 0.803625377643505, 0.43202416918429, 0.453172205438066, 0.365558912386707, 0.374622356495468, 0.45619335347432, 0.468277945619335, 0.43202416918429, 0.326283987915408, 0.234138972809668, 0.168882175226586, 0.147129909365559, 0.169184290030211, 0.171299093655589, 0.154682779456193, 0.129305135951662, 0.111178247734139, 0.0891238670694864, 0.0613293051359517, 0.0537764350453172, 0.048036253776435, 0.0392749244712991, 0.0338368580060423, 0.0300906344410876, 0.0268277945619335, 0.0238368580060423, 0.0211480362537764, 0.0187915407854985, 0.0142296072507553, 0.0109365558912387, 0.00870090634441088, 0.00737160120845921, 0.00634441087613293, 0.00549848942598187, 0.00486404833836858, 0.0043202416918429, 0.00389728096676737, 0.00350453172205438, 0.00293353474320242, 0.0024833836858006, 0.00212688821752266, 0.00183987915407855, 0.00160725075528701, 0.000897280966767372 };
            PGAonSa_FAR[1].Vertical = new List<double>() { 1, 0.980582524271845, 0.980582524271845, 1, 1.04854368932039, 1.042071197411, 1.06148867313916, 1.10032362459547, 1.09385113268608, 1.07119741100324, 1.10032362459547, 1.17799352750809, 1.21035598705502, 1.22977346278317, 1.20711974110032, 1.18122977346278, 1.10679611650485, 1.19093851132686, 1.33009708737864, 1.3042071197411, 1.35275080906149, 1.37216828478964, 1.23300970873786, 1.37864077669903, 1.37864077669903, 1.76699029126214, 1.96440129449838, 1.99676375404531, 2.35275080906149, 2.19093851132686, 2.16504854368932, 2.00970873786408, 2.16828478964401, 2.32038834951456, 2.10032362459547, 2.16828478964401, 2.05501618122977, 1.85760517799353, 1.62783171521036, 1.86407766990291, 2.06472491909385, 1.90291262135922, 1.4368932038835, 1.3915857605178, 1.32038834951456, 1.23300970873786, 1.00970873786408, 1.11003236245955, 1.19417475728155, 1.15210355987055, 1.10679611650485, 1.14886731391586, 1.16504854368932, 1.14239482200647, 1.09708737864078, 0.980582524271845, 0.889967637540453, 0.611650485436893, 0.919093851132686, 0.870550161812298, 0.818770226537217, 0.783171521035599, 0.663430420711974, 0.469255663430421, 0.449838187702265, 0.44336569579288, 0.407766990291262, 0.453074433656958, 0.401294498381877, 0.420711974110032, 0.546925566343042, 0.663430420711974, 0.692556634304207, 0.711974110032362, 0.799352750809062, 0.877022653721683, 0.851132686084142, 0.728155339805825, 0.440129449838188, 0.283171521035599, 0.254045307443366, 0.237864077669903, 0.206796116504854, 0.192880258899676, 0.165695792880259, 0.131391585760518, 0.114239482200647, 0.106796116504854, 0.0935275080906149, 0.0799352750809061, 0.0673139158576052, 0.055663430420712, 0.0459546925566343, 0.0381877022653722, 0.0326860841423948, 0.0249190938511327, 0.0209708737864078, 0.018705501618123, 0.0162135922330097, 0.0138511326860841, 0.0118122977346278, 0.0100970873786408, 0.00870550161812298, 0.00792880258899676, 0.0072168284789644, 0.00601941747572816, 0.00508090614886731, 0.0043042071197411, 0.00368932038834951, 0.00321359223300971, 0.00177669902912621 };
            PGAonSa_FAR[2].Vertical = new List<double>() { 1, 0.985294117647059, 1.06372549019608, 1.05882352941176, 1.25, 1.21078431372549, 1.23529411764706, 1.40686274509804, 1.57352941176471, 2.29901960784314, 2.51470588235294, 2.52450980392157, 2.29901960784314, 2.00490196078431, 1.98039215686275, 2.17156862745098, 2.27450980392157, 2.06862745098039, 1.88235294117647, 2.10294117647059, 2.2156862745098, 2.24019607843137, 2.70098039215686, 2.18137254901961, 2.30882352941176, 2.25490196078431, 2.51470588235294, 2.38235294117647, 2.37745098039216, 2.25980392156863, 2.13725490196078, 2.43627450980392, 2.47058823529412, 2.24509803921569, 2.93627450980392, 2.7156862745098, 2.91666666666667, 2.9656862745098, 2.12254901960784, 2.12254901960784, 2.15196078431373, 2.1421568627451, 2.38235294117647, 2.18627450980392, 2.16176470588235, 2.17647058823529, 1.84313725490196, 1.5343137254902, 1.19607843137255, 0.838235294117647, 0.936274509803922, 1.08823529411765, 1.20098039215686, 1.12254901960784, 0.995098039215686, 0.990196078431373, 0.965686274509804, 0.720588235294118, 0.799019607843137, 0.794117647058824, 0.857843137254902, 0.892156862745098, 0.686274509803922, 0.754901960784314, 0.862745098039216, 1.01960784313725, 1.04901960784314, 1.00980392156863, 0.965686274509804, 0.848039215686274, 0.720588235294118, 0.482843137254902, 0.393627450980392, 0.351960784313726, 0.367647058823529, 0.324509803921569, 0.299509803921569, 0.250490196078431, 0.249509803921569, 0.303921568627451, 0.325980392156863, 0.347549019607843, 0.362745098039216, 0.345098039215686, 0.302941176470588, 0.262254901960784, 0.242647058823529, 0.224019607843137, 0.191176470588235, 0.166666666666667, 0.16078431372549, 0.158333333333333, 0.154901960784314, 0.151470588235294, 0.147058823529412, 0.147549019607843, 0.157352941176471, 0.143137254901961, 0.134313725490196, 0.119117647058824, 0.106862745098039, 0.0916666666666667, 0.0779411764705882, 0.0720588235294118, 0.0651960784313726, 0.0524509803921569, 0.041421568627451, 0.0318137254901961, 0.0243137254901961, 0.0206862745098039, 0.0111274509803922 };
            PGAonSa_FAR[3].Vertical = new List<double>() { 1, 0.993377483443709, 1, 1.00662251655629, 1.01986754966887, 1.01324503311258, 1.07284768211921, 1.03311258278146, 1.03973509933775, 1.11258278145695, 1.10596026490066, 1.0794701986755, 1.06622516556291, 1.07284768211921, 1.14569536423841, 1.2317880794702, 1.47019867549669, 1.63576158940397, 1.62251655629139, 1.58940397350993, 1.80794701986755, 1.58278145695364, 1.71523178807947, 1.89403973509934, 2.45033112582781, 2.60927152317881, 2.72847682119205, 2.43046357615894, 2.50331125827815, 2.88079470198676, 2.54304635761589, 2.59602649006623, 2.49668874172185, 2.60927152317881, 2.39735099337748, 2.56953642384106, 2.3046357615894, 2.49006622516556, 1.95364238410596, 2.24503311258278, 2.25827814569536, 2.71523178807947, 2.94701986754967, 2.66887417218543, 2.47019867549669, 2.09271523178808, 1.63576158940397, 1.54304635761589, 1.50993377483444, 1.71523178807947, 1.44370860927152, 1.78807947019868, 2.39072847682119, 2.45695364238411, 2.36423841059603, 2.05298013245033, 1.9205298013245, 1.63576158940397, 0.993377483443709, 1.05960264900662, 1.11920529801325, 1.21192052980132, 1.31788079470199, 1.24503311258278, 1.05298013245033, 0.887417218543046, 0.827814569536424, 0.754966887417219, 0.603973509933775, 0.708609271523179, 0.834437086092715, 0.76158940397351, 0.633774834437086, 0.591390728476821, 0.545033112582781, 0.579470198675497, 0.514569536423841, 0.44635761589404, 0.378145695364238, 0.339735099337748, 0.355629139072848, 0.365562913907285, 0.368211920529801, 0.347682119205298, 0.266887417218543, 0.194039735099338, 0.160264900662252, 0.149006622516556, 0.122516556291391, 0.120529801324503, 0.116556291390728, 0.127814569536424, 0.135761589403974, 0.137748344370861, 0.136423841059603, 0.117218543046358, 0.114569536423841, 0.110596026490066, 0.101324503311258, 0.0874172185430464, 0.0728476821192053, 0.0604635761589404, 0.0508609271523179, 0.0440397350993377, 0.0394039735099338, 0.0294039735099338, 0.0245033112582781, 0.0203973509933775, 0.0170198675496689, 0.0143046357615894, 0.00695364238410596 };
            PGAonSa_FAR[4].Vertical = new List<double>() { 1, 1.19047619047619, 1.22448979591837, 1.25850340136054, 1.46258503401361, 1.56462585034014, 1.76190476190476, 2.21768707482993, 2.30612244897959, 2.66666666666667, 2.80952380952381, 2.61904761904762, 2.7891156462585, 2.91836734693878, 2.91156462585034, 2.42857142857143, 2.49659863945578, 3.02721088435374, 2.87074829931973, 2.89115646258503, 3, 3.35374149659864, 2.54421768707483, 2.51020408163265, 2.31972789115646, 2.50340136054422, 2.41496598639456, 2.20408163265306, 2.38775510204082, 2.46258503401361, 2.38095238095238, 2.21768707482993, 2.10204081632653, 1.93197278911565, 1.80952380952381, 1.71428571428571, 1.90476190476191, 1.63265306122449, 1.56462585034014, 1.40816326530612, 1.42176870748299, 1.40136054421769, 1.42176870748299, 1.59863945578231, 1.60544217687075, 1.80272108843537, 1.68027210884354, 1.60544217687075, 1.53741496598639, 1.33333333333333, 1.17687074829932, 1.03401360544218, 0.891156462585034, 0.884353741496599, 0.931972789115646, 0.965986394557823, 0.925170068027211, 0.761904761904762, 0.73469387755102, 0.700680272108844, 0.66530612244898, 0.768707482993197, 0.789115646258504, 0.677551020408163, 0.487755102040816, 0.485034013605442, 0.46530612244898, 0.478231292517007, 0.525850340136054, 0.566666666666667, 0.508163265306123, 0.537414965986395, 0.551020408163265, 0.553061224489796, 0.643537414965986, 0.583673469387755, 0.617006802721089, 0.47891156462585, 0.391156462585034, 0.361904761904762, 0.334013605442177, 0.338775510204082, 0.433333333333333, 0.440136054421769, 0.438775510204082, 0.397959183673469, 0.408163265306122, 0.412244897959184, 0.414285714285714, 0.47687074829932, 0.593877551020408, 0.652380952380952, 0.543537414965986, 0.418367346938776, 0.346938775510204, 0.289115646258503, 0.17687074829932, 0.11156462585034, 0.10952380952381, 0.0843537414965986, 0.0677551020408163, 0.0525170068027211, 0.0414285714285714, 0.0372108843537415, 0.0313605442176871, 0.0280272108843537, 0.0205442176870748, 0.0155102040816327, 0.0146938775510204, 0.0119727891156463, 0.00663945578231293 };
            PGAonSa_FAR[5].Vertical = new List<double>() { 1, 1.05555555555556, 1.07638888888889, 1.02777777777778, 1.11111111111111, 1.09722222222222, 1.15277777777778, 1.3125, 1.40277777777778, 1.68055555555556, 1.94444444444444, 1.85416666666667, 1.75, 1.70138888888889, 1.875, 2.11805555555556, 2.375, 2.45138888888889, 2.41666666666667, 2.27777777777778, 2.41666666666667, 2.49305555555556, 2, 1.90972222222222, 2.03472222222222, 2.43055555555556, 2.47916666666667, 2.50694444444444, 2.61111111111111, 3.35416666666667, 3.45138888888889, 3.28472222222222, 2.73611111111111, 2.41666666666667, 2.43055555555556, 2.55555555555556, 2.97222222222222, 2.98611111111111, 2.51388888888889, 2.28472222222222, 2.03472222222222, 1.76388888888889, 1.82638888888889, 1.67361111111111, 1.50694444444444, 1.28472222222222, 1.25, 1.13194444444444, 0.930555555555556, 0.777777777777778, 0.784722222222222, 0.770833333333333, 0.805555555555556, 0.875, 0.902777777777778, 0.826388888888889, 0.631944444444444, 0.521527777777778, 0.491666666666667, 0.442361111111111, 0.4, 0.400694444444444, 0.43125, 0.375694444444444, 0.444444444444444, 0.466666666666667, 0.45625, 0.428472222222222, 0.329861111111111, 0.2375, 0.209027777777778, 0.172916666666667, 0.209722222222222, 0.190972222222222, 0.204861111111111, 0.207638888888889, 0.230555555555556, 0.2625, 0.280555555555556, 0.319444444444444, 0.338888888888889, 0.361111111111111, 0.421527777777778, 0.501388888888889, 0.567361111111111, 0.6375, 0.638888888888889, 0.615972222222222, 0.561111111111111, 0.483333333333333, 0.410416666666667, 0.352083333333333, 0.317361111111111, 0.289583333333333, 0.276388888888889, 0.222916666666667, 0.189583333333333, 0.135416666666667, 0.114583333333333, 0.0875, 0.0620138888888889, 0.0522222222222222, 0.0436111111111111, 0.0356944444444444, 0.0300694444444444, 0.0220138888888889, 0.0201388888888889, 0.0167361111111111, 0.0132638888888889, 0.0104861111111111, 0.00540277777777778 };
            PGAonSa_FAR[6].Vertical = new List<double>() { 1, 0.992307692307692, 0.994871794871795, 1, 1.00769230769231, 1.00769230769231, 1.01025641025641, 1.01538461538462, 1.02051282051282, 1.03846153846154, 1.04102564102564, 1.04102564102564, 1.04358974358974, 1.04358974358974, 1.03846153846154, 1.05128205128205, 1.08717948717949, 1.12820512820513, 1.09487179487179, 1.14358974358974, 1.21282051282051, 1.13589743589744, 1.20512820512821, 1.31025641025641, 1.63333333333333, 1.6974358974359, 1.68717948717949, 1.8025641025641, 1.58205128205128, 1.82051282051282, 1.83846153846154, 1.72307692307692, 2, 2.22564102564103, 2.71794871794872, 3.28205128205128, 3.51282051282051, 3.61538461538461, 2.92307692307692, 2.01025641025641, 1.95897435897436, 2.24358974358974, 3.51282051282051, 4.1025641025641, 4.02564102564103, 2.7948717948718, 1.99230769230769, 1.73846153846154, 1.53076923076923, 1.47435897435897, 1.53076923076923, 1.49230769230769, 1.63076923076923, 1.76923076923077, 1.87692307692308, 1.88717948717949, 1.63589743589744, 0.88974358974359, 0.802564102564102, 0.630769230769231, 0.551282051282051, 0.520512820512821, 0.441025641025641, 0.397435897435897, 0.438461538461538, 0.412820512820513, 0.317948717948718, 0.307692307692308, 0.292307692307692, 0.274358974358974, 0.233846153846154, 0.203076923076923, 0.188717948717949, 0.201025641025641, 0.170769230769231, 0.124358974358974, 0.0976923076923077, 0.0838461538461538, 0.0825641025641026, 0.0774358974358974, 0.0743589743589744, 0.0702564102564103, 0.0592307692307692, 0.0474358974358974, 0.0407692307692308, 0.0392307692307692, 0.0397435897435897, 0.0405128205128205, 0.0420512820512821, 0.0430769230769231, 0.0435897435897436, 0.0423076923076923, 0.0453846153846154, 0.047948717948718, 0.0487179487179487, 0.0443589743589744, 0.037948717948718, 0.0333333333333333, 0.0282051282051282, 0.0230512820512821, 0.0195641025641026, 0.0168205128205128, 0.013974358974359, 0.0117179487179487, 0.0101538461538462, 0.00761538461538462, 0.00607692307692308, 0.00492307692307692, 0.004, 0.00330769230769231, 0.00151025641025641 };
            PGAonSa_FAR[7].Vertical = new List<double>() { 1, 0.9984375, 1.0015625, 1.003125, 1.009375, 1.009375, 1.0109375, 1.0203125, 1.025, 1.0375, 1.025, 1.01875, 1.0265625, 1.0359375, 1.0484375, 1.05625, 1.0484375, 1.053125, 1.125, 1.2375, 1.3296875, 1.465625, 1.5140625, 1.34375, 1.31875, 1.25625, 1.59375, 1.4328125, 1.859375, 2.15625, 2.015625, 1.921875, 1.796875, 2.15625, 2.0625, 1.921875, 2.109375, 2.234375, 2.125, 1.875, 1.471875, 1.578125, 1.9375, 1.984375, 1.9375, 1.4703125, 1.465625, 1.4375, 1.578125, 1.9375, 1.890625, 1.59375, 1.59375, 1.5515625, 1.509375, 1.609375, 1.828125, 2.515625, 2.5, 2.25, 1.9375, 1.4359375, 1.384375, 1.2609375, 1.65625, 1.5609375, 1.46875, 1.1390625, 1.1453125, 1.440625, 1.2828125, 1.4265625, 1.4640625, 1.15625, 0.984375, 0.88125, 0.78125, 0.6984375, 0.584375, 0.4875, 0.4703125, 0.434375, 0.3453125, 0.353125, 0.31875, 0.2765625, 0.253125, 0.2265625, 0.171875, 0.130625, 0.1203125, 0.1125, 0.103125, 0.093125, 0.08875, 0.0809375, 0.06625, 0.0590625, 0.0521875, 0.04375, 0.034375, 0.03171875, 0.0290625, 0.02578125, 0.0225, 0.0165625, 0.012109375, 0.009734375, 0.00790625, 0.006796875, 0.003359375 };
            PGAonSa_FAR[8].Vertical = new List<double>() { 1, 0.995169082125604, 1.01932367149758, 1.05314009661836, 1.1256038647343, 1.14492753623188, 1.19323671497585, 1.27536231884058, 1.34299516908213, 1.47342995169082, 1.47826086956522, 1.58454106280193, 1.68599033816425, 1.76811594202899, 1.72946859903382, 1.58454106280193, 1.94685990338164, 2.4975845410628, 2.76328502415459, 3.08695652173913, 3.02898550724638, 3.08695652173913, 3.21256038647343, 2.98550724637681, 3.68599033816425, 4.21256038647343, 4.42512077294686, 4.34299516908213, 3.24154589371981, 2.11594202898551, 2.1304347826087, 2.69082125603865, 2.42995169082126, 1.77777777777778, 2.18840579710145, 2.17874396135266, 2.17874396135266, 1.83574879227053, 1.76811594202899, 2.01932367149758, 2.15942028985507, 1.9951690821256, 1.56521739130435, 1.33816425120773, 1.41545893719807, 1.64734299516908, 1.65700483091787, 1.71014492753623, 1.7487922705314, 1.60869565217391, 1.17874396135266, 0.93719806763285, 0.792270531400966, 0.816425120772947, 0.792270531400966, 0.63768115942029, 0.584541062801932, 0.835748792270531, 0.792270531400966, 0.642512077294686, 0.618357487922705, 0.632850241545894, 0.835748792270531, 0.893719806763285, 0.821256038647343, 0.719806763285024, 0.613526570048309, 0.550724637681159, 0.497584541062802, 0.507246376811594, 0.531400966183575, 0.531400966183575, 0.448309178743961, 0.536231884057971, 0.502415458937198, 0.473429951690821, 0.516908212560386, 0.613526570048309, 0.628019323671498, 0.445410628019324, 0.470048309178744, 0.560386473429952, 0.70048309178744, 0.734299516908213, 0.671497584541063, 0.565217391304348, 0.507246376811594, 0.451690821256039, 0.352173913043478, 0.267632850241546, 0.207246376811594, 0.166183574879227, 0.164251207729469, 0.164734299516908, 0.164734299516908, 0.164251207729469, 0.178260869565217, 0.172946859903382, 0.167149758454106, 0.146376811594203, 0.120289855072464, 0.0932367149758454, 0.070048309178744, 0.0647342995169082, 0.0589371980676329, 0.0471014492753623, 0.0365700483091787, 0.0283091787439614, 0.0222222222222222, 0.0177777777777778, 0.00797101449275362 };
            PGAonSa_FAR[9].Vertical = new List<double>() { 1, 1.09199522102748, 1.15890083632019, 1.40979689366786, 1.87574671445639, 2.04301075268817, 2.42532855436081, 3.01075268817204, 3.47670250896057, 4.3010752688172, 3.53643966547192, 3.38112305854241, 3.47670250896057, 3.53643966547192, 3.83512544802867, 3.63201911589008, 2.41338112305854, 2.17443249701314, 2.25806451612903, 2.52090800477897, 2.41338112305854, 2.40143369175627, 2.13859020310633, 1.99522102747909, 2.29390681003584, 1.82795698924731, 1.94743130227001, 2.00716845878136, 1.94743130227001, 2.07885304659498, 2.16248506571087, 2.01911589008363, 2.17443249701314, 2.11469534050179, 2.29390681003584, 2.31780167264038, 2.58064516129032, 2.5089605734767, 1.85185185185185, 1.62485065710872, 1.40979689366786, 1.60095579450418, 1.57706093189964, 1.49342891278375, 1.46953405017921, 1.37395459976105, 1.21863799283154, 1.37395459976105, 1.49342891278375, 1.35005973715651, 1.44563918757467, 1.42174432497013, 1.50537634408602, 1.51732377538829, 1.49342891278375, 1.38590203106332, 1.39784946236559, 1.72043010752688, 1.14336917562724, 1.01911589008363, 1.04062126642772, 0.890083632019116, 0.776583034647551, 0.694145758661888, 0.750298685782557, 0.811230585424134, 0.898446833930705, 0.782556750298686, 0.578255675029869, 0.721624850657109, 0.541218637992832, 0.477897252090801, 0.482676224611709, 0.464755077658303, 0.51015531660693, 0.550776583034648, 0.507765830346476, 0.463560334528076, 0.412186379928315, 0.335722819593787, 0.315412186379928, 0.327359617682198, 0.399044205495818, 0.43847072879331, 0.414575866188769, 0.329749103942652, 0.299880525686977, 0.293906810035842, 0.289127837514934, 0.280764635603345, 0.271206690561529, 0.258064516129032, 0.26284348864994, 0.289127837514934, 0.301075268817204, 0.279569892473118, 0.223416965352449, 0.181600955794504, 0.139784946236559, 0.117204301075269, 0.095221027479092, 0.0775388291517324, 0.0636798088410992, 0.0554360812425329, 0.0506571087216248, 0.0410991636798088, 0.0323775388291517, 0.0258064516129032, 0.0216248506571087, 0.0194743130227001, 0.0109438470728793 };
            PGAonSa_FAR[10].Vertical = new List<double>() { 1, 1, 1.0431654676259, 1.18705035971223, 1.22302158273381, 1.23741007194245, 1.17985611510791, 1.11510791366906, 1.10071942446043, 1.0863309352518, 1.11510791366906, 1.2158273381295, 1.2158273381295, 1.20863309352518, 1.30935251798561, 1.44604316546763, 1.7841726618705, 1.88489208633094, 1.87769784172662, 2.10071942446043, 2.28776978417266, 2.58992805755396, 2.79136690647482, 2.48920863309352, 3.0431654676259, 2.62589928057554, 1.8273381294964, 2.19424460431655, 2, 1.7841726618705, 1.70503597122302, 1.86330935251799, 2.0863309352518, 2.01438848920863, 2.2589928057554, 2.40287769784173, 2.73381294964029, 3.40287769784173, 2.42446043165468, 2.38848920863309, 2.24460431654676, 2.10791366906475, 1.85611510791367, 1.75539568345324, 1.7841726618705, 1.46762589928058, 1.2589928057554, 1.38129496402878, 1.51079136690647, 1.71223021582734, 1.63309352517986, 1.58273381294964, 1.38848920863309, 1.30215827338129, 1.1726618705036, 1.13669064748201, 1.03597122302158, 0.762589928057554, 0.776978417266187, 0.76978417266187, 0.76978417266187, 0.610791366906475, 0.670503597122302, 0.841726618705036, 0.848920863309352, 1.02158273381295, 0.97841726618705, 1.10791366906475, 0.877697841726619, 0.992805755395683, 1.0431654676259, 1.11510791366906, 1.02877697841727, 0.762589928057554, 0.531654676258993, 0.438129496402878, 0.369064748201439, 0.37841726618705, 0.323741007194245, 0.277697841726619, 0.274820143884892, 0.258273381294964, 0.215827338129496, 0.193525179856115, 0.173381294964029, 0.184172661870504, 0.189928057553957, 0.190647482014388, 0.175539568345324, 0.151079136690647, 0.13021582733813, 0.119424460431655, 0.12158273381295, 0.131654676258993, 0.141726618705036, 0.141726618705036, 0.12158273381295, 0.101438848920863, 0.0827338129496403, 0.0748201438848921, 0.0623021582733813, 0.0490647482014388, 0.0369064748201439, 0.0309352517985611, 0.0269064748201439, 0.0192805755395683, 0.0138129496402878, 0.0103597122302158, 0.00827338129496403, 0.00692086330935252, 0.00388489208633094 };
            PGAonSa_FAR[11].Vertical = new List<double>() { 1, 1.0561797752809, 1.09550561797753, 1.13483146067416, 1.19662921348315, 1.17977528089888, 1.07865168539326, 1.19662921348315, 1.30898876404494, 1.35955056179775, 1.56741573033708, 1.49438202247191, 1.66292134831461, 1.75280898876405, 1.73033707865169, 1.67415730337079, 1.82584269662921, 2.20786516853933, 2.43258426966292, 2.49438202247191, 2.41573033707865, 2.34269662921348, 2.28651685393258, 2.62359550561798, 3.08988764044944, 3.23595505617978, 3.07303370786517, 2.64606741573034, 2.23595505617978, 2.30337078651685, 2.57865168539326, 3.02808988764045, 2.57303370786517, 2.48876404494382, 2.20224719101124, 2.19662921348315, 2.47752808988764, 2.66292134831461, 2.74157303370787, 3.0561797752809, 3.23033707865169, 3.08426966292135, 2.34831460674157, 2.43820224719101, 2.36516853932584, 2.64606741573034, 2.6685393258427, 2.42134831460674, 2.08426966292135, 1.37078651685393, 1.10112359550562, 1.01685393258427, 1.31460674157303, 1.3876404494382, 1.37640449438202, 1.07303370786517, 1.00561797752809, 1.4438202247191, 1.41011235955056, 1.06741573033708, 1.03370786516854, 1.16292134831461, 0.882022471910112, 0.55561797752809, 0.531460674157303, 0.41685393258427, 0.423033707865169, 0.464606741573034, 0.431460674157303, 0.403370786516854, 0.458426966292135, 0.385955056179775, 0.316292134831461, 0.284269662921348, 0.253370786516854, 0.221348314606742, 0.237078651685393, 0.206741573033708, 0.196067415730337, 0.152808988764045, 0.131460674157303, 0.119662921348315, 0.103932584269663, 0.0853932584269663, 0.0797752808988764, 0.0971910112359551, 0.101123595505618, 0.0971910112359551, 0.0966292134831461, 0.0887640449438202, 0.0820224719101124, 0.0814606741573034, 0.0825842696629213, 0.0825842696629213, 0.0870786516853933, 0.0764044943820225, 0.0707865168539326, 0.0612359550561798, 0.0517415730337079, 0.0443258426966292, 0.0384831460674157, 0.0347191011235955, 0.0298314606741573, 0.0245505617977528, 0.0196629213483146, 0.0156179775280899, 0.011685393258427, 0.00876404494382023, 0.00662921348314607, 0.00535393258426966, 0.00229775280898876 };
            PGAonSa_FAR[12].Vertical = new List<double>() { 1, 1.41826923076923, 1.89102564102564, 2.03525641025641, 1.77884615384615, 1.74679487179487, 1.84294871794872, 1.90705128205128, 1.92307692307692, 2.19551282051282, 2.54807692307692, 3.02884615384615, 3.14102564102564, 3.15705128205128, 3.04487179487179, 2.66025641025641, 3.09294871794872, 2.98076923076923, 2.86858974358974, 2.70833333333333, 2.37179487179487, 2.58012820512821, 2.70833333333333, 2.43589743589744, 3.01282051282051, 3.09294871794872, 2.61217948717949, 2.33974358974359, 2.45192307692308, 2.98076923076923, 3.17307692307692, 2.83653846153846, 2.91666666666667, 3.09294871794872, 2.45192307692308, 2.46794871794872, 2.53205128205128, 2.98076923076923, 2.2275641025641, 1.31089743589744, 1.05288461538462, 0.951923076923077, 1.00160256410256, 0.94551282051282, 0.947115384615385, 0.825320512820513, 0.955128205128205, 0.940705128205128, 0.934294871794872, 0.814102564102564, 0.613782051282051, 0.580128205128205, 0.5625, 0.559294871794872, 0.512820512820513, 0.405448717948718, 0.34775641025641, 0.467948717948718, 0.564102564102564, 0.52724358974359, 0.490384615384615, 0.373397435897436, 0.27724358974359, 0.243589743589744, 0.238782051282051, 0.253205128205128, 0.253205128205128, 0.25, 0.206730769230769, 0.161858974358974, 0.14775641025641, 0.14375, 0.176282051282051, 0.165064102564103, 0.150641025641026, 0.107211538461538, 0.0834935897435897, 0.0573717948717949, 0.0389423076923077, 0.0461538461538461, 0.0440705128205128, 0.0395833333333333, 0.0290064102564103, 0.0275641025641026, 0.0291666666666667, 0.0299679487179487, 0.0307692307692308, 0.0330128205128205, 0.0322115384615385, 0.0278846153846154, 0.0243589743589744, 0.0193910256410256, 0.0166666666666667, 0.0140384615384615, 0.0114903846153846, 0.00871794871794872, 0.0075801282051282, 0.00615384615384615, 0.00490384615384615, 0.00419871794871795, 0.00360576923076923, 0.00309294871794872, 0.00266025641025641, 0.00229166666666667, 0.00200320512820513, 0.00168269230769231, 0.00136858974358974, 0.00129487179487179, 0.00113621794871795, 0.000980769230769231, 0.00052724358974359 };
            PGAonSa_FAR[13].Vertical = new List<double>() { 1, 1.26666666666667, 1.24057971014493, 1.6, 1.78260869565217, 1.74202898550725, 1.51304347826087, 1.80579710144928, 1.88115942028986, 2.66086956521739, 2.49275362318841, 2.86666666666667, 2.98550724637681, 3.21739130434783, 3.44927536231884, 3.42028985507246, 2.85507246376812, 3.2463768115942, 3.18840579710145, 3.1304347826087, 3.01449275362319, 2.52753623188406, 2.24057971014493, 1.92753623188406, 2.01739130434783, 1.77971014492754, 1.95652173913044, 2.3536231884058, 3.04347826086957, 2.62028985507246, 2.43768115942029, 1.85797101449275, 1.37391304347826, 1.22608695652174, 1.02608695652174, 1.07246376811594, 1.14202898550725, 0.889855072463768, 0.895652173913044, 1.13623188405797, 1.25507246376812, 1.29275362318841, 1.52173913043478, 1.45797101449275, 1.37971014492754, 1.21449275362319, 1.00289855072464, 0.927536231884058, 0.840579710144927, 0.71304347826087, 0.814492753623189, 0.904347826086957, 0.866666666666667, 0.884057971014493, 0.863768115942029, 0.736231884057971, 0.669565217391304, 0.542028985507246, 0.382608695652174, 0.253913043478261, 0.213333333333333, 0.197391304347826, 0.179710144927536, 0.205797101449275, 0.235652173913043, 0.301449275362319, 0.388405797101449, 0.428985507246377, 0.394202898550725, 0.466666666666667, 0.620289855072464, 0.628985507246377, 0.426086956521739, 0.405797101449275, 0.417391304347826, 0.394202898550725, 0.359420289855072, 0.321739130434783, 0.220579710144928, 0.181739130434783, 0.166376811594203, 0.145217391304348, 0.128405797101449, 0.110144927536232, 0.1, 0.103768115942029, 0.104927536231884, 0.105217391304348, 0.104347826086957, 0.100869565217391, 0.0953623188405797, 0.0884057971014493, 0.0814492753623188, 0.0742028985507246, 0.0727536231884058, 0.0643478260869565, 0.0605797101449275, 0.0455072463768116, 0.0379710144927536, 0.0301449275362319, 0.0238840579710145, 0.0211014492753623, 0.0188405797101449, 0.0168115942028986, 0.0150144927536232, 0.0120579710144928, 0.00979710144927536, 0.00808695652173913, 0.00672463768115942, 0.00568115942028986, 0.00280869565217391 };
            PGAonSa_FAR[14].Vertical = new List<double>() { 1, 1.00183486238532, 1.03853211009174, 1.18165137614679, 1.05504587155963, 1.09908256880734, 1.12293577981651, 1.10642201834862, 1.08073394495413, 1.08256880733945, 1.0954128440367, 1.12293577981651, 1.15596330275229, 1.19816513761468, 1.28623853211009, 1.32660550458716, 1.51926605504587, 1.65137614678899, 1.79633027522936, 1.78165137614679, 2, 2.31192660550459, 2.67889908256881, 2.44036697247706, 2.1651376146789, 2.69724770642202, 2.51376146788991, 2.6605504587156, 2.75229357798165, 3.21100917431193, 3.1743119266055, 2.73394495412844, 2.64220183486239, 3.19266055045872, 3.61467889908257, 3.22935779816514, 2.6605504587156, 2.29357798165138, 1.98165137614679, 1.64954128440367, 1.71743119266055, 2, 2.1651376146789, 2.29357798165138, 2.18348623853211, 1.90825688073394, 1.48073394495413, 1.45137614678899, 1.50275229357798, 1.34311926605505, 1.24587155963303, 1.20917431192661, 1.13761467889908, 1.08256880733945, 0.996330275229358, 0.926605504587156, 0.941284403669725, 1.05871559633028, 0.948623853211009, 0.792660550458716, 0.871559633027523, 0.875229357798165, 0.825688073394495, 0.78348623853211, 0.607339449541284, 0.552293577981651, 0.6, 0.680733944954128, 0.721100917431193, 0.609174311926606, 0.66605504587156, 0.63302752293578, 0.508256880733945, 0.310091743119266, 0.273394495412844, 0.337614678899083, 0.368807339449541, 0.379816513761468, 0.311926605504587, 0.260550458715596, 0.26605504587156, 0.278899082568807, 0.299082568807339, 0.291743119266055, 0.297247706422018, 0.291743119266055, 0.284403669724771, 0.275229357798165, 0.24954128440367, 0.21651376146789, 0.185321100917431, 0.161834862385321, 0.143853211009174, 0.130275229357798, 0.122201834862385, 0.114678899082569, 0.105688073394495, 0.0877064220183486, 0.0779816513761468, 0.0660550458715596, 0.0524770642201835, 0.0458715596330275, 0.0414678899082569, 0.0365137614678899, 0.0319266055045872, 0.0236697247706422, 0.0172660550458716, 0.0127155963302752, 0.00952293577981651, 0.00746788990825688, 0.00436697247706422 };
            PGAonSa_FAR[15].Vertical = new List<double>() { 1, 1.0546875, 1.078125, 1.0546875, 1.09375, 1.1171875, 1.21875, 1.2265625, 1.2890625, 1.3203125, 1.375, 1.3359375, 1.3359375, 1.40625, 1.5859375, 1.59375, 1.6953125, 1.75, 1.96875, 2.1171875, 2.09375, 1.875, 2.359375, 2.859375, 2.71875, 3.421875, 3.0859375, 3.1015625, 2.734375, 3.140625, 3.1015625, 2.609375, 2.7734375, 2.6484375, 2.09375, 2.0703125, 2.1796875, 2.125, 1.7734375, 1.5546875, 1.5859375, 1.5546875, 1.7421875, 1.421875, 1.1171875, 1.1875, 1.3359375, 1.2734375, 1.2890625, 1.328125, 1, 1.078125, 1.015625, 0.9375, 0.984375, 1.21875, 1.34375, 1.1171875, 1.3203125, 1.2265625, 1.0703125, 0.984375, 0.796875, 0.828125, 1.0625, 0.9375, 0.7640625, 0.61953125, 0.45859375, 0.51640625, 0.59453125, 0.61171875, 0.5265625, 0.496875, 0.50703125, 0.4390625, 0.365625, 0.34140625, 0.253125, 0.21015625, 0.21875, 0.19921875, 0.140625, 0.13828125, 0.1390625, 0.14296875, 0.14765625, 0.1515625, 0.15859375, 0.17734375, 0.19375, 0.18984375, 0.178125, 0.1734375, 0.17578125, 0.1390625, 0.0890625, 0.061796875, 0.04375, 0.03609375, 0.034140625, 0.02921875, 0.023828125, 0.01875, 0.0165625, 0.012265625, 0.008984375, 0.008671875, 0.008125, 0.00715625, 0.0035078125 };
            PGAonSa_FAR[16].Vertical = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            PGAonSa_FAR[17].Vertical = new List<double>() { 1.007598107, 1.013188451, 1.018693842, 1.027065032, 1.038443006, 1.032840207, 1.035215023, 1.038797793, 1.039997567, 1.071073136, 1.070879501, 1.070685936, 1.07058918, 1.070492442, 1.070299017, 1.057090184, 1.102807323, 1.069139935, 1.117029669, 1.137408743, 1.267222166, 1.353722407, 1.290436301, 1.362131141, 1.702322651, 1.77355827, 1.634575307, 2.028171697, 1.774346411, 1.728249445, 1.790543239, 2.277954063, 2.250138147, 1.972462421, 2.650126572, 2.686781268, 2.705810788, 2.198771144, 2.306043695, 2.556057797, 2.69876107, 2.576432189, 2.190091503, 1.817062386, 1.759101855, 1.641004652, 1.249655396, 1.234755577, 1.179743731, 1.154270649, 1.335939762, 1.335778624, 1.178980381, 1.152595787, 1.101289472, 0.9804576, 0.945427967, 1.080927037, 1.216081094, 1.08941741, 1.060984325, 1.038935647, 1.190676342, 1.042948062, 1.016031938, 1.094543157, 1.162615754, 1.118268924, 1.056777814, 0.975391724, 0.719870586, 0.471387009, 0.364668062, 0.338345806, 0.251594692, 0.273322588, 0.343424138, 0.35675035, 0.286409595, 0.273449595, 0.225139896, 0.167025636, 0.121338765, 0.11890315, 0.120244887, 0.087069925, 0.079782271, 0.073203627, 0.076140432, 0.101569198, 0.114121775, 0.109860863, 0.117498292, 0.116385257, 0.111015421, 0.104100583, 0.090827028, 0.069036567, 0.051012556, 0.036731208, 0.02877127, 0.025711234, 0.0251208, 0.0250127, 0.024015331, 0.014544591, 0.011449407, 0.009187285, 0.007493407, 0.006198412, 0.002809952 };
            PGAonSa_FAR[18].Vertical = new List<double>() { 1, 1.0421686746988, 1.0421686746988, 1.08433734939759, 1.16867469879518, 1.24096385542169, 1.40963855421687, 1.54819277108434, 1.59638554216867, 1.36144578313253, 1.43975903614458, 1.5, 1.5, 1.5, 1.47590361445783, 1.44578313253012, 1.65060240963855, 1.48192771084337, 1.60843373493976, 1.81927710843373, 1.87951807228916, 2.01807228915663, 2.53012048192771, 2.49397590361446, 2.5, 2.53614457831325, 2.75903614457831, 2.80722891566265, 2.74698795180723, 2.79518072289157, 2.86746987951807, 3.29518072289157, 2.91566265060241, 2.80722891566265, 2.23493975903614, 1.69277108433735, 2.0421686746988, 2.37951807228916, 2.18072289156627, 2.51204819277108, 2.37349397590361, 2.24096385542169, 1.89156626506024, 1.74096385542169, 1.86746987951807, 2.18674698795181, 2.39759036144578, 2.28313253012048, 2.03012048192771, 1.63253012048193, 1.36746987951807, 1.1144578313253, 1.06024096385542, 1.12650602409639, 1.20481927710843, 1.30722891566265, 1.41566265060241, 1.07831325301205, 0.921686746987952, 0.939759036144578, 0.957831325301205, 1, 0.843373493975904, 1.00602409638554, 0.891566265060241, 0.957831325301205, 0.94578313253012, 0.957831325301205, 0.903614457831325, 0.91566265060241, 0.957831325301205, 0.909638554216867, 1.07831325301205, 0.873493975903614, 0.716867469879518, 0.716867469879518, 0.746987951807229, 0.801204819277108, 0.759036144578313, 0.993975903614458, 1.01204819277108, 1.09036144578313, 1.09036144578313, 0.825301204819277, 0.63855421686747, 0.540963855421687, 0.524698795180723, 0.558433734939759, 0.595180722891566, 0.614457831325301, 0.632530120481928, 0.626506024096385, 0.614457831325301, 0.584939759036145, 0.578915662650602, 0.543373493975904, 0.475903614457831, 0.368674698795181, 0.325301204819277, 0.267469879518072, 0.206024096385542, 0.158433734939759, 0.12710843373494, 0.106024096385542, 0.0897590361445783, 0.0650602409638554, 0.0516265060240964, 0.0412048192771084, 0.0333132530120482, 0.0274698795180723, 0.0133734939759036 };
            PGAonSa_FAR[19].Vertical = new List<double>() { 1, 1.27700831024931, 1.32686980609418, 1.18836565096953, 1.22991689750693, 1.24653739612188, 1.24930747922438, 1.32963988919668, 1.34349030470914, 1.36565096952909, 1.398891966759, 1.39612188365651, 1.43767313019391, 1.49307479224377, 1.57617728531856, 1.69252077562327, 1.66481994459834, 1.8808864265928, 1.65650969529086, 1.57063711911357, 1.71745152354571, 1.79224376731302, 1.56232686980609, 1.66481994459834, 1.65373961218837, 1.5207756232687, 1.49584487534626, 1.86980609418283, 1.52631578947368, 1.30193905817175, 1.35180055401662, 1.27423822714681, 0.889196675900277, 1.00277008310249, 0.975069252077562, 1.0387811634349, 1.10526315789474, 1.14958448753463, 1.0415512465374, 0.853185595567867, 0.916897506925208, 0.85595567867036, 0.797783933518005, 0.839335180055402, 0.911357340720222, 1.06094182825485, 1.04986149584488, 1.06648199445983, 1.09141274238227, 1.07479224376731, 1.14404432132964, 1.08587257617729, 1.00277008310249, 1.0387811634349, 1.10526315789474, 1.1606648199446, 1.15789473684211, 1.15512465373961, 1.15235457063712, 1.04709141274238, 0.988919667590028, 0.869806094182826, 0.795013850415512, 0.811634349030471, 0.795013850415512, 0.778393351800554, 0.71191135734072, 0.662049861495845, 0.662049861495845, 0.60387811634349, 0.493074792243767, 0.43213296398892, 0.3601108033241, 0.332409972299169, 0.346260387811634, 0.313019390581717, 0.299168975069252, 0.313019390581717, 0.236565096952909, 0.136565096952909, 0.127700831024931, 0.135734072022161, 0.143490304709141, 0.142382271468144, 0.127423822714681, 0.108310249307479, 0.106371191135734, 0.110803324099723, 0.103601108033241, 0.1, 0.0897506925207756, 0.0811634349030471, 0.0745152354570637, 0.064819944598338, 0.0520775623268698, 0.0556786703601108, 0.061218836565097, 0.0637119113573407, 0.0614958448753463, 0.0573407202216066, 0.0573407202216066, 0.0556786703601108, 0.0526315789473684, 0.0520775623268698, 0.050415512465374, 0.0448753462603878, 0.039612188365651, 0.0332409972299169, 0.0268698060941828, 0.0210249307479224, 0.00894736842105263 };
            PGAonSa_FAR[20].Vertical = new List<double>() { 1, 1.33928571428571, 1.36309523809524, 1.31547619047619, 1.46428571428571, 1.43452380952381, 1.54166666666667, 1.3452380952381, 1.38690476190476, 2.02380952380952, 2.10119047619048, 1.92857142857143, 1.75595238095238, 1.61904761904762, 1.66071428571429, 1.86904761904762, 2.94047619047619, 3.76785714285714, 2.97023809523809, 2.625, 2.70238095238095, 2.14285714285714, 1.85119047619048, 1.82738095238095, 1.75, 2.11904761904762, 2.0297619047619, 1.5297619047619, 1.22619047619048, 1.21428571428571, 1.23809523809524, 1.11904761904762, 1.10714285714286, 0.767857142857143, 0.803571428571429, 0.702380952380952, 0.791666666666667, 1.00595238095238, 1.19642857142857, 0.976190476190476, 0.773809523809524, 0.588095238095238, 0.502380952380952, 0.498809523809524, 0.523214285714286, 0.500595238095238, 0.648809523809524, 0.69047619047619, 0.69047619047619, 0.619047619047619, 0.576785714285714, 0.550595238095238, 0.486309523809524, 0.451190476190476, 0.397619047619048, 0.355357142857143, 0.392261904761905, 0.473214285714286, 0.441071428571429, 0.432142857142857, 0.407142857142857, 0.36547619047619, 0.351785714285714, 0.433928571428571, 0.473214285714286, 0.351190476190476, 0.291666666666667, 0.321428571428571, 0.361309523809524, 0.338095238095238, 0.40952380952381, 0.476785714285714, 0.320238095238095, 0.195238095238095, 0.142261904761905, 0.15297619047619, 0.158928571428571, 0.171428571428571, 0.120833333333333, 0.120238095238095, 0.123214285714286, 0.120833333333333, 0.106547619047619, 0.0976190476190476, 0.105357142857143, 0.114880952380952, 0.117261904761905, 0.119047619047619, 0.123214285714286, 0.116666666666667, 0.102380952380952, 0.0839285714285714, 0.0696428571428571, 0.0642857142857143, 0.0576190476190476, 0.0432142857142857, 0.0316071428571429, 0.0249404761904762, 0.0188690476190476, 0.0160119047619048, 0.0138095238095238, 0.0118452380952381, 0.0101785714285714, 0.00875, 0.00755952380952381, 0.00564285714285714, 0.00505952380952381, 0.00481547619047619, 0.00442261904761905, 0.00397023809523809, 0.00206547619047619 };
            PGAonSa_FAR[21].Vertical = new List<double>() { 1, 1.20567375886525, 1.14539007092199, 1.21985815602837, 1.0354609929078, 1.07446808510638, 1.0886524822695, 1.04255319148936, 1.07801418439716, 1.28723404255319, 1.32624113475177, 1.44326241134752, 1.45035460992908, 1.40780141843972, 1.33687943262411, 1.36524822695035, 1.4822695035461, 1.47517730496454, 1.43971631205674, 1.36524822695035, 1.54964539007092, 2.11347517730496, 2.45744680851064, 2.72695035460993, 2.52836879432624, 1.90070921985816, 1.9290780141844, 2.47872340425532, 2.20567375886525, 2.58156028368794, 2.62765957446809, 2.57446808510638, 2.54609929078014, 2.39716312056738, 2.98581560283688, 2.70212765957447, 2.30851063829787, 1.84751773049645, 2.10992907801418, 1.88297872340426, 1.59219858156028, 1.39716312056738, 1.36524822695035, 1.61347517730496, 1.96808510638298, 2.25886524822695, 1.96808510638298, 1.81205673758865, 1.64893617021277, 1.43971631205674, 1.1063829787234, 0.801418439716312, 0.595744680851064, 0.535460992907801, 0.49645390070922, 0.471631205673759, 0.429078014184397, 0.49290780141844, 0.379432624113475, 0.365248226950355, 0.358156028368794, 0.315957446808511, 0.284042553191489, 0.260992907801418, 0.270567375886525, 0.30886524822695, 0.321276595744681, 0.300709219858156, 0.211347517730496, 0.19113475177305, 0.164893617021277, 0.135106382978723, 0.124113475177305, 0.108156028368794, 0.103191489361702, 0.0872340425531915, 0.0648936170212766, 0.0585106382978723, 0.0482269503546099, 0.0386524822695035, 0.0393617021276596, 0.0400709219858156, 0.0411347517730496, 0.0407801418439716, 0.0397163120567376, 0.0382978723404255, 0.0393617021276596, 0.0407801418439716, 0.0414893617021277, 0.0432624113475177, 0.0453900709219858, 0.0450354609929078, 0.0436170212765958, 0.0429078014184397, 0.0414893617021277, 0.0361702127659575, 0.0293262411347518, 0.0226595744680851, 0.0189007092198582, 0.0156382978723404, 0.0148936170212766, 0.0121631205673759, 0.010354609929078, 0.00847517730496454, 0.00673758865248227, 0.0050354609929078, 0.00390070921985816, 0.00309219858156028, 0.00259219858156028, 0.00223049645390071, 0.00119858156028369 };




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
                {
                    for (int x = 0; x < 28; x++)
                    {
                        PGAonSa_NEAR_output[x].Horziantal1 = PGAonSa_NEAR[x].Horziantal1[0];
                        PGAonSa_NEAR_output[x].Horziantal2 = PGAonSa_NEAR[x].Horziantal2[0];
                        PGAonSa_NEAR_output[x].Vertical = PGAonSa_NEAR[x].Vertical[0];

                    }
                    return PGAonSa_NEAR_output;
                }
                if (T >= T_sa[T_sa.Length - 1])
                {
                    for (int x = 0; x < 28; x++)
                    {
                        PGAonSa_NEAR_output[x].Horziantal1 = PGAonSa_NEAR[x].Horziantal1[T_sa.Length - 1];
                        PGAonSa_NEAR_output[x].Horziantal2 = PGAonSa_NEAR[x].Horziantal2[T_sa.Length - 1];
                        PGAonSa_NEAR_output[x].Vertical = PGAonSa_NEAR[x].Vertical[T_sa.Length - 1];

                    }
                    return PGAonSa_NEAR_output;
                }
                else
                {
                    for (int x = 0; x < 28; x++)
                    {
                        PGAonSa_NEAR_output[x].Horziantal1 = interpolate(T_sa[i - 1], PGAonSa_NEAR[x].Horziantal1[i - 1], T_sa[i], PGAonSa_NEAR[x].Horziantal1[i], T);
                        PGAonSa_NEAR_output[x].Horziantal2 = interpolate(T_sa[i - 1], PGAonSa_NEAR[x].Horziantal2[i - 1], T_sa[i], PGAonSa_NEAR[x].Horziantal2[i], T);
                        PGAonSa_NEAR_output[x].Vertical = interpolate(T_sa[i - 1], PGAonSa_NEAR[x].Vertical[i - 1], T_sa[i], PGAonSa_NEAR[x].Vertical[i], T);

                    }
                    return PGAonSa_NEAR_output;
                }
            }

            //if far

            if (typ == 2)
            {
                if (T <= T_sa[0])
                {
                    for (int x = 0; x < 22; x++)
                    {
                        PGAonSa_FAR_output[x].Horziantal1 = PGAonSa_FAR[x].Horziantal1[0];
                        PGAonSa_FAR_output[x].Horziantal2 = PGAonSa_FAR[x].Horziantal2[0];
                        PGAonSa_FAR_output[x].Vertical = PGAonSa_FAR[x].Vertical[0];

                    }
                    return PGAonSa_FAR_output;
                }
                if (T >= T_sa[T_sa.Length - 1])
                {
                    for (int x = 0; x < 22; x++)
                    {
                        PGAonSa_FAR_output[x].Horziantal1 = PGAonSa_FAR[x].Horziantal1[T_sa.Length - 1];
                        PGAonSa_FAR_output[x].Horziantal2 = PGAonSa_FAR[x].Horziantal2[T_sa.Length - 1];
                        PGAonSa_FAR_output[x].Vertical = PGAonSa_FAR[x].Vertical[T_sa.Length - 1];

                    }
                    return PGAonSa_FAR_output;
                }
                else
                {
                    for (int x = 0; x < 22; x++)
                    {
                        PGAonSa_FAR_output[x].Horziantal1 = interpolate(T_sa[i - 1], PGAonSa_FAR[x].Horziantal1[i - 1], T_sa[i], PGAonSa_FAR[x].Horziantal1[i], T);
                        PGAonSa_FAR_output[x].Horziantal2 = interpolate(T_sa[i - 1], PGAonSa_FAR[x].Horziantal2[i - 1], T_sa[i], PGAonSa_FAR[x].Horziantal2[i], T);
                        PGAonSa_FAR_output[x].Vertical = interpolate(T_sa[i - 1], PGAonSa_FAR[x].Vertical[i - 1], T_sa[i], PGAonSa_FAR[x].Vertical[i], T);

                    }
                    return PGAonSa_FAR_output;
                }
            }
            return null;

        }

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

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=1=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            about1 a = new about1();
            a.ShowDialog();
        }

        private void iDARCLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDARC_LIC lic = new IDARC_LIC();
            lic.ShowDialog();
        }

        private void iNSPECTLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INSPECT_LIC lic = new INSPECT_LIC();
            lic.ShowDialog();
        }

        private void acknowledgementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ack ac = new Ack();
            ac.ShowDialog();
        }

        private void btn_save_plots_Click(object sender, EventArgs e)
        {
            SavePlot();
        }
        
        private void SavePlot()
        {
            PlotResults res = new PlotResults();
            res.ACMR20 = PlotInfo.ACMR20;
            res.batch = PlotInfo.batch;
            res.BTOT = PlotInfo.BTOT;
            res.c1 = PlotInfo.c1;
            res.c2 = PlotInfo.c2;
            res.c3 = PlotInfo.c3;
            res.c4 = PlotInfo.c4;
            res.c5 = PlotInfo.c5;
            res.c6_damage = PlotInfo.c6_damage;
            res.c6_drift = PlotInfo.c6_drift;
            res.cc1 = PlotInfo.cc1;
            res.cc2 = PlotInfo.cc2;
            res.cc3 = PlotInfo.cc3;
            res.cc4 = PlotInfo.cc4;
            res.cc5 = PlotInfo.cc5;
            res.cc6 = PlotInfo.cc6;
            res.cc7 = PlotInfo.cc7;
            res.ductt = PlotInfo.ductt;
            res.factors = PlotInfo.factors;
            res.FEMA_check = PlotInfo.FEMA_check;
            res.results = PlotInfo.results;
            res.Smtt = PlotInfo.Smtt;
            res.SSFf = PlotInfo.SSFf;
            res.units = Analysis.units;
            SaveFileDialog svg = new SaveFileDialog();
            svg.Filter = settings.plotExt;
            if (svg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Utilites.DeepSerialize<PlotResults>(res, svg.FileName);
               // PlotResults res2 = Utilites.DeepDeserialize<PlotResults>(@"E:\file1.pInfo");
                PlotNeedsSaving = false;
            }

        }

        private void savePlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePlot();
        }

        private void openPlotFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPlot();
        }
        private void OpenPlot()
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = settings.plotExt;
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
                 PlotResults res = Utilites.DeepDeserialize<PlotResults>(ofg.FileName);
                 if (res.results == null)
                 {
                     MessageBox.Show("No Plots to Show");
                     return;
                 }
                 plot t = new plot(ref res.results, ref res.batch, ref res.factors, res.BTOT, res.c1, res.c2, res.c3, res.c4, res.c5, res.ductt, res.SSFf, res.Smtt, res.FEMA_check, res.cc1, res.cc2, res.cc3, res.cc4, res.cc5, res.ACMR20, res.units);
                 t.Show();
                //PlotNeedsSaving = false;
            }
        }







    }
}

