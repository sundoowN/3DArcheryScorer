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

    // Available Scores for the Picker
    public List<int> AvailableScores { get; } = new List<int> { 12, 10, 8, 5, 0 };

    // Holds the scores for each target (1-20)
    public ObservableCollection<ScoreModel> ScoresList { get; set; } = new ObservableCollection<ScoreModel>();

    public RegularScoreViewModel()
    {
        // Initialize ScoresList with 20 targets
        for (int i = 0; i < 20; i++)
        {
            ScoresList.Add(new ScoreModel { TargetNumber = i + 1, Score = 0, RunningTotal = 0 });
        }
    }

    // Method to update running totals dynamically
    public void UpdateRunningTotals()
    {
        int cumulativeSum = 0;

        for (int i = 0; i < ScoresList.Count; i++)
        {
            cumulativeSum += ScoresList[i].Score;  // Add current score
            ScoresList[i].RunningTotal = cumulativeSum; // Update cumulative score
        }

        // Notify the UI that ScoresList has changed
        OnPropertyChanged(nameof(ScoresList));
    }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
