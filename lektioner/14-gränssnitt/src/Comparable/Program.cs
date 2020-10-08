using System;

namespace Comparable
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = { 
                new Person("Anna", 29), 
                new Person("Jonas", 42), 
                new Person("Karl", 27)
            };

            Algorithms.Sort(people);
            System.Console.WriteLine(string.Join(", ", people as object[]));

            Car[] cars = {
                new Car("Tesla", 600),
                new Car("Volvo", 400),
                new Car("Skoda", 250)
            };

            Algorithms.Sort(cars);
            System.Console.WriteLine(string.Join(", ", cars as object[]));
        }
    }
}
