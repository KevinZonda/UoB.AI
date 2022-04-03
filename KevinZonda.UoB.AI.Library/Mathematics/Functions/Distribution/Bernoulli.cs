namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distribution;

public class Bernoulli
{
    public double SuccessProbability { get; set; }

    public Bernoulli(double successProbability)
    {
        SuccessProbability = successProbability;
    }

    public double Distribute(int y)
    {
        return Distribute(y, SuccessProbability);
    }

    public static double Distribute(int y, double p)
    {
        if (!ValidateData(y, p))
        {
            throw new ArgumentException("Invalid data");
        }
        return y == 1 ? p : (1 - p);

    }

    private static bool ValidateData(int y, double p)
    {
        return y != 0 && y != 1 || p > 1 || p < 0;
    }
}

