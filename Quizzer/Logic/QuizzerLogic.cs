using Quizzer.Objects;
using Quizzer.UI;


namespace Quizzer.Logic
{
    internal class QuizzerLogic
    {


        /// <summary>
        /// Controls Quisser game mode
        /// </summary>
        public static void QuizzerGameMode()
        {
            QuizzerUI.DisplayQuizzerInstructions();
            char quizzerAction = UtilitiesLogic.GetUserInputChar("Choose an Quizzer action", "LR");
            Thread.Sleep(Program.POPUP_TIME);

            switch (quizzerAction)
            {
                case 'L':  // List quizzes to play
                    // List Quizes
                    QuizzerUI.DisplayQuizzerActionsHeader("List", "Choose one of our available quizzes");

                    // Handle if there are no saved quizzes to display
                    if (Program.QuizList.Count == 0)
                    {
                        UtilitiesUI.DisplayMessage("\tNo Quizzes to Display\n\t\tReturning to the main menu...");
                        break;
                    }

                    // Display available Quizzes
                    UtilitiesUI.DisplayAvailableQuizes();

                    // Get Quiz to edit
                    int selectedQuizToPlay = UtilitiesLogic.GetUserInputNumber("Choose a quiz ID to play", 0, Program.QuizList.Count);

                    // Return to menu if selected
                    if (selectedQuizToPlay == 0)
                    {
                        break;
                    }

                    // Play the Quiz
                    TakeQuiz(Program.QuizList[selectedQuizToPlay - 1]);

                    break;

                case 'R':  // Return to Game Menu
                    break;
            }


            Thread.Sleep(Program.POPUP_TIME);
        }  //  End of static void QuizzerGameMode


        /// <summary>
        /// Controls taking of the selected quiz, with displays and formatting
        /// </summary>
        /// <param name="quiz">the select quiz</param>
        public static void TakeQuiz(Objects.Quiz quiz)
        {
            //Display quiz details, ready for the questions
            QuizzerUI.DisplayQuizzerActionsHeader("Take", "Good luck with your answerings");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"\t{quiz.QuizName}");
            Console.ResetColor();
            Console.Write($"  -  Created by {quiz.Author} (");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{quiz.QuestionsCount} {(quiz.QuestionsCount > 1 ? "questions" : "question")}");
            Console.ResetColor();
            Console.Write($")\n");

            // Retrieve Questions from file
            List<Question> allQuestionList = UtilitiesLogic.ReadFromQuestionFile(quiz.QuizFileName);
            List<Question> askedQuestionList = new List<Question>();
            
            // Set up for vairables
            Random randomQuestion = new Random();
            Random randomAnswer = new Random();
            int correctAnswers = 0;

            // Work thru List of questions and control flow
            for (int i = 0; i < quiz.QuestionsCount; i++)
            {
                // Random ID for randomising the Questions
                int randomQuestionID = randomQuestion.Next(allQuestionList.Count);

                // Set up and Process available answers
                string answers = allQuestionList[randomQuestionID].WrongAnswers;
                answers += '/' + allQuestionList[randomQuestionID].CorrectAnswer;
                List<string> allAnswersList = answers.Split('/').ToList();
                List<string> usedAnswersList = new List<string>();
                int totalAnswers = allAnswersList.Count;
                int userAnswerID = 999;

                // Display Question and available randomises answers 
                Console.WriteLine($"\t\tQ:  {allQuestionList[randomQuestionID].QuestionPrompt}");
                for (int j = 0; j < totalAnswers; j++)
                {
                    int randomAnswerID = randomAnswer.Next(allAnswersList.Count);

                    Console.WriteLine($"\t\t\t{j + 1}:  {allAnswersList[randomAnswerID]}");

                    // Keep track of answers
                    usedAnswersList.Add(allAnswersList[randomAnswerID]);
                    allAnswersList.Remove(allAnswersList[randomAnswerID]);
                }

                // Keep track of questions
                askedQuestionList.Add(allQuestionList[randomQuestionID]);
                allQuestionList.Remove(allQuestionList[randomQuestionID]);

                // Get answer from user and check if correct
                userAnswerID = UtilitiesLogic.GetUserInputNumber("\tYour answer", 1, usedAnswersList.Count);
                if (usedAnswersList[userAnswerID - 1] == askedQuestionList[askedQuestionList.Count - 1].CorrectAnswer)
                {
                    Console.WriteLine($"\t\tCORRECT!!");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"\t\tWRONG!!");

                }
            }

            // Display Quiz outcome
            Console.Write($"\n\tYou scored ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{correctAnswers}");
            Console.ResetColor();
            Console.Write($" correct, out of ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{askedQuestionList.Count}");
            Console.ResetColor();
            Console.Write($" -- ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{(correctAnswers / (double)askedQuestionList.Count).ToString("P1")}");
            Console.ResetColor();
        }  //  End of public static void TakeQuiz

    }  //  End of internal class QuizzerLogic
}  //  End of namespace Quizzer.Logic
