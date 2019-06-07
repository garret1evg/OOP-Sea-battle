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
        public int[] Shoot(Map map)
        {
            return user.Shoot(map);
        }


    }
    interface IUser
    {
        //Bridge
        int[] Shoot(Map map);
        bool SetShipsOnMap(Map map, ShipList list);
    }
    class LocalUser : IUser
    {
        public int[] Shoot(Map map)
        {
            int[] coords = { };
            return coords;
        }
        public bool SetShipsOnMap(Map map, ShipList list)
        {
            return true;
        }
    }
    class BotUser : IUser
    {
        Random rand = new Random();
        public int[] Shoot(Map map)
        {
            int size = map.mapSize;
            int x = -1;
            int y = -1;
            bool ready = false;
            bool firstHit = true;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map.CheckForHitCell(i,j)&&firstHit)
                    {
                        x = i;
                        y = j;
                        firstHit = false;
                    }
                }
            }
            if (x == -1)
            {
                do
                {
                    x = rand.Next(size);
                    y = rand.Next(size);
                } while (map.CheckForShootableCell(x,y));
                ready = true;
            }
            else
            {
                if (map.CheckForHitCell(x + 1, y))
                {
                    if (map.CheckForShootableCell(x - 1, y))
                    {
                        x--;
                        ready = true;
                    }
                }
                if (map.CheckForHitCell(x, y+1))
                {
                    if (map.CheckForShootableCell(x , y-1))
                    {
                        y--;
                        ready = true;
                    }
                }
                if (!ready)
                {
                    int dir = rand.Next(4);
                    int i = x;
                    int j = y;
                    do
                    {
                        if (dir == 0)
                        {
                            i--;
                        }else if (dir == 1)
                        {
                            j--;
                        }
                        else if (dir == 2)
                        {
                            i++;
                        }
                        else
                        {
                            j++;
                        }
                    } while (map.CheckForShootableCell(i, j));
                    x = i;
                    y = j;
                }
            }
            int[] coords = {x,y};
            return coords;
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
