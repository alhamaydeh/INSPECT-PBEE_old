using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Kniaz.Optimization.NonGradient;
using com.sameer;

namespace Net.Kniaz.Optimization
{
    
    static class Class1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Hello");
           // double[] theta = {0.8,0.4};
            
            double theta = 0.8;
            double beta = 0.4;


            List<double> IM= new List<double>();
            IM.Add(0.2);
            IM.Add(0.3);
            IM.Add(0.4);
            IM.Add(0.6);
            IM.Add(0.7);
            IM.Add(0.8);
            IM.Add(0.9);
            IM.Add(1.0);
           

            List<int> num_collapse = new List<int>();
            num_collapse.Add(0);
            num_collapse.Add(0);
            num_collapse.Add(0);
            num_collapse.Add(4);
            num_collapse.Add(6);
            num_collapse.Add(13);
            num_collapse.Add(12);
            num_collapse.Add(16);

            List<int> num_gms = new List<int>();
            for (int i = 0; i < 8;i++)
            {
                num_gms.Add(40);
            }
            Analysis.fn_mle_pc(IM, num_gms, num_collapse, ref theta, ref beta);
            List<double> x = new List<double>();
            double val = 0.01;
            while(val<=3)
            {
                x.Add(val);
                val = val + 0.01;
            }
            List<double> y = Analysis.Evaluate(theta, beta, x);
            Console.WriteLine("Hello");
           // diff = NumericNet.CalcDiff(_dim, _reference, objNelder.Result);
          //  Assert.IsTrue(diff < _realEpsilon);
        }
    }
}
