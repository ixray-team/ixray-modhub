using Microsoft.Extensions.DependencyInjection;

namespace IXRay.Hub.Avalonia.Helpers;

internal sealed class DesignTimeViewModelResolver<T>
    where T : notnull
{
    // ReSharper disable once UnusedMember.Global
    public T? ProvideValue(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<T>();
    }
}
