using SQLite;

namespace ObjectiveApp.Models.Base
{
    public abstract class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
