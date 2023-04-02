namespace Objective.Maui_App.Views.Templates;

public partial class MainHeader : ContentView
{
    public readonly BindableProperty GreetingTitleProperty;
    public string GreetingMessage
    {
        get => (string)GetValue(GreetingTitleProperty);
        set => SetValue(GreetingTitleProperty, value);
    }

    public MainHeader()
	{
        GreetingTitleProperty = BindableProperty.Create
        (
            nameof(GreetingMessage), 
            typeof(string), typeof(MainHeader), string.Empty
        );

        InitializeComponent();
	}
}