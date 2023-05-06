namespace ObjectiveApp.Views.Home.Templates;

public partial class EmptyListTemplate : ContentView
{
	public EmptyListTemplate()
	{
        DayOfWeek = "Day";
        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty DayOfWeekProperty = BindableProperty.Create(
        nameof(DayOfWeek), typeof(string), typeof(EmptyListTemplate)
    );

    //Fields
    public string DayOfWeek
    {
        get => (string)GetValue(DayOfWeekProperty);
        set => SetValue(DayOfWeekProperty, value);
    }
}