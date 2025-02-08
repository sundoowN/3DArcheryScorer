using Microsoft.Maui.Controls;

namespace MauiApp1.Pages
{
    public partial class ReviewEquipmentPage : ContentPage
    {
        public ReviewEquipmentPage()
        {
            InitializeComponent();
        }

        private async void OnReviewScoresClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoreListPage());
        }

        private async void OnReviewBowsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewBowsPage());
        }

        private async void OnReviewArrowsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewArrowsPage());
        }
    }
}
