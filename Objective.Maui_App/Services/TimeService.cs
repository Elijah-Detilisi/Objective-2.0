
namespace Objective.Maui_App.Services
{
    public static class TimeService
    {
        public static string Time()
        {
            return DateTime.Now.ToString("T");
        }

        public static string Today()
        {
            return DateTime.Now.ToString("D");
        } 
        
        public static string DayOfWeek()
        {
            return DateTime.Today.DayOfWeek.ToString();
        }

        public static string TimeOfDay()
        {
            TimeSpan time = DateTime.Now.TimeOfDay;
            if (time < TimeSpan.FromHours(12))
            {
                return "morning";
            }
            else if (time < TimeSpan.FromHours(18))
            {
                return "afternoon";
            }
            else
            {
                return "evening";
            }
        }
    }

}
