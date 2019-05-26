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
        public Status status;
        public int coordinateX;
        public int coordinateY;
        public Deck deck = null;
        public void putDeck(Deck deck)
        {
            this.deck = deck;
        }
    }
}
