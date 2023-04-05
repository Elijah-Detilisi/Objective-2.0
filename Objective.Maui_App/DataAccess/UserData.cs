using SQLite;
using Objective.Maui_App.DataAccess.Base;

namespace Objective.Maui_App.DataAccess
{
    internal class UserData : DataAccess<Models.User>
    {
        #region Construction
        public UserData(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public override async Task Initialize()
        {
            await base.CreateTable();
        }

        #endregion

    }
}
