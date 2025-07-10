namespace CurrencyConverter.Domain;

public class InvalidMoneyOperationException : DomainException
{
    public InvalidMoneyOperationException(string currencyCode, string otherCurrencyCode)
        : base($"Can't apply operations for {currencyCode} and {otherCurrencyCode} currencies. Currencies must match.")
    {
    }
}
