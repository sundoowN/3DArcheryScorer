using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ViewModel
    {
        public List<string> Targets { get; set; }
        public SqlDb db; 
        public List<string> TargetsList { get; set; } = new List<string>();
        public List<int> Scores { get; set; }
        public List<int> JudgedYardage { get; set; }
        public List<int> ActualYardage { get; set; }
        public string SelectedTarget { get; set; }

        public ViewModel()
        {
            db = new SqlDb(); 
            AddTargetsToList(); 
            PopulateScoresPicker();
            PopulateYardagesPickers();
        }
        public void AddTargetsToList()
        {
            TargetsList = ["African Impala", "African Warthog", "Aoudad", "Black Bear", "Black Panther",
                "Blesbok", "Chamois", "Cinnamon Bear", "Coyote", "Grazing Doe", "HillCountry Buck", "Howling Wolf",
                "Hyena", "Javelina", "Large Alert Deer", "Leopard", "Lynx", "Medium Deer", "Pronghorn Antelope", "Russian Boar",
                "Turkey", "Wild Boar", "Wolf", "Wolverine", "XL Deer"]; 
        }
        public void PopulateScoresPicker()
        {
            Scores = [12, 10, 8, 5, 0];
        }
        public void PopulateYardagesPickers()
        {
            JudgedYardage = new List<int>();
            ActualYardage = new List<int>(); 
            for (int i = 0; i <= 60; i++)
            {
                JudgedYardage.Add(i);
                ActualYardage.Add(i); 
            }
        }
    }
}
