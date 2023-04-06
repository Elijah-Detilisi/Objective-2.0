namespace Objective.Maui_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.Mobile.Main.MainView();
        }
    }
}