using Objective.Maui_App.Models;
using Objective.Maui_App.DataAccess.Base;

namespace Objective.Maui_App.DataAccess
{
    public class ObjectiveData : DataAccess<ObjectiveModel>
    {
        protected override void CreateRepoTable()
        {
            _connection.CreateTableAsync<ObjectiveModel>().Wait();
        }

        public override async Task<List<ObjectiveModel>> Get(int? id)
        {
            if (id == null)
            {
                return await _connection.Table<ObjectiveModel>().Where(objective => objective.Id == id).ToListAsync();
            }
            else
            {
                return await _connection.Table<ObjectiveModel>().ToListAsync();
            }
        }
    }
}
