namespace ObjectiveApp.Views.Objective._customControls;

public partial class DateTimePicker : Grid
{
    #region Construction
    public DateTimePicker()
	{
		InitializeComponent();
	}
    #endregion

    #region Properties
    public TimeSpan Time
    {
        get => (TimeSpan)GetValue(TimeProperty);
        set { SetValue(TimeProperty, value); }
    }
    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set { SetValue(DateProperty, value); }
    }
    #endregion

    #region Bindable properties
    public static readonly BindableProperty DateProperty = BindableProperty.Create(
        propertyName: nameof(Date),
        returnType: typeof(DateTime),
        declaringType: typeof(DateTimePicker),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TimeProperty = BindableProperty.Create(
        propertyName: nameof(Time),
        returnType: typeof(TimeSpan),
        declaringType: typeof(DateTimePicker),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);
    #endregion

}