using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class User
    {
        IUser user;
        public User(IUser u)
        {
            this.user = u;
        }
        public bool SetShips(Map map, ShipList list)
        {
            return user.SetShipsOnMap(map, list);
        }

    }
    interface IUser
    {
        //Bridge
        int Shoot();
        bool SetShipsOnMap(Map map, ShipList list);
    }
    class LocalUser : IUser
    {
        public int Shoot()
        {
            Console.Write("pif");
            return 1;
        }
        public bool SetShipsOnMap(Map map, ShipList list)
        {
            return true;
        }
    }
    class BotUser : IUser
    {
        public int Shoot()
        {
            Console.Write("pif");
            return 1;
        }

        public bool SetShipsOnMap(Map map, ShipList list)
        {
            Random rand = new Random();
            int x;
            int y;
            int numDir;
            Direction dir;
            bool confirm=false;
            foreach (AShip ship in list.activeShips)
            {
                while (!confirm) 
                    {
                        x = rand.Next(map.mapSize);
                        y = rand.Next(map.mapSize);
                        numDir = rand.Next(4);
                        if (numDir == 0)
                            dir = Direction.right;
                        else if (numDir == 1)
                            dir = Direction.left;
                        else if (numDir == 2)
                            dir = Direction.down;
                        else
                            dir = Direction.up;
                        if (ship != null)
                            confirm = map.SetShipOnMap(ship, dir, x, y);
                        else confirm = true;
                    };
                confirm = false;
                
            }
            return true;
        }
    }
}
