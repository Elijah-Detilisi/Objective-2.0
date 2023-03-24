using SQLite;
using Objective.Maui_App.Models.Base;

namespace Objective.Maui_App.Models
{
    [Table(nameof(QuoteModel))]
    public class QuoteModel : Model
    {
        public QuoteModel()
        {
            Qoutee = "Unkown";
        }

        public string Qoutee { get; set; }
        public string Phrase { get; set; }
    }
}
