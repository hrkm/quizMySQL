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
using QuizMySQL.DataBase;
using Newtonsoft.Json;

namespace QuizMySQL
{
    [Activity(Label = "quizMySQL", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainPageActivity : Activity
    {
        Button buttonPlay;

        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainPage);
            assignViewToVar();
            buttonPlay.Click += delegate { goToGame(); };
            // Create your application here
        }

        private void assignViewToVar()
        {
            buttonPlay = FindViewById<Button>(Resource.Id.buttonPlay);
        }

        private void goToGame()
        {
            var intent = new Intent(this, typeof(GameActivity));
            StartActivity(intent);
        }
    }
}