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
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));

        if (currency == null)
            throw new ArgumentNullException(nameof(currency), "Currency cannot be null.");

        var factor = (decimal)Math.Pow(10, currency.DecimalPlaces);

        if (Math.Round(amount * factor) != amount * factor)
            throw new ArgumentException($"Amount precision cannot exceed {currency.DecimalPlaces} decimal places for {currency.Code}.", nameof(amount));

        Amount = amount;

        Currency = currency;
    }

    public Money Add(Money other)
    {
        if (!Currency.Equals(other.Currency))
            throw new InvalidOperationException($"Cannot add {other.Currency.Code} to {Currency.Code}. Currencies must match.");

        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        if (!Currency.Equals(other.Currency))
            throw new InvalidOperationException($"Cannot subtract {other.Currency.Code} from {Currency.Code}. Currencies must match.");

        var result = Amount - other.Amount;
        if (result < 0)
            throw new InvalidOperationException("Subtraction would result in negative amount.");

        return new Money(result, Currency);
    }

    public Money Multiply(decimal factor)
    {
        if (factor < 0)
            throw new ArgumentException("Factor cannot be negative.", nameof(factor));

        return new Money(Amount * factor, Currency);
    }

    public Money Divide(decimal divisor)
    {
        if (divisor <= 0)
            throw new ArgumentException("Divisor must be positive.", nameof(divisor));

        return new Money(Amount / divisor, Currency);
    }

    public int CompareTo(Money other)
    {
        if (other == null) return 1;

        if (!Currency.Equals(other.Currency))
            throw new InvalidOperationException($"Cannot compare {Currency.Code} with {other.Currency.Code}. Currencies must match.");

        return Amount.CompareTo(other.Amount);
    }

    public static Money operator +(Money left, Money right) => left.Add(right);

    public static Money operator -(Money left, Money right) => left.Subtract(right);

    public static Money operator *(Money money, decimal factor) => money.Multiply(factor);

    public static Money operator /(Money money, decimal divisor) => money.Divide(divisor);

    public static bool operator >(Money left, Money right) => left.CompareTo(right) > 0;

    public static bool operator <(Money left, Money right) => left.CompareTo(right) < 0;

    public static bool operator >=(Money left, Money right) => left.CompareTo(right) >= 0;

    public static bool operator <=(Money left, Money right) => left.CompareTo(right) <= 0;

    public class Factory(Currency2.Factory CurrencyFactory)
    {
        public Money Create(decimal amount, string currencyCode)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));

            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentException("Currency code cannot be empty.", nameof(currencyCode));

            currencyCode = currencyCode.ToUpperInvariant();

            if (currencyCode.Length != 3 || !currencyCode.All(char.IsLetter))
                throw new ArgumentException("Currency code must be a 3-letter ISO 4217 code.", nameof(currencyCode));

            var currency = CurrencyFactory.Create(currencyCode);

            return new Money(amount, currency);
        }

        public Money Create(decimal amount, Currency2 currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));

            if (currency == null)
                throw new ArgumentNullException(nameof(currency), "Currency cannot be null.");

            return new Money(amount, currency);
        }
    }
}
