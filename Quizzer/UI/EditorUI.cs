using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.UI
{
    internal class EditorUI
    {


        /// <summary>
        /// Display header section for Editor mode
        /// </summary>
        public static void DisplayEditorInstructions()
        {
            UI.GameUI.DisplayGameHeader();
            Console.WriteLine("\tEDITOR Game Menu");
            Console.WriteLine("\t  - C = Create a new quiz.");
            Console.WriteLine("\t  - E = Edit a current quiz.");
            Console.WriteLine("\t  - D = Delete a current quiz.");
            Console.WriteLine("\t  - R = Return to game menu.");
            UI.UtilitiesUI.DisplayDivider();
        }


        /// <summary>
        /// Display header section for Editor mode specific actions
        /// </summary>
        /// <param name="action">indication of action user has chosen</param>
        /// <param name="prompt">sub text for more info</param>
        public static void DisplayEditorActionsHeader(string action, string prompt)
        {
            UI.GameUI.DisplayGameHeader();
            Console.WriteLine($"\tEDITOR Game Mode - {action} a quiz");
            Console.WriteLine($"\t  {prompt}");
            UI.UtilitiesUI.DisplayDivider();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }


    }  //  End of internal calss EditorUI
}  //  namespace Quizzer.UI
