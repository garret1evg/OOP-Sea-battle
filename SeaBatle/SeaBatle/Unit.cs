using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
     class Unit
    {
        Map myMap;
        Map enemyMap;
        User user;
        ShipList list;
        public Unit (Map myMap,Map enMap,User u,ShipList l)
        {
            this.myMap = myMap;
            this.enemyMap = enMap;
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
            user.SetShips(myMap, list);
        }
        public int[] Shoot()
        {
            int[] coords;
            do
            {
                coords = user.Shoot(enemyMap);
            } while (enemyMap.CheckForShootableCell(coords[0], coords[1]));
            
            return coords;
        }
        public Status CheckHit(int x,int y)
        {
            
            return myMap.CheckShootResult(x, y);
        }
        public void ShootReport(Status status,int x,int y)
        {

            enemyMap.SetStatus(status,x,y);
        }
        public void ShipBlow(AShip ship)
        {
            list.Delete(ship);
        }
        
    }

   
}
