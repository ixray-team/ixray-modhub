namespace IXRay.Hub.Avalonia.Helpers;

public static class SystemInfoPrinter
{
    public static void PrintOsInfo(Serilog.ILogger logger)
    {
        logger.Information("OS: {OSVersion}", Environment.OSVersion);
        logger.Information("Processor architecture: {Architecture}",
            Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
        logger.Information("User / PC: {UserName} / {MachineName}", Environment.UserName,
            Environment.MachineName);
        logger.Information("System directory: {SystemDirectory} {NewLine}", Environment.SystemDirectory, Environment.NewLine);
        logger.Information(".NET: {NETVersion}", Environment.Version);
        logger.Information("ProcessId: {ProcessId}", Environment.ProcessId);
        logger.Information("Processor count: {ProcessorCount}", Environment.ProcessorCount);
        logger.Information("Process path: {ProcessPath}", Environment.ProcessPath);
        logger.Information("Current directory: {CurrentDirectory}", Environment.CurrentDirectory);
        logger.Information("Application directory: {BaseDirectory} {NewLine}", AppDomain.CurrentDomain.BaseDirectory, Environment.NewLine);
    }
}
