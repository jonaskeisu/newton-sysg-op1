using System;

namespace AbstractBaseclass
{
    abstract class Geometry
    {
        public Geometry(double centerX, double centerY, double weight)
        {
            CenterX = centerX;
            CenterY = centerY;
            Weight = weight;
        }

        public double CenterX { get; set; }

        public double CenterY { get; set; }

        public double Weight { get; set; }

        public double Densitiy => Weight / Area;

        abstract public double Area { get; }
    }

    class Circle : Geometry 
    {
        private double radius; 

        public Circle(
                double centerX, 
                double centerY, 
                double weight, 
                double radius) :
            base(centerX, centerY, weight)
        {
            this.radius = radius;
        }

        public double Radius
        {
            get => radius;
            set
            {
                if (value >= 0)
                {
                    radius = value;
                }
            }
        }

        override public double Area {
            get {
                return Radius * Radius * Math.PI; 
            }
        }
    }

    class Rectangle : Geometry
    {
        private double width, height;

        public Rectangle(
                double centerX, 
                double centerY, 
                double weight, 
                double width, 
                double height) :
            base(centerX, centerY, weight)
        {
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get => width;
            set
            {
                if (value >= 0)
                {
                    width = value;
                }
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (value >= 0)
                {
                    height = value;
                }
            }
        }

        override public double Area 
        {
            get {
                return Width * height;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        { 
            Geometry[] geometries = new Geometry[5];

            geometries[0] = new Rectangle(0, 0, 1, 4, 7);
            geometries[1] = new Circle(0, 0, 1, 1.5);
            geometries[2] = new Rectangle(0, 0, 1, 1, 3); 
            geometries[3] = new Circle(0, 0, 1, 2);
            geometries[4] = new Rectangle(0, 0, 1, 6, 0.5);

            double totalArea = 0;
            foreach (var geometry in geometries) {
                totalArea += geometry.Area;
            }
            System.Console.WriteLine($"Total area: {totalArea}");
        }
    }
}
