namespace Core.ValueObjects
{
    public class Money : ValueObject<Money>
    {
        public static readonly Money None = new(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new(0, 0, 0, 0, 0, 1);
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }
        public decimal Amount => OneCentCount * 0.01m
            + TenCentCount * 0.1m
            + QuarterCount * 0.25m
            + OneDollarCount
            + FiveDollarCount * 5
            + TwentyDollarCount * 20;

        private Money() { }


        public Money(
            int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount
            )
        {
            var anyParameterIsNegative =
                oneCentCount < 0
                || tenCentCount < 0
                || quaterCount < 0
                || oneDollarCount < 0
                || fiveDollarCount < 0
                || twentyDollarCount < 0;

            if (anyParameterIsNegative)
                throw new ArgumentException("Negative number is not allowed");


            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quaterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator +(Money left, Money right) 
        {
            Money sum = new Money(
                left.OneCentCount + right.OneCentCount,
                left.TenCentCount + right.TenCentCount,
                left.QuarterCount + right.QuarterCount,
                left.OneDollarCount + right.OneDollarCount,
                left.FiveDollarCount + right.FiveDollarCount,
                left.TwentyDollarCount + right.TwentyDollarCount
                );

            return sum;
        }

        public static Money operator -(Money left, Money right)
        {
            Money subtraction = new Money(
                left.OneCentCount - right.OneCentCount,
                left.TenCentCount - right.TenCentCount,
                left.QuarterCount - right.QuarterCount,
                left.OneDollarCount - right.OneDollarCount,
                left.FiveDollarCount - right.FiveDollarCount,
                left.TwentyDollarCount - right.TwentyDollarCount
                );

            return subtraction;
        }

        public override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;

                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCount;
                hashCode = (hashCode * 397) ^ OneCentCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;

                return hashCode;
            }
        }

        public override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount
                && TenCentCount == other.TenCentCount
                && QuarterCount == other.QuarterCount
                && OneDollarCount == other.OneDollarCount
                && FiveDollarCount == other.FiveDollarCount
                && TwentyDollarCount == other.TwentyDollarCount;
        }

        public override string ToString()
        {
            if (Amount < 1)
            {
                return $"¢{Amount}";
            }

            return $"${Amount}";
        }
    }
}
