﻿
using System.Collections.Generic;


namespace BattleShipsOOP
{
    internal class Player
    {
        private Fleet _fleet;
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

        public void AddFleet(Fleet fleet)
        {
            _fleet = fleet;
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

        public bool CheckIfPlayerLost()
        {
            return _fleet.CheckEndGameConditions();
        }
    }

   
}
