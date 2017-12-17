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

    public partial class Edit_REINFORCEMENT : Form
    {
        decimal total;
        //int i = 0;
        public Edit_REINFORCEMENT()
        {
            InitializeComponent();
        }
        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public Edit_REINFORCEMENT(decimal a)
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
        private void Add_REINFORCEMENT_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery();
            da.SelectCommand = new SQLiteCommand("Select * From REINFORCEMENT", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];


            FS.DataBindings.Add(new Binding("Text", bs, "FS"));
            FSU.DataBindings.Add(new Binding("Text", bs, "FSU"));
            ES.DataBindings.Add(new Binding("Text", bs, "ES"));
            ESH.DataBindings.Add(new Binding("Text", bs, "ESH"));
            EPSH.DataBindings.Add(new Binding("Text", bs, "EPSH"));
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close(); 
            label6.Text = "Steel type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
                
        }



     
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                decimal temp = Convert.ToDecimal(FS.Text) * 1.4M;
                FSU.Text = temp.ToString();
                FSU.ReadOnly = true;
            }
            else
                FSU.ReadOnly = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                decimal temp = 29000;
                ES.Text = temp.ToString();
                ES.ReadOnly = true;
            }
            else
                ES.ReadOnly = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                decimal temp = Convert.ToDecimal(ES.Text) / 60;
                ESH.Text = temp.ToString();
                ESH.ReadOnly = true;
            }
            else
                ESH.ReadOnly = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                decimal temp = 3.0M;
                EPSH.Text = temp.ToString();
                EPSH.ReadOnly = true;
            }
            else EPSH.ReadOnly = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Steel type Number:   " + (bs.Position + 1) + " of  " + total.ToString();

            if (button2.Text == "Finish")
            {
                this.bs.EndEdit();
                SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
                this.da.Update(ds.Tables[0]);
                this.Close();
            }
            if (bs.Position + 1 == total)
                button2.Text = "Finish";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            label6.Text = "Steel type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button2.Text = "Next";
        }

        private void button3_Click(object sender, EventArgs e)
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
