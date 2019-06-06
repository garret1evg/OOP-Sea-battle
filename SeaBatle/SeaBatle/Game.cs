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
            return new Unit(new Map(),new Map(),user,new ShipList());
        }
        public Unit Battle(Unit unit1,Unit unit2)
        {
            ShootingTurn turn = new ShootingTurn(unit1, unit2);
            do
            {
                turn.Do();
                
            } while (0>1);
            return CreateUnit(user1);
        }
    }
    
}
