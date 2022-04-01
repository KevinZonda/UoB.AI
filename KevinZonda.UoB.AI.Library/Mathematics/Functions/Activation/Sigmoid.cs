using KevinZonda.UoB.AI.Library.Interfaces;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Activation
{
    internal class Sigmoid : IActivationFunction
    {
        public double Calculate(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }
    }
}
