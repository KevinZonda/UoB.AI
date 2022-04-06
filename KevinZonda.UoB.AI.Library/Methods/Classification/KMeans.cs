using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Data;
using KevinZonda.UoB.AI.Library.Mathematics.Functions.Distance;
using KevinZonda.UoB.AI.Library.Methods.Attribute;

namespace KevinZonda.UoB.AI.Library.Methods.Classification;

[Unsupervised]
public class KMeans
{
    private Random _rand = new Random();
    public int K { get; set; }
    public Vector<double>[] X { get; set; }
    public DistanceFunction DistanceFunction { get; set; } = new Euclidean();
    public KMeans(int k, Vector<double>[] x)
    {
        K = k;
        X = x;
    }

    private List<Vector<double>>[] CreateClasterList()
    {
        List<Vector<double>>[] clasters = new List<Vector<double>>[K];
        for (int i = 0; i < K; i++)
        {
            clasters[i] = new List<Vector<double>>();
        }
        return clasters;
    }

    private Vector<double>[] CreateInitialPoints()
    {
        Vector<double>[] points = new Vector<double>[K];
        for (int i = 0; i < K; i++)
        {
            var dimension = X[0].Dimension;
            points[i] = new Vector<double>(dimension);
            for (int j = 0; j < dimension; j++)
            {
                points[i][j] = _rand.NextDouble();
            }
        }
        return points;
    }

    private Vector<double>[] CloneVectorArray(Vector<double>[] arr)
    {
        var newArr = new Vector<double>[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            newArr[i] = (Vector<double>)arr[i].Clone();
        }
        return newArr;
    }

    public (Vector<double> Centroid, Vector<double>[] Cluster)[] Cluster(List<double[]> data)
    {
        var clasters = CreateClasterList();
        var centroids = CreateInitialPoints();
        Vector<double>[] prevCentroids;

        do
        {
            prevCentroids = CloneVectorArray(centroids);
            for (int i = 0; i < K; i++)
            {
                clasters[i].Clear();
            }

            // Assign Pts to Closest Cluster
            for (int i = 0; i < X.Length; i++)
            {
                var minDistance = double.MaxValue;
                int minIndex = 0;
                for (int j = 0; j < K; j++)
                {
                    var distance = DistanceFunction.CalculateDistance(X[i], centroids[j]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minIndex = j;
                    }
                }
                clasters[minIndex].Add(X[i]);
            }

            // Update Cluster Centroids
            for (int i = 0; i < K; i++)
            {
                var dimension = centroids[i].Dimension;
                double[] sum = new double[dimension];

                // Sum all dimensions
                foreach (var point in clasters[i])
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        sum[j] += point[j];
                    }
                }

                // Calc mean
                for (int j = 0; j < dimension; j++)
                {
                    sum[j] /= clasters[i].Count;
                }
            }
        } while (centroids != prevCentroids);
        var result = new (Vector<double> Centroid, Vector<double>[] Cluster)[K];
        for (int i = 0; i < K; i++)
        {
            result[i] = (centroids[i], clasters[i].ToArray());
        }
        return result;
    }
}