using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWizard
{
    public class Limits
    {
        public static int NN1 = 20;
        public static int NN2 = 10;
        public static int NN4 = 30;
        public static int NN5 = 1000;
        public static int NN6 = 300;
        public static int NNC = 100;
        public static int NNB = 100;
        public static int NNW = 50;
        public static int NNE = 50;
        public static int NNT = 50;
        public static int NNR = 50;
        public static int NND1 = 40;
        public static int NND2 = 40;
        public static int NND3 = 40;
        public static int NND4 = 50;
        public static int NP1 = 10;
        public static int NP2 = 5;
        public static int NZ1 = 10;
        public static int NZ2 = 8000;
        public static int NZ3 = 10;
        public static int NZ4 = 500;
        public static DateTime LastDay = new DateTime(2017, 12, 31);// Limited version
        //public static DateTime LastDay = DateTime.MaxValue; // for UNLIMITED Version 
        public static DateTime CurrentDay = new DateTime();
        public static double[] FEMA_NEAR_DETLA = { 0.005, 0.005, 0.005, 0.01, 0.005, 0.005, 0.02, 0.005, 0.01, 0.02, 0.005, 0.005, 0.005, 0.005, 0.005, 0.005, 0.01, 0.0025, 0.0025, 0.005, 0.005, 0.02, 0.005, 0.01, 0.005, 0.005, 0.005, 0.005 };
        public static double[] FEMA_FAR_DELTA = { 0.01, 0.01, 0.01, 0.01, 0.01, 0.005, 0.01, 0.01, 0.005, 0.005, 0.02, 0.0025, 0.005, 0.005, 0.02, 0.005, 0.01, 0.02, 0.005, 0.005, 0.01, 0.005 };
        public static double DTCAL = 0;
        public static double WAVE_FILE_EPSLON = 1e-6;
        public static int CORES = Environment.ProcessorCount;
        public static decimal TOTAL_COLLAPSE_DRIFT_THRESHOLD = 10;
        public static decimal TOTAL_COLLAPSE_DAMAGE_INDEX_THRESHOLD = 3;
    }
}
