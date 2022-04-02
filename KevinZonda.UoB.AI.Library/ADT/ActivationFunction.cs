namespace KevinZonda.UoB.AI.Library.ADT;

internal abstract class ActivationFunction
{
    public abstract double Calculate(double input);

    public ActivationLabel GetLabelByCalculation(double input)
    {
        return GetLabelByResult(Calculate(input));
    }

    public static ActivationLabel GetLabelByResult(double calcResult)
    {
        return calcResult switch
        {
            double d when d < 0 || d > 1 => throw new ArgumentOutOfRangeException(nameof(calcResult),
                "Input must be between 0 and 1"),
            double d when d == 0.5 => ActivationLabel.DecisionBoundary,
            double d when d < 0.5 => ActivationLabel.Label0,
            double d when d > 0.5 => ActivationLabel.Label1,
            _ => throw new NotImplementedException()
        };
    }
}

public enum ActivationLabel
{
    Label0,
    Label1,
    DecisionBoundary
}