using KevinZonda.UoB.AI.Library.ADT;


namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Activation;

public class Hyperbolic : ActivationFunction
{
    public override double Calculate(double input)
    {
        var ex = Math.Exp(input);
        var emx = Math.Exp(-input);
        return (ex - emx) / (ex + emx);
    }

    public override double DecisionBoundary => 0;
}

public class Tanh : Hyperbolic { }