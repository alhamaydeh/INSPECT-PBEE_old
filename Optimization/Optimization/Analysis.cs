using MathNet.Numerics.Distributions;
using Net.Kniaz.Optimization;
using Net.Kniaz.Optimization.NonGradient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sameer
{
    public class Analysis
    {
        public static double STEP = 0.0001;
        public static double EPSILON = 1e-7;
        public static int MAX_ITER = 1000;
        public static List<double> log(List<double> input)
        {
            List<double> res = new List<double>();
            for (int i = 0; i < input.Count; i++)
            {
                res.Add(Math.Log(input[i]));
            }

            return res;
        }
        public static double log(double input)
        {
            return Math.Log(input);
        }
        public static List<double> normcdf(List<double> x, double mu, double sig)
        {
            List<double> res = new List<double>();

            Normal normal = new MathNet.Numerics.Distributions.Normal(mu, sig);
            for (int i = 0; i < x.Count; i++)
            {
                res.Add(normal.CumulativeDistribution(x[i]));
            }
            return res;
        }
        public static List<double> normcdf(List<double> x)
        {
            return normcdf(x, 0, 1);
        }

        public static List<double> binopdf(List<int> x, List<int> N, List<double> P)
        {
            List<double> res = new List<double>();
            for (int i = 0; i < x.Count; i++)
            {
                Binomial binomal = new Binomial(P[i], N[i]);
                res.Add(binomal.Probability(x[i]));
            }

            return res;
        }
        public static double sum(List<double> x)
        {
            double res = 0;
            for (int i = 0; i < x.Count; i++)
                res += x[i];
            return res;
        }
        public static double mlefit(double theta, double beta, List<int> num_gms, List<int> num_collapse, List<double> IM)
        {
            List<double> p = normcdf(log(IM), log(theta), beta);
            List<double> likelihood = binopdf(num_collapse, num_gms, p);
            return -sum(log(likelihood));
        }
        public static void fn_mle_pc(List<double> IM, List<int> num_gms, List<int> num_collapse, ref double theta, ref double beta)
        {
            double[] data = { theta, beta };
            int _dim = 2;
            double _epsilon = EPSILON;
            double _realEpsilon = System.Math.Sqrt(_epsilon);
            double _step = STEP;
            int _itmax = MAX_ITER;
            MyFunction func = new MyFunction(2, IM, num_gms, num_collapse);
            Nelder objNelder = new Nelder(_dim, data, func, _step, _epsilon, _itmax);
            objNelder.FindMinimum();
            theta = objNelder.Result[0];
            beta = objNelder.Result[1];

        }

        public static List<double> Evaluate(double theta, double beta, List<double> x)
        {
            List<double> res = new List<double>();
            for (int i = 0; i < x.Count; i++)
            {
                res.Add( x[i] / theta);
            }
            for (int i = 0; i < x.Count; i++)
            {
                res[i] = Math.Log(res[i]);
                res[i] = res[i] / beta;
            }
            return normcdf(res);
        }
    }
}
