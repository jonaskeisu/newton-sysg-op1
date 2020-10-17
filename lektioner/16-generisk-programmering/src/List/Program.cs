using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new int[] { 1, 2, 3 };
            List<int> list2 = new int[] { 4, 5, 6 };
            System.Console.WriteLine(list + list2 );
            
            List<double> list3 = new double[] { 1.1, 1.2, 1.3 };
            List<double> list4 = new double[] { 1.4, 1.5, 1.6 };
            System.Console.WriteLine(list3 + list4);

            List<bool> list5 = new bool[] { true, false, true, false };
        }
    }
}
