using System.Collections;

namespace KevinZonda.UoB.AI.Library.Data;

public class Vector<T> : IEnumerable<T>, ICloneable
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

    public Vector<T> Operate(Vector<T> v, Func<T, T, T> func)
    {
        if (v.Size != Size)
            throw new ArgumentException("Vectors must be of the same size");

        for (var i = 0; i < Size; i++)
            Data[i] = func(Data[i], v[i]);
        return this;
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

    public object Clone()
    {
        return new Vector<T>(Data.Clone() as T[]);
    }

    public static bool operator ==(Vector<T> v1, Vector<T> v2)
    {
        var v1Data = v1.Data;
        var v2Data = v2.Data;
        if (v1Data.Length != v2Data.Length)
            return false;
        for (var i = 0; i < v1Data.Length; i++)
            if (v1Data[i].Equals(v2Data[i]))
                return false;
        return true;
    }

    public static bool operator !=(Vector<T> v1, Vector<T> v2)
    {
        return !(v1 == v2);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        if (ReferenceEquals(obj, null))
            return false;

        if (GetType() != obj.GetType())
            return false;

        return this == (Vector<T>)obj;
    }

    public override int GetHashCode()
    {
        return Data.GetHashCode();
    }
}