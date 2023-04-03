using CommunityToolkit.Mvvm.Input;
using Objective.Maui_App.Services;
using System.Windows.Input;

namespace Objective.Maui_App.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel() 
        {
            SearchCommand = new AsyncRelayCommand(SearchAsync);
            ProfileCommand = new AsyncRelayCommand(ProfileAsync);
        }

        public string GreetingText => $"Good {TimeService.TimeOfDay()} Mr Detilisi";

        public ICommand SearchCommand { get; }
        public ICommand ProfileCommand { get; }

        private async Task SearchAsync()
        {
            await TextToSpeech.SpeakAsync("Searching now");
        }

        private async Task ProfileAsync()
        {
            await TextToSpeech.SpeakAsync("Edit profile");
        }
    }
}
