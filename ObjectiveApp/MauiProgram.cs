using SQLite;
using ObjectiveApp.Configs;
using ObjectiveApp.DataAccess;
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

            //Register Services
            var connectionString = ConstantValues.SQLite_CONNECTION_STRING;
            SQLiteAsyncConnection _sqliteConnection = new SQLiteAsyncConnection(connectionString);

            //Register Views
            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<ProfileView>();
            builder.Services.AddTransient<ObjectiveView>();

            //Register ViewModels
            builder.Services.AddSingleton<HomeViewModel>();


            //Register DataService
            builder.Services.AddSingleton(singleton => ActivatorUtilities.CreateInstance<UserDataService>(singleton, _sqliteConnection));
            builder.Services.AddSingleton(singleton => ActivatorUtilities.CreateInstance<QuoteDataService>(singleton, _sqliteConnection));
            builder.Services.AddSingleton(singleton => ActivatorUtilities.CreateInstance<ObjectiveDataService>(singleton, _sqliteConnection));
            

            return builder.Build();
        }
    }
}