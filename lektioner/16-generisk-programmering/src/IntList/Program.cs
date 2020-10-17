using System;

namespace IntList
{
    class Program
    {
        static void Main(string[] args)
        {
            IntList list = new int[] { 1, 2, 3};
            IntList list2 = new int[] { 4, 5, 6};
            Console.WriteLine(list + list2);
        }
    }
}
