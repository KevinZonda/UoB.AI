namespace KevinZonda.UoB.AI.Library.Data.Extension;

public static class VectorDouble
{
    public static Vector<double> Add(this Vector<double> v1, Vector<double> v2)
    {
        return v1.Operate(v2, (x, y) => x + y);
    }

    public static Vector<double> Minus(this Vector<double> v1, Vector<double> v2)
    {
        return v1.Operate(v2, (x, y) => x - y);
    }

    public static Vector<double> Multiply(this Vector<double> v1, Vector<double> v2)
    {
        return v1.Operate(v2, (x, y) => x * y);
    }

    public static Vector<double> Div(this Vector<double> v1, Vector<double> v2)
    {
        return v1.Operate(v2, (x, y) => x / y);
    }
}