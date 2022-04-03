namespace KevinZonda.UoB.AI.Library.ADT;

public abstract class ActivationFunction
{
    public abstract double Calculate(double input);

    public ActivationLabel GetLabelByCalculation(double input)
    {
        return GetLabelByResult(Calculate(input));
    }

    public virtual ActivationLabel GetLabelByResult(double calcResult)
    {
        return calcResult switch
        {
            double d when d == DecisionBoundary => ActivationLabel.DecisionBoundary,
            double d when d < DecisionBoundary => ActivationLabel.Label0,
            double d when d > DecisionBoundary => ActivationLabel.Label1,
            _ => throw new NotImplementedException(),
        };
    }

    public virtual double DecisionBoundary { get; protected set; } = 0.5;
}

public enum ActivationLabel
{
    Label0,
    Label1,
    DecisionBoundary
}