using Objective.Maui_App.Views.Mobile;

namespace Objective.Maui_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HomeView();
        }
    }
}