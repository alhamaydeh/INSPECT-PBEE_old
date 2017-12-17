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
    public partial class RangeSelector : Form
    {
        public List<int> SelectedRange;
        private int max;
        public RangeSelector(int max, string msg)
        {
            this.max = max; 
            InitializeComponent();
            SelectedRange = new List<int>();
        }

        private void RangeSelector_Load(object sender, EventArgs e)
        {

        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void rb_all_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_all.Checked)
                txt_range.Enabled = false;
            else
                txt_range.Enabled = true;
        }
        private bool addElement(int x)
        {
            if (SelectedRange.Contains(x))
                return true;
            if (x < 1 || x > max)
                return false;
            SelectedRange.Add(x);
            return true;

        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            SelectedRange.Clear();
            if (rb_all.Checked)
            {
                for (int i = 1; i <= max; i++)
                {
                    SelectedRange.Add(i);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }
            string[] ranges = txt_range.Text.Trim().Split(',');
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].Trim().Contains('-'))
                {
                    string[] sranges = ranges[i].Split('-');
                    if (sranges.Length != 2)
                    {
                        MessageBox.Show(ranges[i] + " is not a valid range");
                        return;
                    }
                    try
                    {
                        int min = Convert.ToInt32(sranges[0]);
                        int max = Convert.ToInt32(sranges[1]);
                        for (int j = min; j <= max; j++)
                        {
                            if (!addElement(j))
                            {
                                MessageBox.Show("Element " + j + " is out of range");
                                return;
                            }
                        }
                    }
                    catch
                    {

                        MessageBox.Show(ranges[i] + " is not a valid range");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        if (!addElement(Convert.ToInt32(ranges[i])))
                        {
                            MessageBox.Show("Element " + Convert.ToInt32(ranges[i]) + " is out of range");
                            return;
                        }
                    }
                    catch
                    {

                        MessageBox.Show(ranges[i] + " is not a valid range");
                        return;
                    }
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
