using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal class Menu
    {
        private Enemy _enemy;

        private int _boardSize;

        private string _playerName;


        public Menu()
        {
            //EnterTheName();
            //ChooseEnemy();
            ChooseBoardSize();
        }

        public void EnterTheName()
        {
            Status.Info(21);
            _playerName = Console.ReadLine();
        }

        public Enemy ShowTheEnemy()
        {
            return _enemy;
        }

        public string GiveTheName()
        {
            return _playerName;
        }

        public int GiveBoardSize()
        {
            return _boardSize;
        }

        private void ChooseEnemy()
        {
            Status.Info(22); Console.Write(GiveTheName());
            int amountOfMenuOptions = 3;
            Status.Info(0);
            while(true)
            {
                string enemy = Console.ReadLine();
                if (ValidateInput(amountOfMenuOptions, enemy))
                {
                    if (enemy == "1")
                        _enemy = Enemy.player;
                    else
                        _enemy = Enemy.AI;
                    return;
                }
                Status.Info(1);
            }            
        }

        private void ChooseBoardSize()
        {
            int amountOfMenuOptions = 15;
            Status.Info(11);
            StepBack:
            string boardSize = Console.ReadLine();
            if(int.TryParse(boardSize, out int size))
            {
                if(ValidateInput(amountOfMenuOptions,boardSize))
                {
                        _boardSize = size;
                        return;                     
                }
            }
            goto StepBack;
        }
  

        private bool ValidateInput(int options,string userInput)
        {
            List<string> rangeofChoices = new List<string>();
            for(int x =5; x<= options; x++)
            {
                rangeofChoices.Add(Convert.ToString(x));
            }
            if (rangeofChoices.Contains(userInput))
                return true;
            return false;
        }

    }
}
