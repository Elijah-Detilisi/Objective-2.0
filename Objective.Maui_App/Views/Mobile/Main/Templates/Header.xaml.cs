using System.Windows.Input;

namespace Objective.Maui_App.Views.Mobile.Main.Templates;

public partial class Header : ContentView
{
	public Header()
	{
        UsernameText = "Username";
        GreetingText = "Good day";
        InitializeComponent();
	}

    #region Properties
    
    public static readonly BindableProperty UsernameTextProperty = BindableProperty.Create(nameof(UsernameText), typeof(string), typeof(Header));
    public static readonly BindableProperty GreetingTextProperty = BindableProperty.Create(nameof(GreetingText), typeof(string), typeof(Header));
    
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(Header),
        defaultBindingMode: BindingMode.TwoWay, defaultValueCreator: DefaultCommand);
    public static readonly BindableProperty ProfileCommandProperty = BindableProperty.Create(nameof(ProfileCommand), typeof(ICommand), typeof(Header),
        defaultBindingMode: BindingMode.TwoWay, defaultValueCreator: DefaultCommand);

    #endregion

    #region Fields
    public string UsernameText
    {
        get => (string)GetValue(UsernameTextProperty);
        set => SetValue(UsernameTextProperty, value);
    }
    public string GreetingText
    {
        get => (string)GetValue(GreetingTextProperty);
        set => SetValue(GreetingTextProperty, value);
    }
    #endregion

    #region Commands
    public ICommand SearchCommand
    {
        get => (ICommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }

    public ICommand ProfileCommand
    {
        get => (ICommand)GetValue(ProfileCommandProperty);
        set => SetValue(ProfileCommandProperty, value);
    }

    private static object DefaultCommand(BindableObject bindable)
    {
        return new Command(() => TextToSpeech.Default.SpeakAsync("Null action!"));
    }
    #endregion
}