using Quizzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace Quizzer.Logic
{
    internal class EditorLogic
    {
        public static void EditorGameMode()
        {
            UI.EditorUI.DisplayEditorInstructions();

            char editorAction = Logic.UtilitiesLogic.GetUserInputChar("Choose an Editor action", "CEDR");
            Console.SetCursorPosition(0, Console.CursorTop + 1);

            switch (editorAction)
            {
                case 'C':
                    
                    UI.EditorUI.DisplayEditorActionsHeader("Create", "Follow the prompts to create your new quiz");

                    // Set up for new Quiz
                    Objects.Quiz quiz = new Objects.Quiz();

                    // Store Quiz object values
                    quiz.QuizID = Program.QUIZ_LIST.Count + 1;
                    quiz.QuizName = Logic.UtilitiesLogic.GetUserInputString("Quiz Name");
                    quiz.Author = Logic.UtilitiesLogic.GetUserInputString("Author Name");
                    quiz.QuizFileName = quiz.MakeFileName(quiz.QuizName);
                    Console.CursorTop = Console.CursorTop + 1;
                    
                    Program.QUIZ_LIST.Add(quiz);

                    // Set up for new Question
                    List<Question> QuestionList = new List<Question>();
                    char addAnotherQuestion = 'Y';
                    int questionCounter = 0;

                    while (addAnotherQuestion == 'Y')
                    {
                        Objects.Question question = new Objects.Question();
                        questionCounter++;

                        // Store Question object values
                        question.QuestionID = questionCounter;
                        question.QuestionPrompt = Logic.UtilitiesLogic.GetUserInputString($"Question {questionCounter} - prompt");
                        question.CorrectAnswer = Logic.UtilitiesLogic.GetUserInputString($"Question {questionCounter} - correct answer");
                        question.WrongAnswers = Logic.UtilitiesLogic.GetUserInputString($"Question {questionCounter} - wrong answers separated by /");
                        
                        QuestionList.Add(question);

                        addAnotherQuestion = Logic.UtilitiesLogic.GetUserInputChar("Add another Question", "YN");
                    }

                    // Open file and write it to disk.
                    Logic.UtilitiesLogic.WriteToQuizFile(Program.QUIZ_LIST);
                    Logic.UtilitiesLogic.WriteToQuestionFile(QuestionList, quiz.QuizFileName);

                    UI.UtilitiesUI.DisplayMessage("Quiz and questions added successfully");  
                    break;
                case 'E':
                    // List Quizes
                    UI.EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz");
                    foreach (Quiz q in Program.QUIZ_LIST)
                    {
                        Console.WriteLine(q);
                    }




                    UI.UtilitiesUI.DisplayMessage("WIP - Coming soon!!!");
                    char tempPauser1 = Logic.UtilitiesLogic.GetUserInputChar(" ... pauser ... ", "Y");
                    
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
                    UI.EditorUI.DisplayEditorActionsHeader("Delete", "Choose a list to delete");
                    foreach (Quiz q in Program.QUIZ_LIST)
                    {
                        Console.WriteLine(q);
                    }





                    UI.UtilitiesUI.DisplayMessage("WIP - Coming soon!!!");
                    char tempPauser2 = Logic.UtilitiesLogic.GetUserInputChar(" ... pauser ... ", "Y");

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