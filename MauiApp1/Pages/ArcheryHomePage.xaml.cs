namespace MauiApp1.Pages;

public partial class ArcheryHomePage : ContentPage
{
	public ArcheryHomePage()
	{
		InitializeComponent();
	}

    private void OpenScoringApplication(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new MainPage()); 

    }

    private void ReviewScores(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ScoreHistoryPage());  
    }

    private void BowSetups(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new BowSetupsPage()); 
    }

    private void ArrowSetups(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ArrowSetupsPage());

        var navigation = new NavigationPage(new ArrowSetupsPage()); 
    }
}