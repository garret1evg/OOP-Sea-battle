using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class ShipCreator
    {
        int numberSubmarines = 4;
        AShipDeveloper sub = new SubmarineDeveloper();
        int numberSmallBoats = 3;
        AShipDeveloper small = new SmallBoatDeveloper();
        int numberMediumBoats = 2;
        AShipDeveloper medium = new MediumBoatDeveloper();
        int numberBigBoats = 1;
        AShipDeveloper big = new BigBoatDeveloper();

        public AShip GetShip()
        {
            if (numberSubmarines > 0)
            {
                numberSubmarines--;
                return sub.Create();
            }
                
            if (numberSmallBoats > 0)
            {
                numberSmallBoats--;
                return small.Create();
            }
                
            if (numberMediumBoats > 0)
            {
                numberMediumBoats--;
                return medium.Create();
            }
            if (numberBigBoats > 0)
            {
                numberBigBoats--;
                return big.Create();
            }
            return null;
                
        }
        public void Reset()
        {
            numberSubmarines = 4;
            numberSmallBoats = 3;
            numberMediumBoats = 2;
            numberBigBoats = 1;
        }


    }
    abstract class AShipDeveloper
    {
        // фабричный метод
        abstract public AShip Create();
    }
    class SubmarineDeveloper : AShipDeveloper
    {
        public override AShip Create()
        {
            return new Submarine();
        }
    }
    class SmallBoatDeveloper : AShipDeveloper
    {
        public override AShip Create()
        {
            return new SmallBoat();
        }
    }
    class MediumBoatDeveloper : AShipDeveloper
    {
        public override AShip Create()
        {
            return new MediumBoat();
        }
    }
    class BigBoatDeveloper : AShipDeveloper
    {
        public override AShip Create()
        {
            return new BigBoat();
        }
    }
}
