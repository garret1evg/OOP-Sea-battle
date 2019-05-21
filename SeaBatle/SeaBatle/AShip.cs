using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Status
{
    ok,
    hit,
    destroyed
}

namespace SeaBatle
{
    class AShip
    {
        public Status status;
        public int size;
        public int id;
        public List<Deck> decks;
        public void Blow()
        {
            Console.WriteLine("Ship was destroyed");
        }

    }
}
