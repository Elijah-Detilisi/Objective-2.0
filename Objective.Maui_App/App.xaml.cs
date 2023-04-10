using Objective.Maui_App.ViewModels;

namespace Objective.Maui_App
{
    public partial class App : Application
    {
        public App(MainViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new Views.Mobile.Main.MainView(viewModel);
        }
    }
}