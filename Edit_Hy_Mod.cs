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

    public partial class Edit_Hy_Mod : Form
    {
        decimal total;
        //int i = 0;
        public Edit_Hy_Mod()
        {
            InitializeComponent();
        }

        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public Edit_Hy_Mod(decimal a)
        {
            InitializeComponent();

            total = a;
            int size1 = Convert.ToInt32(total);

            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;
        }
        private void Add_Hy_Mod_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From Hysteretic_1", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];

            HC.DataBindings.Add(new Binding("Text", bs, "HC"));
            Ty.DataBindings.Add(new Binding("SelectedIndex",bs,"Ty"));
            HBD.DataBindings.Add(new Binding("Text", bs, "HBD"));
            HBE.DataBindings.Add(new Binding("Text", bs, "HBE"));
            HS.DataBindings.Add(new Binding("Text", bs, "HS"));
            IBILINEAR.DataBindings.Add(new Binding("SelectedIndex", bs, "IBILINEAR"));
            NTRANS.DataBindings.Add(new Binding("Text", bs, "NTRANS"));
            ETA.DataBindings.Add(new Binding("Text", bs, "ETA"));
            HSR.DataBindings.Add(new Binding("Text", bs, "HSR"));
            HSS.DataBindings.Add(new Binding("Text", bs, "HSS"));
            HSM.DataBindings.Add(new Binding("Text", bs, "HSM"));
            NGAP.DataBindings.Add(new Binding("Text", bs, "NGAP"));
            PHIGAP.DataBindings.Add(new Binding("Text", bs, "PHIGAP"));
            STIFFGAP.DataBindings.Add(new Binding("Text", bs, "STIFFGAP"));
            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 
            label6.Text = "Hysteretic Rule Number:   " + (bs.Position + 1) + " of  " + total.ToString();
        }


        private void button_23_Click_1(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Hysteretic Rule Number:   " + (bs.Position + 1) + " of  " + total.ToString();

            if (button_23.Text == "Finish")
            {
                this.bs.EndEdit();
                SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
                this.da.Update(ds.Tables[0]);
                this.Close();
            }
            if (bs.Position + 1 == total)
                button_23.Text = "Finish";

            checkBox1.Checked = false;
            checkBox10.Checked = false;
            checkBox12.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            label6.Text = "Hysteretic Rule Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";

        }

        private void Ty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ty.SelectedIndex == 0)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            if (Ty.SelectedIndex == 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                HC.Text = "200";
             HC.ReadOnly=true;
            }
            else
                HC.ReadOnly=false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                HBD.Text = "0.01";
                HBD.ReadOnly = true;
            }
            else
                HBD.ReadOnly = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                HBE.Text = "0.01";
                HBE.ReadOnly = true;
            }
            else
                HBE.ReadOnly = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
                        if (checkBox4.Checked)
            {
                HS.Text = "1.0";
                HS.ReadOnly = true;
            }
            else
                HS.ReadOnly = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
                    if (checkBox7.Checked)
            {
                NTRANS.Text = "10";
                NTRANS.ReadOnly = true;
            }
            else
                        NTRANS.ReadOnly = false;
        }

         private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
                    if (checkBox6.Checked)
                    {
                        ETA.Text = "0.5";
                        ETA.ReadOnly = true;
                    }
                    else
                        ETA.ReadOnly = false;
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
                    if (checkBox10.Checked)
            {
                HSS.Text = "100";
                HSS.ReadOnly = true;
            }
            else
                        HSS.ReadOnly = false;
        }



        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
                    if (checkBox12.Checked)
            {
                PHIGAP.Text = "1000";
                PHIGAP.ReadOnly = true;
            }
            else
                        PHIGAP.ReadOnly = false;
        }

        private void IBILINEAR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IBILINEAR.SelectedIndex == 3)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
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

        private void btn_IBILINEAR_Click(object sender, EventArgs e)
        {
            updateAll("IBILINEAR", Convert.ToDouble(IBILINEAR.SelectedIndex));
        }
        
    }

        
}
   
