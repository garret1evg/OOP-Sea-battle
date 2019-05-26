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
            return true;
        }
    }
}
