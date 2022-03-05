using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsOOP
{
    internal class Menu
    {
        public string _enemy;
        public Menu()
        {

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
