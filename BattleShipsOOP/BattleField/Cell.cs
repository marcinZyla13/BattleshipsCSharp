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
        private bool _status;

        public Cell(Coords coord)
        {
            _coord = coord;
            _status = false;
        }

        public void ChangeStatus()
        {
            _status = true;
        }
    }
}
