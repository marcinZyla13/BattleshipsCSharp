using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal sealed class Board
    {
        private static Board instance = null;
        private static readonly object padlock = new object();
        public static List<Cell> _cells;

        Board()
        {
            
        }

        public static void AddCells(List<Cell>cells)
        {
            _cells = cells;
            Status.Info(3);
        }

        public static Board Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Board();
                    }
                    return instance;
                }
            }
        }
    }
}
