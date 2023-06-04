using Quizzer.Objects;
using Quizzer.Logic;
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
                QuizList = UtilitiesLogic.ReadFromQuizFile();
            }

            char gameMode = ' ';
            while (gameMode != 'X')  // X = Exit
            {
                // Initial game info and get game mode
                GameUI.DisplayGameHeader();
                GameUI.DisplayGameModeInstructions();
                gameMode = UtilitiesUI.GetUserInputChar("Choose a game mode", "EQX");

                 
                switch (gameMode)
                {
                    case 'E':  //  E = Editor mode
                        EditorLogic.EditorGameMode();
                        break;

                    case 'Q':  //  Q = Quizzer mode
                        QuizzerLogic.QuizzerGameMode();
                        break;
                }
            }
        } // end of static void Main


    } // end of internal class Program
} // end of namespace Quizzer