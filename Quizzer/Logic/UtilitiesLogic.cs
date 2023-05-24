using Quizzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quizzer.Logic
{
    internal class UtilitiesLogic
    {

        /// <summary>
        /// Takes a prompt and list of valid characters to return a validated user input
        /// </summary>
        /// <param name="userPrompt">Question to be posed to the user</param>
        /// <param name="validOptions">List of valid options</param>
        /// <returns>The validated char from the user input</returns>
        public static char GetUserInputChar(string userPrompt, string validOptions)
        {
            char[] validChars = validOptions.ToUpper().ToCharArray();

            while (true)
            {
                UI.UtilitiesUI.DisplayBlanker(16, Console.CursorTop + 1);

                // Get user input
                Console.Write($"\t{userPrompt} ({string.Join('/', validChars)}): ");
                ConsoleKeyInfo userInput = Console.ReadKey();

                char casedUserInput = char.ToUpper(userInput.KeyChar);

                if (validOptions.Contains(casedUserInput, StringComparison.CurrentCultureIgnoreCase))
                {
                    return casedUserInput;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"\t --> Valid options are {string.Join(" / ", validChars)}...");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.ResetColor();
                Thread.Sleep(Program.POPUP_TIME);
            } 
        }  //  End of public static char GetCharUserInput

        /// <summary>
        /// Takes a prompt and gets a string input from the user
        /// </summary>
        /// <param name="userPrompt">Question to be posed to the user</param>
        /// <returns>a non zero length string</returns>
        public static string GetUserInputString(string userPrompt)
        {
            // Get user input
            string userInput = "";
            
            //while (userInput.Length == 0)
            while (true)
            {
                UI.UtilitiesUI.DisplayBlanker(8, Console.CursorTop);
                
                Console.Write($"\t{userPrompt}: ");
                int forErrorCursorLeft = Console.CursorLeft;
                int forErrorCursorTop = Console.CursorTop;
                userInput = Console.ReadLine();
                
                if (userInput.Length != 0)
                {
                    return userInput;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(forErrorCursorLeft, forErrorCursorTop);
                Console.Write($"\t --> Please enter some text...");
                Console.ResetColor();
                Thread.Sleep(Program.POPUP_TIME);
            }
               // return "xxx";
        }

        /// <summary>
        /// Takes a prompt and gets an int input from the user
        /// </summary>
        /// <param name="userPrompt">the question to prompt the user</param>
        /// <param name="lowerValue">minimum number</param>
        /// <param name="upperValue">maximum number</param>
        /// <returns></returns>
        public static int GetUserInputNumber(string userPrompt, int lowerValue, int upperValue)
        {
            // Get user input
            string userInput = "";

            while (true)
            {
                UI.UtilitiesUI.DisplayBlanker(8, Console.CursorTop + 1);

                // Get user input
                Console.Write($"\t{userPrompt} - ({lowerValue}-{upperValue}): ");
                int forErrorCursorLeft = Console.CursorLeft;
                int forErrorCursorTop = Console.CursorTop;
                userInput = Console.ReadLine();

                // Validate user input
                int validatedNumber;
                bool numberValidation = int.TryParse(userInput, out validatedNumber);
                if (numberValidation && validatedNumber >= lowerValue && validatedNumber <= upperValue)
                {
                    return validatedNumber;
                }
                Console.SetCursorPosition(forErrorCursorLeft, forErrorCursorTop);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"\t --> Valid options are between {lowerValue}-{upperValue} ...");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.ResetColor();
                Thread.Sleep(Program.POPUP_TIME);
            }

        }

            public static List<Quiz> ReadFromQuizFile()
        {
            XmlSerializer xmlQuizReader = new XmlSerializer(typeof(List<Objects.Quiz>));
            using (FileStream file = File.OpenRead(Program.DATASTORE_PATH + Program.QUIZ_LIST_FILENAME))
            {
                return xmlQuizReader.Deserialize(file) as List<Objects.Quiz>;
            }
        }  //  End of public static List<Quiz> GetCurrentQuizzes

        public static void WriteToQuizFile(List<Quiz> quiz)
        {
            XmlSerializer xmlQuizWriter = new XmlSerializer(typeof(List<Objects.Quiz>));
            using (FileStream file = File.Create(Program.DATASTORE_PATH + Program.QUIZ_LIST_FILENAME))
            {
                xmlQuizWriter.Serialize(file, quiz);
            }
        }  //  End of public static void WriteToQuizFile

        public static List<Question> ReadFromQuestionFile(string filename)
        {
            XmlSerializer xmlQuestionReader = new XmlSerializer(typeof(List<Objects.Question>));

            using (FileStream file = File.OpenRead(Program.DATASTORE_PATH + filename))
            {
                return xmlQuestionReader.Deserialize(file) as List<Objects.Question>;
            }
        }  //  End of public static List<Question> ReadFromQuestionFile

        public static void WriteToQuestionFile(List<Question> questions, string filename)
        {
            XmlSerializer xmlQuestionWriter = new XmlSerializer(typeof(List<Objects.Question>));
            using (FileStream file = File.Create(Program.DATASTORE_PATH + filename))
            {
                xmlQuestionWriter.Serialize(file, questions);
            }
        }  //  End of public static void WriteToQuestionFile

    }  //  End of internal class UtilitiesLogic
}  //  Quizzer.Logic