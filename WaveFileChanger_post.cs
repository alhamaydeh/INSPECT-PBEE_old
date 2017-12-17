using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SampleWizard
{
    public partial class WaveFileChanger_post : Form
    {
        WaveFile wave;
        string table;
        public WaveFileChanger_post(WaveFile wave,string table)
        {
            this.table = table;
            this.wave = wave;

            InitializeComponent();
            //txt_deltaT.Text = wave.deltaT.ToString();
            //txt_file_name.Text = wave.File_Name;
            //txt_lines_to_skip.Text = wave.Header_Lines.ToString();
            //txt_points_per_line.Text = wave.Points_Per_Line.ToString();
            //txt_prefix.Text = wave.Prefix_Per_Line.ToString();
            //txt_text.Text = wave.Text;
            //rdb_values.Checked = !wave.isTimeAndValues;
        }

        
        SQLiteConnection cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        private List<int> updateAll(string column, double value)
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
            return rng.SelectedRange;
        }
        private void updateAllSilent(string column, double value, List<int> range)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (range.Contains(Convert.ToInt32(ds.Tables[0].Rows[i][0])))
                {
                    ds.Tables[0].Rows[i][column] = Convert.ToDouble(value);
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


        private void WaveFileChanger_post_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\post.db;Version=3;"); cmd.Connection = cn;
            cn.Open(); cmd.CommandText = "begin"; cmd.ExecuteNonQuery();
            da.SelectCommand = new SQLiteCommand("Select * From "+table, cn);
            ds.Clear();
            da.Fill(ds);
            bs.DataSource = ds.Tables[0];

            txt_deltaT.DataBindings.Add(new Binding("Text", bs, "txt_deltaT"));
            txt_file_name.DataBindings.Add(new Binding("Text", bs, "txt_file_name"));
            txt_lines_to_skip.DataBindings.Add(new Binding("Value", bs, "txt_lines_to_skip"));
            txt_points_per_line.DataBindings.Add(new Binding("Value", bs, "txt_points_per_line"));
            txt_prefix.DataBindings.Add(new Binding("Value", bs, "txt_prefix"));
            txt_text.DataBindings.Add(new Binding("Text", bs, "txt_text"));
            rdb_values.DataBindings.Add(new Binding("Checked", bs, "rdb_values"));
            
            cmd.CommandText = "end"; cmd.ExecuteNonQuery(); cn.Close();

            //Edit_XX: There is a problem here (infinite loop) --Fixed
            while(bs.Position<bs.Count)
            {
                if (txt_file_name.Text.Trim().Equals(wave.File_Name))
                    break;
                bs.MoveNext();

            }

            validateNZ2();

        }
        public void validateNZ2()
        {
             // validating NZ2 11.06.15
            errorProvider1.Clear();
            int lines = (txt_text.Text.Split('\n')).Length;
            lines = lines - (int)txt_lines_to_skip.Value;
            int points = lines * (int)txt_points_per_line.Value;
            if (points > Limits.NZ2)
            {
                errorProvider1.SetError(txt_text, "Number of points shoudn't exceed " + Limits.NZ2 + " point");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            double deltaT = 0;
            WaveFile wv = new WaveFile();
            DataRow cur = ds.Tables[0].Rows[bs.Position];

            wv.deltaT = (double)cur["txt_deltaT"];
            wv.File_Name = (string)cur["txt_file_name"];
            wv.Header_Lines = (int)cur["txt_lines_to_skip"];
            wv.isTimeAndValues = ((int)cur["rdb_values"]) != 1;
            wv.Points_Per_Line = (int)cur["txt_points_per_line"];
            wv.Prefix_Per_Line =(int)cur["txt_prefix"];
            wv.Text = (string)cur["txt_text"];
            
            List<double> values = wv.getValues(ref deltaT);
            
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < values.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i*deltaT, values[i]);
            }
            txt_deltaT.Text = deltaT.ToString();
        }

        private void txt_lines_to_skip_TextChanged(object sender, EventArgs e)
        {
            try
            {
                wave.Header_Lines = Convert.ToInt32(txt_lines_to_skip.Text);
            }
            catch
            {
                MessageBox.Show("Header lines should contain integer value");
            }
        }

        private void txt_prefix_TextChanged(object sender, EventArgs e)
        {
            try
            {
                wave.Prefix_Per_Line = Convert.ToInt32(txt_prefix.Text);
            }
            catch
            {
                MessageBox.Show("Prefix per  line should contain integer value");
            }
        }

        private void txt_points_per_line_TextChanged(object sender, EventArgs e)
        {
            try
            {
                wave.Points_Per_Line = Convert.ToInt32(txt_points_per_line.Text);
            }
            catch
            {
                MessageBox.Show("Points per line should contain integer value");
            }
        }

        private void txt_deltaT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                wave.deltaT = Convert.ToDouble(txt_deltaT.Text);
            }
            catch
            {
                MessageBox.Show("deleaT should contain double value");
            }
        }

        private void txt_text_TextChanged(object sender, EventArgs e)
        {
            wave.Text = txt_text.Text;
        }

        private void rdb_values_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_values.Checked)
            {
                rdb_time_value.Checked = false;
            }
            else
            {
                rdb_time_value.Checked = true;
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.bs.EndEdit();
            SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
            this.da.Update(ds.Tables[0]);
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_23_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
            //wave = new WaveFile(this.txt_file_name.Text);
           // txt_text.Text = wave.Text;

            if (button_23.Text == "Finish")
            {
                this.bs.EndEdit();
                SQLiteCommandBuilder mySQLiteCommandBuilder = new SQLiteCommandBuilder(da);
                this.da.Update(ds.Tables[0]);
                this.Close();
            }
            if (bs.Position + 1 == bs.Count)
                button_23.Text = "Finish";

            validateNZ2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            //wave = new WaveFile(this.txt_file_name.Text);
           // txt_text.Text = wave.Text;
            

            button_23.Text = "Next";
            validateNZ2();
        }

        private void btn_rdb_values_Click(object sender, EventArgs e)
        {
            double value = 0;
            try
            {
                value = Double.Parse(txt_deltaT.Text);
            }
            catch
            {
                txt_deltaT.Text = "0";
                value = 0;
            }
            List<int> range = updateAll("txt_deltaT", value);
            updateAllSilent("rdb_values", rdb_values.Checked ? 1 : 0, range);
        }

        private void btn_txt_deltaT_Click(object sender, EventArgs e)
        {
            double value=0; 
            try
            {
                value = Double.Parse(txt_deltaT.Text);
            }
            catch
            {
                txt_deltaT.Text = "0";
                value = 0;
            }
            List<int> range = updateAll("txt_deltaT", value);
            updateAllSilent("rdb_values", rdb_values.Checked ? 1 : 0,range);
        }
    }
}
