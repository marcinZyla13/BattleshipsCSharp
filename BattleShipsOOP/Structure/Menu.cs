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
        private string _enemy;

        private int _boardSize;


        public Menu()
        {
            ChooseEnemy();
            ChooseBoardSize();
        }

        public string ShowTheEnemy()
        {
            return _enemy;
        }

        public int GiveBoardSize()
        {
            return _boardSize;
        }

        public void ChooseEnemy()
        {
            int amountOfMenuOptions = 3;
            Status.Info(0);
            while(true)
            {
                string enemy = Console.ReadLine();
                if (ValidateInput(amountOfMenuOptions, enemy))
                {
                    _enemy = enemy;
                    return;
                }
                Status.Info(1);
            }            
        }

        public void ChooseBoardSize()
        {
            int amountOfMenuOptions = 11;
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
  

        public bool ValidateInput(int options,string userInput)
        {
            List<string> rangeofChoices = new List<string>();
            for(int x =1; x<= options; x++)
            {
                rangeofChoices.Add(Convert.ToString(x));
            }
            if (rangeofChoices.Contains(userInput))
                return true;
            return false;
        }

    }
}
