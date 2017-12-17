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

    public partial class Edit_Columns_1 : Form
    {
        decimal total;
        //int i = 0;
        public Edit_Columns_1()
        {
            InitializeComponent();
        }
        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public Edit_Columns_1(decimal a)
        {
            InitializeComponent();
        //    dataGridView1 = b;
            total = a;
            int size1 = Convert.ToInt32(total);
       //     dataGridView1.RowCount = size1;
        //    this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
       //     this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;



            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;
        }
        private void Add_Columns_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From Columns_1", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];


            ICTYPE.DataBindings.Add(new Binding("SelectedIndex", bs, "ICTYPE"));

            IMC.DataBindings.Add(new Binding("Text", bs, "IMC"));
            IMS.DataBindings.Add(new Binding("Text", bs, "IMS"));
            AN.DataBindings.Add(new Binding("Text", bs, "AN"));
            AMLC.DataBindings.Add(new Binding("Text", bs, "AMLC"));
            RAMC1.DataBindings.Add(new Binding("Text", bs, "RAMC1"));
            RAMC2.DataBindings.Add(new Binding("Text", bs, "RAMC2"));
            KHYSC.DataBindings.Add(new Binding("Text", bs, "KHYSC"));
            D.DataBindings.Add(new Binding("Text", bs, "D"));
            B.DataBindings.Add(new Binding("Text", bs, "B"));
            DC.DataBindings.Add(new Binding("Text", bs, "DC"));
            AT.DataBindings.Add(new Binding("Text", bs, "AT"));
            HBD.DataBindings.Add(new Binding("Text", bs, "HBD"));
            HBS.DataBindings.Add(new Binding("Text", bs, "HBS"));
            CEF.DataBindings.Add(new Binding("Text", bs, "CEF"));
            KHYSC_t.DataBindings.Add(new Binding("Text", bs, "KHYSC_t"));
            D_t.DataBindings.Add(new Binding("Text", bs, "D_t"));
            B_t.DataBindings.Add(new Binding("Text", bs, "B_t"));
            DC_t.DataBindings.Add(new Binding("Text", bs, "DC_t"));
            AT_t.DataBindings.Add(new Binding("Text", bs, "AT_t"));
            HBD_t.DataBindings.Add(new Binding("Text", bs, "HBD_t"));
            HBS_t.DataBindings.Add(new Binding("Text", bs, "HBS_t"));
            CEF_t.DataBindings.Add(new Binding("Text", bs, "CEF_t"));
            KHYSC_1.DataBindings.Add(new Binding("Text", bs, "KHYSC_1"));
            IMC_2.DataBindings.Add(new Binding("Text", bs, "IMC_2"));
            IMS_2.DataBindings.Add(new Binding("Text", bs, "IMS_2"));
            KHYSC_2.DataBindings.Add(new Binding("Text", bs, "KHYSC_2"));
            AMLC_2.DataBindings.Add(new Binding("Text", bs, "AMLC_2"));
            RAMC1_2.DataBindings.Add(new Binding("Text", bs, "RAMC1_2"));
            RAMC2_2.DataBindings.Add(new Binding("Text", bs, "RAMC2_2"));
            AN_2.DataBindings.Add(new Binding("Text", bs, "AN_2"));
            DO_2.DataBindings.Add(new Binding("Text", bs, "DO_2"));
            CVR_2.DataBindings.Add(new Binding("Text", bs, "CVR_2"));
            DST_2.DataBindings.Add(new Binding("Text", bs, "DST_2"));
            NBAR_2.DataBindings.Add(new Binding("Text", bs, "NBAR_2"));
            BDIA_2.DataBindings.Add(new Binding("Text", bs, "BDIA_2"));
            HBD_2.DataBindings.Add(new Binding("Text", bs, "HBD_2"));
            HBS_2.DataBindings.Add(new Binding("Text", bs, "HBS_2"));

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


        private void button_23_Click_1(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Column Type Number:   " + (bs.Position + 1) + " of  " + total.ToString();

            if (button_23.Text == "Finish")
            {
                this.bs.EndEdit();
                SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
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
                    groupBox6.Enabled = true;
                }
                else
                    groupBox6.Enabled = false;
            }
        }

        private void KHYSC_Leave(object sender, EventArgs e)
        {

        }

        private void KHYSC_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=16=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
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
            prop = prop.Replace("btn_", "");
            Control[] c = this.Controls.Find(prop, true);
            if (c.Length != 1)
            {
                MessageBox.Show("Can't Find Control [" + prop + "]");
                return;
            }
            updateAll(c[0].Name, Convert.ToDouble(c[0].Text));
        }


        }
    }
