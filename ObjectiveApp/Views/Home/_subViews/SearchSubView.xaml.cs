using ObjectiveApp.ViewModels;

namespace ObjectiveApp.Views.Home._subViews;

public partial class SearchSubView : ContentPage
{
    #region Fields
    private HomeViewModel _viewModel;
    #endregion

    #region Construction
    public SearchSubView(HomeViewModel viewModel)
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

    #region Commands and Handlers
    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        FilterSearchListCommand(e.NewTextValue);
    }
    private void FilterSearchListCommand(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            MyCollectionView.ItemsSource = _viewModel.ObjectiveList;
        }
        else
        {
            MyCollectionView.ItemsSource = _viewModel.ObjectiveList.Where(
                item => item.Title.ToLower().Contains(searchText.ToLower())
            );
        }
    }
    #endregion

}