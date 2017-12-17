using com.sameer;
using Net.Kniaz.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sameer
{
    public class MyFunction : RealFunction
    {
        List<double> IM;
        List<int> num_gms;
        List<int> num_collapse;

        private int _dim;
        public MyFunction(int dimension, List<double> IM, List<int> num_gms, List<int> num_collapse)
        {
            _dim = dimension;
            this.IM = IM;
            this.num_collapse = num_collapse;
            this.num_gms = num_gms;
        }
       
		public override int Dimension
		{
			get{return _dim;}
		}

		public override double GetVal(double[] x)
		{
            return Analysis.mlefit(x[0], x[1], num_gms, num_collapse, IM);
		}

        
       
    }
}
