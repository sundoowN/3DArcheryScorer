using MauiApp1.Models;
using MauiApp1.Pages;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        //public List<string> TargetsList = new List<string>();
        public MauiProgram maui;
        public string selectedTarget = string.Empty;
        public ViewModel model;
        public int targetCounter = 1;
        //public List<string> scores = [];
        public SqlDb db;
        public string RangeDate; 
       public MainPage()
        {
            InitializeComponent();
            targetLabel.Text = "Target #" + targetCounter.ToString(); 
            maui = new MauiProgram();
            model = new ViewModel();
            db = new SqlDb();
            if (RangeDate == null)
            {
                GetRangeAndDate(); 
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SetTargetImage(); 
        }

        private async void SubmitUserScore(object sender, EventArgs e)
        {
            if (targetCounter <= 20)
            {
                var jd = Convert.ToInt32(JudgedYardages.SelectedItem);
                var ad = Convert.ToInt32(ActualYardages.SelectedItem); 
                var st = targetPicker.SelectedItem.ToString();
                var score = Convert.ToInt32(ScorePicker.SelectedItem);
                var notes = Notestb.Text.ToString();
                await db.AddScoreData(st, jd, ad, score, notes, RangeDate);
            }
            else if(targetCounter == 21)
            {
                await DisplayAlert("Alert", "Round is over.", "OK");
            }
            await DisplayAlert($"Target: {targetCounter}", "Target saved", "OK");
            targetCounter++;
            targetLabel.Text = "Target #" + targetCounter.ToString(); 
        }

        public void SetTargetImage()
        {
            if(targetPicker.SelectedItem.Equals("African Impala"))
            {
                targetImage.Source = "africanimpala.jpeg";
            }
            if (targetPicker.SelectedItem.Equals("African Warthog"))
            {
                targetImage.Source = "afrwarthog.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Aoudad"))
            {
                targetImage.Source = "aouda.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Black Bear"))
            {
                targetImage.Source = "blackbear.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Blesbok"))
            {
                targetImage.Source = "blesbo.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Black Panther"))
            {
                targetImage.Source = "blkpanther.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Cinnamon Bear"))
            {
                targetImage.Source = "cbear.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Chamois"))
            {
                targetImage.Source = "chamoi.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Coyote"))
            {
                targetImage.Source = "coyote.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Grazing Doe"))
            {
                targetImage.Source = "grazingdoe.jpg";
            }
            if (targetPicker.SelectedItem.Equals("HillCountry Buck")) //check
            {
                targetImage.Source = "hcbuck.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Howling Wolf"))
            {
                targetImage.Source = "howlwolf.jpeg";
            }
            if (targetPicker.SelectedItem.Equals("Hyena"))
            {
                targetImage.Source = "hyena.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Javelina"))
            {
                targetImage.Source = "javelina.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Large Alert Deer"))
            {
                targetImage.Source = "ladeer.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Leopard"))
            {
                targetImage.Source = "leopar.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Lynx"))
            {
                targetImage.Source = "lyn.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Medium Deer"))
            {
                targetImage.Source = "meddeer.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Mule Deer"))
            {
                targetImage.Source = "muledeer.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Pronghorn Antelope"))
            {
                targetImage.Source = "pronghornantelope.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Russian Boar"))
            {
                targetImage.Source = "russianboar.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Turkey"))
            {
                targetImage.Source = "turk.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Wild Boar"))
            {
                targetImage.Source = "wildboar.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Wolf"))
            {
                targetImage.Source = "wolf.jpg";
            }
            if (targetPicker.SelectedItem.Equals("Wolverine"))
            {
                targetImage.Source = "wolverin.jpg";
            }
            if (targetPicker.SelectedItem.Equals("XL Deer"))
            {
                targetImage.Source = "xldeer.jpg";
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
                if(folders.Length == 8)
                {
                    var folder = folders[6];
                    path = folder.FullName; 
                }
            }
            return path;
        }

        public async void GetRangeAndDate()
        {
            var result = await DisplayPromptAsync("Range", "Where are you shooting today?");
            var date = DateTime.Now;
            var dates = date.ToString("MM/dd/yyyy"); 
            result = result + " " + dates; 
            RangeDate = result; 
        }
    }

}
