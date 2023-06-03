using ObjectiveApp.Handlers;
using Microsoft.Maui.Platform;

namespace ObjectiveApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new AppShell();
        }
    }
}