using System.Reactive;

using IXRay.Hub.Avalonia.Services;

using ReactiveUI;

namespace IXRay.Hub.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public INavigationService NavigationService { get; set; }

    public ReactiveCommand<Unit, Unit>? NavigateToHomeCommand { get; set; }
    public ReactiveCommand<Unit, Unit>? NavigateToSettingsCommand { get; set; }

    public MainWindowViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;

        SetupBinding();
    }

    private void SetupBinding()
    {
        NavigateToHomeCommand = ReactiveCommand.Create<Unit>(execute =>
        {
            NavigationService.NavigateTo<HomeViewModel>();
        });
        NavigateToSettingsCommand = ReactiveCommand.Create<Unit>(execute =>
        {
            NavigationService.NavigateTo<SettingsViewModel>();
        });
    }
}
