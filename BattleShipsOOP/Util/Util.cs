using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal class Util
    {

        public List<Coords> CreateCords(int size)
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

        public  List<Cell> CreateCells(List<Coords> cords)
        {
            List<Cell> cells = new List<Cell>();
            foreach (var item in cords)
            {
                cells.Add(new Cell(item));
            }
            return cells;

        }

        public  void Display(List<Cell> cells)
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

        public void SetYourFleet(List<Cell> cells, int boardSize)
        {
            Status.Info(12);
            while (true)
            {
                Console.WriteLine("Cruiser(3): ");
                var coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject(boardSize);
                var coords = coordsAndDirection.Value.Item1;
                var direction = coordsAndDirection.Value.Item2;

                /// Funkcja walidujcąca czy można położyć statek na danym miejscu mapy 
                /// jeżeli się da , przypisanie do Fieldów danych statków 
                /// Dużo pracy z walidacją ułożenia statku w danej lokalizacji
                break;

            }
            while (true)
            {
                Console.WriteLine("Submarine(4): ");
                var coords = CollectCoordinatesAndGenerateCoordsObject(boardSize);
                break;

            }
            while (true)
            {
                Console.WriteLine("Destroyer(5): ");
                var coords = CollectCoordinatesAndGenerateCoordsObject(boardSize);
                break;

            }
        }

       

        private (Coords,string)? CollectCoordinatesAndGenerateCoordsObject(int boardSize)
        {
            Console.WriteLine("Choose coordinates for ship core : (example 'A6')");
            string shipCore = Console.ReadLine();
            Console.WriteLine("Choose direction : ('v' or 'h')");
            string direction = Console.ReadLine();
            if (ValidateUserInput(shipCore, direction, boardSize))
            {
                return (ConvertCoords(shipCore), direction);
            }
            return null;


        }

        private Coords ConvertCoords(string shipCore)
        {
            string alphabet = "ABCDEFGHIJKLMNO";
            int x = alphabet.IndexOf(shipCore[0]);
            int y = default;
            if (shipCore.Length == 2)
                y = Convert.ToInt32(shipCore[1]);
            else
                y = Convert.ToInt32(shipCore[1]+shipCore[2]);
            return new Coords(x, y);

        }


        private bool ValidateUserInput(string shipCore, string direction, int boardSize)
        {
            string alphabet = "ABCDEFGHIJKLMNO";
            string compare = default;

            if (shipCore.Length < 2 || shipCore.Length > 3)
                return false;


            for (int z = 0; z<boardSize; z++)
            {
                compare += alphabet[z];
            }

            if (!compare.Contains(Convert.ToString(shipCore[0]).ToUpper()))
                return false;

            compare = "VH";
            if (direction.Length != 1 || !compare.Contains(direction.ToUpper()))
                return false;

            if (shipCore.Length == 2)
                if (int.TryParse(Convert.ToString(shipCore[1]), out int coord))
                {
                    if (coord >0 || coord<=boardSize)
                        return true;
                }
                else
                    return false;

            if (shipCore.Length == 3)
            {
                if (int.TryParse(Convert.ToString(shipCore[1]+shipCore[2]), out int coord))
                {
                    if (coord >0 || coord<=boardSize)
                        return true;
                }
                else
                    return false;

            }
            return false;
        }


    }
}
