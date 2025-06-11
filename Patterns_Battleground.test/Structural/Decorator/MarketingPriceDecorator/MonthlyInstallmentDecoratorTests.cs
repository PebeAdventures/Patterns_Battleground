using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;
using Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator.Mock;

namespace Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator
{
    public class MonthlyInstallmentDecoratorTests
    {
        [Fact]
        public void CalculatePrice_WhenCalled_ShouldCorrectlyAddMonthlyInstallment()
        {
            //Arrange
            var baseProduct = TestProducts.Console2;
            var numberOfInstallments = 10;
            var installmentAmount = baseProduct.BasePrice / numberOfInstallments;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new MonthlyInstallmentDecorator(calculator, numberOfInstallments);
            var expectedPrice = new Price(baseProduct.BasePrice, $"{installmentAmount:0.00} zł/m przez {numberOfInstallments} mc.");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
        }

        [Fact]
        public void CalculatePrice_WhenCalledWithCustomInterestRate_ShouldCorrectlyAddMonthlyInstallment()
        {
            //Arrange
            var baseProduct = TestProducts.Console2;
            var numberOfInstallments = 10;
            var interestRate = 0.5m;
            // calculate total price with interest rate
            var totalPrice = baseProduct.BasePrice * (1 + interestRate);
            // calculate installment amount based on total prie with interest rate included
            var installmentAmount = totalPrice / numberOfInstallments;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new MonthlyInstallmentDecorator(calculator, numberOfInstallments, interestRate);
            var expectedPrice = new Price(baseProduct.BasePrice, $"{installmentAmount:0.00} zł/m przez {numberOfInstallments} mc.");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
        }

        [Fact]
        public void CalculatePrice_WhenCalledAfterOtherDecorator_ShouldCorrectlyOverrideLabel()
        {
            //Arrange
            var baseProduct = TestProducts.Console2;
            var numberOfInstallments = 10;
            var installmentAmount = baseProduct.BasePrice / numberOfInstallments;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new CustomLabelDecorator(calculator, "Custom Label");
            calculator = new MonthlyInstallmentDecorator(calculator, numberOfInstallments);
            var expectedPrice = new Price(baseProduct.BasePrice, $"{installmentAmount:0.00} zł/m przez {numberOfInstallments} mc.");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
        }
        [Fact]
        public void CalculatePrice_WhenCalledWithZeroInstallmentNumber_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var baseProduct = TestProducts.Console2;
            var numberOfInstallments = 0;
            IPriceCalculator calculator = new BasePriceCalculator();

            //Act //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new MonthlyInstallmentDecorator(calculator, numberOfInstallments);
            });
        }

        [Fact]
        public void CalculatePrice_WhenCalledWithNegativeInstallmentAmount_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var baseProduct = TestProducts.Console2;
            var numberOfInstallments = -5;
            var installmentAmount = baseProduct.BasePrice / numberOfInstallments;
            IPriceCalculator calculator = new BasePriceCalculator();

            //Act //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new MonthlyInstallmentDecorator(calculator, numberOfInstallments);
            });
        }


        [Fact]
        public void CalculatePrice_WhenCalledWithNegativeInterestRate_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var baseProduct = TestProducts.Console2;
            var numberOfInstallments = 10;
            var interestRate = -5;
            IPriceCalculator calculator = new BasePriceCalculator();

            //Act //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new MonthlyInstallmentDecorator(calculator, numberOfInstallments, interestRate);
            });
        }

    }
}
