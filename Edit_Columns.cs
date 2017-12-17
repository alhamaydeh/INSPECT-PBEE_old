using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
namespace SampleWizard
{

    public partial class Edit_Columns : Form
    {
        decimal total;
        //int i = 0;
        public Edit_Columns()
        {
            InitializeComponent();
        }
        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public Edit_Columns(decimal a)
        {
            InitializeComponent();
        //    dataGridView1 = b;
            total = a;
            int size1 = Convert.ToInt32(total);
       //     dataGridView1.RowCount = size1;
      //      this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
      //      this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;


        }
        private void Add_Columns_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From Columns", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];


            ICTYPE.DataBindings.Add(new Binding("SelectedIndex", bs, "ICTYPE"));
            AN.DataBindings.Add(new Binding("Text", bs, "AN"));
            ANY.DataBindings.Add(new Binding("Text", bs, "ANYY"));
            ANB.DataBindings.Add(new Binding("Text", bs, "ANB"));
            AMLC.DataBindings.Add(new Binding("Text", bs, "AMLC"));
            RAMC1.DataBindings.Add(new Binding("Text", bs, "RAMC1"));
            RAMC2.DataBindings.Add(new Binding("Text", bs, "RAMC2"));
            KHYSC.DataBindings.Add(new Binding("Text", bs, "KHYSC"));
            EI.DataBindings.Add(new Binding("Text", bs, "EI"));
            EA.DataBindings.Add(new Binding("Text", bs, "EA"));
            PCP.DataBindings.Add(new Binding("Text", bs, "PCP"));
            PYP.DataBindings.Add(new Binding("Text", bs, "PYP"));
            UYP.DataBindings.Add(new Binding("Text", bs, "UYP"));
            UUP.DataBindings.Add(new Binding("Text", bs, "UUP"));
            EI3P.DataBindings.Add(new Binding("Text", bs, "EI3P"));
            PCN.DataBindings.Add(new Binding("Text", bs, "PCN"));
            PYN.DataBindings.Add(new Binding("Text", bs, "PYN"));
            UYN.DataBindings.Add(new Binding("Text", bs, "UYN"));
            UUN.DataBindings.Add(new Binding("Text", bs, "UUN"));
            EI3N.DataBindings.Add(new Binding("Text", bs, "EI3N"));

            KHYSC_t.DataBindings.Add(new Binding("Text", bs, "KHYSC_t"));
            EI_t.DataBindings.Add(new Binding("Text", bs, "EI_t"));
            EA_t.DataBindings.Add(new Binding("Text", bs, "EA_t"));
            PCP_t.DataBindings.Add(new Binding("Text", bs, "PCP_t"));
            PYP_t.DataBindings.Add(new Binding("Text", bs, "PYP_t"));
            UYP_t.DataBindings.Add(new Binding("Text", bs, "UYP_t"));
            UUP_t.DataBindings.Add(new Binding("Text", bs, "UUP_t"));
            EI3P_t.DataBindings.Add(new Binding("Text", bs, "EI3P_t"));
            PCN_t.DataBindings.Add(new Binding("Text", bs, "PCN_t"));
            PYN_t.DataBindings.Add(new Binding("Text", bs, "PYN_t"));
            UYN_t.DataBindings.Add(new Binding("Text", bs, "UYN_t"));
            UUN_t.DataBindings.Add(new Binding("Text", bs, "UUN_t"));
            EI3N_t.DataBindings.Add(new Binding("Text", bs, "EI3N_t"));

            KHYSC_1.DataBindings.Add(new Binding("Text", bs, "KHYSC_1"));
            GA_1.DataBindings.Add(new Binding("Text", bs, "GA_1"));
            PCP_1.DataBindings.Add(new Binding("Text", bs, "PCP_1"));
            PYP_1.DataBindings.Add(new Binding("Text", bs, "PYP_1"));
            UYP_1.DataBindings.Add(new Binding("Text", bs, "UYP_1"));
            UUP_1.DataBindings.Add(new Binding("Text", bs, "UUP_1"));
            EI3P_1.DataBindings.Add(new Binding("Text", bs, "EI3P_1"));
            PCN_1.DataBindings.Add(new Binding("Text", bs, "PCN_1"));
            PYN_1.DataBindings.Add(new Binding("Text", bs, "PYN_1"));
            UYN_1.DataBindings.Add(new Binding("Text", bs, "UYN_1"));
            UUN_1.DataBindings.Add(new Binding("Text", bs, "UUN_1"));
            EI3N_1.DataBindings.Add(new Binding("Text", bs, "EI3N_1"));
            AN_2.DataBindings.Add(new Binding("Text", bs, "AN_2"));
            ANY_2.DataBindings.Add(new Binding("Text", bs, "ANY_2"));
            ANB_2.DataBindings.Add(new Binding("Text", bs, "ANB_2"));
            AMLC_2.DataBindings.Add(new Binding("Text", bs, "AMLC_2"));
            RAMC1_2.DataBindings.Add(new Binding("Text", bs, "RAMC1_2"));
            RAMC2_2.DataBindings.Add(new Binding("Text", bs, "RAMC2_2"));
            NEV_2.DataBindings.Add(new Binding("YesNo", bs, "NEV_2"));
            
            KHYSC_2.DataBindings.Add(new Binding("Text", bs, "KHYSC_2"));
            EI_2.DataBindings.Add(new Binding("Text", bs, "EI_2"));
            EA_2.DataBindings.Add(new Binding("Text", bs, "EA_2"));
            PCP_2.DataBindings.Add(new Binding("Text", bs, "PCP_2"));
            PYP_2.DataBindings.Add(new Binding("Text", bs, "PYP_2"));
            UYP_2.DataBindings.Add(new Binding("Text", bs, "UYP_2"));
            UNSP_2.DataBindings.Add(new Binding("Text", bs, "UNSP_2"));
            ULP_2.DataBindings.Add(new Binding("Text", bs, "ULP_2"));
            EI3P_2.DataBindings.Add(new Binding("Text", bs, "EI3P_2"));
            PCN_2.DataBindings.Add(new Binding("Text", bs, "PCN_2"));
            PYN_2.DataBindings.Add(new Binding("Text", bs, "PYN_2"));
            UYN_2.DataBindings.Add(new Binding("Text", bs, "UYN_2"));
            UNSN_2.DataBindings.Add(new Binding("Text", bs, "UNSN_2"));
            ULN_2.DataBindings.Add(new Binding("Text", bs, "ULN_2"));
            EI3N_2.DataBindings.Add(new Binding("Text", bs, "EI3N_2"));
            UUP_2.DataBindings.Add(new Binding("Text", bs, "UUP_2"));
            UUN_2.DataBindings.Add(new Binding("Text", bs, "UUN_2"));



            KHYSC_2_t.DataBindings.Add(new Binding("Text", bs, "KHYSC_2_t"));
            EI_2_t.DataBindings.Add(new Binding("Text", bs, "EI_2_t"));
            EA_2_t.DataBindings.Add(new Binding("Text", bs, "EA_2_t"));
            PCP_2_t.DataBindings.Add(new Binding("Text", bs, "PCP_2_t"));
            PYP_2_t.DataBindings.Add(new Binding("Text", bs, "PYP_2_t"));
            UYP_2_t.DataBindings.Add(new Binding("Text", bs, "UYP_2_t"));
            UNSP_2_t.DataBindings.Add(new Binding("Text", bs, "UNSP_2_t"));
            ULP_2_t.DataBindings.Add(new Binding("Text", bs, "ULP_2_t"));
            EI3P_2_t.DataBindings.Add(new Binding("Text", bs, "EI3P_2_t"));
            PCN_2_t.DataBindings.Add(new Binding("Text", bs, "PCN_2_t"));
            PYN_2_t.DataBindings.Add(new Binding("Text", bs, "PYN_2_t"));
            UYN_2_t.DataBindings.Add(new Binding("Text", bs, "UYN_2_t"));
            UNSN_2_t.DataBindings.Add(new Binding("Text", bs, "UNSN_2_t"));
            ULN_2_t.DataBindings.Add(new Binding("Text", bs, "ULN_2_t"));
            EI3N_2_t.DataBindings.Add(new Binding("Text", bs, "EI3N_2_t"));
            UUP_2_t.DataBindings.Add(new Binding("Text", bs, "UUP_2_t"));
            UUN_2_t.DataBindings.Add(new Binding("Text", bs, "UUN_2_t"));





            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 
            label6.Text = "Column Type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
                
        }



        private void ICTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ICTYPE.SelectedIndex == 0)
            {
                groupBox1.Visible= true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }
            if (ICTYPE.SelectedIndex == 1)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
            if (ICTYPE.SelectedIndex == 2)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
            }

        }


        private void NEV_2_CheckedChanged(object sender, EventArgs e)
        {
            if (NEV_2.Checked)
            {
                groupBox6.Visible = true;
                groupBox12.Visible = true;
                groupBox7.Visible = false;
                groupBox11.Visible = false;

            }
            else
                radioButton1.Checked = true;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox6.Visible = false;
                groupBox12.Visible = false;
                groupBox7.Visible = true;
                groupBox11.Visible = true;
            }
        }

        private void button_23_Click_1(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Column Type Number:   " + (bs.Position + 1) + " of  " + total.ToString();

            if (button_23.Text == "Finish")
            {
                this.bs.EndEdit();
              //  SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
               // da.AcceptChangesDuringUpdate = true;
                ///this.da.Update(ds.Tables[0]);
                SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
                mySQLiteCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges;

                mySQLiteCommandBuilder.GetUpdateCommand();
                da.UpdateCommand = mySQLiteCommandBuilder.GetUpdateCommand();
                this.da.Update(ds.Tables[0]);
                this.Close();
            }
            if (bs.Position + 1 == total)
                button_23.Text = "Finish";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            label6.Text = "Column Type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";
        }

        private void KHYSC_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(KHYSC.Text, out number) == true)
            {
                if (Convert.ToDecimal(KHYSC.Text) >= 0.0M)
                {
                    groupBox9.Enabled = true;
                }
                else
                    groupBox9.Enabled = false;
            }
        }

        private void KHYSC_2_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(KHYSC_2.Text, out number) == true)
            {
                if (Convert.ToDecimal(KHYSC_2.Text) >= 0.0M)
                {
                    groupBox10.Enabled = true;
                    groupBox11.Enabled = true;
                    groupBox12.Enabled = true;
                }
                else
                {
                    groupBox10.Enabled = false;
                    groupBox11.Enabled = false;
                    groupBox12.Enabled = false;
                }
            }
        }

        private void NEV_2_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=21=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=24=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.bs.EndEdit();
            SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
            this.da.Update(ds.Tables[0]);
            this.Close();
        }
        private void updateAll(string column, double value)
        {
            RangeSelector rng = new RangeSelector(ds.Tables[0].Rows.Count, "Select range of " + column + " to be changed [1-" + ds.Tables[0].Rows.Count);
            if (rng.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (rng.SelectedRange.Contains(Convert.ToInt32(ds.Tables[0].Rows[i][0])))
                    {
                        ds.Tables[0].Rows[i][column] = Convert.ToDouble(value);
                    }
                }
            }
        }

        private void btn_setRange(object sender, EventArgs e)
        {
            string prop = ((Control)sender).Name;
            prop = prop.Replace("btn_setAll_", "");
            Control[] c = this.Controls.Find(prop, true);
            if (c.Length != 1)
            {
                MessageBox.Show("Can't Find Control [" + prop + "]");
                return;
            }
            updateAll(c[0].Name, Convert.ToDouble(c[0].Text));
        }

        private void btn_setlAll_NEV_2_Click(object sender, EventArgs e)
        {
            updateAll("NEV_2", Convert.ToDouble(NEV_2.Checked));
        }


        }
    }
