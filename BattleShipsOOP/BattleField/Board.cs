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
        public static List<Cell> _player_1_cells;
        public static List<Cell> _player_2_cells;
        public double _boardLength = Math.Sqrt(_player_1_cells.Count);

        Board()
        {
            
        }

        public static void AddCells(List<Cell>player_1_cells,List<Cell>player_2_cells)
        {
            _player_1_cells = player_1_cells;
            _player_2_cells = player_2_cells;
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
