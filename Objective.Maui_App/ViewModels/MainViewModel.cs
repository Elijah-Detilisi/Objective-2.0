
using Objective.Maui_App.Models;
using Objective.Maui_App.Services;
using Objective.Maui_App.DataAccess;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

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
        public string todayText = string.Empty;
        [ObservableProperty]
        public string greetingText = string.Empty;
        
        public ObservableCollection<Models.Objective> _objectives;

        //Construction
        public MainViewModel
        (
            UserData userData,
            QuoteData quoteData
        ) 
        {
            _userData = userData;
            _quoteData = quoteData;

            Objectives = new ObservableCollection<Models.Objective>()
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

        public ObservableCollection<Models.Objective> Objectives
        {
            get { return _objectives; }
            set
            {
                _objectives = value;
                OnPropertyChanged();
            }
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
            TodayText = TimeService.DayOfWeek();
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
