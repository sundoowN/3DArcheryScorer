using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class BowViewModel 
    {
        public ObservableCollection<string> BowsList { get; set; }
        public ObservableCollection<Bow> SelectedBowData {get; set;}
        public BowDb db; 

        public BowViewModel()
        {
            db = new BowDb();
            BowsList = new ObservableCollection<string>();  
            SelectedBowData = new ObservableCollection<Bow>(); 
            PopulateBowsDropdownList();    
        }

        public void PopulateBowsDropdownList()
        {
            BowsList.Clear();
            var bows = GetBowsFromDatabase(); 
            foreach (var bow in bows)
            {
                BowsList.Add(bow);
            }
        }

        public List<string> GetBowsFromDatabase()
        {
            var newList = new List<string>();
            var bows = db.GetAllBows();
            foreach (var a in bows)
            {
                newList.Add(a);
            }
            var noDupes = newList.Distinct().ToList();
            return noDupes; 
        }

        public void PopulateBowDataTable(string bow)
        {
            SelectedBowData.Clear(); 
            var bowData = db.GetBowData(bow);
            foreach(var thinger in bowData)
            {
                SelectedBowData.Add(thinger);
            }
        }

    }
}
