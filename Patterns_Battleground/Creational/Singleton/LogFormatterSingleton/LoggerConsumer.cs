using Microsoft.Extensions.Logging;
using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Core;
using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Enums;


namespace Patterns_Battleground.Creational.Singleton.LogFormatterSingleton;

public static class LoggerConsumer
{
    public static void Run()
    {
        var logger = LogFormatter.Instance;

        var log1 = logger.Format("Application started.", LogPriority.Info);
        var log2 = logger.Format("Fetching user data...", LogPriority.Debug);
        var log3 = logger.Format("User not found!", LogPriority.Warning);
        var log4 = logger.Format("Unhandled exception occurred.", LogPriority.Error);
        Console.WriteLine(log1);
        Console.WriteLine(log2);
        Console.WriteLine(log3);
        Console.WriteLine(log4);
    }
}
