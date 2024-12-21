namespace MauiApp1.Pages;

public partial class BowSetupsPage : ContentPage
{
	public BowDb db; 
	public BowViewModel bvm; 
	public BowSetupsPage()
	{
		InitializeComponent();
		db = new BowDb(); 
		bvm = new BowViewModel(); 
		BindingContext = bvm; 
	}

	private async void CreateBow(object sender, EventArgs e)
	{
		var name = NameEntry.Text;
		var company = CompanyEntry.Text; 
		var model = ModelEntry.Text; 
		var dlp = DLPEntry.Text; 
		var strings = StringsEntry.Text; 
		var sight = SightEntry.Text; 
		var sightnts = SightNotesEntry.Text; 
		var bars = BarsEntry.Text; 
		var barsnts = BarsNotesEntry.Text; 
		var release = ReleaseEntry.Text; 
		var rest = RestEntry.Text; 
		db.AddBowData(name, company, model, dlp, strings, sight, sightnts, bars, barsnts, release, rest);
	}

	private void SelectedBow (object sender, EventArgs e)
	{
		var picker = sender as Picker;
		string selectedItem = BowsList.SelectedItem.ToString();
		bvm.PopulateBowDataTable(selectedItem);
	}
	
	//So you will want three total tables: Scores (for review), Arrows, and Bows. This 
	//would take care of your three objects that you plan on keeping to review. 
	//Each of these would be a model
}