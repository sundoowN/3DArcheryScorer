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

            if (picker.BindingContext is not ScoreModel selectedScoreModel)
                return;

            var viewModel = (RegularScoreViewModel)BindingContext;

            // Find the corresponding ScoreModel
            var targetModel = viewModel.ScoresList.FirstOrDefault(m => m.TargetNumber == selectedScoreModel.TargetNumber);
            
            if (targetModel != null)
            {
                targetModel.Score = selectedScore;
                viewModel.UpdateRunningTotals();  // ✅ Trigger running total update
            }
        }
    }
}
