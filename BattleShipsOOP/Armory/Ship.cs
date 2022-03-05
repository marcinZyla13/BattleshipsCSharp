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
        public Ship(ShipType shipType,ShipStatus shipStatus,List<Coords>coordinates)
        {
            _shipType = shipType;
            _shipStatus = shipStatus;
            _coordinates = coordinates;
        }
        
    }
}

enum ShipType
{
    Cruiser = 3,
    Submarine =4,
    Destroyer = 5,
}
