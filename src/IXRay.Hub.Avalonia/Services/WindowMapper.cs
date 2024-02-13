using Avalonia.Controls;

using IXRay.Hub.Avalonia.ViewModels;

namespace IXRay.Hub.Avalonia.Services;

public class WindowMapper
{
    private readonly Dictionary<Type, Type> _mappings = [];

    public WindowMapper()
    {
    }

    public void RegisterMapping<TViewModel, TWindow>() where TViewModel : ViewModelBase where TWindow : Window 
        => _mappings[typeof(TViewModel)] = typeof(TWindow);

    public Type? GetWindowTypeForViewModel(Type viewModelType)
    {
        _mappings.TryGetValue(viewModelType, out var windowType);
        return windowType;
    }
}
