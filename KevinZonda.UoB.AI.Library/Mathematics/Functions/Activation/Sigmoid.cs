using KevinZonda.UoB.AI.Library.ADT;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Activation;

public class Sigmoid : ActivationFunction
{
    public override double Calculate(double input)
    {
        return 1 / (1 + Math.Exp(-input));
    }
}