using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal static class Status
    {
        public static void Info(int informationId)
        {
            switch(informationId)
            {
                case 0:
                    Console.WriteLine("With who You want to play ?");
                    Console.WriteLine();
                    Console.WriteLine("Press '1' to Play with other player");
                    Console.WriteLine("Press '2' to Play with AI");
                    Console.WriteLine("Press '3' to Quit the game");
                    break;
                case 1:
                    Console.WriteLine("No such a option, try again");
                    break;
                case 3:
                    Console.WriteLine("Cells have been added");
                    break;
                case 4:
                    Console.WriteLine("No space for more units");
                    break;
                case 5:
                    Console.WriteLine("Unit has been added");
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
                    Console.WriteLine("Choose the size of the battlefield : ");
                    Console.WriteLine("Min. '5' / Max. '15'");
                    break;
         
            }

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

  
}
    