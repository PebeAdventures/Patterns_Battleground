namespace Patterns_Battleground.Structural.Bridge.DocumentExportBridge.Implementations
{
    public class HtmlRenderer : IDocumentRenderer
    {
        public string Render(string content)
        {
            return $"<html><body>{content}</body></html>";
        }
    }
}