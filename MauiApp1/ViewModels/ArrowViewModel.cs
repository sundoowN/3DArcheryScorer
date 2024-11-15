using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ArrowViewModel 
    {
        public ObservableCollection<string> ArrowsList { get; set; }
        public ObservableCollection<Arrow> SelectedArrowData {get; set;}
        public ArrowDb db; 

        public ArrowViewModel()
        {
            db = new ArrowDb();
            ArrowsList = new ObservableCollection<string>();  
            SelectedArrowData = new ObservableCollection<Arrow>(); 
            PopulateArrowsDropdownList();    
        }

        public void PopulateArrowsDropdownList()
        {
            ArrowsList.Clear();
            var arrows = GetArrowsFromDatabase(); 
            foreach (var arr in arrows)
            {
                ArrowsList.Add(arr);
            }
        }

        public List<string> GetArrowsFromDatabase()
        {
            var newList = new List<string>();
            var arrows = db.GetAllArrows();
            foreach (var a in arrows)
            {
                newList.Add(a);
            }
            var noDupes = newList.Distinct().ToList();
            return noDupes; 
        }

        public void PopulateArrowDataTable(string arrow)
        {
            SelectedArrowData.Clear(); 
            var arrowData = db.GetArrowData(arrow);
            foreach(var thinger in arrowData)
            {
                SelectedArrowData.Add(thinger);
            }
        }

        // public void RemoveArrowFromArrowsList(string arrow)
        // {
        //     db.RemoveScoreByDate(date);
        // }
    }
}
