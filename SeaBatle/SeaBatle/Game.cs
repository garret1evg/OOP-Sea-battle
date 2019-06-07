using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;

namespace SeaBatle
{
    class Game
    {
       
        Unit unit1;
        Unit unit2;
        TextBox textBox;

        public Game(Unit u1, Unit u2,TextBox textBox)
        {
            unit1 = u1;
            unit2 = u2;
            this.textBox = textBox;

        }
        public Unit CreateUnit(User user)
        {
            return new Unit(new Map(),new Map(),user,new ShipList());
        }
        public Unit Battle()
        {
            StrategyEndGame end = new StrategyEndGame(unit1, unit2);
            ShootingTurn turn = new ShootingTurn(unit1, unit2);
            do
            {
                turn.Do();
                textBox.Text = unit1.myMap.DrawToStr() + "\n\n\n" + unit2.myMap.DrawToStr();
                //Thread.Sleep(1000);



                
            } while (!end.CheckForEnd());
            return unit1;
        }
       
    }
    

}
