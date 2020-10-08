namespace Comparable
{
    class Car : IComparable
    {
        public int HorsePower { get; private set; }

        public string Model { get; private set; }

        public Car(string model, int horsePowers)
        {
            HorsePower = horsePowers;
            Model = model;
        }

        public int CompareTo(object other)
        {
            if (other is Car) {
                Car otherCar = (Car)other;
                return Model.CompareTo(otherCar.Model);
            }
            return -1;
        }

        public override string ToString() => Model;
    }
}