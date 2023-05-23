using System.Transactions;
using System.Xml.Serialization;
using Quizzer.Objects;
using Quizzer.UI;

namespace Quizzer
{
    internal class Program
    {
        public const int POPUP_TIME = 750;
        public const string DATASTORE_PATH = @"C:\Users\Geordie\Documents\Dev\C-Sharp\RaketeMentoring\Projects\Module06\Data\";
        public const string QUIZ_LIST_FILENAME = "QuizList.txt";
        //public static int CURRENT_QUIZ_COUNT = 0;
        public static List<Quiz> QuizList = new List<Quiz>();
        

        static void Main(string[] args)
        {
            char gameMode = ' ';
            if (File.Exists(DATASTORE_PATH + QUIZ_LIST_FILENAME))
            {
                Program.QuizList = Logic.UtilitiesLogic.ReadFromQuizFile();
            }

            while (gameMode != 'X')
            {
                UI.GameUI.DisplayGameHeader();
                UI.GameUI.DisplayGameModeInstructions();
                gameMode = Logic.UtilitiesLogic.GetUserInputChar("Choose a game mode", "EQX");

                 
                switch (gameMode)
                {
                    case 'E':
                        Logic.EditorLogic.EditorGameMode();
                        break;
                    case 'Q':
                        Logic.QuizzerLogic.QuizzerGameMode();
                        break;
                }



            }
        } // end of static void Main


    } // end of internal class Program
} // end of namespace Quizzer