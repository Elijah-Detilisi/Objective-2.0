namespace ObjectiveApp.Views.Home._customControls;

public partial class EmptyListMessage : VerticalStackLayout
{
    #region Construction
    public EmptyListMessage()
    {
        InitializeComponent();
    }
    #endregion

    #region Properties
    public string DayOfWeek
    {
        get => (string)GetValue(DayOfWeekProperty);
        set => SetValue(DayOfWeekProperty, value);
    }
    #endregion

    #region Bindable properties

    public static readonly BindableProperty DayOfWeekProperty = BindableProperty.Create(
        propertyName: nameof(DayOfWeek),
        returnType: typeof(string),
        declaringType: typeof(EmptyListMessage),
        defaultValue: "day",
        defaultBindingMode: BindingMode.TwoWay);
    #endregion

}