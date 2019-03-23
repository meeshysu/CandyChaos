using System;
using System.Collections.Generic;
using System.Text;

namespace candy_market
{
    class Users
    {
        public int Id { get; set; }
        public string userName { get; set; }

        public Users(int id, string username)
        {
            Id = id;
            userName = username;
        }
    }
}
