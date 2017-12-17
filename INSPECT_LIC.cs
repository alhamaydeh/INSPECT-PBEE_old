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
    public partial class INSPECT_LIC : Form
    {
        Settings settings;
        public INSPECT_LIC()
        {
            InitializeComponent();
            settings = new Settings();
            webBrowser1.DocumentText = settings.inspect_lic_text;
        }

        private void INSPECT_LIC_Load(object sender, EventArgs e)
        {

        }

        private void btn_agree_Click(object sender, EventArgs e)
        {
            settings.inspect_lic_new = true;
            settings.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_decline_Click(object sender, EventArgs e)
        {
            settings.inspect_lic_new = false;
            settings.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
