using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Data;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distance;

public class Minkowski : DistanceFunction
{
    public Minkowski(double p)
    {
        P = p;
    }

    public double P { get; set; }

    public static double CalculateDistance(double[] x, double[] y, double p)
    {
        double sum = 0;
        for (var i = 0; i < x.Length; i++)
            sum += Math.Pow(Math.Abs(x[i] - y[i]), p);
        return Math.Pow(sum, 1 / p);
    }

    public static double CalculateDistance(Vector<double> vector1, Vector<double> vector2, double p)
    {
        return CalculateDistance(vector1.Data, vector2.Data, p);
    }

    public override double CalculateDistance(double[] x, double[] y)
    {
        return CalculateDistance(x, y, P);
    }
}