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
                    quiz.QuizID = Program.QuizList.Count + 1;
                    quiz.QuizName = Logic.UtilitiesLogic.GetUserInputString("Quiz Name");
                    quiz.Author = Logic.UtilitiesLogic.GetUserInputString("Author Name");
                    quiz.QuizFileName = quiz.MakeFileName(quiz.QuizName);
                    Console.CursorTop = Console.CursorTop + 1;
                    

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

                    quiz.QuestionsCount = QuestionList.Count;
                    Program.QuizList.Add(quiz);

                    // Open file and write it to disk.
                    Logic.UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                    Logic.UtilitiesLogic.WriteToQuestionFile(QuestionList, quiz.QuizFileName);

                    UI.UtilitiesUI.DisplayMessage("Quiz and questions added successfully");  
                    break;
                case 'E':
                    // List Quizes
                    UI.EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz");
                    if (Program.QuizList.Count == 0)
                    {
                        UI.UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Edit)\n\t\tReturning to the main menu...");
                        break;
                    }
                    foreach (Quiz q in Program.QuizList)
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
                    UI.EditorUI.DisplayEditorActionsHeader("Delete", "Choose a list to delete");
                    
                    // Catch when ther are no quizzes to display
                    if (Program.QuizList.Count == 0)
                    {
                        UI.UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Delete)\n\t\tReturning to the main menu...");
                        break;
                    }

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
                    UI.UtilitiesUI.DisplayDivider();
                    
                    // Get Quiz to remove and confirm
                    int selectedQuiztoDelete = Logic.UtilitiesLogic.GetUserInputNumber("Choose a quiz ID to Delete", 1, Program.QuizList.Count);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\t{Program.QuizList[selectedQuiztoDelete - 1].QuizName}");
                    Console.Write($"  -  Created by {Program.QuizList[selectedQuiztoDelete - 1].Author}");
                    Console.Write($"\tTo be deleted\n");
                    Console.ResetColor();
                    char confirmDeletion = Logic.UtilitiesLogic.GetUserInputChar("Confirm deletion of this quiz","YN");

                    if (confirmDeletion == 'Y')
                    {
                        UI.UtilitiesUI.DisplayMessage(Program.QuizList[selectedQuiztoDelete - 1].QuizName + " has been deleted");
                        // Clean up Question file and the Quiz header
                        File.Delete(Program.DATASTORE_PATH + Program.QuizList[selectedQuiztoDelete - 1].QuizFileName);
                        Program.QuizList.Remove(Program.QuizList[selectedQuiztoDelete - 1]);
                        
                        // Update QuizList.xml after removal
                        Logic.UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                    }
                    else
                    {
                        UI.UtilitiesUI.DisplayMessage(Program.QuizList[selectedQuiztoDelete - 1].QuizName + " has not been deleted");
                    }
                    break;
                case 'R':
                    // Return to GameMenu
                    break;
            }

            Thread.Sleep(Program.POPUP_TIME);
        }  //  End of static void EditorGameMode



    }  //  End of internal class EditorLogic
}  // End of namespace Quizzer.Logic