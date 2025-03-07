using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using SQLite;
namespace MauiApp1
{
    public class ScoreModel : INotifyPropertyChanged
    {
        private int _score;
        private int _consecutiveScore;

        public int TargetNumber { get; set; }

        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged(nameof(Score));
                }
            }
        }

        public int ConsecutiveScore
        {
            get => _consecutiveScore;
            set
            {
                if (_consecutiveScore != value)
                {
                    _consecutiveScore = value;
                    OnPropertyChanged(nameof(ConsecutiveScore));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}