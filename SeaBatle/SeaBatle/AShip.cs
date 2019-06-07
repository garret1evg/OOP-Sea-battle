using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Status
{
    ok,
    miss,
    hit,
    destroyed
}
enum Direction
{
    up,
    down,
    left,
    right
}

namespace SeaBatle
{
    interface IShipManager
    {
        
        Status GetStatusShip();
        Status ShipTakeShoot();
    }
    class ShipToStatusManager : IStatusManager
    {
        //adapter
        AShip ship;
        public ShipToStatusManager(AShip ship)
        {
            this.ship = ship;
        }
        public Status GetStatus()
        {
            return ship.GetStatusShip();
        }
        public Status TakeShoot()
        {
            return ship.ShipTakeShoot();
        }
    }

    abstract class AShip : IShipManager
    {
        public Status status;
        public int size;
        public int id;
        public List<Deck> decks =new List<Deck>();
        public AShip(int lenght)
        {
            this.status = Status.ok;
            size = lenght;
            for (int i = 0; i < size; i++)
            {
                this.decks.Add(new Deck(this));
            }
        }
        private bool CheckForBlow()
        {
            bool blow = true;
            foreach (Deck deck in decks)
            {
                if (deck.GetStatus() == Status.ok)
                    blow = false;
            }
            return blow;
        }

        public void Blow()
        {
            foreach (Deck deck in decks)
            {
                deck.status = Status.destroyed;
            }
            status = Status.destroyed;
        }
        public Status GetStatusShip()
        {
            return status;
        }
        public Status ShipTakeShoot()
        {
            status = Status.hit;
            if (CheckForBlow())
            {
                Blow();
            }
            return status;
        }


    }
    class Submarine : AShip
    {
        
        public static int size=1;
        public Submarine(): base(size)
        {

        }
        


    }
    class SmallBoat : AShip
    {
        public static int size = 2;
        public SmallBoat() : base(size)
        {

        }
    }
    class MediumBoat : AShip
    {
        public static int size = 3;
        public MediumBoat() : base(size)
        {

        }
    }
    class BigBoat : AShip
    {
        public static int size = 4;
        public BigBoat() : base(size)
        {

        }
    }
}
