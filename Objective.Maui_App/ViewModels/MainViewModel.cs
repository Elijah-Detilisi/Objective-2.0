using Objective.Maui_App.Services;

namespace Objective.Maui_App.ViewModels
{
    public static class MainViewModel
    {
        public static string GreetingText => $"Good {TimeService.TimeOfDay()} Mr Detilisi";
    }
}
