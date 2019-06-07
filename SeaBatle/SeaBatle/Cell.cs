using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    interface IStatusManager
    {
        //proxy
        Status GetStatus();
        Status TakeShoot();
    }
    class Cell : IStatusManager
    {
        public Cell(int x, int y)
        {
            this.coordinateX = x;
            this.coordinateY = y;
            status = Status.ok;
        }
        public Status status;
        public int coordinateX;
        public int coordinateY;
        public Deck deck = null;
        public void putDeck(Deck deck)
        {
            this.deck = deck;
        }
        public override string ToString()
        {
            if (deck != null)
                if (deck.status == Status.ok)
                {
                    return "S";
                }else if (deck.status == Status.hit)
                {
                    return "X";
                }
                else
                {
                    return "K";
                }
            if (status == Status.ok)
            {
                return "O";
            }
            else { return "M"; }
        }
        public Status GetStatus()
        {
            if (deck == null)
                return status;
            else
                return deck.GetStatus();
        }
        public Status TakeShoot()
        {
            if (deck == null)
            {
                status = Status.miss;
                return status;
            }
            else
            {
                status = ShootingStatusManager.TakeShoot(deck);
                return status;
            }
        }
        public void SetStatus(Status stat)
        {
            status = stat;
        }
        public AShip GetShip()
        {
            if (deck != null)
                return deck.GetShip();
            return null;
        }
    }
}
