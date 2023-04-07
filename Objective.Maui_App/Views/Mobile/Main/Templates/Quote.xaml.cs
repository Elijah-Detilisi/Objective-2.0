namespace Objective.Maui_App.Views.Mobile.Main.Templates;

public partial class Quote : ContentView
{
	public Quote()
	{
        QuoteText = new Models.Quote() {
            Phrase= "Whatever you do, work at it with all your heart.",
            Qoutee = "Paul the Apostle"
        };

        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty QuoteTextProperty = BindableProperty.Create(nameof(QuoteText), typeof(Models.Quote), typeof(Quote));

    //Fields
    public Models.Quote QuoteText
    {
        get => (Models.Quote)GetValue(QuoteTextProperty);
        set => SetValue(QuoteTextProperty, value);
    }
}