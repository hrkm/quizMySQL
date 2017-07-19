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


namespace quizMySQL
{
    [Activity(Label = "quizMySQL", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        dbManager database;
        QuizGame game;
        QuizQuestion qq;
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
            SetContentView(Resource.Layout.Main);
            game = new QuizGame();
            game.populatingQuestionList();
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
        }
        //Testing function, to be called once.
        private void addToDB()
        {
            database.add("Question1", "answer1A", "answer1B", "answer1C", "answer1D", "B");
            database.add("Question2", "answer2A", "answer2B", "answer2C", "answer2D", "B");
            database.add("Question3", "answer3A", "answer3B", "answer3C", "answer3D", "B");
            database.add("Question4", "answer4A", "answer4B", "answer4C", "answer4D", "B");
            database.add("Question5", "answer5A", "answer5B", "answer5C", "answer5D", "B");
            database.add("Question6", "answer6A", "answer6B", "answer6C", "answer6D", "B");
            database.add("Question7", "answer7A", "answer7B", "answer7C", "answer7D", "B");
            database.add("Question8", "answer8A", "answer8B", "answer8C", "answer8D", "B");
            database.add("Question9", "answer9A", "answer9B", "answer9C", "answer9D", "B");
            database.add("Question10", "answer10A", "answer10B", "answer10C", "answer10D", "B");
            database.add("Question11", "answer11A", "answer11B", "answer11C", "answer11D", "B");
            database.add("Question12", "answer12A", "answer12B", "answer12C", "answer12D", "B");
            database.add("Question13", "answer13A", "answer13B", "answer13C", "answer13D", "B");
            database.add("Question14", "answer14A", "answer14B", "answer14C", "answer14D", "B");
            database.add("Question15", "answer15A", "answer15B", "answer15C", "answer15D", "B");
            database.add("Question16", "answer16A", "answer16B", "answer16C", "answer16D", "B");
            database.add("Question17", "answer17A", "answer17B", "answer17C", "answer17D", "B");
            database.add("Question18", "answer18A", "answer18B", "answer18C", "answer18D", "B");
            database.add("Question19", "answer19A", "answer19B", "answer19C", "answer19D", "B");
        }
    }
}
