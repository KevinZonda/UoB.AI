using KevinZonda.UoB.AI.Library.Data;
using KevinZonda.UoB.AI.Library.Data.Extension;
using KevinZonda.UoB.AI.Library.Data.Model;
using KevinZonda.UoB.AI.Library.Mathematics.Functions;

namespace KevinZonda.UoB.AI.Library.Methods.Regression;

public class TwoDLinearRegression
{
    public Vector<double>[] X { get; set; }
    public double[] Y { get; set; }

    public GradientDescentConfig Config;

    public TwoDLinearRegression(Vector<double>[] x, double[] y, GradientDescentConfig config)
    {
        X = x;
        Y = y;
        if (!CheckDemension())
        {
            throw new Exception("Dimension of X and Y are not equal or not in 2D");
        }
        Config = config;
    }

    public bool CheckDemension()
    {
        if (X.Length != Y.Length)
        {
            return false;
        }
        foreach (var x in X)
        {
            if (x.Dimension != 2)
            {
                return false;
            }
        }
        return true;
    }

    private Vector<double> Nabla(Vector<double> w, Vector<double> x, double y)
    {
        // w = [w0, w1]
        // x = [ 1, x1]
        // y = y
        var nabla = new Vector<double>(2);
        // w0 = (w0 + w1 * x) - y      -> w0 = (w0 * x0 + w1 * x1) - y
        // w1 = (w0 + w1 * x  - y) * x -> w1 = (w0 * x0 + w1 * x1  - y) * x1
        nabla[0] = w[0] * x[0] + w[1] * x[1] - y;
        nabla[1] = (w[0] * x[0] + w[1] * x[1] - y) * x[1];
        return nabla;
    }

    public void Train()
    {
        var l = new GradientDescent(Config);
        var newW = l.FindMinimumByNabla(
            new Vector<double>(2),
            (w0) =>
            {
                var sum = new Vector<double>(2);
                for (int n = 0; n < X.Length; n++)
                {
                    var nabla = Nabla(w0, X[n], Y[n]);
                    sum.Add(sum);
                }
                return sum;
            });
        _model = new Func<Vector<double>, double>(x => newW[0] * x[0] + newW[1] * x[1]);
    }

    private Func<Vector<double>, double>? _model = null;

    public Func<Vector<double>, double>? GetTrainModel()
    {
        return _model;
    }
}