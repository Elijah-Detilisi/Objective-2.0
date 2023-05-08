﻿using ObjectiveApp.Models;
using ObjectiveApp.Services;
using ObjectiveApp.DataAccess;
using ObjectiveApp.Views.Profile;
using ObjectiveApp.Views.Objective;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ObjectiveApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        //Fields
        private readonly UserDataService _userData;
        private readonly QuoteDataService _quoteData;
        private readonly ObjectiveDataService _objectiveData;

        //Properties
        [ObservableProperty]
        public string greeting;
        [ObservableProperty]
        public string dayOfWeek;
        [ObservableProperty]
        public User currentUser = new();
        [ObservableProperty]
        public Quote randomQuote = new();
        
        //Collections
        public ObservableCollection<Objective> ObjectiveList 
        { 
            get; set; 
        }

        //Construction
        public HomeViewModel
        (
            UserDataService userData, 
            QuoteDataService quoteData, 
            ObjectiveDataService objectiveData
        )
        {
            _userData = userData;
            _quoteData = quoteData;
            _objectiveData = objectiveData;
        }
        public async Task LoadViewModel()
        {
            LoadGreeting();
            /*await InitializeDataAsync();
            await LoadUserAsync();
            await LoadRandomQuoteAsync();
            await LoadObjectiveListAsync();*/
            //await AnnounceStartUpMessage();
        }

        //Init
        private async Task InitializeDataAsync()
        {
            await _userData.InitDatabaseAsync();
            await _quoteData.InitDatabaseAsync();
            await _objectiveData.InitDatabaseAsync();
        }

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
            DayOfWeek = DateTimeService.DayOfWeek();
            Greeting = $"Good {DateTimeService.TimeOfDay()}";
        }
        private async Task LoadUserAsync()
        {
            var result = await _userData.GetAsync(user => user.Id == 1);
            if (result.Any())
            {
                CurrentUser = result.FirstOrDefault();
            }
        }
        private async Task LoadObjectiveListAsync()
        {
            var result = await _objectiveData.GetAsync(x => !x.IsDone);
            if (result.Any())
            {
                var resultList = result.ToList();
                ObjectiveList = new ObservableCollection<Objective>(resultList);
            }
        }
        private async Task LoadRandomQuoteAsync()
        {
            int randomId = new Random().Next(1, 102);
            var result = await _quoteData.GetAsync(qoute => qoute.Id == randomId);

            RandomQuote = result.FirstOrDefault();
        }
    }
}
