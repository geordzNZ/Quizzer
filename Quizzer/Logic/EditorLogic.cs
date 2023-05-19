using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Logic
{
    internal class EditorLogic
    {
        public static void EditorGameMode()
        {
            UI.EditorUI.DisplayEditorInstructions();
            char editorAction = Logic.UtilitiesLogic.GetCharUserInput("Choose an Editor action", "CEDR");
            Console.WriteLine($"\tEditor Option = {editorAction}");
            Thread.Sleep(Program.POPUP_TIME);

            switch (editorAction)
            {
                case 'C':
                    // Instantiate Quiz obj and populate
                    //   - Set QuizID - Count of quizes + 1
                    //   - Prompt for QuizName and store
                    //   - Prompt for Author and store
                    //   - Prompt for QuizFileName and store
                    //   - Prompt to
                    //     - Edit Entries --> redo loop to here
                    //     - Save to File --> Save
                    //   - Move to Add Questions
                    // Instantiate Question obj and populate
                    //   - Set QuestionID - start at 0, increment
                    //   - Prompt for QuestionPrompt and store
                    //   - Prompt for CorrectAnswer and save
                    //   - Prompt for IncorrectAnswers and save (delimiter??)
                    //   - Prompt to
                    //     - Edit Entries --> redo loop to here
                    //     - Save to File --> Save
                    //   - Update Quiz obj with number of Questions
                    // Return to Editor Menu
                    break;
                case 'E':
                    // List Quizes
                    // Choose Quiz
                    // Load Quiz info from file
                    // Load Question info from file
                    // Display each Prop of Quiz obj and ask to edit
                    // Display each Prop of Question obj and ask to edit
                    // Save back to files
                    // Return to Editor Menu
                    break;
                case 'D':
                    // List Quizes
                    // Choose Quiz
                    // Confirm deletion - soft or hard delete?
                    //   - Soft ... mark Quiz status as deleted
                    //   - Hard ... remove fully from Quiz file
                    //          ... delete the questions file
                    // Confirm deletion completed
                    // Return to Editor Menu
                    break;
                case 'R':
                    // Return to GameMenu
                    break;
            }




            Thread.Sleep(Program.POPUP_TIME);
        }  //  End of static void EditorGameMode



    }  //  End of internal class EditorLogic
}  // End of namespace Quizzer.Logic