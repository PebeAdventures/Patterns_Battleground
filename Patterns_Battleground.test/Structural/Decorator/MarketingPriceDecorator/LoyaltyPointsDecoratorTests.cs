using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json.Bson;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;
using Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator.Mock;

namespace Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator;

public class LoyaltyPointsDecoratorTests
{
    [Fact]
    public void CalculatePrice_WhenCalled_ShouldCorrectlyAddPriceEqualityInPoints()
    {
        //Arrange
        var baseProduct = TestProducts.Oven1;
        var loyaltyPointsRate = 10;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new LoyaltyPointsDecorator(calculator, loyaltyPointsRate);
        var expectedPrice = new Price(baseProduct.BasePrice, $"{(baseProduct.BasePrice*loyaltyPointsRate):0} pkt.");
        
        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
    }

    [Fact]
    public void CalculatePrice_WhenCalledAfterOtherLabelDecorator_ShouldOverridePriceLabel()
    {
        //Arrange
        var baseProduct = TestProducts.Oven1;
        var loyaltyPointsRate = 10;
        IPriceCalculator calculator = new BasePriceCalculator();
        calculator = new CustomLabelDecorator(calculator, "Custom Label");
        calculator = new LoyaltyPointsDecorator(calculator, loyaltyPointsRate);
        var expectedPrice = new Price(baseProduct.BasePrice, $"{(baseProduct.BasePrice * loyaltyPointsRate):0} pkt.");

        //Act
        var decoratedPrice = calculator.CalculatePrice(baseProduct);

        //Assert
        Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
    }

    [Fact]
    public void CalculatePrice_WhenCalledWithZeroPointsRate_ShouldThrowOutOfRangeException()
    {
        //Arrange
        var loyaltyPointsRate = 0;
        IPriceCalculator calculator = new BasePriceCalculator();

        //Act // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var _ = new LoyaltyPointsDecorator(calculator, loyaltyPointsRate);
            });
    }

    [Fact]
    public void CalculatePrice_WhenCalledWithNegativePointsRate_ShouldThrowOutOfRangeException()
    {
        //Arrange
        var loyaltyPointsRate = -10;
        IPriceCalculator calculator = new BasePriceCalculator();

        //Act // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var _ = new LoyaltyPointsDecorator(calculator, loyaltyPointsRate);
        });
    }

}
