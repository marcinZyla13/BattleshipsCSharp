using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal static class Util
    {

        public static List<Coords> CreateCords(int size)
        {
            List<Coords> cords = new List<Coords>();
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    cords.Add(new Coords(x, y));
                }
            }
            return cords;

        }

        public static List<Cell> CreateCells(List<Coords> cords)
        {
            List<Cell> cells = new List<Cell>();
            foreach (var item in cords)
            {
                cells.Add(new Cell(item));
            }
            return cells;

        }

        public static void Display(List<Cell> cells)
        {
            for (int x = 0; x<Math.Sqrt(cells.Count); x++)
            {

                for (int y = 0; y<Math.Sqrt(cells.Count); y++)
                {
                    Console.Write('*');
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }


    }
}
