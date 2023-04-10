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

        public async Task InitializeRepos()
        {
            await _quoteData.Initialize();
        }

        public async Task LoadRandomQuote()
        {
            int num = new Random().Next(1, 102);
            var test = await _quoteData.Get(x => x.Id == num);

            RandomQuote = test.FirstOrDefault();
            GreetingText = $"Good {TimeService.TimeOfDay()}";
        }

    }
}
