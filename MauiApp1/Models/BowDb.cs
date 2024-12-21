using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MauiApp1
{
    public class Bow
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }         
        public string Name {get; set;}
        public string Company { get; set; }
        public string Model {get; set;}
        public string DrawLengthWeight {get; set;}
        public string Strings {get; set;}
        public string Sight {get; set;}
        public string SightNotes {get; set;}
        public string Bars {get; set;}
        public string BarsNotes {get; set;}
        public string Release {get; set;}
        public string Rest {get; set;}
    }

    public class BowDb
    {
        public static SQLiteConnection conn;
        public static string databasePath; 
        
        public static async void Init()
        {
            if (conn != null)
            {
                return;
            }
            databasePath = Path.Combine(FileSystem.AppDataDirectory, "ScoringDatabase.db3");
            conn = new SQLiteConnection(databasePath);
            conn.CreateTable<Bow>();
        }

        public void AddBowData(string name, string company, string model, string drawlngwt, string strings, string sight, string sightnotes, string bars, string barsnotes, string release, string rest)
        {
            Init();
            var data = new Bow
            {
                Name = name, 
                Company = company,
                Model = model,
                DrawLengthWeight = drawlngwt,
                Strings = strings,
                Sight = sight, 
                SightNotes = sightnotes, 
                Bars = bars,
                BarsNotes = barsnotes,
                Release = release,
                Rest = rest
            };
            conn.Insert(data);
        }

        public List<string> GetAllBows()
        {
            Init();
            return conn.Table<Bow>().Select(a => a.Name).ToList();
        }

        public List<string> GetAllBowNames()
        {
            Init();
            return conn.Table<Bow>().Select(a => a.Name).ToList();
        }

        public List<Bow> GetBowData(string bow) 
        {
            Init(); 
            return conn.Table<Bow>().Where(r => r.Name == bow).ToList();
        }

    }
}