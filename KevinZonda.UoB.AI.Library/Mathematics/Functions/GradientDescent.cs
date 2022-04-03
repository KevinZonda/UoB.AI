using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Data;
using KevinZonda.UoB.AI.Library.Data.Extension;
using KevinZonda.UoB.AI.Library.Data.Model;
using KevinZonda.UoB.AI.Library.Mathematics.Operations;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions;

public class GradientDescent
{
    public GradientDescentConfig Config { get; set; }

    public GradientDescent(GradientDescentConfig config)
    {
        Config = config;
    }

    public Vector<double> FindMinimumByNabla(
        Vector<double> initial,
        Func<Vector<double>, Vector<double>> nablaFunc)
    {
        return FindMinimumByNabla(
            initial,
            Config.LearningRate,
            Config.Tolerance,
            nablaFunc,
            Config.Distance,
            Config.MaxIterations);
    }

    public Vector<double> FindMinimum(
        Vector<double> initial,
        Func<(Vector<double> w, double stepSize), Vector<double>> gradientStep)
    {
        return FindMinimum(
            initial,
            Config.LearningRate,
            Config.Tolerance,
            gradientStep,
            Config.Distance,
            Config.MaxIterations);
    }


    public static Vector<double> FindMinimumByNabla(
    Vector<double> initial, double stepSize, double tolerance,
    Func<Vector<double>, Vector<double>> nablaFunc,
    DistanceFunction distance, int maxIterations = int.MaxValue)
    {
        return FindMinimum(
            initial, stepSize, tolerance,
            x =>
            {
                var nabla = nablaFunc(x.w);
                return OneStep(x.w, x.stepSize, nabla);
            },
            distance,
            maxIterations);
    }

    public static Vector<double> FindMinimum(
        Vector<double> initial, double stepSize, double tolerance,
        Func<(Vector<double> w, double stepSize), Vector<double>> gradientStep,
        DistanceFunction distance, int maxIterations = int.MaxValue)
    {
        var current = initial;
        var previous = initial;

        for (var i = 0; i < maxIterations; i++)
        {
            var newPoint = gradientStep((current, stepSize));

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