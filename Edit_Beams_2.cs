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

    public partial class Edit_Beams_2 : Form
    {
        decimal total;
        //int i = 0;
        public Edit_Beams_2()
        {
            InitializeComponent();
        }
        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();


        public Edit_Beams_2(decimal a)
        {
            InitializeComponent();
       //     dataGridView1 = b;
            total = a;
            int size1 = Convert.ToInt32(total);
     //       dataGridView1.RowCount = size1;
       //     this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
       //     this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;


            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;

        }
        private void Add_Columns_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From Beams_2", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];

            ICTYPE.DataBindings.Add(new Binding("SelectedIndex", bs, "ICTYPE"));
            AMLB.DataBindings.Add(new Binding("Text", bs, "AMLB"));
            RAMB1.DataBindings.Add(new Binding("Text", bs, "RAMB1"));
            RAMB2.DataBindings.Add(new Binding("Text", bs, "RAMB2"));
            KHYSB.DataBindings.Add(new Binding("Text", bs, "KHYSB"));
            EI.DataBindings.Add(new Binding("Text", bs, "EI"));
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

            KHYSB_t.DataBindings.Add(new Binding("Text", bs, "KHYSB_t"));
            EI_t.DataBindings.Add(new Binding("Text", bs, "EI_t"));
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


            KHYSB_1.DataBindings.Add(new Binding("Text", bs, "KHYSB_1"));
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
            //  MessageBox.Show(bs.Position.ToString());

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
