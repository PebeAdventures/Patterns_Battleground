namespace Patterns_Battleground.Creational.Singleton.LoggerExample;

public static class LoggerConsumer
{
    public static void Run()
    {
        Logger.Instance.Log("App starting...", LogLevel.Info);
        Logger.Instance.Log("Something happened.", LogLevel.Debug);
        Logger.Instance.Log("Something went wrong!", LogLevel.Error);
    }
}
