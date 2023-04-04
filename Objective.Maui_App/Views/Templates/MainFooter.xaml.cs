using System.Windows.Input;

namespace Objective.Maui_App.Views.Templates;

public partial class MainFooter : ContentView
{
	public MainFooter()
	{
		InitializeComponent();
	}

    #region Properties
    
    public static readonly BindableProperty QuoteTextProperty = BindableProperty.Create
    (
        nameof(QuoteText), typeof(string), typeof(MainHeader)
    );

    #endregion

    #region Fields
    public string QuoteText
    {
        get => (string)GetValue(QuoteTextProperty);
        set => SetValue(QuoteTextProperty, value);
    }
    #endregion

}