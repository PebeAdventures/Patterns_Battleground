namespace Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations
{
    public class PdfRenderer : IDocumentRenderer
    {
        public string Render(string content)
        {
            return $"[PDF Document]{content}[/PDF Document]";
        }
    }
}
