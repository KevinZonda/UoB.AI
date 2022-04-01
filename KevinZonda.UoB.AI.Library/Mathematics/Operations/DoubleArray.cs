namespace KevinZonda.UoB.AI.Library.Mathematics
{
    internal static class DoubleArray
    {
        #region Oper*
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
            CheckSize(x, y);

            double[] result = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
                result[i] = x[i] * y[i];

            return result;
        }
        #endregion

        #region oper+-
        public static double[] Add(this double[] x, double[] y)
        {
            CheckSize(x, y);

            double[] result = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
                result[i] = x[i] + y[i];

            return result;
        }

        public static double[] Minus(this double[] x, double[] y)
        {
            CheckSize(x, y);

            double[] result = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
                result[i] = x[i] - y[i];

            return result;
        }
        #endregion

        /// <summary>
        /// x^{T}y
        /// </summary>
        public static double Transpose(this double[] x, double[] y)
        {
            CheckSize(x, y);

            double result = 0;

            for (int i = 0; i < x.Length; i++)
                result += x[i] * y[i];

            return result;
        }

        public static bool IsSameSize(this double[] x, double[] y)
        {
            return x.Length == y.Length;
        }

        private static void CheckSize(double[] x, double[] y)
        {
            if (!x.IsSameSize(y))
                throw new ArgumentException("x and y must be of the same length");
        }
    }
}
