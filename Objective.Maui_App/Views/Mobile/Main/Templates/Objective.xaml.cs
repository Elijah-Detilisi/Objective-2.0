namespace Objective.Maui_App.Views.Mobile.Main.Templates;

public partial class Objective : ContentView
{
	public Objective()
	{
        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty ObjectiveProperty 
        = BindableProperty.Create(nameof(ObjectiveModel), typeof(Models.Objective), typeof(Objective));

    //Fields
    public Models.Objective ObjectiveModel
    {
        get => (Models.Objective)GetValue(ObjectiveProperty);
        set => SetValue(ObjectiveProperty, value);
    }

}