using IXRay.Hub.Avalonia.ViewModels;

namespace IXRay.Hub.Avalonia.Services;

public interface IWindowManager
{
    void ShowWindow(ViewModelBase viewModel);
}
