using System;
using System.Collections.Generic;
using System.Text;

namespace candy_market
{
    public class DefaultCandy
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Flavor { get; set; }
        public DateTime DateReceived { get; set; }

        public DefaultCandy(int id, int ownerid, string name, string manufacturer, string flavor, DateTime datereceivied)
        {
            Id = id;
            OwnerId = id;
            Name = name;
            Manufacturer = manufacturer;
            Flavor = flavor;
            DateReceived = DateReceived;
        }
    }
}
