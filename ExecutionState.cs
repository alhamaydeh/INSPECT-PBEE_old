using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWizard
{
    public class ExecutionState
    {
        public static string [,] Text;
        public static string[,] HFiles;
        public static string[,] VFiles;
        public static double[,] Scales;
        public static string[,] Paths;
        public static int ScalesCount, FilesCount;
        public static DateTime[,] StartingTimes;
        public static DateTime[,] EndingTimes;
        public static Process[,] Process;
        public static bool OK = true;
        public static void Init(int scalesCount,int filesCount)
        {
            ScalesCount = scalesCount;
            FilesCount = filesCount;
            Text = new string[scalesCount, filesCount];
            HFiles = new string[scalesCount, filesCount];
            VFiles = new string[scalesCount, filesCount];
            Paths = new string[scalesCount, filesCount];
            Scales = new double[scalesCount, filesCount];
            StartingTimes = new DateTime[scalesCount, filesCount];
            EndingTimes = new DateTime[scalesCount, filesCount];
            Process = new Process[scalesCount, filesCount];
            for(int i=0;i<scalesCount;i++)
            {
                for(int j=0;j<filesCount;j++)
                {
                    Text[i, j] = null;
                    HFiles[i, j] = null;
                    VFiles[i, j] = null;
                    Paths[i, j] = null;
                    Scales[i, j] = 0;
                    StartingTimes[i, j] = DateTime.MinValue;
                    EndingTimes[i, j] = DateTime.MaxValue;
                    Process[i, j] = null;
                }
            }
        }

    }

}
