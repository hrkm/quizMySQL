using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Data;
using quizMySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System;
using quizMySQL.DataBase;
using Newtonsoft.Json;


namespace quizMySQL
{
    [Activity(Label = "GameActivity", MainLauncher = false, Icon = "@drawable/icon")]
    public class GameActivity : Activity
    {
        QuizGame game;
        TextView questionNoTxt;
        TextView question;
        Button buttonA;
        Button buttonB;
        Button buttonC;
        Button buttonD;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Game);
            game = new QuizGame();
            game.database = new DbManager("Server=10.0.2.2;Database=quiz;Uid=root;Allow User Variables=True;");
            game.populatingQuestionList(game.database);
            assignViewToVar();
            refreshQuestionPage();
            buttonA.Click += delegate { btn1Click(); };
            buttonB.Click += delegate { btn2Click(); };
            buttonC.Click += delegate { btn3Click(); };
            buttonD.Click += delegate { btn4Click(); };
        }
        public void refreshQuestionPage()
        {
            assignValToVar(game.currentQuestion);
        }
        private void assignViewToVar()
        {
            questionNoTxt = FindViewById<TextView>(Resource.Id.textView2);
            question = FindViewById<TextView>(Resource.Id.textView1);
            buttonA = FindViewById<Button>(Resource.Id.button1);
            buttonB = FindViewById<Button>(Resource.Id.button2);
            buttonC = FindViewById<Button>(Resource.Id.button3);
            buttonD = FindViewById<Button>(Resource.Id.button4);
        }
        private void assignValToVar(int questionNumber)
        {
            questionNoTxt.Text = game.updateCurrentQuestionTxt();
            question.Text = game.getQuestion(questionNumber).question;
            buttonA.Text = game.getQuestion(questionNumber).answerA;
            buttonB.Text = game.getQuestion(questionNumber).answerB;
            buttonC.Text = game.getQuestion(questionNumber).answerC;
            buttonD.Text = game.getQuestion(questionNumber).answerD;

        }
#region btnsClick
        private void btn1Click()
        {   //Checking if A is correct
            if(game.checkClick("A"))
            {
                //Increment general points
                game.incrementPoints();
                //IF this was last question
                if(game.amountOfQuestions == (game.currentQuestion + 1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
            //Wrong answer
            else
            {
                if (game.amountOfQuestions == (game.currentQuestion + 1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
        }
        private void btn2Click()
        {   //Checking if B is correct
            if (game.checkClick("B"))
            {
                //Increment general points
                game.incrementPoints();
                //IF this was last question
                if (game.amountOfQuestions == (game.currentQuestion+1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
            else
            {
                if (game.amountOfQuestions == (game.currentQuestion + 1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
        }
        private void btn3Click()
        {   //Checking if C is correct
            if (game.checkClick("C"))
            {
                //Increment general points
                game.incrementPoints();
                //IF this was last question
                if (game.amountOfQuestions == (game.currentQuestion + 1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
            else
            {
                if (game.amountOfQuestions == (game.currentQuestion + 1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
        }
        private void btn4Click()
        {   //Checking if D is correct
            if (game.checkClick("D"))
            {
                //Increment general points
                game.incrementPoints();
                //IF this was last question
                if (game.amountOfQuestions == (game.currentQuestion + 1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
            else
            {
                if (game.amountOfQuestions == (game.currentQuestion + 1))
                {
                    //Show the dialog box
                    //Restart Quiz
                    endOfQuiz();
                    refreshQuestionPage();
                }
                //If this wasnt last question
                else
                {
                    //pick next question
                    game.nextQuestion();
                    refreshQuestionPage();
                }
            }
        }
#endregion btnsClick
        public void endOfQuiz()
        {
            /*
            //creating alter dialog
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("End of Quiz");
            builder.SetMessage("Your score is " + game.returnFinalResult());
            builder.SetNeutralButton("Play Again", delegate
            {
                game.restartQuiz();
                refreshQuestionPage();
                game.populatingQuestionList();
            });
            builder.Show();
            */
            var intent = new Intent(this, typeof(ResultActivity));
            var json = JsonConvert.SerializeObject(game);
            intent.PutExtra("game", json);
            StartActivity(intent);
        }
    }
}
