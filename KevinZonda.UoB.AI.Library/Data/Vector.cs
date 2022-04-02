using System.Collections;

namespace KevinZonda.UoB.AI.Library.Data;

internal class Vector<T> : IEnumerable<T>
{
    public Vector(int dimension)
    {
        Data = new T[dimension];
    }

    public Vector(T[] data)
    {
        Data = data;
    }

    public T this[int index]
    {
        get => Data[index];
        set => Data[index] = value;
    }

    public int Length => Data.Length;
    public int Dimension => Data.Length;
    public int Size => Data.Length;

    public T[] Data { get; }

    public IEnumerator<T> GetEnumerator()
    {
        return Data.AsEnumerable().GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return Data.GetEnumerator();
    }

    public void Operate(Vector<T> v, Func<T, T, T> func)
    {
        if (v.Size != Size)
            throw new ArgumentException("Vectors must be of the same size");

        for (var i = 0; i < Size; i++)
            Data[i] = func(Data[i], v[i]);
    }

    public static explicit operator Vector<T>(T[] v)
    {
        return new Vector<T>(v);
    }

    public static implicit operator T[](Vector<T> v)
    {
        return v.Data;
    }

    public override string ToString()
    {
        return "[" + string.Join(", ", Data) + "]";
    }
}