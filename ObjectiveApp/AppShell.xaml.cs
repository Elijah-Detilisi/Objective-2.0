using ObjectiveApp.Views.Home;
using ObjectiveApp.Views.Home._subViews;
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
            RegisterSubViewRoutes();
        }

        private void RegisterViewRoutes()
        {
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));
            Routing.RegisterRoute(nameof(ObjectiveView), typeof(ObjectiveView));
        }

        public void RegisterSubViewRoutes()
        {
            Routing.RegisterRoute(nameof(SearchSubView), typeof(SearchSubView));
        }
    }
}