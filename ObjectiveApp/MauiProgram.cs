using SQLite;
using ObjectiveApp.Configs;
using ObjectiveApp.DataAccess;
using ObjectiveApp.ViewModels;
using ObjectiveApp.Views.Home;
using ObjectiveApp.Views.Profile;
using ObjectiveApp.Views.Objective;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace ObjectiveApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Register Services
            var connectionString = ConstantValues.SQLite_CONNECTION_STRING;
            builder.Services.AddSingleton<SQLiteAsyncConnection>(new SQLiteAsyncConnection(connectionString));

            //Register Views
            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<ProfileView>();
            builder.Services.AddTransient<ObjectiveView>();

            //Register ViewModels
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<ObjectiveViewModel>();

            //Register DataService
            builder.Services.AddSingleton<UserDataService>();
            builder.Services.AddSingleton<QuoteDataService>();
            builder.Services.AddSingleton<ObjectiveDataService>();

            return builder.Build();
        }
    }
}