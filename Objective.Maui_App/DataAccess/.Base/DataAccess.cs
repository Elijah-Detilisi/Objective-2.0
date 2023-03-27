using SQLite;

namespace Objective.Maui_App.DataAccess.Base
{
    public abstract class DataAccess<Model>
    {
        #region Fields
        protected SQLiteAsyncConnection _connection;
        private string _connectionString => Path.Combine(FileSystem.AppDataDirectory, "objective.db3");
        #endregion

        #region Construction
        public DataAccess()
        {
            if (_connection == null)
            {
                _connection = new SQLiteAsyncConnection(_connectionString);

               CreateRepoTable();
            }
        }

        #endregion

        #region CRUD methods
        protected abstract void CreateRepoTable();
        public async Task<int> Add(Model model)
        {
            return await _connection.InsertAsync(model);
        }
        public async Task<int> Update(Model model)
        {
            return await _connection.UpdateAsync(model);
        }
        public async Task<int> Delete(Model model)
        {
            return await _connection.DeleteAsync(model);
        }
        public abstract Task<List<Model>> Get(int? id);

        #endregion

    }
}
