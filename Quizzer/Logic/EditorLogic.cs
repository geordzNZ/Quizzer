using Quizzer.Objects;
using Quizzer.UI;


namespace Quizzer.Logic
{
    internal class EditorLogic
    {

        /// <summary>
        /// Handles the Quiz editing modes
        /// </summary>
        public static void HandleEditorGameModes()
        {
            // Prompt user for Game Mode and process input
            EditorUI.DisplayEditorInstructions();
            char editorAction = UtilitiesUI.GetUserInputChar("Choose an Editor action", "CEDR");

            switch (editorAction)
            {
                case 'C':  // Create a Quiz
                    HandleEditorCreateAction();
                    break;
                case 'E':  // Create a Quiz
                    HandleEditorEditAction();
                    break;
                case 'D':  // Create a Quiz
                    HandleEditorDeleteAction();
                    break;
                case 'R':  // Create a Quiz
                    break;
            }
        }


        /// <summary>
        /// Controls the  Editor - Create quiz action
        /// </summary>
        public static void HandleEditorCreateAction()
        {
            // Get either the QuizList or a blank list
            List<Quiz> editorCreateQuizList = UtilitiesLogic.ReadFromQuizFile();

            // Header section
            EditorUI.DisplayEditorActionsHeader("Create", "Follow the prompts to create your new quiz");

            // Get Quiz Details
            int nextQuizID = 0;
            if (editorCreateQuizList.Count != 0)
            {
                nextQuizID = editorCreateQuizList[editorCreateQuizList.Count - 1].QuizID + 1;
            }

            Quiz createdQuiz = CreateQuiz(nextQuizID);

            // Get Quiz Questions
            List<Question> createdQuestionList = CreateQuizQuestions();

            // Update Question count for the created Quiz
            createdQuiz.QuestionsCount = createdQuestionList.Count;

            // Add created Quiz to Master Quiz List
            editorCreateQuizList.Add(createdQuiz);

            // Open file and write Master Quiz List and Questions to files
            UtilitiesLogic.WriteToQuizFile(editorCreateQuizList);
            UtilitiesLogic.WriteToQuestionFile(createdQuestionList, createdQuiz.QuizFileName);

            UtilitiesUI.DisplayMessage("Quiz and questions added successfully");
        }  //  End of public static void HandleEditorCreateAction


        /// <summary>
        /// Controls the Editor - Edit quiz action
        /// </summary>
        public static void HandleEditorEditAction()
        {
            // Get either the QuizList or a blank list
            List<Quiz> editorEditQuizList = UtilitiesLogic.ReadFromQuizFile();

            // Display header section
            EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz");

            // Handle if there are no saved quizzes to display
            if (editorEditQuizList.Count == 0)
            {
                UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Edit)\n\t\tReturning to the main menu...");
                return;
            }

            // Display available Quizzes
            UtilitiesUI.DisplayAvailableQuizes(editorEditQuizList);

            // Get Quiz to edit
            int selectedQuizToEdit = UtilitiesUI.GetUserInputNumber("Choose a quiz ID to Edit", 0, editorEditQuizList.Count);

            // Return to menu if so selected
            if (selectedQuizToEdit == 0)
            {
                return;
            }

            // Display Editer > Edit headers
            EditorUI.DisplayEditorActionsHeader("Edit", "Choose a list and follow the prompts to edit your quiz\n\t  Update the field, or leave blank to leave unchanged");

            // Display Quiz header info and prompt for the updates as needed
            EditorUI.ControlEditingQuizHeaderDetails(editorEditQuizList[selectedQuizToEdit - 1]);

            // Get Questions for this Quiz and display for updating as needed
            List<Question> allQuestionList = UtilitiesLogic.ReadFromQuestionFile(editorEditQuizList[selectedQuizToEdit - 1].QuizFileName);

            List<Question> editedQuestionsList = EditorUI.ControlEditingQuizQuestions(allQuestionList);

            // Update info inthe files
            UtilitiesLogic.WriteToQuizFile(editorEditQuizList);
            UtilitiesLogic.WriteToQuestionFile(editedQuestionsList, editorEditQuizList[selectedQuizToEdit - 1].QuizFileName);

            UtilitiesUI.DisplayMessage("Quiz and questions updated successfully");
        }  //  End of public static void HandleEditorEditAction


        /// <summary>
        /// Controls the  Editor - Delete quiz action
        /// </summary>
        public static void HandleEditorDeleteAction()
        {

            // Get either the QuizList or a blank list
            List<Quiz> editorDeleteQuizList = UtilitiesLogic.ReadFromQuizFile();

            EditorUI.DisplayEditorActionsHeader("Delete", "Choose a list to delete");

            // Handle if there are no saved quizzes to display
            if (editorDeleteQuizList.Count == 0)
            {
                UtilitiesUI.DisplayMessage("\tNo Quizzes to Display (or Delete)\n\t\tReturning to the main menu...");
                return;
            }

            // Display available Quizzes
            UtilitiesUI.DisplayAvailableQuizes(editorDeleteQuizList);

            // Get Quiz to remove 
            int selectedQuiztoDelete = UtilitiesUI.GetUserInputNumber("Choose a quiz ID to Delete", 0, editorDeleteQuizList.Count);

            // Return to menu if selected
            if (selectedQuiztoDelete == 0)
            {
                return;
            }

            // Store quis to delete details
            Quiz quizToDelete = editorDeleteQuizList[selectedQuiztoDelete - 1];

            // Display selected quiz details
            EditorUI.DisplayDeleteQuizPrompt(quizToDelete);

            // Prompt to confirm deletion and process accordingly
            char confirmDeletion = UtilitiesUI.GetUserInputChar("Confirm deletion of this quiz", "YN");

            if (confirmDeletion == 'Y')
            {
                // Clean up Question file and the Quiz header
                File.Delete(quizToDelete.QuizFileName);
                editorDeleteQuizList.Remove(quizToDelete);

                // Delete the Question file
                UtilitiesUI.DisplayMessage(quizToDelete.QuizName + " has been deleted");

                // Update QuizList.xml after removal
                UtilitiesLogic.WriteToQuizFile(editorDeleteQuizList);
            }
            else
            {
                UtilitiesUI.DisplayMessage(quizToDelete.QuizName + " has not been deleted");
            }
        }  //  End of public static void HandleEditorDeleteAction


        /// <summary>
        /// Get all quiz details
        /// </summary>
        /// <returns>(Quiz) - The newly created Quiz details</returns>
        public static Quiz CreateQuiz(int nextQuizID)
        {
            // Set up to create new quiz
            Quiz inputQuiz = new Quiz();

            // Store Quiz object details
            inputQuiz.QuizID = nextQuizID;
            inputQuiz.QuizName = UtilitiesUI.GetUserInputString("Quiz Name");
            inputQuiz.Author = UtilitiesUI.GetUserInputString("Author Name");
            inputQuiz.QuizFileName = inputQuiz.MakeFileName(inputQuiz.QuizName);

            return inputQuiz;
        }  //  End of public static Quiz CreateQuiz

        /// <summary>
        /// Get List of questiosn from user
        /// </summary>
        /// <returns>(List<Question>) - Question List, with all entered questions</returns>
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
        /// <param name="nextQuestionID">(int) - the next Question number</param>
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