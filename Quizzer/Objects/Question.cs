using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Objects
{
    internal class Question
    {
        public int QuestionID;
        public string QuestionPrompt;
        public string CorrectAnswer;
        public string[] Answers = new string[0];

        public override string ToString()
        {
            return $"ID: {QuestionID} / {QuestionPrompt} / {Answers.Length + 1} a's";
        }  //  End of public override string ToString


    }  //  End of internal class Question
}  //  End of namespace Quizzer.Objects
