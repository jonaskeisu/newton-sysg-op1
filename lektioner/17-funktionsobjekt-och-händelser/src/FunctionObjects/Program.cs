using System;
using System.Collections.Generic;

namespace FunctionObjects
{
    class Contact
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Name + " (" + Age + " år)" + " <" + Email + ">";
        }
    }
    class Program
    {
        static List<Contact> contacts = new List<Contact>();

        static void AddContact(string name, int age, string email)
        {
            contacts.Add(new Contact() { 
                Name = name, 
                Age = age, 
                Email = email });
        }

        static void PrintContacts(List<Contact> contacts)
        {
            System.Console.WriteLine(String.Join("\n", contacts));
        }

        static List<Contact> YoungerThan40()
        {
            List<Contact> result = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.Age < 40)
                {
                    result.Add(contact);
                }
            }
            return result;
        }

        static List<Contact> EmailEndsWith(string postfix)
        {
            List<Contact> result = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.Email.EndsWith(postfix))
                {
                    result.Add(contact);
                }
            }
            return result;
        }

        delegate bool FilterFunc(Contact contact);

        static List<Contact> FilterContacts(FilterFunc filter)
        {
            List<Contact> result = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (filter(contact))
                {
                    result.Add(contact);
                }
            }
            return result;
        }

        static List<Contact> FilterContacts2(Func<Contact, bool> filter)
        {
            List<Contact> result = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (filter(contact))
                {
                    result.Add(contact);
                }
            }
            return result;
        }


        static void Main(string[] args)
        {
            AddContact("Jonas", 42,"jonas.keisu@bitaddict.se");
            AddContact("Jonas", 42,"jonas.keisu@gmail.com");
            AddContact("Karl", 27,"karl.svensson@bitaddict.se");
            AddContact("Anna", 29,"anna.nylander@bitaddict.se");            
            AddContact("Oscar", 26,"oscar.bark@bitaddict.se");

            // Sortera kontakter som är yngre än 40
            System.Console.WriteLine("Kontakter under 40");
            System.Console.WriteLine("==================");
            PrintContacts(YoungerThan40());
            System.Console.WriteLine();
            System.Console.WriteLine("Kontakter med gmail");
            System.Console.WriteLine("===================");
            PrintContacts(EmailEndsWith("@gmail.com"));

            bool below40(Contact contact) => contact.Age < 40;

            System.Console.WriteLine();
            System.Console.WriteLine("Kontakter under 40");
            System.Console.WriteLine("==================");
            PrintContacts(FilterContacts(below40));

            bool hasGamil(Contact contact) => contact.Email.EndsWith("@gmail.com");
            System.Console.WriteLine();
            System.Console.WriteLine("Kontakter med gmail");
            System.Console.WriteLine("===================");
            PrintContacts(FilterContacts(hasGamil));


            System.Console.WriteLine();
            System.Console.WriteLine("Kontakter under 40");
            System.Console.WriteLine("==================");
            PrintContacts(FilterContacts2(c => c.Age < 40));

            System.Console.WriteLine();
            System.Console.WriteLine("Kontakter med gmail");
            System.Console.WriteLine("===================");
            PrintContacts(FilterContacts2(c => c.Email.EndsWith("@gmail.com")));


            System.Console.WriteLine();
            System.Console.WriteLine("Kontakter under 40");
            System.Console.WriteLine("==================");
            PrintContacts(contacts.FindAll(c => c.Age < 40));

            System.Console.WriteLine();
            System.Console.WriteLine("Kontakter med gmail");
            System.Console.WriteLine("===================");
            PrintContacts(contacts.FindAll(c => c.Email.EndsWith("@gmail.com")));
        }
    }
}
