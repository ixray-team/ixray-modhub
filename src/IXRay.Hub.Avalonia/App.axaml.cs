using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using IXRay.Hub.Avalonia.Injection;
using IXRay.Hub.Avalonia.Logging;
using IXRay.Hub.Avalonia.Services;
using IXRay.Hub.Avalonia.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace IXRay.Hub.Avalonia;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App()
    {
        _serviceProvider = ConfigureServices()
               .BuildServiceProvider();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            desktop.MainWindow = windowManager.GetWindow(_serviceProvider.GetRequiredService<MainWindowViewModel>());
            desktop.MainWindow?.Show();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddLogging(loggingBuilder =>
            loggingBuilder.AddSerilog(LogManager.CreateLoggerDebug(), dispose: true));

        services.AddPresetationServices();

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(
            provider => viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));
        services.AddSingleton<ViewModelLocator>();
        services.AddSingleton<IWindowManager, WindowManager>();

        services.AddSingleton<WindowMapper>();

        return services;
    }
}
