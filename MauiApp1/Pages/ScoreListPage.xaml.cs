using MauiApp1;

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

        public void GetScoresFromDatabase()
        {
            //populate this method
        }
    }
}
