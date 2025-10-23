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
}