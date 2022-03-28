using BattleShipsOOP.Armory;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BattleShipsOOP
{
    internal class Util
    {
        public double _boardLength;

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

        

        public void SetYourFleet(List<Cell> cells,Fleet fleet)
        {
            Status.Info(12);
            Display.Display_Defence(cells);
            while (true)
            {
                Status.Info(13);
                (Coords,string)? coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                ResponseObject response = CheckIfPlacementIsPassible((int)ShipType.Cruiser, coordsAndDirection, cells);
                if(response.Success())
                {
                    Cruiser cruiser = new Cruiser(ShipType.Cruiser, ShipStatus.untouched);
                    foreach (var item in response.ShipPosition())
                    {
                        item.AddShip(cruiser);
                        
                    }
                    fleet.AddShip(cruiser);
                    break;
                } 
            }
            Display.Display_Defence(cells);
            Console.WriteLine("");
            while (true)
            {
                Status.Info(14);
                (Coords,string)? coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                ResponseObject response = CheckIfPlacementIsPassible((int)ShipType.Submarine, coordsAndDirection, cells);
                if (response.Success())
                {
                    Submarine submarine = new Submarine(ShipType.Destroyer, ShipStatus.untouched);
                    foreach (var item in response.ShipPosition())
                    {
                        item.AddShip(submarine);
                        
                    }
                    fleet.AddShip(submarine);
                    break;
                }

            }
            Display.Display_Defence(cells);
            Console.WriteLine("");
            while (true)
            {
                Status.Info(15);
                (Coords,string)? coordsAndDirection = CollectCoordinatesAndGenerateCoordsObject();
                ResponseObject response = CheckIfPlacementIsPassible((int)ShipType.Destroyer, coordsAndDirection, cells);
                if (response.Success())
                {
                    Destroyer destroyer = new Destroyer(ShipType.Submarine, ShipStatus.untouched);
                    foreach (var item in response.ShipPosition())
                    {
                        item.AddShip(destroyer);
                        
                    }
                    fleet.AddShip(destroyer);
                    break;
                }                          
            }
            Console.WriteLine("");
            Display.Display_Defence(cells);
        }

        private ResponseObject CheckIfPlacementIsPassible(int shipSize, (Coords, string)? coordsAndDirection, List<Cell> cells)
        {
            if(coordsAndDirection == null)
                return new ResponseObject(false);
            var coords = coordsAndDirection.Value.Item1;
            string direction = coordsAndDirection.Value.Item2;
            List<Cell> ShipPosition = new List<Cell>();


            if (coords.Y() >= _boardLength || coords.Y() >= _boardLength)
                return new ResponseObject(false);
            if (direction == "V")
            {
                for (int i = 0; i < shipSize; i++)
                {
                    foreach (var item in cells)
                    {
                        if (item.FindCellBasingOnXYCoords(coords.X()-i, coords.Y()))
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
                        if (item.FindCellBasingOnXYCoords(coords.X(), coords.Y()+i))
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
            if(direction == "V")
            {
                foreach (var item in cells)
                {
                    if(item.FindCellBasingOnXYCoords(coords.X()-1, coords.Y()) ||
                       item.FindCellBasingOnXYCoords(coords.X()+1, coords.Y()) ||
                       item.FindCellBasingOnXYCoords(coords.X(), coords.Y()+1))
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
                    if(item.FindCellBasingOnXYCoords(coords.X(), coords.Y()+1) ||
                       item.FindCellBasingOnXYCoords(coords.X(), coords.Y()-1) ||
                       item.FindCellBasingOnXYCoords(coords.X()+1, coords.Y()))
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
