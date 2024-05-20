using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class Score
    {
        [PrimaryKey, AutoIncrement]
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
            string DatabaseFilePath = Path.Combine(FileSystem.AppDataDirectory, "ScoringDatabase.db3");
            db = new SQLiteAsyncConnection(DatabaseFilePath);
            await db.CreateTableAsync<Score>();
            var result = db.CreateTableAsync<Score>(); 
        }
        public async Task<List<Score>> GetAllScores()
        {
            await Init();
            return await db.Table<Score>().ToListAsync();
           
        }
        public async Task<int> AddScoreData(string target, int jd, int ad, int score, string notes)
        {
            await Init();
            var data = new Score
            {
                Target = target,
                JudgedDistance = jd,
                ActualDistance = ad,
                ScoringRing = score,
                Notes = notes
            };
            return await db.InsertAsync(data);
        }
    }
}
