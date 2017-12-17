using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SampleWizard
{

    public partial class Edit_MASONRY : Form
    {
        decimal total;
        //int i = 0;
        public Edit_MASONRY()
        {
            InitializeComponent();
        }

        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public Edit_MASONRY(decimal a)
        {
            InitializeComponent();

            total = a;
            int size1 = Convert.ToInt32(total);
        //    dataGridView1.RowCount = size1;
         //   this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
          //  this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;


            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;

        }
        private void Add_MASONRY_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From MASONRY", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];
            FM.DataBindings.Add(new Binding("Text", bs, "FM"));
            FMCR.DataBindings.Add(new Binding("Text", bs, "FMCR"));
            EPSM.DataBindings.Add(new Binding("Text", bs, "EPSM"));
            VM.DataBindings.Add(new Binding("Text", bs, "VM"));
            SIGMM.DataBindings.Add(new Binding("Text", bs, "SIGMM"));
            CFM.DataBindings.Add(new Binding("Text", bs, "CFM"));

            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 
            label6.Text = "Masonry type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
                
        }





        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                decimal temp = 3.0M;
                CFM.Text = temp.ToString();
                CFM.ReadOnly = true;
            }
            else CFM.ReadOnly = false;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                decimal temp = Convert.ToDecimal(FM.Text) * 0.05M;
                SIGMM.Text = temp.ToString();
                SIGMM.ReadOnly = true;
            }
            else SIGMM.ReadOnly = false;

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                decimal temp = Convert.ToDecimal(FM.Text) * 0.05M;
                FMCR.Text = temp.ToString();
                FMCR.ReadOnly = true;
            }
            else FMCR.ReadOnly = false;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                decimal temp = 0.2M;
                EPSM.Text = temp.ToString();
                EPSM.ReadOnly = true;
            }
            else EPSM.ReadOnly = false;
        }





        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                decimal temp = 0.04M;
                VM.Text = temp.ToString();
                VM.ReadOnly = true;
            }
            else VM.ReadOnly = false;
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

        private void button_23_Click_1(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Masonry type Number:   " + (bs.Position + 1) + " of  " + total.ToString();

     
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
            label6.Text = "Masonry type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";
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
