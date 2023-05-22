﻿using ObjectiveApp.Models;
using ObjectiveApp.Services;
using ObjectiveApp.DataAccess;
using ObjectiveApp.Views.Profile;
using ObjectiveApp.Views.Objective;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text;

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
        public ObservableCollection<Objective> ObjectiveList{
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
            await InitializeDataAsync();
            await LoadUserAsync();
            await LoadRandomQuoteAsync();
            await LoadObjectiveListAsync();
            //await AnnounceStartUpMessage();
        }

        //Init
        private async Task InitializeDataAsync()
        {
            await _userData.InitDatabaseAsync();
            await _quoteData.InitDatabaseAsync();
            await _objectiveData.InitDatabaseAsync();
        }
        private async Task AnnounceStartUpMessage()
        {
            //Arrange
            var objectiveListText = new StringBuilder("You currently don't have any objectives yet.");
            var salutationText = String.Format("{0} {1}, today is {2} and the time is {3}.",
                greeting, currentUser.Username, DateTimeService.TodayDate(), DateTimeService.TimeNow()
            );
            
            if (ObjectiveList != null)
            {
                objectiveListText.Clear();
                objectiveListText.Append("Your objectives are as follows:");

                foreach (var item in ObjectiveList)
                {
                    objectiveListText.Append($" {item.Title}.");
                }
            }

            string startUpMessage = String.Format("{0}. {1}. Remember; {2} once said {3}. That's it from me, good by for now.",
                salutationText, objectiveListText.ToString(), randomQuote.Qoutee, randomQuote.Phrase
            );

            //Speak
            await TextToSpeechService.Speak(startUpMessage);
        }

        //Commands
        [RelayCommand]
        public async void OnProfile()
        {
            await Shell.Current.GoToAsync(nameof(ProfileView));
        }
        [RelayCommand]
        public async void OnInsert()
        {
            await Shell.Current.GoToAsync(nameof(ObjectiveView));
        }

        //Methods
        private void LoadGreeting()
        {
            dayOfWeek = DateTimeService.DayOfWeek();
            greeting = $"Good {DateTimeService.TimeOfDay()}";
        }
        private async Task LoadUserAsync()
        {
            var result = await _userData.GetAsync(user => user.Id == 1);
            if (result.Any())
            {
                currentUser = result.FirstOrDefault();
            }
        }
        private async Task LoadObjectiveListAsync()
        {
            var result = await _objectiveData.GetAsync(x => x.Id>=0);
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

            randomQuote = result.FirstOrDefault();
        }
    }
}
