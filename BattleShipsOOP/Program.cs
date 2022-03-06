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

            Board board = Board.Instance;
            var coords = Util.CreateCords(10);
            var cells = Util.CreateCells(coords);
            Util.Display(cells);

        }
        

       
    }
        

}
