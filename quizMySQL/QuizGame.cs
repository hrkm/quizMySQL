using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Quiz.DataBase;

namespace Quiz
{
    class QuizGame
    {
        List<QuizQuestion> questionList;
        public dbManager database { get; set; }
        public int amountOfQuestions { get; set; }
        public int currentQuestion { get; set; }
        public int points { get; set; }


        public QuizGame()
        {
            database = new dbManager("Server=10.0.2.2;Database=quiz;Uid=root;Allow User Variables=True;");
            questionList = new List<QuizQuestion>();
            amountOfQuestions = 8;
            currentQuestion = 1;
            populatingQuestionList();
        }
        public void populatingQuestionList()
        {
            for (int i = 0; i < amountOfQuestions; i++)
            {
                var qq = new QuizQuestion(database.findRndQuestion().ExecuteReader());
                bool match = questionList.Any(x => x.ID == qq.ID);
                while (!match)
                {
                    questionList.Add(qq);
                    break;
                }
            }
        }
        public QuizQuestion getQuestion(int i)
        {
            return questionList[i];
        }
        public void nextQuestion()
        {
            currentQuestion++;
        }
        public void incrementPoints()
        {
            points++;
        }
        public int returnFinalResult()
        {
            return points;
        }
    }
}