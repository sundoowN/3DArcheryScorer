using MauiApp1;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.Pages
{
    public partial class ScoreListPage : ContentPage
    {
        public ViewModel model;
        public ScoreListViewModel viewmodel;
        public ScoreListPage()
        {
            InitializeComponent();
            viewmodel = new ScoreListViewModel();
        }


        private void PopulateScoreHistoryData(object sender, EventArgs e)
        {
            var date = ScoreHistoryList.SelectedItem.ToString(); 
            viewmodel.GetScoreDataWithSelectedDate(date);
        }

        private void RemoveScoreFromList(object sender, EventArgs e)
        {
            var score = ScoreHistoryList.SelectedItem.ToString();
            viewmodel.RemoveDateFromList(score); 
        }

    }
}
