using System;
using System.Collections.Generic;
using System.Linq;

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

		public static CandyStorage SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;

			var db = new CandyStorage();

			return db;
		}

		internal static ConsoleKeyInfo MainMenu()
		{
            //View userMenu = new View()
            //        .AddMenuOption("Which user would you like to select?");
            //Console.Write(userMenu.GetFullMenu());
			View mainMenu = new View()
                    .AddMenuOption("Select your user!")
                    .AddMenuOption("Do you want to add some candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Do you want to eat a random piece of candy? Eat one here based on flavor...")
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
                case "1": PickUser(db);
                    break;
                case "2": AddNewCandy(db);
					break;
				case "3": EatCandy(db);
					break;
                case "4": EatRandomCandy(db);
                    break;
                default: return true;
			}
			return true;
		}

        public static void PickUser(CandyStorage db)
        {
            var users = db.allTheUsers();
            Console.WriteLine("Here are your users");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.userName}");
            }
            Console.ReadLine();

            Console.WriteLine("Which user would you like to use?:");
            var userChoice = Console.ReadLine();
            //Lamba filtering through name 
            var userInput = MainMenu();
            var exit = false;
            exit = TakeActions(db, userInput);
        }

        internal static void AddNewCandy(CandyStorage db)
        {    
			Console.WriteLine($"Candy Name:");
            var candyName = Console.ReadLine();
            
            Console.WriteLine($"Manufacturer:");
            var candyManufacturer = Console.ReadLine();

            Console.WriteLine($"Flavor:");
            var flavorCrap = Console.ReadLine();

            Console.WriteLine($"Date: {DateTime.Now}");
            var candyDateReceived = DateTime.Now.ToString();

            var newCandy = new Candy
            {
                Name = candyName,
                Manufacturer = candyManufacturer,
                Flavor = flavorCrap,
                DateReceived = candyDateReceived,
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
            var list = db.getAllTheCandies().OrderBy(x => x.DateReceived);
            var defaultCandyList = db.allTheDefaultCandies().OrderBy(y => y.DateReceived);
            Console.WriteLine("Here are your candies");

            foreach (var defaultCandy in defaultCandyList)
            {
                Console.WriteLine($"{defaultCandy.Name} : {defaultCandy.Manufacturer} : {defaultCandy.Flavor} : {defaultCandy.DateReceived}");
            }

            foreach (var candy in list)
            {
                Console.WriteLine($"{candy.Name} : {candy.Manufacturer} : {candy.Flavor} : {candy.DateReceived}");
            }
           
            var candyList = db.getAllTheCandies();
            Console.WriteLine("Would you like to eat a piece of candy?");
            var eatingCandyInput = Console.ReadLine();
            var filterCandies = candyList.Where(candy => candy.Name == eatingCandyInput).ToList();
            var eatingCandy = filterCandies.First();
            candyList.Remove(eatingCandy);

            var userInput = MainMenu();
            var exit = false;
            exit = TakeActions(db, userInput);
        }

        private static void EatRandomCandy(CandyStorage db)
        {
            var list = db.getAllTheCandies().OrderBy(x => x.DateReceived);
            Console.WriteLine("Here are your candies");

            foreach (var candy in list)
            {
                Console.WriteLine($"{candy.Name} : {candy.Manufacturer} : {candy.Flavor} : {candy.DateReceived}");
            }

            var candyList = db.getAllTheCandies();
            Console.WriteLine("Would you like to eat a random piece of candy based on flavor?");
            var eatingCandyInput = Console.ReadLine();
            var filterCandies = candyList.Where(candy => candy.Flavor == eatingCandyInput).ToList();
            Random random = new Random();
            int randnum = random.Next(0, filterCandies.Count);
            candyList.RemoveAt(randnum);

            var userInput = MainMenu();
            var exit = false;
            exit = TakeActions(db, userInput);
        }
    }
}
