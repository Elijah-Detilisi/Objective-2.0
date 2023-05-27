using ObjectiveApp.Models;
using ObjectiveApp.DataAccess;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ObjectiveApp.ViewModels
{
    public partial class ObjectiveViewModel : ObservableObject
    {

        #region Fields

        private readonly ObjectiveDataService _objectiveData;
        #endregion

        #region Properties

        [ObservableProperty]
        public TimeSpan selectedTime;
        [ObservableProperty]
        public Objective newObjective = new();

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
                NewObjective = null;
                GC.Collect();
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
            if (objectiveId>0)
            {
                var result = await _objectiveData.GetAsync(x=>x.Id==objectiveId);
                if (result.Any())
                {
                    NewObjective = result.First();
                }
            }
        }
        #endregion

        #region Helper methods
        private static bool IsNull(object obj)
        {
            return obj == null;
        }

        #endregion

    }
}
