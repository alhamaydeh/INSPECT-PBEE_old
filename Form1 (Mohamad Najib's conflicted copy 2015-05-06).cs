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

namespace SampleWizard
{


    public partial class Form1 : Form
    {
        Batch_opt batch_options = null;
        string batch_template = "[BATCH_TEMPLATE]";
        bool done6 = false;
        public static string __message;

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

        public Form1()
        {

            InitializeComponent();
            txt_batch_template.Text = batch_template;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;


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
            Text = "Sample Wizard";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        bool change1 = false;
        bool change2 = false;
        //  bool change3 = false;
        private void NSO_ValueChanged(object sender, EventArgs e)
        {
            Var.story_num = (int)NSO.Value;

            change1 = true;
            int size = Convert.ToInt32(NSO.Value);
            data1.ColumnCount = 1;
            data1.RowCount = size;
            int k = size;
            for (int rowIndex = 0; rowIndex < Convert.ToInt32(NSO.Value); rowIndex++)
            {

                data1.Rows[rowIndex].HeaderCell.Value = String.Format("{0}", k);
                data1["HIGT", rowIndex].Value = 0;
                k--;
            }

            //  NVLN_change = false;
            // change1 = false;
            //change2 = false;
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


        }
        private void do_temp()
        {
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

        }
        private void NFR_ValueChanged(object sender, EventArgs e)
        {
            change2 = true;

            int size1 = Convert.ToInt32(NFR.Value);
            data2.ColumnCount = 2;
            data2.RowCount = size1;

            for (int rowIndex = 0; rowIndex < size1; ++rowIndex)
            {
                data2.Rows[rowIndex].HeaderCell.Value = String.Format("{0}", rowIndex + 1);
                data2["NDUP", rowIndex].Value = 0;
                data2["NVLN", rowIndex].Value = 0;
            }
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
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NCON.Value == 0)
            {
                button15.Enabled = false;
            }

            else
            {
                button15.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from concrete";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NCON.Value; k++)
                    {
                        cmd.CommandText = "insert into concrete (IM,FC,EC,EPS0,FT,EPSU,ZF) values(" + k + ",0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }

            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void NSTL_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NSTL.Value == 0)
            {
                button16.Enabled = false;

            }
            else
            {
                button16.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from REINFORCEMENT";
                    cmd.ExecuteNonQuery();

                    for (int k = 1; k <= (int)NSTL.Value; k++)
                    {
                        cmd.CommandText = "insert into REINFORCEMENT (IM,FS,FSU,ES,ESH,EPSH) values(" + k + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void NMSR_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


            if (NMSR.Value == 0)
            {
                button17.Enabled = false;
            }
            else
            {
                button17.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from MASONRY";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NMSR.Value; k++)
                    {
                        cmd.CommandText = "insert into MASONRY (IM, FM, FMCR, EPSM, VM, SIGMM, CFM) values(" + k + ",0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }



        private void NHYS_ValueChanged_1(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (NHYS.Value == 0)
            {
                button1.Enabled = false;

            }
            else
            {

                button1.Enabled = true;


                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Hysteretic_1";
                    cmd.ExecuteNonQuery();

                    for (int k = 1; k <= (int)NHYS.Value; k++)
                    {
                        cmd.CommandText = "insert into Hysteretic_1 (IR, HC, HBD, HBE,HS, IBILINEAR, NTRANS, ETA, HSR, HSS, HSM, NGAP, PHIGAP, STIFFGAP,Ty) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
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
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (!Var.Dont_del)
            {
                cmd.CommandText = "Delete from columns";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from columns_1";
                cmd.ExecuteNonQuery();
                for (int k = 1; k <= (int)MCOL.Value; k++)
                {
                    cmd.CommandText = "insert into Columns (KC, ICTYPE, AN, ANYY, ANB, AMLC, RAMC1, RAMC2, KHYSC, EI, EA, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N, KHYSC_1, GA_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1, AN_2, ANY_2, ANB_2, AMLC_2, RAMC1_2, RAMC2_2, NEV_2, KHYSC_2, EI_2, EA_2, PCP_2, PYP_2, UYP_2, UNSP_2, ULP_2, EI3P_2, PCN_2, PYN_2, UYN_2, UNSN_2, ULN_2, EI3N_2, UUP_2, UUN_2, KHYSC_t, EI_t, EA_t, PCP_t, PYP_t, UYP_t, UUP_t, EI3P_t, PCN_t, PYN_t, UYN_t, UUN_t, EI3N_t,KHYSC_2_t,EI_2_t,EA_2_t,PCP_2_t,PYP_2_t,UYP_2_t,UNSP_2_t,ULP_2_t,EI3P_2_t,PCN_2_t,PYN_2_t,UYN_2_t,UNSN_2_t,ULN_2_t,EI3N_2_t,UUP_2_t,UUN_2_t) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                    cmd.ExecuteNonQuery();
                }
                for (int k = 1; k <= (int)MCOL.Value; k++)
                {
                    cmd.CommandText = "insert into columns_1 (KC, ICTYPE, IMC, IMS, AN, AMLC, RAMC1, RAMC2, KHYSC, D, B, DC, AT, HBD, HBS, CEF, KHYSC_t, D_t, B_t, DC_t, AT_t, HBD_t, HBS_t, CEF_t, KHYSC_1, IMC_2, IMS_2, KHYSC_2, AMLC_2, RAMC1_2, RAMC2_2, AN_2, DO_2, CVR_2, DST_2, NBAR_2, BDIA_2, HBD_2, HBS_2) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                    cmd.ExecuteNonQuery();
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
            if (MCOL.Value == 0)
            {
                groupBox11.Enabled = false;
            }
            else
                groupBox11.Enabled = true;

        }

        private void MBEM_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (!Var.Dont_del)
            {
                cmd.CommandText = "Delete from beams_1";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from beams_2";
                cmd.ExecuteNonQuery();
                for (int k = 1; k <= (int)MBEM.Value; k++)
                {
                    cmd.CommandText = "insert into beams_1 (KB, ICTYPE, IMC, IMS, AMLB, RAMB1, RAMB2, KHYSB, D, B, BSL, TSL, BC, AT1, AT2, HBD, HBS, KHYSB_1,KHYSB_t,D_t,B_t,BSL_t,TSL_t,BC_t,AT1_t,AT2_t,HBD_t,HBS_t) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                    cmd.ExecuteNonQuery();
                }
                for (int k = 1; k <= (int)MBEM.Value; k++)
                {
                    cmd.CommandText = "insert into beams_2 (KB, ICTYPE, AMLB, RAMB1, RAMB2, KHYSB, EI, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N, KHYSB_1, GA_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1,KHYSB_t,EI_t,PCP_t,PYP_t,UYP_t,UUP_t,EI3P_t,PCN_t,PYN_t,UYN_t,UUN_t,EI3N_t) values(" + k + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                    cmd.ExecuteNonQuery();
                }

            } cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
            if (MBEM.Value == 0)
            {
                groupBox12.Enabled = false;
            }
            else
                groupBox12.Enabled = true;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            C_column temp_form = new C_column(NCOL.Value);
            temp_form.ShowDialog();
        }

        private void NCOL_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NCOL.Value == 0)
            {
                button18.Enabled = false;
            }
            else
            {
                button18.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_column";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NCOL.Value; k++)
                    {
                        cmd.CommandText = "insert into C_column (M, ITC, IC, JC, LBC, LTC) values(" + k + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            C_beam temp_form = new C_beam(NBEM.Value);
            temp_form.ShowDialog();
        }

        private void NBEM_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NBEM.Value == 0)
            {
                button19.Enabled = false;
            }
            else
            {
                button19.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_beam";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NBEM.Value; k++)
                    {
                        cmd.CommandText = "insert into C_beam (M, ITB, LB, IB, JLB, JRB) values(" + k + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            C_edge temp_form = new C_edge(NEDG.Value);
            temp_form.ShowDialog();
        }

        private void NWAL_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NWAL.Value == 0)
            {
                button20.Enabled = false;
            }
            else
            {
                button20.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_shear";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NWAL.Value; k++)
                    {
                        cmd.CommandText = "insert into C_shear (M, ITW, IW, JW, LBW, LTW) values(" + k + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void NEDG_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NEDG.Value == 0)
            {
                button21.Enabled = false;
            }
            else
            {
                button21.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_edge";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NEDG.Value; k++)
                    {
                        cmd.CommandText = "insert into C_edge (M, ITE, IE, JE, LBE, LTE) values(" + k + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
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
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NTRN.Value == 0)
            {
                button22.Enabled = false;
            }
            else
            {
                button22.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_Transverse";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NTRN.Value; k++)
                    {
                        cmd.CommandText = "insert into C_Transverse (M, ITT, LT, IWT, JWT, IFT, JFT) values(" + k + ",0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void NSPR_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NSPR.Value == 0)
            {
                button23.Enabled = false;
            }
            else
            {
                button23.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_Spring";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NSPR.Value; k++)
                    {
                        cmd.CommandText = "insert into C_Spring (M, ITRSP, ISP, JSP, LSP, KSPL) values(" + k + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
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
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NMR.Value == 0)
            {
                button24.Enabled = false;
            }
            else
            {
                button24.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_Moment";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NMR.Value; k++)
                    {
                        cmd.CommandText = "insert into C_Moment (IDM, IHTY, INUM, IREG) values(" + k + ",0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }


            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void NBR_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NBR.Value == 0)
            {
                button25.Enabled = false;
            }
            else
            {
                button25.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_Brace";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NBR.Value; k++)
                    {
                        cmd.CommandText = "insert into C_Brace (M, IF_1, ITBR, ITD, LT, LB, JT, JB, AMLBR) values(" + k + ",0,0,0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void button26_Click(object sender, EventArgs e)
        {
            C_Infill temp_form = new C_Infill(NIW.Value);
            temp_form.ShowDialog();
        }

        private void NIW_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (NIW.Value == 0)
            {
                button26.Enabled = false;
            }
            else
            {
                button26.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from C_Infill";
                    cmd.ExecuteNonQuery();
                    for (int k = 1; k <= (int)NIW.Value; k++)
                    {
                        cmd.CommandText = "insert into C_Infill (M, IF_1, ITIW, LT, LB, JL, JR, JBMT) values(" + k + ",0,0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

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

            for (int k = (Convert.ToInt16(NSO.Value)) - 1; k >= 0; k--)
            {
                temp_in.Text += (k + 1).ToString() + ", ";
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
                while (reader1.Read())
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
            if (checkedListBox1.SelectedItem != null)
                ReadfromDB(checkedListBox1.SelectedItem.ToString());
        }

        private void data1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (MTRN.Value == 0)
                button10.Enabled = false;
            else
            {
                button10.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Transverse";
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= MTRN.Value; i++)
                    {
                        cmd.CommandText = "insert into Transverse (KT, AKV, ARV, ALV) values(" + i + ",0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MSPR_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (MSPR.Value == 0)
                button11.Enabled = false;
            else
            {
                button11.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Rotational";
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= MSPR.Value; i++)
                    {
                        cmd.CommandText = "insert into Rotational (KS, KHYSR, EI, PCP, PYP, UYP, UUP, EI3P, PCN, PYN, UYN, UUN, EI3N) values(" + i + ",0,0,0,0,0,0,0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MEDG_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (MEDG.Value == 0)
                button9.Enabled = false;
            else
            {
                button9.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Edge";
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= MEDG.Value; i++)
                    {
                        cmd.CommandText = "insert into Edge (KE, IMC, IMS, AN, DC, BC, AG, AMLE, ARME) values(" + i + ",0,0,0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void MWAL_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;


            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            if (MWAL.Value == 0)
                groupBox10.Enabled = false;
            else
            {
                groupBox10.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Shear_1";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Delete from Shear_2";
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= MWAL.Value; i++)
                    {

                        cmd.CommandText = "insert into Shear_1 (KW, IMC, KHYSW_1, KHYSW_2, KHYSW_3, AN, AMLW, NSECT) values(" + i + ",0,0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into Shear_2 (KW, AMLW, EAW, KHYSW_1, EI_1, PCP_1, PYP_1, UYP_1, UUP_1, EI3P_1, PCN_1, PYN_1, UYN_1, UUN_1, EI3N_1, KHYSW_2, GA_2, PCP_2, PYP_2, UYP_2, UUP_2, GA3P_2, PCN_2, PYN_2, UYN_2, UUN_2, GA3N_2) values(" + i + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"drop table if exists NSECT_" + i;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"
                                        CREATE TABLE [NSECT_" + i + @"] (
                                            [KS] integer  NOT NULL PRIMARY KEY,
                                            [IMS] float  NULL,
                                            [DWAL] float  NULL,
                                            [BWAL] float  NULL,
                                            [PT] float  NULL,
                                            [PW] float  NULL
    
                                        )";
                        cmd.ExecuteNonQuery();

                    }
                }
            } cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

        }

        private void MBRH_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (MBRH.Value == 0)
                groupBox8.Enabled = false;
            else
            {
                groupBox8.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Hysteretic_damper";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Delete from C_brace_sp";
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= MBRH.Value; i++)
                    {
                        cmd.CommandText = "insert into Hysteretic_damper (ITDH, KDH, FYDH, RPSTDH,KDHCH, ANGDH) values(" + i + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                    for (int i = 1; i <= MBRH.Value; i++)
                    {
                        cmd.CommandText = "insert into C_brace_sp (ITDH, KDH, FYDH, RPSTDH, POWER, ETA) values(" + i + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MIW_ValueChanged(object sender, EventArgs e)
        {
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
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (MBRV.Value == 0)
                groupBox17.Enabled = false;
            else
            {
                groupBox17.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Visco";
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= MBRV.Value; i++)
                    {
                        cmd.CommandText = "insert into Visco (ITDV, CDV, KDV, ALPHADV, KDVCH, ANGDV) values(" + i + ",0,0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


        }

        private void MBRF_ValueChanged(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (MBRF.Value == 0)
                groupBox9.Enabled = false;
            else
            {
                groupBox9.Enabled = true;
                if (!Var.Dont_del)
                {
                    cmd.CommandText = "Delete from Friction";
                    cmd.ExecuteNonQuery();
                    for (int i = 1; i <= MBRF.Value; i++)
                    {
                        cmd.CommandText = "insert into Friction (ITDF, KDF, FYDF, KDFCH, ANGDF) values(" + i + ",0,0,0,0)";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();


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
                    if (sqlDataReader.Read())
                        return true;
                    else
                        return false;
                }
            }
        }

        private void ICCTYPE_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void IPT_ValueChanged(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;

            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            if (!Var.Dont_del)
            {
                cmd.CommandText = "Delete from Infill";
                cmd.ExecuteNonQuery();
                for (int i = 1; i <= IPT.Value; i++)
                {
                    cmd.CommandText = "insert into Infill (IMT, TMP, VLMP, VHMP, QMPC, QMPB, QMPJ, EAIW, VYIW, AIW, BTA, GMA, ETA, ALPHIW, IS_1, AS_1, ZS, ZBS, SK, SP1, SP2, MU) values(" + i + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                    cmd.ExecuteNonQuery();
                }

            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
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
            a1.Filter = "Text File|* .db";
            if (a1.ShowDialog() == DialogResult.OK)
            {


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
            a.Filter = "Text File|* .db";
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
                a.Filter = "Text File|* .db";
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
            temp_in.Text = "";
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
        public void DoIDARC(String xx)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();

            cmd.CommandText = "select * from " + xx;
            SQLiteDataReader reader1 = cmd.ExecuteReader();
            int batch_check = 0;
            int earth_check = 0;
            reader1.Read();
            if (DataRecordExtensions.HasColumn(reader1, "batch_check"))
            {
                batch_check = Convert.ToInt16(reader1["batch_check"]);
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
                  if(Directory.Exists(Var.pp + @"\IDARC_" + xx))
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
                    decimal xfactors = ((batch_end - batch_start) / batch_inc);
                    if (((batch_end - batch_start) % batch_inc) == 0)
                        xfactors += 1;
                    int factors = Convert.ToInt16(xfactors);
                    batch = new object[count, 11];

                    decimal[, ,] results = new decimal[count, factors, 12];
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
                             Hfiles.Add(wave);
                             HfilesNames.Add("HFile_" + kk + ".dat");
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
                             Vfiles.Add(wave);
                             VfilesNames.Add("VFile_" + kk + ".dat");
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
                            batch[ii, 1] = Hfiles[ii].Max;              //Max H
                            batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
                            //batch[ii, 3] = reader1["path_v"];
                            batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
                            batch[ii, 6] = batch_end;
                            batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H
                            if (ii < VfilesNames.Count)
                            {
                                batch[ii, 5] = VfilesNames[ii];    //Name V
                                batch[ii, 8] = Vfiles[ii].Max;      //Max V
                                batch[ii, 9] = Vfiles[ii].deltaT;   //Delta V (No need- Delta of H should be same as V)
                                batch[ii, 10] = Vfiles[ii].values.Count; //Line V (No need- Numer of Lines for H should be same as V)

                            }



                        }
                    }

                    if (FEMA_check==1)

                    {
                        double SF_FEMA = 0;
                        int nEQ = 0;
                        //GET Near_Check, SF(N, F)
                        cmd.CommandText = "select * from FEMA_final";
                        reader1 = cmd.ExecuteReader();
                        reader1.Read();
                        int Near_check = Convert.ToInt16(reader1["chs_n"].ToString());
                        double SF_N = Convert.ToDouble(reader1["SF_N"].ToString());
                        double SF_F = Convert.ToDouble(reader1["SF_F"].ToString());
                        reader1.Close();
                        //ArrayList selected = new ArrayList();
                        ArrayList normlized = new ArrayList();
                        Hfiles.Clear();
                        HfilesNames.Clear();
                        Vfiles.Clear();
                        VfilesNames.Clear();

                        
                        String FEMA_path = Var.pp + @"\FEMA";
                        int tt = 0;


                        //GET FILE + Create Normilized factors

                        if (Near_check != 0) //Near
                        {
                            SF_FEMA = SF_N;
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
                                       Hfiles.Add(wave);
                                       HfilesNames.Add("HFile_" + tt + ".dat");

                                       if (System.IO.File.Exists(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat"))
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
                                           Vfiles.Add(wave3);
                                           VfilesNames.Add("VFile_" + tt + ".dat");
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
                                       Hfiles.Add(wave2);
                                       HfilesNames.Add("HFile_" + tt + ".dat");
                                       if (System.IO.File.Exists(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat"))
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
                                           Vfiles.Add(wave4);
                                           VfilesNames.Add("VFile_" + tt + ".dat");
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
                            normlized.AddRange(new double[] { 0.65, 0.83, 0.63, 1.09, 1.31, 1.01, 1.03, 1.1, 0.69, 1.36, 0.99, 1.15, 1.09, 0.88, 0.79, 0.87, 1.17, 0.82, 0.41, 0.96, 2.1, 1.44 });

                            cmd.CommandText = "select * from FEMA_files_F";
                            reader1 = cmd.ExecuteReader();
                            reader1.Read();
                            for (int i = 1; i < 22; i++)
                            {
                                if (reader1["Far"].ToString() == "1")
                                {
                                    nEQ+=2;
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
                                        wave.FEMA_Modify((double) normlized[i - 1]);
                                        wave.FEMA_max();
                                        Hfiles.Add(wave);
                                        HfilesNames.Add("HFile_" + tt + ".dat");

                                        if (System.IO.File.Exists(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2"))
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
                                            Vfiles.Add(wave3);
                                            VfilesNames.Add("VFile_" + tt + ".dat");
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
                                        Hfiles.Add(wave2);
                                        HfilesNames.Add("HFile_" + tt + ".dat");
                                        if (System.IO.File.Exists(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2"))
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
                                            Vfiles.Add(wave4);
                                            VfilesNames.Add("VFile_" + tt + ".dat");
                                        }
                                        tt++;



                                }
                                reader1.Read();

                            }
                            reader1.Close();

                        }
                        batch = new object[nEQ, 11];
                        results = new decimal[nEQ, factors, 12];
                        count = nEQ;
                        for (int o = 0; o < factors_m.GetLength(0); o++)
                        {
                            factors_m[o] = nEQ;
                        }
                        for (int ii = 0; ii < nEQ; ii++)
                        {

                            // batch[ii, 0] = reader1["path_h"];
                            batch[ii, 1] = Hfiles[ii].Max * SF_FEMA;              //Max H
                            batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
                            //batch[ii, 3] = reader1["path_v"];
                            batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
                            batch[ii, 6] = batch_end;
                            batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H
                            if (ii < VfilesNames.Count )
                            {
                                batch[ii, 5] = VfilesNames[ii];    //Name V
                                batch[ii, 8] = Vfiles[ii].Max * SF_FEMA;      //Max V
                                batch[ii, 9] = Vfiles[ii].deltaT;   //Delta V (No need- Delta of H should be same as V)
                                batch[ii, 10] = Vfiles[ii].values.Count; //Line V (No need- Numer of Lines for H should be same as V)

                            }



                        }

                    }


                    scale_f = batch_start;

                    factor_c = 0;
                    Process p = new Process();

                    for (; scale_f <= batch_end; scale_f += batch_inc)
                    {




                        for (int i = 0; i < count; i++)
                        {
                            String path = Var.pp + @"\IDARC_" + xx + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
                            if (System.IO.Directory.Exists(path))
                                System.IO.Directory.Delete(path, true);
                            //  System.Threading.Thread.Sleep(100);


                            System.IO.Directory.CreateDirectory(path);

                           
                            int hLines = 0, vLines = 0;
                            //Copy the Eq files
                            if (i < HfilesNames.Count)
                            {
                                Hfiles[i].writeToFile(path + @"\" + HfilesNames[i], ref hLines);
                            }
                            if (i < VfilesNames.Count)
                            {
                                Vfiles[i].writeToFile(path + @"\" + VfilesNames[i], ref vLines);
                            }


                            String line;

                            results[i, factor_c, 11] = scale_f;


                            List<string> list = new List<string>(Regex.Split(temp_in.Text, "\n"));

                            for (int k = 0; k < list.Count; k++)
                            {
                                if (list[k].Equals(search))
                                {///////////////EDITING MAX_G,LINES,
                                    String edit1 = list[k + 1];
                                    List<string> edit_values1 = new List<string>(Regex.Split(edit1, ","));
                                    edit_values1[0] = Convert.ToString(Convert.ToDecimal(batch[i, 1]) * scale_f); //SF * PGA_H
                                    if (i < VfilesNames.Count )
                                    {
                                        edit_values1[1] = Convert.ToString(Convert.ToDecimal(batch[i, 8]) * scale_f); //SF * PGA_V
                                    }
                                    edit_values1[3] = Convert.ToString(Convert.ToDecimal(batch[i, 2]) * Convert.ToDecimal(edit_values1[2])); //Number of Lines_H

                                    String edit2 = list[k + 3];
                                    List<string> edit_values2 = new List<string>(Regex.Split(edit2, ","));
                                    edit_values2[2] = Convert.ToString(Convert.ToDecimal(batch[i, 2])); //Lines
                                    edit_values2[3] = Convert.ToString(Convert.ToDecimal(batch[i, 7])); //DeltaT

                                    String edit3 = list[k + 5]; //Edit H Name
                                    List<string> edit_values3 = new List<string>(Regex.Split(edit3, ","));
                                    edit_values3[0] = batch[i, 4].ToString();




                                    list[k + 1] = String.Join(",", edit_values1.ToArray());
                                    list[k + 3] = String.Join(",", edit_values2.ToArray());
                                    list[k + 5] = String.Join(",", edit_values3.ToArray());

                                    if (i < VfilesNames.Count ) //Edit V Name
                                    {
                                        String edit4 = list[k + 6];
                                        List<string> edit_values4 = new List<string>(Regex.Split(edit4, ","));
                                        edit_values4[0] = batch[i, 5].ToString();
                                        list[k + 6] = String.Join(",", edit_values4.ToArray());



                                    }

                                    break;
                                }
                            }

                            temp_in.Text = "";
                            for (int k = 0; k < list.Count; k++)
                            {
                                temp_in.Text += list[k] + "\n";
                            }

                            //Run the input file, for loop; until failure.



                            //Run all the files for specific scale factor


                            
                            System.IO.File.Copy(Var.pp + @"\idarc2d_7.0.exe", path + @"\idarc2d_7.0.exe", true);


                           

                            

                            temp_in.SaveFile(path + @"\test.dat", RichTextBoxStreamType.PlainText);
                            System.IO.File.Copy(Var.pp + @"\IDARC.dat", path + @"\IDARC.dat", true);

                            string[] lines = { "test.dat", "test.out" };
                            System.IO.File.WriteAllLines(path + @"\IDARC.dat", lines);

                            // System.Threading.Thread.Sleep(100);
                            //
                            //MessageBox.Show(i.ToString());


                            path = Var.pp + @"\IDARC_" + xx + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
                            ProcessStartInfo startInfo = new ProcessStartInfo(path + @"\idarc2d_7.0.exe");
                            startInfo.WorkingDirectory = path;
                            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                            startInfo.UseShellExecute = false;

                            startInfo.Verb = "runas";
                            p = new Process();
                            p.StartInfo = startInfo;
                            p.Start();
                            p.WaitForExit();
                            path = Var.pp + @"\IDARC_" + xx + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();


                            //Process.Start(path);
                            //Process.Start("notepad.exe", path + @"\test.out");

                            //Reading from the output
                            /////?? add delay
                            while (FileInUse(path + @"\test.out"))
                            {
                                System.Threading.Thread.Sleep(100); //test
                            }
                            String output = System.IO.File.ReadAllText(path + @"\test.out");

                            if (output.Contains("CHOLESKY DECOMPOSITION FAILED"))
                            {
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
                                factors_m[factor_c]--;
                                //List<string> out_list = new List<string>(Regex.Split(output, "\n"));
                                int index1 = output.IndexOf("********** MAXIMUM RESPONSE **********");
                                int index2 = output.IndexOf("********** MAXIMUM FORCES **********");
                                if (index1 == -1 || index2 == -1)
                                    MessageBox.Show("error"); //Need edit



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
                                decimal max_d = 0;
                                decimal max_sd=0;
                                decimal max_ss=0;
                              //  int max_d_i = 0;
                                for (int j = 10; j < 10 + NSO.Value; j++)
                                {
                                    String[] temp_string = edit_out[j].Split(' ');
                                    if (temp_string[0] == "")
                                    {
                                        temp_string = RemoveIndices(temp_string, 0);
                                    }

                                    decimal d = Convert.ToDecimal(temp_string[2]);
                                    decimal sd = Convert.ToDecimal(temp_string[3]);
                                    decimal ss = Convert.ToDecimal(temp_string[1]);


                                    if (d >= max_d)
                                    {
                                        max_d = d;
                                   //     max_d_i = j - 10;
                                    }
                                    if (sd >= max_sd)
                                    {
                                        max_sd = sd;
                                   //     max_d_i = j - 10;
                                    }
                                    if (ss >= max_ss)
                                    {
                                        max_ss = ss;
                                   //     max_d_i = j - 10;
                                    }


                                }

                                results[i, factor_c, 8] = max_d; //Max Drift Ratio
                                results[i, factor_c, 9] = max_sd; //Max Story Drift
                                results[i, factor_c, 10] = max_ss; //Max Story Shear

                            }


                        }
                        //while (factor_c < factors)
                        //{

                        //    results[i, factor_c, 0, 11] = scale_f;
                        //    scale_f += batch_inc;
                        //    //results[i, factor_c, 0, 8] = 0;
                        //    //results[i, factor_c, 0, 9] = 0;
                        //    //results[i, factor_c, 0, 10] = 0;

                        //    factor_c++;
                        //}
                        factor_c++;

                        reader1.Close();
                    }


                
                    cn.Close();

                

                //PLOT
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
                double BB, duct, SSF, Smt, c1, c2, c3, c4, c5;
                BB = duct = SSF = Smt = c1 = c2 = c3 = c4 = c5 = -1;
                if (FEMA_check == 1)
                {
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
                    reader1.Close();
                    cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

                }



                plot t = new plot(ref results, ref batch, ref factors_m, BB, c1, c2, c3, c4, c5, duct, SSF, Smt, FEMA_check);
                t.Show();


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

        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            /////For each analysis
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {


                if (checkedListBox1.GetItemChecked(i))
                {
                    String xx = checkedListBox1.Items[i].ToString();
                    ReadfromDB(xx);
                    DoIDARC(xx);
                }
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about1 a = new about1();
            a.ShowDialog();

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
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;

            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


            cmd.CommandText = "select * from Plot";
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            decimal[, ,] results = Helpers.ObjectFromString(reader["results_t"].ToString()) as decimal[, ,];
            decimal[] factors_m = Helpers.ObjectFromString(reader["factors_t"].ToString()) as decimal[];
            object[,] batch = Helpers.ObjectFromString(reader["batch_t"].ToString()) as object[,];
            reader.Close();
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

            plot t = new plot(ref results, ref batch, ref factors_m, 1, 1, 1, 1, 1, 1, 1, 1, 1,1);
            t.Show();
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            if (batch_options == null)
                batch_options = new Batch_opt();
            batch_options.ShowDialog();
        }


        FEMA_opt FEMA;
        
        private void button33_Click(object sender, EventArgs e)
        {
            if (FEMA == null)
                FEMA = new FEMA_opt(units_post.Checked, Convert.ToDouble( h_post.Text));

            FEMA.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            StreamReader t = new StreamReader(openFileDialog3.FileName);
            load_input.Text = t.ReadToEnd();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            double tempp;
            int tempp_t;
            if(load_input.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Please load input file first ");
                return; 
            }

            if (!Int32.TryParse(NSO_post.Text, out tempp_t))
            {
                MessageBox.Show("Number of Stories input should contain numeric ");
                return;
            }
            if (!Double.TryParse(h_post.Text, out tempp))
            {
                MessageBox.Show("Total Elevation input should contain numeric ");
                return;
            }
            if (!load_input.Text.Contains(batch_template))
            {
                MessageBox.Show("Please Make sure the you have " + batch_template + " in your input content");
                return;
            }
            if (chb_isFEMA.Checked == false)
            {
                if (batch_options == null)
                {
                    batch_options = new Batch_opt();
                    batch_options.ShowDialog();
                }
                if (Directory.Exists(Var.pp + @"\IDARC_BATCH"))
                    Directory.Delete(Var.pp + @"\IDARC_BATCH", true);

                decimal batch_start = batch_options.start.Value;
                int batch_ver = batch_options.IWV.SelectedIndex;
                decimal batch_end = batch_options.end.Value;
                decimal batch_inc = batch_options.inc.Value;
                int count = batch_options.listBox1.Items.Count;
                //String search = Convert.ToString(reader1["textBox46"]);
                //dobue
                //reader1.Close();
                decimal xfactors = ((batch_end - batch_start) / batch_inc);
                if (((batch_end - batch_start) % batch_inc) == 0)
                    xfactors += 1;
                int factors = Convert.ToInt16(xfactors);
                batch = new object[count, 11];

                decimal[, ,] results = new decimal[count, factors, 12];
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




                double dumpDeltaT = 0;
                int kk = 0;
                for (int i = 0; i < batch_options.listBox1.Items.Count; i++)
                {
                    WaveFile wave = (WaveFile)batch_options.listBox1.Items[i];
                    Hfiles.Add(wave);
                    HfilesNames.Add("HFile_" + i + ".dat");
                    wave.getValues(ref dumpDeltaT);
                }

                for (int i = 0; i < batch_options.listBox3.Items.Count; i++)
                {
                    WaveFile wave = (WaveFile)batch_options.listBox3.Items[i];

                    Vfiles.Add(wave);
                    VfilesNames.Add("VFile_" + i + ".dat");
                    wave.getValues(ref dumpDeltaT);

                }


                for (int ii = 0; ii < count; ii++)
                {

                    // batch[ii, 0] = reader1["path_h"];
                    batch[ii, 1] = Hfiles[ii].Max;              //Max H
                    batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
                    //batch[ii, 3] = reader1["path_v"];
                    batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
                    batch[ii, 6] = batch_end;
                    batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H
                    if (ii < VfilesNames.Count)
                    {
                        batch[ii, 5] = VfilesNames[ii];    //Name V
                        batch[ii, 8] = Vfiles[ii].Max;      //Max V
                        batch[ii, 9] = Vfiles[ii].deltaT;   //Delta V (No need- Delta of H should be same as V)
                        batch[ii, 10] = Vfiles[ii].values.Count; //Line V (No need- Numer of Lines for H should be same as V)

                    }
                }




                scale_f = batch_start;

                int factor_c = 0;
                Process p = new Process();

                for (; scale_f <= batch_end; scale_f += batch_inc)
                {



                    //Do u want to include batch_end?

                    for (int i = 0; i < count; i++)
                    {
                        String path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
                        if (System.IO.Directory.Exists(path))
                            System.IO.Directory.Delete(path, true);
                        //  System.Threading.Thread.Sleep(100);


                        System.IO.Directory.CreateDirectory(path);


                        int hLines = 0, vLines = 0;
                        //Copy the Eq files
                        if (i < HfilesNames.Count)
                        {
                            Hfiles[i].writeToFile(path + @"\" + HfilesNames[i], ref hLines);
                        }
                        if (i < VfilesNames.Count)
                        {
                            Vfiles[i].writeToFile(path + @"\" + VfilesNames[i], ref vLines);
                        }


                        String line = "DYNAMIC ANALYSIS CONTROL PARAMETERS\n";
                        line += (Hfiles[i].Max * (double)scale_f) + ",";
                        if (batch_options.listBox3.Enabled)
                            line += (Vfiles[i].Max * (double)scale_f) + ",";
                        else
                            line += "0,";
                        line += batch_options.DTCAL.Text + ",";
                        line += Convert.ToDouble(batch_options.DTCAL.Text) * Hfiles[i].values.Count + ",";
                        line += batch_options.DAMP.Text + ",";
                        line += (batch_options.ITDMP.SelectedIndex + 1) + "\n";
                        line += "INPUT WAVE INFORMATION\n";
                        line += "0,";
                        line += batch_options.IWV.SelectedIndex + ",";
                        line += Hfiles[i].values.Count + ",";
                        line += Hfiles[i].deltaT + "\n";
                        line += "Recorded Table Motion\n";
                        line += HfilesNames[i] + "";
                        if (batch_options.listBox3.Enabled)
                            line += "\n" + VfilesNames[i];

                        results[i, factor_c, 11] = scale_f;

                        System.IO.File.Copy(Var.pp + @"\idarc2d_7.0.exe", path + @"\idarc2d_7.0.exe", true);
                        string text = load_input.Text;
                        text = text.Replace(batch_template, line);
                        text = text.Replace("\n", "\r\n");

                        StreamWriter sw = new StreamWriter(path + @"\test.dat");
                        sw.Write(text);
                        sw.Flush();
                        sw.Close();



                        // temp_in.SaveFile(path + @"\test.dat", RichTextBoxStreamType.PlainText);
                        System.IO.File.Copy(Var.pp + @"\IDARC.dat", path + @"\IDARC.dat", true);

                        string[] lines = { "test.dat", "test.out" };
                        System.IO.File.WriteAllLines(path + @"\IDARC.dat", lines);

                        // System.Threading.Thread.Sleep(100);
                        //
                        //MessageBox.Show(i.ToString());


                        path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
                        ProcessStartInfo startInfo = new ProcessStartInfo(path + @"\idarc2d_7.0.exe");
                        startInfo.WorkingDirectory = path;
                        startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                        startInfo.UseShellExecute = false;

                        startInfo.Verb = "runas";
                        p = new Process();
                        p.StartInfo = startInfo;
                        p.Start();
                        p.WaitForExit();
                        path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();


                        //Process.Start(path);
                        //Process.Start("notepad.exe", path + @"\test.out");

                        //Reading from the output
                        /////?? add delay
                        while (FileInUse(path + @"\test.out"))
                        {
                            System.Threading.Thread.Sleep(100); //test
                        }

                        String output = System.IO.File.ReadAllText(path + @"\test.out");
                        //int nso_i1 = output.IndexOf(" NUMBER OF STORIES ............");
                        //int nso_i2 = output.IndexOf("NUMBER OF FRAMES");
                        //if (nso_i1 == -1 || nso_i2 == -1)
                        //{
                        //    MessageBox.Show("Can't detect Number of stories");
                        //    return; 
                        //}
                        //int nso = Convert.ToInt32(output.Substring(nso_i1 + 33, nso_i2));
                        if (output.Contains("CHOLESKY DECOMPOSITION FAILED"))
                        {
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
                            factors_m[factor_c]--;
                            //List<string> out_list = new List<string>(Regex.Split(output, "\n"));
                            int index1 = output.IndexOf("********** MAXIMUM RESPONSE **********");
                            int index2 = output.IndexOf("********** MAXIMUM FORCES **********");
                            if (index1 == -1 || index2 == -1)
                                MessageBox.Show("error"); //Need edit



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
                            decimal max_d = 0;
                            decimal max_sd = 0;
                            decimal max_ss = 0;
                            //  int max_d_i = 0;
                            for (int j = 10; j < 10 + NSO.Value; j++)
                            {
                                String[] temp_string = edit_out[j].Split(' ');
                                if (temp_string[0] == "")
                                {
                                    temp_string = RemoveIndices(temp_string, 0);
                                }

                                decimal d = Convert.ToDecimal(temp_string[2]);
                                decimal sd = Convert.ToDecimal(temp_string[3]);
                                decimal ss = Convert.ToDecimal(temp_string[1]);


                                if (d >= max_d)
                                {
                                    max_d = d;
                                    //     max_d_i = j - 10;
                                }
                                if (sd >= max_sd)
                                {
                                    max_sd = sd;
                                    //     max_d_i = j - 10;
                                }
                                if (ss >= max_ss)
                                {
                                    max_ss = ss;
                                    //     max_d_i = j - 10;
                                }


                            }

                            results[i, factor_c, 8] = max_d; //Max Drift Ratio
                            results[i, factor_c, 9] = max_sd; //Max Story Drift
                            results[i, factor_c, 10] = max_ss; //Max Story Shear


                        }


                    }
                    //while (factor_c < factors)
                    //{

                    //    results[i, factor_c, 0, 11] = scale_f;
                    //    scale_f += batch_inc;
                    //    //results[i, factor_c, 0, 8] = 0;
                    //    //results[i, factor_c, 0, 9] = 0;
                    //    //results[i, factor_c, 0, 10] = 0;

                    //    factor_c++;
                    //}
                    factor_c++;

                    //  reader1.Close();
                }






                //PLOT
                String results_t = Helpers.ObjectToString(results);
                String batch_t = Helpers.ObjectToString(batch);
                String factors_t = Helpers.ObjectToString(factors_m);




                plot t = new plot(ref results, ref batch, ref factors_m,1,1,1,1,1,1,1,1,1,1);
                t.Show();



            }
            else // FEMA 
            {

                if (Directory.Exists(Var.pp + @"\IDARC_BATCH"))
                    Directory.Delete(Var.pp + @"\IDARC_BATCH", true);

                decimal batch_start = FEMA.start.Value;
                decimal batch_end = FEMA.end.Value;
                decimal batch_inc = FEMA.inc.Value;
                int count = 0;
                //String search = Convert.ToString(reader1["textBox46"]);
                //dobue
                //reader1.Close();
                decimal xfactors = ((batch_end - batch_start) / batch_inc);
                if (((batch_end - batch_start) % batch_inc) == 0)
                    xfactors += 1;
                int factors = Convert.ToInt16(xfactors);
                batch = new object[count, 11];

                decimal[, ,] results = new decimal[count, factors, 12];
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




                double dumpDeltaT = 0;
                int kk = 0;


                double SF_FEMA = 0;
                int nEQ = 0;
                //GET Near_Check, SF(N, F)

                bool Near_check = FEMA.near_check.Checked;
                double SF_N = FEMA.SF_N;
                double SF_F = FEMA.SF_F;
                //ArrayList selected = new ArrayList();
                ArrayList normlized = new ArrayList();
                Hfiles.Clear();
                HfilesNames.Clear();
                Vfiles.Clear();
                VfilesNames.Clear();


                String FEMA_path = Var.pp + @"\FEMA";
                int tt = 0;


                //GET FILE + Create Normilized factors

                if (Near_check) //Near
                {
                    SF_FEMA = SF_N;
                    normlized.AddRange(new double[] { 0.9, 0.96, 1.72, 1.04, 1.63, 1.09, 1.08, 0.77, 0.69, 0.8, 2.79, 0.74, 0.86, 1.08, 0.86, 1.13, 1.99, 1.27, 1.95, 1.15, 1.17, 0.66, 0.77, 1.18, 0.9, 0.78, 0.62, 0.57 });


                    //*!*
                    for (int i = 1; i < 29; i++)
                    {

                        if (FEMA.checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                        {
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
                            wave.getValues(ref dumpDeltaT);
                            wave.values = wave.FEMA_Modify((double)normlized[i - 1]);
                            wave.FEMA_max();

                            Hfiles.Add(wave);
                            HfilesNames.Add("HFile_" + tt + ".dat");


                            WaveFile wave3 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat");            //V
                            wave3.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat";
                            wave3.Header_Lines = 1;
                            wave3.isTimeAndValues = false;
                            wave3.Points_Per_Line = 1;
                            wave3.Prefix_Per_Line = 0;
                            double delta_t3 = 0;
                            wave3.FEMA_Delta(ref delta_t3);
                            wave3.deltaT = delta_t3;
                            wave3.getValues(ref dumpDeltaT);
                            wave3.values = wave3.FEMA_Modify((double)normlized[i - 1]);
                            wave3.FEMA_max();

                            Vfiles.Add(wave3);
                            VfilesNames.Add("VFile_" + tt + ".dat");

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
                            wave2.getValues(ref dumpDeltaT);
                            wave2.values = wave2.FEMA_Modify((double)normlized[i - 1]);
                            wave2.FEMA_max();

                            Hfiles.Add(wave2);
                            HfilesNames.Add("HFile_" + tt + ".dat");

                            WaveFile wave4 = new WaveFile(FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat");            //V
                            wave4.File_Name = FEMA_path + @"\PEER\Near\" + "EQ" + (i).ToString() + "-3.dat";
                            wave4.Header_Lines = 1;
                            wave4.isTimeAndValues = false;
                            wave4.Points_Per_Line = 1;
                            wave4.Prefix_Per_Line = 0;
                            double delta_t4 = 0;
                            wave4.FEMA_Delta(ref delta_t4);
                            wave4.deltaT = delta_t4;
                            wave4.getValues(ref dumpDeltaT);
                            wave4.values = wave4.FEMA_Modify((double)normlized[i - 1]);
                            wave4.FEMA_max();

                            Vfiles.Add(wave4);
                            VfilesNames.Add("VFile_" + tt + ".dat");

                            tt++;



                        }



                    }


                }
                else //FAR
                {
                    SF_FEMA = SF_F;
                    normlized.AddRange(new double[] { 0.65, 0.83, 0.63, 1.09, 1.31, 1.01, 1.03, 1.1, 0.69, 1.36, 0.99, 1.15, 1.09, 0.88, 0.79, 0.87, 1.17, 0.82, 0.41, 0.96, 2.1, 1.44 });

                    for (int i = 1; i < 22; i++)
                    {
                        if (FEMA.checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                        {
                            nEQ += 2;
                            WaveFile wave = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-1.AT2");         //H1
                            wave.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-1.AT2";
                            wave.Header_Lines = 1;
                            wave.isTimeAndValues = false;
                            wave.Points_Per_Line = 1;
                            wave.Prefix_Per_Line = 0;
                            double delta_t = 0;
                            wave.FEMA_Delta(ref delta_t);
                            wave.deltaT = delta_t;
                            wave.getValues(ref dumpDeltaT);
                            wave.values = wave.FEMA_Modify((double)normlized[i - 1]);
                            wave.FEMA_max();

                            Hfiles.Add(wave);
                            HfilesNames.Add("HFile_" + tt + ".dat");


                            WaveFile wave3 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2");            //V
                            wave3.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2";
                            wave3.Header_Lines = 1;
                            wave3.isTimeAndValues = false;
                            wave3.Points_Per_Line = 1;
                            wave3.Prefix_Per_Line = 0;
                            double delta_t3 = 0;
                            wave3.FEMA_Delta(ref delta_t3);
                            wave3.deltaT = delta_t3;
                            wave3.getValues(ref dumpDeltaT);
                            wave3.values = wave3.FEMA_Modify((double)normlized[i - 1]);
                            wave3.FEMA_max();

                            Vfiles.Add(wave3);
                            VfilesNames.Add("VFile_" + tt + ".dat");

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
                            wave2.getValues(ref dumpDeltaT);
                            wave2.values = wave2.FEMA_Modify((double)normlized[i - 1]);
                            wave2.FEMA_max();

                            Hfiles.Add(wave2);
                            HfilesNames.Add("HFile_" + tt + ".dat");

                            WaveFile wave4 = new WaveFile(FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2");            //V
                            wave4.File_Name = FEMA_path + @"\PEER\Far\" + "EQ" + (i).ToString() + "-3.AT2";
                            wave4.Header_Lines = 1;
                            wave4.isTimeAndValues = false;
                            wave4.Points_Per_Line = 1;
                            wave4.Prefix_Per_Line = 0;
                            double delta_t4 = 0;
                            wave4.FEMA_Delta(ref delta_t4);
                            wave4.deltaT = delta_t4;
                            wave4.getValues(ref dumpDeltaT);
                            wave4.values = wave4.FEMA_Modify((double)normlized[i - 1]);
                            wave4.FEMA_max();

                            Vfiles.Add(wave4);
                            VfilesNames.Add("VFile_" + tt + ".dat");

                            tt++;



                        }

                    }

                    batch = new object[nEQ, 11];
                    results = new decimal[nEQ, factors, 12];
                    count = nEQ;
                    for (int o = 0; o < factors_m.GetLength(0); o++)
                    {
                        factors_m[o] = nEQ;
                    }
                    for (int ii = 0; ii < nEQ; ii++)
                    {

                        // batch[ii, 0] = reader1["path_h"];
                        batch[ii, 1] = Hfiles[ii].Max * SF_FEMA;              //Max H
                        batch[ii, 2] = Hfiles[ii].values.Count;     //Lines H
                        //batch[ii, 3] = reader1["path_v"];
                        batch[ii, 4] = HfilesNames[ii];          //Name H (needed in plot)
                        batch[ii, 6] = batch_end;
                        batch[ii, 7] = Hfiles[ii].deltaT;       //Delta H
                        if (ii < VfilesNames.Count)
                        {
                            batch[ii, 5] = VfilesNames[ii];    //Name V
                            batch[ii, 8] = Vfiles[ii].Max * SF_FEMA;      //Max V
                            batch[ii, 9] = Vfiles[ii].deltaT;   //Delta V (No need- Delta of H should be same as V)
                            batch[ii, 10] = Vfiles[ii].values.Count; //Line V (No need- Numer of Lines for H should be same as V)

                        }



                    }

                }


                scale_f = batch_start;

                scale_f = batch_start;

                int factor_c = 0;
                Process p = new Process();

                for (; scale_f <= batch_end; scale_f += batch_inc)
                {



                    //Do u want to include batch_end?

                    for (int i = 0; i < count; i++)
                    {
                        String path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
                        if (System.IO.Directory.Exists(path))
                            System.IO.Directory.Delete(path, true);
                        //  System.Threading.Thread.Sleep(100);


                        System.IO.Directory.CreateDirectory(path);


                        int hLines = 0, vLines = 0;
                        //Copy the Eq files
                        if (i < HfilesNames.Count)
                        {
                            Hfiles[i].writeToFile(path + @"\" + HfilesNames[i], ref hLines);
                        }
                        if (i < VfilesNames.Count)
                        {
                            Vfiles[i].writeToFile(path + @"\" + VfilesNames[i], ref vLines);
                        }


                        String line = "DYNAMIC ANALYSIS CONTROL PARAMETERS\n";
                        line += ((double)batch[i, 1] * (double)scale_f) + ",";

                        line += ((double)batch[i, 8] * (double)scale_f) + ",";

                        line += FEMA.DTCAL.Text + ",";
                        line += Convert.ToDouble(FEMA.DTCAL.Text) * Hfiles[i].values.Count + ",";
                        line += FEMA.DAMP.Text + ",";
                        line += (FEMA.ITDMP.SelectedIndex + 1) + "\n";
                        line += "INPUT WAVE INFORMATION\n";
                        line += "0,";
                        line += "1" + ",";
                        line += Hfiles[i].values.Count + ",";
                        line += Hfiles[i].deltaT + "\n";
                        line += "Recorded Table Motion\n";
                        line += HfilesNames[i] + "";
                        line += "\n" + VfilesNames[i];

                        results[i, factor_c, 11] = scale_f;





                        //Run the input file, for loop; until failure.



                        //Run all the files for specific scale factor



                        System.IO.File.Copy(Var.pp + @"\idarc2d_7.0.exe", path + @"\idarc2d_7.0.exe", true);
                        string text = load_input.Text;
                        text = text.Replace(batch_template, line);
                        text = text.Replace("\n", "\r\n");
                        StreamWriter sw = new StreamWriter(path + @"\test.dat");
                        sw.Write(text);
                        sw.Flush();
                        sw.Close();



                        // temp_in.SaveFile(path + @"\test.dat", RichTextBoxStreamType.PlainText);
                        System.IO.File.Copy(Var.pp + @"\IDARC.dat", path + @"\IDARC.dat", true);

                        string[] lines = { "test.dat", "test.out" };
                        System.IO.File.WriteAllLines(path + @"\IDARC.dat", lines);

                        // System.Threading.Thread.Sleep(100);
                        //
                        //MessageBox.Show(i.ToString());


                        path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();
                        ProcessStartInfo startInfo = new ProcessStartInfo(path + @"\idarc2d_7.0.exe");
                        startInfo.WorkingDirectory = path;
                        startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                        startInfo.UseShellExecute = false;

                        startInfo.Verb = "runas";
                        p = new Process();
                        p.StartInfo = startInfo;
                        p.Start();
                        p.WaitForExit();
                        path = Var.pp + @"\IDARC_BATCH" + @"\IDARC_tempFile_batch_" + i.ToString() + @"\scale_factor_" + scale_f.ToString();


                        //Process.Start(path);
                        //Process.Start("notepad.exe", path + @"\test.out");

                        //Reading from the output
                        /////?? add delay
                        while (FileInUse(path + @"\test.out"))
                        {
                            System.Threading.Thread.Sleep(100); //test
                        }

                        String output = System.IO.File.ReadAllText(path + @"\test.out");
                        //int nso_i1 = output.IndexOf(" NUMBER OF STORIES ............");
                        //int nso_i2 = output.IndexOf("NUMBER OF FRAMES");
                        //if (nso_i1 == -1 || nso_i2 == -1)
                        //{
                        //    MessageBox.Show("Can't detect Number of stories");
                        //    return; 
                        //}
                        //int nso = Convert.ToInt32(output.Substring(nso_i1 + 33, nso_i2));
                        if (output.Contains("CHOLESKY DECOMPOSITION FAILED"))
                        {
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
                            factors_m[factor_c]--;
                            //List<string> out_list = new List<string>(Regex.Split(output, "\n"));
                            int index1 = output.IndexOf("********** MAXIMUM RESPONSE **********");
                            int index2 = output.IndexOf("********** MAXIMUM FORCES **********");
                            if (index1 == -1 || index2 == -1)
                                MessageBox.Show("error"); //Need edit



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
                            decimal max_d = 0;
                            decimal max_sd = 0;
                            decimal max_ss = 0;
                            //  int max_d_i = 0;
                            for (int j = 10; j < 10 + NSO.Value; j++)
                            {
                                String[] temp_string = edit_out[j].Split(' ');
                                if (temp_string[0] == "")
                                {
                                    temp_string = RemoveIndices(temp_string, 0);
                                }

                                decimal d = Convert.ToDecimal(temp_string[2]);
                                decimal sd = Convert.ToDecimal(temp_string[3]);
                                decimal ss = Convert.ToDecimal(temp_string[1]);


                                if (d >= max_d)
                                {
                                    max_d = d;
                                    //     max_d_i = j - 10;
                                }
                                if (sd >= max_sd)
                                {
                                    max_sd = sd;
                                    //     max_d_i = j - 10;
                                }
                                if (ss >= max_ss)
                                {
                                    max_ss = ss;
                                    //     max_d_i = j - 10;
                                }


                            }

                            results[i, factor_c, 8] = max_d; //Max Drift Ratio
                            results[i, factor_c, 9] = max_sd; //Max Story Drift
                            results[i, factor_c, 10] = max_ss; //Max Story Shear


                        }


                    }
                    //while (factor_c < factors)
                    //{

                    //    results[i, factor_c, 0, 11] = scale_f;
                    //    scale_f += batch_inc;
                    //    //results[i, factor_c, 0, 8] = 0;
                    //    //results[i, factor_c, 0, 9] = 0;
                    //    //results[i, factor_c, 0, 10] = 0;

                    //    factor_c++;
                    //}
                    factor_c++;

                    //  reader1.Close();
                }






                //PLOT
                String results_t = Helpers.ObjectToString(results);
                String batch_t = Helpers.ObjectToString(batch);
                String factors_t = Helpers.ObjectToString(factors_m);




                plot t = new plot(ref results, ref batch, ref factors_m,1,1,1,1,1,1,1,1,1,1);
                t.Show();

            }
               




        }
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

        private void btn_batch_example_Click(object sender, EventArgs e)
        {
            WaveBatchExample wvb = new WaveBatchExample();
            wvb.ShowDialog();
        }

        private void wizardPage4_Click(object sender, EventArgs e)
        {

        }





    }
}

