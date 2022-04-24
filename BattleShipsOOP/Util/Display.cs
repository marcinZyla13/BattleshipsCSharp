using System;
using System.Collections.Generic;


namespace BattleShipsOOP
{
    public static class Display
    {
        private static string _alphabet => MatchAlphabet();
        private static string _horizontalBorderLine => GenerateHorizontalBorderLine();


        public static void DisplayBattleFields(List<Cell> cells)
        {
            Console.Clear();
            Display_Defence(cells);
            Console.WriteLine("");
            Display_Attack(cells);
            Status.Info(24);
            Console.ReadKey();
            Console.Clear();
        }



        public static void Display_Defence(List<Cell> cells) 
        {
            DisplaySign();
            Console.WriteLine(_alphabet);
            Console.Write(_horizontalBorderLine);
            Console.WriteLine("");
            int counter = 0;
            int counter2 = 1;
            Console.Write(" 1 |");
            foreach (var item in cells)
            {
                if (item.ShowDefenceStatus() == CellStatus.Destroyed)
                {
                    Console.Write("X");
                    Console.Write(' ');
                }
                else if (item.ShowDefenceStatus() == CellStatus.Missed)
                {
                    Console.Write("*");
                    Console.Write(' ');
                }
                else if (item.HasAShip())
                {
                    Console.Write("#");
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(" "); 
                    Console.Write(' ');
                }
                counter+=1;
                
                if (counter >= Board.Instance._boardLength)
                {
                    counter2+=1;
                    Console.WriteLine("");
                    if(counter2 <= Board.Instance._boardLength)
                    {
                        if (counter2 < 10)
                            Console.Write(" {0} |", counter2);
                        else
                            Console.Write("{0} |", counter2);
                    }
                    
                    counter = 0;
                    
                }

            }
        }


        private static void Display_Attack(List<Cell> cells)
        {
            Console.WriteLine(_alphabet);
            Console.Write(_horizontalBorderLine);
            Console.WriteLine("");
            int counter = 0;
            int counter2 = 1;
            Console.Write(" 1 |");
            foreach (var item in cells)
            {
                if (item.ShowAttackStatus() == CellStatus.Destroyed)
                {
                    Console.Write("X");
                    Console.Write(' ');
                }
                else if (item.ShowAttackStatus() == CellStatus.Missed)
                {
                    Console.Write("*");
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(" ");
                    Console.Write(' ');
                }
                counter+=1;

                if (counter >= Board.Instance._boardLength)
                {
                    counter2+=1;
                    Console.WriteLine("");
                    if (counter2 <= Board.Instance._boardLength)
                    {
                        if (counter2 < 10)
                            Console.Write(" {0} |", counter2);
                        else
                            Console.Write("{0} |", counter2);
                    }

                    counter = 0;

                }

            }
        }



        private static string MatchAlphabet()
        {
            string alphabet = "ABCDEFGHIJKLMNO";
            string alph = default;
            alph+="    ";
            for(int x= 0;x<Board.Instance._boardLength;x++)
            {
                alph += alphabet[x];
                alph +=" ";
            }
            return alph;

        }

        private static string GenerateHorizontalBorderLine()
        {
            string borderLine = "    ";
            for(int x = 0;x <(Board.Instance._boardLength*2)-1;x++)
            {
                borderLine+="_";
            }
            return borderLine;
        }



        public static void DisplayIntro()
        {
            Console.WriteLine("                                                         "+
                        "                                                                  " +
                        "                                        \n" +
                        "                                      \\/\n" +
                        "                                      / ---\n" +
                        "                                     / | [\n" +
                        "                              !      | |||\n" +
                        "                            _/|     _/|-++'\n" +
                        "                        +  +--|    |--|--|_ |-\n" +
                        "                     { /|__|  |/\\__|  |--- |||__/\n" +
                        "                    +---------------___[}-_===_.'____                 /\\\n" +
                        "                ____`-' ||___-{]_| _[}-  |     |_[___\\==--            \\/   _\n" +
                        " __..._____--==/___]_|__|_____________________________[___\\==--____,------' .\n" +
                        "|                                                                           /\n" +
                        " \\_________________________________________________________________________|");

        }

        public static void DisplaySign()
        {
                        Console.WriteLine( "    ____     _   _____  _____  _      _____  ____   _   _  ___  ____  \n" +
                            "   | __ )   / \\ |_   _||_   _|| |    | ____|/ ___| | | | ||_ _||  _ \\ \n" +
                            "   |  _ \\  / _ \\  | |    | |  | |    |  _|  \\___ \\ | |_| | | | | |_) |\n" +
                            "   | |_) |/ ___ \\ | |    | |  | |___ | |___  ___) ||  _  | | | |  __/ \n" +
                            "   |____//_/   \\_\\|_|    |_|  |_____||_____||____/ |_| |_||___||_|    \n" +
                            "                                                                      ");

        }




    }
}
