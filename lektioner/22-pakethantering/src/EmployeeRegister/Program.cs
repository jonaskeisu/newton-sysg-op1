using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace EmployeeRegister
{
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age} {Birthday:yyyy-MM-dd}";
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void AddEmployee(params string[] args)
        {
            employees.Add(
                new Employee() 
                {
                    Name = args[0],
                    Age = int.Parse(args[1]),
                    Birthday = DateTime.Parse(args[2],
                        new CultureInfo("se-SE"))
                }
            );
        }

        static void ListEmployees()
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        static void LoadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                employees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(fileName));
            }
        }

        static void SaveFile(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(employees));
        }

        static void Main(string[] args)
        {
            const string fileName = "employees.json";
            LoadFile(fileName);
            switch (args[0])
            {
                case "add":
                    AddEmployee(args[1..]);
                    break;
                case "list":
                    ListEmployees();
                    break;
                default:
                    break;
            }
            SaveFile(fileName);
        }
    }
}
