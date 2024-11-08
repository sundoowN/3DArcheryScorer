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
    public class Arrow
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }         
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

        public void AddArrowData(string company, string model, int length, int point, string fletch, string nock, string other)
        {
            Init();
            var data = new Arrow
            {
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

        public List<Arrow> GetAllArrows()
        {
            Init();
            return conn.Table<Arrow>().ToList();
        }
    }
}