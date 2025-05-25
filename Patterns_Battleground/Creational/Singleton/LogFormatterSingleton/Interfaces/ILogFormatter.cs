using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Enums;

namespace Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Interfaces
{
    public interface ILogFormatter
    {
        string Format(string message, LogPriority level = LogPriority.Info);
    }
}
