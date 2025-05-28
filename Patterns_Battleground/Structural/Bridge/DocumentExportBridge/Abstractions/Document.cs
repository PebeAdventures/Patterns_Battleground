using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations;

namespace Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Abstractions
{
    public abstract class Document
    {
        protected readonly IDocumentRenderer renderer;

        protected Document(IDocumentRenderer renderer)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        public abstract string Export();
    }
}
