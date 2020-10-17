using System;
using System.Linq;
using System.Collections;

namespace IntList
{
    partial class IntList : IEnumerable
    {
        private int length; 
        private int[] elements;

        private int Capacity => elements.Length;
        private int Length => length;

        public IntList()
        {
            length = 0;
            elements = new int[1];
        }

        public IntList(IEnumerable elements) :
            this()
        {
            Append(elements);
        }

        public IntList Append(IEnumerable elements)
        {
            foreach (int element in elements)
                Add(element);
            return this;
        }

        public void Add(int value)
        {
            if (Length == Capacity)
            {
                DoubleCapacity();
            }
            elements[length++] = value;
        }

        public int this[int index]
        {
            get => elements[CheckedIndex(index)];
            set => elements[CheckedIndex(index)] = value;
        }

        public IEnumerator GetEnumerator() => new Enumerator(this);

        override public string ToString() =>
            String.Join(", ", elements.Take(length));

        static public IntList operator +(IntList a, IntList b) =>
            new IntList(a).Append(b);

        static public implicit operator IntList(int[] array) =>
            new IntList(array);

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
    }
}