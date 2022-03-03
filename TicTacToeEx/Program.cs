using System;
using System.Collections.Generic;

namespace TicTacToeEx
{
    internal class Program
    {
        private static char[,] playFields = {
        { '1', '2', '3'},
        { '4', '5', '6'},
        { '7', '8', '9'},
        };

        private static int turns = 0;

        private static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool valid = true;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(input, 'O');
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(input, 'X');
                }
                SetFields();

                #region
                //Check wining condition
                char[] playersChar = { 'X', 'O' };
                foreach (var playerChar in playersChar)
                {
                    if (((playFields[0, 0] == playerChar) && (playFields[0, 1] == playerChar) && (playFields[0, 2] == playerChar))
                        || ((playFields[1, 0] == playerChar) && (playFields[1, 1] == playerChar) && (playFields[1, 2] == playerChar))
                        || ((playFields[2, 0] == playerChar) && (playFields[2, 1] == playerChar) && (playFields[2, 2] == playerChar))
                        || ((playFields[0, 0] == playerChar) && (playFields[1, 0] == playerChar) && (playFields[2, 0] == playerChar))
                        || ((playFields[0, 1] == playerChar) && (playFields[1, 1] == playerChar) && (playFields[2, 1] == playerChar))
                        || ((playFields[0, 2] == playerChar) && (playFields[1, 2] == playerChar) && (playFields[2, 2] == playerChar))
                        || ((playFields[0, 0] == playerChar) && (playFields[1, 1] == playerChar) && (playFields[2, 2] == playerChar))
                        || ((playFields[0, 2] == playerChar) && (playFields[1, 1] == playerChar) && (playFields[2, 0] == playerChar))
                        )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 1 has won!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 2 has won!");
                        }
                        ResetFields();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("It's a Draw");
                        ResetFields();
                        break;
                    }
                }
                #endregion
                #region
                //Test if field is already taken
                do
                {
                    Console.Write($"Player {player}: Choose your field!");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("invalid please choose a number");
                    }

                    if ((input == 1) && (playFields[0, 0] == '1'))
                        valid = true;
                    else if ((input == 2) && (playFields[0, 1] == '2'))
                        valid = true;
                    else if ((input == 3) && (playFields[0, 2] == '3'))
                        valid = true;
                    else if ((input == 4) && (playFields[1, 0] == '4'))
                        valid = true;
                    else if ((input == 5) && (playFields[1, 1] == '5'))
                        valid = true;
                    else if ((input == 6) && (playFields[1, 2] == '6'))
                        valid = true;
                    else if ((input == 7) && (playFields[2, 0] == '7'))
                        valid = true;
                    else if ((input == 8) && (playFields[2, 1] == '8'))
                        valid = true;
                    else if ((input == 9) && (playFields[2, 2] == '9'))
                        valid = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect input! Please use another field!");
                        valid = false;
                    }
                } while (!valid);
                #endregion
            } while (true);
        }

        private static void ResetFields()
        {
            Console.WriteLine("Press any key for reset");
            Console.ReadKey();
            char[,] initialFields = {
                { '1', '2', '3'},
                { '4', '5', '6'},
                { '7', '8', '9'},
            };
            playFields = initialFields;
            SetFields();
            turns = 0;
        }

        private static void EnterXorO(int input, char playerSign)
        {
            switch (input)
            {
                case 1: playFields[0, 0] = playerSign; break;
                case 2: playFields[0, 1] = playerSign; break;
                case 3: playFields[0, 2] = playerSign; break;
                case 4: playFields[1, 0] = playerSign; break;
                case 5: playFields[1, 1] = playerSign; break;
                case 6: playFields[1, 2] = playerSign; break;
                case 7: playFields[2, 0] = playerSign; break;
                case 8: playFields[2, 1] = playerSign; break;
                case 9: playFields[2, 2] = playerSign; break;
            }
        }

        private static void SetFields()
        {
            Console.Clear();
            Console.WriteLine("         |         |         ");
            Console.WriteLine($"    {playFields[0, 0]}    |    {playFields[0, 1]}    |    {playFields[0, 2]}    ");
            Console.WriteLine("_________|_________|_________");
            Console.WriteLine("         |         |         ");
            Console.WriteLine($"    {playFields[1, 0]}    |    {playFields[1, 1]}    |    {playFields[1, 2]}    ");
            Console.WriteLine("_________|_________|_________");
            Console.WriteLine("         |         |         ");
            Console.WriteLine($"    {playFields[2, 0]}    |    {playFields[2, 1]}    |    {playFields[2, 2]}    ");
            Console.WriteLine("         |         |         ");
            turns++;
        }
    }
}