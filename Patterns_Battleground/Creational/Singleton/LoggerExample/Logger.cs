namespace Patterns_Battleground.Creational.Singleton.LoggerExample;

public sealed class Logger
{
    private static readonly Logger _instance = new();
    public static Logger Instance => _instance;

    private Logger() { }

    public void Log(string message, LogLevel level = LogLevel.Info)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss");
        Console.WriteLine($"[{timestamp}] [{level}] {message}");
    }
}
