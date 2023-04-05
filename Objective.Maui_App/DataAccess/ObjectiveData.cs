using Objective.Maui_App.Models;
using Objective.Maui_App.DataAccess.Base;

namespace Objective.Maui_App.DataAccess
{
    public class ObjectiveData : DataAccess<Models.Objective>
    {
        protected override void CreateRepoTable()
        {
            _connection.CreateTableAsync<Objective>().Wait();
        }

        public override async Task<List<Models.Objective>> Get(int? id)
        {
            if (id == null)
            {
                return await _connection.Table<Objective>().Where(objective => objective.Id == id).ToListAsync();
            }
            else
            {
                return await _connection.Table<Objective>().ToListAsync();
            }
        }
    }
}
