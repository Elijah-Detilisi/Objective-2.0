using ObjectiveApp.Views.Objective;

namespace ObjectiveApp.Views.Home._customControls;

public partial class ListItem : Frame
{
    #region Construction
    public ListItem()
	{
		InitializeComponent();
	}
    #endregion

    #region Event handlers
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        BackgroundColor = Color.FromArgb("#ACACAC");
        await Shell.Current.GoToAsync($"{nameof(ObjectiveView)}?ObjectiveId={ClassId}");
    }
    #endregion

}