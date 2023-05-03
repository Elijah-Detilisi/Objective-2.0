namespace ObjectiveApp.Services
{
    public static class DateTimeService
    {
        public static string DayOfWeek()
        {
            return DateTime.Today.DayOfWeek.ToString();
        }

        public static string TimeNow()
        {
            return TimeOnly.FromDateTime(DateTime.Now).ToShortTimeString();
        }

        public static string TodayDate()
        {
            return DateOnly.FromDateTime(DateTime.Now).ToLongDateString();
        }
        
        public static string TimeOfDay()
        {
            TimeSpan time = DateTime.Now.TimeOfDay;

            return (
                time < TimeSpan.FromHours(12) ? "mornning" :
                time < TimeSpan.FromHours(18) ? "afternoon" :
                "evening"
            );
        }
    }
}
