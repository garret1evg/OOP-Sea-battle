using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class ShootingTurn
    {
        private Unit unitShooting;
        private Unit unitDefending;
        private ITurnState state;
        public ShootingTurn (Unit unit1, Unit unit2)
        {
            unitShooting = unit1;
            unitDefending = unit2;
        }
        public void SwapUnits()
        {
            Unit tmp= unitShooting;
            unitShooting = unitDefending;
            unitDefending = tmp;
        }
        private void EndTurn()
        {
            state.EndTurn(this);
        }
        public void Do()
        {
            int[] coord = unitShooting.Shoot();
            Status status = unitDefending.CheckHit(coord[0],coord[1]);
            unitShooting.ShootReport(status,coord[0], coord[1]);
            if (status == Status.miss)
                state = new MissState();
            else
                state = new HitState();
            if (status == Status.destroyed)
            {
                unitDefending.ShipBlow(unitDefending.myMap.GetShip(coord[0], coord[1]));
            }
                this.EndTurn();
        }

    }
    //state
    interface ITurnState
    {
        void EndTurn(ShootingTurn turn);
    }

    class HitState : ITurnState
    {
        public void EndTurn(ShootingTurn turn)
        {

        }
    }
    class MissState : ITurnState
    {
        public void EndTurn(ShootingTurn turn)
        {
            turn.SwapUnits();
        }
    }
}
