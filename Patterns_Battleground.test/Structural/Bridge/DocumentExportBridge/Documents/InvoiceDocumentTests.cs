
using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Abstractions;
using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations;
using Patterns_Battleground.test.Structural.Bridge.DocumentExportBridge.MockData;

namespace Patterns_Battleground.test.Structural.Bridge.DocumentExportBridge.Documents
{
    public class InvoiceDocumentTests
    {
        [Fact]
        public void InvoiceDocument_ExportWithPdfRenderer_ShouldReturnPdfFormattedContent()
        {
            // Arrange
            var renderer = new PdfRenderer();
            var document = new InvoiceDocument(DocumentData.InvoiceContent, renderer);
            var expected = $"[PDF Document]{DocumentData.InvoiceContent}[/PDF Document]";

            // Act
            var result = document.Export();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void InvoiceDocument_WhenUsingHtmlRenderer_ShouldReturnHtmlFormattedContent()
        {
            // Arrange
            var renderer = new HtmlRenderer();
            var document = new InvoiceDocument(DocumentData.InvoiceContent, renderer);
            var expected = $"<html><body>{DocumentData.InvoiceContent}</body></html>";

            // Act
            var result = document.Export();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void InvoiceDocument_Ctor_WithNullRenderer_ShouldThrowArgumentNullException()
        {
            // Arrange
            IDocumentRenderer? renderer = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var _ = new ResumeDocument(DocumentData.InvoiceContent, renderer!);
            });
        }
    }
}
