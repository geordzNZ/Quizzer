

using Quizzer.Objects;

namespace Quizzer.UI
{
    internal class EditorUI
    {
        /// <summary>
        /// Display header section for Editor mode
        /// </summary>
        public static void DisplayEditorInstructions()
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine("\tEDITOR Game Menu");
            Console.WriteLine("\t  - C = Create a new quiz.");
            Console.WriteLine("\t  - E = Edit a current quiz.");
            Console.WriteLine("\t  - D = Delete a current quiz.");
            Console.WriteLine("\t  - R = Return to game menu.");
            UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayEditorInstructions


        /// <summary>
        /// Display header section for Editor mode specific actions
        /// </summary>
        /// <param name="action">(string) - indication of action user has chosen</param>
        /// <param name="prompt">(string) - sub text for more info</param>
        public static void DisplayEditorActionsHeader(string action, string prompt)
        {
            GameUI.DisplayGameHeader();
            Console.WriteLine($"\tEDITOR Game Mode - {action} a quiz");
            Console.WriteLine($"\t  {prompt}");
            UtilitiesUI.DisplayDivider();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }  //  End of public static void DisplayEditorActionsHeader


        /// <summary>
        /// Display details of quic to delte
        /// </summary>
        /// <param name="quiz">(Quiz) - Quiz, the Quiz object to be deleted</param>
        public static void DisplayDeleteQuizPrompt(Quiz quiz)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n\t{quiz.QuizName}");
            Console.Write($"  -  Created by {quiz.Author}");
            Console.Write($"\tTo be deleted\n");
            Console.ResetColor();
        }  //  End of public static void DisplayDeleteQuizPrompt


        /// <summary>
        /// Displays current QuizName and Author promts and updates those values, if changed
        /// </summary>
        /// <param name="quizID">(int) - the ID number of the quiz to edit</param>
        public static void ControlEditingQuizHeaderDetails(int quizID)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\tQuiz Header Details...");

            Program.QuizList[quizID].QuizName = DisplayAndVaildateEditedItemValue("QuizName", Program.QuizList[quizID].QuizName);

            Program.QuizList[quizID].Author = DisplayAndVaildateEditedItemValue("Author\t", Program.QuizList[quizID].Author);

        }  //  public static void ControlEditingQuizHeaderDetails


        /// <summary>
        /// displays the prompts and gets validated edited value, if changed
        /// </summary>
        /// <param name="prompt">(string) - the property of the quiz to be changed</param>
        /// <param name="currentValue">(string) - the current value of the property to be changed</param>
        /// <returns>(string) - the edited or current text</returns>
        public static string DisplayAndVaildateEditedItemValue(string prompt, string currentValue)
        {
            // Display prompt and current value
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\t\t{prompt}\t: ");
            Console.ResetColor();
            Console.WriteLine($"{currentValue}");

            // Get user input then validate
            string editiedValue = UtilitiesUI.GetUserInputString("\tUpdate?\t\t", true);
            
            return editiedValue.Length != 0 ? editiedValue : currentValue;

        }  //  End of public static string DisplayAndVaildateEditedItemValue


        public static List<Question> ControlEditingQuizQuestions(List<Question> questions)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n\tQuiz Question Details...");
            Console.ResetColor();

            List<Question> editedQuestionList = new List<Question>();
            foreach (Question q in questions)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\tQuestion {q.QuestionID}:");
                editedQuestionList.Add(DisplayAndVaildateEditedQuestion(q));
            }

            return editedQuestionList;
        }  //  public static void ControlEditingQuizQuestions


        /// <summary>
        /// displays the prompts and gets validated edited values, if changed
        /// </summary>
        /// <param name="question">(Question) - the current question to be edited</param>
        /// <returns>(Question) - the updated question</returns>
        public static Question DisplayAndVaildateEditedQuestion(Question question)
        {
            Question editedQuestion = new Question();

            // Get updated properties of the question
            editedQuestion.QuestionID = question.QuestionID;
            editedQuestion.QuestionPrompt = DisplayAndVaildateEditedItemValue("Prompt\t", question.QuestionPrompt);
            editedQuestion.CorrectAnswer = DisplayAndVaildateEditedItemValue("Correct Answer", question.CorrectAnswer);
            editedQuestion.WrongAnswers = DisplayAndVaildateEditedItemValue("Wrong Answers", question.WrongAnswers);
            editedQuestion.TotalAnswers = editedQuestion.WrongAnswers.Split('/').ToList().Count + 1;

            return editedQuestion;
        }  //  end of public static Question DisplayAndVaildateEditedQuestion


    }  //  End of internal calss EditorUI
}  //  namespace Quizzer.UI
