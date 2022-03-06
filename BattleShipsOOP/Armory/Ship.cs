using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal abstract class Ship
    {
        public ShipType _shipType;
        public ShipStatus _shipStatus;
        public List<Coords> _coordinates;
        public int _segments;
        public Ship(ShipType shipType,ShipStatus shipStatus,List<Coords>coordinates)
        {
            _shipType = shipType;
            _shipStatus = shipStatus;
            _coordinates = coordinates;
            _segments = (int)shipStatus;
        }

        public void CutSegement()
        {
            _segments--;
        }

        public void UpdateStatus()
        {
            if (_segments == 0)
                _shipStatus = ShipStatus.destroyed;
            else if (_segments == (int)_shipType)
                _shipStatus = ShipStatus.untouched;
            else
                _shipStatus = ShipStatus.hit;

        }      
    }
}

enum ShipType
{
    Cruiser = 3,
    Submarine =4,
    Destroyer = 5,
}
