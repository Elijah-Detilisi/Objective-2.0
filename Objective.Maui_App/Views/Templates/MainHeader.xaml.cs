using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Objective.Maui_App.Views.Templates;

public partial class MainHeader : ContentView
{
    public MainHeader()
    {
        InitializeComponent();
    }

    #region Properties
    public static readonly BindableProperty GreetingTextProperty = BindableProperty.Create(nameof(GreetingText), typeof(string), typeof(MainHeader));
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(MainHeader),
        defaultBindingMode: BindingMode.TwoWay, defaultValueCreator: DefaultCommand);
    public static readonly BindableProperty ProfileCommandProperty = BindableProperty.Create(nameof(ProfileCommand), typeof(ICommand), typeof(MainHeader),
        defaultBindingMode: BindingMode.TwoWay, defaultValueCreator: DefaultCommand);

    #endregion

    #region Fields
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
        return new Command(() => TextToSpeech.SpeakAsync("Hello there"));
    }
    #endregion

}