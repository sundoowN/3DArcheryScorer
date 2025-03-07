using System;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using MauiApp1.Models;
using MauiApp1.Pages;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace MauiApp1.Pages
{
    public partial class RegularScoreCardPage : ContentPage
    {

        public RegularScoreCardPage()
        {
            InitializeComponent();
            var model = new RegularScoreViewModel(); 
            BindingContext = model; 
        }

private void Picker_SelectedIndexChanged(object sender, EventArgs e)
{
    var picker = (Picker)sender;

    if (picker.SelectedItem == null)
        return;

    int selectedScore = (int)picker.SelectedItem;

    // Get the bound ScoreModel from the Picker
    var selectedScoreModel = picker.BindingContext as ScoreModel;

    if (selectedScoreModel == null)
        return;

    var viewModel = (RegularScoreViewModel)BindingContext;

    // Find and update the corresponding ScoreModel
    var targetModel = viewModel.ScoresList.FirstOrDefault(model => model.TargetNumber == selectedScoreModel.TargetNumber);

    if (targetModel != null)
    {
        targetModel.Score = selectedScore; // Update selected score
        viewModel.UpdateRunningTotals(); // Update cumulative score
    }
}
    }
}
