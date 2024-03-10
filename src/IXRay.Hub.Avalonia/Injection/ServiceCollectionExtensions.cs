using IXRay.Hub.Avalonia.ViewModels;
using IXRay.Hub.Avalonia.Views;

using Microsoft.Extensions.DependencyInjection;

namespace IXRay.Hub.Avalonia.Injection;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresetationServices(this IServiceCollection services)
    {
        services.AddViewModels();
        services.AddViews();
        services.AddPages();
        services.AddWindows();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<SettingsViewModel>();
        services.AddTransient<MessageWindowViewModel>();

        return services;
    }

    private static IServiceCollection AddViews(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddPages(this IServiceCollection services)
    {
        services.AddSingleton<HomeView>();
        services.AddSingleton<SettingsView>();

        return services;
    }

    private static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddScoped<MessageWindow>();

        return services;
    }
}
