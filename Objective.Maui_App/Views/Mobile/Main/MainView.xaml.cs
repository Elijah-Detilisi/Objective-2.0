using Objective.Maui_App.ViewModels;

namespace Objective.Maui_App.Views.Mobile.Main;

public partial class MainView : ContentPage
{
	private MainViewModel _viewModel;

    public MainView(MainViewModel viewModel)
	{
		_viewModel = viewModel;
        this.BindingContext = _viewModel;

        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        await _viewModel.InitializeRepos();
        await _viewModel.LoadRandomQuote();

        base.OnAppearing();
    }

}