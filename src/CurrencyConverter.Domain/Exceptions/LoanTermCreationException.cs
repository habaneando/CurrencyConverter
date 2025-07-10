namespace CurrencyConverter.Domain;

public class LoanTermCreationException : DomainException
{
    public LoanTermCreationException()
        : base("Loan term creation failed due to invalid input.")
    {
    }
}
