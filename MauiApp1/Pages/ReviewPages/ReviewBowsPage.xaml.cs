namespace MauiApp1.Pages;

public partial class ReviewBowsPage : ContentPage
{
	public BowDb db; 
	public BowViewModel bvm; 
	public ReviewBowsPage()
	{
		InitializeComponent();
		db = new BowDb(); 
		bvm = new BowViewModel(); 
		BindingContext = bvm; 
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