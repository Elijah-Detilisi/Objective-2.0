using Objective.Maui_App.Models;
using Objective.Maui_App.DataAccess.Base;

namespace Objective.Maui_App.DataAccess
{
    public class QuoteData : DataAccess<Quote>
    {
        protected override void CreateRepoTable()
        {
            _connection.CreateTableAsync<Quote>().Wait();
            PresetTableValues().Wait();
        }

        public override async Task<List<Quote>> Get(int? id)
        {
            if (id == null)
            {
                return await _connection.Table<Quote>().Where(quote => quote.Id == id).ToListAsync();
            }
            else
            {
                return await _connection.Table<Quote>().ToListAsync();
            }
        }

        private async Task PresetTableValues()
        {
            try
            {
                var defaultValues = new List<Quote>();
                string fileName = "102-inspirational-qoutes.txt";

                using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
                using StreamReader reader = new StreamReader(fileStream);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var quoteText = line.Split("-");

                    var quote = new Quote()
                    {
                        Phrase = quoteText[0],
                        Qoutee = quoteText[1],
                    };

                    defaultValues.Add(quote);
                }

                await _connection.InsertAllAsync(defaultValues);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
