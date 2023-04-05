using SQLite;

namespace Objective.Maui_App.DataAccess.Base
{
    public abstract class DataAccess<Model> where Model : class, new()
    {
        protected readonly SQLiteAsyncConnection _connection;

        #region Construction
        public DataAccess(SQLiteAsyncConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        protected async Task CreateTable()
        {
            await _connection.CreateTableAsync<Model>();
        }

        #endregion

        #region CRUD methods
        public async Task<int> Add(Model model)
        {
            ModelNullCheck(model);

            return await _connection.InsertAsync(model);
        }

        public async Task<int> Update(Model model)
        {
            ModelNullCheck(model);

            return await _connection.UpdateAsync(model);
        }

        public async Task<int> Delete(Model model)
        {
            ModelNullCheck(model);

            return await _connection.DeleteAsync(model);
        }

        public async Task<List<Model>> Get(Func<Model, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var items = await _connection.Table<Model>().ToListAsync();

            return items.Where(predicate).ToList();
        }

        #endregion

        #region Helper methods
        private void ModelNullCheck(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }
        #endregion

        public abstract Task Initialize();

    }
}
