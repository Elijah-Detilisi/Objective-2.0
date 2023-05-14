using ObjectiveApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace ObjectiveApp.ViewModels
{
    public partial class ObjectiveViewModel : ObservableObject
    {
        //Properties
        [ObservableProperty]
        public Objective newObjective = new()
        {
            DueDate = new DateTime(2008, 9, 23, 10, 30, 50),
        };
    }
}
