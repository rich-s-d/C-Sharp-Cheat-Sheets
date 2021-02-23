using System;
using System.Collections.Generic;

namespace collections
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
            List<Country> listOfRefTypes = new List<Country>();
            listOfRefTypes.Add(new Country {Name = "Ghana", Code = "test", Region = "WA", Population = 1000});

            foreach (var item in arrayOfValueTypes)
            {
                System.Console.WriteLine(item);
            }
            foreach (Country country in listOfRefTypes)
            {
                System.Console.WriteLine(country.Name);
            }
        }
    }
}
