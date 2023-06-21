using Quizzer.Objects;
using Quizzer.UI;


namespace Quizzer.Logic
{
    internal class QuizzerLogic
    {
        /// <summary>
        /// Controls Quizzer game mode
        /// </summary>
        public static void QuizzerGameMode()
        {
            // Get either the QuizList or a blank list
            List<Quiz> quizzerQuizList = new List<Quiz>();
            quizzerQuizList = UtilitiesLogic.ReadFromQuizFile();

            QuizzerUI.DisplayQuizzerInstructions();
            char quizzerAction = UtilitiesUI.GetUserInputChar("Choose an Quizzer action", "LR");


            switch (quizzerAction)
            {
            case 'L':  // List quizzes to play
                // List Quizes
                QuizzerUI.DisplayQuizzerActionsHeader("List", "Choose one of our available quizzes");

                // Handle if there are no saved quizzes to display
                if (quizzerQuizList.Count == 0)
                {
                    UtilitiesUI.DisplayMessage("\tNo Quizzes to Display\n\t\tReturning to the main menu...");
                    break;
                }

                // Display available Quizzes <TODO: Pass List>
                UtilitiesUI.DisplayAvailableQuizes(quizzerQuizList);

                // Get Quiz to edit
                int selectedQuizToPlay = UtilitiesUI.GetUserInputNumber("Choose a quiz ID to play", 0, quizzerQuizList.Count);

                // Return to menu if selected
                if (selectedQuizToPlay == 0)
                {
                    break;
                }

                // Play the Quiz
                TakeQuiz(quizzerQuizList[selectedQuizToPlay - 1]);
                break;
            case 'R':  // Return to Game Menu
                break;
            }
        }  //  End of public static void QuizzerGameMode


        /// <summary>
        /// Controls taking of the selected quiz
        /// </summary>
        /// <param name="quiz">(Quiz) - the select quiz</param>
        public static void TakeQuiz(Quiz quiz)
        {
            //Display quiz details, ready for the questions
            QuizzerUI.DisplayQuizzerActionsHeader("Take", "Good luck with your answerings");
            QuizzerUI.DisplayQuizHeader(quiz);
            
            // Retrieve Questions from file
            List<Question> allQuestionList = UtilitiesLogic.ReadFromQuestionFile(quiz.QuizFileName);
            List<Question> askedQuestionList = new List<Question>();

            // Set up for random number generation
            Random randomQuestion = new Random();
            int correctAnswers = 0;

            // Work thru List of questions and control flow
            for (int i = 0; i < quiz.QuestionsCount; i++)
            {
                // Random ID for randomising the Questions and get question
                int randomQuestionID = randomQuestion.Next(allQuestionList.Count);
                Question currentQuestion = allQuestionList[randomQuestionID];
                
                // Handle current question - display Q & A's / Get answer
                correctAnswers += HandleCurrentQuestion(i, currentQuestion);
                
                // Keep track of questions
                allQuestionList.Remove(allQuestionList[randomQuestionID]);
            }

            // Display Quiz outcome
            QuizzerUI.DisplayQuizResult(correctAnswers, quiz.QuestionsCount);
        }  //  End of public static void TakeQuiz


        /// <summary>
        /// Manages the whole question journey
        /// </summary>
        /// <param name="questionNumber">(int) -  current question number</param>
        /// <param name="question">(Question) - the current question object</param>
        /// <returns>(int) - 1 if correct answer is given, 0 if not</returns>
        public static int HandleCurrentQuestion(int questionNumber, Question question)
        {
            // Display question prompt
            QuizzerUI.DisplayCurrentQuizQuestion(questionNumber, question.QuestionPrompt);
         
            // Display answers and return list of answers as displayed
            List<string> usedAnswersList = QuizzerUI.DisplayCurrentQuizQuestionAnswers(question.WrongAnswers, question.CorrectAnswer);

            // Get answer from user and check if correct
            int userAnswerID = UtilitiesUI.GetUserInputNumber("\t  Your answer", 1, question.TotalAnswers);

            // Display question result and return as appropriate
            if (usedAnswersList[userAnswerID - 1] == question.CorrectAnswer)
            {
                QuizzerUI.DisplayQuestionReult(1);
                return 1;
            }
            else
            {
                QuizzerUI.DisplayQuestionReult(0);
                return 0;
            }
        }  //  End of public static int HandleCurrentQuestion


    }  //  End of internal class QuizzerLogic
}  //  End of namespace Quizzer.Logic
