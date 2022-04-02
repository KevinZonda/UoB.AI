using KevinZonda.UoB.AI.Library.ADT;

namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Activation;

internal class HeavisideStep : ActivationFunction
{
    public override double Calculate(double input)
    {
        return input == 0
            ? 0.5 // Decision Boundary
            : input > 0
                ? 1
                : 0;
    }
}