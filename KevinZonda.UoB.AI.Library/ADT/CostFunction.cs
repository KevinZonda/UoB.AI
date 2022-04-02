using KevinZonda.UoB.AI.Library.Data;

namespace KevinZonda.UoB.AI.Library.ADT;

public abstract class CostFunction
{
    public abstract double Evaluate(Func<Vector<double>, double> func, Vector<double>[] x, double[] y);

    protected virtual bool ValidateInput(Vector<double>[] x, double[] y)
    {
        return x.Length == y.Length;
    }
}