namespace candy_market
{
    internal class Candy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public Flavors Flavor { get; set; }
        public string DateReceived { get; set; }
        public bool IsEaten { get; set; }
    }
}