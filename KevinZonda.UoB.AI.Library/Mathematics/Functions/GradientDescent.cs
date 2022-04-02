using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Mathematics.Operations;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions;

public class GradientDescent
{
    public static double[] FindMinimum(double[] initial, double stepSize, double tolerance,
        Func<double[], double[]> nabla, DistanceFunction distance, int maxIterations = int.MaxValue)
    {
        var current = initial;
        var previous = initial;

        for (var i = 0; i < maxIterations; i++)
        {
            var gradient = nabla(current);
            var direction = stepSize.Multiply(gradient);
            var newPoint = current.Add(direction);

            if (distance.CalculateDistance(newPoint, previous) < tolerance) return newPoint;

            previous = current;
            current = newPoint;
        }

        return current;
    }
}