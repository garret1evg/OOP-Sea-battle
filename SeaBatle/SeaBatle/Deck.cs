using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Deck : IStatusManager
    {
        public Deck(AShip ship)
        {
            this.status = Status.ok;
            this.ship = ship;
        }
        public Status status;
        public AShip ship;
        public Status GetStatus()
        {
            
            return status;
            
        }
        public Status TakeShoot()
        {
            status = Status.hit;
            IStatusManager shipToStatusManager = new ShipToStatusManager(ship);
            status = ShootingStatusManager.TakeShoot(shipToStatusManager);
            return status;

        }
    }
}
