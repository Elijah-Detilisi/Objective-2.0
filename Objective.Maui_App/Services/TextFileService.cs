
namespace Objective.Maui_App.Services
{
    public static class TextFileService
    {
        public static async Task<string> ReadFile(string textFile)
        {
            try
            {
                using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(textFile);
                using StreamReader reader = new StreamReader(fileStream);

                var result = await reader.ReadToEndAsync();

                return result;
            }
            catch (Exception ex)
            { 
                Console.Write(ex.ToString());
            }

            return String.Empty;
        }

    }
}
