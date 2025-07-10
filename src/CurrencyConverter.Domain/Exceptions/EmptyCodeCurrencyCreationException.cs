namespace CurrencyConverter.Domain;

public class EmptyCodeCurrencyCreationException : DomainException
{
    public EmptyCodeCurrencyCreationException()
        : base("Currency code can't be empty.")
    {
    }
}
