namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distribution;

public class Binomial
{
    public double SuccessProbability { get; set; }
    public int NumberOfTrials { get; set; }

    public Binomial(double succesProbability, int numberOfTrials)
    {
        SuccessProbability = succesProbability;
        NumberOfTrials = numberOfTrials;
    }

    public double Distribute(int numberOfSuccesses)
    {
        return Distribute(numberOfSuccesses, NumberOfTrials, SuccessProbability);
    }

    public static double Distribute(int k, int n, double p)
    {
        return Calculator.Ncr(k, n)
            * Math.Pow(p, k)
            * Math.Pow(1 - p, n - k);
    }
}
