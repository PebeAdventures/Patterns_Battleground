
using System.Xml.Linq;
using Newtonsoft.Json;
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Legacy;

namespace Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Adapter
{
    public class XmlToJsonAdapter : IDataProvider
    {
        public readonly LegacyXmlService legacyXmlService;

        public XmlToJsonAdapter(LegacyXmlService legacyXmlService)
        {
            this.legacyXmlService = legacyXmlService;
        }

        public string GetDataAsJson()
        {
            string xml = legacyXmlService.GetDataAsXml();
            var xDoc = XDocument.Parse(xml);
            string json = JsonConvert.SerializeXNode(xDoc, Formatting.Indented);
            return json;
        }
    }
}
