using System;
using System.Collections.Generic;

namespace BattleShipsOOP.Armory
{
    public class WeaponModule
    {
        private Coords _coords;

        private Cell _defender;

        private Cell _attacker;

        private Util _util;


        public WeaponModule(Util util)
        {
            _util = util;
        }

        public void OpenFire(List<Cell> defender, List<Cell> attacker,bool ai)
        {
            if (ai == true)
                AiChooseAttackLocationLevelEasy();
            else
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

        private void AiChooseAttackLocationLevelEasy()
        {
            int boardSize = (int)Status._boardSize;
            Random random = new Random();
            int x = random.Next(0,boardSize);
            int y = random.Next(0, boardSize);
            _coords = new Coords(x, y);          
        }



        private void Aim(List<Cell> defender, List<Cell> attacker)
        {
            foreach (var item in defender)
            {
                if (item.FindCellBasingOnXYCoords(_coords.GetX(), _coords.GetY()))
                {
                    _defender = item;
                }
            }
            foreach (var item in attacker)
            {
                if (item.FindCellBasingOnXYCoords(_coords.GetX(), _coords.GetY()))
                {
                    _attacker = item;
                }
            }

        }

        private void Fire()
        {
            if (_defender.HasAShip())
            {
                _defender.RevealTheShip().CutSegement();
                _defender.RevealTheShip().UpdateStatus();

                _defender.ChangeDefenceStatus(CellStatus.Destroyed);

                _attacker.ChangeAttackStatus(CellStatus.Destroyed);
            }
            else
            {
                _defender.ChangeDefenceStatus(CellStatus.Missed);
                _attacker.ChangeAttackStatus(CellStatus.Missed);
            }
            
        }
    }
}
