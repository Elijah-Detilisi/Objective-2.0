namespace Objective.Maui_App.Services
{
    public static class TextFileService
    {
        public static async Task<string> ReadFile(string textFile)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(textFile);
            using StreamReader reader = new StreamReader(fileStream);

            return await reader.ReadToEndAsync();
        }

        public static async Task<List<string>> ReadFileLines(string textFile)
        {
            string line = String.Empty;
            var result = new List<string>();

            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(textFile);
            using StreamReader reader = new StreamReader(fileStream);

            while ((line = reader.ReadLine()) != null)
            {
                result.Add(line);
            }

            return result;
        }
    }
}
