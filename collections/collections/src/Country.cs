namespace Collections
{
    public class Country
    {
        public Country(string name, string code, string region, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = population;
        }
        public Country()
        {
        }

        public string Name { get; set;}
        public string Code { get; set;}
        public string Region { get; set;}
        public int Population { get; set;}
    }
}