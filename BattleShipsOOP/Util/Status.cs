using System;


namespace BattleShipsOOP
{
    internal static class Status
    {
        public static double _boardSize;


        public static void Info(int informationId)
        {
            switch(informationId)
            {
                case 0:
                    Console.WriteLine("");
                    Console.WriteLine("With who You want to play ?");
                    Console.WriteLine();
                    Console.WriteLine("Press '1' to Play with other player");
                    Console.WriteLine("Press '2' to Play with AI   (not available)");
                    break;
                case 1:
                    Console.WriteLine("No such a option, try again");
                    break;
                case 3:
                    Console.WriteLine("   Welcome in BattleShips !!!");
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("No space for more units");
                    break;
                case 5:
                    Console.WriteLine("Unit has been added");
                    Console.Clear();
                    break;
                case 6:
                    Console.WriteLine("Unit has already been deplyed");
                    break;
                case 7:
                    Console.WriteLine("Looks like there is no ship");
                    break;
                case 9:
                    Console.WriteLine("Player is ready to play");
                    break;
                case 10:
                    Console.WriteLine("Player is not ready to play");
                    break;
                case 11:
                    Console.Clear();
                    Console.WriteLine("Choose the size of the battlefield : ");
                    Console.WriteLine("Min. '5' / Max. '15'");
                    break;
                case 12:
                    Console.Clear();
                    Console.WriteLine("You have 3 types of ships to place :");
                    Console.WriteLine(". => Cruiser   (3)");
                    Console.WriteLine(". => Sumbarine (4)");
                    Console.WriteLine(". => Destroyer (5)");
                    Console.WriteLine("Choose location using letter and number ex. 'A5' and accept using 'Enter'");
                    Console.WriteLine("Then choose if You want to place ship vertical or horizontal using 'v' or 'h'");
                    Console.WriteLine("If any location will be outside of the map or placing the ship will not be passible " +
                        "You will be asked to repeat the last process");
                    Console.WriteLine("");
                    break;
                case 13:
                    Console.WriteLine("");
                    Console.WriteLine("Cruiser(3): ");
                    break;
                case 14:
                    Console.WriteLine("");
                    Console.WriteLine("Submarine(4): ");
                    break;
                case 15:
                    Console.WriteLine("");
                    Console.WriteLine("Destroyer(5): ");
                    break;
                case 16:
                    Console.WriteLine("Choose coordinates for ship core : (example 'A6')");
                    break;
                case 17:
                    Console.WriteLine("Choose direction : ('v' or 'h')");
                    break;
                case 18:
                    Console.ReadKey();                   
                    Console.Clear();
                    Console.WriteLine("Press Any Key to continue");
                    Console.WriteLine("");
                    Console.WriteLine("Indicate the target's location");
                    break;
                case 19:
                    Console.Write(" Won the game !!!");
                    break;
                case 20:
                    Console.WriteLine("Player 2 Won the game !!!");
                    break;
                case 21:
                    Console.WriteLine("Enter Your Name :");
                    break;
                case 22:
                    Console.Clear();
                    Console.Write("Welcome ");
                    break;
                case 23:
                    Console.WriteLine("We are sorry but AI function is under construction....");
                    break;


            }          

        }
        public static void AddBoardSize(double boardSize)
        {
            _boardSize = boardSize;
        }
    }

    enum ShipStatus
    {
        untouched,
        hit,
        destroyed
    }

    enum PlayerStatus
    {
        player_1,
        player_2,
    }

    enum CellStatus
    {
        missed,
        destroyed,
        neutral,
    }

    enum Sign
    {
        O,
        X,
        M,
    }

    enum Enemy
    {
        player,
        AI
    }

    

  
}
    