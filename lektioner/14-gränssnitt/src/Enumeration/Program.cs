using System;

namespace Enumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = new PrimesCollection(2, 100);
            foreach (int prime in primes)
            {
                System.Console.WriteLine(prime);
            }
        }
    }
}
