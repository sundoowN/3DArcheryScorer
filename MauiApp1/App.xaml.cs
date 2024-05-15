using MauiApp1.Pages;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ArcheryHomePage();  
            //MainPage = new AppShell();
        }
    }
}
