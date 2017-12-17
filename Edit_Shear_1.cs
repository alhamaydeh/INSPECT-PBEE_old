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

    public partial class Edit_Shear_1 : Form
    {
        decimal total;
        //int i = 0;
        public Edit_Shear_1()
        {
            InitializeComponent();
        }

        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        bool loading = true;
        public Edit_Shear_1(decimal a)
        {
            InitializeComponent();
         //   dataGridView1 = b;
            total = a;
            int size1 = Convert.ToInt32(total);

            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;


        }
        private void Add_Columns_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From Shear_1", cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];
            IMC.DataBindings.Add(new Binding("Text", bs, "IMC"));
            KHYSW_1.DataBindings.Add(new Binding("Text", bs, "KHYSW_1"));
            KHYSW_2.DataBindings.Add(new Binding("Text", bs, "KHYSW_2"));
            KHYSW_3.DataBindings.Add(new Binding("Text", bs, "KHYSW_3"));
            AN.DataBindings.Add(new Binding("Text", bs, "AN"));
            AMLW.DataBindings.Add(new Binding("Text", bs, "AMLW"));
            NSECT.DataBindings.Add(new Binding("Value", bs, "NSECT"));

            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 
 
            label6.Text = "Shear wall type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            loading = false;
            NSECT_ValueChanged(null, null);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Edit_NSECT temp_form = new Edit_NSECT(Convert.ToInt32(NSECT.Value), bs.Position +1);
            temp_form.ShowDialog();
        }

        private void button_23_Click_1(object sender, EventArgs e)
        {
            NSECT_del = true;
            bs.MoveNext();
            NSECT_del = false;
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
            NSECT_ValueChanged(null, null);
        }
        private void ValueChangedHandler(string tableName, int newValue, string insertTemplate, string deleteTemplate)
        {
            if (loading)
                return;
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();

            if (newValue == 0)
            {
                cmd.CommandText = "begin";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from " + tableName;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end";
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandText = "Select Count(*) from " + tableName;
                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    int oldValue = rd.GetInt32(0);
                    rd.Close();
                    cn.Close();
                    cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

                    if (newValue > oldValue)// Insert More Rows 
                    {

                        for (int i = 0; i < (newValue - oldValue); i++)
                        {
                            cmd.CommandText = String.Format(insertTemplate, (oldValue + i + 1));
                            cmd.ExecuteNonQuery();
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else if (newValue < oldValue) // Remove last rows 
                    {

                        while (oldValue != newValue)
                        {
                            cmd.CommandText = String.Format(deleteTemplate, oldValue);
                            cmd.ExecuteNonQuery();
                            oldValue--;
                        }
                        cmd.CommandText = "end";
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Can't update " + tableName);
                    return;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            label6.Text = "Shear wall type Number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";
            NSECT_ValueChanged(null, null);
        }
        bool NSECT_del = false;
        private void NSECT_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(Var.Dont_del.ToString());

            

            if (!NSECT_del)
            {

                string tableName = "NSECT_" + (bs.Position + 1);
                string insertTemplate =  "insert into NSECT_" + (bs.Position + 1) + " (KS, IMS, DWAL, BWAL, PT, PW) values({0},0,0,0,0,0)";
                string deleteTemplate = "Delete from NSECT_" + (bs.Position + 1) + " where KS={0}";
                ValueChangedHandler(tableName, (int)NSECT.Value, insertTemplate, deleteTemplate);
                if (NSECT.Value == 0)
                {
                    button1.Enabled = false;

                }
                else
                {
                    button1.Enabled = true;
                }
                
                return;


                //if(cn.State == ConnectionState.Closed)
                //  cn.Open(); 
                //cmd.CommandText = "Delete from NSECT_" + (bs.Position + 1);
                //cmd.ExecuteNonQuery();
                //for (int i = 1; i <= NSECT.Value; i++)
                //{

                //    cmd.CommandText = "insert into NSECT_" + (bs.Position + 1) + " (KS, IMS, DWAL, BWAL, PT, PW) values(" + i + ",0,0,0,0,0)";
                //    cmd.ExecuteNonQuery();
                //}
                //cn.Close();

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "Acrobat.exe";
            myProcess.StartInfo.Arguments = "/A \"page=32=OpenActions\"" + Var.pp + @"\100110-idarc2d70-Manual.pdf";
            myProcess.Start();
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

        private void btn_NSECT_Click(object sender, EventArgs e)
        {
            updateAll("NSECT", Convert.ToDouble(NSECT.Value));
        }

        }
    }
