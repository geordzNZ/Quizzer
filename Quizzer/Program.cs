using Quizzer.Objects;
using Quizzer.Logic;
using Quizzer.UI;


namespace Quizzer
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
                        QuizzerLogic.HandleQuizzerGameModes();
                        break;
                }
            }
        } // end of static void Main


    } // end of internal class Program
} // end of namespace Quizzer