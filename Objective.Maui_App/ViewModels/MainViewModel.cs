using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Objective.Maui_App.DataAccess;
using Objective.Maui_App.Models;
using Objective.Maui_App.Services;


namespace Objective.Maui_App.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        private QuoteData _quoteData;

        [ObservableProperty]
        public Quote randomQuote;
        [ObservableProperty]
        public string greetingText;

        public MainViewModel(QuoteData quoteData) 
        {
            _quoteData = quoteData;
        }

        public async Task LoadViewModel()
        {
            LoadGreeting();
            await InitializeDataAsync();
            await LoadRandomQuoteAsync();
        }

        private void LoadGreeting()
        {
            GreetingText = $"Good {TimeService.TimeOfDay()}";
        }
        private async Task InitializeDataAsync()
        {
            await _quoteData.Initialize();
        }
        private async Task LoadRandomQuoteAsync()
        {
            int num = new Random().Next(1, 102);
            var test = await _quoteData.Get(x => x.Id == num);

            RandomQuote = test.FirstOrDefault();
        }

    }
}
