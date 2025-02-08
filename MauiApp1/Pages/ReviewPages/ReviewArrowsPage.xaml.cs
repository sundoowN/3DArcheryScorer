namespace MauiApp1.Pages;

public partial class ReviewArrowsPage : ContentPage
{
	public ArrowDb db; 
	public ArrowViewModel avm; 
	public ReviewArrowsPage()
	{
		InitializeComponent();
		db = new ArrowDb(); 
		avm = new ArrowViewModel(); 
		BindingContext = avm; 
	}

	private void SelectedArrow (object sender, EventArgs e)
	{
		var picker = sender as Picker;
		string selectedItem = ArrowsList.SelectedItem.ToString();
		avm.PopulateArrowDataTable(selectedItem);
	}

	//probably want to add in a remove arrow button
}