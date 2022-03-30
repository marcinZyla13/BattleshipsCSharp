

namespace BattleShipsOOP
{
    public abstract class Ship
    {
        public ShipType _shipType;
        public ShipStatus _shipStatus;
        public int _segments;
        public Ship(ShipType shipType,ShipStatus shipStatus)
        {
            _shipType = shipType;
            _shipStatus = shipStatus;
            _segments = (int)shipStatus;
        }

        public void CutSegement()
        {
            _segments--;
        }

        public void UpdateStatus()
        {
            if (_segments == 0)
                _shipStatus = ShipStatus.Destroyed;
            else if (_segments == (int)_shipType)
                _shipStatus = ShipStatus.Untouched;
            else
                _shipStatus = ShipStatus.Hit;

        }      
    }
}

public enum ShipType
{
    Cruiser = 3,
    Submarine =4,
    Destroyer = 5,
}

public enum ShipStatus
{
    Untouched,
    Hit,
    Destroyed
}
