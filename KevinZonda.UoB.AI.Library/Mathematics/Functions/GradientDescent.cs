using KevinZonda.UoB.AI.Library.Interfaces;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions
{
    internal class GradientDescent
    {
        public static double[] FindMinimum(double[] initial, double stepSize, double tolerance, Func<double[], double[]> nabla, IDistanceFunction distance, int maxIterations = int.MaxValue)
        {
            double[] current = initial;
            double[] previous = initial;
            

            for (int i = 0; i < maxIterations; i++)
            {
                var gradient = nabla.Invoke(current);
                var direction = DoubleArray.Multiply(stepSize, gradient);
                var newPoint = DoubleArray.Add(current, direction);

                if (distance.CalculateDistance(newPoint, previous) < tolerance)
                {
                    return newPoint;
                }

                previous = current;
                current = newPoint;
            }

            return current;
        }
    }
}
