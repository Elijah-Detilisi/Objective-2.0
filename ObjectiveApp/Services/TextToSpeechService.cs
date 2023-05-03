namespace ObjectiveApp.Services
{
    public class TextToSpeechService
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
