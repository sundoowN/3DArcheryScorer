using System;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using MauiApp1.Models;
using MauiApp1.Pages;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace MauiApp1;
    public partial class UnknownScoreKeepingPage : ContentPage
    {
        public MauiProgram maui;
        public string selectedTarget = string.Empty;
        public ViewModel model;
        public SqlDb db; 
        public int targetCounter = 1;
        public string RangeDate; 
        public UnknownScoreKeepingPage()
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
            try
            {
                // Validate required fields
                if (JudgedYardages.SelectedItem == null || ScorePicker.SelectedItem == null)
                {
                    await DisplayAlert("Missing Data",
                        "Please select Judged Yardage and Score before submitting.",
                        "OK");
                    return;
                }

                // Parse required fields
                if (!int.TryParse(JudgedYardages.SelectedItem.ToString(), out int jd) ||
                    !int.TryParse(ScorePicker.SelectedItem.ToString(), out int score))
                {
                    await DisplayAlert("Invalid Entry",
                        "One or more selected values could not be read properly. Please reselect them.",
                        "OK");
                    return;
                }

                // Optional Actual Yardage
                int? ad = null;
                if (ActualYardages.SelectedItem != null &&
                    int.TryParse(ActualYardages.SelectedItem.ToString(), out int parsedAd))
                {
                    ad = parsedAd;
                }

                // Optional Notes
                var notes = Notestb?.Text ?? string.Empty;

                // Safety check for RangeDate
                if (string.IsNullOrEmpty(RangeDate))
                {
                    await DisplayAlert("Error", "No range or date found. Please start a new round.", "OK");
                    await Navigation.PopAsync();
                    return;
                }

                // Save current target
                var st = targetPicker.SelectedItem?.ToString() ?? $"Target {targetCounter}";
                await db.AddScoreData(st, jd, ad ?? 0, score, notes, RangeDate, 1, targetCounter);

                // Check if this is the last target
                if (targetCounter < 20)
                {
                    await DisplayAlert($"Target: {targetCounter}", "Target saved successfully!", "OK");

                    // Increment counter and update label for next target
                    targetCounter++;
                    targetLabel.Text = $"Target #{targetCounter}";

                    // Reset UI for next entry
                    JudgedYardages.SelectedIndex = -1;
                    ActualYardages.SelectedIndex = -1;
                    ScorePicker.SelectedIndex = -1;
                    Notestb.Text = string.Empty;
                }
                else
                {
                    // Last target, do NOT increment the counter or update label
                    await DisplayAlert("Round Complete", "You've reached all 20 targets. Round is over.", "OK");
                    await Navigation.PushAsync(new ArcheryHomePage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",
                    $"An unexpected error occurred while saving your score:\n\n{ex.Message}",
                    "OK");
            }
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
        string action = await DisplayActionSheet(
            "Round Options",
            "Go Back", // Cancel button text (appears at bottom)
            null,
            "New Round", "Continue");

        // Handle "Go Back" early
        if (action == "Go Back" || string.IsNullOrEmpty(action))
        {
            await Navigation.PopAsync(); // Take the user back
            return;
        }

        if (action == "New Round")
        {
            bool validInput = false;
            string result = null;

            while (!validInput)
            {
                result = await DisplayPromptAsync("Range", "Where are you shooting today?",
                    "OK", "Cancel", "e.g. Outdoor Range", maxLength: 50);

                // User pressed Cancel
                if (result == null)
                {
                    bool retry = await DisplayAlert(
                        "Cancelled",
                        "You must enter a range name to start a new round.",
                        "Try Again", "Go Back");

                    if (!retry)
                    {
                        // User chose “Go Back”
                        await Navigation.PopAsync();
                        return;
                    }
                    else
                    {
                        continue; // Ask again
                    }
                }

                // Empty input check
                if (string.IsNullOrWhiteSpace(result))
                {
                    await DisplayAlert("Invalid", "Range name cannot be empty.", "OK");
                    continue;
                }

                validInput = true;
            }

            // Add current date
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            RangeDate = $"{result} {date}";
        }
        else if (action == "Continue")
        {
            RangeDate = db.GetLastUnknownRangeDate();

            if (string.IsNullOrEmpty(RangeDate))
            {
                bool restart = await DisplayAlert(
                    "No Previous Round",
                    "No saved round found. Would you like to start a new round?",
                    "Yes", "No");

                if (restart)
                    GetRangeAndDate();
                else
                    await Navigation.PopAsync();

                return;
            }

            var data = db.GetUnknownRangeDataByDate(RangeDate);

            if (data == null)
            {
                bool restart = await DisplayAlert(
                    "Data Error",
                    "Could not load round data. Start a new round?",
                    "Yes", "No");

                if (restart)
                    GetRangeAndDate();
                else
                    await Navigation.PopAsync();

                return;
            }

            targetLabel.Text = "Target #" + (data.TargetNumber + 1);
            targetCounter = data.TargetNumber + 1;
        }
    }



        private async void GoBackToPreviousTarget(object sender, EventArgs e)
        {
            targetCounter = targetCounter - 1;
            var data = db.GetLastTargetShot(RangeDate, targetCounter);
            JudgedYardages.SelectedItem = data.JudgedDistance;
            ActualYardages.SelectedItem = data.ActualDistance;
            ScorePicker.SelectedItem = data.TargetNumber;
            Notestb.Text = data.Notes;
            targetPicker.SelectedItem = data.Target;
            targetLabel.Text = "Target #" + data.TargetNumber;
            targetCounter = data.TargetNumber;
            db.DeleteTargetScore(data.RangeDate, data.TargetNumber);
        }
    }
