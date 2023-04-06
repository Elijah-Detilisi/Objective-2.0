using System.Windows.Input;

namespace Objective.Maui_App.Views.Mobile.Main.Templates;

public partial class Header : ContentView
{
    public Header()
    {
        UsernameText = "User";
        GreetingText = "Good day";
        InitializeComponent();
    }

    //Properties
    public static readonly BindableProperty UsernameTextProperty = BindableProperty.Create(nameof(UsernameText), typeof(string), typeof(Header));
    public static readonly BindableProperty GreetingTextProperty = BindableProperty.Create(nameof(GreetingText), typeof(string), typeof(Header));
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(Header), defaultValueCreator: DefaultCommand);
    public static readonly BindableProperty ProfileCommandProperty = BindableProperty.Create(nameof(ProfileCommand), typeof(ICommand), typeof(Header), defaultValueCreator: DefaultCommand);

    //Fields
    public string UsernameText 
    {
        get => (string)GetValue(UsernameTextProperty);
        set => SetValue(UsernameTextProperty, value);
    }
    public string GreetingText {
        get => (string)GetValue(GreetingTextProperty);
        set => SetValue(GreetingTextProperty, value);
    }

    //Commands
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

    //Helper
    private static object DefaultCommand(BindableObject bindable) => new Command(() => TextToSpeech.Default.SpeakAsync("Null action!"));
}
