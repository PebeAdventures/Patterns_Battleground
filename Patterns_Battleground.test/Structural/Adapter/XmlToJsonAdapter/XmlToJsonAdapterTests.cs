
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Adapter;
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Legacy;
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Services;
using Patterns_Battleground.test.Structural.Adapter.XmlToJsonAdapter.MockData;

namespace Patterns_Battleground.test.Structural.Adapter.XmlToJsonAdapter;

public class XmlToJsonAdapterTests
{
    [Fact]
    public void GetDataAsJson_WhenDataIsMerged_ShouldReturnCorrectJson()
    {
        // Arrange
        var customerDoc = XDocument.Parse(XmlAdapterTestData.CustomerXml);
        var orderDoc = XDocument.Parse(XmlAdapterTestData.OrderXml);
        
        // Defensive check: ensure that parsed XML contains a valid root element before merging
        Assert.NotNull(customerDoc.Root);
        Assert.NotNull(orderDoc.Root);

        var merger = new DataMerger();
        var unifiedXml = merger.Merge(customerDoc.Root, orderDoc.Root);
        var actualJson = Newtonsoft.Json.JsonConvert.SerializeXNode(unifiedXml, Newtonsoft.Json.Formatting.Indented);

        // Act
        var expected = JToken.Parse(XmlAdapterTestData.ExpectedMergedJson);
        var actual = JToken.Parse(actualJson);

        // Assert
        Assert.True(JToken.DeepEquals(expected, actual), "The JSON output does not match the expected structure.");
    }

    [Fact]
    public void DataMarger_Merge_ShouldReturnProperXmlStructure()
    {
        // Arrange
        var customerDoc = XElement.Parse(XmlAdapterTestData.CustomerXml);
        var orderDoc = XElement.Parse(XmlAdapterTestData.OrderXml);
        var merger = new DataMerger();

        // Act
        var mergedXmlData = merger.Merge(customerDoc, orderDoc);

        // Assert
        Assert.NotNull(mergedXmlData);
        Assert.Equal("MergedData", mergedXmlData.Name.LocalName);

        var customerElement = mergedXmlData.Element("Customer");
        var orderElement = mergedXmlData.Element("Order");

        Assert.NotNull(customerElement);
        Assert.NotNull(orderElement);

        Assert.Equal("Anna", customerElement?.Element("Name")?.Value);
        Assert.Equal("28", customerElement?.Element("Age")?.Value);

        Assert.Equal("123", orderElement?.Element("Id")?.Value);
        Assert.Equal("456.78", orderElement?.Element("Total")?.Value);
    }

    [Fact]
    public void DataMerger_Merge_ShouldThrowException_WhenInputIsNull()
    {
        // Arrange
        var merger = new DataMerger();

        XElement? customerElement = null;
        var orderElement = XElement.Parse(@"
            <Order>
                <Id>123</Id>
            </Order>");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => merger.Merge(customerElement, orderElement));
        Assert.Throws<ArgumentNullException>(() => merger.Merge(orderElement, null));
        Assert.Throws<ArgumentNullException>(() => merger.Merge(null, null));
    }
}
