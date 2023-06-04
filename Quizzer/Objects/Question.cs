

using System.Net.NetworkInformation;

namespace Quizzer.Objects
{
    public class Question
    {
        public int QuestionID;
        public string QuestionPrompt;
        public string CorrectAnswer;
        public string WrongAnswers;
        public int TotalAnswers;


        /// <summary>
        /// repurposed standard output
        /// </summary>
        /// <returns>formatted Question details</returns>
        public override string ToString()
        {
            return $"\t\tID: {QuestionID} -- {QuestionPrompt} -- {CorrectAnswer} / {WrongAnswers}";
        }

    }  //  End of public class Question
}  //  End of namespace Quizzer.Objects
