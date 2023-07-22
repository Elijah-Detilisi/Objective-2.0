using ObjectiveApp.Configs;
using ObjectiveApp.DataAccess.Base;
using ObjectiveApp.Models;
using ObjectiveApp.Services;

namespace ObjectiveApp.DataAccess
{
    public class QuoteDataAccess : BaseDataAccess<Quote>
    {
        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await InsertDefaultTableValues();
        }

        private async Task InsertDefaultTableValues()
        {
            var defaultValues = new List<Quote>();
            var allQuotes = await TextFileService.ReadFileLines
            (
                Constants.QuotesTextFile
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
