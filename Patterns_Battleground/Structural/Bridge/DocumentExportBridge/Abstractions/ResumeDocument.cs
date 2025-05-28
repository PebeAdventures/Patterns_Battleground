using Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations;

namespace Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Abstractions
{
    public class ResumeDocument : Document
    {
        private readonly string _content;
        public ResumeDocument(string content, IDocumentRenderer renderer) : base(renderer)
        {
            _content = content;
        }

        public override string Export()
        {
            return renderer.Render(_content);
        }
    }
}
