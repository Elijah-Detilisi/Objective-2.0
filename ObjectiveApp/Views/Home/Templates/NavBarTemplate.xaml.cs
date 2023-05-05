namespace ObjectiveApp.Views.Home.Templates;

public partial class NavBarTemplate : ContentView
{
	public NavBarTemplate()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty GreetingProperty = BindableProperty.Create(
        nameof(Greeting), typeof(string), typeof(NavBarTemplate)
    );
    public static readonly BindableProperty CurrentUserProperty = BindableProperty.Create(
        nameof(CurrentUser), typeof(string), typeof(NavBarTemplate)
    );

    public string Greeting
    {
        get => (string)GetValue(GreetingProperty);
        set => SetValue(GreetingProperty, value);
    }
    public string CurrentUser
    {
        get => (string)GetValue(CurrentUserProperty);
        set => SetValue(CurrentUserProperty, value);
    }
    
}