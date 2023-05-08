using ObjectiveApp.Models;

namespace ObjectiveApp.Views.Home.Templates;

public partial class CardTemplate : ContentView
{
	public CardTemplate()
	{
        RandomQuote = new();

        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty RandomQuoteProperty = BindableProperty.Create(
        nameof(RandomQuote), typeof(Quote), typeof(CardTemplate)
    );
    
    //Fields
    public Quote RandomQuote
    {
        get => (Quote)GetValue(RandomQuoteProperty);
        set => SetValue(RandomQuoteProperty, value);
    }
}