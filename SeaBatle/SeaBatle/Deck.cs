using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Deck : AbstractCell
    {
        public Deck(AShip ship)
        {
            this.status = Status.ok;
            this.ship = ship;
        }
        public Status status;
        public AShip ship;
        public override Status GetStatus()
        {
            
            return status;
            
        }
    }
}
