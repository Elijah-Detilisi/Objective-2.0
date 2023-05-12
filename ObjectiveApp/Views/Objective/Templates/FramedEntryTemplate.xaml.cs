namespace ObjectiveApp.Views.Objective.Templates;

public partial class FramedEntryTemplate : ContentView
{
	public FramedEntryTemplate()
	{
		InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty ObjectiveTitleProperty = BindableProperty.Create(
        nameof(ObjectiveTitle), typeof(String), typeof(FramedEntryTemplate)
    );

    //Fields
    public String ObjectiveTitle
    {
        get => (String)GetValue(ObjectiveTitleProperty);
        set => SetValue(ObjectiveTitleProperty, value);
    }
}