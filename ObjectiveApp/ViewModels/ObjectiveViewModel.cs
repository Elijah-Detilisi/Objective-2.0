using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ObjectiveApp.DataAccess;
using ObjectiveApp.Models;
using ObjectiveApp.Services;

namespace ObjectiveApp.ViewModels
{
    public partial class ObjectiveViewModel : ObservableObject
    {

        #region Fields

        private readonly ObjectiveDataService _objectiveData;
        #endregion

        #region Properties
        [ObservableProperty]
        public string viewTitle;
        [ObservableProperty]
        public string viewSubtitle;
        [ObservableProperty]
        public Color viewSubtitleColor;
        [ObservableProperty]
        public TimeSpan selectedTime;
        [ObservableProperty]
        public DateTime selectedDate;
        [ObservableProperty]
        public Objective newObjective;

        #endregion

        #region Constrution
        public ObjectiveViewModel
        (
            ObjectiveDataService objectiveData
        )
        {
            _objectiveData = objectiveData;
        }
        #endregion

        #region Commands

        [RelayCommand]
        public async void OnSave()
        {
            if (!IsNull(NewObjective.Title) && !IsNull(SelectedDate) && !IsNull(SelectedTime))
            {
                var finalDate = SelectedDate.Add(SelectedTime);
                NewObjective.DueDate = finalDate;

                await _objectiveData.AddOrUpdateAsync(NewObjective);
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await Shell.Current.DisplayAlert
                (
                    title: "🙊", 
                    message: "~ You can't save an empty entry.", 
                    cancel: "Got it"
                );
            }
        }
        #endregion

        #region Load methods
        public async Task LoadViewModel(int objectiveId=0)
        {
            ResetViewModel();

            if (objectiveId>0)
            {
                var result = await _objectiveData.GetAsync(x=>x.Id==objectiveId);
                if (result.Any())
                {
                    NewObjective = result.First();
                    LoadSubtitle(NewObjective.DueDate);
                    SelectedDate = NewObjective.DueDate;
                    SelectedTime = DateTimeService.ConvertToTimeSpan(NewObjective.DueDate);
                }
            }
        }
        #endregion

        #region Helper methods
        private void ResetViewModel()
        {
            SelectedTime = new();
            NewObjective = new();
            SelectedDate = NewObjective.DueDate;
            ViewSubtitle = "New";
            ViewTitle = "Create Objective";
            ViewSubtitleColor = Color.FromArgb("#666666");
        }

        private static bool IsNull(object obj)
        {
            return obj == null;
        }

        private void LoadSubtitle(DateTime dueDateTime)
        {
            ViewSubtitle = "Pending";
            ViewTitle = "View Objective";
            ViewSubtitleColor = Color.FromArgb("#4569AF");

            if (dueDateTime.Date == DateTime.Now.Date)
            {
                ViewSubtitle = "Today";
                ViewSubtitleColor = Color.FromArgb("#40C060");
            }
            else if (dueDateTime == DateTime.Now.Date.AddDays(1))
            {
                ViewSubtitle = "Tomorrow";
                ViewSubtitleColor = Color.FromArgb("#FFB732");
            }
            else if(dueDateTime.Date<DateTime.Now.Date)
            {
                ViewSubtitleColor = Color.FromArgb("#BF0603");
                ViewSubtitle = dueDateTime == DateTime.Now.Date.AddDays(-1)? "Yesterday" : "Overdue";
            }
        }

        #endregion

    }
}
