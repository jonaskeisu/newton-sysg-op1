using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeInfo
{
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
        static List<Employee> employees = new List<Employee>();

        static void Serialize(TextWriter writer, Employee employee)
        {
            writer.WriteLine(String.Join(" ",
                employee.Id,
                "\"" + employee.Name + "\"",
                employee.Email, 
                employee.Birthday.ToString("yyyy-MM-dd")
            ));
        }

        static Employee Deserialize(TextReader reader)
        {
            CultureInfo cultureInfo = new CultureInfo("se-SE");
            var parts = reader.ReadLine().Split('"');
            Employee employee = new Employee();
            employee.Id = int.Parse(parts[0].Trim());
            employee.Name = parts[1];
            var subparts = parts[2].Trim().Split(' ');
            employee.Email = subparts[0];
            employee.Birthday = DateTime.Parse(subparts[1], cultureInfo);
            return employee;
        }

        static void LoadTextFile(string fileName)
        {
            var stream = File.Open(fileName, FileMode.OpenOrCreate);
            TextReader reader = new StreamReader(stream);
            while(stream.Position < stream.Length)
            {
                employees.Add(Deserialize(reader));
            }
            reader.Close();
        }

        static void SaveTextFile(string fileName)
        {
            var stream = File.Open(fileName, FileMode.Create);
            TextWriter writer = new StreamWriter(stream);
            foreach (Employee employee in employees)
            {
                Serialize(writer, employee);
            }
            writer.Close();
        }

        static void AddEmployee(params string[] data)
        {
            CultureInfo cultureInfo = new CultureInfo("se-SE");
            int id = employees.Select(e => e.Id).DefaultIfEmpty().Max() + 1;
            employees.Add(new Employee() { 
                Id = id, 
                Name = data[0],
                Email = data[1],
                Birthday = DateTime.Parse(data[2], cultureInfo)
            });
        }

        static void Main(string[] args)
        {
            const string fileName = "employees.txt";
            LoadTextFile(fileName);
            if (args.Length > 1)
            {
                switch (args[0])
                {
                    case "add":
                        AddEmployee(args[1..]);
                        SaveTextFile(fileName);
                        break;
                    case "find":
                        var employee = employees.Find(e => e.Id == int.Parse(args[1]));
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
