using SQLite;
using Objective.Maui_App.Models.Base;

namespace Objective.Maui_App.Models
{
    [Table(nameof(Quote))]
    public class Quote : BaseModel
    {
        [MaxLength(150)]
        public string Phrase { get; set; }

        [MaxLength(50)]
        public string Qoutee { get; set; } = "Unknown";   
    }
}
