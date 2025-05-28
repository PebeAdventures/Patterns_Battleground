using Microsoft.AspNetCore.Components.RenderTree;
using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations;

namespace Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Abstractions
{
    public class InvoiceDocument : Document
    {
        private readonly string _content;

        public InvoiceDocument(string content, IDocumentRenderer renderer) : base(renderer)
        {
            _content = content;
        }

        public override string Export()
        {
            return renderer.Render(_content);
        }
    }
}
