using System;

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
            Country[] arrayOfRefTypes = new Country[1];

            foreach (var item in arrayOfValueTypes)
            {
                System.Console.WriteLine(item);
            }
            foreach (Country country in arrayOfRefTypes)
            {
                System.Console.WriteLine(country.Name);
            }
        }
    }
}
