using System;
using System.Collections;

namespace GenericMethods
{
    static class Algorithms
    {
        static public void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static public void Sort<T>(T[] objs) where T : IComparable<T>
        {
            for (int i = objs.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (objs[j].CompareTo(objs[j + 1]) > 0)
                    {
                        Swap(ref objs[j], ref objs[j + 1]);
                    }
                }
            }
        }
    }
}