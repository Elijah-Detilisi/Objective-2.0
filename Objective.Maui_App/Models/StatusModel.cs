using SQLite;
using Objective.Maui_App.Models.Base;

namespace Objective.Maui_App.Models
{
    [Table(nameof(StatusModel))]
    public class StatusModel : Model
    {
        [Unique]
        public string Title { get; set; }
    }
}
