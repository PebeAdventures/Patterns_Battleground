using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Core;
using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Enums;
using Patterns_Battleground.Creational.Singleton.LogFormatterSingleton.Interfaces;
namespace Patterns_Battleground.test.Creational.Singleton.LogFormatterSingleton
{
    public class LogFormatterTests
    {

        private static readonly ILogFormatter _logger = LogFormatter.Instance;
        [Fact]
        public void LogFormatter_WhenCreated_ShouldHaveSingleInstance()
        {
            // Arrange & Act
            var logger1 = LogFormatter.Instance;
            var logger2 = LogFormatter.Instance;
            // Assert
            Assert.Same(logger1, logger2);
        }

        [Fact]
        public void LogFormatter_WhenAccessedViaInterface_ShouldReturnSameInstance()
        {
            // Arrange & Act
            ILogFormatter logger1 = _logger;
            ILogFormatter logger2 = LogFormatter.Instance;

            // Assert
            Assert.Same(logger1, logger2);
        }

        [Fact]
        public void LogFormatter_WhenFormatCalled_ShouldReturnCorrectlyFormatedString()
        {
            // Arrange
            var message = "Test message";
            //var expectedPrefix = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [Info] {message}";

            // Act
            var result = _logger.Format(message, LogPriority.Info);

            // Assert
            Assert.StartsWith("[", result);
            Assert.Contains("Info", result);
            Assert.EndsWith(message, result);
        }

        [Fact]
        public void LogFormatter_WhenInitializedOnMultipleCores_ShouldReturnSameInstanceAcrossThreads()
        {
            // Arrange
            var instances = new List<ILogFormatter>();

            // Act
            Parallel.For(0, 10, _ =>
            {
                instances.Add(LogFormatter.Instance);
            });
            var first = instances.First();

            // Assert
            Assert.All(instances, inst => Assert.Same(first, inst));
        }
    }
}
