using SQLite;
using ObjectiveApp.Models;
using ObjectiveApp.DataAccess.Base;

namespace ObjectiveApp.DataAccess
{
    public class UserDataService : DataService<User>
    {
        public UserDataService(SQLiteAsyncConnection connection) : base(connection)
        {
        }
    }
}
