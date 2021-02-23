using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // string filePath = "";
            // CsvReader reader = new CsvReader(filePath);
            // Country[] countries = reader.ReadFirstNCountries(10);

            // foreach(Country country in countries)
            // {
            //     System.Console.WriteLine($"{country.Population}: {country.Name}");
            // }

            int[] arrayOfValueTypes = new int[4];

            foreach (var item in arrayOfValueTypes)
            {
                System.Console.WriteLine(item);
            }

            List<Country> listOfRefTypes = new List<Country>();
            listOfRefTypes.Add(new Country { Name = "Ghana", Code = "test", Region = "WA", Population = 1000 });

            foreach (Country country in listOfRefTypes)
            {
                System.Console.WriteLine(country.Name);
            }

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Name = "Shane" });

            foreach (Employee employee in employees)
            {
                System.Console.WriteLine(employee.Name);
            }

            Queue<Employee> line = new Queue<Employee>();
            line.Enqueue(new Employee { Name = "Maike" }); // adds to head of queue
            line.Enqueue(new Employee { Name = "Schafer" });

            while (line.Count != 0) // because dequeue will remove items from the queue.
            {
                var employee = line.Dequeue();
                System.Console.WriteLine(employee.Name);
            }

            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(new Employee { Name = "Daniel" });
            stack.Push(new Employee { Name = "Maike" });

            while (stack.Count != 0) // because pop will remove items from the queue.
            {
                var employee = stack.Pop();
                System.Console.WriteLine(employee.Name);
            }

            HashSet<int> set = new HashSet<int>();
            set.Add(2);
            set.Add(1);
            set.Add(2);

            foreach(var number in set)
            {
                System.Console.WriteLine(number);
            }
            System.Console.WriteLine($@"There are {set.Count} unique items in this Hash Set
            but three items were added");

        }
    }
}
