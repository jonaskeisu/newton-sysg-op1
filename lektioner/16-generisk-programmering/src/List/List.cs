using System;
using System.Linq;
using System.Collections;

namespace List
{
    class List<T> : IEnumerable
    {
        private int length; 
        private T[] elements;

        private int Capacity => elements.Length;
        private int Length => length;

        public List()
        {
            length = 0;
            elements = new T[1];
        }

        public List(IEnumerable elements) :
            this()
        {
            Append(elements);
        }

        public List<T> Append(IEnumerable elements)
        {
            foreach (T element in elements)
                Add(element);
            return this;
        }

        public void Add(T value)
        {
            if (Length == Capacity)
            {
                DoubleCapacity();
            }
            elements[length++] = value;
        }

        public T this[int index]
        {
            get => elements[CheckedIndex(index)];
            set => elements[CheckedIndex(index)] = value;
        }

        public IEnumerator GetEnumerator() => new Enumerator(this);

        override public string ToString() =>
            String.Join(", ", elements.Take(length));

        static public List<T> operator +(List<T> a, List<T> b) =>
            new List<T>(a).Append(b);

        static public implicit operator List<T>(T[] array) =>
            new List<T>(array);

        private int CheckedIndex(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }
            return index;
        }

        private void DoubleCapacity()
        {
            Array.Resize(ref elements, Capacity * 2);
        }

        private class Enumerator : IEnumerator
        {
            int currentIndex; 
            private List<T> list; 

            public Enumerator(List<T> list)
            {
                currentIndex = -1;
                this.list = list;
            }

            public object Current => list[currentIndex];

            public bool MoveNext() => ++currentIndex < list.Length;

            public void Reset() => currentIndex = 0;
        }
    }
}