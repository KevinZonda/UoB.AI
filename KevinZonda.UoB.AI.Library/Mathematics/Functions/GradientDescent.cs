using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Data;
using KevinZonda.UoB.AI.Library.Data.Extension;
using KevinZonda.UoB.AI.Library.Mathematics.Operations;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions;

public class GradientDescent
{
    public static double[] FindMinimum(
        Vector<double> initial, double stepSize, double tolerance,
        Func<Vector<double>, Vector<double>> nabla,
        DistanceFunction distance, int maxIterations = int.MaxValue)
    {
        var current = initial;
        var previous = initial;

        for (var i = 0; i < maxIterations; i++)
        {
            var newPoint= OneStep(current, stepSize, nabla(current));

            if (distance.CalculateDistance(newPoint, previous) < tolerance)
                return newPoint;

            previous = current;
            current = newPoint;
        }

        return current;
    }

    public static Vector<double> OneStep(Vector<double> initStep, double stepSize,
        Vector<double> nabla)
    {
        var direction = stepSize.Multiply(nabla);
        return initStep.Minus(direction.ToVector());
    }
}