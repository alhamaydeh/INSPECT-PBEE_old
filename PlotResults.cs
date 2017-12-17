using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWizard
{
    [Serializable]
   public class PlotResults
    {

        public results_class[, ,] results = null;
        public object[,] batch;
        public decimal[] factors;
        public double BTOT;
        public double c1, c2, c3, c4, c5, cc1, cc2, cc3, cc4, cc5, cc6, cc7, c6_drift, c6_damage;
        public double ductt, SSFf, Smtt, ACMR20;
        public int FEMA_check;
        public bool units;

    }
}
