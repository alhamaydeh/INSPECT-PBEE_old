using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace SampleWizard
{

    public partial class C_beam : Form
    {
        decimal total;
        //int i = 0;
        public C_beam()
        {
            InitializeComponent();
        }

        SQLiteConnection cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public C_beam(decimal a)
        {
            InitializeComponent();
            total = a;
            int size1 = Convert.ToInt32(total);

            this.SizeGripStyle = SizeGripStyle.Hide;
            this.ShowInTaskbar = false;


        }
        private void Add_Edge_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source="+ Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open();cmd.CommandText= "begin";cmd.ExecuteNonQuery(); 
            da.SelectCommand = new SQLiteCommand("Select * From C_Beam", cn);

            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];

            ITB.DataBindings.Add(new Binding("Value", bs, "ITB"));
            LB.DataBindings.Add(new Binding("Value", bs, "LB"));
            IB.DataBindings.Add(new Binding("Value", bs, "IB"));
            JLB.DataBindings.Add(new Binding("Value", bs, "JLB"));
            JRB.DataBindings.Add(new Binding("Value", bs, "JRB"));

            cmd.CommandText= "end";cmd.ExecuteNonQuery();cn.Close(); 
            label6.Text = "Beam number:   " + (bs.Position + 1) + " of  " + total.ToString();

            bindingNavigator1.BindingSource = bs;
        }



        private void button_23_Click_1(object sender, EventArgs e)
        {
            bs.MoveNext();
            label6.Text = "Beam number:   " + (bs.Position + 1) + " of  " + total.ToString();

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
            label6.Text = "Beam number:   " + (bs.Position + 1) + " of  " + total.ToString();
            button_23.Text = "Next";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.bs.EndEdit();
            SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);

            this.da.Update(ds.Tables[0]);
            


            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            int current = bs.Position;
            for (int i = (int)total; i >= current+1 ; i--)
            {
                ds.Tables[0].Rows[i - 1]["M"] = i + 1;
               // cmd.CommandText = "update " + "C_beam" + " set M =" + (i+1) +" where M="+i;
               // cmd.ExecuteNonQuery();

            }

            DataRow d = null;
            ds.Tables[0].Rows.Add(d);
            ds.Tables[0].Rows[(int)total + 1]["M"] = current + 1;
          //  cmd.CommandText = "insert into C_beam (M, ITB, LB, IB, JLB, JRB) values(" + (current + 1) + ",0,0,0,0,0)";
          //  cmd.ExecuteNonQuery();

          //  da.SelectCommand = new SQLiteCommand("Select * From C_Beam", cn);
          //  ds.Clear();
          //  da.Fill(ds);
            bs.EndEdit();
            da.Update(ds);
            bs.DataSource = ds.Tables[0];
            bindingNavigator1.BindingSource = bs;
            bs.ResumeBinding();
           // Var.Dont_del = true;
            total += 1;


        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           // cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
           // cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            int current = bs.Position;
            total = (int)bs.Count;
            this.bs.EndEdit();
            SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
            da.UpdateCommand = mySQLiteCommandBuilder.GetUpdateCommand();
            da.InsertCommand = mySQLiteCommandBuilder.GetInsertCommand();
            this.da.Update(ds.Tables[0]);
            this.bs.ResumeBinding();
            for (int i = (int)total-1; i >= current + 1; i--)
            {
                ds.Tables[0].Rows[i]["M"] = i + 1;
                // cmd.CommandText = "update " + "C_beam" + " set M =" + (i+1) +" where M="+i;
                // cmd.ExecuteNonQuery();

            }


           // ds.Tables[0].Rows.Add(current +1 , "0" ,"0","0","0", "0");
            ds.Tables[0].Rows[(int)total-1]["M"] = current + 1;
           // //  cmd.CommandText = "insert into C_beam (M, ITB, LB, IB, JLB, JRB) values(" + (current + 1) + ",0,0,0,0,0)";
           // //  cmd.ExecuteNonQuery();

           // //  da.SelectCommand = new SQLiteCommand("Select * From C_Beam", cn);
           // //  ds.Clear();
           // //  da.Fill(ds);
           // bs.EndEdit();
           // //SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
           // //da.Update(ds);
           // bs.DataSource = ds.Tables[0];
            this.bs.EndEdit();
            mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
            da.UpdateCommand = mySQLiteCommandBuilder.GetUpdateCommand();
            da.InsertCommand = mySQLiteCommandBuilder.GetInsertCommand();
            this.da.Update(ds.Tables[0]);
            this.bs.ResumeBinding();
           //bs.ResumeBinding();
           // // Var.Dont_del = true;
           // total += 1;
           // bs.MoveNext();


           
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
            updateAll(c[0].Name, Convert.ToDouble(((NumericUpDown)c[0]).Value));
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            List<double> lst = new List<double>();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader rd = new StreamReader(ofd.FileName);
                while (!rd.EndOfStream)
                {
                    string line = rd.ReadLine();
                    string[] values = line.Split(null);
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (!values[i].Trim().Equals(String.Empty))
                            lst.Add(Double.Parse(values[i].Trim()));
                    }

                }
                int k = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i][0] = Convert.ToInt32(lst[k++]);

                    for (int j = 1; j < ds.Tables[0].Columns.Count; j++)
                        ds.Tables[0].Rows[i][j] = lst[k++];
                }

            }
        }



        }
    }
