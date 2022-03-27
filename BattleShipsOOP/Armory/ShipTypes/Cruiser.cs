using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP.Armory
{
    internal class Cruiser:Ship
    {
        public Cruiser(ShipType shipType,ShipStatus shipStatus)
            :base(shipType, shipStatus)
        {

        }
    }
}
