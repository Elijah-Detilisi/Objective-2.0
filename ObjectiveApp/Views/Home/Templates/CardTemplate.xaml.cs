namespace ObjectiveApp.Views.Home.Templates;

public partial class CardTemplate : ContentView
{
	public CardTemplate()
	{
        Quotee = "Paul the Apostle";
        Quote = "Whatever you do, work at it with all your heart.";

        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty QuoteProperty = BindableProperty.Create(
        nameof(Quote), typeof(string), typeof(CardTemplate)
    );
    public static readonly BindableProperty QuoteeProperty = BindableProperty.Create(
        nameof(Quotee), typeof(string), typeof(CardTemplate)
    );

    //Fields
    public string Quote
    {
        get => (string)GetValue(QuoteProperty);
        set => SetValue(QuoteProperty, value);
    }
    public string Quotee
    {
        get => (string)GetValue(QuoteeProperty);
        set => SetValue(QuoteeProperty, value);
    }
}