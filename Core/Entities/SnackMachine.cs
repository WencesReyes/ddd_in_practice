using Core.ValueObjects;
using static Core.ValueObjects.Money;

namespace Core.Entities
{
    public class SnackMachine : Entity<long>
    {
        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = [Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar];

            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException("Must insert one coin or note at a time");

            MoneyInTransaction += money;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;

            MoneyInTransaction = None;
        }
    }
}
