using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWizard
{
    public partial class Batch_opt : Form
    {
        public Batch_opt()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int xx = listBox1.SelectedIndex;
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);


            if (xx >= 0)
            {

                // delete selected file from the database 
                try
                {
                    cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                    string sql = "DELETE FROM EQH WHERE txt_file_name='{0}';";
                    WaveFile wav = (WaveFile)listBox1.SelectedItem;
                    sql = String.Format(sql, wav.File_Name);

                    //cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    //  cmd.CommandText = "end"; cmd.ExecuteNonQuery();

                    if (listBox3.Items.Count > 0)
                    {
                        wav = (WaveFile)listBox1.SelectedItem;
                        string sql1 = "DELETE FROM EQV WHERE txt_file_name='{0}';";
                        sql1 = String.Format(sql1, wav.File_Name);
                        //cmd.CommandText = "begin"; cmd.ExecuteNonQuery();


                        cmd.CommandText = sql1;
                        cmd.ExecuteNonQuery();
                        // cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                    }
                    listBox1.Items.RemoveAt(xx);

                    listBox3.Items.RemoveAt(xx);
                    //   cn.Close();
                }
                catch (Exception ee)
                {

                    MessageBox.Show("Error Deleting file :(");
                }
                finally
                {
                    cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count <= 0)
                return;
            try
            {

                WaveFile wv = (WaveFile)listBox1.SelectedItem;

                WaveFileChanger_post www = new WaveFileChanger_post(wv, "EQH");

                www.ShowDialog();

                populateEarhQuicksFile();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error Editing file");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != listBox1.Items.Count)
                return;
            if (listBox3.SelectedIndex == 0)
                return;
            if (listBox3.SelectedIndex - 1 >= 0)
            {
                Object x = listBox3.Items[listBox3.SelectedIndex];
                Object y = listBox3.Items[listBox3.SelectedIndex - 1];

                // Object x1 = listBox4.Items[listBox3.SelectedIndex];
                // Object y1 = listBox4.Items[listBox3.SelectedIndex - 1];

                listBox3.Items[listBox3.SelectedIndex] = y;
                listBox3.Items[listBox3.SelectedIndex - 1] = x;

                //  listBox4.Items[listBox3.SelectedIndex] = y1;
                // listBox4.Items[listBox3.SelectedIndex - 1] = x1;

                listBox3.SelectedIndex -= 1;
                maintainID();

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != listBox3.Items.Count)
                return;
            if (listBox3.SelectedIndex == listBox3.Items.Count - 1)
                return;
            if (listBox3.SelectedIndex + 1 < listBox3.Items.Count)
            {
                Object x = listBox3.Items[listBox3.SelectedIndex];
                Object y = listBox3.Items[listBox3.SelectedIndex + 1];

                // Object x1 = listBox4.Items[listBox3.SelectedIndex];
                // Object y1 = listBox4.Items[listBox3.SelectedIndex + 1];

                listBox3.Items[listBox3.SelectedIndex] = y;
                listBox3.Items[listBox3.SelectedIndex + 1] = x;

                //   listBox4.Items[listBox3.SelectedIndex] = y1;
                //  listBox4.Items[listBox3.SelectedIndex + 1] = x1;

                listBox3.SelectedIndex += 1;
                maintainID();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count <= 0)
                return;
            try
            {

                WaveFile wv = (WaveFile)listBox3.SelectedItem;

                WaveFileChanger_post www = new WaveFileChanger_post(wv, "EQV");

                www.ShowDialog();

                populateEarhQuicksFile();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error Editing file");
            }
        }
        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            if (!TableExists("EQH", cn))
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table EQH ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            }
            if (!TableExists("EQV", cn))
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table EQV ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            }


            if (listBox1.Items.Count == 0)
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM EQH;"; // always create EQH and 

                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();

            }


            for (int i = 0; i < openFileDialog3.SafeFileNames.Length; i++)
            {
                WaveFile wav = new WaveFile(openFileDialog3.FileNames[i]);
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                listBox1.Items.Add(wav);


                cmd.CommandText = "insert into EQH (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text,order_id) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "'," + listBox1.Items.Count + ")";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();

                //if (checkboxYN1.Checked == false)
                //{
                //    listBox3.Items.Add("None");

                //}


            }
            cn.Close();
            if (checkboxYN1.Checked)
            {
               // openFileDialog4.ShowDialog();

            }


            //WHFILE_t = System.IO.File.ReadAllText(openFileDialog3.FileName);
        }
        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {
            if (listBox3.Items.Count == listBox1.Items.Count) return;
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            if (!TableExists("EQH", cn))
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table EQH ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            }
            if (!TableExists("EQV", cn))
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = @"create table EQV ([id] integer  NOT NULL PRIMARY KEY, [txt_deltaT] double null,
                                                        [txt_file_name] Text null,
                                                        [txt_lines_to_skip] int null,
                                                        [txt_points_per_line] int null,
                                                       [txt_prefix] int null,
                                                        [txt_text] Text null,
                                                        [rdb_values] int null,
                                                        [order_id] int null)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            }


            if (listBox3.Items.Count == 0)
            {
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM EQV;"; // always create EQH and 

                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();

            }


            for (int i = 0; i < openFileDialog4.SafeFileNames.Length && listBox3.Items.Count < listBox1.Items.Count; i++)
            {
                WaveFile wav = new WaveFile(openFileDialog4.FileNames[i]);
                cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                listBox3.Items.Add(wav);


                cmd.CommandText = "insert into EQV (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text,order_id) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "'," + listBox1.Items.Count + ")";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            }
            while (listBox3.Items.Count < listBox1.Items.Count)
            {
                MessageBox.Show("Please add more veritical components files");
                OpenFileDialog ofg = new OpenFileDialog();
                if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < ofg.FileNames.Length && listBox3.Items.Count < listBox1.Items.Count; i++)
                    {
                        WaveFile wav = new WaveFile(ofg.FileNames[i]);
                        cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
                        listBox3.Items.Add(wav);


                        cmd.CommandText = "insert into EQV (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text,order_id) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "'," + listBox1.Items.Count + ")";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "end"; cmd.ExecuteNonQuery();
                    }
                }
            }

            cn.Close();

            //WHFILE_t = System.IO.File.ReadAllText(openFileDialog3.FileName);
        }

        private void checkboxYN1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxYN1.Checked == true)
            {
                listBox3.Enabled = true;
            }
            else
            {
                listBox3.Enabled = false;
            }

        }

        private void ITDMP_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;

        }

       
       
        private void groupBox26_Enter(object sender, EventArgs e)
        {

        }

        private void Batch_opt_Load(object sender, EventArgs e)
        {

        }
        private void IWV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IWV.SelectedIndex != 0)
            {
                btn_add_vertical.Enabled = true;
                listBox3.Enabled = true;
                if (listBox3.Items.Count < listBox1.Items.Count)
                {
                  //  MessageBox.Show("Please add more veritcal components");
                   // openFileDialog4.ShowDialog();
                }

            }
            else
            {
                btn_add_vertical.Enabled = false;
                for (int i = listBox1.Items.Count; i < listBox3.Items.Count; i++)
                {
                    // delete selected file from the list 
                    listBox3.Items.RemoveAt(i);

                }
                listBox3.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                c1.Enabled = true;
            }
            else
            {
                c1.Enabled = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                c2.Enabled = true;
            }
            else
            {
                c2.Enabled = false;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                c3.Enabled = true;
            }
            else
            {
                c3.Enabled = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                c4.Enabled = true;
            }
            else
            {
                c4.Enabled = false;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                c5.Enabled = true;
            }
            else
            {
                c5.Enabled = false;

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public static bool TableExists(String tableName, SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
                cmd.Parameters.AddWithValue("@name", tableName);

                using (SQLiteDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        sqlDataReader.Close();
                        return true;
                    }
                    else
                    {
                        sqlDataReader.Close();
                        return false;
                    }
                }
            }
        }

        public void populateEarhQuicksFile()
        {
            listBox1.Items.Clear();
            listBox3.Items.Clear();

            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            if (!TableExists("EQH", cn))
            {
                cn.Close();
                return;
            }
            if (!TableExists("EQV", cn))
            {
                cn.Close();
                return;
            }
            string sql1 = "SELECT * FROM EQH order by order_id;";
            string sql2 = "SELECT * FROM EQV order by order_id;";

            // cmd.CommandText = "insert into EQH (txt_file_name,txt_deltaT,txt_lines_to_skip,txt_points_per_line,txt_prefix,rdb_values,txt_text) values('" + wav.File_Name + "'," + wav.deltaT + "," + wav.Header_Lines + "," + wav.Points_Per_Line + " ," + wav.Prefix_Per_Line + "," + (wav.isTimeAndValues ? 1 : 0) + ",'" + wav.Text + "')";
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();

            cmd.CommandText = sql1;
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                WaveFile wave = new WaveFile();
                wave.File_Name = reader.GetString(reader.GetOrdinal("txt_file_name"));
                wave.deltaT = reader.GetDouble(reader.GetOrdinal("txt_deltaT"));
                wave.Header_Lines = reader.GetInt32(reader.GetOrdinal("txt_lines_to_skip"));
                wave.isTimeAndValues = reader.GetInt32(reader.GetOrdinal("rdb_values")) != 1;
                wave.Points_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_points_per_line"));
                wave.Prefix_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_prefix"));
                wave.Text = reader.GetString(reader.GetOrdinal("txt_text"));
                listBox1.Items.Add(wave);
            }
            reader.Close();
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            //  reader.Close();
            cn.Close();

            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;");
            cmd = new SQLiteCommand(cn);
            cn.Open();
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            cmd.CommandText = sql2;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                WaveFile wave = new WaveFile();
                wave.File_Name = reader.GetString(reader.GetOrdinal("txt_file_name"));
                wave.deltaT = reader.GetDouble(reader.GetOrdinal("txt_deltaT"));
                wave.Header_Lines = reader.GetInt32(reader.GetOrdinal("txt_lines_to_skip"));
                wave.isTimeAndValues = !reader.GetBoolean(reader.GetOrdinal("rdb_values"));
                wave.Points_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_points_per_line"));
                wave.Prefix_Per_Line = reader.GetInt32(reader.GetOrdinal("txt_prefix"));
                wave.Text = reader.GetString(reader.GetOrdinal("txt_text"));


                listBox3.Items.Add(wave);
            }

            reader.Close();
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            //  reader.Close();
            cn.Close();

        }

        public void maintainID()
        {
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            string sql = "UPDATE {0} SET order_id = {1} WHERE txt_file_name='{2}';";
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                WaveFile wave = (WaveFile)listBox1.Items[i];
                cmd.CommandText = String.Format(sql, "EQH", i, wave.File_Name);
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                if (listBox3.Items[i].ToString().Equals("None"))
                    continue;
                WaveFile wave = (WaveFile)listBox3.Items[i];
                cmd.CommandText = String.Format(sql, "EQV", i, wave.File_Name);
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "end"; cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void checkbox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox6.Checked)
                c6_drift.Enabled = true;
            else
                c6_drift.Enabled = false;

        }

        private void checkbox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox7.Checked)
                c6_damage.Enabled = true;
            else
                c6_damage.Enabled = false;
        }

        private void btn_add_vertical_Click(object sender, EventArgs e)
        {
            openFileDialog4.ShowDialog();
        }
    }
}
