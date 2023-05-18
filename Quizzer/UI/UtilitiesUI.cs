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
        public static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DIVIDER);
            Console.ResetColor();
        }  //  End of public static void DisplayDivider

        public static void DisplayBlanker(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(BLANKER);
            Console.SetCursorPosition(0, top);
        }  //  End of public static void DisplayBlanker

    }  //  End of internal class UtilitiesUI
}  //  End of namespace Quizzer.UI 
