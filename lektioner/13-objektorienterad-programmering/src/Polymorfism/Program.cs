using System;

namespace Polymorfism
{
    class Circle 
    {
        public double Radius { get; set; }

        public double Area => Radius*Radius*Math.PI;
    }

    enum Color
    {
        Red,
        Green,
        Blue
    }

    class ColoredCircle : Circle
    {
        public Color Color { get; set; }
    }
    
    class PositionedColoredCircle : ColoredCircle 
    {
        public double CenterX { get; set; }

        public int CenterY { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle;
            System.Console.WriteLine("Press a key..");
            int num = int.Parse(Console.ReadKey().KeyChar.ToString());
            if (num == 0) {
                circle = new Circle() { Radius = 1 };
            }
            else {
                circle = new ColoredCircle() { Radius = 2, Color = Color.Blue };
            }
            System.Console.WriteLine("\n" + circle.Radius);
            System.Console.WriteLine("\n" + circle.Area);
            /*
            if (circle is ColoredCircle) {
                ColoredCircle coloredCircle = (ColoredCircle)circle;
                System.Console.WriteLine("\n" + coloredCircle.Color);
            }
            */

            if (circle is ColoredCircle coloredCircle) {
                System.Console.WriteLine("\n" + coloredCircle.Color);
            }

        }
    }
}
