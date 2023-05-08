using SQLite;
using ObjectiveApp.Models;
using ObjectiveApp.Services;
using ObjectiveApp.DataAccess.Base;

namespace ObjectiveApp.DataAccess
{
    public class QuoteDataService : DataService<Quote>
    {
        public QuoteDataService(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public override async Task InitDatabaseAsync()
        {
            await base.InitDatabaseAsync();
            await InsertDefaultTableValues();
        }

        private async Task InsertDefaultTableValues()
        {
            var defaultValues = new List<Quote>();
            var allQuotes = await TextFileService.ReadFileLines
            (
                Configs.ConstantValues.QUOTES_TEXT_FILE
            );

            foreach (var quoteText in allQuotes)
            {

                var quote = new Quote()
                {
                    Phrase = quoteText.Split("-")[0],
                    Qoutee = quoteText.Split("-")[1],
                };

                defaultValues.Add(quote);
            }

            await _connection.InsertAllAsync(defaultValues);
        }

    }
}
