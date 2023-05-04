using ObjectiveApp.ViewModels;
using ObjectiveApp.Views.Home;
using ObjectiveApp.Views.Profile;
using ObjectiveApp.Views.Objective;


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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<ProfileView>();
            builder.Services.AddTransient<ObjectiveView>();

            //Register Main ViewModels
            builder.Services.AddSingleton<HomeViewModel>();


            return builder.Build();
        }
    }
}