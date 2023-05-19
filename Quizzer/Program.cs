﻿using System.Transactions;
using System.Xml.Serialization;
using Quizzer.UI;

namespace Quizzer
{
    internal class Program
    {
        public const int POPUP_TIME = 750;
        static void Main(string[] args)
        {
            char gameMode = ' ';

            while (gameMode != 'X')
            {
                UI.GameUI.DisplayGameHeader();
                UI.GameUI.DisplayGameModeInstructions();
                gameMode = Logic.UtilitiesLogic.GetCharUserInput("Choose a game mode", "EQX");

                switch (gameMode)
                {
                    case 'E':
                        Logic.EditorLogic.EditorGameMode();
                        break;
                    case 'Q':
                        Logic.QuizzerLogic.QuizzerGameMode();
                        break;
                }



            }

            //Objects.Quiz QuizOne = new Objects.Quiz();

            //QuizOne.QuizID = 1;
            //QuizOne.QuizName = "000%%Quiz name goes here$$10";
            //QuizOne.Author = "G_NZ";
            //QuizOne.QuestionsCount = 15;
            //QuizOne.QuizFileName = QuizOne.MakeFileName(QuizOne.QuizName);

            //Objects.Quiz QuizTwo = new Objects.Quiz();

            //QuizTwo.QuizID = 2;
            //QuizTwo.QuizName = "This is the Quiz name $$10";
            //QuizTwo.Author = "G_NZ";
            //QuizTwo.QuizFileName = QuizTwo.MakeFileName(QuizTwo.QuizName);

            //QuizList1.Add(QuizOne);
            //QuizList1.Add(QuizTwo);

            //Console.WriteLine(" -- QuizList1 -- ");
            //foreach (var q in QuizList1)
            //{
            //    Console.WriteLine(q);
            //}


            //string filePath = @"C:\Users\Geordie\Documents\Dev\C-Sharp\RaketeMentoring\Projects\Module06\Data\QuizList.txt";

            //// Save file with QuizList1
            //XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Objects.Quiz>));

            //using (FileStream outputFile = File.Create(filePath))
            //{
            //    xmlWriter.Serialize(outputFile, QuizList1);
            //}

            //// Open file and write to QuizList2
            //using (FileStream inputFile = File.OpenRead(filePath))
            //{
            //    QuizList2 = xmlWriter.Deserialize(inputFile) as List<Objects.Quiz>;
            //}

            //Console.WriteLine(" -- QuizList2 -- ");
            //foreach (var q in QuizList2)
            //{
            //    Console.WriteLine(q);
            //}

        } // end of static void Main

    } // end of internal class Program
} // end of namespace Quizzer