using System.Transactions;
using System.Xml.Serialization;
using Quizzer.Objects;

using Quizzer.UI;
namespace Quizzer
{
    internal class Program
    {
        public const int POPUP_TIME = 750;
        public const string QUIZ_LIST_FILENAME = "QuizList.xml";
        public static List<Quiz> QuizList = new List<Quiz>();
        

        static void Main(string[] args)
        {

            // Check if file exists for first run, ope if it exists
            if (File.Exists(QUIZ_LIST_FILENAME))
                {
                    Program.QuizList = Logic.UtilitiesLogic.ReadFromQuizFile();
            }

            char gameMode = ' ';
            while (gameMode != 'X')  // X = Exit
            {
                // Initial game info and get game mode
                UI.GameUI.DisplayGameHeader();
                UI.GameUI.DisplayGameModeInstructions();
                gameMode = Logic.UtilitiesLogic.GetUserInputChar("Choose a game mode", "EQX");

                 
                switch (gameMode)
                {
                    case 'E':  //  E = Editor mode
                        Logic.EditorLogic.EditorGameMode();
                        break;

                    case 'Q':  //  Q = Quizzer mode
                        Logic.QuizzerLogic.QuizzerGameMode();
                        break;
                }
            }
        } // end of static void Main


    } // end of internal class Program
} // end of namespace Quizzer