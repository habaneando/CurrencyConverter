namespace CurrencyConverter.Domain;

public class InvalidISOCodeCurrencyCreationException : DomainException
{
    public InvalidISOCodeCurrencyCreationException(string currencyCode)
        : base($"Currency code: {currencyCode} must be a 3-letter ISO 4217 code.")
    {
    }
}
