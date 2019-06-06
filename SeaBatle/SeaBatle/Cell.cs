using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    abstract class AbstractCell
    {
        //proxy
        public abstract Status GetStatus();
        public abstract Status TakeShoot(int x,int y);
    }
    class Cell : AbstractCell
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
                    return "S";
                else
                    return "X";
            if (status == Status.ok)
                return "O";
            else return "*";
        }
        public override Status GetStatus()
        {
            if (deck == null)
                return status;
            else
                return deck.GetStatus();
        }
        public override Status TakeShoot(int x, int y)
        {
            if (deck == null)
            {
                status = Status.miss;
                return status;
            }
        }
    }
}
