using System.Xml.Linq;

namespace Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Services
{
    public class DataMerger
    {

        public XElement Merge(XElement customerXml, XElement orderXml)
        {
            if (customerXml == null || orderXml == null)
                throw new ArgumentNullException("Input XML cannot be null");

            var merged = new XElement("MergedData",
                new XElement("Customer", customerXml.Elements()),
                new XElement("Order", orderXml.Elements())
            );
            return merged;
        }
    }
}
