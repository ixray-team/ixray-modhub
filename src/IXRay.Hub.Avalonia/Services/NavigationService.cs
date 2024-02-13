using IXRay.Hub.Avalonia.ViewModels;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace IXRay.Hub.Avalonia.Services;

public class NavigationService(Func<Type, ViewModelBase> viewModelFactory) : ReactiveObject, INavigationService
{
    private readonly Func<Type, ViewModelBase> _viewModelFactory = viewModelFactory;

    [Reactive] public ViewModelBase? CurrentView { get; private set; }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        => CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
}
