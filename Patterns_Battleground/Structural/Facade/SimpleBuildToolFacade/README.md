# 🧱 BuildToolFacade – Facade Design Pattern in C#


A clean and testable implementation of the **Facade design pattern** in C#. Built with a realistic scenario: automating a software build-test-package pipeline.

> 💡 This project is part of the **Patterns Battleground** series – a portfolio dedicated to mastering design patterns in C#.

---

## 📘 What is the Facade Pattern?

**Facade** is a structural design pattern that provides a simplified interface to a set of interfaces in a subsystem. It hides internal complexity and exposes only what is necessary.

> 📚 Learn more on [Refactoring.Guru](https://refactoring.guru/design-patterns/facade)

---

## 🧩 Scenario

This project simulates a software pipeline. Instead of calling individual components like `dotnet build`, `dotnet test`, or custom packagers manually, the `BuildToolFacade` provides a **single entry point** for common operations.

---

## 🗂️ Project Structure

```
SimpleBuildToolFacade/
├── Core/                 # Interfaces and Facade
│   ├── IBuilder.cs
│   ├── ITester.cs
│   ├── IPackager.cs
│   └── BuildToolFacade.cs
├── Components/           # Simulated implementations
│   ├── DotnetBuilder.cs
│   ├── XUnitTester.cs
│   └── ZipPackager.cs
├── Tests/                # Unit tests with xUnit
│   ├── BuildToolFacadeTests.cs
│   └── Mock/
│       ├── FakeBuilder.cs
│       ├── FakeTester.cs
│       ├── FakePackager.cs
│       └── TestCallTracker.cs

```

---

## ✅ Features

- 📦 Clear separation of concerns via interfaces
- 🧪 100% unit-testable using fakes (no real build actions)
- 🔄 Covers both *delegation* and *execution order*
- 💡 Designed to show how Facade simplifies orchestration

---



## 🧪 Sample Test – Verifying Execution Order

```csharp
[Fact]
public void BuildTestAndPackageSolution_WhenCalled_ShouldRunInCorrectOrder()
{
    _facade.BuildTestAndPackageSolution();
    Assert.Equal(new[] { "build", "test", "package" }, _callTracker.Calls);
}
```

---

## 📚 Learn More

- [Design Patterns in C# – Full Guide (refactoring.guru)](https://refactoring.guru/design-patterns/csharp)
- [xUnit Documentation](https://xunit.net/)
- [Microsoft Docs – Dependency Injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

---

## 🧠 Author

**Piotr Bujak**  
This project is part of the *Patterns Battleground* portfolio – a step-by-step journey through design patterns in clean, testable C#.

---

## 🛡️ License

This project is licensed under the [MIT License](LICENSE).