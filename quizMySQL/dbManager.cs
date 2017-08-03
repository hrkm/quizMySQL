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
using MySql.Data.MySqlClient;
using System.Data;

namespace QuizMySQL.DataBase
{
    public class DbManager
    {
        public MySqlCommand cmd { get; set; }
        public MySqlConnection con { get; set; }

        public DbManager(string dbInfo)
        {
            //Connecting to database
            con = new MySqlConnection(dbInfo);
        }

        public void add(string question, string answerA, string answerB, string answerC, string answerD, string corrAnswer)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new MySqlCommand("INSERT INTO question (Question, answerA, answerB, answerC, answerD, corrAnswer) VALUES(@question, @answerA, @answerB, @answerC, @answerD, @corrAnswer)", con);

            cmd.Parameters.AddWithValue("@question", question);
            cmd.Parameters.AddWithValue("@answerA", answerA);
            cmd.Parameters.AddWithValue("@answerB", answerB);
            cmd.Parameters.AddWithValue("@answerC", answerC);
            cmd.Parameters.AddWithValue("@answerD", answerD);
            cmd.Parameters.AddWithValue("@corrAnswer", corrAnswer);
            cmd.ExecuteNonQuery();
        }

        public MySqlCommand findRndQuestion()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new MySqlCommand("SELECT ID, Question, answerA, answerB, answerC, answerD, corrAnswer FROM question ORDER BY RAND() LIMIT 1", con);
            return cmd;
        }
    }
}