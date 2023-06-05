

using Quizzer.Objects;

namespace Quizzer.UI
{
    internal class EditorUI
    {
        /// <summary>
        /// Display header section for Editor mode
        /// </summary>
        public static void DisplayEditorInstructions()
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine("\tEDITOR Game Menu");
            Console.WriteLine("\t  - C = Create a new quiz.");
            Console.WriteLine("\t  - E = Edit a current quiz.");
            Console.WriteLine("\t  - D = Delete a current quiz.");
            Console.WriteLine("\t  - R = Return to game menu.");
            UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayEditorInstructions


        /// <summary>
        /// Display header section for Editor mode specific actions
        /// </summary>
        /// <param name="action">(string) - indication of action user has chosen</param>
        /// <param name="prompt">(string) - sub text for more info</param>
        public static void DisplayEditorActionsHeader(string action, string prompt)
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine($"\tEDITOR Game Mode - {action} a quiz");
            Console.WriteLine($"\t  {prompt}");
            UtilitiesUI.DisplayDivider();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }  //  End of public static void DisplayEditorActionsHeader


        /// <summary>
        /// Display details of quic to delte
        /// </summary>
        /// <param name="quiz">(Quiz) - Quiz, the Quiz object to be deleted</param>
        public static void DisplayDeleteQuizPrompt(Quiz quiz)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n\t{quiz.QuizName}");
            Console.Write($"  -  Created by {quiz.Author}");
            Console.Write($"\tTo be deleted\n");
            Console.ResetColor();
        }  //  End of public static void DisplayDeleteQuizPrompt


    }  //  End of internal calss EditorUI
}  //  namespace Quizzer.UI
