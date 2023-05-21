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

            do
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
            } while (true);
        }  //  End of public static char GetCharUserInput

                /// <summary>
        /// Takes a prompt and gets an input from the user
        /// </summary>
        /// <param name="userPrompt">Question to be posed to the user</param>
        /// <returns>a non zero length string</returns>
        public static string GetUserInputString(string userPrompt)
        {


            // Get user input
            string userInput = "";
            
            while (userInput.Length == 0){
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
                return "xxx";
        }

        public static int GetQuizCount()
        {
            if (!File.Exists(Program.DATASTORE_PATH + Program.QUIZ_LIST_FILENAME))
            {
                return 0;
            }

            // Open file to check current list count
            XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Objects.Quiz>));

            List<Objects.Quiz> currentQuizList = new List<Objects.Quiz>();

            using (FileStream inputFile = File.OpenRead(Program.DATASTORE_PATH + Program.QUIZ_LIST_FILENAME))
            {
                currentQuizList = xmlWriter.Deserialize(inputFile) as List<Objects.Quiz>;
            }

            return currentQuizList.Count;
        }  //  End of public static int GetQuizCount

    }  //  End of internal class UtilitiesLogic
}  //  Quizzer.Logic
