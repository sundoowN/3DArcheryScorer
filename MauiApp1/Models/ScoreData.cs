using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class ScoreData
    {
        public ScoreData(string target, string judged, string actual, string score, string notes)
        {
            Target = target; 
            Judged = judged;
            Actual = actual;
            Score = score;
            Notes = notes; 
        }
        public string Target { get; set; }
        public string Judged { get; set; }
        public string Actual { get; set; }
        public string Score { get; set; }
        public string Notes { get; set; }
    }
}
