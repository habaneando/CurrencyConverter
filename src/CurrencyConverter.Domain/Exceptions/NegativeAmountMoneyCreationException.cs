namespace CurrencyConverter.Domain;

public class NegativeAmountMoneyCreationException : DomainException
{
    public NegativeAmountMoneyCreationException()
        : base("Amount cannot be negative.")
    {
    }
}
