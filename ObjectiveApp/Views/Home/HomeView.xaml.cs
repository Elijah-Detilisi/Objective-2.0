using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Home;

public partial class HomeView : ContentPage
{
    private HomeViewModel _viewModel;

    public HomeView(HomeViewModel viewModel)
	{
        _viewModel = viewModel;
        BindingContext = viewModel;

        InitializeComponent();
    }

    protected override async void OnParentSet()
    {
        await _viewModel.LoadViewModel();
        base.OnParentSet();
    }

    protected override async void OnAppearing()
    {
        await _viewModel.LoadObjectiveListAsync();
        MyCollectionView.ItemsSource = _viewModel.ObjectiveList;

        base.OnAppearing();
    }
}