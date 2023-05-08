using SQLite;
using ObjectiveApp.Models;
using ObjectiveApp.DataAccess.Base;

namespace ObjectiveApp.DataAccess
{
    public class ObjectiveDataService : DataService<Objective>
    {
        public ObjectiveDataService(SQLiteAsyncConnection connection) : base(connection)
        {
        }
    }
}
