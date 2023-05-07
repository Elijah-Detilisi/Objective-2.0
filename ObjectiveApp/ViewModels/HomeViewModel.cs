using ObjectiveApp.Services;
using ObjectiveApp.Views.Profile;
using ObjectiveApp.Views.Objective;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;


namespace ObjectiveApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        
        public HomeViewModel()
        {
            LoadGreeting();

            Objectives = new ObservableCollection<String>() {
                "Danger", "Hero", "Daisy", "Daisy", "Daisy", "Daisy"
            };
        }

        //Properties
        [ObservableProperty]
        public string greeting;
        [ObservableProperty]
        public string dayOfWeek;
        [ObservableProperty]
        public string currentUser;

        //Collection
        public ObservableCollection<String> Objectives { get; }

        //Commands
        [RelayCommand]
        public void OnProfile()
        {
            Shell.Current.GoToAsync(nameof(ProfileView));
        }
        [RelayCommand]
        public void OnInsert()
        {
            Shell.Current.GoToAsync(nameof(ObjectiveView));
        }

        //Methods
        private void LoadGreeting()
        {
            CurrentUser = "User";
            DayOfWeek = DateTimeService.DayOfWeek();
            Greeting = $"Good {DateTimeService.TimeOfDay()}";
        }
    }
}
