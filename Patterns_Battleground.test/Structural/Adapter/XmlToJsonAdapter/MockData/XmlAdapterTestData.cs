namespace Patterns_Battleground.test.Structural.Adapter.XmlToJsonAdapter.MockData;

public class XmlAdapterTestData
{
    public static string CustomerXml => @"
        <Customer>
            <Name>Anna</Name>
            <Age>28</Age>
            <Email>anna@example.com</Email>
            <Address>
                <Street>Polna 7</Street>
                <City>Warszawa</City>
            </Address>
        </Customer>";

    public static string OrderXml => @"
        <Order>
            <Id>123</Id>
            <Total>456.78</Total>
            <Items>
                <Item>
                    <Name>Keyboard</Name>
                    <Quantity>1</Quantity>
                </Item>
                <Item>
                    <Name>Mouse</Name>
                    <Quantity>2</Quantity>
                </Item>
            </Items>
        </Order>";

    public static string ExpectedMergedJson => @"
    {
        'MergedData': {
            'Customer': {
                'Name': 'Anna',
                'Age': '28',
                'Email': 'anna@example.com',
                'Address': {
                    'Street': 'Polna 7',
                    'City': 'Warszawa'
                }
            },
            'Order': {
                'Id': '123',
                'Total': '456.78',
                'Items': {
                    'Item': [
                        {
                            'Name': 'Keyboard',
                            'Quantity': '1'
                        },
                        {
                            'Name': 'Mouse',
                            'Quantity': '2'
                        }
                    ]
                }
            }
        }
    }";

}
