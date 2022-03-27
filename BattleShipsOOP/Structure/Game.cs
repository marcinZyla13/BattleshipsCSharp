using System;


namespace BattleShipsOOP
{
    internal class Game
    {
        public Menu _menu;
        public Player _player_1;
        public Player _player_2;
        public Board _board;
        public bool _isReady;
        public Util _util;

        public Game(Menu menu,Player player_1,Player player_2,Util util)
        {
            _board = Board.Instance;
            _menu = menu;
            _player_1 = player_1;
            _player_2 = player_2;
            _isReady = false;
            _util = util;

        }

        public void CheckIfGameIsReady()
        {
            if (_menu == null)
                return;
            if (_board == null)
                return;
            if (_player_1 == null)
                return;
            if (_player_2 == null)
                return;
            _isReady = true;
        }

        public void CheckGameStatus()
        {
            if (_isReady == false)
                throw new Exception("Sorry, there was an error in setting up the game... ");
        }

        public void IsTheGameFinnished()
        {
            if(_player_1.CheckIfPlayerLost())
            {
                Status.Info(20);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            if(_player_2.CheckIfPlayerLost())
            {
                Console.Write(_menu.GiveTheName());
                Status.Info(19);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }    

        }
    }
}
