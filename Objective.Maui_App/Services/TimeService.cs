
namespace Objective.Maui_App.Services
{
    public static class TimeService
    {
        public static string Time()
        {
            return DateTime.Now.ToString("t");
        }
        public static string Today()
        {
            return DateTime.Now.ToString("dd MMMM, yyyy");
        }

        public static string TimeOfDay()
        {
            string timeOfDay = "morning";
            int currentHour = DateTime.Now.Hour;

            if(currentHour>12 && currentHour<18)
            {
                timeOfDay = "afternoon";
            }
            else if (currentHour>=18 && currentHour<=23)
            {
                timeOfDay = "evening";
            }

            return timeOfDay;
        }
    }
}
