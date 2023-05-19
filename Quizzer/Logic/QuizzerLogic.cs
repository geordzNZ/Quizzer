using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
            Console.WriteLine($"\tQuizzer Option = {quizzerAction}");
            Thread.Sleep(Program.POPUP_TIME);

            switch (quizzerAction)
            {
                case 'L':
                    // List Quizes
                    // Choose Quiz
                    // Load Quiz info from file
                    // Load Question info from file
                    // Display Quiz Header info
                    // Ask Question
                    //   - Choose random Question, add info to temp obj, 
                    //   - Show Question Prompt
                    //   - Build possible answers (correct and incorrect)
                    //   - Choose random Answer and display / repeat for all answers
                    // Prompt for user's Answer
                    // Compare to Answer and output result / update stats
                    // Repeat for all questions
                    // Output final Quiz results
                    // Show Quizzer menu again
                    break;
                case 'R':
                    // Return to Game Menu
                    break;
            }


            Thread.Sleep(Program.POPUP_TIME);
        }  //  End of static void QuizzerGameMode


    }  //  End of internal class QuizzerLogic
}  //  End of namespace Quizzer.Logic
