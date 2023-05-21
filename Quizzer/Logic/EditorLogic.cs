using Quizzer.Objects;
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

            char editorAction = Logic.UtilitiesLogic.GetUserInputChar("Choose an Editor action", "CEDR");
            //Console.WriteLine($"\tEditor Option = {editorAction}");
            Console.SetCursorPosition(0, Console.CursorTop + 1);

            switch (editorAction)
            {
                case 'C':
                    
                    UI.EditorUI.DisplayEditorActionsHeader("Create", "Follow the prompts to create your new quiz");

                    // Set up for new Quiz
                    List<Quiz> QuizList = new List<Quiz>();
                    Objects.Quiz quiz = new Objects.Quiz();

                    // Store Quiz object values
                    quiz.QuizID = Program.CURRENT_QUIZ_COUNT + 1;
                    quiz.QuizName = Logic.UtilitiesLogic.GetUserInputString("Quiz Name");
                    quiz.Author = Logic.UtilitiesLogic.GetUserInputString("Author Name");
                    quiz.QuizFileName = quiz.MakeFileName(quiz.QuizName);
                    Console.CursorTop = Console.CursorTop + 1;
                    
                    QuizList.Add(quiz);

                    // Set up for new Question
                    List<Question> QuestionList = new List<Question>();
                    char endOfQuestions = 'Y';
                    int questionCounter = 0;

                    while (endOfQuestions == 'Y')
                    {
                        Objects.Question question = new Objects.Question();
                        questionCounter++;

                        // Store Question object values
                        question.QuestionID = questionCounter;
                        question.QuestionPrompt = Logic.UtilitiesLogic.GetUserInputString($"Question {questionCounter} - prompt");
                        question.CorrectAnswer = Logic.UtilitiesLogic.GetUserInputString($"Question {questionCounter} - correct answer");
                        question.WrongAnswers = Logic.UtilitiesLogic.GetUserInputString($"Question {questionCounter} - wrong answers separated by /");
                        QuestionList.Add(question);

                        endOfQuestions = Logic.UtilitiesLogic.GetUserInputChar("Add another Question", "YN");
                    }

                    quiz.QuestionsCount = QuestionList.Count;
                    Console.WriteLine(quiz);
                    foreach (Question q in QuestionList)
                    {
                        Console.WriteLine(q);
                    }
                    
                    // TODO: Prompt to check data and loop if incorrect ... or maybe just do the 'wrong bit'??



                    //   - Prompt to
                    //     - Edit Entries --> redo loop to here
                    //     - Save to File --> Save
                    //   - Move to Add Questions
                    // Instantiate Question obj and populate
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