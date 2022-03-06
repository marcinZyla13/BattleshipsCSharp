using System;
using System.Collections.Generic;

namespace BattleShipsOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Play play = new Play();
            play.PrepareGame();
        }
    }
    internal class Play
    {
        public void PrepareGame()
        {
            Menu menu = new Menu();
            Util util = new Util();

            Player player1 = new Player(PlayerStatus.player_1);
            Fleet fleet_1 = new Fleet(PlayerStatus.player_1);
            var coords_1 = util.CreateCords(menu.GiveBoardSize());
            var cells_1 = util.CreateCells(coords_1);
           

            Player player2 = new Player(PlayerStatus.player_2);
            Fleet fleet_2 = new Fleet(PlayerStatus.player_2);
            var coords_2 = util.CreateCords(menu.GiveBoardSize());
            var cells_2 = util.CreateCells(coords_2);

            Board.AddCells(cells_1, cells_2);

        }
        

       
    }
        

}
