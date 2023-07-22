namespace ObjectiveApp.Configs
{
    public static class Constants
    {
        private const string DatabaseFilename = "objectiveSQLite.db3";

        public const string QuotesTextFile = "102-inspirational-qoutes.txt";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
