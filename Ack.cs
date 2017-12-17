using SampleWizard.Properties;
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
    public partial class Ack: Form
    {
        Settings settings;
        public Ack()
        {
            InitializeComponent();
            settings = new Settings();
            webBrowser1.DocumentText = settings.ack;
        }

        private void INSPECT_LIC_Load(object sender, EventArgs e)
        {

        }

        private void btn_agree_Click(object sender, EventArgs e)
        {

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_decline_Click(object sender, EventArgs e)
        {
            
        }
    }
}
