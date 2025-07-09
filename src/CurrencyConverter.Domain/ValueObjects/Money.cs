namespace CurrencyConverter.Domain;

public class Money
{
    public decimal Amount { get; init; }

    public Currency2 Currency { get; init; }

    public bool IsZero => Amount == 0;

    public bool IsPositive => Amount > 0;

    public bool IsNegative => Amount < 0;

    private Money(decimal amount, Currency2 currency)
    {
        Guard.NegativeAmount(amount);

        Guard.NullCurrency(currency);

        Guard.DifferentAmountPrecisionAndDecimalPlaces(amount, currency);

        Amount = amount;

        Currency = currency;
    }

    public Money Add(Money other)
    {
        Guard.AddDifferentCurrencyCode(Currency, other.Currency);

        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        Guard.SubstractDifferentCurrencyCode(Currency, other.Currency); 

        var result = Amount - other.Amount;

        return new Money(result, Currency);
    }

    public Money Multiply(decimal factor)
    {
        Guard.NegativeFactor(factor);

        return new Money(Amount * factor, Currency);
    }

    public Money Divide(decimal divisor)
    {
        Guard.NonDivideByZero(divisor);

        return new Money(Amount / divisor, Currency);
    }

    public int CompareTo(Money other)
    {
        if (other == null) return 1;

        Guard.DifferentCurrency(Currency, other.Currency);

        return Amount.CompareTo(other.Amount);
    }

    public static Money operator +(Money left, Money right) =>
        left.Add(right);

    public static Money operator -(Money left, Money right) =>
        left.Subtract(right);

    public static Money operator *(Money money, decimal factor) =>
        money.Multiply(factor);

    public static Money operator /(Money money, decimal divisor) =>
        money.Divide(divisor);

    public static bool operator >(Money left, Money right) =>
        left.CompareTo(right) > 0;

    public static bool operator <(Money left, Money right) =>
        left.CompareTo(right) < 0;

    public static bool operator >=(Money left, Money right) =>
        left.CompareTo(right) >= 0;

    public static bool operator <=(Money left, Money right) =>
        left.CompareTo(right) <= 0;

    public class Factory(Currency2.Factory CurrencyFactory)
    {
        public async Task<Money> Create(decimal amount, string currencyCode)
        {
            Guard.NegativeAmount(amount);

            Guard.EmptyCurrencyCode(currencyCode);

            Guard.EmptyCurrencyCode(currencyCode);

            var currency = await CurrencyFactory.Create(currencyCode).ConfigureAwait(false);

            return new Money(amount, currency);
        }

        public Money Create(decimal amount, Currency2 currency)
        {
            Guard.NegativeAmount(amount);

            Guard.NullCurrency(currency);

            return new Money(amount, currency);
        }
    }
}
