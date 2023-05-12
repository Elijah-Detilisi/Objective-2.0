using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Objective;

public partial class ObjectiveView : ContentPage
{
    private ObjectiveViewModel _viewModel;

    public ObjectiveView(ObjectiveViewModel viewModel)
	{
        _viewModel = viewModel;
        BindingContext = viewModel;

        InitializeComponent();
	}
}