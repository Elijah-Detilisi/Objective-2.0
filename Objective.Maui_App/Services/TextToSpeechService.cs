namespace Objective.Maui_App.Services
{
    public static class TextToSpeechService
    {
        public async static Task Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                await TextToSpeech.Default.SpeakAsync(text);
            }
        }
    }
}
