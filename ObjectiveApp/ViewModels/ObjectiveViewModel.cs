using ObjectiveApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ObjectiveApp.ViewModels
{
    public partial class ObjectiveViewModel : ObservableObject
    {
        //Properties
        [ObservableProperty]
        public DateTime selectedDate;
        [ObservableProperty]
        public TimeSpan selectedTime;
        [ObservableProperty]
        public Objective newObjective = new()
        {
            DueDate = new DateTime(2008, 9, 23, 10, 30, 50),
        };

        //Constrution
        public ObjectiveViewModel()
        {
            selectedDate = NewObjective.DueDate;
            selectedTime = TimeOnly.FromDateTime(selectedDate).ToTimeSpan();
        }

        //Commands
        [RelayCommand]
        public void OnSave()
        {
            var result1 = SelectedDate.Month;
            var result2 = SelectedTime.ToString();
            var result3 = NewObjective.Title;
        }
    }
}
