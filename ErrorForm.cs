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
    public partial class ErrorForm : Form
    {
        public ErrorForm(string text)
        {
            InitializeComponent();
            txt_error.Text = text;
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }
        public static DialogResult Show(string text)
        {
            ErrorForm fr = new ErrorForm(text);
            return fr.ShowDialog();
        }
    }
}
