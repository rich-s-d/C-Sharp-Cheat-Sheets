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

        public string Name { get; }
        public string Code { get; }
        public string Region { get; }
        public int Population { get; }
    }
}