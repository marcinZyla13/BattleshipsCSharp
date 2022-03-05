using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal class Player
    {
        private List<Fleet> _fleet;
        private PlayerStatus _status;
        private List<Coords> _defenceCoords;
        private List<Coords> _attackCoords;
        private bool _isPrepared;

        public Player(PlayerStatus playerStatus)
        {
            _status = playerStatus;
            _defenceCoords = new List<Coords>();
            _attackCoords = new List<Coords>();
            _isPrepared = false;

        }

        public bool IsPrepared()
        {
            return _isPrepared;
        }
        public List<Coords> ReturnDefenceList()
        {
            return _defenceCoords;
        }

        public List<Coords> ReturnAttackList()
        {
            return _attackCoords;
        }

        public PlayerStatus ReturnStatus()
        {
            return _status; 
        }

        public void CheckIfPlayerIsReady()
        {
            if(_fleet != null)
            {
                _isPrepared = true;
                Status.Info(9);
            }
            else
            {
                _isPrepared = false;
                Status.Info(10);
            }
                       
        }
    }

   
}
