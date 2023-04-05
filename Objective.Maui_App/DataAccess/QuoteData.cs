using SQLite;
using Objective.Maui_App.Services;
using Objective.Maui_App.DataAccess.Base;
using Objective.Maui_App.Resources.Values;

namespace Objective.Maui_App.DataAccess
{
    public class QuoteData : DataAccess<Models.Quote>
    {
        #region Construction
        public QuoteData(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public override async Task Initialize()
        {
            await CreateTable();
            await PresetDefaultTableValues();
        }

        #endregion

        #region DataPreset Methods
        private async Task PresetDefaultTableValues()
        {
            var defaultValues = new List<Models.Quote>();
            var allQuotes = await TextFileService.ReadFileLines(Constants.QUOTES_TEXT_FILE);

            foreach (var quoteText in allQuotes)
            {

                var quote = new Models.Quote()
                {
                    Phrase = quoteText.Split("-")[0],
                    Qoutee = quoteText.Split("-")[1],
                };

                defaultValues.Add(quote);
            }

            await _connection.InsertAllAsync(defaultValues);
        }

        #endregion

    }
}
