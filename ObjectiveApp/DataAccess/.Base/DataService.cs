using SQLite;
using ObjectiveApp.Models.Base;

namespace ObjectiveApp.DataAccess.Base
{
    public abstract class DataService<TModel> where TModel : BaseModel, new()
    {
        //Fields
        protected readonly SQLiteAsyncConnection _connection;

        //Construction
        public DataService(SQLiteAsyncConnection connection)
        {
            _connection = connection ?? 
                throw new ArgumentNullException(nameof(connection));
        }

        //Helper
        private void NullCheck(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }

        //Init
        protected virtual async Task InitDatabaseAsync()
        {
            await _connection.CreateTableAsync<TModel>();
        }

        //CRUD operations
        public async Task<int> AddAsync(TModel model)
        {
            NullCheck(model);

            return await _connection.InsertAsync(model);
        }
        public async Task<List<TModel>> GetAsync(Func<TModel, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var items = await _connection.Table<TModel>().ToListAsync();

            return items.Where(predicate).ToList();
        }

        public async Task<int> UpdateAsync(TModel model)
        {
            NullCheck(model);

            return await _connection.UpdateAsync(model);
        }
        public async Task<int> Delete(TModel model)
        {
            NullCheck(model);

            return await _connection.DeleteAsync(model);
        }

    }
}
