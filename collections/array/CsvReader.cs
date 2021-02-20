
namespace collections
{
    public class CsvReader
    {
    private string _csvFilePath;
    
        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];
            // using (StreamReader reader = new StreamReader(_csvFilePath))
            // {
            //     reader.Readline();
            //     for (int i = 0; i < nCountries; i++)
            //     {
            //         string csvLine = reader.Readline();
            //         countries[i] = ReadCountryFromCsvLine(csvLine);
            //     }
            // }
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}
