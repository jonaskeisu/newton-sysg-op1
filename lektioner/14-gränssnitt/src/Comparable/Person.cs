namespace Comparable
{
    class Person : IComparable
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(object other)
        {
            if (other is Person otherPerson) {
                return Name.CompareTo(otherPerson.Name);
            }
            return -1; 
        }

        public override string ToString() => Name;
    }
}