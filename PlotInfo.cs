using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWizard
{
 
    public class PlotInfo
    {
        public static results_class[, ,] results=null;
        public static  object[,] batch;
        public static  decimal[] factors;
        public static  double BTOT;
        public static double c1, c2, c3, c4, c5, cc1, cc2, cc3, cc4, cc5, cc6, cc7, c6_drift, c6_damage;
        public static double ductt,  SSFf,  Smtt, ACMR20;
        public static int FEMA_check;
        public static bool units;
    }
}
