using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MauiApp1
{
    public class RegularScoreViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly SqlDb _db = new SqlDb();

        public List<int> AvailableScores { get; } = new() { 12, 10, 8, 5, 0 };
        public ObservableCollection<ScoreModel> ScoresList { get; set; } = new();

        public RegularScoreViewModel()
        {
            for (int i = 0; i < 20; i++)
            {
                ScoresList.Add(new ScoreModel
                {
                    TargetNumber = i + 1,
                    Score = null,
                    RunningTotal = null
                });
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateRunningTotals()
        {
            int cumulativeSum = 0;

            for (int i = 0; i < ScoresList.Count; i++)
            {
                if (ScoresList[i].Score.HasValue)
                {
                    cumulativeSum += ScoresList[i].Score.Value;
                    ScoresList[i].RunningTotal = cumulativeSum;
                }
                else
                {
                    ScoresList[i].RunningTotal = null;
                }
            }

            OnPropertyChanged(nameof(ScoresList));
        }

        public void LoadRegularScoresFromDatabase(string date)
        {
            var savedScores = _db.GetRegularScoresByDate(date);

            if (savedScores == null || !savedScores.Any())
                return;

            foreach (var saved in savedScores)
            {
                var target = ScoresList.FirstOrDefault(x => x.TargetNumber == saved.TargetNumber);
                if (target != null)
                {
                    target.Score = saved.Score;
                }
            }

            UpdateRunningTotals();
        }

        public void SaveRegularScore(int targetNumber, int? score, string date)
        {
            if (!score.HasValue) return; // ⛔ Skip saving if no score chosen
            _db.AddOrUpdateRegularScore(targetNumber, score.Value, date);
        }

        public void SaveAllRegularScores(string date)
        {
            foreach (var s in ScoresList)
            {
                if (s.Score.HasValue) // ✅ only save chosen scores
                    _db.AddOrUpdateRegularScore(s.TargetNumber, s.Score.Value, date);
            }
        }

    }
}
