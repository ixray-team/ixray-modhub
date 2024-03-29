using System.Diagnostics.CodeAnalysis;

using Avalonia.Controls;

using IXRay.Hub.Avalonia.ViewModels;
using IXRay.Hub.Avalonia.Views;

namespace IXRay.Hub.Avalonia.Services;

public class WindowMapper
{
    private readonly Dictionary<Type, Type> _mappings = [];

    public WindowMapper()
    {
        RegisterMapping<MainWindowViewModel, MainWindow>();
        RegisterMapping<MessageWindowViewModel, MessageWindow>();
    }

    public void RegisterMapping<TViewModel, TWindow>()
        where TViewModel : ViewModelBase
        where TWindow : Window
        => _mappings[typeof(TViewModel)] = typeof(TWindow);

    [return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    public Type? GetWindowTypeForViewModel(Type viewModelType)
    {
        _mappings.TryGetValue(viewModelType, out var windowType);
        return windowType;
    }
}
