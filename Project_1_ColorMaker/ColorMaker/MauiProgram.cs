using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace ColorMaker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping("TextColor", (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Blue);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Blue;
#elif WINDOWS
            handler.PlatformView.Background = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Blue);
#endif
            });
            // Customize Button control.
            return builder.Build();
        }
    }
}
