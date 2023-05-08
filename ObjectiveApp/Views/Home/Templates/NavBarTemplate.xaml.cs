using ObjectiveApp.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ObjectiveApp.Views.Home.Templates;

public partial class NavBarTemplate : ContentView
{
	public NavBarTemplate()
	{
        CurrentUser = new();
        Greeting = "Good day";

        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty GreetingProperty = BindableProperty.Create(
        nameof(Greeting), typeof(string), typeof(NavBarTemplate)
    );
    public static readonly BindableProperty CurrentUserProperty = BindableProperty.Create(
        nameof(CurrentUser), typeof(User), typeof(NavBarTemplate)
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
    public User CurrentUser
    {
        get => (User)GetValue(CurrentUserProperty);
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