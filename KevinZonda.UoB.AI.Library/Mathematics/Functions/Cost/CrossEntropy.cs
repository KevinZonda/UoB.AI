using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Data;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Cost;

internal class CrossEntropy : CostFunction
{
    public override double Evaluate(Func<Vector<double>, double> func, Vector<double>[] x, double[] y)
    {
        var N = x.Length;
        double sum = 0;
        for (var n = 0; n < N; n++)
        {
            sum += y[n] * Math.Log(func(x[n])) +
                   (1 - y[n]) * Math.Log(1 - func(x[n]));
        }
        return sum / N;
    }

    protected override bool ValidateInput(Vector<double>[] x, double[] y)
    {
        if (!base.ValidateInput(x, y))
            return false;
        foreach (var item in y)
            if (item != 1 && item != 0)
                return false;
        return true;
    }
}