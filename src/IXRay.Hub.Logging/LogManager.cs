using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace IXRay.Hub.Avalonia.Logging;

public static class LogManager
{
    private static readonly string _outputTemplate = "[{Level:u3}] {Timestamp:HH:mm:ss} {Message:lj}{NewLine}{Exception}";

    public static ILogger CreateLoggerDefault(string logPath) 
        => new LoggerConfiguration()
            .WriteTo.File(logPath, outputTemplate: _outputTemplate, rollingInterval: RollingInterval.Day)
            .WriteTo.Debug(outputTemplate: _outputTemplate)
            .CreateLogger();

    public static ILogger CreateLoggerDebug()
        => new LoggerConfiguration()
            .WriteTo.Debug(outputTemplate: _outputTemplate)
            .CreateLogger();

    public static ILogger CreateLoggeConsole()
        => new LoggerConfiguration()
            .WriteTo.Debug(outputTemplate: _outputTemplate)
            .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: _outputTemplate)
            .CreateLogger();
}
