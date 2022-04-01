using KevinZonda.UoB.AI.Library.Data;
using KevinZonda.UoB.AI.Library.Interfaces;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distance
{
    internal class Manhattan : IDistanceFunction
    {
        public double CalculateDistance(double[] x, double[] y)
        {
            double distance = 0;
            for (int i = 0; i < x.Length; i++)
            {
                distance += Math.Abs(x[i] - y[i]);
            }
            return distance;
        }

    }
}
