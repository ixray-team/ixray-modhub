using Avalonia.Controls;

using IXRay.Hub.Avalonia.ViewModels;

namespace IXRay.Hub.Avalonia.Services;

public interface IWindowManager
{
    Window GetWindow(ViewModelBase viewModel);
    void ShowWindow(ViewModelBase viewModel);
    void CloseWindow(ViewModelBase viewModel);
}
