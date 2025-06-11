using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;
using Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator.Mock;

namespace Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator;

public class VatDecoratorTests
{
    [Fact]
    public void CalculatePrice_WhenCalled_ShouldAddVatToBasePrice()
    {
        //Arrange
        var baseProduct = TestProducts.Console1;
        var vatRate = 0.23m;
        var expectedAmount = baseProduct.BasePrice * (1 + vatRate);
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new VatDecorator(calculator, vatRate);

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedAmount, decoratedPrice.Amount);
    }

    [Fact]
    public void CalculatePrice_WhenCalled_ShouldNotSetLabel()
    {
        //Arrange
        var baseProduct = TestProducts.Console1;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new VatDecorator(calculator, 0.23m);

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Null(decoratedPrice.Label);
    }

    [Fact]
    public void CalculatePrice_WhenCalledAfterLabelDecorator_ShouldNotOverrideLabel()
    {
        //Arrange
        var baseProduct = TestProducts.Console1;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new CustomLabelDecorator(calculator, "Custom Label");
        calculator = new VatDecorator(calculator, 0.23m);

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal("Custom Label", decoratedPrice.Label);
    }


    [Fact]
    public void Constructor_WhenVatRateIsNegative_ShouldThrowArgumentOutOfRangeException()
    {
        //Arrange
        IPriceCalculator calculator = new BasePriceCalculator();
        var vatRate = -0.15m;

        //Act // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            _ = new VatDecorator(calculator, vatRate);
        });
    }
}
