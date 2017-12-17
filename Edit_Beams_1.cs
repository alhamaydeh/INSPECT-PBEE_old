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

    public partial class Edit_Beams_1 : Form
    {
        decimal total;
        //int i = 0;
        public Edit_Beams_1()
        {
            InitializeComponent();
        }
        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public Edit_Beams_1(decimal a)
        {
            InitializeComponent();
        //    dataGridView1 = b;
            total = a;
            int size1 = Convert.ToInt32(total);
      //      dataGridView1.RowCount = size1;
       //     this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
     //       this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;


            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;

        }
        private void Add_Columns_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From Beams_1", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];
            IMC.DataBindings.Add(new Binding("Text", bs, "IMC"));
            ICTYPE.DataBindings.Add(new Binding("SelectedIndex", bs, "ICTYPE"));
            IMS.DataBindings.Add(new Binding("Text", bs, "IMS"));
            AMLB.DataBindings.Add(new Binding("Text", bs, "AMLB"));
            RAMB1.DataBindings.Add(new Binding("Text", bs, "RAMB1"));
            RAMB2.DataBindings.Add(new Binding("Text", bs, "RAMB2"));
            KHYSB.DataBindings.Add(new Binding("Text", bs, "KHYSB"));
            D.DataBindings.Add(new Binding("Text", bs, "D"));
            B.DataBindings.Add(new Binding("Text", bs, "B"));
            BSL.DataBindings.Add(new Binding("Text", bs, "BSL"));
            TSL.DataBindings.Add(new Binding("Text", bs, "TSL"));
            BC.DataBindings.Add(new Binding("Text", bs, "BC"));
            AT1.DataBindings.Add(new Binding("Text", bs, "AT1"));
            AT2.DataBindings.Add(new Binding("Text", bs, "AT2"));
            HBD.DataBindings.Add(new Binding("Text", bs, "HBD"));
            HBS.DataBindings.Add(new Binding("Text", bs, "HBS"));

            KHYSB_t.DataBindings.Add(new Binding("Text", bs, "KHYSB_t"));
            D_t.DataBindings.Add(new Binding("Text", bs, "D_t"));
            B_t.DataBindings.Add(new Binding("Text", bs, "B_t"));
            BSL_t.DataBindings.Add(new Binding("Text", bs, "BSL_t"));
            TSL_t.DataBindings.Add(new Binding("Text", bs, "TSL_t"));
            BC_t.DataBindings.Add(new Binding("Text", bs, "BC_t"));
            AT1_t.DataBindings.Add(new Binding("Text", bs, "AT1_t"));
            AT2_t.DataBindings.Add(new Binding("Text", bs, "AT2_t"));
            HBD_t.DataBindings.Add(new Binding("Text", bs, "HBD_t"));
            HBS_t.DataBindings.Add(new Binding("Text", bs, "HBS_t"));

            KHYSB_1.DataBindings.Add(new Binding("Text", bs, "KHYSB_1"));
            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 
            label6.Text = "Beam type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
                
        }


        private void ICTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ICTYPE.SelectedIndex == 0)
            {
                groupBox1.Visible= true;
                groupBox2.Visible = false;

            }
            if (ICTYPE.SelectedIndex == 1)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;

            }


        }


        private void button_23_Click_1(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Beam type Number:   " + (bs.Position + 1) + " of  " + total.ToString();

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
            label6.Text = "Beam type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";
        }

        private void HBS_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void KHYSB_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(KHYSB.Text, out number) == true)
            {
                if (Convert.ToDecimal(KHYSB.Text) >= 0.0M)
                {
                    groupBox3.Enabled = true;
                }
                else
                    groupBox3.Enabled = false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=27=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
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
