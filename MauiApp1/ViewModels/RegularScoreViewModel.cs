using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class RegularScoreViewModel 
    {
       public ObservableCollection<int> Scores; 
       public RegularScoreViewModel()
       {
            Scores = [12, 10, 8, 5, 0];
       }
    }
}
