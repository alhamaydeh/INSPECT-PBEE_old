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
    public partial class ProgramMode : Form
    {
        Settings settings = new Settings();
        public ProgramMode()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_post_Click(object sender, EventArgs e)
        {
            PostProcessor post= new PostProcessor();
            post.Show();
            this.Close();
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            Form1 pre= new Form1();
            pre.Show();
            this.Close();
        }

        private void ProgramMode_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = settings.plotExt;
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                PlotResults res = Utilites.DeepDeserialize<PlotResults>(ofg.FileName);
                if (res.results == null)
                {
                    MessageBox.Show("No Plots to Show");
                    return;
                }
                plot t = new plot(ref res.results, ref res.batch, ref res.factors, res.BTOT, res.c1, res.c2, res.c3, res.c4, res.c5, res.ductt, res.SSFf, res.Smtt, res.FEMA_check, res.cc1, res.cc2, res.cc3, res.cc4, res.cc5, res.ACMR20, res.units);
                t.Show();
               // this.Close();
                //PlotNeedsSaving = false;
            }
        }
    }
}
