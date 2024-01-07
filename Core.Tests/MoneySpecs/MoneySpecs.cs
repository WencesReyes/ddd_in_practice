using Core.ValueObjects;
using FluentAssertions;
using static Core.ValueObjects.Money;

namespace Core.Tests.MoneySpecs
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_of_two_money_instances_should_be_correct()
        {
            var money1 = new Money(1, 1, 0, 0, 0, 0);
            var money2 = TwentyDollar;

            var sum = money1 + money2;

            sum.OneCentCount.Should().Be(1);
            sum.TenCentCount.Should().Be(1);
            sum.QuarterCount.Should().Be(0);
            sum.OneDollarCount.Should().Be(0);
            sum.FiveDollarCount.Should().Be(0);
            sum.TwentyDollarCount.Should().Be(1);
        }

        [Fact]
        public void Subtraction_of_two_money_instances_should_be_correct()
        {
            var money1 = new Money(1, 1, 0, 0, 0, 1);
            var money2 = new Money(1, 1, 0, 0, 0, 0);

            var subtraction = money1 - money2;

            subtraction.OneCentCount.Should().Be(0);
            subtraction.TenCentCount.Should().Be(0);
            subtraction.QuarterCount.Should().Be(0);
            subtraction.OneDollarCount.Should().Be(0);
            subtraction.FiveDollarCount.Should().Be(0);
            subtraction.TwentyDollarCount.Should().Be(1);
        }

        [Theory]
        [InlineData(new object[] { 1, 1, 0, 0, 0, 1, 20.11 })]
        [InlineData(new object[] { 0, 0, 0, 1, 1, 0, 6 })]
        public void money_amount_should_be_correct(
            int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            decimal expected)
        {
            var money1 = new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            money1.Amount.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(MoneyTheoryData))]
        public void Two_money_instances_should_be_equal(
            int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            var money1 = new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);
            var money2 = new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            money1.Should().Be(money2);
        }

        [Fact]
        public void Two_money_instances_should_be_different()
        {
            var money1 = new Money(1, 1, 0, 0, 0, 0);
            var money2 = Dollar;

            money1.Should().NotBe(money2);
            money1.GetHashCode().Should().NotBe(money2.GetHashCode());
        }

        [Theory]
        [InlineData(new object[] { 1, 2, 3, 4, 5, -6 })]
        [InlineData(new object[] { 1, 2, -3, 4, 5, 6 })]
        public void Money_instance_with_negative_properties_should_throw_an_exception(
            int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            var money = () => new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            money.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(new object[] { 1, 2, 0, 0, 0, 0, '¢' })]
        [InlineData(new object[] { 1, 2, 1, 4, 5, 1, '$' })]
        public void To_string_method_in_money_instance_should_start_with_correct_symbols(
            int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            char expectedSymbol)
        {
            var money = new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            var moneySymbol = money.ToString()[0];

            moneySymbol.Should().Be(expectedSymbol);
        }
    }
}