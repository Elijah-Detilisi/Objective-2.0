using SQLite;
using ObjectiveApp.Models.Base;

namespace ObjectiveApp.Models
{
    [Table(nameof(Objective))]
    public class Objective : BaseModel
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public bool IsDone { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(1);

    }
}
