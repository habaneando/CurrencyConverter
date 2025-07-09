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
        public Money Create(decimal amount, string currencyCode)
        {
            Guard.NegativeAmount(amount);

            Guard.EmptyCurrency(currencyCode);

            Guard.EmptyCurrency(currencyCode);

            var currency = CurrencyFactory.Create(currencyCode);

            return new Money(amount, currency);
        }

        public Money Create(decimal amount, Currency2 currency)
        {
            Guard.NegativeAmount(amount);

            Guard.NullCurrency(currency);

            return new Money(amount, currency);
        }
    }

    private static class Guard
    {
        public static void NegativeAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
        }

        public static void EmptyCurrency(string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentException("Currency code cannot be empty.", nameof(currencyCode));
        }

        public static void InvalidISOCurrencyCode(string currencyCode)
        {
            currencyCode = currencyCode.ToUpperInvariant();

            if (currencyCode.Length != 3 || !currencyCode.All(char.IsLetter))
                throw new ArgumentException("Currency code must be a 3-letter ISO 4217 code.", nameof(currencyCode));
        }

        public static void NullCurrency(Currency2 currency)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency), "Currency cannot be null.");
        }

        public static void DifferentCurrency(Currency2 currency, Currency2 otherCurrency)
        {
            if (!currency.Equals(otherCurrency))
                throw new InvalidOperationException($"Cannot compare {currency.Code} with {otherCurrency.Code}. Currencies must match.");
        }

        public static void DifferentAmountPrecisionAndDecimalPlaces(decimal amount, Currency2 currency)
        {
            var factor = (decimal)Math.Pow(10, currency.DecimalPlaces);

            if (Math.Round(amount * factor) != amount * factor)
                throw new ArgumentException($"Amount precision cannot exceed {currency.DecimalPlaces} decimal places for {currency.Code}.", nameof(amount));
        }

        public static void AddDifferentCurrencyCode(Currency2 currency, Currency2 otherCurrency)
        {
            if (!currency.Equals(otherCurrency))
                throw new InvalidOperationException($"Cannot add {otherCurrency.Code} to {currency.Code}. Currencies must match.");
        }

        public static void SubstractDifferentCurrencyCode(Currency2 currency, Currency2 otherCurrency)
        {
            if (!currency.Equals(otherCurrency))
                throw new InvalidOperationException($"Cannot subtract {otherCurrency.Code} from {currency.Code}. Currencies must match.");
        }

        public static void NegativeFactor(decimal factor)
        {
            if (factor < 0)
                throw new ArgumentException("Factor cannot be negative.", nameof(factor));
        }

        public static void NonDivideByZero(decimal divisor)
        {
            if (divisor <= 0)
                throw new ArgumentException("Divisor must be positive.", nameof(divisor));
        }
    }
}
