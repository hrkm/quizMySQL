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
using quizMySQL.DataBase;
using MySql.Data.MySqlClient;

namespace quizMySQL
{
    class QuizQuestion
    {
        public int ID { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public string answerC { get; set; }
        public string answerD { get; set; }
        public string corrAnswer { get; set; }
        public QuizQuestion(MySqlDataReader reader)
        {
            if (!reader.IsClosed)
            {
                reader.Read();
            }

            //reader.Read();

            ID = Convert.ToInt32(reader.GetValue(0));
            question = reader.GetValue(1).ToString();
            answerA = reader.GetValue(2).ToString();
            answerB = reader.GetValue(3).ToString();
            answerC = reader.GetValue(4).ToString();
            answerD = reader.GetValue(5).ToString();
            corrAnswer = reader.GetValue(6).ToString();

            reader.Close();
        }
    }
}