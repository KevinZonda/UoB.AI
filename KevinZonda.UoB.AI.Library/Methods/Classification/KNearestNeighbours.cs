using KevinZonda.UoB.AI.Library.ADT;
using KevinZonda.UoB.AI.Library.Data;
using KevinZonda.UoB.AI.Library.Mathematics.Functions.Distance;
using KevinZonda.UoB.AI.Library.Methods.Attribute;

namespace KevinZonda.UoB.AI.Library.Methods.Classification;

[SupervisedLearning]
public class KNearestNeighbours<T>
{
    public Vector<double>[] X { get; set; }
    public T[] Y { get; set; }

    public DistanceFunction DistanceFunction { get; set; }

    public int K { get; set; }

    public KNearestNeighbours(Vector<double>[] data, T[] label, int k, DistanceFunction dist = null)
    {
        X = data;
        Y = label;
        K = k;
        DistanceFunction = dist == null ? new Euclidean() : dist;
    }

    public (T Label, double Confidence)[] Predict(Vector<double> x)
    {
        // Desc
        var descCmp = Comparer<double>.Create((x, y) => y.CompareTo(x));

        SortedList<double, T> descSortedList = new SortedList<double, T>(descCmp);

        for (int i = 0; i < X.Length; i++)
        {
            double dist = DistanceFunction.CalculateDistance(X[i], x);
            descSortedList.Add(dist, Y[i]);
        }

        // <Label, Count>
        Dictionary<T, int> dic = new Dictionary<T, int>();
        int allCount = 0;
        foreach (var e in descSortedList)
        {
            if (dic.ContainsKey(e.Value))
                dic[e.Value]++;
            else
                dic.Add(e.Value, 1);
            ++allCount;
        }

        var sorted = dic.OrderByDescending(kvp => kvp.Value);
        var result = new List<(T Label, double Confidence)>();
        foreach (var e in sorted)
        {
            result.Add((e.Key, 1.0 * e.Value / allCount));
        }
        return result.ToArray();
    }

    public T PredictHighest(Vector<double> x)
    {
        var result = Predict(x);
        return result[0].Label;
    }

    private SortedList<TKey, TValue> MaintainSortedList<TKey, TValue>(SortedList<TKey, TValue> l, int k)
    {
        if (l.Count > k)
        {
            l.RemoveAt(l.Count - 1);
            return MaintainSortedList(l, k);
        }
        else
        {
            return l;
        }
    }
}

public class KNN<T> : KNearestNeighbours<T>
{
    public KNN(Vector<double>[] data, T[] label, int k, DistanceFunction dist = null) : base(data, label, k, dist)
    {
    }
}