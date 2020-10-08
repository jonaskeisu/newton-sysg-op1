using System.Collections;

namespace Enumeration
{
    class PrimesCollection : System.Collections.IEnumerable
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public PrimesCollection(int start, int end)
        {
            Start = start; 
            End = end;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator
        {
            private PrimesCollection Collection { get; set; }

            public Enumerator(PrimesCollection collection)
            {
                Collection = collection;
                Reset();
            }

            public bool MoveNext()
            {
                int num = (int)Current;
                ++num;
                while(num < Collection.End)
                {
                    if (IsPrime(num)) {
                        Current = num;
                        return true;
                    }
                    ++num;
                }
                return false;
            }

            public object Current { get; private set; }

            static public bool IsPrime(int num)
            {
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0) {
                        return false;
                    }
                }
                return true;
            }

            public void Reset()
            {
                Current = Collection.Start - 1; 
            }
        }
    }
}