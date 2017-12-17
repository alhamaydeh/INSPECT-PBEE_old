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
    public partial class GraphViewer : Form
    {
        public GraphViewer(/*ZedGraph.ZedGraphControl graph,ZedGraph.GraphPane Pane*/)
        {
            InitializeComponent();
           // zedGraphControl1 = new ZedGraph.ZedGraphControl();

           // this.zedGraphControl1 = graph;
           //// this.zedGraphControl3.GraphPane = Pane;
           // zedGraphControl1.GraphPane = new ZedGraph.GraphPane(Pane);

           // zedGraphControl1.AxisChange();
           // zedGraphControl1.Invalidate();
           // this.zedGraphControl1.Refresh();

           // this.Refresh();
        }

        private void GraphViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
