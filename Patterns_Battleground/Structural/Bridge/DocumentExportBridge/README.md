# 🧩 Bridge Pattern – Document Export Example

## 🧠 What is the Bridge Pattern?

The Bridge pattern decouples an abstraction from its implementation so that the two can vary independently.

In this example:

- **Abstraction**: Different types of documents (e.g., Invoice, Resume)
- **Implementation**: Different output formats (e.g., PDF, HTML)

This separation allows you to **add new document types or formats** without modifying existing code.

---

## 📦 Folder Structure

```
Structural/
└── Bridge/
    └── DocumentExportBridge/
        ├── Abstractions/
        │   ├── Document.cs
        │   ├── InvoiceDocument.cs
        │   └── ResumeDocument.cs
        │
        ├── Implementations/
        │   ├── HtmlRenderer.cs
        │   ├── IDocumentRenderer.cs
        │   └── PdfRenderer.cs
        │
        └── README.md

```

---

## 📄 Pattern in Action

```csharp
var renderer = new PdfRenderer();
var document = new InvoiceDocument("Invoice content", renderer);
Console.WriteLine(document.Export());
// Output:
// [PDF Document]
// Invoice content
// [/PDF Document]
```

Switching renderer:

```csharp
var htmlRenderer = new HtmlRenderer();
var document = new ResumeDocument("Resume content", htmlRenderer);
Console.WriteLine(document.Export());
// Output:
// <html><body>Resume content</body></html>
```

---

## ✅ Benefits of Bridge

- **Open/Closed Principle**: Add new formats or documents without modifying core logic.
- **Separation of Concerns**: Document content is separated from rendering logic.
- **Scalability**: Add more combinations without exploding class count.

---

## 🧪 Tests

All components are thoroughly tested:

- Export flow for each document/renderer pair.
- Independent renderer formatting logic.
- Defensive checks for null renderers in constructors.

Test naming convention: `Class_WhenCondition_ShouldResult`, e.g.:  
`InvoiceDocument_ExportWithHtmlRenderer_ShouldReturnHtmlFormattedContent`

---


Inspired by [Bridge Pattern @ Refactoring.Guru](https://refactoring.guru/design-patterns/bridge)