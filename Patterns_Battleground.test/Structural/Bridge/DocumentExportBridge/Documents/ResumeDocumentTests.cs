using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Abstractions;
using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations;
using Patterns_Battleground.test.Structural.Bridge.DocumentExportBridge.MockData;

namespace Patterns_Battleground.test.Structural.Bridge.DocumentExportBridge.Documents
{
    public class ResumeDocumentTests
    {
        
        [Fact]
        public void ResumeDocument_ExportWithPdfRenderer_ShouldReturnPdfFormattedContent()
        {
            // Arrange
            var renderer = new PdfRenderer();
            var document = new ResumeDocument(DocumentData.ResumeContent, renderer);
            var expected = $"[PDF Document]\n{DocumentData.ResumeContent}\n[/PDF Document]";

            // Act
            var result = document.Export();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ResumeDocument_ExportWithHtmlRenderer_ShouldReturnHtmlFormattedContent()
        {
            // Arrange
            var renderer = new HtmlRenderer();
            var document = new ResumeDocument(DocumentData.ResumeContent, renderer);
            var expected = $"<html><body>{DocumentData.ResumeContent}</body></html>";

            // Act
            var result = document.Export();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ResumeDocument_Ctor_WithNullRenderer_ShouldThrowArgumentNullException()
        {
            // Arrange
            IDocumentRenderer? renderer = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var _ = new ResumeDocument(DocumentData.ResumeContent, renderer!);
            });
        }
    }
}
