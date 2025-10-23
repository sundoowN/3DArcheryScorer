namespace MauiApp1.Pages;

public partial class ArcheryHomePage : ContentPage
{
	public ArcheryHomePage()
	{
		InitializeComponent();
	}

    private async void OpenScoringApplication(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new DetailedScoreKeeperPage()); 
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

    private async void ReviewEquipment(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReviewEquipmentPage());
    }

    private async void RegularScoreCard(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegularScoreCardPage(DateTime.Now.ToString("yyyy-MM-dd")));
    }
    
    private async void OpenLancaster(object sender, EventArgs e)
    {
        var uri = new Uri("https://www.lancasterarchery.com");
        await Launcher.Default.OpenAsync(uri);
    }
    
    //TODO: open asaarchery.com
    //TODO: Notepad/General notes
}