using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class ShipList
    {
        public List<AShip> activeShips = new List<AShip>();
        public void Push(AShip ship)
        {
            activeShips.Add(ship);
        }
        public void Delete(AShip ship)
        {
            activeShips.Remove(ship);
        }
        
    }
}
