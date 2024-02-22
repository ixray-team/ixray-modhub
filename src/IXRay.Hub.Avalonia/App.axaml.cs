using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using IXRay.Hub.Avalonia.Services;
using IXRay.Hub.Avalonia.ViewModels;

using Microsoft.Extensions.DependencyInjection;

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

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<SettingsViewModel>();
        services.AddTransient<MessageWindowViewModel>();

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(
            provider => viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));
        services.AddSingleton<ViewModelLocator>();
        services.AddSingleton<WindowMapper>();
        services.AddSingleton<IWindowManager, WindowManager>();

        return services;
    }
}
