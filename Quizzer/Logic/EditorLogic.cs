using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Logic
{
    internal class EditorLogic
    {
        public static void EditorGameMode()
        {
            UI.EditorUI.DisplayEditorInstructions();
            char editorAction = Logic.UtilitiesLogic.GetCharUserInput("Choose an Editor action", "CEDR");
            Console.WriteLine($"\tEditor Option = {editorAction}");
            Thread.Sleep(Program.POPUP_TIME);
        }  //  End of static void EditorGameMode



    }  //  End of internal class EditorLogic
}  // End of namespace Quizzer.Logic