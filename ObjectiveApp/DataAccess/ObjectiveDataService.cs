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

        public async Task AddOrUpdateAsync(Objective objective)
        {
            if (objective.Id == 0)
            {
                await AddAsync(objective);
            }
            else
            {
                await UpdateAsync(objective);
            }
        }
    }
}
