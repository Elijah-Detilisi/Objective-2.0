using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Objective;

[QueryProperty(nameof(ObjectiveId), nameof(ObjectiveId))]
public partial class ObjectiveView : ContentPage
{

    #region Fields
    private ObjectiveViewModel _viewModel;
    public int ObjectiveId { get; set; }
    #endregion

    #region Construction
    public ObjectiveView(ObjectiveViewModel viewModel)
	{
        _viewModel = viewModel;
        BindingContext = viewModel;

        InitializeComponent();
	}
    #endregion

    #region App lifecylce methods
    protected override async void OnAppearing()
    {
        await _viewModel.LoadViewModel(ObjectiveId);
        base.OnAppearing();
    }
    #endregion

}