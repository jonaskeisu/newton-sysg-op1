using System;

namespace ProtectedAccess
{
    enum Color
    {
        Red,
        Green,
        Blue
    }

    class Car 
    {
        private int horsePowers = 400;

        public Color Color { get; set; }

        protected int HorsePowers => horsePowers;

        public double FuelConsumtion => horsePowers/300.0; 
    }

    class NoisyCar : Car
    {
        public void MakeNoise()
        {
            if (HorsePowers > 300)
            {
                System.Console.WriteLine("WRRRROMMMM!");
            }
            else 
            {
                System.Console.WriteLine("brrm brrm");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NoisyCar car = new NoisyCar();
            car.MakeNoise();
        }
    }
}
