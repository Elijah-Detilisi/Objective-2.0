namespace ObjectiveApp.Views.Objective.Templates;

public partial class FramedEditorTemplate : ContentView
{
	public FramedEditorTemplate()
	{
		InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty ObjectiveDescriptionProperty = BindableProperty.Create(
        nameof(ObjectiveDescription), typeof(String), typeof(FramedEditorTemplate)
    );

    //Fields
    public String ObjectiveDescription
    {
        get => (String)GetValue(ObjectiveDescriptionProperty);
        set => SetValue(ObjectiveDescriptionProperty, value);
    }

}