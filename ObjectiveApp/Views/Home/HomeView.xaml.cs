using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Home;

public partial class HomeView : ContentPage
{
	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}