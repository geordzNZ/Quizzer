using Quizzer.Objects;
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
            char quizzerAction = Logic.UtilitiesLogic.GetUserInputChar("Choose an Quizzer action", "LR");
            Thread.Sleep(Program.POPUP_TIME);

            switch (quizzerAction)
            {
                case 'L':
                    // List Quizes
                    UI.QuizzerUI.DisplayQuizzerActionsHeader("List", "Choose one of our available quizzes");
                    if (Program.QuizList.Count == 0)
                    {
                        UI.UtilitiesUI.DisplayMessage("\tNo Quizzes to Display\n\t\tReturning to the main menu...");
                        break;
                    }

                    // Display available Quizzes
                    UI.UtilitiesUI.DisplayAvailableQuizes();

                    // Get Quiz to edit
                    int selectedQuizToPlay = Logic.UtilitiesLogic.GetUserInputNumber("Choose a quiz ID to play", 0, Program.QuizList.Count);

                    // Return to menu if selected
                    if (selectedQuizToPlay == 0)
                    {
                        break;
                    }

                    // Play the Quiz
                    TakeQuiz(Program.QuizList[selectedQuizToPlay - 1]);

                    char tempPauser = Logic.UtilitiesLogic.GetUserInputChar(" ... pauser ... ", "Y");


                    // Output final Quiz results
                    // Show Quizzer menu again
                    break;
                case 'R':
                    // Return to Game Menu
                    break;
            }


            Thread.Sleep(Program.POPUP_TIME);
        }  //  End of static void QuizzerGameMode


        public static void TakeQuiz(Objects.Quiz quiz)
        {
            UI.QuizzerUI.DisplayQuizzerActionsHeader("Take", "Good luck with your answering");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"\t{quiz.QuizName}");
            Console.ResetColor();
            Console.Write($"  -  Created by {quiz.Author} (");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{quiz.QuestionsCount} {(quiz.QuestionsCount > 1 ? "questions" : "question")}");
            Console.ResetColor();
            Console.Write($")\n");

            // Retrieve Questions from file
            List<Question> allQuestionList = Logic.UtilitiesLogic.ReadFromQuestionFile(quiz.QuizFileName);
            List<Question> askedQuestionList = new List<Question>();
            
            // 
            Random randomQuestion = new Random();
            Random randomAnswer = new Random();

            int correctAnswers = 0;

            for (int i = 0; i < quiz.QuestionsCount; i++)
            {
                int randomQuestionID = randomQuestion.Next(allQuestionList.Count);

                string answers = allQuestionList[randomQuestionID].WrongAnswers;
                answers += '/' + allQuestionList[randomQuestionID].CorrectAnswer;
                List<string> allAnswersList = answers.Split('/').ToList();
                List<string> usedAnswersList = new List<string>();
                int totalAnswers = allAnswersList.Count;
                int userAnswerID = 999;

                Console.WriteLine($"\t\tQ:  {allQuestionList[randomQuestionID].QuestionPrompt}");
                for (int j = 0; j < totalAnswers; j++)
                {
                    int randomAnswerID = randomAnswer.Next(allAnswersList.Count);

                    Console.WriteLine($"\t\t\t{j + 1}:  {allAnswersList[randomAnswerID]}");

                    usedAnswersList.Add(allAnswersList[randomAnswerID]);
                    allAnswersList.Remove(allAnswersList[randomAnswerID]);
                }


                askedQuestionList.Add(allQuestionList[randomQuestionID]);
                allQuestionList.Remove(allQuestionList[randomQuestionID]);

                userAnswerID = Logic.UtilitiesLogic.GetUserInputNumber("\tYour answer", 1, usedAnswersList.Count);
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
            Console.WriteLine($"You scored {correctAnswers} correct, out of {askedQuestionList.Count} -- {(correctAnswers / askedQuestionList.Count)}%");
        }

    }  //  End of internal class QuizzerLogic
}  //  End of namespace Quizzer.Logic
