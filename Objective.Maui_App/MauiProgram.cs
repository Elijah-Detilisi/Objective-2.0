using SQLite;
using Objective.Maui_App.DataAccess;

namespace Objective.Maui_App
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

            //Services
            var connectionString = Resources.Values.Constants.CONNECTION_STRING;
            SQLiteAsyncConnection _sqliteConnection = new SQLiteAsyncConnection(connectionString);

            //DataAccess Registration
            builder.Services.AddSingleton(singleton => ActivatorUtilities.CreateInstance<UserData>(singleton, _sqliteConnection));
            builder.Services.AddSingleton(singleton => ActivatorUtilities.CreateInstance<QuoteData>(singleton, _sqliteConnection));
            builder.Services.AddSingleton(singleton => ActivatorUtilities.CreateInstance<ObjectiveData>(singleton, _sqliteConnection));

            //ViewModels Registration
            builder.Services.AddSingleton<ViewModels.MainViewModel>();

            //Views Registration
            builder.Services.AddSingleton<Views.Mobile.Main.MainView>();

            return builder.Build();
        }
    }
}