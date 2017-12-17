using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SampleWizard
{
    public partial class New1 : Form
    {
        String question;
        public New1()
        {
            InitializeComponent();
        }
        public New1(String a)
        {
            question = a;
            InitializeComponent();
        }
        private void New_Load(object sender, EventArgs e)
        {
            label1.Text = question;
        }
    }
