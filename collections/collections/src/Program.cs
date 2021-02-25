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
            // the below instantiation will only work if Country paramenter are public.
            // listOfRefTypes.Add(new Country { Name = "Ghana", Code = "test", Region = "WA", Population = 1000 });
            listOfRefTypes.Add(new Country("Ghana", "test", "WA", 1000));

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

            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(3);
            list.AddFirst(2);

            var first = list.First;
            var secondLast = list.Last.Previous;
            list.AddAfter(first, 5);
            list.AddBefore(secondLast, 10);

            var node = list.First;
            while(node != null) // node = null when no next or previous item.
            {
                System.Console.WriteLine(node.Value);
                node = node.Next;
            }


            Dictionary<string, Employee> employeesByName = new Dictionary<string, Employee>();// multiple generic type parameters seperated by a comma.
            employeesByName.Add("Daniel", new Employee("Daniel"));
            employeesByName.Add("Maike", new Employee { Name = "Maike"});
            employeesByName.Add("Ingrid", new Employee("Ingrid"));

            var Shane = employeesByName["Daniel"];

            foreach (var employee in employeesByName)
            {
                System.Console.WriteLine(employee.Key);
                System.Console.WriteLine(employee.Value.Name);
            }

            SortedSet<int> sortSet = new SortedSet<int>();
            sortSet.Add(3);
            sortSet.Add(1);
            sortSet.Add(100);
            System.Console.WriteLine("");
            var enumerator = sortSet.GetEnumerator();
            System.Console.WriteLine($"GetEnumerator returns {enumerator.Current}");
            enumerator.MoveNext();
            System.Console.WriteLine($"MoveNext then returns {enumerator.Current}");

        }
    }
}
