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
enum Direction
{
    up,
    down,
    left,
    right
}

namespace SeaBatle
{
    abstract class AShip
    {
        public Status status;
        public int size;
        public int id;
        public List<Deck> decks;
        public AShip()
        {
            this.status = Status.ok;
            for (int i = 0; i < size; i++)
            {
                this.decks.Add(new Deck(this));
            }
        }

        public void Blow()
        {
            Console.WriteLine("Ship was destroyed");
        }

    }
    class Submarine : AShip
    {
        public int size=1;
     

    }
    class SmallBoat : AShip
    {
        public int size = 2;
    }
    class MediumBoat : AShip
    {
        public int size = 3;
    }
    class BigBoat : AShip
    {
        public int size = 4;
    }
}
