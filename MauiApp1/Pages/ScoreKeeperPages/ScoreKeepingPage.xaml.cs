using System;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using MauiApp1.Models;
using MauiApp1.Pages;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace MauiApp1;
    public partial class ScoreKeepingPage : ContentPage
    {
        public MauiProgram maui;
        public string selectedTarget = string.Empty;
        public ViewModel model;
        public SqlDb db; 
        public int targetCounter = 1;
        public string RangeDate; 
        public ScoreKeepingPage()
        {
            InitializeComponent();
            targetLabel.Text = "Target #" + targetCounter.ToString(); 
            maui = new MauiProgram();
            model = new ViewModel();
            db = new SqlDb(); 
            GetRangeAndDate(); 
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
                await DisplayAlert($"Target: {targetCounter}", "Target saved", "OK");
                targetCounter++;
                targetLabel.Text = "Target #" + targetCounter.ToString(); 
            }
            else
            {
                await DisplayAlert("Alert", "Round is over.", "OK");
                await Navigation.PushAsync(new ArcheryHomePage());
            }
            // JudgedYardages.SelectedIndex = -1; //clears the judged yardages box
            // ActualYardages.SelectedIndex = -1; //clears the actual yardages box
            // targetPicker.SelectedIndex = -1; ;
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
                targetImage.Source = "hcbuck.jpeg";
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

        public async void GetRangeAndDate()
        {
            bool answer = await DisplayAlert("Round Options", "Is this a new round or would you like to pick up where you left off?", "New Round", "Continue");
            if(answer == true)
            {
                var result = await DisplayPromptAsync("Range", "Where are you shooting today?");
                var date = DateTime.Now;
                var dates = date.ToString("MM/dd/yyyy"); 
                result = result + " " + dates; 
                RangeDate = result; 
            }
            else
            {
                RangeDate = db.GetLastRangeDate(); 
                var data = db.GetRangeDataByDate(RangeDate);  
                targetLabel.Text = "Target #" + (data.ScoreId + 1); 
                targetCounter = targetCounter + data.ScoreId; 

            }
        }
    }
