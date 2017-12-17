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

    public partial class Edit_Shear_2 : Form
    {
        decimal total;
     //   int i = 0;
        public Edit_Shear_2()
        {
            InitializeComponent();
        }
        //DataGridView dataGridView1;

        public Edit_Shear_2(decimal a)
        {
            InitializeComponent();
        //    dataGridView1 = b;
            total = a;
            int size1 = Convert.ToInt32(total);
         //   dataGridView1.RowCount = size1;
        //    this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
         //   this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;


        }
        SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        private void Add_Columns_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From Shear_2", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];


            AMLW.DataBindings.Add(new Binding("Text", bs, "AMLW"));
            EAW.DataBindings.Add(new Binding("Text", bs, "EAW"));

            KHYSW_1.DataBindings.Add(new Binding("Text", bs, "KHYSW_1"));
            EI_1.DataBindings.Add(new Binding("Text", bs, "EI_1"));
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

            KHYSW_2.DataBindings.Add(new Binding("Text", bs, "KHYSW_2"));
            GA_2.DataBindings.Add(new Binding("Text", bs, "GA_2"));
            PCP_2.DataBindings.Add(new Binding("Text", bs, "PCP_2"));
            PYP_2.DataBindings.Add(new Binding("Text", bs, "PYP_2"));
            UYP_2.DataBindings.Add(new Binding("Text", bs, "UYP_2"));
            UUP_2.DataBindings.Add(new Binding("Text", bs, "UUP_2"));
            GA3P_2.DataBindings.Add(new Binding("Text", bs, "GA3P_2"));
            PCN_2.DataBindings.Add(new Binding("Text", bs, "PCN_2"));
            PYN_2.DataBindings.Add(new Binding("Text", bs, "PYN_2"));
            UYN_2.DataBindings.Add(new Binding("Text", bs, "UYN_2"));
            UUN_2.DataBindings.Add(new Binding("Text", bs, "UUN_2"));
            GA3N_2.DataBindings.Add(new Binding("Text", bs, "GA3N_2"));




            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 

            label6.Text = "Shear wall type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
                
        }



        private void button_23_Click_1(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Shear wall type Number:   " + (bs.Position + 1) + " of  " + total.ToString();

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

        private void button2_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            label6.Text = "Shear wall type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";
        }

        private void button1_Click(object sender, EventArgs e)
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
