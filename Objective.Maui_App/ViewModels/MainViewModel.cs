using Objective.Maui_App.Models;
using Objective.Maui_App.Services;
using Objective.Maui_App.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using Kotlin.Properties;
using System.Collections.ObjectModel;

namespace Objective.Maui_App.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        //Fields
        private readonly UserData _userData;
        private readonly QuoteData _quoteData;

        //Properties
        [ObservableProperty]
        public User currentUser = new();
        [ObservableProperty]
        public Quote randomQuote = new();
        [ObservableProperty]
        public string greetingText = string.Empty;

        public ObservableCollection<Models.Objective> objectives;

        //Construction
        public MainViewModel
        (
            UserData userData,
            QuoteData quoteData
        ) 
        {
            _userData = userData;
            _quoteData = quoteData;

            objectives = new ObservableCollection<Models.Objective>()
            {
                new Models.Objective {},
                new Models.Objective {},
                new Models.Objective {},
                new Models.Objective {},
                new Models.Objective {},
                new Models.Objective {},
                new Models.Objective {},
            };
        }

        //Data loading
        public async Task LoadViewModel()
        {
            LoadGreeting();
            await InitializeDataAsync();
            await LoadUserAsync();
            await LoadRandomQuoteAsync();
        }
        private void LoadGreeting()
        {
            GreetingText = $"Good {TimeService.TimeOfDay()}";
        }
        private async Task InitializeDataAsync()
        {
            await _userData.Initialize();
            await _quoteData.Initialize();
        }
        private async Task LoadRandomQuoteAsync()
        {
            int randomId = new Random().Next(1, 102);
            var result = await _quoteData.Get(qoute => qoute.Id == randomId);

            RandomQuote = result.FirstOrDefault();
        }
        private async Task LoadUserAsync()
        {
            var result = await _userData.Get(user => user.Id == 1);
            if (result.Any())
            {
                CurrentUser = result.FirstOrDefault();
            }
        }

    }
}
