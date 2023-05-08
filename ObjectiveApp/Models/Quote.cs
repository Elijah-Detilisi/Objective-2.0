using SQLite;
using ObjectiveApp.Models.Base;

namespace ObjectiveApp.Models
{
    [Table(nameof(Quote))]
    public class Quote : BaseModel
    {

        public Quote() {
            Phrase = @"And whatever you do, do it heartily, as to the Lord and not to men, " +
            "knowing that from the Lord you will receive the reward of the inheritance; for you serve the Lord Christ.";
            Qoutee = "Paul the Apostle";
        }

        [MaxLength(150)]
        public string Phrase { get; set; }

        [MaxLength(50)]
        public string Qoutee { get; set; } = "Unknown";
    }
}
