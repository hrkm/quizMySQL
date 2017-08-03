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
using Newtonsoft.Json;

namespace QuizMySQL
{
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        TextView text;
        Button mainPage;
        Button playAgain;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Results);
            var gametxt = Intent.GetStringExtra("game") ?? "0";
            var game = JsonConvert.DeserializeObject<QuizGame>(gametxt);
            assignViewToVar();
            text.Text = "You got " + game.returnFinalResult() + " points, out of " + game.amountOfQuestions;

            mainPage.Click += delegate { goToMainPage();  };
            playAgain.Click += delegate { goToGame(); };
        }

        private void assignViewToVar()
        {
            text = FindViewById<TextView>(Resource.Id.quizResult);
            mainPage = FindViewById<Button>(Resource.Id.buttonMainPage);
            playAgain = FindViewById<Button>(Resource.Id.buttonPlayAgain);
        }

        private void goToMainPage()
        {
            var intent = new Intent(this, typeof(MainPageActivity));
            StartActivity(intent);
        }

        private void goToGame()
        {
            var intent = new Intent(this, typeof(GameActivity));
            StartActivity(intent);
        }
    }
}