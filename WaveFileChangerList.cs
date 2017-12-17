using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWizard
{
    public partial class WaveFileChangerList : Form
    {
        ListBox lst;
        int index;
        public WaveFileChangerList(ListBox lst,int index)
        {
            this.lst = lst;
            this.index = index;
            InitializeComponent();
            load();
        }
        private void load()
        {
            errorProvider1.Clear();
            if (index >= lst.Items.Count)
                return;
            WaveFile wv = (WaveFile)lst.Items[index];

            txt_deltaT.Text = wv.deltaT.ToString();
            txt_file_name.Text = wv.File_Name;
            txt_text.Text = wv.Text;
            nud_lines_to_skip.Value = wv.Header_Lines;
            nud_points_per_line.Value = wv.Points_Per_Line;
            nud_prefix.Value = wv.Prefix_Per_Line;
            rdb_time_value.Checked = wv.isTimeAndValues;
            rdb_values.Checked = !wv.isTimeAndValues;
            lb_count.Text = (index + 1) + " of " + lst.Items.Count;
            
            // validating NZ2 11.06.15
            int lines = (wv.Text.Split('\n')).Length;
            lines = lines - wv.Header_Lines;
            int points = lines * wv.Points_Per_Line;
            if(points>Limits.NZ2)
            {
                errorProvider1.SetError(txt_text, "Number of points shoudn't exceed " + Limits.NZ2 + " point");
            }
        }
        private void save()
        {
            if (index >= lst.Items.Count)
                return;
            WaveFile wv = (WaveFile)lst.Items[index];
            wv.deltaT = Convert.ToDouble(txt_deltaT.Text);
            wv.File_Name = txt_file_name.Text;
            wv.Header_Lines = (int)nud_lines_to_skip.Value;
            wv.isTimeAndValues = rdb_time_value.Checked;
            wv.Points_Per_Line = (int)nud_points_per_line.Value;
            wv.Prefix_Per_Line = (int)nud_prefix.Value;
            wv.Text = txt_text.Text;
           
        }
        private void WaveFileChangerList_Load(object sender, EventArgs e)
        {

        }

        private void button_23_Click(object sender, EventArgs e)
        {
            save();
            index++;
            
            if (button_23.Text == "Finish")
                button2_Click(sender, e);
            if (index >= lst.Items.Count-1)
            {
                button_23.Text = "Finish";
               // return;
            }
            else
            {
                button_23.Text = "Next";
            }
           
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save();
            if (index == 0)
                return;
            button_23.Text = "Next";
            index--;
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
            if (index < 0 || index >= lst.Items.Count)
                return;
            double deltaT = 0;
            WaveFile wv = (WaveFile)lst.Items[index];
            List<double> values = wv.getValues(ref deltaT);
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < values.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i * deltaT, values[i]);
            }
            txt_deltaT.Text = deltaT.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_nud_lines_to_skip_Click(object sender, EventArgs e)
        {
            RangeSelector rng = new RangeSelector(lst.Items.Count, "Select range of Header Lines to Skip  to be changed [1-" + lst.Items.Count+1);
            if (rng.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                save();
                WaveFile currFile = (WaveFile)lst.Items[index];
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (rng.SelectedRange.Contains(i+1))
                    {
                        WaveFile wv = (WaveFile)lst.Items[i];
                        wv.Header_Lines = currFile.Header_Lines;
                    }
                }
            }
        }

        private void btn_nud_prefix_Click(object sender, EventArgs e)
        {
            RangeSelector rng = new RangeSelector(lst.Items.Count, "Select range of Header Lines to Skip  to be changed [1-" + lst.Items.Count + 1);
            if (rng.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                save();
                WaveFile currFile = (WaveFile)lst.Items[index];
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (rng.SelectedRange.Contains(i + 1))
                    {
                        WaveFile wv = (WaveFile)lst.Items[i];
                        wv.Prefix_Per_Line = currFile.Prefix_Per_Line;
                    }
                }
            }
        }

        private void btn_nud_points_per_line_Click(object sender, EventArgs e)
        {
            RangeSelector rng = new RangeSelector(lst.Items.Count, "Select range of Header Lines to Skip  to be changed [1-" + lst.Items.Count + 1);
            if (rng.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                save();
                WaveFile currFile = (WaveFile)lst.Items[index];
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (rng.SelectedRange.Contains(i + 1))
                    {
                        WaveFile wv = (WaveFile)lst.Items[i];
                        wv.Points_Per_Line = currFile.Points_Per_Line;
                    }
                }
            }
        }

        private void btn_rdb_values_Click(object sender, EventArgs e)
        {
            RangeSelector rng = new RangeSelector(lst.Items.Count, "Select range of Header Lines to Skip  to be changed [1-" + lst.Items.Count + 1);
            if (rng.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                save();
                WaveFile currFile = (WaveFile)lst.Items[index];
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (rng.SelectedRange.Contains(i + 1))
                    {
                        WaveFile wv = (WaveFile)lst.Items[i];
                        wv.isTimeAndValues = currFile.isTimeAndValues;
                        wv.deltaT = currFile.deltaT;
                    }
                }
            }
        }

        private void btn_txt_deltaT_Click(object sender, EventArgs e)
        {
            RangeSelector rng = new RangeSelector(lst.Items.Count, "Select range of Header Lines to Skip  to be changed [1-" + lst.Items.Count + 1);
            if (rng.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                save();
                WaveFile currFile = (WaveFile)lst.Items[index];
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (rng.SelectedRange.Contains(i + 1))
                    {
                        WaveFile wv = (WaveFile)lst.Items[i];
                        wv.isTimeAndValues = currFile.isTimeAndValues;
                        wv.deltaT = currFile.deltaT;
                    }
                }
            }
        }
    }
}
