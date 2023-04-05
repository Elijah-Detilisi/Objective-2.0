using SQLite;

namespace Objective.Maui_App.Models.Base
{
    public abstract class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
