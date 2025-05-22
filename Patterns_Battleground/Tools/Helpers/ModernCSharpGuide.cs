namespace Patterns_Battleground.Tools.Helpers;

// Quick guide: Modern C# 10–12 syntax usage examples
// Use this file to reference idiomatic, modern features in current C# projects.

public static class ModernCSharpQuickGuide
{
    // C# 10: File-scoped namespace
    public static void ListLiteralsAndVar()
    {
        // C# 12: List literals (collection expressions)
        // Requires .NET 8 or higher
        List<string> fruits = ["Apple", "Banana", "Cherry"];

        // C# 9+: Target-typed new with var
        var numbers = new List<int> { 1, 2, 3 };

        // C# 10: Improved lambda syntax
        var upper = (string s) => s.ToUpper();
        Console.WriteLine(upper("hello"));
    }

    // C# 9: Record types with init-only setters
    public record Person(string FirstName, string LastName)
    {
        public string FullName => $"{FirstName} {LastName}";
    }

    // C# 10+: Global using (usually declared in a separate GlobalUsings.cs file)
    // Example usage:
    // In GlobalUsings.cs:
    // global using System.Text.Json;
    // Then in code, JsonSerializer can be used directly without explicit using

    // C# 11: Raw string literals (multi-line JSON, SQL, etc.)
    // Requires .NET 7 or higher
    public static string GetSampleJson() =>
        """
        {
          "name": "example",
          "version": 1
        }
        """;

    // C# 11: Required properties in classes (requires .NET 7+)
    public class Config
    {
        public required string Host { get; init; }
        public required int Port { get; init; }
    }

    // C# 12: Primary constructors in classes (preview feature)
    // Requires .NET 8+ and LangVersion=preview
    // Example:
    // public class Example(string name)
    // {
    //     public string Name { get; } = name;
    // }

    // C# 10: Pattern matching with switch expressions
    public static string CheckType(object input) => input switch
    {
        int i => $"int: {i}",
        string s => $"string: {s}",
        null => "null",
        _ => "unknown"
    };
}
