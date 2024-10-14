using MauiApp1; 

namespace MauApp1.Models
{
    public class BowSetup
    {
        public BowSetup(string bow, string sights, string stabs, string release, string other)
        {
            //the id needs to retrieve the lastest from the table and set it to +1 
            Bow = bow; 
            Sights = sights; 
            Stabilizers = stabs; 
            Release = release; 
            DateCreated = DateTime.Now; 
        }
        public int Id { get; set; }
        public string Bow { get; set; }
        public string Sights { get; set; }
        public string Stabilizers { get; set; }
        public string Release { get; set; }
        public DateTime DateCreated { get; set; }

        
    }
}