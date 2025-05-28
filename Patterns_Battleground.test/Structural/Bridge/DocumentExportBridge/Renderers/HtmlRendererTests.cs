using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations;

namespace Patterns_Battleground.test.Structural.Bridge.DocumentExportBridge.Renderers
{
    public class HtmlRendererTests
    {

        [Fact]
        public void Render_WhenUsed_ShouldWrapContentInHtmlTags()
        {
            // Arrange
            var content = "Sample content";
            var renderer = new HtmlRenderer();
            var expected = $"<html><body>{content}</body></html>";

            // Act
            var result = renderer.Render(content);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
