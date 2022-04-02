namespace KevinZonda.UoB.AI.Library.Data.Extension
{
    internal static class VectorDouble
    {
        public static void Add(this Vector<double> v1, Vector<double> v2)
        {
            v1.Operate(v2, (x, y) => x + y);
        }

        public static void Minus(this Vector<double> v1, Vector<double> v2)
        {
            v1.Operate(v2, (x, y) => x - y);
        }

        public static void Multiply(this Vector<double> v1, Vector<double> v2)
        {
            v1.Operate(v2, (x, y) => x * y);
        }

        public static void Div(this Vector<double> v1, Vector<double> v2)
        {
            v1.Operate(v2, (x, y) => x / y);
        }
    }
}
