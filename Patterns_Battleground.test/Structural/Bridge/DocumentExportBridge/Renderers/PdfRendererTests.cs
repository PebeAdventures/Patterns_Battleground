using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations;

namespace Patterns_Battleground.test.Structural.Bridge.DocumentExportBridge.Renderers
{
    public class PdfRendererTests
    {
        [Fact]
        public void Render_WhenUsed_ShouldWrapContentInPdfTags()
        {
            // Arrange
            var content = "Sample content";
            var renderer = new PdfRenderer();
            var expected = "[PDF Document]\nSample content\n[/PDF Document]";

            // Act
            var result = renderer.Render(content);

            // Assert
            Assert.Equal(expected, result);
        }

    }
}
