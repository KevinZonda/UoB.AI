using KevinZonda.UoB.AI.Library.Data;

namespace KevinZonda.UoB.AI.Library.Interfaces
{
    internal interface IDistanceFunction
    {
        public double CalculateDistance(Vector<double> vector1, Vector<double> vector2)
        {
            return CalculateDistance(vector1.Raw, vector2.Raw);
        }
        public double CalculateDistance(double[] x, double[] y);
    }
}
