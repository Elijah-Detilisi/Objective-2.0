namespace Objective.Maui_App.Views.Mobile.Main.Templates;

public partial class Objective : ContentView
{
	public Objective()
	{
        ObjectiveText = new Models.Objective()
        {
            Title = "Customize profile.",
            Description = "Change your profile picture and username.",
            DueDate = DateTime.Now.Date,
            IsDone = false,
        };

        InitializeComponent();
	}

    //Properties
    public static readonly BindableProperty ObjectiveProperty = BindableProperty.Create(nameof(ObjectiveText), typeof(Models.Objective), typeof(Objective));

    //Fields
    public Models.Objective ObjectiveText
    {
        get => (Models.Objective)GetValue(ObjectiveProperty);
        set => SetValue(ObjectiveProperty, value);
    }

    public string DueDateText => ObjectiveText.DueDate.ToString("dd MMM yyyy");
}