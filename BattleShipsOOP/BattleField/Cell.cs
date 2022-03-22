using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal class Cell
    {
        private Coords _coord;
        private CellStatus _attackStatus;
        private CellStatus _defenceStatus;
        private Ship _ship;
        public Sign sign;

        public Cell(Coords coord)
        {
            _coord = coord;
            _attackStatus = CellStatus.neutral;
            _defenceStatus = CellStatus.neutral;
        }

        public void AddShip(Ship ship)
        {
           _ship = ship;
        }

        public void ChangeDefenceStatus(CellStatus status)
        {
            _defenceStatus = status;
        }

        public void ChangeAttackStatus(CellStatus status)
        {
            _attackStatus = status;
        }

        public CellStatus ShowDefenceStatus()
        {
            return _defenceStatus;
        }

        public CellStatus ShowAttackStatus()
        {
            return _attackStatus;
        }

        public Coords ShowCoords()
        {
            return _coord;
        }
        
        public bool FindCellBasingOnXYCoords(int x ,int y)
        {
            if (_coord.X() == x && _coord.Y() == y)
                return true;
            return false;

        }

        public bool HasAShip()
        {
            return _ship != null;
        }
    }
}
