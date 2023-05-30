using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ObjectiveApp.DataAccess;
using ObjectiveApp.Models;

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
            if (!IsNull(NewObjective.Title) && !IsNull(NewObjective.DueDate) && !IsNull(SelectedTime))
            {
                NewObjective.DueDate.Add(SelectedTime);
                await _objectiveData.AddAsync(NewObjective);
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
            NewObjective = new();
            ViewSubtitle = "New";
            ViewTitle = "Create Objective";
            ViewSubtitleColor = Color.FromArgb("#666666");

            if (objectiveId>0)
            {
                ViewTitle = "View Objective";
                var result = await _objectiveData.GetAsync(x=>x.Id==objectiveId);
                if (result.Any())
                {
                    NewObjective = result.First();
                    LoadSubtitle(NewObjective.DueDate);
                }
            }
        }
        #endregion

        #region Helper methods
        private static bool IsNull(object obj)
        {
            return obj == null;
        }

        private void LoadSubtitle(DateTime dateTime)
        {
            if (dateTime<DateTime.Now)
            {
                ViewSubtitle = "Overdue";
                ViewSubtitleColor = Color.FromArgb("#BF0603");
            }
            else if (dateTime.AddDays(1) == DateTime.Now)
            {
                ViewSubtitle = "Tomorrow";
                ViewSubtitleColor = Color.FromArgb("#FFB732");
            }
            else if (dateTime.Day == DateTime.Now.Day)
            {
                ViewSubtitle = "Today";
                ViewSubtitleColor = Color.FromArgb("#40C060");
            }

        }

        #endregion

    }
}
