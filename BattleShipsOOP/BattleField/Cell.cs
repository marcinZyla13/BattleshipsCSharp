
namespace BattleShipsOOP
{
    public class Cell
    {
        private Coords _coord;
        private CellStatus _attackStatus;
        private CellStatus _defenceStatus;
        private Ship _ship;


        public Cell(Coords coord)
        {
            _coord = coord;
            _attackStatus = CellStatus.Neutral;
            _defenceStatus = CellStatus.Neutral;
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
            if (_coord.GetX() == x && _coord.GetY() == y)
                return true;
            return false;

        }

        public bool HasAShip()
        {
            return _ship != null;
        }

        public Ship RevealTheShip()
        {
            return _ship;
        }
    }
}

public enum CellStatus
{
    Missed,
    Destroyed,
    Neutral,
}
