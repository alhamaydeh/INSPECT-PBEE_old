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
    public partial class ForceFailForm : Form
    {
        public ForceFailForm(int scales)
        {
            InitializeComponent();
            nud_scales.Maximum = scales;
            Scales = scales;
        }
        public int Scales
        {
            get
            {
                return (int)nud_scales.Value;
            }
            set
            {
                nud_scales.Value = value;
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ForceFailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
