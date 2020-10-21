using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    class Program
    {
        class Contact
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }

        static void Main(string[] args)
        {
            var contacts = new List<Contact>() {
                new Contact { Name = "Jonas", Age = 42, Email = "jonas.keisu@bitaddict.se"}  
            };

            var names = contacts.Select(c => c.Name);
            var ages = contacts.Select(c => c.Age);
            var descriptions = contacts.Select(c => $"{c.Name} ({c.Age } år)");

            var young = contacts.Where(c => c.Age < 25);
            var bitaddicts = contacts.Where(c => c.Email.EndsWith("@bitaddict.se"));

            int[] ints = {1, 2, 3, 4, 5};
            int intSum = ints.Sum();
            double[] doubles = {6.0, 7.0, 8.0};
            int doubleSum = ints.Sum();

            var byAge = contacts.OrderBy(c => c.Age);
            var byName = contacts.OrderBy(c => c.Name);
            var namesOnA = byName.TakeWhile(c => c.Name.CompareTo("b") < 0);

            var firstByName = byName.First();
            var lastByName = byName.Last();

            var emailsToYoungPeople = 
                contacts.
                Where(c => c.Age < 25).
                Select(c => c.Email);

            var averageAgeOfGmailUsers = 
                contacts.
                Where(c => c.Email.EndsWith("@gmail.com")).
                Select(c => c.Age).
                Average();
        }
    }
}
