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
using Newtonsoft.Json;

namespace quizMySQL
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
        /*
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
        */

    }
}