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

    public partial class Edit_Concrete : Form
    {
        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();

        

        BindingSource bs = new BindingSource();
        
        decimal total;
        //int i = 0;
        public Edit_Concrete()
        {
            
            InitializeComponent();
        }


        public Edit_Concrete(decimal a)
        {
            InitializeComponent();
            total = a;
            int size1 = Convert.ToInt32(total);
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;

        }
        private void Add_Concrete_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From concrete", cn);
            ds.Clear();
           da.Fill(ds);
            bs.DataSource = ds.Tables[0];
            FC.DataBindings.Add(new Binding("Text", bs, "FC"));
            EC.DataBindings.Add(new Binding("Text", bs, "EC"));
            EPS0.DataBindings.Add(new Binding("Text", bs, "EPS0"));
            EPSU.DataBindings.Add(new Binding("Text", bs, "EPSU"));
            FT.DataBindings.Add(new Binding("Text", bs, "FT"));
            ZF.DataBindings.Add(new Binding("Text", bs, "ZF"));
            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 

            label6.Text = "Concrete property type Number:   " + (bs.Position +1) +" of  " + total.ToString(); 
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            bs.MovePrevious();
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            label6.Text = "Concrete property type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";
        }
        private void button_23_Click(object sender, EventArgs e)
        {
            
            bs.MoveNext();
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            label6.Text = "Concrete property type Number:   " + (bs.Position + 1) + " of  " + total.ToString();

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

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                decimal temp = Convert.ToDecimal(FC.Text) * 0.12M;
                FT.Text = temp.ToString();
                FT.ReadOnly = true;
            }
            else FT.ReadOnly = false;


        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                decimal temp = 0.2M;
                EPS0.Text = temp.ToString();
                EPS0.ReadOnly = true;
            }
            else EPS0.ReadOnly = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked)
            {

                decimal temp = 57M * (decimal) Math.Sqrt(Convert.ToDouble(FC.Text) * 1000);
                EC.Text = temp.ToString();
                EC.ReadOnly = true;
            }
            else
                EC.ReadOnly = false;
        }



        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
                    }

        private void NEV_2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void FC_TextChanged(object sender, EventArgs e)
        {
            check_decimal(FC);
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

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dg_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (e.Column.Index == 0)
                e.Column.Visible = true;
            else
                e.Column.Visible = false;
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
