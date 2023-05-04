using ObjectiveApp.Views.Home;
using ObjectiveApp.Views.Objective;
using ObjectiveApp.Views.Profile;

namespace ObjectiveApp
{
    public static class MauiProgram
    {
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

            //Register Main Views
            builder.Services.AddTransient<HomeView>();
            builder.Services.AddTransient<ProfileView>();
            builder.Services.AddTransient<ObjectiveView>();

            return builder.Build();
        }
    }
}