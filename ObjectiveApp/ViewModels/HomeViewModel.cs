using ObjectiveApp.Views.Profile;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ObjectiveApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {

        [RelayCommand]
        public void NavigateToNewPage()
        {
            Shell.Current.GoToAsync(nameof(ProfileView));
        }
    }
}
