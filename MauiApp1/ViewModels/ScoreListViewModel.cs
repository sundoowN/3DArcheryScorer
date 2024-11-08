using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ScoreListViewModel 
    {
        public ObservableCollection<string> ScoresList { get; set; }
        public SqlDb db; 
        public ObservableCollection<ScoringData> ReviewScoreData { get; set; }

        public ScoreListViewModel()
        {
            db = new SqlDb();
            PopulateScoringDatesDropdownList();    
            ReviewScoreData = new ObservableCollection<ScoringData>();  
        }

        public void PopulateScoringDatesDropdownList()
        {
            var dates = GetRangeDateFromDatabase(); 
            ScoresList = new ObservableCollection<string>(); 
            foreach (var date in dates)
            {
                ScoresList.Add(date);
            }
        }

        public List<string> GetRangeDateFromDatabase()
        {
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
            ReviewScoreData.Clear(); 
            var Scores = db.GetScoringDataFromDate(date); 
            foreach(var thinger in Scores)
            {
                ReviewScoreData.Add(thinger); 
            }
        }

        public void RemoveDateFromList(string date)
        {
            db.RemoveScoreByDate(date);
        }
    }
}
