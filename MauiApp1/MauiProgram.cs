using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public class MauiProgram
    {
        public List<string> targetNames = new List<string>();
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build(); 
        }

        public List<string> PopulateTargetsList()
        {
            //TODO: populate targets by traversing the filenames
            //Loop through the folder and get the file names to populate the list. 
            var folder = @"D:\Projects\MauiApp1\MauiApp1\TargetImages\";
            string[] targets = Directory.GetFiles(folder);

            foreach (string name in targets)
            {
                targetNames.Add(name); 
            }
            return targetNames; 
        }
    }
}
