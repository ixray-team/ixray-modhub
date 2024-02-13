using Avalonia.Controls;

namespace IXRay.Hub.Avalonia.Helpers;

public static class ExceptionHelper
{
    public static void ThrowIfEmptyConstructorNotInDesignTime(string name)
    {
        if (!Design.IsDesignMode) {
            throw new InvalidOperationException($"Calling constructor of {name} class not in design-time!");
        }
    }
}
