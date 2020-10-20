using System;

namespace DelegateTypes
{
    class Program
    {
        static double StaticAddMethod(int a, float b)
        {
            return a + b;
        }

        class Adder
        {
            public double AddMethod(int a, float b)
            {
                return a + b;
            }
        }

        static void Main(string[] args)
        {
            double localAdd(int a, float b) => a + b;

            Func<int, float, double> del = localAdd;
            del = StaticAddMethod;
            Adder adder = new Adder();
            del = adder.AddMethod;
            del = (a, b) => a + b;


        }
    }
}
