﻿using Quizzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace Quizzer.Logic
{
    internal class EditorLogic
    {
        /// <summary>
        /// Controller for Editor Game Mode
        /// </summary>
        public static void EditorGameMode()
        {
            // Prompt user for Game Mode and process input
            UI.EditorUI.DisplayEditorInstructions();
            char editorAction = Logic.UtilitiesLogic.GetUserInputChar("Choose an Editor action", "CEDR");
            Console.SetCursorPosition(0, Console.CursorTop + 1);

            switch (editorAction)
            {
                case 'C':  // Create a Quiz
                    // Header section
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
    
                    // Prompt and store question(s)
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

                    // Add Quiz inifo to master Quiz list
                    quiz.QuestionsCount = QuestionList.Count;
                    Program.QuizList.Add(quiz);

                    // Open file and write it to disk.
                    Logic.UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                    Logic.UtilitiesLogic.WriteToQuestionFile(QuestionList, quiz.QuizFileName);

                    UI.UtilitiesUI.DisplayMessage("Quiz and questions added successfully");
                    break;

                case 'E':  // Edit a Quiz
                    // Display Editer > Edit headers
                    UI.EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz");

                    // Handle if there are no saved quizzes to display
                    if (Program.QuizList.Count == 0)
                    {
                        UI.UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Edit)\n\t\tReturning to the main menu...");
                        break;
                    }

                    // Display available Quizzes
                    UI.UtilitiesUI.DisplayAvailableQuizes();

                    // Get Quiz to edit
                    int selectedQuizToEdit = Logic.UtilitiesLogic.GetUserInputNumber("Choose a quiz ID to Edit", 0, Program.QuizList.Count);

                    // Return to menu if so selected
                    if (selectedQuizToEdit == 0)
                    {
                        break;
                    }

                    // Display Editer > Edit headers
                    UI.EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz\n\t  Update the field, or leave blank to leave unchanged");


                    // Display Quiz header info - line at a time and prompt for the updates as needed
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\tQuiz Header Details...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tQuizName: ");
                    Console.WriteLine($"{Program.QuizList[selectedQuizToEdit - 1].QuizName}");
                    Console.ResetColor();
                    string quizNameEdit = Logic.UtilitiesLogic.GetUserInputString("\tUpdate? ", true);
                    if (quizNameEdit.Length != 0)
                    {
                        Program.QuizList[selectedQuizToEdit - 1].QuizName = quizNameEdit;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tAuthor\t: ");
                    Console.WriteLine($"{Program.QuizList[selectedQuizToEdit - 1].Author}");
                    Console.ResetColor();
                    string authorEdit = Logic.UtilitiesLogic.GetUserInputString("\tUpdate?\t", true);
                    if (authorEdit.Length != 0)
                    {
                        Program.QuizList[selectedQuizToEdit - 1].Author = authorEdit;
                    }

                    // Get Questions for this Quiz and display for updating as needed
                    List <Question> allQuestionList = Logic.UtilitiesLogic.ReadFromQuestionFile(Program.QuizList[selectedQuizToEdit - 1].QuizFileName);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n\tQuiz Question Details...");
                    Console.ResetColor();

                    int questionID = 1;
                    foreach (Question q in allQuestionList)
                    {
                        Console.WriteLine($"\tQuestion {questionID}:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"\t\tPrompt\t: ");
                        Console.WriteLine($"{q.QuestionPrompt}");
                        Console.ResetColor();
                        string promptEdit = Logic.UtilitiesLogic.GetUserInputString("\tUpdate?\t", true);
                        if (promptEdit.Length != 0)
                        {
                            q.QuestionPrompt = promptEdit;
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"\t\tCorrect Answer\t: ");
                        Console.WriteLine($"{q.CorrectAnswer}");
                        Console.ResetColor();
                        string correctEdit = Logic.UtilitiesLogic.GetUserInputString("\tUpdate?\t\t", true);
                        if (correctEdit.Length != 0)
                        {
                            q.CorrectAnswer = correctEdit;
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"\t\tWrong Answers\t: ");
                        Console.WriteLine($"{q.WrongAnswers}");
                        Console.ResetColor();
                        string wrongEdit = Logic.UtilitiesLogic.GetUserInputString("\tUpdate?\t\t", true);
                        if (wrongEdit.Length != 0)
                        {
                            q.WrongAnswers = wrongEdit;
                        }

                        questionID++;
                    }

                    // Update info inthe files
                    Logic.UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                    Logic.UtilitiesLogic.WriteToQuestionFile(allQuestionList, Program.QuizList[selectedQuizToEdit - 1].QuizFileName);

                    UI.UtilitiesUI.DisplayMessage("Quiz and questions updated successfully");

                    break;

                case 'D':  // Delete a Quiz
                    UI.EditorUI.DisplayEditorActionsHeader("Delete", "Choose a list to delete");

                    // Handle if there are no saved quizzes to display
                    if (Program.QuizList.Count == 0)
                    {
                        UI.UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Delete)\n\t\tReturning to the main menu...");
                        break;
                    }

                    // Display available Quizzes
                    UI.UtilitiesUI.DisplayAvailableQuizes();

                    // Get Quiz to remove 
                    int selectedQuiztoDelete = Logic.UtilitiesLogic.GetUserInputNumber("Choose a quiz ID to Delete", 0, Program.QuizList.Count);

                    // Return to menu if selected
                    if (selectedQuiztoDelete == 0)
                    {
                        break;
                    }

                    // Display selected quiz details
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\t{Program.QuizList[selectedQuiztoDelete - 1].QuizName}");
                    Console.Write($"  -  Created by {Program.QuizList[selectedQuiztoDelete - 1].Author}");
                    Console.Write($"\tTo be deleted\n");
                    Console.ResetColor();
                    
                    // Prompt to confirm deletion and process accordingly
                    char confirmDeletion = Logic.UtilitiesLogic.GetUserInputChar("Confirm deletion of this quiz","YN");

                    if (confirmDeletion == 'Y')
                    {
                        UI.UtilitiesUI.DisplayMessage(Program.QuizList[selectedQuiztoDelete - 1].QuizName + " has been deleted");
                        // Clean up Question file and the Quiz header
                        File.Delete(Program.QuizList[selectedQuiztoDelete - 1].QuizFileName);
                        Program.QuizList.Remove(Program.QuizList[selectedQuiztoDelete - 1]);
                        
                        // Update QuizList.xml after removal
                        Logic.UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                    }
                    else
                    {
                        UI.UtilitiesUI.DisplayMessage(Program.QuizList[selectedQuiztoDelete - 1].QuizName + " has not been deleted");
                    }
                    break;

                case 'R':   // Return to GameMenu
                    break;

            }
        }  //  End of static void EditorGameMode


    }  //  End of internal class EditorLogic
}  // End of namespace Quizzer.Logic