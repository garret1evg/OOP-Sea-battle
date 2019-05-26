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
        public List<Deck> decks =new List<Deck>();
        public AShip(int lenght)
        {
            this.status = Status.ok;
            size = lenght;
            for (int i = 0; i < lenght; i++)
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
