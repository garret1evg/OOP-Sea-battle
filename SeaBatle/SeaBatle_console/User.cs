using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SeaBatle
{
    class User
    {
        Random rand;
        IUser user;
        public User(IUser u, Random rand)
        {
            this.user = u;
            this.rand = rand;
        }
        public bool SetShips(Map map, ShipList list)
        {

            int x;
            int y;
            int numDir;
            Direction dir;
            bool confirm = false;
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
        public int[] Shoot(Map map, Map myMap)
        {
            return user.Shoot(map, myMap);
        }
        public void Win()
        {
            user.Win();
        }
        public void Lost()
        {
            user.Lost();
        }



    }
    interface IUser
    {
        //Bridge
        int[] Shoot(Map map,Map myMap);
        //bool SetShipsOnMap(Map map, ShipList list);
        void Win();
        void Lost();
    }
    class ConsoleUser : IUser
    {
        public int[] Shoot(Map map, Map myMap)
        {
            
            DrawMapsInConsole(myMap, map);
            Console.Write("Enter x");
            int x = Convert.ToUInt16(Console.ReadKey().KeyChar)- Convert.ToUInt16('0');
            Console.WriteLine();
            Console.Write("Enter y");
            int y = Convert.ToUInt16(Console.ReadKey().KeyChar)- Convert.ToUInt16('a');
            Console.Clear();

            int[] coords = {x,y};
            return coords;
        }
        private void DrawMapsInConsole(Map myMap,Map enemyMap)
        {
            String map = "   MyMap                                          EnemyMap\n   ";
            for (int i = 0; i < myMap.mapSize; i++)
            {
                map += i + "  ";
            }
            map +="                   ";
            for (int i = 0; i < myMap.mapSize; i++)
            {
                map += i + "  ";
            }
            map += "\n";
            for (int y = 0; y < myMap.mapSize; y++)
            {
                map += (char)(Convert.ToUInt16('A') + y) + "  ";
                for (int x = 0; x < myMap.mapSize; x++)
                {
                    map += myMap.cells[x, y].ToString() + "  ";
                }
                map += "                ";
                map += (char)(Convert.ToUInt16('A') + y) + "  ";
                
                for (int x = 0; x < myMap.mapSize; x++)
                {
                    map += enemyMap.cells[x, y].ToString() + "  ";
                }
                map += "\n";
            }
            Console.WriteLine(map);

        }
        public void Lost()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n                               GAME OVER!YOU LOST!");
            } while (Console.ReadKey().KeyChar=='q');
            
            Console.ReadKey();
        }
        public void Win()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n                               CONGRATULATIONS!YOU WON!");
            } while (Console.ReadKey().KeyChar == 'q');
           
        }

    }
    class BotUserHard : IUser
    {
        Random rand = new Random();
        public int[] Shoot(Map map, Map myMap)
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
                } while (!map.CheckForShootableCell(x,y));
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
                    else
                    {
                        x++;
                        do
                        {
                            x++;
                            ready = true;
                        } while (!map.CheckForShootableCell(x, y));
                    }
                    
                    
                }
                if (map.CheckForHitCell(x, y+1))
                {
                    if (map.CheckForShootableCell(x , y-1))
                    {
                        y--;
                        ready = true;
                    }
                    else
                    {
                        y++;
                        do
                        {
                            y++;
                            ready = true;
                        } while (!map.CheckForShootableCell(x, y));
                    }
                    
                }
                if (!ready)
                {
                    int dir;
                    int i ;
                    int j ;
                    do
                    {
                        dir = rand.Next(4);
                        i = x;
                        j = y;
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
                    } while (!map.CheckForShootableCell(i, j));
                    x = i;
                    y = j;
                }
            }
            
            
            int[] coords = {x,y};
            return coords;
        }
        public void Lost()
        {
            
        }
        public void Win()
        {
            
        }


    }
    class BotUserEasy : IUser
    {
        Random rand = new Random();
        public int[] Shoot(Map map,Map myMap)
        {
            int size = map.mapSize;
            int x;
            int y;
            do
            {
                x = rand.Next(size);
                y = rand.Next(size);
            } while (!map.CheckForShootableCell(x, y));   
            int[] coords = { x, y };
            return coords;
        }
        public void Lost()
        {

        }
        public void Win()
        {

        }


    }
}
