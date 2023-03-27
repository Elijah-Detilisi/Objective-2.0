using Objective.Maui_App.Models;
using Objective.Maui_App.DataAccess.Base;

namespace Objective.Maui_App.DataAccess
{
    internal class UserData : DataAccess<UserModel>
    {
        protected override void CreateRepoTable()
        {
            _connection.CreateTableAsync<UserModel>().Wait();
        }

        public override async Task<List<UserModel>> Get(int? id)
        {
            if (id == null)
            {
                return await _connection.Table<UserModel>().Where(user => user.Id == id).ToListAsync();
            }
            else
            {
                return await _connection.Table<UserModel>().ToListAsync();
            }
        }

        public async Task<bool> VerifyUserAsync(String username, string password)
        {
            var result = await _connection.Table<UserModel>().Where(user => user.Username == username && user.Password == password).FirstOrDefaultAsync();

            return result == null;
        }
    }
}
