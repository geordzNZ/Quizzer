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
            Console.WriteLine($"\tQuizzer Option = {quizzerAction}");
            Thread.Sleep(Program.POPUP_TIME);

            switch (quizzerAction)
            {
                case 'L':
                    // List Quizes
                    UI.QuizzerUI.DisplayQuizzerActionsHeader("List", "Choose one of our available quizzes");
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
                    int selectedQuizNumber = Logic.UtilitiesLogic.GetUserInputNumber("Choose a quiz ID", 1, Program.QuizList.Count);
                    TakeQuiz(Program.QuizList[selectedQuizNumber-1]);



                    char tempPauser1 = Logic.UtilitiesLogic.GetUserInputChar(" ... pauser ... ", "Y");
                    UI.UtilitiesUI.DisplayMessage("WIP - Coming soon!!!");


                    // Load Question info from file
                    // Ask Question
                    //   - Choose random Question, add info to temp obj, 
                    //   - Show Question Prompt
                    //   - Build possible answers (correct and incorrect)
                    //   - Choose random Answer and display / repeat for all answers
                    // Prompt for user's Answer
                    // Compare to Answer and output result / update stats
                    // Repeat for all questions
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

            for (int i=0; i<quiz.QuestionsCount; i++)
            {
                int randomQuestionID = randomQuestion.Next(allQuestionList.Count);

                string answers = allQuestionList[randomQuestionID].WrongAnswers;
                answers += '/' + allQuestionList[randomQuestionID].CorrectAnswer;
                List<string> allAnswersList = answers.Split('/').ToList();
                List<string> usedAnswersList = new List<string>();
                int totalAnswers = allAnswersList.Count;
                int userAnswerID = 999;

                Console.WriteLine($"\t\tQ:  {allQuestionList[randomQuestionID].QuestionPrompt}");
                for (int j=0; j<totalAnswers; j++)
                {
                    int randomAnswerID = randomAnswer.Next(allAnswersList.Count);

                    Console.WriteLine($"\t\t\t{j+1}:  {allAnswersList[randomAnswerID]}");

                    usedAnswersList.Add(allAnswersList[randomAnswerID]);
                    allAnswersList.Remove (allAnswersList[randomAnswerID]);
                }


                askedQuestionList.Add(allQuestionList[randomQuestionID]);
                allQuestionList.Remove(allQuestionList[randomQuestionID]);

                userAnswerID = Logic.UtilitiesLogic.GetUserInputNumber("\tYour answer", 1, usedAnswersList.Count);
                if (usedAnswersList[userAnswerID-1] == askedQuestionList[askedQuestionList.Count-1].CorrectAnswer)
                {
                    Console.WriteLine($"\t\tCORRECT!!");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"\t\tWRONG!!");

                }

                Console.WriteLine($"You scored {correctAnswers}");
            }
        }

    }  //  End of internal class QuizzerLogic
}  //  End of namespace Quizzer.Logic
