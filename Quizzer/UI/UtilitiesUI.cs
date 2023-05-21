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

    }  //  End of internal class UtilitiesUI
}  //  End of namespace Quizzer.UI 
