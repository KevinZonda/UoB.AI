using KevinZonda.UoB.AI.Library.ADT;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distance;

internal class Chebyshev : DistanceFunction
{
    public override double CalculateDistance(double[] x, double[] y)
    {
        double max = 0;
        for (var i = 0; i < x.Length; i++)
        {
            var diff = Math.Abs(x[i] - y[i]);
            if (diff > max)
                max = diff;
        }

        return max;
    }
}