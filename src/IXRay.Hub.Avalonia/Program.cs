using Avalonia;
using Avalonia.ReactiveUI;

using IXRay.Hub.Avalonia.Helpers;
using IXRay.Hub.Avalonia.Logging;

using Serilog;

namespace IXRay.Hub.Avalonia;

internal sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        try {
            StartApp(args);
        } catch (Exception exception) {
            Log.Fatal("{Message} \n {StackTrace}", exception.Message, exception.StackTrace);
        } finally {
            Log.CloseAndFlush();
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();

    private static void StartApp(string[] args)
    {
        Log.Logger = LogManager.CreateLoggerDebug();

        Log.Information("Start IX-Ray Hub");
        SystemInfoPrinter.PrintOsInfo(Log.Logger);

        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }
}
