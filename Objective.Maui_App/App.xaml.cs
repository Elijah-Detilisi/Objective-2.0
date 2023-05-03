using Objective.Maui_App.ViewModels;

namespace Objective.Maui_App
{
    public partial class App : Application
    {
        public App(MainViewModel viewModel)
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Light;
            //MainPage = new Views.Mobile.Main.SearchView(viewModel);
            MainPage = new Views.Mobile.Main.MainView(viewModel);
        }
    }
}