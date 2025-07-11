namespace CurrencyConverter.Domain;

public sealed record Money
{
    public decimal Amount { get; init; }

    public Currency Currency { get; init; }

    public bool IsZero => Amount == 0;

    public bool IsPositive => Amount > 0;

    public bool IsNegative => Amount < 0;

    private Money(decimal amount, Currency currency)
    {
        Guards.NegativeAmount(amount);

        Guards.EmptyCurrency(currency);

        Guards.DifferentAmountPrecisionAndDecimalPlaces(amount, currency);

        Amount = amount;

        Currency = currency;
    }

    public Money Add(Money other)
    {
        Guards.AddDifferentCurrencyCode(Currency, other.Currency);

        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        Guards.SubstractDifferentCurrencyCode(Currency, other.Currency); 

        var result = Amount - other.Amount;

        return new Money(result, Currency);
    }

    public Money Multiply(decimal factor)
    {
        Guards.NegativeFactor(factor);

        return new Money(Amount * factor, Currency);
    }

    public Money Divide(decimal divisor)
    {
        Guards.NonDivideByZero(divisor);

        return new Money(Amount / divisor, Currency);
    }

    public int CompareTo(Money other)
    {
        if (other == null) return 1;

        Guards.DifferentCurrency(Currency, other.Currency);

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

    public class Factory(Currency.Factory CurrencyFactory)
    {
        public async Task<Money> Create(decimal amount, string currencyCode)
        {
            Guards.NegativeAmount(amount);

            Guards.EmptyCurrencyCode(currencyCode);

            Guards.EmptyCurrencyCode(currencyCode);

            var currency = await CurrencyFactory.Create(currencyCode)
                .ConfigureAwait(false);

            return new Money(amount, currency);
        }

        public Money Create(decimal amount, Currency currency)
        {
            Guards.NegativeAmount(amount);

            Guards.EmptyCurrency(currency);

            return new Money(amount, currency);
        }
    }
}
