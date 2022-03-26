using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP.Armory
{
    internal class WeaponModule
    {
        private Coords _coords;

        private Cell _defender;

        private Cell _attacker;

        private Util _util;


        public WeaponModule(Util util)
        {
            _util = util;
        }

        public void OpenFire(List<Cell> defender, List<Cell> attacker)
        {
            EnterAttackLocation();
            Aim(defender, attacker);
            Fire();
        }


        private void EnterAttackLocation()
        {
            while (true)
            {
                Status.Info(18);
                string attackCoords = Console.ReadLine();
                if (_util.ValidateUserInput(attackCoords, null, "Battle"))
                {
                    _coords = _util.ConvertCoords(attackCoords);
                    break;
                }
            }

        }

        private Cell Aim(List<Cell> defender, List<Cell> attacker)
        {
            foreach (var item in defender)
            {
                if (item.FindCellBasingOnXYCoords(_coords.X(), _coords.Y()))
                {
                    _defender = item;
                }
            }
            foreach (var item in attacker)
            {
                if (item.FindCellBasingOnXYCoords(_coords.X(), _coords.Y()))
                {
                    _attacker = item;
                }
            }
            return null;

        }


        private void Fire()
        {
            if (_defender.HasAShip())
            {
                _defender.RevealTheShip().UpdateStatus();
                _defender.ChangeDefenceStatus(CellStatus.destroyed);

                _attacker.ChangeAttackStatus(CellStatus.destroyed);
            }
            else
            {
                _defender.ChangeDefenceStatus(CellStatus.missed);
                _attacker.ChangeAttackStatus(CellStatus.missed);
            }
            
        }
    }
}
