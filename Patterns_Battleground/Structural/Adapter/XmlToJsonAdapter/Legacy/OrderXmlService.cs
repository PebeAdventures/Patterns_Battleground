namespace Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Legacy
{
    public class OrderXmlService
    {
        public string GetOrderXml()
        {
            return @"<Order><Id>123</Id><Total>456.78</Total></Order>";
        }
    }
}
