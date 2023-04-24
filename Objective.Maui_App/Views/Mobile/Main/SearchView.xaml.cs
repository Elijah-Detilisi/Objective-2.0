using System.Collections.ObjectModel;

namespace Objective.Maui_App.Views.Mobile.Main;

public partial class SearchView : ContentPage
{
    public SearchView()
	{
        InitializeComponent();
        InitializeSearchListView();

        //SearchListView.ItemsSource = new ObservableCollection<Models.Objective>();
    }

    private void InitializeSearchListView()
    {
        var listItemView = new DataTemplate(() => {
            return new Templates.Objective();
        });

        SearchListView.ItemTemplate = listItemView;
    }
}