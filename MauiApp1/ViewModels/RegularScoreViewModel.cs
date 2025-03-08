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

        public List<int> AvailableScores { get; } = new() { 12, 10, 8, 5, 0 };
        public ObservableCollection<ScoreModel> ScoresList { get; set; } = new();

        public RegularScoreViewModel()
        {
            for (int i = 0; i < 20; i++)
            {
                ScoresList.Add(new ScoreModel { TargetNumber = i + 1, Score = null, RunningTotal = null });  // ✅ Initialize as NULL
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
            // Method to update running totals dynamically
        public void UpdateRunningTotals()
        {
            int cumulativeSum = 0;

            for (int i = 0; i < ScoresList.Count; i++)
            {
                if (ScoresList[i].Score.HasValue)  // ✅ Only update for selected targets
                {
                    cumulativeSum += ScoresList[i].Score.Value;
                    ScoresList[i].RunningTotal = cumulativeSum;  // ✅ Update RunningTotal
                }
                else
                {
                    ScoresList[i].RunningTotal = null;  // ✅ Keep unselected targets empty
                }
            }

            OnPropertyChanged(nameof(ScoresList));  // ✅ Notify UI
        }
    }

}
