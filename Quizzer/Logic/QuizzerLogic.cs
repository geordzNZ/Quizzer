using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Logic
{
    internal class QuizzerLogic
    {

        public static void QuizzerGameMode()
        {
            UI.QuizzerUI.DisplayQuizzerInstructions();
            char quizzerAction = Logic.UtilitiesLogic.GetCharUserInput("Choose an Quizzer action", "LR");
            Console.WriteLine($"\tEditor Option = {quizzerAction}");
            Thread.Sleep(Program.POPUP_TIME);
        }  //  End of static void QuizzerGameMode


    }  //  End of internal class QuizzerLogic
}  //  End of namespace Quizzer.Logic
