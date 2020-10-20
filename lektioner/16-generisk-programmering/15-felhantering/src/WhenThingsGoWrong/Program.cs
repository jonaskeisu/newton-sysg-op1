using System;
using System.Linq;

namespace WhenThingsGoWrong
{
    class LinkedList
    {
        public int[] data;
        public LinkedList next;

        public LinkedList()
        {
            data = new int[1000000];
            for (int i = 0; i < data.Length; ++i)
                data[i] = i;
        }
    }


    class Program
    {
        static void MemoryLeak()
        {
            LinkedList root = new LinkedList();
            LinkedList node = root;
            while (true)
            {
                node.next = new LinkedList();
                node = node.next;
            }
        }

        static void StackOverflowException()
        {
            int a = 0;
            StackOverflowException();
        }

        static void IndexOutOfRangeException()
        {
            int[] array = { 1, 2, 3 };
            System.Console.WriteLine(array[3]);
        }

        static void NullReferenceException()
        {
            LinkedList list = null;
            int x = list.data[0];
        }

        static void InvalidCastException()
        {
            object obj = "En text";
            LinkedList list = (LinkedList)obj;
        }

        static void DivideByZeroException()
        {
            int a = 1, b = 0;
            int c = a / b;
        }

        static int CalculateAverage(int[] numbers)
        {
            int sum = 0;
            foreach (var n in numbers)
                sum += n;
            return sum / numbers.Length;
        }

        static void UserDefinedException()
        {
            int.Parse("ett");
        }

        static int Factorial(int number)
        {
            if (number == 0 || number == 1)
            {
                return 1;
            }
            else
            {
                return Factorial(number - 1) * number;
            }
        }

        static void PrintPrime()
        {
            int[] primes = { 2, 3, 5, 7, 11, 13, 17 };
            Console.Write("Skriv in ett tal: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Primaltal nummer {number} är {primes[number]}");
        }

        static void Main(string[] args)
        {
            bool tryAgain;
            do
            {
                tryAgain = false;
                try
                {
                    PrintPrime();
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine("Talet du skrev in var för högt.");
                    tryAgain = true;
                }
            } while (tryAgain);
        }
    }
}
