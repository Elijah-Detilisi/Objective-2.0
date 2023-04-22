using System.Collections.ObjectModel;

namespace Objective.Maui_App.Views.Mobile.Main;

public partial class SearchView : ContentPage
{
    public ObservableCollection<Models.Objective> _objectives;

    public SearchView()
	{
        Objectives = new ObservableCollection<Models.Objective>()
        {
            new Models.Objective {Title = "Customize profile."},
            new Models.Objective {Title = "Customize profile."},
            new Models.Objective {Title = "Customize profile."},
            new Models.Objective {Title = "Customize profile."},
        };


        InitializeComponent();
	}

    public ObservableCollection<Models.Objective> Objectives
    {
        get { return _objectives; }
        set
        {
            _objectives = value;
            OnPropertyChanged();
        }
    }
}