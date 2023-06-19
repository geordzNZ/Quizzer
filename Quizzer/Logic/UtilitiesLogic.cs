using Quizzer.Objects;
using Quizzer.UI;
using System.Xml.Serialization;


namespace Quizzer.Logic
{
    internal class UtilitiesLogic
    {
        const string QUIZ_LIST_FILENAME = "QuizList.xml";

        /// <summary>
        /// Open Quiz file and read as input
        /// </summary>
        /// <returns>(List<Quiz>) - Quiz details</returns>
        public static List<Quiz> ReadFromQuizFile()
        {
            if (!File.Exists(QUIZ_LIST_FILENAME))
            {
                return new List<Quiz>();
            }


            XmlSerializer xmlQuizReader = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.OpenRead(QUIZ_LIST_FILENAME))
            {
                return xmlQuizReader.Deserialize(file) as List<Quiz>;
            }
        }  //  End of public static List<Quiz> GetCurrentQuizzes


        /// <summary>
        /// Output list of type quiz to file
        /// </summary>
        /// <param name="quiz">(List<Quiz>) - Quiz list to write to file</param>
        public static void WriteToQuizFile(List<Quiz> quiz)
        {
            XmlSerializer xmlQuizWriter = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.Create(QUIZ_LIST_FILENAME))
            {
                xmlQuizWriter.Serialize(file, quiz);
            }
        }  //  End of public static void WriteToQuizFile


        /// <summary>
        /// Open Question file and read as input
        /// </summary>
        /// <param name="filename">(string) - the file to open as listed in the Quiz List</param>
        /// <returns>(List<Question>) - the list of questions retrieved from file</returns>
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
        /// <param name="questions">(List<Question>) - the Questions list to ouput</param>
        /// <param name="filename">(string) - the filename to save to</param>
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