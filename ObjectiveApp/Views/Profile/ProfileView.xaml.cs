using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Profile;

public partial class ProfileView : ContentPage
{
    #region Fields
    private ProfileViewModel _viewModel;
    #endregion

    #region Construction
    public ProfileView(ProfileViewModel viewModel)
	{
        _viewModel = viewModel;
        BindingContext = viewModel;

        InitializeComponent();
	}
    #endregion

}