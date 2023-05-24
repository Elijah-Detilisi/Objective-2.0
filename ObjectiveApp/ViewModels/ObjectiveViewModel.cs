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
            if (NewObjective.Title is not null)
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
    }
}
