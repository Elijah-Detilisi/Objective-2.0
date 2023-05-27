using ObjectiveApp.Views.Objective;

namespace ObjectiveApp.Views.Home._customControls;

public partial class ListItem : Frame
{
	public ListItem()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        BackgroundColor = Color.FromArgb("#ADD8E6");
        await Shell.Current.GoToAsync($"{nameof(ObjectiveView)}?ObjectiveId={ClassId}");
    }
}