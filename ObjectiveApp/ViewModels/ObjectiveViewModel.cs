using ObjectiveApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ObjectiveApp.ViewModels
{
    public partial class ObjectiveViewModel : ObservableObject
    {
        //Properties
        [ObservableProperty]
        public Objective newObjective;
    }
}
