using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.UI
{
    public static class GameUI
    {

        /// <summary>
        /// Game Title section
        /// </summary>
        public static void DisplayGameHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tWELCOME TO QUIZZING QUIZZER");
            Console.WriteLine("\t\tCome and test your knowledge");
            Console.ResetColor();
            UI.UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayHeader


        /// <summary>
        /// Game mode instructions display
        /// </summary>
        public static void DisplayGameModeInstructions()
        {
            Console.WriteLine("\tGame mode:");
            Console.WriteLine("\t  - E = Editor  --> Create / Edit quizzes.");
            Console.WriteLine("\t  - Q = Quizzer --> Test your skills.");
            Console.WriteLine("\t  - X = Exit    --> Run away an hide.");
            UI.UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayGameModeInstructions


    }  //  End of public static class ProgramUI
}  //  End of namespace Quizzer.UI
