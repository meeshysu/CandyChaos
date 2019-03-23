using System;
using System.Collections.Generic;
using System.Text;

namespace candy_market
{
    public class Candy
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Flavor { get; set; }
        public string DateReceived { get; set; }

        public Candy(int id, int ownerid, string name, string manufacturer, string flavor, string datereceivied)
        {
            Id = id;
            OwnerId = id;
            Name = name;
            Manufacturer = manufacturer;
            Flavor = flavor;
            DateReceived = DateTime.Now.ToString();
        }

        public Candy() { }
    }
}
