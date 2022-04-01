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
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }

        public int Size
        {
            get
            {
                return _data.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.AsEnumerable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public int Length => _data.Length;

        public T[] Raw => _data;
    }
}
