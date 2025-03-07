using System;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using MauiApp1.Models;
using MauiApp1.Pages;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace MauiApp1.Pages;
    public partial class RegularScoreCardPage : ContentPage
    {
        public List<int> ScoreTallyTotal = new List<int>(); 
        public RegularScoreViewModel model; 
        public RegularScoreCardPage()
        {
            InitializeComponent();
            model = new RegularScoreViewModel(); 
            BindingContext = model; 
        }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        // Ensure a valid selection was made
        if (picker.SelectedItem == null)
            return;

        int selectedScore = (int)picker.SelectedItem;

        // Get the ScoreModel bound to this Picker
        var selectedScoreModel = picker.BindingContext as ScoreModel;

        if (selectedScoreModel == null)
            return;  // Safety check to ensure we have a valid ScoreModel

        var viewModel = (RegularScoreViewModel)BindingContext;

        // Find the matching ScoreModel in ScoresList using the TargetNumber
        var targetModel = viewModel.ScoresList.FirstOrDefault(model => model.TargetNumber == selectedScoreModel.TargetNumber);

        if (targetModel != null)
        {
            // Update the Score for that target model
            targetModel.Score = selectedScore;

            // Calculate the consecutive (cumulative) score up to the current target
            int cumulativeScore = 0;
            for (int i = 0; i <= viewModel.ScoresList.IndexOf(targetModel); i++)
            {
                cumulativeScore += viewModel.ScoresList[i].Score;  // Add the score up to the selected target
            }

            // Optionally, store this cumulative score in the ScoreModel or handle it as needed
            selectedScoreModel.ConsecutiveScore = cumulativeScore;

            // Update running total in ViewModel
            viewModel.UpdateRunningTotal();

            // Optionally, display the cumulative score for debugging or in the UI
            Console.WriteLine($"Cumulative Score: {cumulativeScore}");
        }
    }
}

