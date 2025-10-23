namespace MauiApp1.Pages
{
    public partial class ScoreListPage : ContentPage
    {
        public ScoreListViewModel viewmodel;

        public ScoreListPage()
        {
            InitializeComponent();
            viewmodel = new ScoreListViewModel();
            BindingContext = viewmodel;
        }

        private void SelectedScore(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker.SelectedItem != null)
            {
                string selectedDate = picker.SelectedItem.ToString();
                viewmodel.GetScoreDataWithSelectedDate(selectedDate);
            }
        }
    }

}