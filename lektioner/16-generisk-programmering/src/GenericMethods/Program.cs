using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using static System.Console;
using static GenericMethods.Algorithms;

namespace GenericMethods
{
    class Car : IComparable<Car>
    {
        public int HorsePowers { get; set; }
        public string Model { get; set; }

        public int CompareTo(Car other)
        {
            return HorsePowers - other.HorsePowers;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {8, 3, 6, 2, 1, 9, 0, 5, 4, 7 };
            Sort(numbers);
            WriteLine(String.Join(", ", numbers));
            string[] names = {"Jonas", "Marcus", "Niclas", "Daniel", "Henrik", "Anna"};
            Sort(names);
            WriteLine(String.Join(", ", names));

            Car[] cars = new Car[] {
                new Car() { Model = "Volvo", HorsePowers = 400}, 
                new Car() { Model = "Tesla", HorsePowers = 600}, 
                new Car() { Model = "Skoda", HorsePowers = 200}, 
            };

            Sort(cars);
            WriteLine(String.Join(", ", from car in cars select car.Model));
        }
    }
}
