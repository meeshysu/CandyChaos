using System;
using System.Collections.Generic;

namespace candy_market
{
    internal class CandyStorage
    {
        static List<Candy> _myCandy = new List<Candy>();

        //internal IList<string> GetCandyTypes()
        //{
        //}

        internal List<Candy> getAllTheCandies()
        {
            return _myCandy;
        }

        internal Candy SaveNewCandy(Candy newCandy)
        {
            _myCandy.Add(newCandy);
            return newCandy;
        }
    }
}
