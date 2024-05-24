using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ScoreListViewModel
    {
        public List<ScoringData> ScoresHistory { get; set; }
        public List<string> ScoresList { get; set; }
        public List<ScoringData> scores; 
        public SqlDb db;
        public ScoreListViewModel()
        {
            GetScoresFromDB();
        }
        public void PopulateScoresHistory()
        {
            ScoresList = [];
            //foreach(var thing in ScoresHistory)
            //{
            //    ScoresList.Add(thing); 
            //}
            
        }
        public async void GetScoresFromDB()
        {
            db = new SqlDb();
            var scores = await db.GetAllScores();
            await Task.Delay(5000);

            ScoresList = [];
            foreach (var score in scores)
            {
                ScoresList.Add(score.Target);
            }
            //PopulateScoresHistory(); 
        }
    }
}
