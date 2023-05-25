using CommunityToolkit.Mvvm.Input;
using ObjectiveApp.Models;
using System.Windows.Input;

namespace ObjectiveApp.Views.Home._customControls;

public partial class QuoteCard : Border
{
    #region Construction
    public QuoteCard()
    {
        InitializeComponent();
    }
    #endregion

    #region Properties
    public Quote RandomQuote
    {
        get => (Quote)GetValue(RandomQuoteProperty);
        set => SetValue(RandomQuoteProperty, value);
    }
    #endregion

    #region Bindable properties

    public static readonly BindableProperty RandomQuoteProperty = BindableProperty.Create(
        propertyName: nameof(RandomQuote),
        returnType: typeof(Quote),
        declaringType: typeof(QuoteCard),
        defaultValue: new Quote(),
        defaultBindingMode: BindingMode.TwoWay);
    #endregion

}