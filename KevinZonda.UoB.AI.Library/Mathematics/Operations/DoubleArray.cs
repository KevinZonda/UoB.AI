namespace KevinZonda.UoB.AI.Library.Mathematics
{
    internal static class DoubleArray
    {
        public static double[] Multiply(this double x, double[] y)
        {
            double[] result = new double[y.Length];

            for (int i = 0; i < y.Length; i++)
                result[i] = x * y[i];

            return result;
        }

        public static double[] Multiply(this double[] x, double y)
        {
            return y.Multiply(x);
        }

        public static double[] Multiply(this double[] x, double[] y)
        {
            if (x.Length != y.Length)
                throw new ArgumentException("x and y must be of the same length");

            double[] result = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
                result[i] = x[i] * y[i];

            return result;
        }

        public static double[] Add(this double[] x, double[] y)
        {
            if (x.Length != y.Length)
                throw new ArgumentException("x and y must be of the same length");

            double[] result = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
                result[i] = x[i] + y[i];

            return result;
        }

        public static double[] Minus(this double[] x, double[] y)
        {
            if (x.Length != y.Length)
                throw new ArgumentException("x and y must be of the same length");

            double[] result = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
                result[i] = x[i] - y[i];

            return result;
        }
    }
}
