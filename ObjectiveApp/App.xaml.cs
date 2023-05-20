using ObjectiveApp.Handlers;
using Microsoft.Maui.Platform;

namespace ObjectiveApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //RegisterCustomEntryHandler();

            MainPage = new AppShell();
        }

        public void RegisterCustomEntryHandler()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
            {
                if (view is CustomEntry)
                {
                #if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
                #elif __IOS__
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                #elif WINDOWS
                    handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
                #endif
                }
            });
        }
    }
}