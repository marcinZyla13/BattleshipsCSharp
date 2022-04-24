using System;
using System.Collections.Generic;


namespace BattleShipsOOP
{
    public class Menu
    {

        private int _boardSize;

        private string _playerName;


        public Menu()
        {
            
            EnterTheName();
            ChooseBoardSize();
        }

        public void EnterTheName()
        {
            Console.Write("                        "); Display.DisplayIntro();
            Status.Info(3);
            Status.Info(21);
            _playerName = Console.ReadLine();
        }


        public string GiveTheName()
        {
            return _playerName;
        }

        public int GiveBoardSize()
        {
            return _boardSize;
        }

       

        private void ChooseBoardSize()
        {
            Display.DisplayIntro();
            var rangeOfMenuOptions = (7,15);
            Status.Info(11);
            StepBack:
            string boardSize = Console.ReadLine();
            if(int.TryParse(boardSize, out int size))
            {
                if(ValidateInput(rangeOfMenuOptions,boardSize))
                {
                        _boardSize = size;
                        return;                     
                }
            }
            goto StepBack;
        }
  

        private bool ValidateInput((int min,int max)options,string userInput)
        {
            List<string> rangeofChoices = new List<string>();
            for(int x = options.min; x<= options.max; x++)
            {
                rangeofChoices.Add(Convert.ToString(x));
            }
            if (rangeofChoices.Contains(userInput))
                return true;
            return false;
        }

    }
}
