using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Objective;

public partial class ObjectiveView : ContentPage
{

    #region Fields
    private ObjectiveViewModel _viewModel;
    #endregion

    #region Construction
    public ObjectiveView(ObjectiveViewModel viewModel)
	{
        _viewModel = viewModel;
        BindingContext = viewModel;

        InitializeComponent();
	}
    #endregion

    #region App lifecycle method
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        SaveButton.IsVisible = !(_viewModel.IsCelebrating);
        base.OnNavigatedTo(args);
    }
    #endregion

}