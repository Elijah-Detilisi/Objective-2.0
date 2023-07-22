using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Home;

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
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.LoadViewModel();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            MyCollectionView.ItemsSource = _viewModel.ObjectiveList;
        });

        await _viewModel.AnnounceStartUpMessage();

        base.OnNavigatedTo(args);
    }

    #endregion

}