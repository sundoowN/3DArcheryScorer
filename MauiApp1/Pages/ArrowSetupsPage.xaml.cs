namespace MauiApp1.Pages;

public partial class ArrowSetupsPage : ContentPage
{
	public ArrowDb db; 
	public ArrowViewModel avm; 
	public ArrowSetupsPage()
	{
		InitializeComponent();
		db = new ArrowDb(); 
		avm = new ArrowViewModel(); 
		BindingContext = avm; 
	}

	private async void SubmitArrow(object sender, EventArgs e)
	{
		var name = NameEntry.Text;
		var company = CompanyEntry.Text; 
		var model = ModelEntry.Text; 
		var len = Convert.ToInt32(ArrowLengthEntry.Text); 
		var point = Convert.ToInt32(PointWeightEntry.Text); 
		var fletch = FletchingEntry.Text; 
		var nock = NockEntry.Text; 
		var other = OtherEntry.Text; 
		db.AddArrowData(name, company, model, len, point, fletch, nock, other); 
		avm.PopulateArrowsDropdownList(); 
	}

	private void SelectedArrow (object sender, EventArgs e)
	{
		var picker = sender as Picker;
		string selectedItem = ArrowsList.SelectedItem.ToString();
		avm.PopulateArrowDataTable(selectedItem);
	}

	//probably want to add in a remove arrow button
}