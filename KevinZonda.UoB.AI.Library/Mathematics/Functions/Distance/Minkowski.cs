using KevinZonda.UoB.AI.Library.Data;
using KevinZonda.UoB.AI.Library.Interfaces;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distance
{
    internal class Minkowski : IDistanceFunction
    {
        public double P { get; set; }
        public Minkowski(double p)
        {
            P = p;
        }
        
        public static double CalculateDistance(double[] x, double[] y, double p)
        {
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += Math.Pow(Math.Abs(x[i] - y[i]), p);
            }
            return Math.Pow(sum, 1 / p);
        }

        public static double CalculateDistance(Vector<double> vector1, Vector<double> vector2, double p)
        {
            return CalculateDistance(vector1.Raw, vector2.Raw, p);
        }

        public double CalculateDistance(double[] x, double[] y)
        {
            return CalculateDistance(x, y, P);
        }
    }
}
