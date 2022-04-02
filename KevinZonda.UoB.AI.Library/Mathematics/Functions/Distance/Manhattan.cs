using KevinZonda.UoB.AI.Library.ADT;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distance;

internal class Manhattan : DistanceFunction
{
    public override double CalculateDistance(double[] x, double[] y)
    {
        double distance = 0;
        for (var i = 0; i < x.Length; i++)
            distance += Math.Abs(x[i] - y[i]);
        return distance;
    }
}