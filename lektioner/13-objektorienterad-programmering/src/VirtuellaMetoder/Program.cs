using System;

namespace VirtuellaMetoder
{
    enum Color
    {
        Red,
        Green,
        Blue
    }

    class Car 
    {
        Color Color { get; set; }

        virtual public void Drive() {
            System.Console.WriteLine("Brrrrrm!");
        } 
    }

    class Tesla : Car
    {
        public override void Drive()
        {
            System.Console.WriteLine("Schwiiiiish!");
        }
    }

    class Volvo : Car 
    {
        public override void Drive()
        {
            base.Drive();
            base.Drive();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Car tesla = new Tesla();
            Car volvo = new Volvo();
            car.Drive();
            System.Console.WriteLine();
            tesla.Drive(); 
            System.Console.WriteLine();
            volvo.Drive();
        }
    }
}
