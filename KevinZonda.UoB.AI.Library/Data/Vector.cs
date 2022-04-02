using System.Collections;

namespace KevinZonda.UoB.AI.Library.Data
{
    internal sealed class Vector<T> : IEnumerable<T>
    {
        private T[] _data;

        public Vector(int size)
        {
            _data = new T[size];
        }

        public Vector(T[] data)
        {
            _data = data;
        }

        public T this[int index]
        {
            get => _data[index];
            set
            {
                _data[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator() => _data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();

        public int Length => _data.Length;
        public int Demdimension => _data.Length;
        public int Size => _data.Length;

        public T[] Raw => _data;
        public T[] RawData => _data;

    }
}
