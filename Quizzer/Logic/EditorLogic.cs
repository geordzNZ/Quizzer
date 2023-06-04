using Quizzer.Objects;
using Quizzer.UI;


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
            EditorUI.DisplayEditorInstructions();
            char editorAction = UtilitiesUI.GetUserInputChar("Choose an Editor action", "CEDR");
            //Console.SetCursorPosition(0, Console.CursorTop + 1);

            switch (editorAction)
            {
            case 'C':  // Create a Quiz
                // Header section
                EditorUI.DisplayEditorActionsHeader("Create", "Follow the prompts to create your new quiz");

                // Get Quiz Details
                Quiz createdQuiz = CreateQuiz();

                // Get Quiz Questions
                List<Question> createdQuestionList = CreateQuizQuestions();

                // Update Question count for the created Quiz
                createdQuiz.QuestionsCount = createdQuestionList.Count;

                // Add created Quiz to Master Quiz List
                Program.QuizList.Add(createdQuiz);

                // Open file and write Master Quiz List and Questions to files
                UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                UtilitiesLogic.WriteToQuestionFile(createdQuestionList, createdQuiz.QuizFileName);

                UtilitiesUI.DisplayMessage("Quiz and questions added successfully");
                break;

            case 'E':  // Edit a Quiz
                // Display Editer > Edit headers
                EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz");

                // Handle if there are no saved quizzes to display
                if (Program.QuizList.Count == 0)
                {
                    UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Edit)\n\t\tReturning to the main menu...");
                    break;
                }

                // Display available Quizzes
                UtilitiesUI.DisplayAvailableQuizes();

                // Get Quiz to edit
                int selectedQuizToEdit = UtilitiesUI.GetUserInputNumber("Choose a quiz ID to Edit", 0, Program.QuizList.Count);

                // Return to menu if so selected
                if (selectedQuizToEdit == 0)
                {
                    break;
                }

                // Display Editer > Edit headers
                EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz\n\t  Update the field, or leave blank to leave unchanged");


                // Display Quiz header info - line at a time and prompt for the updates as needed
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\tQuiz Header Details...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\t\tQuizName: ");
                Console.WriteLine($"{Program.QuizList[selectedQuizToEdit - 1].QuizName}");
                Console.ResetColor();
                string quizNameEdit = UtilitiesUI.GetUserInputString("\tUpdate? ", true);
                if (quizNameEdit.Length != 0)
                {
                    Program.QuizList[selectedQuizToEdit - 1].QuizName = quizNameEdit;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\t\tAuthor\t: ");
                Console.WriteLine($"{Program.QuizList[selectedQuizToEdit - 1].Author}");
                Console.ResetColor();
                string authorEdit = UtilitiesUI.GetUserInputString("\tUpdate?\t", true);
                if (authorEdit.Length != 0)
                {
                    Program.QuizList[selectedQuizToEdit - 1].Author = authorEdit;
                }

                // Get Questions for this Quiz and display for updating as needed
                List <Question> allQuestionList = UtilitiesLogic.ReadFromQuestionFile(Program.QuizList[selectedQuizToEdit - 1].QuizFileName);

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
                    string promptEdit = UtilitiesUI.GetUserInputString("\tUpdate?\t", true);
                    if (promptEdit.Length != 0)
                    {
                        q.QuestionPrompt = promptEdit;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tCorrect Answer\t: ");
                    Console.WriteLine($"{q.CorrectAnswer}");
                    Console.ResetColor();
                    string correctEdit = UtilitiesUI.GetUserInputString("\tUpdate?\t\t", true);
                    if (correctEdit.Length != 0)
                    {
                        q.CorrectAnswer = correctEdit;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\t\tWrong Answers\t: ");
                    Console.WriteLine($"{q.WrongAnswers}");
                    Console.ResetColor();
                    string wrongEdit = UtilitiesUI.GetUserInputString("\tUpdate?\t\t", true);
                    if (wrongEdit.Length != 0)
                    {
                        q.WrongAnswers = wrongEdit;
                    }

                    questionID++;
                }

                // Update info inthe files
                UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                UtilitiesLogic.WriteToQuestionFile(allQuestionList, Program.QuizList[selectedQuizToEdit - 1].QuizFileName);

                UtilitiesUI.DisplayMessage("Quiz and questions updated successfully");

                break;

            case 'D':  // Delete a Quiz
                EditorUI.DisplayEditorActionsHeader("Delete", "Choose a list to delete");

                // Handle if there are no saved quizzes to display
                if (Program.QuizList.Count == 0)
                {
                    UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Delete)\n\t\tReturning to the main menu...");
                    break;
                }

                // Display available Quizzes
                UtilitiesUI.DisplayAvailableQuizes();

                // Get Quiz to remove 
                int selectedQuiztoDelete = UtilitiesUI.GetUserInputNumber("Choose a quiz ID to Delete", 0, Program.QuizList.Count);

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
                char confirmDeletion = UtilitiesUI.GetUserInputChar("Confirm deletion of this quiz","YN");

                if (confirmDeletion == 'Y')
                {
                    UtilitiesUI.DisplayMessage(Program.QuizList[selectedQuiztoDelete - 1].QuizName + " has been deleted");
                    // Clean up Question file and the Quiz header
                    File.Delete(Program.QuizList[selectedQuiztoDelete - 1].QuizFileName);
                    Program.QuizList.Remove(Program.QuizList[selectedQuiztoDelete - 1]);
                        
                    // Update QuizList.xml after removal
                    UtilitiesLogic.WriteToQuizFile(Program.QuizList);
                }
                else
                {
                    UtilitiesUI.DisplayMessage(Program.QuizList[selectedQuiztoDelete - 1].QuizName + " has not been deleted");
                }
                break;

            case 'R':   // Return to GameMenu
                break;

            }
        }  //  End of static void EditorGameMode


        /// <summary>
        /// Get all quiz details
        /// </summary>
        /// <returns>Quiz, </returns>
        public static Quiz CreateQuiz()
        {
            // Set up to create new quiz
            Quiz inputQuiz = new Quiz();
            int nextQuizID = Program.QuizList[Program.QuizList.Count - 1].QuizID + 1;

            // Store Quiz object details
            inputQuiz.QuizID = nextQuizID;
            inputQuiz.QuizName = UtilitiesUI.GetUserInputString("zzQuiz Name");
            inputQuiz.Author = UtilitiesUI.GetUserInputString("zzAuthor Name");
            inputQuiz.QuizFileName = inputQuiz.MakeFileName(inputQuiz.QuizName);

            return inputQuiz;
        }  //  End of public static Quiz CreateQuiz


        /// <summary>
        /// Get List of questiosn from user
        /// </summary>
        /// <returns>Question List, with all entered questions</returns>
        public static List<Question> CreateQuizQuestions()
        {
            // Set up for Question list creation
            List<Question> inputQuestionList = new List<Question>();
            char addAnotherQuestion = 'Y';

            // Loop to get all questions and details
            while (addAnotherQuestion == 'Y')
            {
                Question question = GetQuizQuestionDetails(inputQuestionList.Count + 1);
                inputQuestionList.Add(question);

                addAnotherQuestion = UtilitiesUI.GetUserInputChar("Add another Question", "YN");
            }
            
            return inputQuestionList;
        }  //  End of public static List<Question> CreateQuizQuestions


        /// <summary>
        /// Get singe Question Details
        /// </summary>
        /// <param name="nextQuestionID">int, the next Question number</param>
        /// <returns>Question, the inputed question details</returns>
        public static Question GetQuizQuestionDetails(int nextQuestionID)
        {
            Question inputQuestion = new Question();

            // Store Question object values
            inputQuestion.QuestionID = nextQuestionID;
            inputQuestion.QuestionPrompt = UtilitiesUI.GetUserInputString($"Question {nextQuestionID} - prompt");
            inputQuestion.CorrectAnswer = UtilitiesUI.GetUserInputString($"Question {nextQuestionID} - correct answer");
            inputQuestion.WrongAnswers = UtilitiesUI.GetUserInputString($"Question {nextQuestionID} - wrong answers separated by /");
            inputQuestion.TotalAnswers = inputQuestion.WrongAnswers.Split('/').ToList().Count + 1;

            return inputQuestion;
        }  //  End of public static List<Question> GetQuizQuestionDetails


    }  //  End of internal class EditorLogic
}  // End of namespace Quizzer.Logic