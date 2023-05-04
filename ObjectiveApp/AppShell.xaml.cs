using ObjectiveApp.Views.Home;
using ObjectiveApp.Views.Objective;
using ObjectiveApp.Views.Profile;

namespace ObjectiveApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterViewRoutes();
        }

        public void RegisterViewRoutes()
        {
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));
            Routing.RegisterRoute(nameof(ObjectiveView), typeof(ObjectiveView));
        }
    }
}