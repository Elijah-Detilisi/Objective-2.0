using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Home;

[QueryProperty(nameof(ObjectiveId), nameof(ObjectiveId))]
public partial class HomeView : ContentPage
{
    #region Fields
    private HomeViewModel _viewModel;
    public int ObjectiveId { get; set; }
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
        await _viewModel.LoadViewModel(ObjectiveId);
        MyCollectionView.ItemsSource = _viewModel.ObjectiveList;

        base.OnAppearing();
    }
    #endregion

}