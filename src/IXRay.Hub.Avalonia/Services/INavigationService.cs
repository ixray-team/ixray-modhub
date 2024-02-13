using IXRay.Hub.Avalonia.ViewModels;

namespace IXRay.Hub.Avalonia.Services;

public interface INavigationService
{
    ViewModelBase? CurrentView { get; }

    void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
}
