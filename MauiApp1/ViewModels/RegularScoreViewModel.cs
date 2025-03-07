using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MauiApp1
{
    public class RegularScoreViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ScoreModel> ScoresList { get; set; } = new ObservableCollection<ScoreModel>();
        public ObservableCollection<int> AvailableScores { get; } = new ObservableCollection<int> { 12, 10, 8, 5, 0 };
        private int _totalScore;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int TotalScore
        {
            get => _totalScore;
            set
            {
                if (_totalScore != value)
                {
                    _totalScore = value;
                    OnPropertyChanged(nameof(TotalScore)); // Notify UI
                }
            }
        }

        public RegularScoreViewModel()
        {
            // Initialize ScoresList with 20 targets (you can change the default values as needed)
            for (int i = 0; i < 20; i++)
            {
                ScoresList.Add(new ScoreModel { TargetNumber = i + 1, Score = 0 });
            }

            // Set initial TotalScore
            UpdateRunningTotal();
        }

        public void UpdateRunningTotal()
        {
            // Calculate the cumulative total
            TotalScore = ScoresList.Sum(score => score.Score);
            OnPropertyChanged(nameof(ScoresList)); // Notify UI to update the ScoresList
        }

        public void SetScore(int targetIndex, int score)
        {
            // Update the selected score and recalculate the total
            ScoresList[targetIndex].Score = score;
            UpdateRunningTotal();
        }
    }
}
