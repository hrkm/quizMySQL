using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using quizMySQL.DataBase;

namespace quizMySQL
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
        public bool checkClick(string letter)
        {
            //If clicked answer is correct
            if (getQuestion(currentQuestion).corrAnswer == letter)
            {
                return true;
            }
            //If clicked answer is not correct
            else if (getQuestion(currentQuestion).corrAnswer != letter)
            {
                return false;
            }
            else
            {
                throw new NotImplementedException("button " + letter + " click");
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
        public string updateCurrentQuestionTxt()
        {
            return "Question " + currentQuestion + " out of " + amountOfQuestions;
        }
        public int returnFinalResult()
        {
            return points;
        }
        public void restartQuiz()
        {
            currentQuestion = 1;
            populatingQuestionList();
        }
    }
}