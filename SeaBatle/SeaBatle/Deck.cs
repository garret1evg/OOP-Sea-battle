using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Deck
    {
        public Deck(AShip ship)
        {
            this.status = Status.ok;
            this.ship = ship;
        }
        public Status status;
        public AShip ship;
    }
}
