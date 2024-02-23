using Avalonia.Controls;

using IXRay.Hub.Avalonia.ViewModels;

namespace IXRay.Hub.Avalonia.Services;

/// <summary>
/// Manages windows based on provided view models
/// </summary>
/// <param name="windowMapper">Window mapper instance to be used for retrieving window types</param>
public class WindowManager(WindowMapper windowMapper) : IWindowManager
{
    private readonly WindowMapper _windowMapper = windowMapper;

    /// <summary>
    /// Retrieves window associated with provided view model and sets its data context
    /// </summary>
    /// <param name="viewModel">View model for which to retrieve window</param>
    /// <returns>Window associated with provided view model, or <c>null</c> if window type is not found</returns>
    /// <exception cref="ArgumentException">Thrown when window type is not found for provided view model</exception>
    /// <exception cref="InvalidOperationException">Thrown when failed to create instance of window</exception>
    public Window GetWindow(ViewModelBase viewModel)
    {
        // Get the window type for the provided view model from WindowMapper
        var windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType()) 
            ?? throw new ArgumentException("Window type not found for the provided view model", nameof(viewModel));

        if (windowType.GetConstructors().Length == 0) {
            throw new InvalidOperationException($"No constructors found for window type '{windowType.FullName}'");
        }
        if (viewModel.GetType().GetConstructors().Length == 0) {
            throw new InvalidOperationException($"No constructors found for viewModel type '{viewModel.GetType().FullName}'");
        }

        // Create an instance of the window using Activator
        if (Activator.CreateInstance(windowType) is Window window) {
            // Set the data context for the window
            window.DataContext = viewModel;
            return window;
        } else {
            // If failed to create an instance of the window, throw InvalidOperationException
            throw new InvalidOperationException("Failed to create an instance of window");
        }
    }

    /// <summary>
    /// Shows window associated with provided view model
    /// </summary>
    /// <param name="viewModel">View model for which to show window</param>
    public void ShowWindow(ViewModelBase viewModel) => GetWindow(viewModel)?.Show();

    /// <summary>
    /// Closes window associated with provided view model
    /// </summary>
    /// <param name="viewModel">View model for which to close window</param>
    public void CloseWindow(ViewModelBase viewModel) => GetWindow(viewModel)?.Close();
}
