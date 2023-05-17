using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer
{
    public static class UIMethods
    {
        const string DIVIDER = "===================================================================";
        const string BLANKER = "                                                                   ";
        const int POPUP_TIME = 500;
        public static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DIVIDER);
            Console.ResetColor();
        }

        public static void DisplayBlanker(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(BLANKER);
            Console.SetCursorPosition(0, top);
        }


        public static void DisplayHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tWELCOME TO QUIZZING QUIZZER");
            Console.WriteLine("\t\tCome and test your knowledge");
            Console.ResetColor();
            DisplayDivider();
        }
        public static void DisplayGameModeInstructions()
        {
            Console.WriteLine("\t\tGame mode:");
            Console.WriteLine("\t\t  - E = Editor  --> Create / Edit quizzes.");
            Console.WriteLine("\t\t  - Q = Quizzer --> Test your skills.");
            Console.WriteLine("\t\t  - X = Exit    --> Run away an hide.");
            DisplayDivider();
        }

        public static void DisplayEditorInstructions()
        {
            DisplayHeader();
            Console.WriteLine("\t\tEDITOR  Game Menu");
            Console.WriteLine("\t\t  - C = Create a new quiz.");
            Console.WriteLine("\t\t  - E = Edit a current quiz.");
            Console.WriteLine("\t\t  - D = Delete a current quiz.");
            Console.WriteLine("\t\t  - R = Return to game menu.");
            DisplayDivider();
        }

        public static void DisplayPlayerInstructions()
        {
            DisplayHeader();
            Console.WriteLine("\t\tQUIZZER  Game Menu");
            Console.WriteLine("\t\t  - L = List Available quizes.");
            Console.WriteLine("\t\t  - R = Return to game menu.");
            DisplayDivider();
        }
        
        // TODO: Think about how to reuse this for all menu validations.
        public static char GetGameMode()
        {
            char gameModeAnswer = ' ';
            do
            {
                // Get user input
                //ConsoleKeyInfo playAgainInput = UI_Methods.GetYesNoAnswer("");
                DisplayBlanker(16,9);

                Console.Write($"\t\tChoose a game mode (E/Q/X): ");
                ConsoleKeyInfo gameModeInput = Console.ReadKey();

                char casedGameModeInput = char.ToLower(gameModeInput.KeyChar);

                if ((int)casedGameModeInput == 101 || // e or E
                    (int)casedGameModeInput == 113 || // q or Q
                    (int)casedGameModeInput == 120)   // x or X
                {
                    gameModeAnswer = char.Parse(gameModeInput.KeyChar.ToString());
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t --> Please enter only E / Q / X ");
                Console.ResetColor();
                Thread.Sleep(POPUP_TIME);
            } while (true);  // Play again loop

            return gameModeAnswer;
        }
    }
}
