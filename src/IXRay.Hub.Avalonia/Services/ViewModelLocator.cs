using IXRay.Hub.Avalonia.ViewModels;

using Microsoft.Extensions.DependencyInjection;

namespace IXRay.Hub.Avalonia.Services;

public class ViewModelLocator(IServiceProvider serviceProvider)
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    // Windows
    public MainWindowViewModel MainWindowViewModel => _serviceProvider.GetRequiredService<MainWindowViewModel>();
    public MessageWindowViewModel MessageWindowViewModel => _serviceProvider.GetRequiredService<MessageWindowViewModel>();

    // Views
    public HomeViewModel HomeViewModel => _serviceProvider.GetRequiredService<HomeViewModel>();
    public SettingsViewModel SettingsViewModel => _serviceProvider.GetRequiredService<SettingsViewModel>();
}
