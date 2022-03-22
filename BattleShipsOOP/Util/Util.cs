using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal class Util
    {
        Board board = Board.Instance;

        public List<Coords> CreateCords()
        {
            List<Coords> cords = new List<Coords>();
            for (int x = 0; x < board._boardLength; x++)
            {
                for (int y = 0; y < board._boardLength; y++)
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

        public void SetYourFleet(List<Cell> cells)
        {
            Status.Info(12);
            while (true)
            {
                Status.Info(13);
                (Coords,string)? coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                CheckIfPlacementIsPassible((int)ShipType.Cruiser, coordsAndDirection,cells);
                             
                break;

            }
            while (true)
            {
                Status.Info(14);
                (Coords,string)? coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                CheckIfPlacementIsPassible((int)ShipType.Submarine, coordsAndDirection,cells);

                break;

            }
            while (true)
            {
                Status.Info(15);
                (Coords,string)? coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                CheckIfPlacementIsPassible((int)ShipType.Destroyer, coordsAndDirection,cells);
            
                break;

            }
        }

        private bool CheckIfPlacementIsPassible(int shipSize,(Coords,String)? coordsAndDirection,List<Cell>cells)
        {
            var coords =  coordsAndDirection.Value.Item1;
            string direction = coordsAndDirection.Value.Item2;


            if (coords.Y() >= board._boardLength || coords.Y() >= board._boardLength) // Czy jesteśmy na planszy ??Sprawdz czy potrzebne !!!
                return false;
            if(direction == "v")
            {
                
            }




            

            return true;
        }



        private (Coords,string)? CollectCoordinatesAndGenerateCoordsObject()
        {
            Status.Info(16);
            string shipCore = Console.ReadLine();
            Status.Info(17);
            string direction = Console.ReadLine();
            if (ValidateUserInput(shipCore, direction))
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


        private bool ValidateUserInput(string shipCore, string direction)
        {
            string alphabet = "ABCDEFGHIJKLMNO";
            string compare = default;

            if (shipCore.Length < 2 || shipCore.Length > 3)
                return false;


            for (int z = 0; z< board._boardLength; z++)
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
                    if (coord >0 || coord<= board._boardLength)
                        return true;
                }
                else
                    return false;

            if (shipCore.Length == 3)
            {
                if (int.TryParse(Convert.ToString(shipCore[1]+shipCore[2]), out int coord))
                {
                    if (coord >0 || coord<= board._boardLength)
                        return true;
                }
                else
                    return false;

            }
            return false;
        }


    }
}
