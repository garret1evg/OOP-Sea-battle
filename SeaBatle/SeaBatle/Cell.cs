using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Cell
    {
        public Cell(int x, int y)
        {
            this.coordinateX = x;
            this.coordinateY = y;
        }
        public Status status = Status.ok;
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
    }
}
