/*********************************************************************************************
 * 2D interploation Class 
 * To be used in IDARC GUI program 
 * 
 * Numbers are from Table 7-1b of the FEMA-P695 document
 * Interpolation alogrithm is adopted from http://en.wikipedia.org/wiki/Bilinear_interpolation 
 * 
 * Code Developed by: Eng. Sameer A. Alawnah  [sameer@alawnah.com , sameer.alawnah.com]
 * 
 * Version 1.0   ->  Date : Thursday, March 12,2015  03:55 pm.
 * ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWizard
{
    public class Interpol2
    {
        double[] ts = { 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7 };
        double[] us = { 0.8, 0.9, 1.0, 1.1, 1.5, 2, 3, 4, 6, 8, 9, 10 };
        double[,] vals ={{1.00, 1.00, 1.00, 1.05, 1.10, 1.13, 1.18, 1.22, 1.28, 1.33, 1.33, 1.33},
                        {1.00, 1.00, 1.00, 1.05, 1.10, 1.13, 1.18, 1.22, 1.28, 1.33, 1.33, 1.33},
                        {1.00, 1.00, 1.00, 1.05, 1.10, 1.13, 1.18, 1.22, 1.28, 1.33, 1.33, 1.33},
                        {1.00, 1.00, 1.00, 1.05, 1.11, 1.14, 1.20, 1.24, 1.30, 1.36, 1.36, 1.36},
                        {1.00, 1.00, 1.00, 1.06, 1.11, 1.15, 1.21, 1.25, 1.32, 1.38, 1.38, 1.38},
                        {1.00, 1.00, 1.00, 1.06, 1.12, 1.16, 1.22, 1.27, 1.35, 1.41, 1.41, 1.41},
                        {1.00, 1.00, 1.00, 1.06, 1.13, 1.17, 1.24, 1.29, 1.37, 1.44, 1.44, 1.44},
                        {1.00, 1.00, 1.00, 1.07, 1.13, 1.18, 1.25, 1.31, 1.39, 1.46, 1.46, 1.46},
                        {1.00, 1.00, 1.00, 1.07, 1.14, 1.19, 1.27, 1.32, 1.41, 1.49, 1.49, 1.49},
                        {1.00, 1.00, 1.00, 1.07, 1.15, 1.20, 1.28, 1.34, 1.44, 1.52, 1.52, 1.52},
                        {1.00, 1.00, 1.00, 1.08, 1.16, 1.21, 1.29, 1.36, 1.46, 1.55, 1.55, 1.55}, 
                        {1.00, 1.00, 1.00, 1.08, 1.16, 1.22, 1.31, 1.38, 1.49, 1.58, 1.58, 1.58},
                        {1.00, 1.00, 1.00, 1.08, 1.17, 1.23, 1.32, 1.40, 1.51, 1.61, 1.61, 1.61},
                        {1.00, 1.00, 1.00, 1.08, 1.17, 1.23, 1.32, 1.40, 1.51, 1.61, 1.61, 1.61},
                        {1.00, 1.00, 1.00, 1.08, 1.17, 1.23, 1.32, 1.40, 1.51, 1.61, 1.61, 1.61}};
        public Interpol2()
        {


        }
        public double Interpolate(double t, double u)
        {
            double t1 = findPreValue(ts, t);
            double t2 = findPostValue(ts, t);
            double u1 = findPreValue(us, u);
            double u2 = findPostValue(us, u);
            double f_Q11 = vals[findIndexByValue(ts, t1), findIndexByValue(us, u1)];
            double f_Q12 = vals[findIndexByValue(ts, t1), findIndexByValue(us, u2)];
            double f_Q21 = vals[findIndexByValue(ts, t2), findIndexByValue(us, u1)];
            double f_Q22 = vals[findIndexByValue(ts, t2), findIndexByValue(us, u2)];

            if (t1 == t2 && u1 == u2)// exact value no need for interpolation 
                return vals[findIndexByValue(ts, t1), findIndexByValue(us, u1)];
            else if (u1 == u2) // interpolation in the t-direction only 
            {
                double q = ((t2 - t) / (t2 - t1)) * f_Q11 + ((t - t1) / (t2 - t1)) * f_Q21;
                return q;
            }
            else if (t1 == t2)// interploation in the u-direction only
            {
                double q = ((u2 - u) / (u2 - u1)) * f_Q11 + ((u - u1) / (u2 - u1)) * f_Q12;
                return q;
            }
            else
            {// interpolation in both t and u directions 
                double q = (1 / ((t2 - t1) * (u2 - u1))) * (f_Q11 * (t2 - t) * (u2 - u) + f_Q21 * (t - t1) * (u2 - u) + f_Q12 * (t2 - t) * (u - u1) + f_Q22 * (t - t1) * (u - u1));
                return q;
            }
        }
        private double findPreValue(double[] arr, double value)
        {
            if (value <= arr[0])
                return arr[0];
            if (value >= arr[arr.Length - 1])
                return arr[arr.Length - 1];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] <= value)
                    return arr[i];
            }
            return arr[0];
        }
        private double findPostValue(double[] arr, double value)
        {
            if (value <= arr[0])
                return arr[0];
            if (value >= arr[arr.Length - 1])
                return arr[arr.Length - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= value)
                    return arr[i];
            }
            return arr[arr.Length - 1];
        }
        private int findIndexByValue(double[] arr, double value)
        {
            if (value < arr[0])
                return 0;
            if (value > arr[arr.Length - 1])
                return arr.Length - 1;
            for (int i = 0; i < arr.Length; i++)
                if (value == arr[i])
                    return i;
            return -1;
        }


    }
}
