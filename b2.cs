﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
namespace SampleWizard
{
    public partial class b2 : Form
    {
       double[] y;
       public b2()
        {
            y = new double[1];
            InitializeComponent();
           
        }
       public  b2(double [] x)
       {
           InitializeComponent();
           y = x;
       }

       int check = 0;

        private void b2_Load(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            cmd.CommandText = @"create table if not exists FEMA_B2 ([id] integer  NOT NULL PRIMARY KEY, [b2] float null, [b2_value] float null)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select * from FEMA_B2";
            cmd.ExecuteNonQuery();
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                check = Convert.ToInt16(reader["b2"]);
                switch (check)
                {
                    case 1:
                        radioButton1.Checked = true;
                        break;
                    case 2:
                        radioButton2.Checked = true;
                        break;
                    case 3:
                        radioButton3.Checked = true;
                        break;
                    case 4:
                        radioButton4.Checked = true;
                        break;
                    case 5:
                        radioButton5.Checked = true;
                        break;
                    case 6:
                        radioButton6.Checked = true;
                        break;
                    case 8:
                        radioButton8.Checked = true;
                        break;
                    case 9:
                        radioButton9.Checked = true;
                        break;
                }

            }
            reader.Close();

            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void b2_FormClosed(object sender, FormClosedEventArgs e)
        {



            if (radioButton1.Checked)
            { y[0] = 0.1; check = 1; }
            else if (radioButton2.Checked)
            { y[0] = 0.2; check = 2; }
            else if (radioButton3.Checked)
            { y[0] = 0.35; check = 3; }
            else if (radioButton4.Checked)
            { y[0] = 0.5; check = 4; }
            else if (radioButton5.Checked)
            { y[0] = 0.35; check = 5; }
            else if (radioButton6.Checked)
            { y[0] = 0.2; check = 6; }
            else if (radioButton8.Checked)
            { y[0] = 0.5; check = 8; }
            else if (radioButton9.Checked)
            { y[0] = 0.35; check = 9; }

            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\Database.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from FEMA_B2";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into FEMA_B2 (id,b2,b2_value) values (1," + check.ToString() + ", " + y[0].ToString() + ")";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
