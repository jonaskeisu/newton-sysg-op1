using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace EmployeeDb
{
    [Serializable]
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Name} <{Email}> {Birthday.ToString("yyyy-MM-dd")}";
        }
    }

    class Program
    {
        static List<Employee> employeeDb = new List<Employee>();

        static void LoadDb(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();
                while (stream.Position < stream.Length)
                {
                    employeeDb.Add((Employee)formatter.Deserialize(stream));
                }
            }
        }

        static void SaveDb(string fileName)
        {
            var stream = File.Open(fileName, FileMode.Create);
            IFormatter formatter = new BinaryFormatter();
            foreach (Employee employee in employeeDb)
            {
                formatter.Serialize(stream, employee);
            }
            stream.Close();
        }

        static void AddEmployee(params string[] data)
        {
            CultureInfo cultureInfo = new CultureInfo("se-SE");
            int id = employeeDb.Select(e => e.Id).DefaultIfEmpty().Max() + 1;
            employeeDb.Add(new Employee()
            {
                Id = id,
                Name = data[0],
                Email = data[1],
                Birthday = DateTime.Parse(data[2], cultureInfo)
            });
        }

        static void Main(string[] args)
        {
            const string fileName = "employees.bin";
            LoadDb(fileName);
            if (args.Length > 1)
            {
                switch (args[0])
                {
                    case "add":
                        AddEmployee(args[1..]);
                        SaveDb(fileName);
                        break;
                    case "find":
                        var employee = employeeDb.Find(e => e.Id == int.Parse(args[1]));
                        System.Console.WriteLine(employee);
                        break;
                    default:
                        System.Console.WriteLine($"Unknown command: {args[0]}");
                        break;
                }
            }
        }
    }
}
