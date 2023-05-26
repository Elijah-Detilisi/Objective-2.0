using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Home;

public partial class HomeView : ContentPage
{
    #region Fields
    private HomeViewModel _viewModel;
    #endregion

    #region Construction
    public HomeView(HomeViewModel viewModel)
	{
        _viewModel = viewModel;
        BindingContext = viewModel;

        InitializeComponent();
    }
    #endregion

    #region App lifecycle method
    protected override async void OnAppearing()
    {
        await _viewModel.LoadViewModel();
        MyCollectionView.ItemsSource = _viewModel.ObjectiveList;

        base.OnAppearing();
    }
    #endregion

}