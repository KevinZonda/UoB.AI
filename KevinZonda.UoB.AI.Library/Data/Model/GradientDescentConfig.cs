using KevinZonda.UoB.AI.Library.ADT;

namespace KevinZonda.UoB.AI.Library.Data.Model;
public class GradientDescentConfig
{
    public double LearningRate { get; set; } = 0.01;
    public double Tolerance { get; set; } = 0.001;
    public DistanceFunction Distance { get; set; } = new Mathematics.Functions.Distance.Euclidean();
    public int MaxIterations { get; set; } = int.MaxValue;
}
