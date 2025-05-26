
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Adapter;
using Patterns_Battleground.Structural.Adapter.XmlToJsonAdapter.Legacy;

namespace Patterns_Battleground.test.Structural.Adapter.XmlToJsonAdapterTests;

public class XmlToJsonAdapterTests
{
    [Fact]
    public void GetDataAsJson_ShouldConvertXmlToJsonCorrectly()
    {
        // Arrange
        var legacy = new LegacyXmlService();
        var adapter = new XmlToJsonAdapter(legacy);

        // Act
        string json = adapter.GetDataAsJson();

        // Assert
        Assert.Contains("\"Name\": \"Jan\"", json);
        Assert.Contains("\"Age\": \"5\"", json);
    }
}
