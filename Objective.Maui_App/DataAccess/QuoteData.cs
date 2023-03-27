using Objective.Maui_App.Models;
using Objective.Maui_App.DataAccess.Base;

namespace Objective.Maui_App.DataAccess
{
    public class QuoteData : DataAccess<QuoteModel>
    {
        protected override void CreateRepoTable()
        {
            _connection.CreateTableAsync<QuoteModel>().Wait();
            PresetTableValues().Wait();
        }

        public override async Task<List<QuoteModel>> Get(int? id)
        {
            if (id == null)
            {
                return await _connection.Table<QuoteModel>().Where(quote => quote.Id == id).ToListAsync();
            }
            else
            {
                return await _connection.Table<QuoteModel>().ToListAsync();
            }
        }

        private async Task PresetTableValues()
        {
            try
            {
                var defaultValues = new List<QuoteModel>();
                string fileName = "102-inspirational-qoutes.txt";

                using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
                using StreamReader reader = new StreamReader(fileStream);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var quoteText = line.Split("-");

                    var quote = new QuoteModel()
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
