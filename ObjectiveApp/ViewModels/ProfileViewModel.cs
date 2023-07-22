using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ObjectiveApp.DataAccess;
using ObjectiveApp.Models;

namespace ObjectiveApp.ViewModels
{
    public partial class ProfileViewModel : ObservableObject, IQueryAttributable
    {
        #region Fields
        private readonly UserDataAccess _userData;
        #endregion

        #region Properties
        [ObservableProperty]
        public User currentUser;
        #endregion

        #region Constrution
        public ProfileViewModel
        (
            UserDataAccess userData
        )
        {
            _userData = userData;
        }
        #endregion

        #region Commands

        [RelayCommand]
        public async void OnSave()
        {
            if (CurrentUser.Username !="")
            {
                await _userData.SaveAsync(CurrentUser);
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await Shell.Current.DisplayAlert
                (
                    title: "🙊",
                    message: "~ Enter a valid username",
                    cancel: "Got it"
                );
            }
        }
        #endregion

        #region Load methods
        public async Task LoadViewModel(int userId = 0)
        {
            ResetViewModel();

            if (userId > 0)
            {
                var result = await _userData.GetAsync(x => x.Id == userId);
                if (result.Any())
                {
                    CurrentUser = result.First();
                }
            }
        }
        #endregion

        #region Helper methods
        private void ResetViewModel()
        {
            CurrentUser = new();
        }
        #endregion

        #region IQuery methods
        async void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("userId"))
            {
                int userId = Int32.Parse(query["userId"].ToString());
                await LoadViewModel(userId);
            }
            else
            {
                await LoadViewModel();
            }
        }
        #endregion

    }
}
