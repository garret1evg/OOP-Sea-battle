using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Unit
    {
        Map map;
        User user;
        ShipList list;
        public Unit (Map m,User u,ShipList l)
        {
            this.map = m;
            this.user = u;
            this.list = l;
        }

        public void fillList()
        {
            AShip ship;
            ShipCreator creator = new ShipCreator();
            do
            {
                ship = creator.GetShip();
                if (ship != null)
                    this.list.Push(ship);
            } while (ship != null);
        }

        public void SetShips()
        {
            user.SetShips(map, list);
        }
    }
}
