using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Game
    {
        User user1;
        User user2;
        public Unit CreateUnit(User user)
        {
            return new Unit(new Map(),user,new ShipList());
        }
    }
}
