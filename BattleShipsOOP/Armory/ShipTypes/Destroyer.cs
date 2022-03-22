using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP.Armory
{
    internal class Destroyer:Ship
    {
        public Destroyer(ShipType shipType, ShipStatus shipStatus/*, List<Coords> coordinates*/)
            : base(shipType, shipStatus/*, coordinates*/)
        {

        }
    }
}
