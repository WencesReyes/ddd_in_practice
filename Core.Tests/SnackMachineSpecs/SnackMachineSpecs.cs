using Core.Entities;
using FluentAssertions;
using static Core.ValueObjects.Money;

namespace Core.Tests.SnackMachineSpecs
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_money_from_snack_machine_money_in_transaction_should_be_cero()
        {
            var snackMachine = new SnackMachine();

            var money = TwentyDollar;

            snackMachine.InsertMoney(money);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0);
        }

        [Fact]
        public void Inserted_money_goes_to_snack_machine_in_money_in_transaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(FiveDollar);
            snackMachine.InsertMoney(Quarter);

            snackMachine.MoneyInTransaction.Amount.Should().Be(5.25m);
        }

        [Fact]
        public void Inserting_more_than_one_coin_or_note_should_throw_an_exception()
        {
            var snackMachine = new SnackMachine();
            var money = Dollar + Cent;

            Action action = () => snackMachine.InsertMoney(money);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Money_in_transaction_goes_to_money_inside_of_snack_machine()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(TwentyDollar);
            snackMachine.InsertMoney(TenCent);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0);
            snackMachine.MoneyInside.Amount.Should().Be(20.10m);
        }
    }
}
