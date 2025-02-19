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
       public List<string> Scores { get; set; }

       public RegularScoreViewModel()
       {
            Scores = new List<string> { "12", "10", "8", "5", "0" };
       }
    }
}
