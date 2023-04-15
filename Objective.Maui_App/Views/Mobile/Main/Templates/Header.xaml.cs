using System.Windows.Input;

namespace Objective.Maui_App.Views.Mobile.Main.Templates;

public partial class Header : ContentView
{
    public Header()
    {
        CurrentUser = new();
        GreetingText = "Good day";
        
        InitializeComponent();
    }

    //Properties
    public static readonly BindableProperty CurrentUserProperty = BindableProperty.Create(nameof(CurrentUser), typeof(Models.Quote), typeof(Quote));
    public static readonly BindableProperty GreetingTextProperty = BindableProperty.Create(nameof(GreetingText), typeof(string), typeof(Header));
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(Header), defaultValueCreator: DefaultCommand);
    public static readonly BindableProperty ProfileCommandProperty = BindableProperty.Create(nameof(ProfileCommand), typeof(ICommand), typeof(Header), defaultValueCreator: DefaultCommand);

    //Fields
    public Models.User CurrentUser
    {
        get => (Models.User)GetValue(CurrentUserProperty);
        set => SetValue(CurrentUserProperty, value);
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
