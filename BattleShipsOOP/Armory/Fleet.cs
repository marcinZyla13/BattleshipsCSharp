
using System;
using System.Collections.Generic;


namespace BattleShipsOOP
{
    public class Fleet
    {

        private List<Ship> _shipList;



        public Fleet()
        {
            _shipList = new List<Ship>();

        }

        public List<Ship> ProvideFleet()
        {
            return _shipList;
        }

        public bool CheckEndGameConditions()
        {
            return _shipList.Count<=0;
        }


        public void AddShip(Ship ship)
        {
            if (ValidateFleetProcess(ship))
            {
                _shipList.Add(ship);
                Status.Info(5);
            }

        }

        private bool ValidateFleetProcess(Ship ship)
        {
            if (ship == null)
            {
                Status.Info(7);
                return false;
            }
            if (_shipList.Count > 3)
            {
                Status.Info(4);
                return false;
            }
            if (_shipList.Contains(ship))
            {
                Status.Info(6);
                return false;
            }
            return true;
        }

    }


}
