using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntPrimes
{
    class Program
    {
        static void GeneratePrimesFile(string fileName)
        {
            // Skapa sammling av primtal av typen int med LINQ
            IEnumerable<int> primes = 
                Enumerable.Range(2, 1000).
                Where(n => !Enumerable.Range(2, n - 2).Any(d => n % d == 0));

            // Spara talen till fil
            FileStream stream = File.Open("primes.bin", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            foreach (int prime in primes)
            {
                writer.Write(prime);
            }
            stream.Close();
        }

        static int LookupPrimeInFile(string fileName, int position)
        {
            int index = position - 1;
            FileStream stream = File.Open(fileName, FileMode.Open);
            BinaryReader reader = new BinaryReader(stream);
            stream.Seek(index * sizeof(int), SeekOrigin.Begin);
            int prime = reader.ReadInt32();
            stream.Close();
            return prime;
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
                int prime = LookupPrimeInFile(fileName, int.Parse(args[0]));
                System.Console.WriteLine(prime);
            }
        }
    }
}
