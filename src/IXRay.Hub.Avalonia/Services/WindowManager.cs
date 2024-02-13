using Avalonia.Controls;

using IXRay.Hub.Avalonia.ViewModels;

namespace IXRay.Hub.Avalonia.Services;

public class WindowManager(WindowMapper windowMapper) : IWindowManager
{
    private readonly WindowMapper _windowMapper = windowMapper;

    public void ShowWindow(ViewModelBase viewModel)
    {
        var windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());
        if (windowType is null) {
            return;
        }

        if (Activator.CreateInstance(windowType) is not Window window) {
            return;
        }

        window.DataContext = viewModel;
        window.Show();
    }
}
