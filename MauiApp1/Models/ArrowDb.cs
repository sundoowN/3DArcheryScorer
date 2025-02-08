using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using SQLite;
namespace MauiApp1
{
    public class Arrow
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }         
        public string Name { get; set; }
        public string Company {get; set;}
        public string Model {get; set;}
        public int Length {get; set;}
        public int PointWeight {get; set;}
        public string Fletch {get; set;}
        public string Nock {get; set;}
        public string Other {get; set;}
    }

    public class ArrowDb
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
            conn.CreateTable<Arrow>();
        }

        public void AddArrowData(string name, string company, string model, int length, int point, string fletch, string nock, string other)
        {
            Init();
            var data = new Arrow
            {
                Name = name,
                Company = company,
                Model = model,
                Length = length,
                PointWeight = point,
                Fletch = fletch, 
                Nock = nock, 
                Other = other
            };
            conn.Insert(data);
        }

        public List<string> GetAllArrows()
        {
            Init();
            return conn.Table<Arrow>().Select(a => a.Name).ToList();
        }

        public List<string> GetAllArrowNames()
        {
            Init();
            return conn.Table<Arrow>().Select(a => a.Name).ToList();
        }

        public List<Arrow> GetArrowData(string arrow)
        {
            Init(); 
            return conn.Table<Arrow>().Where(r => r.Name == arrow).ToList();
        }

    }
}