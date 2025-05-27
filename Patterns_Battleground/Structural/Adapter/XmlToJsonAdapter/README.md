# Adapter Pattern: XML to JSON

## 🎯 Purpose

This example demonstrates the **Adapter structural design pattern**, which allows the integration of an **incompatible data source** by adapting its interface to one expected by the client.

In this scenario:
- The application expects data in **JSON** format.
- Two legacy services provide **XML** data:
  - `CustomerXmlService`
  - `OrderXmlService`

The adapter:
- Collects data from both sources,
- Merges them into a unified XML structure,
- Converts the result to JSON,
- Exposes a **single interface (`IDataProvider`)** that the client can work with.

## 🧱 Class Structure

```
Adapter/
├── IDataProvider.cs                  ← interface expected by the client
├── XmlToJsonAdapter.cs              ← the main adapter
Legacy/
├── CustomerXmlService.cs            ← legacy XML source 1
├── OrderXmlService.cs               ← legacy XML source 2
Services/
├── DataMerger.cs                    ← helper class to merge XML data
Tests/
├── XmlToJsonAdapterTests.cs        ← adapter tests (full JSON verification) & unit tests for the helper class
MockData/
├── XmlAdapterTestData.cs            ← sample XML/JSON test data
```

## 🧪 Test Coverage

| Test Name                                        | Purpose                                                                                  |
|--------------------------------------------------|------------------------------------------------------------------------------------------|
| ✅ `GetDataAsJson_WhenDataIsMerged_ShouldReturnCorrectJson`      | Integration test – verifies final JSON structure                         |
| ✅ `DataMerger_Merge_ShouldReturnProperXmlStructure`             | Unit test – ensures correct merging of two `XElement`s                   |
| ✅ `DataMerger_Merge_ShouldThrowException_WhenInputIsNull`       | Defensive test – throws `ArgumentNullException` on bad input             |
            |

## 📌 Key Techniques

- The adapter implements `IDataProvider` to isolate the integration logic.
- `DataMerger` is separated to honor **SRP (Single Responsibility Principle)**.
- `MockData` provides reusable XML/JSON samples to ensure clean and consistent tests.
- JSON comparisons use `JToken.DeepEquals` to verify **structure**, not just string content.

## 💡 Possible Extensions

- XML schema validation before merging,
- Supporting multiple versions of XML input (e.g., `v1`, `v2`),
- Strategy pattern to dynamically select an adapter implementation,
- Switching from `Newtonsoft.Json` to `System.Text.Json`.

## ✅ What This Example Demonstrates

- Practical application of the **Adapter** pattern,
- Clean **separation of responsibilities** between components,
- Realistic unit + integration test structure,
- A well-isolated design that allows external system integration without modifying legacy code.