using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Enums;
using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Interfaces;

namespace Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Core;

public sealed class LogFormatter : ILogFormatter
{
    private static readonly Lazy<LogFormatter> _instance = new(() => new LogFormatter());
    public static LogFormatter Instance => _instance.Value;

    private LogFormatter(){}
    public string Format(string message, LogPriority level = LogPriority.Info)
    {
       var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
       return $"[{timestamp}] [{level}] {message}";
    }
}
