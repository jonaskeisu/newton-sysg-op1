using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

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
            return $"{Name} <{Email}> {Birthday:yyyy-MM-dd}";
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static string Serialize(Employee employee)
        {
            // Skapa rad på formatet: <id> "<namn>" <email> <birthday>"
            return 
                $"{employee.Id} \"{employee.Name}\" {employee.Email} " 
                + $"{employee.Birthday:yyyy-MM-dd}";
        }

        static Employee Deserialize(string line)
        {
            // Tolka rad på formatet: <id> "<namn>" <email> <birthday>"
            Regex re = new Regex(@"(\d+) ""([^""]+)"" (\S+) (\S+)"); 
            CultureInfo cultureInfo = new CultureInfo("se-SE");
            Match match = re.Match(line);
            return new Employee()
            {
                Id = int.Parse(match.Groups[1].Value),
                Name = match.Groups[2].Value,
                Email = match.Groups[3].Value,
                Birthday = DateTime.Parse(match.Groups[4].Value, cultureInfo)
            };
        }

        static void LoadTextFile(string fileName)
        {
            var stream = File.Open(fileName, FileMode.OpenOrCreate);
            TextReader reader = new StreamReader(stream);
            string line; 
            while((line = reader.ReadLine()) != null)
            {
                employees.Add(Deserialize(line));
            }
            reader.Close();
        }

        static void SaveTextFile(string fileName)
        {
            var stream = File.Open(fileName, FileMode.Create);
            TextWriter writer = new StreamWriter(stream);
            foreach (Employee employee in employees)
            {
                writer.WriteLine(Serialize(employee));
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
