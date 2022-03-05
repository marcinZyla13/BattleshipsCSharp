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
                    break;
                case 1:
                    break;
                case 3:
                    Console.WriteLine("Cells have been added");
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
}
    