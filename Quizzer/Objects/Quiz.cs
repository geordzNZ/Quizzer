﻿using System;
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

        public string MakeFileName(string Name)
        {
            string tempFileName = "";
            foreach (char c in Name)
            {
                tempFileName += char.IsLetterOrDigit(c) ? c : '_';
            }
            return tempFileName + ".txt";
        }  //  End of public string MakeFileName

        public override string ToString()
        {
            return $"ID: {QuizID} - {QuizName} - {QuestionsCount} q's \n {QuizFileName}";
        }  //  End of public override string ToString

    }  //  End of internal class Quiz
}  //  End of namespace Quizzer.Objects