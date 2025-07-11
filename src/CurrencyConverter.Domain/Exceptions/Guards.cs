namespace CurrencyConverter.Domain;

public static class Guard
{
    public static void NegativeAmount(decimal amount)
    {
        if (amount < 0)
            throw new NegativeAmountMoneyCreationException();
    }

    public static void NegativeDecimalPlaces(decimal decimalPlaces)
    {
        if (decimalPlaces < 0)
            throw new ArgumentException("Decimal places cannot be negative.", nameof(decimalPlaces));
    }

    public static void EmptyCurrencyCode(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
            throw new EmptyCodeCurrencyCreationException();
    }

    public static void EmptyCurrencySymbol(string symbol)
    {
        if (string.IsNullOrWhiteSpace(symbol))
            throw new ArgumentException("Currency symbol cannot be empty.", nameof(symbol));
    }

    public static void InvalidISOCurrencyCode(string currencyCode)
    {
        currencyCode = currencyCode.ToUpperInvariant();

        if (currencyCode.Length != 3 || !currencyCode.All(char.IsLetter))
            throw new InvalidISOCodeCurrencyCreationException(currencyCode);
    }

    public static void EmptyCurrency(Currency currency)
    {
        if (currency == null)
            throw new EmptyCurrencyMoneyCreationException();
    }

    public static void DifferentCurrency(Currency currency, Currency otherCurrency)
    {
        if (!currency.Equals(otherCurrency))
            throw new InvalidOperationException($"Cannot compare {currency.Code} with {otherCurrency.Code}. Currencies must match.");
    }

    public static void DifferentAmountPrecisionAndDecimalPlaces(decimal amount, Currency currency)
    {
        var factor = (decimal)Math.Pow(10, currency.DecimalPlaces);

        if (Math.Round(amount * factor) != amount * factor)
            throw new ArgumentException($"Amount precision cannot exceed {currency.DecimalPlaces} decimal places for {currency.Code}.", nameof(amount));
    }

    public static void AddDifferentCurrencyCode(Currency currency, Currency otherCurrency)
    {
        if (!currency.Equals(otherCurrency))
            throw new InvalidMoneyOperationException(currency.Code, otherCurrency.Code);
    }

    public static void SubstractDifferentCurrencyCode(Currency currency, Currency otherCurrency)
    {
        if (!currency.Equals(otherCurrency))
            throw new InvalidMoneyOperationException(currency.Code, otherCurrency.Code);
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
