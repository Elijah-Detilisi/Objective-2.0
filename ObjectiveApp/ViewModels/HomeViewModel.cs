using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ObjectiveApp.Views.Home;


namespace ObjectiveApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {

        [RelayCommand]
        public void NavigateToNewPage()
        {
            Shell.Current.GoToAsync(nameof(HomeView));
        }
    }
}
