using System;
using System.Collections.Generic;

namespace candy_market
{
    public class CandyStorage
    {
        public List<Candy> myCandy = new List<Candy>();

        //internal IList<string> GetCandyTypes()
        //{
        //}

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
