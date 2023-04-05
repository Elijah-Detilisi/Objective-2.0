using SQLite;
using Objective.Maui_App.DataAccess.Base;

namespace Objective.Maui_App.DataAccess
{
    public class ObjectiveData : DataAccess<Models.Objective>
    {
        #region Construction
        public ObjectiveData(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public override async Task Initialize()
        {
            await base.CreateTable();
        }

        #endregion

    }
}
