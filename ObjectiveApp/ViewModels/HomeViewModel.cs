using ObjectiveApp.Services;
using ObjectiveApp.Views.Profile;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ObjectiveApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        
        public HomeViewModel()
        {
            LoadGreeting();
        }

        //Properties
        [ObservableProperty]
        public string greeting;
        [ObservableProperty]
        public string dayOfWeek;
        [ObservableProperty]
        public string currentUser = "User";

        //Commands
        [RelayCommand]
        public async Task NavigateToNewPage()
        {
            await Shell.Current.GoToAsync(nameof(ProfileView));
        }

        //Methods
        private void LoadGreeting()
        {
            Greeting = $"Good {DateTimeService.TimeOfDay()}";
            DayOfWeek = $"Good {DateTimeService.TimeOfDay()}";
        }
    }
}
