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
        }

        public string GreetingText => $"Good {TimeService.TimeOfDay()} Mr Detilisi";

        public ICommand SearchCommand { get; }

        private async Task SearchAsync()
        {
            await TextToSpeech.SpeakAsync("Searching now");
        }
    }
}
