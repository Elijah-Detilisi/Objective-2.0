using SQLite;
using Objective.Maui_App.Models.Base;

namespace Objective.Maui_App.Models
{
    [Table(nameof(ObjectiveModel))]
    public class ObjectiveModel : Model
    {
        public ObjectiveModel()
        {
            CreatedAt = DateTime.Now;
            DueDate = DateTime.Now.AddDays(1);
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
        public bool IsDone { get; set; }
    }
}
