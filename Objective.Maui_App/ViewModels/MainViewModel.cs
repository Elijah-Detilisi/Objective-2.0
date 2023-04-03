using Objective.Maui_App.Services;

namespace Objective.Maui_App.ViewModels
{
    public class MainViewModel
    {
        public string GreetingText => $"Good {TimeService.TimeOfDay()} Mr Detilisi";
    }
}
