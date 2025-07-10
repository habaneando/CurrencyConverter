namespace CurrencyConverter.Domain;

public class EmptyCurrencyMoneyCreationException : DomainException
{
    public EmptyCurrencyMoneyCreationException()
        : base("Currency can't be empty.")
    {
    }
}
