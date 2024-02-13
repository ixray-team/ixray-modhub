using System.Reactive;

using IXRay.Hub.Avalonia.Services;

using ReactiveUI;

namespace IXRay.Hub.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IWindowManager _windowManager;
    private readonly ViewModelLocator _viewModelLocator;

    public INavigationService NavigationService { get; set; }

    public ReactiveCommand<Unit, Unit>? NavigateToHomeCommand { get; set; }
    public ReactiveCommand<Unit, Unit>? NavigateToSettingsCommand { get; set; }
    public ReactiveCommand<Unit, Unit>? OpenMessageWindowCommand { get; set; }

    public MainWindowViewModel(INavigationService navigationService, IWindowManager windowManager, 
        ViewModelLocator viewModelLocator)
    {
        NavigationService = navigationService;
        _windowManager = windowManager;
        _viewModelLocator = viewModelLocator;
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
        OpenMessageWindowCommand = ReactiveCommand.Create<Unit>(execute =>
        {
            _windowManager.ShowWindow(_viewModelLocator.MessageWindowViewModel);
        });
    }
}
