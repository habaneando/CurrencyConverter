namespace CurrencyConverter.Domain;

public class InterestRateCreationException : DomainException
{
    public InterestRateCreationException()
        : base("Rate must be non-negative")
    {
    }
}
