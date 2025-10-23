using MauiApp1.Models;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace MauiApp1.Pages
{
    public partial class RegularScoreCardPage : ContentPage
    {
        private readonly string _rangeDate;
        private readonly RegularScoreViewModel _viewModel;

        public RegularScoreCardPage(string? rangeDate = null)
        {
            InitializeComponent();

            _rangeDate = rangeDate ?? DateTime.Now.ToString("yyyy-MM-dd");
            _viewModel = new RegularScoreViewModel();

            BindingContext = _viewModel;
            _viewModel.LoadRegularScoresFromDatabase(_rangeDate);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedItem == null)
                return;

            int selectedScore = (int)picker.SelectedItem;

            if (picker.BindingContext is not ScoreModel selectedScoreModel)
                return;

            var targetModel = _viewModel.ScoresList
                .FirstOrDefault(m => m.TargetNumber == selectedScoreModel.TargetNumber);

            if (targetModel != null)
            {
                targetModel.Score = selectedScore;
                _viewModel.UpdateRunningTotals();
                _viewModel.SaveRegularScore(targetModel.TargetNumber, targetModel.Score, _rangeDate);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.SaveAllRegularScores(_rangeDate);
        }
    }
}