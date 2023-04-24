namespace Objective.Maui_App.Views.Mobile.Main;

public partial class SearchView : ContentPage
{
    private List<Models.Objective> _searchList;

    public SearchView(List<Models.Objective> searchList)
	{
        _searchList = searchList;

        InitializeComponent();
        InitializeSearchListView();
    }

    #region Initialization
    private void InitializeSearchListView()
    {
        var listItemView = new DataTemplate(() => {
            return new Templates.Objective();
        });

        SearchListView.ItemTemplate = listItemView;
        SearchListView.ItemsSource = _searchList;
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
            SearchListView.ItemsSource = _searchList;
        }
        else
        {
            SearchListView.ItemsSource = _searchList.Where(
                item => item.Title.ToLower().Contains(searchText.ToLower())
            );
        }
    }
    #endregion

}