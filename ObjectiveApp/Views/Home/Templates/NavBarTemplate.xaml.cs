using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace ObjectiveApp.Views.Home.Templates;

public partial class NavBarTemplate : ContentView
{
	public NavBarTemplate()
	{
        Greeting = "Good day";
        CurrentUser = "User";

        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty GreetingProperty = BindableProperty.Create(
        nameof(Greeting), typeof(string), typeof(NavBarTemplate)
    );
    public static readonly BindableProperty CurrentUserProperty = BindableProperty.Create(
        nameof(CurrentUser), typeof(string), typeof(NavBarTemplate)
    );
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
        nameof(SearchCommand), typeof(ICommand), typeof(NavBarTemplate), defaultValueCreator: DefaultCommand
    );
    public static readonly BindableProperty ProfileCommandProperty = BindableProperty.Create(
        nameof(ProfileCommand), typeof(RelayCommand), typeof(NavBarTemplate), defaultValueCreator: DefaultCommand
    );

    //Fields
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

    //Commands
    private static object DefaultCommand(BindableObject bindable) => new RelayCommand(
        () => Shell.Current.DisplayAlert(
            title:"Default", message:"No Action For Clicked Button. Try another.", cancel:"Okay"
        )
    );
   
    public ICommand SearchCommand
    {
        get => (ICommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }

    public RelayCommand ProfileCommand
    {
        get => (RelayCommand)GetValue(ProfileCommandProperty);
        set => SetValue(ProfileCommandProperty, value);
    }

}