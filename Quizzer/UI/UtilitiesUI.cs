using Quizzer.Objects;


namespace Quizzer.UI
{
    internal class UtilitiesUI
    {
        const string DIVIDER = "=====================================================================";
        const string BLANKER = "                                                                                  ";
       

        /// <summary>
        /// Displays default divider line with formatting to standardize
        /// </summary>
        public static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DIVIDER);
            Console.ResetColor();
        }


        /// <summary>
        /// Blanks out certain parts of the sreen, based on params and repositions cursor for next input
        /// </summary>
        /// <param name="left">(int) - indicating position from the left of the console</param>
        /// <param name="top">(int) - indicating position from the top of the console</param>
        public static void DisplayBlanker(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(BLANKER);
            Console.SetCursorPosition(0, top);
        }


        /// <summary>
        /// Standardised meesage display with formatting
        /// </summary>
        /// <param name="message">(string) - text to be displayed</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine($"\n\t{message}");
            DisplayDivider();
            Thread.Sleep(Program.POPUP_TIME);
        }


        /// <summary>
        /// Process the Quiz List to format and display output
        /// </summary>
        public static void DisplayAvailableQuizes()
        {
            // List Quizes
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\t0: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"Return to menu\n");

            UtilitiesUI.DisplayDivider();
        }  //  End of public static void DisplayAvailableQuizes


        /// <summary>
        /// Takes a prompt and list of valid characters to return a validated user input
        /// </summary>
        /// <param name="userPrompt">(string) - Question to be posed to the user</param>
        /// <param name="validOptions">(string) - List of valid options</param>
        /// <returns>(char) - The validated uppercase char from the user input</returns>
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
        /// <param name="userPrompt">(string) - Question to be posed to the user</param>
        /// <param name="blanksOK">(bool) - Optional - If blank is a valid answer to this prompt, defualts to false (blanks not allowed)</param>
        /// <returns>(string) - text input by user or a blank string</returns>
        public static string GetUserInputString(string userPrompt, bool blanksOK = false)
        {
            // Get user input
            string userInput = "";

            while (true)
            {
                UtilitiesUI.DisplayBlanker(8, Console.CursorTop);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\t{userPrompt}: ");
                Console.ResetColor();
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
        }  //  End of public static string GetUserInputString


        /// <summary>
        /// Takes a prompt and gets an int input from the user
        /// </summary>
        /// <param name="userPrompt">(string) - the question to prompt the user</param>
        /// <param name="lowerValue">(int) - minimum number</param>
        /// <param name="upperValue">(int) - maximum number</param>
        /// <returns>(int) - the validated user selection</returns>
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


    }  //  End of internal class UtilitiesUI
}  //  End of namespace Quizzer.UI 
