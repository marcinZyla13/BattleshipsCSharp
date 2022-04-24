using BattleShipsOOP.Armory;
using System;

namespace BattleShipsOOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Play play = new Play();
            play.PrepareGame();
            play.Battle();
        }
    }


    public class Play
    {
        public Game _game;

        public void PrepareGame()
        {

            Menu menu = new Menu();
            Status.AddBoardSize(menu.GiveBoardSize());          
            Util util = new Util();
            
            Player player = new Player();
            Fleet fleet_1 = new Fleet();
            var coords_1 = util.CreateCords();
            var cells_1 = util.CreateCells(coords_1);
            util.SetYourFleet(cells_1, fleet_1,false);
            player.AddFleet(fleet_1);

            Player player2 = new Player();
            Fleet fleet_2 = new Fleet();
            var coords_2 = util.CreateCords();
            var cells_2 = util.CreateCells(coords_2);
            util.SetYourFleet(cells_2, fleet_2,true);
            player2.AddFleet(fleet_2);

            Board.AddCells(cells_1, cells_2);

            Game game = new Game(menu,player ,player2,util);
            game.CheckIfGameIsReady();
            game.CheckGameStatus();
            _game = game;
                      
        }


        public void Battle()
        {
            Console.Clear();
            WeaponModule weaponSystem = new WeaponModule(_game._util);
            while (true)
            {
                weaponSystem.OpenFire(Board._player_2_cells, Board._player_1_cells,false);
                _game.ProvidePlayer("Player").CheckFleet();
                _game.IsTheGameFinnished();
                Display.DisplayBattleFields(Board._player_1_cells);


                weaponSystem.OpenFire(Board._player_1_cells, Board._player_2_cells, true);
                _game.IsTheGameFinnished();
                _game.ProvidePlayer("Ai").CheckFleet();
                Display.DisplayBattleFields(Board._player_1_cells);


            }

        }

       

        

    }
        

}
