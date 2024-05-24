
using Microsoft.WindowsAppSDK.Runtime;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ScoringData
    {
        [PrimaryKey, AutoIncrement]
        public int ScoreId { get; set; }
        public string Target { get; set; }
        public int JudgedDistance { get; set; }
        public int ActualDistance { get; set; }
        public int ScoringRing { get; set; }
        public string Notes { get; set; }
    }
    public class SqlDb
    {
        static SQLiteAsyncConnection db; 
        
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "ScoringDatabase.db3");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<ScoringData>();
        }
        public async Task<List<ScoringData>> GetAllScores()
        {
            await Init();
            var scores = await db.Table<ScoringData>().ToListAsync();
            return scores; 
           
        }
        public async Task AddScoreData(string target, int jd, int ad, int score, string notes)
        {
            await Init();           

            var data = new ScoringData
            {
                Target = target,
                JudgedDistance = jd,
                ActualDistance = ad,
                ScoringRing = score,
                Notes = notes
            };
            await db.InsertAsync(data);
        }
    }
}
