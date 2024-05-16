using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ViewModel
    {
        public List<string> Targets { get; set; }
        public List<int> Scores { get; set; }
        public string SelectedTarget { get; set; }

        public ViewModel()
        {
            AddTargetsToList(); 
            AddScoresToPicker(); 
        }
        public void AddTargetsToList()
        {
            Targets = new List<string>();
            Targets = ["African Impala", "African Warthog", "Aoudad", "Black Bear", "Black Panther",
                "Blesbok", "Chamois", "Cinnamon Bear", "Coyote", "Grazing Doe", "HillCountry Buck", "Howling Wolf",
                "Hyena", "Javelina", "Large Alert Deer", "Leopard", "Lynx", "Medium Deer", "Pronghorn Antelope", "Russian Boar",
                "Turkey", "Wild Boar", "Wolf", "Wolverine", "XL Deer"];
        }
        public void AddScoresToPicker()
        {
            Scores = [12, 10, 8, 5, 0];
        }

        public void AddScoreDataToFile(string json)
        {
            var path = GetScoreDataFolderLocation();
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.ToString("MM-dd-yy");
            var newPath = Path.Combine(path, "Course" + date + ".json");
            if (File.Exists(newPath))
            {

                    File.AppendAllText(newPath, json);
            }
            else
            {
                File.WriteAllText(newPath, json);
            }
        }

        public string GetScoreDataFolderLocation()
        {
            var anotherDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var directory = new DirectoryInfo(anotherDir ?? Directory.GetCurrentDirectory());
            var path = string.Empty;

            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
                var folders = directory.GetDirectories();
                if (folders.Length == 8)
                {
                    var folder = folders[6];
                    path = folder.FullName;
                }
            }
            return path;
        }

        public string GetImagesFolderLocation()
        {
            var anotherDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var mainDir = FileSystem.Current.AppDataDirectory;
            //var dir = new DirectoryInfo(mainDir);// ?? Directory.GetCurrentDirectory());
            var directory = new DirectoryInfo(anotherDir ?? Directory.GetCurrentDirectory()); //this is the problem child
            var path = string.Empty;

            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
                var folders = directory.GetDirectories();
                if (folders.Length > 1)
                {
                    if (folders.Length == 9)
                    {
                        path = folders[8].ToString();
                    }
                }
            }
            return path;
        }
    }
}
