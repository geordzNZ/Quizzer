﻿using Quizzer.Objects;
using Quizzer.UI;
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
                UtilitiesUI.DisplayBlanker(16, Console.CursorTop + 1);

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
        /// <param name="blanksOK">Optional - If blank is a valid answer to this prompt, defualts to false (blanks not allowed)</param>
        /// <returns>a string input by user</returns>
        public static string GetUserInputString(string userPrompt, bool blanksOK = false)
        {
            // Get user input
            string userInput = "";
            
            //while (userInput.Length == 0)
            while (true)
            {
                UtilitiesUI.DisplayBlanker(8, Console.CursorTop);
                
                Console.Write($"\t{userPrompt}: ");
                int forErrorCursorLeft = Console.CursorLeft;
                int forErrorCursorTop = Console.CursorTop;
                userInput = Console.ReadLine();

                if (userInput.Length != 0)
                {
                    return userInput;
                }
                else
                {
                    if (blanksOK)
                    {
                        return "";
                    }
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(forErrorCursorLeft, forErrorCursorTop);
                Console.Write($"\t --> Please enter some text...");
                Console.ResetColor();
                Thread.Sleep(Program.POPUP_TIME);
            }
            // return "xxx";
        }  //  End of public static string GetUserInputString


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
                UtilitiesUI.DisplayBlanker(8, Console.CursorTop + 1);

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
        }  //  End of public static int GetUserInputNumber


        /// <summary>
        /// Open Quiz file and read as input
        /// </summary>
        /// <returns>List of type Quiz</returns>
        public static List<Quiz> ReadFromQuizFile()
        {
            XmlSerializer xmlQuizReader = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.OpenRead(Program.QUIZ_LIST_FILENAME))
            {
                return xmlQuizReader.Deserialize(file) as List<Quiz>;
            }
        }  //  End of public static List<Quiz> GetCurrentQuizzes


        /// <summary>
        /// Output list of type quiz to file
        /// </summary>
        /// <param name="quiz">Quiz list to output</param>
        public static void WriteToQuizFile(List<Quiz> quiz)
        {
            XmlSerializer xmlQuizWriter = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.Create(Program.QUIZ_LIST_FILENAME))
            {
                xmlQuizWriter.Serialize(file, quiz);
            }
        }  //  End of public static void WriteToQuizFile


        /// <summary>
        /// Open Question file and read as input
        /// </summary>
        /// <param name="filename">The file to open as listed in the Quiz List</param>
        /// <returns>List of type Question</returns>
        public static List<Question> ReadFromQuestionFile(string filename)
        {
            XmlSerializer xmlQuestionReader = new XmlSerializer(typeof(List<Question>));

            using (FileStream file = File.OpenRead(filename))

            {
                return xmlQuestionReader.Deserialize(file) as List<Question>;
            }
        }  //  End of public static List<Question> ReadFromQuestionFile


        /// <summary>
        /// Output list of type Question to file
        /// </summary>
        /// <param name="questions">The Questions list to ouput</param>
        /// <param name="filename">the filename to save to</param>
        public static void WriteToQuestionFile(List<Question> questions, string filename)
        {
            XmlSerializer xmlQuestionWriter = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.Create(filename))
            {
                xmlQuestionWriter.Serialize(file, questions);
            }
        }  //  End of public static void WriteToQuestionFile


    }  //  End of internal class UtilitiesLogic
}  //  Quizzer.Logic