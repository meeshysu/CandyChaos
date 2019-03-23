using System;
using System.Collections.Generic;

namespace candy_market
{
    public class CandyStorage
    {
        public List<Candy> myCandy = new List<Candy>();

        public List<Users> chaosCandyUsers = new List<Users>()
        {
            new Users(1, "Michelle"),
            new Users(2, "Chase"),
            new Users(3, "Lance"),
            new Users(4, "Martin"),
        };
        public List<DefaultCandy> defaultCandies = new List<DefaultCandy>()
        {
            new DefaultCandy(0, 1, "Skittles" , "Sweetums", "Rainbow", DateTime.Now.ToString()),
            new DefaultCandy(1, 1, "Starbursts" , "Sweetums", "Red", DateTime.Now.ToString()),
            new DefaultCandy(2, 2, "Snickers" , "Mars", "Chocolate", DateTime.Now.ToString()),
            new DefaultCandy(3, 2, "Baby Ruth" , "Magical", "Chocolate", DateTime.Now.ToString()),
            new DefaultCandy(3, 3, "Warheads" , "Mystyer", "Sour", DateTime.Now.ToString()),
            new DefaultCandy(4, 3, "Jelly Belly" , "Beanies", "Rainbow", DateTime.Now.ToString()),
            new DefaultCandy(4, 4, "Whatchamacallit" , "Pretzel", "Chocolate", DateTime.Now.ToString()),
            new DefaultCandy(0, 4, "Trolls" , "TinyPeeps", "Fruity", DateTime.Now.ToString()),
        };

        public List<Users> allTheUsers()
        {
            return chaosCandyUsers;
        }

        public List<DefaultCandy> allTheDefaultCandies()
        {
            return defaultCandies;
        }

        public List<Candy> getAllTheCandies()
        {
            return myCandy;
        }

        public Candy SaveNewCandy(Candy newCandy)
        {
            myCandy.Add(newCandy);
            return newCandy;
        }
    }
}
