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
        public List<string> ScoresList { get; set; }
        public SqlDb db; 
        public ObservableCollection<string> ReviewScoreData { get; set; }

        public ScoreListViewModel()
        {

            db = new SqlDb();
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
            //ScoresList = ["test", "test2"];
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
            var model = new ScoreListViewModel(); 
        }

        public void RemoveDateFromList(string date)
        {
            var model = new ScoreListViewModel(); 
            ReviewScoreData.Remove(date); 
        }
    }
}
