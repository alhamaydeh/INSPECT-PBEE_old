using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SampleWizard
{
    public partial class About : Form
    {
        String question;
        public About()
        {
            InitializeComponent();
        }
        public About(String a)
        {
            question = a;
            InitializeComponent();
        }
        private void New_Load(object sender, EventArgs e)
        {
            label1.Text = question;
        }
    }
}
