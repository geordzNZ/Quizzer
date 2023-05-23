using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.UI
{
    internal class QuizzerUI
    {

        public static void DisplayQuizzerInstructions()
        {
            UI.GameUI.DisplayGameHeader();
            Console.WriteLine("\tQUIZZER Game Menu");
            Console.WriteLine("\t  - L = List Available quizes.");
            Console.WriteLine("\t  - R = Return to game menu.");
            UI.UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayQuizzerInstructions

        public static void DisplayQuizzerActionsHeader(string action, string prompt)
        {
            UI.GameUI.DisplayGameHeader();
            Console.WriteLine($"\tQuizzer Game Mode - {action} available quizzes");
            Console.WriteLine($"\t  {prompt}");
            UI.UtilitiesUI.DisplayDivider();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }  //  End of public static void DisplayEditorActionsHeader

    }  //  End of internal class Quizzer
}  //  End of namespace Quizzer.UI
