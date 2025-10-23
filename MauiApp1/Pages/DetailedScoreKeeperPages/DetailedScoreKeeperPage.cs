using Microsoft.Maui.Controls;

namespace MauiApp1.Pages
{
    public partial class DetailedScoreKeeperPage : ContentPage
    {
        public DetailedScoreKeeperPage()
        {
            InitializeComponent();
        }

        private async void OpenKnownScoreCard(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KnownScoreKeeperPage());
        }

        private async void OpenUnknownScorecard(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnknownScoreKeepingPage());
        }
    }
}
