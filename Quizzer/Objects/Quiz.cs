using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Objects
{
    public class Quiz
    {
        public int QuizID;
        public string QuizName;
        public string Author;
        public int QuestionsCount = 0;
        public string QuizFileName;


        /// <summary>
        /// Control file name, remove special chars and set standard format
        /// </summary>
        /// <param name="Name">User entered quiz name to format</param>
        /// <returns>formatted, cleansed filename</returns>
        public string MakeFileName(string Name)
        {
            string tempFileName = "";
            foreach (char c in Name)
            {
                tempFileName += char.IsLetterOrDigit(c) ? c : '_';
            }
            return $"QuestionsFor_{tempFileName}.xml";
        }


        /// <summary>
        /// repurposed standard output
        /// </summary>
        /// <returns>formatted Quiz details</returns>
        public override string ToString()
        {
            return $"\tID: {QuizID} -- {QuizName} -- {Author} -- {QuestionsCount} q's -- {QuizFileName}";
        }


    }  //  End of internal class Quiz
}  //  End of namespace Quizzer.Objects
