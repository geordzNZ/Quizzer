using Quizzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.UI
{
    internal class UtilitiesUI
    {
        const string DIVIDER = "===================================================================";
        const string BLANKER = "                                                                                ";
        /// <summary>
        /// Displays defualt divider line with formatting
        /// </summary>
        public static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DIVIDER);
            Console.ResetColor();
        }  //  End of public static void DisplayDivider

        /// <summary>
        /// Blanks out certain parts of the sreen, based on params and repositions cursor for next input
        /// </summary>
        /// <param name="left">number(int) indicating position from the left of the console</param>
        /// <param name="top">number(int) indicating position from the top of the console</param>
        public static void DisplayBlanker(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(BLANKER);
            Console.SetCursorPosition(0, top);
        }  //  End of public static void DisplayBlanker


        public static void DisplayMessage(string message)
        {
            Console.WriteLine($"\n\t{message}");
            DisplayDivider();
            Thread.Sleep(Program.POPUP_TIME);
        }


        public static void DisplayAvailableQuizes()
        {
            // List Quizes
            int quizCounter = 1;
            foreach (Quiz q in Program.QuizList)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\t{quizCounter}: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{q.QuizName}");
                Console.ResetColor();
                Console.Write($"  -  Created by {q.Author} (");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{q.QuestionsCount} {(q.QuestionsCount > 1 ? "questions" : "question")}");
                Console.ResetColor();
                Console.Write($")\n");
                quizCounter++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\t0: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"Return to menu\n");

            UI.UtilitiesUI.DisplayDivider();
        }
    }  //  End of internal class UtilitiesUI
}  //  End of namespace Quizzer.UI 
