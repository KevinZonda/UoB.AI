using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Data;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Cost
{
    internal class L2Loss : CostFunction
    {
        public override double Evaluate(Func<Vector<double>, double> func, Vector<double>[] x, double[] y)
        {
            base.ValidateInput(x, y);
            
            int N = x.Length;
            double sum = 0;
            for (int n = 0; n < N; n++)
            {
                sum += Math.Pow(func(x[n]) - y[n], 2);
            }
            return sum / N;
        }
    }

    internal class MeanSquareError  : L2Loss { }
    internal class SquaredLoss : L2Loss { }
}
