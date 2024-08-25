using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ScoreListViewModel : INotifyPropertyChanged
    {
        public List<ScoringData> ScoresHistory { get; set; }
        public List<string> ScoresList { get; set; }
        public ObservableCollection<string> ReviewScoreData { get; set; }
        public List<ScoringData> scores; 
        public SqlDb db;

        public ScoreListViewModel()
        {
           ReviewScoreData = new ObservableCollection<string>(); 
           PopulateScoringDatesDropdownList();            
        }

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)ReviewScoreData).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)ReviewScoreData).PropertyChanged -= value;
            }
        }

        public void PopulateScoringDatesDropdownList()
        {
            var dates = GetRangeDateFromDatabase(); 
            ScoresList = [];
            foreach (var date in dates)
            {
                ScoresList.Add(date);
            }
        }

        public List<string> GetRangeDateFromDatabase()
        {
            db = new SqlDb();
            var newList = new List<string>();
            var scores = db.GetAllDates();
            foreach (var sc in scores)
            {
                newList.Add(sc.RangeDate);
            }
            var noDupes = newList.Distinct().ToList();
            return noDupes; 
        }

        public void GetScoreDataWithSelectedDate(string date)
        {
            var data = db.GetScoringDataFromDate(date);
            foreach(var dt in data)
            {
                ReviewScoreData.Add(dt.Target.ToString()); 
            }
            var model = new ScoreListViewModel(); 
        }

        public void RemoveDateFromList(string date)
        {
            var model = new ScoreListViewModel(); 
            ReviewScoreData.Remove(date); 
        }
    }
}
