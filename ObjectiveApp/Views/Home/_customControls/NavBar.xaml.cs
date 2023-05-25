using ObjectiveApp.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ObjectiveApp.Views.Home._customControls;

public partial class NavBar : Grid
{
    #region Construction
    public NavBar()
	{
		InitializeComponent();
	}
    #endregion

    #region Properties
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
    #endregion

    # region Commands
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
    #endregion

    #region Bindable properties

    public static readonly BindableProperty GreetingProperty = BindableProperty.Create(
        propertyName: nameof(Greeting),
        returnType: typeof(string),
        declaringType: typeof(NavBar),
        defaultValue: "Good day",
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty CurrentUserProperty = BindableProperty.Create(
        propertyName: nameof(CurrentUser),
        returnType: typeof(User),
        declaringType: typeof(NavBar),
        defaultValue: new User(),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
        propertyName: nameof(SearchCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(NavBar),
        defaultValueCreator: null,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty ProfileCommandProperty = BindableProperty.Create(
        propertyName: nameof(ProfileCommand),
        returnType: typeof(RelayCommand),
        declaringType: typeof(NavBar),
        defaultValueCreator: null,
        defaultBindingMode: BindingMode.TwoWay);

    #endregion

}