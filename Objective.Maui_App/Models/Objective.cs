using SQLite;
using Objective.Maui_App.Models.Base;

namespace Objective.Maui_App.Models
{
    [Table(nameof(Objective))]
    public class Objective : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(1);
        
    }
}
