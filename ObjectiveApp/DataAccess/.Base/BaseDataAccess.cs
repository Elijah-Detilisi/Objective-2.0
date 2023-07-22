using ObjectiveApp.Configs;
using ObjectiveApp.Models.Base;
using SQLite;
using System.Diagnostics;

namespace ObjectiveApp.DataAccess.Base
{
    public class BaseDataAccess<TModel> where TModel : BaseModel, new()
    {
        #region Fields
        protected SQLiteAsyncConnection _connection;
        #endregion

        #region Helper methods
        private static void NullCheck(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }
        #endregion

        #region Init methods
        protected virtual async Task InitializeAsync()
        {
            if (_connection is null)
            {
                _connection = new SQLiteAsyncConnection(Constants.DatabasePath);
                _connection.Tracer = new Action<string>(q => Debug.WriteLine(q));
                _connection.Trace = true;

                await _connection.CreateTableAsync<TModel>();
            }
        }
        #endregion

        #region CRUD methods
        public async Task<int> AddAsync(TModel model)
        {
            BaseDataAccess<TModel>.NullCheck(model);
            await InitializeAsync();

            return await _connection.InsertAsync(model);
        }
        public async Task<int> UpdateAsync(TModel model)
        {
            BaseDataAccess<TModel>.NullCheck(model);
            await InitializeAsync();

            return await _connection.UpdateAsync(model);
        }
        public async Task SaveAsync(TModel model)
        {
            if (model.Id == 0)
            {
                await AddAsync(model);
            }
            else
            {
                await UpdateAsync(model);
            }
        }
        public async Task<int> Delete(TModel model)
        {
            BaseDataAccess<TModel>.NullCheck(model);
            await InitializeAsync();

            return await _connection.DeleteAsync(model);
        }
        public async Task<List<TModel>> GetAsync(Func<TModel, bool> predicate)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            await InitializeAsync();
            var items = await _connection.Table<TModel>().ToListAsync();

            return items.Where(predicate).ToList();
        }

        #endregion
    }
}
