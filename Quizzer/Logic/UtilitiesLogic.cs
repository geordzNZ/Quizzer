using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Logic
{
    internal class UtilitiesLogic
    {
        public static char GetCharUserInput(string userPrompt, string validOptions)
        {
            char[] validChars = validOptions.ToUpper().ToCharArray();

            do
            {

                UI.UtilitiesUI.DisplayBlanker(16, Console.CursorTop + 1);

                // Get user input
                Console.Write($"\t{userPrompt} ({string.Join('/', validChars)}): ");
                ConsoleKeyInfo userInput = Console.ReadKey();

                char casedUserInput = char.ToUpper(userInput.KeyChar);

                if (validOptions.Contains(casedUserInput, StringComparison.CurrentCultureIgnoreCase))
                {
                    return casedUserInput;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"\t --> Valid options are {string.Join(" / ", validChars)} ");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.ResetColor();
                Thread.Sleep(Program.POPUP_TIME);
            } while (true);
        }  //  End of public static char GetCharUserInput


    }  //  End of internal class UtilitiesLogic
}  //  Quizzer.Logic
