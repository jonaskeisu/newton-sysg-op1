using System;

namespace MultipleTypeParameters
{
    class Program
    {
        class Double : Func<int, int>
        {
            public int Call(int arg)
            {
                return arg * 2;
            }
        }

        class Half : Func<int, double>
        {
            public double Call(int arg)
            {
                return arg / 2.0;
            }
        }

        class FuncChain<A, B, C> : Func<A, C>
        {
            private Func<A, B> func1;
            private Func<B, C> func2;

            public FuncChain(Func<A, B> func1, Func<B, C> func2)
            {
                this.func1 = func1;
                this.func2 = func2;
            }

            public C Call(A arg)
            {
                return func2.Call(func1.Call(arg));
            }
        }

        static void Main(string[] args)
        {
            var func = new FuncChain<int, int, double>(new Double(), new Half());
            Console.WriteLine(func.Call(2));
        }
    }
}
