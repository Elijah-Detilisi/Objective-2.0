using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ObjectiveApp.DataAccess;
using ObjectiveApp.Models;
using ObjectiveApp.Services;
using ObjectiveApp.Views.Home._subViews;
using ObjectiveApp.Views.Objective;
using ObjectiveApp.Views.Profile;
using System.Collections.ObjectModel;
using System.Text;

namespace ObjectiveApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        #region Fields

        private bool _isInitialized = false;
        private readonly UserDataAccess _userData;
        private readonly QuoteDataAccess _quoteData;
        private readonly ObjectiveDataAccess _objectiveData;

        #endregion

        #region Properties

        [ObservableProperty]
        public string greeting;
        [ObservableProperty]
        public string dayOfWeek;
        [ObservableProperty]
        public User currentUser = new();
        [ObservableProperty]
        public Quote randomQuote = new();

        #endregion

        #region Collections
        public ObservableCollection<Objective> ObjectiveList{
            get; set;
        }
        #endregion

        #region Construction
        public HomeViewModel
        (
            
            UserDataAccess userData, 
            QuoteDataAccess quoteData, 
            ObjectiveDataAccess objectiveData
        )
        {
            _userData = userData;
            _quoteData = quoteData;
            _objectiveData = objectiveData;
        }
        #endregion

        #region Commands
        [RelayCommand]
        public async void OnSearch()
        {
            await Shell.Current.GoToAsync(nameof(SearchSubView));
        }
        [RelayCommand]
        public async void OnProfile()
        {
            await Shell.Current.GoToAsync($"{nameof(ProfileView)}?userId={CurrentUser.Id}");
        }
        [RelayCommand]
        public async void OnInsert()
        {
            await Shell.Current.GoToAsync(nameof(ObjectiveView));
        }
        #endregion

        #region Init methods
        private async Task AnnounceStartUpMessage()
        {
            //Arrange
            var objectiveListText = new StringBuilder("You currently don't have any objectives yet.");
            var salutationText = String.Format("{0} {1}, today is {2} and the time is {3}.",
                Greeting, CurrentUser.Username, DateTimeService.TodayDate(), DateTimeService.TimeNow()
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
                salutationText, objectiveListText.ToString(), RandomQuote.Qoutee, RandomQuote.Phrase
            );

            //Speak
            await TextToSpeechService.Speak(startUpMessage);
        }
        #endregion

        #region Load methods
        private void LoadGreeting()
        {
            DayOfWeek = DateTimeService.DayOfWeek();
            Greeting = $"Good {DateTimeService.TimeOfDayText()}";
        }
        private async Task LoadRandomQuoteAsync()
        {
            int randomId = new Random().Next(1, 102);
            var result = await _quoteData.GetAsync(qoute => qoute.Id == randomId);

            RandomQuote = result.FirstOrDefault();
        }
        public async Task LoadUserAsync()
        {
            var result = await _userData.GetAsync(user => user.Id == 1);
            if (result.Any())
            {
                CurrentUser = result.FirstOrDefault();
            }
        }
        public async Task LoadObjectiveListAsync()
        {
            var result = await _objectiveData.GetAsync(x => !x.IsDone);
            ObjectiveList = new ObservableCollection<Objective>(result.ToList());
        }
        public async Task LoadViewModel()
        {
            if (!_isInitialized)
            {
                LoadGreeting();
                await LoadRandomQuoteAsync();
                await AnnounceStartUpMessage();

                _isInitialized = true;
            }

            await LoadUserAsync();
            await LoadObjectiveListAsync();
        }
        #endregion

    }
}
