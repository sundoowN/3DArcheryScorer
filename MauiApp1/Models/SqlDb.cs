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
    public class ScoringData
    {
        public string Target { get; set; }
        public int JudgedDistance { get; set; }
        public int ActualDistance { get; set; }
        public int ScoringRing { get; set; }
        public string Notes { get; set; }
        public string RangeDate { get; set; }
        public int IsUnknown { get; set; }
        public int TargetNumber { get; set; }
    }

    public class SqlDb
    {
        public static SQLiteConnection conn;
        public SqliteCommand connection;
        public static string databasePath; 
        
        public static async void Init()
        {
            if (conn != null)
            {
                return;
            }
            databasePath = Path.Combine(FileSystem.AppDataDirectory, "ScoringDatabase.db3");
            conn = new SQLiteConnection(databasePath);
            conn.CreateTable<ScoringData>();
        }
        public async Task<List<ScoringData>> GetAllScores()
        {
            Init();
            var scoreList = conn.Table<ScoringData>().ToList();
            return scoreList; 
        }
        public async Task AddScoreData(string target, int jd, int ad, int score, string notes, string rangeDate, int isUnknown, int number)
        {
            Init();
            var data = new ScoringData
            {
                Target = target,
                JudgedDistance = jd,
                ActualDistance = ad,
                ScoringRing = score,
                Notes = notes,
                RangeDate = rangeDate,
                IsUnknown = isUnknown,
                TargetNumber = number
            };
            conn.Insert(data);
        }

        public async Task AddKnownScoreData(string target, int yards, int score, string notes, string rangeDate, int isUnknown)
        {
            Init();
            var data = new ScoringData()
            {
                Target = target,
                ActualDistance = yards,
                ScoringRing = score,
                Notes = notes,
                RangeDate = rangeDate,
                IsUnknown = isUnknown
            };
            conn.Insert(data);
        }

        public TableQuery<ScoringData> GetAllDates()
        {
            Init();
            var datesL = conn.Table<ScoringData>().Where(r => r.RangeDate != null);
            return datesL; 
        }

        public TableQuery<ScoringData> GetTotalScore(string date)
        {
            Init(); 
            var scores = conn.Table<ScoringData>().Where(r => r.RangeDate == date);
            return scores; 
        }

        public List<ScoringData> GetScoringDataFromDate(string date)
        {
            Init();
            var scores = conn.Table<ScoringData>().Where(r => r.RangeDate == date).ToList();
            return scores;
        }

        public void RemoveScoreByDate(string rangeDate)
        {
            var scoresToRemove = conn.Table<ScoringData>().Where(r => r.RangeDate == rangeDate).ToList();
            foreach (var score in scoresToRemove)
            {
                conn.Delete(score);
            }
        }

        public int GetTotalScoreByDate(string rangeDate)
        {
            var scores = conn.Table<ScoringData>()
                            .Where(r => r.RangeDate == rangeDate)
                            .Select(r => r.ScoringRing)
                            .ToList();

            return scores.Sum();
        }

        public string GetLastUnknownRangeDate()
        {
            Init(); 
            var lrd = conn.Table<ScoringData>()
                .Where(x => x.IsUnknown == 1)
                .OrderByDescending(x => x.RangeDate)
                .Select(x => x.RangeDate)
                .FirstOrDefault();

            return lrd; 
        }
        
        public string GetLastKnownRangeDate()
        {
            Init(); 
            var lrd = conn.Table<ScoringData>()
                .Where(x => x.IsUnknown == 0)
                .OrderByDescending(x => x.RangeDate)
                .Select(x => x.RangeDate)
                .FirstOrDefault();

            return lrd; 
        }

        public ScoringData GetUnknownRangeDataByDate(string rangeDate)
        {
            var rangeData = conn.Table<ScoringData>()
                            .Where(x => x.RangeDate == rangeDate && x.IsUnknown == 1)
                            .OrderByDescending(x => x.TargetNumber) // Assuming ShootingDate helps in determining the most recent
                            .FirstOrDefault();

            return rangeData;
        }
        
        public ScoringData GetKnownRangeDataByDate(string rangeDate)
        {
            var rangeData = conn.Table<ScoringData>()
                .Where(x => x.RangeDate == rangeDate && x.IsUnknown == 0)
                .OrderByDescending(x => x.TargetNumber) // Assuming ShootingDate helps in determining the most recent
                .FirstOrDefault();

            return rangeData;
        }
    }
}