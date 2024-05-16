using MauiApp1.Pages;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var navigation = new NavigationPage(new ArcheryHomePage());
            MainPage = navigation; 
            //MainPage = new ArcheryHomePage();  
        }
    }
}
