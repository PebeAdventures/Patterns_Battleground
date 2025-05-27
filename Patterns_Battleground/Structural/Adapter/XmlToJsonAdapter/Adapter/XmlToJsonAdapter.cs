
using System.Xml.Linq;
using Newtonsoft.Json;
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Legacy;
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Services;

namespace Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Adapter
{
    public class XmlToJsonAdapter : IDataProvider
    {
        private readonly CustomerXmlService _customerService;
        private readonly OrderXmlService _orderService;
        private readonly DataMerger _merger;

        public XmlToJsonAdapter(CustomerXmlService customerService, OrderXmlService orderService, DataMerger merger)
        {
            _customerService = customerService;
            _orderService = orderService;
            _merger = merger;
        }

        public string GetDataAsJson()
        {
            var customerXml = _customerService.GetCustomerXml();
            var orderXml = _orderService.GetOrderXml();

            var unifiedXml = _merger.Merge(XElement.Parse(customerXml), XElement.Parse(orderXml));
            return JsonConvert.SerializeXNode(unifiedXml, Formatting.Indented);
        }
    }
}
