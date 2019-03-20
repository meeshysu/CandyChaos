using System;
using System.Collections.Generic;

namespace candy_market
{
	class Program
	{
		static void Main(string[] args)
		{
			var db = SetupNewApp();

			var exit = false;
			while (!exit)
			{
				var userInput = MainMenu();
				exit = TakeActions(db, userInput);
			}
		}

		internal static CandyStorage SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;

			var db = new CandyStorage();

			return db;
		}

		internal static ConsoleKeyInfo MainMenu()
		{
			View mainMenu = new View()
					.AddMenuOption("Press 1 to Add New Candy.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
					.AddMenuText("Press Esc to exit.");
			Console.Write(mainMenu.GetFullMenu());
			var userOption = Console.ReadKey();
			return userOption;
		}

		private static bool TakeActions(CandyStorage db, ConsoleKeyInfo userInput)
		{
			Console.Write(Environment.NewLine);

			if (userInput.Key == ConsoleKey.Escape)
				return true;

			var selection = userInput.KeyChar.ToString();
			switch (selection)
			{
				case "1": AddNewCandy(db);
					break;
				case "2": EatCandy(db);
					break;
				default: return true;
			}
			return true;
		}

		internal static void AddNewCandy(CandyStorage db)
        {
            //var newCandy = new Candy
            //{
            //    Id = 1,
            //    Name = "Whatchamacallit",
            //    Manufacturer = "mars",
            //    Flavor = "chocolate",
            //    DateRecieved = "1/23/23",
            //    IsEaten = false,
            //};

        
          var candies = new List<Candy> {};
       
            
            //var savedCandy = db.SaveNewCandy(candies);
			Console.WriteLine($"Candy Name:");
            var candyName = Console.ReadLine();
            candies.Add(new Candy() { Name = candyName });
            Console.WriteLine($"Manufacturer:");
            var candyManufacturer = Console.ReadLine();
            candies.Add(new Candy() { Manufacturer = candyManufacturer });
            Console.WriteLine($"Flavors:");
            var candyFlavor = Console.ReadLine();
            candies.Add(new Candy() { Flavor = candyFlavor });
            Console.WriteLine($"Date Recieved:");
            var candyDateReceived = Console.ReadLine();
            candies.Add(new Candy() { DateReceived = candyDateReceived });
            foreach (Candy cand in candies)
            {
                Console.WriteLine($"{cand.Name}");
            }
            Console.ReadLine();

        }

		private static void EatCandy(CandyStorage db)
		{
            //throw new NotImplementedException();
        }
	}
}
