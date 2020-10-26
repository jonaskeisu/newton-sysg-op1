using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Primes
{
    class Program
    {
        static void GeneratePrimesFile(string fileName)
        {
            // Skapa bytefält av primtal LINQ
            byte[] primes = 
                Enumerable.Range(2, 254).
                Where(n => !Enumerable.Range(2, n - 2).Any(d => n % d == 0)).
                Select(n => (byte)n).ToArray();

            // Spara bytefältet till fil
            Stream stream = File.Open("primes.bin", FileMode.Create);
            stream.Write(primes, 0, primes.Length);
            stream.Close();
        }

        static byte LookupPrimeInFile(string fileName, int position)
        {
            int index = position - 1;
            Stream stream = File.Open(fileName, FileMode.Open);
            if (index < stream.Length)
            {
                stream.Seek(index, SeekOrigin.Begin);
                byte[] prime = new byte[1];
                stream.Read(prime, 0, 1);
                stream.Close();
                return prime[0];
            }
            else 
                throw new IndexOutOfRangeException(
                    "Index out of file bounds");
        }

        static void Main(string[] args)
        {
            const string fileName = "primes.bin";
            if (args.Length == 0)
            {
                GeneratePrimesFile(fileName);
            }
            else
            {
                byte prime = LookupPrimeInFile(fileName, int.Parse(args[0]));
                System.Console.WriteLine(prime);
            }
        }
    }
}
