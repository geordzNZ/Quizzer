using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Objects
{
    public class Question
    {
        public int QuestionID;
        public string QuestionPrompt;
        public string CorrectAnswer;
        public string WrongAnswers;

        public override string ToString()
        {
            return $"\t\tID: {QuestionID} -- {QuestionPrompt} -- {CorrectAnswer} / {WrongAnswers}";
        }  //  End of public override string ToString


    }  //  End of public class Question
}  //  End of namespace Quizzer.Objects
