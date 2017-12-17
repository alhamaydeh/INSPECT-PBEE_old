using SampleWizard.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SampleWizard
{
    public partial class about1 : Form
    {
        String question;
        public about1()
        {
            InitializeComponent();
            Settings settings = new Settings();
            webBrowser1.DocumentText = settings.about;
        }
        public about1(String a)
        {
            question = a;
            InitializeComponent();
        }
        private void New_Load(object sender, EventArgs e)
        {
          
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
