using static System.Environment;

namespace ObjectiveApp.Configs
{
    public static class ConstantValues
    {
        public static string QUOTES_TEXT_FILE
        {
            get { return "102-inspirational-qoutes.txt"; }
        }

        public static string SQLite_CONNECTION_STRING
        {
            get {
                return Path.Combine(GetFolderPath(SpecialFolder.Personal), "objective_data.db3");
            }
        }
    }
}
