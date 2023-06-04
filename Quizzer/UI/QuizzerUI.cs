using Quizzer.Logic;
using Quizzer.Objects;
using System.Data;

namespace Quizzer.UI
{
    internal class QuizzerUI
    {


        /// <summary>
        /// Display header section for Quizzer mode
        /// </summary>
        public static void DisplayQuizzerInstructions()
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine("\tQUIZZER Game Menu");
            Console.WriteLine("\t  - L = List Available quizes.");
            Console.WriteLine("\t  - R = Return to game menu.");
            UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayQuizzerInstructions


        /// <summary>
        /// Display header section for Quizzer mode specific actions
        /// </summary>
        /// <param name="action">indication of action user has chosen</param>
        /// <param name="prompt">sub text for more info</param>
        public static void DisplayQuizzerActionsHeader(string action, string prompt)
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine($"\tQuizzer Game Mode - {action} available quizzes");
            Console.WriteLine($"\t  {prompt}");
            UtilitiesUI.DisplayDivider();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }  //  End of public static void DisplayEditorActionsHeader

        /// <summary>
        /// Displays the quiz header details
        /// </summary>
        /// <param name="quiz">The quizselected by the user</param>
        public static void DisplayQuizHeader(Objects.Quiz quiz)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"\t{quiz.QuizName}");
            Console.ResetColor();
            Console.Write($"  -  Created by {quiz.Author} (");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{quiz.QuestionsCount} {(quiz.QuestionsCount > 1 ? "questions" : "question")}");
            Console.ResetColor();
            Console.Write($")\n\n");
        }  //  End of public static void DisplayQuizHeader


        /// <summary>
        /// Display current question number and the prompt, adds in ? if needed.
        /// </summary>
        /// <param name="questionNumber">int, number of question</param>
        /// <param name="prompt">string, prompt to ask user</param>
        public static void DisplayCurrentQuizQuestion(int questionNumber, string prompt)
        {
            prompt = prompt.EndsWith('?') ? prompt : prompt + '?';
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\t\tQ{questionNumber + 1}:   {prompt}");
            Console.ResetColor();
        }  //  End of public static void DisplayCurrentQuizQuestion


        /// <summary>
        /// Display correct and wrong answers in the list
        /// </summary>
        /// <param name="wrongAnswers">string, The incorrect answers, with / seperator</param>
        /// <param name="correctAnswer">string, The correct answer </param>
        /// <returns>List of all answers, in random order, as displayed to user</returns>
        public static List<string> DisplayCurrentQuizQuestionAnswers(string wrongAnswers, string correctAnswer)
        {
            Random randomAnswer = new Random();
            List<string> usedAnswersList = new List<string>();

            // Parse Answers into one unit
            string answers = wrongAnswers + '/' + correctAnswer;
            List<string> allAnswersList = answers.Split('/').ToList();
            int totalAnswers = allAnswersList.Count;

            // TODO Maybe? as a foreach??
            for (int j = 0; j < totalAnswers; j++)
            {
                int randomAnswerID = randomAnswer.Next(allAnswersList.Count);

                Console.WriteLine($"\t\t\t{j + 1}:   {allAnswersList[randomAnswerID]}");

                // Keep track of already displayed answers
                usedAnswersList.Add(allAnswersList[randomAnswerID]);
                allAnswersList.Remove(allAnswersList[randomAnswerID]);
            }
            // Reposition cursor, ready for getting the answer
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            return usedAnswersList;
        }  //  End of public static void DisplayCurrentQuizQuestionAnswers


        /// <summary>
        /// Display answer result on same line as answer, with colour
        /// </summary>
        /// <param name="result">0 for wrong messages, 1 for correct message</param>
        public static void DisplayQuestionReult(int result)
        {
            Console.SetCursorPosition(42, Console.CursorTop - 1);

            Console.Write(" --> ");
            
            switch (result)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG!!");
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("CORRECT!!");
                    break;
            }
            Console.ResetColor();
        }  //  End of public static void DisplayQuestionReult


        /// <summary>
        /// Displays the Quiz result line
        /// </summary>
        /// <param name="correct">number of correct answers</param>
        /// <param name="total">total number of questions in the quiz</param>
        public static void DisplayQuizResult(int correct, int total)
        {
            Console.Write($"\n\tYou scored ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{correct}");
            Console.ResetColor();
            Console.Write($" correct, out of ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{total}");
            Console.ResetColor();
            Console.Write($" -- ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{(correct / (double)total).ToString("P1")}");
            Console.ResetColor();
        }  //  End of public static void DisplayQuizResult


    }  //  End of internal class Quizzer
}  //  End of namespace Quizzer.UI
