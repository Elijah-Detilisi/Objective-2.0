using SQLite;
using ObjectiveApp.Models.Base;

namespace ObjectiveApp.Models
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
