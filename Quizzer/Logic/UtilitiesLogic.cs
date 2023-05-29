﻿using Quizzer.Objects;
using Quizzer.UI;
using System.Xml.Serialization;


namespace Quizzer.Logic
{
    internal class UtilitiesLogic
    {




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