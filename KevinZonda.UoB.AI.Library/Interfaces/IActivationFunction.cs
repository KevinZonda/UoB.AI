namespace KevinZonda.UoB.AI.Library.Interfaces
{
    internal interface IActivationFunction
    {
        public double Calculate(double input);
    }

    public static class ActivationFunctionExtensions
    {
        internal static ActivationFunctionResult GetResult(this IActivationFunction function, double input)
        {
            return function.Calculate(input) switch
            {
                double d when (d < 0 || d > 1) => throw new ArgumentOutOfRangeException(nameof(input), "Input must be between 0 and 1"),
                double d when d == 0.5 => ActivationFunctionResult.DecisionBoundary,
                double d when d < 0.5 => ActivationFunctionResult.Label0,
                double d when d > 0.5 => ActivationFunctionResult.Label1,
                _ => throw new NotImplementedException(),
            };
        }
    }

    public enum ActivationFunctionResult
    {
        Label0,
        Label1,
        DecisionBoundary,
    }
}
