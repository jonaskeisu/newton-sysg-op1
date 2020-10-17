using System;
using System.Collections;

namespace IntList
{
    partial class IntList : IEnumerable
    {
        private class Enumerator : IEnumerator
        {
            int currentIndex; 
            private IntList list; 

            public Enumerator(IntList list)
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