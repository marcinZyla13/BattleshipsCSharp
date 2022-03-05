using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal class Game
    {
        public Menu _menu;
        public Player _player_1;
        public Player _player_2;
        public Board _board;
        public bool _isReady;

        public Game(Menu menu,Player player_1,Player player_2)
        {
            _board = Board.Instance;
            _menu = menu;
            _player_1 = player_1;
            _player_2 = player_2;
            _isReady = false;

        }

        public bool CheckIfGameIsReady()
        {
            if (_menu == null)
                return false;
            if (_board == null)
                return false;
            if (_player_1 == null)
                return false;
            if (_player_2 == null)
                return false;
            return true;
        }

    }
}
