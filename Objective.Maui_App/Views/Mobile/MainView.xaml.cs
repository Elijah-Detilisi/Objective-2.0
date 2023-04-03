using Objective.Maui_App.ViewModels;

namespace Objective.Maui_App.Views.Mobile;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();

        TextToSpeech.SpeakAsync(MainViewModel.GreetingText);
        Header.GreetingMessage = MainViewModel.GreetingText;
    }
}