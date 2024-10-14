namespace MauiApp1.Pages;

public partial class ArcheryHomePage : ContentPage
{
	public ArcheryHomePage()
	{
		InitializeComponent();
	}

    private async void OpenScoringApplication(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ScoreKeepingPage()); 

    }

    private async void ReviewScores(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ScoreListPage());  
    }

    private async void BowSetups(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BowSetupsPage()); 
    }

    private async void ArrowSetups(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ArrowSetupsPage());
    }
}