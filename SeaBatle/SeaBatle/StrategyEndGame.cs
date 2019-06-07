using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    //strategy
    class StrategyEndGame
    {
        public Unit unit1;
        public Unit unit2;
        public StrategyEndGame(Unit u1,Unit u2)
        {
            unit1 = u1;
            unit2 = u2;
        }
        public bool CheckForEnd()
        {
            return (unit1.IsEmptyList() || unit2.IsEmptyList());
        }
        public void SetStrategy()
        {
            if (unit1.IsEmptyList())
            {
                unit1.SetEnd(new LoseGame());
                unit2.SetEnd(new WinGame());
            }
            else
            {
                unit2.SetEnd(new LoseGame());
                unit1.SetEnd(new WinGame());
            }
        }

    }
    interface IEndGame
    {
        void EndGame();
    }

    class WinGame : IEndGame
    {
        public void EndGame()
        {

        }
    }
    class LoseGame : IEndGame
    {
        public void EndGame()
        {

        }
    }
}
