using System.Text;

namespace IXRay.Hub.Avalonia.Helpers;

public static class InformationPrinter
{
    public static string GetOsInfo()
    {
        var builder = new StringBuilder();
        builder.Append("Basic information about operating system").AppendLine();
        builder.AppendFormat("OS version: {0}", Environment.OSVersion).AppendLine();
        builder.AppendFormat("Processor architecture: {0}",
            Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")).AppendLine();
        builder.AppendFormat("Processor count: {0}", Environment.ProcessorCount).AppendLine();
        builder.AppendFormat("User / PC: {0} / {1}", Environment.UserName,
            Environment.MachineName).AppendLine();
        builder.AppendFormat("System directory: {0}", Environment.SystemDirectory).AppendLine();

        return builder.ToString();
    }

    public static string GetApplicationInfo()
    {
        var builder = new StringBuilder();
        builder.Append("Basic application information").AppendLine();
        builder.AppendFormat(".NET: {0}", Environment.Version).AppendLine();
        builder.AppendFormat("ProcessId: {0}", Environment.ProcessId).AppendLine();
        builder.AppendFormat("Process path: {0}", Environment.ProcessPath).AppendLine();
        builder.AppendFormat("Current directory: {0}", Environment.CurrentDirectory).AppendLine();
        builder.AppendFormat("Application directory: {0}", AppDomain.CurrentDomain.BaseDirectory).AppendLine();
        builder.AppendFormat("Runtime architecture: {0}-bit", IntPtr.Size * 8).AppendLine();

        var commandLineArgs = Environment.GetCommandLineArgs();
        if (commandLineArgs.Length > 1) {
            builder.AppendLine("Command line arguments:");
            foreach (var arg in commandLineArgs) {
                builder.AppendLine(arg);
            }
        }
        
        return builder.ToString();
    }
}
