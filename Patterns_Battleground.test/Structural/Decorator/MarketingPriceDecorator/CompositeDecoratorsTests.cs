using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;
using Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator.Mock;

namespace Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator;

public class CompositeDecoratorsTests
{
    
    [Fact]
    public void CalculatePrice_WithMonthlyAndVat_ShouldReturnCorrectValue()
    {
        //Arrange
        var baseProduct = TestProducts.Toy2;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new VatDecorator(calculator, 0.23m);
        calculator = new MonthlyInstallmentDecorator(calculator,24);
        var expectedPrice = new Price(12.3m, "0,51 zł/m przez 24 mc.");

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
        Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
    }

    [Fact]
    public void CalculatePrice_WithMonthlyAndCustomLabel_ShouldSuccesfullyOverrideLabel()
    {
        //Arrange
        var baseProduct = TestProducts.Toy2;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new MonthlyInstallmentDecorator(calculator, 24);
        calculator = new CustomLabelDecorator(calculator, "testLabel");
        var expectedPrice = new Price(baseProduct.BasePrice, "testLabel");

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
        Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
    }

    [Fact]
    public void CalculatePrice_WithVatThenLoyalty_ShouldApplyPointsBeforeTax()
    {
        //Arrange
        var baseProduct = TestProducts.Toy2;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new VatDecorator(calculator, 0.23m);
        calculator = new LoyaltyPointsDecorator(calculator, 100);
        var expectedPrice = new Price(12.3m, "1230 pkt.");

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
        Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
    }

    [Fact]
    public void CalculatePrice_WithLoyaltyThenVat_ShouldApplyPointsBeforeTax()
    {
        //Arrange
        var baseProduct = TestProducts.Toy2;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new LoyaltyPointsDecorator(calculator, 100);
        calculator = new VatDecorator(calculator, 0.23m);
        var expectedPrice = new Price(12.3m, "1000 pkt.");

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
        Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
    }

    [Fact]
    public void CalculatePrice_WithVatThenLoyaltyThenMonthlyInstallmentThenCustomDecorators_ShouldReturnCorrectValue()
    {
        //Arrange
        decimal vatValue = 0.23m;
        var baseProduct = TestProducts.Toy2;
        IPriceCalculator calculator = new BasePriceCalculator();
        // base+ 23% vat = 12.23
        calculator = new VatDecorator(calculator, vatValue);
        // add Label Based on actual price(12.23)
        calculator = new LoyaltyPointsDecorator(calculator, 100);
        // calculate installments based on actual price.
        calculator = new MonthlyInstallmentDecorator(calculator, 10);
        // ovverride label with custom label
        calculator = new CustomLabelDecorator(calculator, "Custom Label");
        var expectedPrice = new Price((baseProduct.BasePrice*(1+ vatValue)), "Custom Label");

        //Act
        var calculatedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedPrice.Amount, calculatedPrice.Amount);
        Assert.Equal(expectedPrice.Label, calculatedPrice.Label);
    }
}
