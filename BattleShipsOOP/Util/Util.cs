using BattleShipsOOP.Armory;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BattleShipsOOP
{
    public class Util
    {
        private double _boardLength;

        public Util()
        {
            _boardLength = Status._boardSize;
        }

        public List<Coords> CreateCords()
        {
            List<Coords> cords = new List<Coords>();
            for (int x = 0; x < _boardLength; x++)
            {
                for (int y = 0; y < _boardLength; y++)
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

        public (Coords,string) AI_GenerateCords(ShipType shipType)
        {
            int shipSize = (int)shipType;

            int x = default;
            int y = default;
            var boardSize = Board.Instance._boardLength;

            Random random = new Random();

            dynamic direction = random.Next(0, 2);

            if (direction%2 ==0)

                direction = "H";
            else
                direction = "V";

            if (direction == "V")
            {
                x = random.Next(shipSize-1, (int)boardSize);
                y = random.Next(0, (int)boardSize);
            }
            else
            {
                x = random.Next(0, (int)boardSize);
                y = random.Next(0, (int)boardSize-shipSize);
            }


            return (new Coords(x, y),direction);

        }

        public void SetYourFleet(List<Cell> cells,Fleet fleet,bool ai)
        {
            Status.Info(12);
            if(ai == false)
                Display.Display_Defence(cells);
            dynamic coordsAndDirection;
            while (true)
            {
                Status.Info(13);
                if(ai == false)
                {
                     coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                }
                else
                {
                    coordsAndDirection = AI_GenerateCords(ShipType.Cruiser);
                }
                    

                ResponseObject response = CheckIfPlacementIsPassible((int)ShipType.Cruiser, coordsAndDirection, cells);
                if(response.Success())
                {
                    Cruiser cruiser = new Cruiser(ShipType.Cruiser, ShipStatus.Untouched);
                    foreach (var item in response.ShipPosition())
                    {
                        item.AddShip(cruiser);
                        
                    }
                    fleet.AddShip(cruiser);
                    break;
                } 
            }
            if (ai == false)
                Display.Display_Defence(cells);
            Console.WriteLine("");
            while (true)
            {
                Status.Info(14);
                if (ai == false)
                {
                    coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                }
                else
                {
                    coordsAndDirection = AI_GenerateCords(ShipType.Submarine);
                }
                ResponseObject response = CheckIfPlacementIsPassible((int)ShipType.Submarine, coordsAndDirection, cells);
                if (response.Success())
                {
                    Submarine submarine = new Submarine(ShipType.Destroyer, ShipStatus.Untouched);
                    foreach (var item in response.ShipPosition())
                    {
                        item.AddShip(submarine);
                        
                    }
                    fleet.AddShip(submarine);
                    break;
                }

            }
            if (ai == false)
                Display.Display_Defence(cells);
            Console.WriteLine("");
            while (true)
            {
                Status.Info(15);
                if (ai == false)
                {
                    coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                }
                else
                {
                    coordsAndDirection = AI_GenerateCords(ShipType.Destroyer);
                }
                ResponseObject response = CheckIfPlacementIsPassible((int)ShipType.Destroyer, coordsAndDirection, cells);
                if (response.Success())
                {
                    Destroyer destroyer = new Destroyer(ShipType.Submarine, ShipStatus.Untouched);
                    foreach (var item in response.ShipPosition())
                    {
                        item.AddShip(destroyer);
                        
                    }
                    fleet.AddShip(destroyer);
                    break;
                }                          
            }
            Console.WriteLine("");
            if (ai == false)
                Display.Display_Defence(cells);
        }

        private ResponseObject CheckIfPlacementIsPassible(int shipSize, (Coords, string)? coordsAndDirection, List<Cell> cells)
        {
            if(coordsAndDirection == null)
                return new ResponseObject(false);
            var coords = coordsAndDirection.Value.Item1;
            string direction = coordsAndDirection.Value.Item2;
            List<Cell> ShipPosition = new List<Cell>();


            if (coords.GetX() >= _boardLength || coords.GetY() >= _boardLength)
                return new ResponseObject(false);
            if (direction == "V")
            {
                for (int i = 0; i < shipSize; i++)
                {
                    foreach (var item in cells)
                    {
                        if (item.FindCellBasingOnXYCoords(coords.GetX()-i, coords.GetY()))
                        {
                            if (item.HasAShip() || CheckOnColision(item, "V", cells))
                                return new ResponseObject(false);
                            ShipPosition.Add(item);
                        
                        }

                    }

                }
            }
            if (direction == "H")
            {
                for (int i = 0; i < shipSize; i++)
                {
                    foreach (var item in cells)
                    {
                        if (item.FindCellBasingOnXYCoords(coords.GetX(), coords.GetY()+i))
                        {
                            if (item.HasAShip() || CheckOnColision(item, "H", cells))
                                return new ResponseObject(false);
                            ShipPosition.Add(item);
                        }

                    }
                }
            }
            if(ShipPosition.Count() < shipSize)
                return new ResponseObject(false);
            return new ResponseObject(true, ShipPosition);

        }
        private bool CheckOnColision(Cell cell,string direction,List<Cell>cells) 
        {
            Coords coords = cell.ShowCoords();
            if(direction == "H")
            {
                foreach (var item in cells)
                {
                    if(item.FindCellBasingOnXYCoords(coords.GetX()-1, coords.GetY()) ||
                       item.FindCellBasingOnXYCoords(coords.GetX()+1, coords.GetY()) ||
                       item.FindCellBasingOnXYCoords(coords.GetX(), coords.GetY()-1))
                    {
                        if (item.HasAShip())
                            return true;
                    }             
                }
            }
            else
            {
                foreach (var item in cells)
                {
                    if(item.FindCellBasingOnXYCoords(coords.GetX(), coords.GetY()+1) ||
                       item.FindCellBasingOnXYCoords(coords.GetX(), coords.GetY()-1) ||
                       item.FindCellBasingOnXYCoords(coords.GetX()+1, coords.GetY()))
                    {
                        if (item.HasAShip())
                            return true;
                    }                    

                }
            }
            return false;
        }


        private (Coords,string)? CollectCoordinatesAndGenerateCoordsObject()
        {
            Status.Info(16);
            string shipCore = Console.ReadLine();
            Status.Info(17);
            string direction = Console.ReadLine();
            if (ValidateUserInput(shipCore, direction,"launch phase"))
            {
                return (ConvertCoords(shipCore), direction.ToUpper());
            }
            return null;


        }

        public Coords ConvertCoords(string shipCore)
        {
            string alphabet = "ABCDEFGHIJKLMNO";
            int x = alphabet.IndexOf(Convert.ToString(shipCore[0]).ToUpper());
            int y = default;
            if (shipCore.Length == 2)
               y = shipCore[1]-'0';
            else
            {
               string numbersInCoords =  shipCore.Substring(1, 2);
               int.TryParse(numbersInCoords, out int afterParse);
               y = afterParse;
            }
                
            return new Coords(y-1, x);

        }


        public bool ValidateUserInput(string shipCore,string direction, string phase)
        {
            string alphabet = "ABCDEFGHIJKLMNO";
            string compare = default;

            if (shipCore.Length < 2 || shipCore.Length > 3)
                return false;


            for (int z = 0; z< _boardLength; z++)
            {
                compare += alphabet[z];
            }

            if (!compare.Contains(Convert.ToString(shipCore[0]).ToUpper()))
                return false;

            compare = "VH";
            if(phase == "launch phase")
            {
                if (direction.Length != 1 || !compare.Contains(direction.ToUpper()))
                    return false;
            }
            
            if (shipCore.Length == 2)
                if (int.TryParse(Convert.ToString(shipCore[1]), out int coord))
                {
                    if (coord >0 || coord<= _boardLength)
                        return true;
                }
                else
                    return false;

            if (shipCore.Length == 3)
            {
                if (int.TryParse(Convert.ToString(shipCore[1]+shipCore[2]), out int coord))
                {
                    if (coord >0 || coord<= _boardLength)
                        return true;
                }
                else
                    return false;

            }
            return false;
        }

      


    }
}
