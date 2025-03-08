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
   using System.ComponentModel;

public class ScoreModel : INotifyPropertyChanged
{
    private int? _score;
    private int? _runningTotal;

    public int TargetNumber { get; set; }

    public int? Score  // ✅ Allow null values for unselected targets
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

    public int? RunningTotal  // ✅ Make this nullable
    {
        get => _runningTotal;
        set
        {
            if (_runningTotal != value)
            {
                _runningTotal = value;
                OnPropertyChanged(nameof(RunningTotal));
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