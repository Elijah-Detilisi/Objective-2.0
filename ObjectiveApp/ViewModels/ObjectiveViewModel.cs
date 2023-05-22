using ObjectiveApp.Models;
using ObjectiveApp.DataAccess;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ObjectiveApp.ViewModels
{
    public partial class ObjectiveViewModel : ObservableObject
    {
        //Fields
        private readonly ObjectiveDataService _objectiveData;

        //Properties
        [ObservableProperty]
        public TimeSpan selectedTime;
        [ObservableProperty]
        public Objective newObjective = new();

        //Constrution
        public ObjectiveViewModel
        (
            ObjectiveDataService objectiveData
        )
        {
            _objectiveData = objectiveData;
        }

        //Commands
        [RelayCommand]
        public async void OnSave()
        {
            if (newObjective.Title is not null)
            {
                newObjective.DueDate.Add(selectedTime);
                await _objectiveData.AddAsync(newObjective);
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
    }
}
