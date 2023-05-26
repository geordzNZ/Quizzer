using Quizzer.Logic;
using Quizzer.Objects;


namespace Quizzer.UI
{
    internal class QuizzerUI
    {


        /// <summary>
        /// Display header section for Quizzer mode
        /// </summary>
        public static void DisplayQuizzerInstructions()
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine("\tQUIZZER Game Menu");
            Console.WriteLine("\t  - L = List Available quizes.");
            Console.WriteLine("\t  - R = Return to game menu.");
            UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayQuizzerInstructions


        /// <summary>
        /// Display header section for Quizzer mode specific actions
        /// </summary>
        /// <param name="action">indication of action user has chosen</param>
        /// <param name="prompt">sub text for more info</param>
        public static void DisplayQuizzerActionsHeader(string action, string prompt)
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine($"\tQuizzer Game Mode - {action} available quizzes");
            Console.WriteLine($"\t  {prompt}");
            UtilitiesUI.DisplayDivider();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }  //  End of public static void DisplayEditorActionsHeader


    }  //  End of internal class Quizzer
}  //  End of namespace Quizzer.UI
