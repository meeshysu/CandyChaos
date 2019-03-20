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
					.AddMenuOption("Do you want to add some candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Do you want to trade some candy? Trade it here.")
                    .AddMenuText("Press Esc to exit.");
			Console.Write(mainMenu.GetFullMenu());
			var userOption = Console.ReadKey();
			return userOption;
		}

		public static bool TakeActions(CandyStorage db, ConsoleKeyInfo userInput)
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
            //    DateRecieved = "1/23/23",af
            //    IsEaten = false,
            //};       
            
			Console.WriteLine($"Candy Name:");
            var candyName = Console.ReadLine();
            
            Console.WriteLine($"Manufacturer:");
            var candyManufacturer = Console.ReadLine();

            Console.WriteLine($"Flavor:");
            var flavorCrap = Console.ReadLine();

            Console.WriteLine($"Date Recieved:");
            var candyDateReceived = Console.ReadLine();

            var newCandy = new Candy
            {
                Name = candyName,
                Manufacturer = candyManufacturer,
                Flavor = flavorCrap,
                DateReceived = candyDateReceived
            };

            db.SaveNewCandy(newCandy);

            Console.WriteLine("Your Candy: ");
            Console.WriteLine($"{newCandy.Name} : {newCandy.Manufacturer} : {newCandy.Flavor} : {newCandy.DateReceived}");
            Console.ReadLine();

            var userInput = MainMenu();
            var exit = false;
            exit = TakeActions(db, userInput);
        }

        private static void EatCandy(CandyStorage db)
		{
            Console.WriteLine("Here are your candies");

            foreach (var candy in db.getAllTheCandies())
            {
                Console.WriteLine($"{candy.Name} : {candy.Manufacturer} : {candy.Flavor} : {candy.DateReceived}");
            }

            Console.ReadLine();
            var userInput = MainMenu();
            var exit = false;
            exit = TakeActions(db, userInput);
        }
	}
}
