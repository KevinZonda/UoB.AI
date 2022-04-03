namespace KevinZonda.UoB.AI.Library.Mathematics.Functions.Distribution;

public class Normal
{
    public double StandardDeviation { get; set; }
    public double Mean { get; set; }

    public Normal(double mean, double standardDeviation)
    {
        Mean = mean;
        StandardDeviation = standardDeviation;
    }

    public double Distribute(double x)
    {
        return Distribute(x, Mean, StandardDeviation);
    }

    public static double Distribute(double x, double mu, double sigma)
    {
        return (1.0 /
            (sigma * Math.Sqrt(2.0 * Math.PI)))
            * Math.Exp(
                -(x - mu) * (x - mu) /
                (2.0 * sigma * sigma)
            );
    }
}